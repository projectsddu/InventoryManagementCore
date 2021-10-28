using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.Models
{
    public class Category
    {
        // Category model starts here
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required!!")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}
