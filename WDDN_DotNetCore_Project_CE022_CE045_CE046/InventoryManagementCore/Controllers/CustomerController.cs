using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult PayDebt(int id)
        {
            Customer cust = _custRepo.GetCustomer(id);
            //ViewBag.customer = cust
            return View(cust);
        }
        [HttpPost]
        public IActionResult PayDebt(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _custRepo.UpdateCustomer(customer);

                return RedirectToAction("Index");
            }

            Response.WriteAsync(customer.totalOutstanding.ToString());
            return View();
            
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
                return View("CustomerNotFound", id);
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
            Customer customer = _custRepo.GetCustomer(id);
            if(customer.totalOutstanding == 0)
            {
                _custRepo.DeleteCustomer(id);
            }
            else
            {
                ViewBag.Message = "Customer cannot be deleted as he has not cleared his/her previous debt.";
                return View("Message");
            }
            return RedirectToAction("Index");
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
