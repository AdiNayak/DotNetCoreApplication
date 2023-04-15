using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Sales
{
    public partial class Invoice : User
    {
        public int FinacialId { get; set; }
        public string InvoiceNo { get; set; }
        public int SellerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string GstinNo { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public decimal TotalGstAmount { get; set; }    
        public decimal TotalNetAmount { get; set; }
        public List<InvoiceDetails> _invoiceDetailsList { get; set; }
    }
}
