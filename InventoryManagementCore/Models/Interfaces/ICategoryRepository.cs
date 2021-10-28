using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface ICategoryRepository
    {
        //Category GetCategory(int Id);
        //IEnumerable<Category> GetAllCategories();
        //Category AddCategory(Category c);
        //Category DeleteCategory(int Id);
        //Category UpdateCategory(Category c);
        //IEnumerable<Product> GetAllProducts();

        Category GetCategory(int Id);

        IEnumerable<Category> GetAllCategories();

        Category AddCategory(Category category);

        Category UpdateCategory(Category category);

        Category DeleteCategory(int Id);
    }
}
