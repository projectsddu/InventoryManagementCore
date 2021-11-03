using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required!!")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Phone Number is required!!")]
        [Display(Name = "Phone Number")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Phone Number length should be 6 or 10 characters long!!")]
        public string CustomerPhoneNo { get; set; }

        [Required(ErrorMessage = "Customer Address is required!!")]
        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Total Outstanding")]
        public int totalOutstanding { get; set; }

        public ICollection<Bill> Bill { get; set; }

    }
}
