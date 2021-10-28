using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.Models
{
    public class Product
    {
        public int ProductId { get; set; }

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

        //[Required(ErrorMessage = "Photo is required!!")]
        //[Display(Name = "Photograph")]
        //public string PhotoPath { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
