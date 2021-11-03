using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagementCore.Models.Models;

namespace InventoryManagementCore.Models.Interfaces
{
    public interface IBillItemRepository
    {
        BillItem GetBillItem(int Id);

        IEnumerable<BillItem> GetAllBillItems(int id);

        BillItem AddBillItem(BillItem billItem);

        BillItem UpdateBillItem(BillItem billItem);

        BillItem DeleteBillItem(int Id);
    }
}
