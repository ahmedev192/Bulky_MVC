using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch all categories
            var categories = await _unitOfWork.Category.GetAllAsync();

            // Map to view model
            var viewModel = new CategoryIndexViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map view model to entity
                var category = new Category
                {
                    Name = model.Name,
                    DisplayOrder = model.DisplayOrder
                };

                _unitOfWork.Category.Add(category);
                await _unitOfWork.SaveAsync();  // Assuming SaveAsync() exists
                TempData["success"] = "Category created successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = await _unitOfWork.Category.GetAsync(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            // Map entity to view model
            var model = new CategoryCreateEditViewModel
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name,
                DisplayOrder = categoryFromDb.DisplayOrder
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map view model to entity
                var category = new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                    DisplayOrder = model.DisplayOrder
                };

                _unitOfWork.Category.Update(category);
                await _unitOfWork.SaveAsync();  // Assuming SaveAsync() exists
                TempData["success"] = "Category updated successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = await _unitOfWork.Category.GetAsync(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            // Map entity to view model
            var model = new CategoryDetailsViewModel
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name,
                DisplayOrder = categoryFromDb.DisplayOrder
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _unitOfWork.Category.GetAsync(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            await _unitOfWork.SaveAsync();  
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}
