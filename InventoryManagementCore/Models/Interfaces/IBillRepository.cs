using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface IBillRepository
    {
        Bill GetBill(int Id);

        IEnumerable<Bill> GetAllBills();

        IEnumerable<Bill> GetAllCustomerBills();

        Bill AddBill(Bill bill);

        Bill UpdateBill(Bill bill);

        Bill DeleteBill(int Id);

        IEnumerable<Customer> GetCustomers();

        BillItem AddBillItem(int billId,BillItem item);

    }
}
