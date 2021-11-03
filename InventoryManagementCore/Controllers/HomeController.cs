using InventoryManagementCore.Models;
using InventoryManagementCore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _custRepo;
        private readonly IBillRepository _billRepo;
        public readonly IProductRepository _pdtRepo;

        public HomeController(ILogger<HomeController> logger, ICustomerRepository _custRepo, IBillRepository _billRepo, IProductRepository _pdtRepo)
        {
            _logger = logger;
            this._custRepo = _custRepo;
            this._billRepo = _billRepo;
            this._pdtRepo = _pdtRepo;
        }

        public IActionResult Index()
        {   
            // calculate total customers
            var customers = _custRepo.GetAllCustomers();
            ViewBag.NoOfcustomers = customers.Count();

            // calculate total bills
            var bills = _billRepo.GetAllBills();
            var billsCount = bills.Count();
            int totalSales = 0;
            foreach(var bill in bills)
            {
                totalSales += bill.BillTotalCost;
            }
            ViewBag.totalSales = totalSales;
            ViewBag.bills = bills;
            ViewBag.billsCount = billsCount;

            // find recently added products
            var products = _pdtRepo.GetAllProducts();
            ViewBag.Products = products;
            ViewBag.ProductCount = products.Count();

            
            return View();
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
