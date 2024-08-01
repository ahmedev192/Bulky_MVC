using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Product/Index
        public async Task<IActionResult> Index(string sortOrder)
        {
            var productList = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            ViewBag.TitleSortParam = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.ISBNSortParam = sortOrder == "isbn" ? "isbn_desc" : "isbn";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            ViewBag.AuthorSortParam = sortOrder == "author" ? "author_desc" : "author";
            ViewBag.CategorySortParam = sortOrder == "category" ? "category_desc" : "category";

            // Determine the sort order
            switch (sortOrder)
            {
                case "title_desc":
                    productList = productList.OrderByDescending(p => p.Title).ToList();
                    break;
                case "isbn":
                    productList = productList.OrderBy(p => p.ISBN).ToList();
                    break;
                case "isbn_desc":
                    productList = productList.OrderByDescending(p => p.ISBN).ToList();
                    break;
                case "price":
                    productList = productList.OrderBy(p => p.ListPrice).ToList();
                    break;
                case "price_desc":
                    productList = productList.OrderByDescending(p => p.ListPrice).ToList();
                    break;
                case "author":
                    productList = productList.OrderBy(p => p.Author).ToList();
                    break;
                case "author_desc":
                    productList = productList.OrderByDescending(p => p.Author).ToList();
                    break;
                case "category":
                    productList = productList.OrderBy(p => p.Category.Name).ToList();
                    break;
                case "category_desc":
                    productList = productList.OrderByDescending(p => p.Category.Name).ToList();
                    break;
                default:
                    productList = productList.OrderBy(p => p.Title).ToList();
                    break;
            }

            var viewModel = new ProductIndexViewModel
            {
                Products = productList
            };
            return View(viewModel);
        }


        // GET: Admin/Product/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductCreateEditViewModel
            {
                Categories = await _unitOfWork.Category.GetAllAsync()
            };
            return View(viewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateEditViewModel viewModel , IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    viewModel.ImageUrl = @"\Images\Products\" + fileName;
                }
                var product = new Product
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    ISBN = viewModel.ISBN,
                    Author = viewModel.Author,
                    ListPrice = viewModel.ListPrice,
                    Price = viewModel.Price,
                    Price50 = viewModel.Price50,
                    Price100 = viewModel.Price100,
                    CategoryId = viewModel.CategoryId,
                    ImageUrl = viewModel.ImageUrl
                };



                _unitOfWork.Product.Add(product);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            viewModel.Categories =await _unitOfWork.Category.GetAllAsync();
            return View(viewModel);
        }

        // GET: Admin/Product/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product.GetAsync(u => u.Id == id, includeProperties: "Category");

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductCreateEditViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ISBN = product.ISBN,
                Author = product.Author,
                ListPrice = product.ListPrice,
                Price = product.Price,
                Price50 = product.Price50,
                Price100 = product.Price100,
                CategoryId = product.CategoryId,
                Categories =await _unitOfWork.Category.GetAllAsync(),
                ImageUrl = product.ImageUrl
            };
            return View(viewModel);
        }

        // POST: Admin/Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCreateEditViewModel viewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var oldData = await _unitOfWork.Product.GetAsync(u => u.Id == viewModel.Id);
                        string oldFileName = Path.GetFileName(oldData.ImageUrl);
                        string oldFilePath = Path.Combine(productPath, oldFileName);

                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    viewModel.ImageUrl = @"\Images\Products\" + fileName;
                }

                var product = await _unitOfWork.Product.GetAsync(u => u.Id == viewModel.Id);
                if (product == null)
                {
                    return NotFound();
                }

                product.Title = viewModel.Title;
                product.Description = viewModel.Description;
                product.ISBN = viewModel.ISBN;
                product.Author = viewModel.Author;
                product.ListPrice = viewModel.ListPrice;
                product.Price = viewModel.Price;
                product.Price50 = viewModel.Price50;
                product.Price100 = viewModel.Price100;
                product.CategoryId = viewModel.CategoryId;
                product.ImageUrl = viewModel.ImageUrl;

                _unitOfWork.Product.Update(product);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            viewModel.Categories = await _unitOfWork.Category.GetAllAsync();
            return View(viewModel);
        }

        // GET: Admin/Product/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product =await _unitOfWork.Product.GetAsync(u => u.Id == id, includeProperties: "Category");
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                ISBN = product.ISBN,
                Author = product.Author,
                ListPrice = product.ListPrice,
                Price = product.Price,
                Price50 = product.Price50,
                Price100 = product.Price100,
                CategoryName = product.Category.Name,
                ImageUrl = product.ImageUrl
            };
            return View(viewModel);
        }

        // POST: Admin/Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product =await _unitOfWork.Product.GetAsync(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            string productPath = Path.Combine(wwwRootPath, @"Images\Products");

            string oldFileName = Path.GetFileName(product.ImageUrl);
            string oldFilePath = Path.Combine(productPath, oldFileName);

            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }
        _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
