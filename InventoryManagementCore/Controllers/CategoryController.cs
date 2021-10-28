using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;
        public CategoryController(ICategoryRepository catRepo)
        {
            this._catRepo = catRepo;
        }


        public IActionResult Index()
        {
            var model = _catRepo.GetAllCategories();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                Category cat = _catRepo.AddCategory(c);
                return RedirectToAction("details", new { id = cat.CategoryId });
            }
            return View();
        }
        public ViewResult Details(int id)
        {
            Category cat = _catRepo.GetCategory(id);
            if (cat == null)
            {
                Response.StatusCode = 404;
                return View("Product Not Found", id);
            }
            return View(cat);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category cat = _catRepo.GetCategory(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Category cat = _catRepo.DeleteCategory(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Category cat = _catRepo.GetCategory(id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                Category cat = _catRepo.GetCategory(model.CategoryId);
                //Response.WriteAsync(pdt.pid + " " + pdt.productName);
                cat.CategoryName = model.CategoryName;
                Category updatedDept = _catRepo.UpdateCategory(cat);

                return RedirectToAction("index");
            }
            return View(model);
        }

    }
}
