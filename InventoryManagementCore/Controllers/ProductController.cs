using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using InventoryManagementCore.ViewModels.Product;
using System.IO;

namespace InventoryManagementCore.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _pdtRepo;
        public readonly IWebHostEnvironment hostEnvironment;
        public ProductController(IProductRepository _pdtRepo, IWebHostEnvironment hostEnvironment)
        {
            this._pdtRepo = _pdtRepo;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var model = _pdtRepo.GetAllProducts();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _pdtRepo.GetCategories();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

               
                if (model.ProductPhoto != null)
                {
                    string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" +model.ProductPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.ProductPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newProduct = new Product()
                {
                    ProductName = model.ProductName,
                    BuyingPrice = model.BuyingPrice,
                    SellingPrice = model.SellingPrice,
                    Quantity = model.Quantity,
                    CategoryId = model.CategoryId,
                    Category = model.Category,
                    ProductPhotoPath = uniqueFileName
                };
                _pdtRepo.AddProduct(newProduct);
                return RedirectToAction("details", new { id = newProduct.ProductId });
            }
            return View();
        }

        public ViewResult Details(int id)
        {
            Product product = _pdtRepo.GetProduct(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id);
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
