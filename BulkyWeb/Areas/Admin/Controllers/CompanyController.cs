using Bulky.DataAccess.Rrpository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


     public async Task<IActionResult> Index()
        {
            // Fetch all companies
            var companies = await _unitOfWork.Company.GetAllAsync();

            // Map to view model
            var viewModel = new CompanyIndexViewModel
            {
                Companies = companies
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map view model to entity
                var company = new Company
                {
                    Name = model.Name,
                    State = model.State,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    PhoneNumber = model.PhoneNumber,
                };

                _unitOfWork.Company.Add(company);
                await _unitOfWork.SaveAsync();  // Assuming SaveAsync() exists
                TempData["success"] = "Company created successfully";

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

            var companyFromDb = await _unitOfWork.Company.GetAsync(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }

            // Map entity to view model
            var model = new CompanyCreateEditViewModel
            {
                Id = companyFromDb.Id,
                Name = companyFromDb.Name,
                State = companyFromDb.State,
                StreetAddress = companyFromDb.StreetAddress,
                City = companyFromDb.City,
                PostalCode = companyFromDb.PostalCode,
                PhoneNumber = companyFromDb.PhoneNumber,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map view model to entity
                var company = new Company
                {
                    Id = model.Id,
                    Name = model.Name,
                    State = model.State,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    PhoneNumber = model.PhoneNumber,
                };

                _unitOfWork.Company.Update(company);
                await _unitOfWork.SaveAsync();  // Assuming SaveAsync() exists
                TempData["success"] = "Company updated successfully";

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

            var companyFromDb = await _unitOfWork.Company.GetAsync(u => u.Id == id);
            if (companyFromDb == null)
            {
                return NotFound();
            }

            // Map entity to view model
            var model = new CompanyDetailsViewModel
            {
                Id = companyFromDb.Id,
                Name = companyFromDb.Name,
                State = companyFromDb.State,
                StreetAddress = companyFromDb.StreetAddress,
                City = companyFromDb.City,
                PostalCode = companyFromDb.PostalCode,
                PhoneNumber = companyFromDb.PhoneNumber,
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _unitOfWork.Company.GetAsync(u => u.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.Company.Remove(company);
            await _unitOfWork.SaveAsync();  
            TempData["success"] = "Company deleted successfully";

            return RedirectToAction(nameof(Index));
        }

    }
}
