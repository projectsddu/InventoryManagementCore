using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
        Category AddCategory(Category c);
        Category DeleteCategory(int id);
        Category UpdateCategory(Category c);
        IEnumerable<Product> GetAllProducts();
    }
}
