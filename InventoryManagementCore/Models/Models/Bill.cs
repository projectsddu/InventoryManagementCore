using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementCore.Models.Models
{
    public class Bill
    {
        public int BillId { get; set; }

        [Display(Name = "Billing Date")]
        [Required(ErrorMessage = "Billing Date is required!!")]
        public DateTime BillDateTime { get; set; }

        [Display(Name = "Total Bill Cost")]
        [Required(ErrorMessage = "Total Bill Cost is required!!")]
        public int BillTotalCost { get; set; }

        [Display(Name = "Total Amount Paid")]
        [Required(ErrorMessage = "Total Amount Paid is required!!")]
        public int BillTotalPaid { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage ="Customer name is required!!")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<BillItem> BillItems { get; set; }


    }
}
