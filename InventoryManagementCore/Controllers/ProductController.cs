using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace InventoryManagementCore.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _pdtRepo;
        public ProductController(IProductRepository _pdtRepo)
        {
            this._pdtRepo = _pdtRepo;
        }
        public IActionResult Index()
        {
            var model = _pdtRepo.GetAllProducts();
            return View(model);
        }

        //[HttpGet]
        //public ViewResult Create()
        //{
        //    var Categories = _pdtRepo.GetCategories();
        //    ViewData["CategoryId"] = new SelectList(Categories, "CategoryId", "CategoryName");

            
        //    return View();
        //}

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _pdtRepo.GetCategories();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                //Response.WriteAsync(p.Category.CategoryName);
                Product pdt = _pdtRepo.AddProduct(p);
                return RedirectToAction("details", new { id = pdt.ProductId });
            }
            return View();
        }

        public ViewResult Details(int id)
        {
            Product product = _pdtRepo.GetProduct(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return View("Product Not Found", id);
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product pdt = _pdtRepo.GetProduct(id);
            if (pdt == null)
            {
                return NotFound();
            }
            return View(pdt);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
             _pdtRepo.DeleteProduct(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Product pdt = _pdtRepo.GetProduct(id);
            var Categories = _pdtRepo.GetCategories();
            ViewData["CategoryId"] = new SelectList(Categories, "CategoryId", "CategoryName");
            return View(pdt);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                Product pdt = _pdtRepo.GetProduct(model.ProductId);
                //Response.WriteAsync(pdt.pid + " " + pdt.productName);
                pdt.ProductName = model.ProductName;
                pdt.BuyingPrice = model.BuyingPrice;
                pdt.SellingPrice = model.SellingPrice;
                pdt.Quantity = model.Quantity;
                _pdtRepo.UpdateProduct(pdt);

                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
