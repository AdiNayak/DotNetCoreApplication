using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Orders
{
    public partial class PurchaseDetails : Item
    {
        public int PurchaseId { get; set; }
        public int ItemId { get; set; }
        public string BatchNo { get; set; }
        public DateTime ItemExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal GstPercentage { get; set; }
        public decimal GstAmount { get; set; }
        public decimal OtherCharge { get; set; }        
        public decimal NetAmount { get; set; }
        public decimal RateperItem { get; set; }
        public decimal MinSalePrice { get; set; }
        public decimal Mrp { get; set; }
    }
}
