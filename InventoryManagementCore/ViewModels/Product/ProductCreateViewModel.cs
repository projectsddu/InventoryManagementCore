using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;
using Microsoft.AspNetCore.Http;

namespace InventoryManagementCore.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Product Name is required!!")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Quantity is required!!")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Buying Price is required!!")]
        [Display(Name = "Buying Price")]
        public int BuyingPrice { get; set; }

        [Required(ErrorMessage = "Selling Price is required!!")]
        [Display(Name = "Selling Price")]
        public int SellingPrice { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile ProductPhoto { get; set; }

        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
