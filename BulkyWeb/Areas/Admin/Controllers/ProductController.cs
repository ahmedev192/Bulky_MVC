using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
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
        public async Task<IActionResult> Create(ProductCreateEditViewModel viewModel, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                viewModel.ProductImages = new List<ProductImage>(); // Initialize the list

                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Add the image to the viewModel's ProductImages list
                        viewModel.ProductImages.Add(new ProductImage
                        {
                            ImageUrl = @"\Images\Products\" + fileName,
                            ProductId = 0 // Temporary, will be set when saving to the database
                        });
                    }
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
                    ProductImages = viewModel.ProductImages // Set the images to the product
                };

                _unitOfWork.Product.Add(product);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            viewModel.Categories = await _unitOfWork.Category.GetAllAsync();
            return View(viewModel);
        }

        // GET: Admin/Product/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product.GetAsync(u => u.Id == id, includeProperties: "Category,ProductImages");

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
                ProductImages = product.ProductImages
            };
            return View(viewModel);
        }

        // POST: Admin/Product/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCreateEditViewModel viewModel, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var product = await _unitOfWork.Product.GetAsync(u => u.Id == viewModel.Id, includeProperties: "ProductImages");
                if (product == null)
                {
                    return NotFound();
                }

                if (files != null && files.Count > 0)
                {
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                    // Delete old images
                    foreach (var image in product.ProductImages)
                    {
                        string oldFilePath = Path.Combine(wwwRootPath, image.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Clear the old images from the database
                    _unitOfWork.ProductImage.RemoveRange(product.ProductImages);
                    await _unitOfWork.SaveAsync();

                    // Save new images
                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }

                            var newImage = new ProductImage
                            {
                                ImageUrl = @"\Images\Products\" + fileName,
                                ProductId = product.Id
                            };
                            product.ProductImages.Add(newImage);
                        }
                    }
                }

                // Update the other product properties
                product.Title = viewModel.Title;
                product.Description = viewModel.Description;
                product.ISBN = viewModel.ISBN;
                product.Author = viewModel.Author;
                product.ListPrice = viewModel.ListPrice;
                product.Price = viewModel.Price;
                product.Price50 = viewModel.Price50;
                product.Price100 = viewModel.Price100;
                product.CategoryId = viewModel.CategoryId;

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

            var product =await _unitOfWork.Product.GetAsync(u => u.Id == id, includeProperties: "Category,ProductImages");
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
                ProductImages = product.ProductImages
            };
            return View(viewModel);
        }

        // POST: Admin/Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _unitOfWork.Product.GetAsync(u => u.Id == id, includeProperties: "ProductImages");
            if (product == null)
            {
                return NotFound();
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            // Loop through each image in the ProductImages list and delete the associated files
            foreach (var productImage in product.ProductImages)
            {
                string productPath = Path.Combine(wwwRootPath, productImage.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(productPath))
                {
                    System.IO.File.Delete(productPath);
                }
            }

            // Remove the product and save changes to the database
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveAsync();

            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
