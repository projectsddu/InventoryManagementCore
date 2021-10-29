using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.Models
{
    public class BillItem
    {
        public int BillItemId { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required!!")]
        public int BillItemQuantity { get; set; }

        [Display(Name = "Selling Price")]
        [Required(ErrorMessage = "Selling price is required!!")]
        public int BillItemSellingPrice { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required!!")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
