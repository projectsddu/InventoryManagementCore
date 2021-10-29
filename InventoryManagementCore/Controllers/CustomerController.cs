using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ICustomerRepository _custRepo;
        public CustomerController(ICustomerRepository _custRepo)
        {
            this._custRepo = _custRepo;
        }

        public IActionResult Index()
        {
            var model = _custRepo.GetAllCustomers();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _custRepo.AddCustomer(c);
                return RedirectToAction("details", new { id = customer.CustomerId });
            }
            return View();
        }

        public ViewResult Details(int id)
        {
            Customer customer = _custRepo.GetCustomer(id);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return View("Customer Not Found", id);
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = _custRepo.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Customer customer = _custRepo.DeleteCustomer(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Customer customer = _custRepo.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _custRepo.GetCustomer(model.CustomerId);
                customer.CustomerName = model.CustomerName;
                customer.CustomerPhoneNo = model.CustomerPhoneNo;
                customer.CustomerAddress = model.CustomerAddress;
                Customer updatedCustomer = _custRepo.UpdateCustomer(customer);
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}
