using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Controllers
{
    class ProductJSONModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int sellingPrice { get; set; }
    }
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepo;
        private readonly ICustomerRepository _custRepo;
        private readonly IProductRepository _prodRepo;
        public BillController(IBillRepository _billRepo, ICustomerRepository _custRepo, 
            IProductRepository _prodRepo)
        {
            this._billRepo = _billRepo;
            this._custRepo = _custRepo;
            this._prodRepo = _prodRepo;
        }

        public IActionResult Index()
        {
            var model = _billRepo.GetAllBills();
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.CustomerDetails = _custRepo.GetAllCustomers();
            ViewBag.ProductDetails = _prodRepo.GetAllProducts();
            return View();
        }

        public ViewResult Details(int id)
        {
            Bill bill = _billRepo.GetBill(id);
            if (bill == null)
            {
                Response.StatusCode = 404;
                return View("Bill Not Found", id);
            }
            return View(bill);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Bill bill = _billRepo.GetBill(id);
            if (bill == null)
            {
                return NotFound();
            }
            return View(bill);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Bill bill = _billRepo.DeleteBill(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Bill bill = _billRepo.GetBill(id);
            return View(bill);
        }

        [HttpPost]
        public IActionResult Edit(Bill model)
        {
            if (ModelState.IsValid)
            {
                Bill bill = _billRepo.GetBill(model.BillId);
                bill.BillDateTime = model.BillDateTime;
                bill.BillTotalCost = model.BillTotalCost;
                bill.BillTotalPaid = model.BillTotalPaid;
                Bill updatedBill = _billRepo.UpdateBill(bill);
                return RedirectToAction("index");
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult fillCustomerDetails(int id)
        {
            Customer customer = _custRepo.GetCustomer(id);
            return Json(customer);
        }

        [HttpPost]

        public JsonResult fillProductDetails(int id)
        {
            Product product = _prodRepo.GetProduct(id);

            ProductJSONModel p = new ProductJSONModel()
            {
                productName = product.ProductName,
                sellingPrice = product.SellingPrice,
                productId = product.ProductId
            };

            return Json(p);
            
        }
     }
}
