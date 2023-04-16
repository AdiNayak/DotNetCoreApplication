using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Orders
{
    public partial class Purchase :Party
    {
        public int FinacialId { get; set; }
        public string InvoiceNo { get; set; }
        public int PartyId { get; set; }
        public string PartyVoucherNo { get; set; }
        public DateTime PartyVoucherDate { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }       
        public decimal TotalGstAmount { get; set; }
        public decimal TotalOtherCharge { get; set; }
        public decimal TotalNetAmount { get; set; }
        public List<PurchaseDetails> _purchaseDetailsList { get; set; }
    }
}
