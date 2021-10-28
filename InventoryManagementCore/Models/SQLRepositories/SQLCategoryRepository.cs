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

        public Category AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(int Id)
        {
            Category c = context.Categories.Find(Id);
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

        public Category GetCategory(int Id)
        {
            return context.Categories.Find(Id);
        }

        public Category UpdateCategory(Category category)
        {
            var newCategory = context.Categories.Attach(category);
            newCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return category;
        }
    }
}
