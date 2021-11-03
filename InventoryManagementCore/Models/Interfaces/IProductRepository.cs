using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProducts();
        Product AddProduct(Product p);
        Product UpdateProduct(Product updatedProduct);
        Product DeleteProduct(int Id);
        IEnumerable<Category> GetCategories();
    }
}
