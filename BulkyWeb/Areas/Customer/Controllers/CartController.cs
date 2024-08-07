using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartIndexViewModel ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId,
                includeProperties: "Product"),
                OrderHeader = new()
            };

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            return View(ShoppingCartVM);
        }


        public async Task<IActionResult> Plus(int cartId)
        {
            var cartFromDb =await _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int cartId)
        {
            var cartFromDb = await _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                //remove that from cart
                // Get the count asynchronously
                var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == cartFromDb.ApplicationUserId);
                int cartItemCount = cartItems.Count() - 1;

                // Set the count in the session
                HttpContext.Session.SetInt32(SD.SessionCart, cartItemCount);

                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int cartId)
        {
            var cartFromDb = await  _unitOfWork.ShoppingCart.GetAsync(u => u.Id == cartId);
            // Get the count asynchronously
            var cartItems = await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == cartFromDb.ApplicationUserId);
            int cartItemCount = cartItems.Count() - 1;

            // Set the count in the session
            HttpContext.Session.SetInt32(SD.SessionCart, cartItemCount);

            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }



        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;
                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }




        public async Task<IActionResult> Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList =await  _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId,
                includeProperties: "Product"),
                OrderHeader = new()
            };

            ShoppingCartVM.OrderHeader.ApplicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == userId);

            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;



            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM.ShoppingCartList =await _unitOfWork.ShoppingCart.GetAllAsync(u => u.ApplicationUserId == userId,
                includeProperties: "Product");

            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

            ApplicationUser applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == userId);


            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //it is a regular customer 
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            }
            else
            {
                //it is a company user
                ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusDelayedPayment;
                ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
            }
            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            await _unitOfWork.SaveAsync();
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                await _unitOfWork.SaveAsync();
            }

            if (applicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                //it is a regular customer account and we need to capture payment
                //stripe logic
                var domain = "https://localhost:7169/";
                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                    CancelUrl = domain + "customer/cart/index",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach (var item in ShoppingCartVM.ShoppingCartList)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Title
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItem);
                }


                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.OrderHeader.UpdateStripePaymentID(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
                await _unitOfWork.SaveAsync();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);

            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }


        public async Task<IActionResult> OrderConfirmation(int id)
        {
            OrderHeader orderHeader = await _unitOfWork.OrderHeader.GetAsync(u => u.Id == id, includeProperties: "ApplicationUser");
            if (orderHeader.PaymentStatus != SD.PaymentStatusDelayedPayment)
            {
                //this is an order by customer

                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    await _unitOfWork.SaveAsync();
                }


            }

            List<ShoppingCart> shoppingCarts =await  _unitOfWork.ShoppingCart
                .GetAllAsync(u => u.ApplicationUserId == orderHeader.ApplicationUserId);

            shoppingCarts = shoppingCarts.ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
           await _unitOfWork.SaveAsync();
            return View(id);

        }


    }
}
