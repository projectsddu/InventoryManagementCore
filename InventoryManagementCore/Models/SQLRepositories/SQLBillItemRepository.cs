using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementCore.Models.SQLRepositories
{
    public class SQLBillItemRepository : IBillItemRepository
    {
        private readonly AppDbContext context;

        public SQLBillItemRepository(AppDbContext context)
        {
            this.context = context;
        }
        public BillItem AddBillItem(BillItem billItem)
        {
            context.BillItems.Add(billItem);
            context.SaveChanges();
            return billItem;
        }

        public BillItem DeleteBillItem(int Id)
        {
            BillItem b = context.BillItems.Find(Id);
            if (b != null)
            {
                context.BillItems.Remove(b);
                context.SaveChanges();
            }
            return b;
        }

        public IEnumerable<BillItem> GetAllBillItems(int Id)
        {
            List<BillItem> items = new List<BillItem>();
            foreach(var it in context.BillItems)
            {
                if(it.BillId==Id)
                {
                    it.Product = context.Products.Find(it.ProductId);
                    items.Add(it);
                }
            }
            return items;
        }

        public BillItem GetBillItem(int Id)
        {
            return context.BillItems.Find(Id);
        }

        public BillItem UpdateBillItem(BillItem billItem)
        {
            var cust = context.BillItems.Attach(billItem);
            cust.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return billItem;
        }
    }
}
