using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.SQLRepositories
{
    public class SQLProductRepository:IProductRepository
    {
        private readonly AppDbContext context;
        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return p;
        }

        public Product DeleteProduct(int id)
        {
            Product pdt = context.Products.Find(id);
            if (pdt != null)
            {
                context.Products.Remove(pdt);
                context.SaveChanges();
            }
            return pdt;
        }

        

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public Product UpdateProduct(Product updatedProduct)
        {
            var pdt = context.Products.Attach(updatedProduct);
            pdt.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedProduct;
        }
    }
}
