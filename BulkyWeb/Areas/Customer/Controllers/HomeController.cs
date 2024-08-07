using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                // Get all shopping cart items asynchronously
                var items = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == claim.Value);

                // Count the items
                int itemCount = items.Count();

                // Now you can use itemCount as needed
                HttpContext.Session.SetInt32(SD.SessionCart, itemCount);

            }
            IEnumerable<Product> productList = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            return View(productList);
        }


        public async Task<IActionResult> Details(int productId)
        {
            Product product = await _unitOfWork.Product.GetAsync(u => u.Id == productId, includeProperties: "Category");
            ShoppingCart cart = new()
            {
                Product = await _unitOfWork.Product.GetAsync(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;
            ShoppingCart cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.ApplicationUserId == userId &&
   u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.SaveAsync();
                // Get the count asynchronously
                var cartItem = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId);
                int cartItemCount = cartFromDb.Count;

                // Set the count in the session
                HttpContext.Session.SetInt32(SD.SessionCart, cartItemCount);

            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);

                _unitOfWork.SaveAsync();

            }


            TempData["success"] = "Cart updated successfully";


            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
