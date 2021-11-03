using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int Id);

        IEnumerable<Customer> GetAllCustomers();

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);

        Customer DeleteCustomer(int Id);
    }
}
