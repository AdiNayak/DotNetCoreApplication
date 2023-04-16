using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Sales
{
  public partial  class InvoiceDetails:Item
    {
        public int RetailInvoiceId { get; set; }
        public int ItemId { get; set; }
        public string BatchNo { get; set; }
        public DateTime ItemExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        
        public decimal Amount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal GstPercentage { get; set; }
        public decimal GstAmount { get; set; }

        //public decimal CgstPercentage { get; set; }
        //public decimal CgstAmount { get; set; }
        //public decimal SgstPercentage { get; set; }
        //public decimal SgstAmount { get; set; }
       
       
        public decimal NetAmount { get; set; }
    }
}
