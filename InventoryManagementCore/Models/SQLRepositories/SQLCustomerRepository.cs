using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.SQLRepositories
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public SQLCustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Customer AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int Id)
        {
            Customer c = context.Customers.Find(Id);
            if (c != null)
            {
                context.Customers.Remove(c);
                context.SaveChanges();
            }
            return c;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }

        public Customer GetCustomer(int Id)
        {
            return context.Customers.Find(Id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var cust = context.Customers.Attach(customer);
            cust.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customer;
        }
    }
}
