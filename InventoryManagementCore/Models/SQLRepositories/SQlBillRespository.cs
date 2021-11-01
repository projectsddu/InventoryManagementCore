using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementCore.Models.SQLRepositories
{
    public class SQlBillRespository : IBillRepository
    {
        private readonly AppDbContext context;

        public SQlBillRespository(AppDbContext context)
        {
            this.context = context;
        }
        public Bill AddBill(Bill bill)
        {
            context.Bills.Add(bill);
            context.SaveChanges();
            return bill;
        }

        public BillItem AddBillItem(int billId, BillItem item)
        {
            Bill b = GetBill(billId);
            b.BillItems.Add(item);
            context.SaveChanges();
            return item;
        }

        public Bill DeleteBill(int Id)
        {
            Bill b = context.Bills.Find(Id);
            if (b != null)
            {
                context.Bills.Remove(b);
                context.SaveChanges();
            }
            return b;
        }

        public IEnumerable<Bill> GetAllBills()
        {
            return context.Bills;
        }

        public IEnumerable<Bill> GetAllCustomerBills()
        {
            return context.Bills.Include(b => b.Customer);
        }

        public Bill GetBill(int Id)
        {
            return context.Bills.Include(b => b.Customer).FirstOrDefault(m => m.BillId == Id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers;

        }

        public Bill UpdateBill(Bill bill)
        {
            var cust = context.Bills.Attach(bill);
            cust.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bill;
        }
    }
}
