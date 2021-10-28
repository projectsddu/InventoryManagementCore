using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Interfaces;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.SQLRepositories
{
    public class SQLCategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext context;
        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category AddCategory(Category c)
        {
            this.context.Add(c);
            this.context.SaveChanges();
            return c;
        }

        public Category DeleteCategory(int id)
        {
            Category c = context.Categories.Find(id);
            if (c != null)
            {
                context.Categories.Remove(c);
                context.SaveChanges();
            }
            return c;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return context.Categories;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Find(id);
        }

        public Category UpdateCategory(Category c)
        {
            var cat = context.Categories.Attach(c);
            cat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return c;
        }
    }
}
