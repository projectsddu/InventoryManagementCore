using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;
using Microsoft.EntityFrameworkCore;

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

        public Product DeleteProduct(int Id)
        {
            Product product = context.Products.Find(Id);

            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.Include(p => p.Category);
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories;
        }

        public Product GetProduct(int Id)
        {
            return context.Products.Include(p => p.Category).FirstOrDefault(m => m.ProductId == Id);
        }

        public Product UpdateProduct(Product updatedProduct)
        {
            var product = context.Products.Attach(updatedProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedProduct;
        }
    }
}
