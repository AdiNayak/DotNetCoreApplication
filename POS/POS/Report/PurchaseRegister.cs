using POS.Data.Orders;
using POS.Data.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Report
{
    public partial class PurchaseRegister :formTemplate
    {
        private readonly PartyMap _partyMap;
        private readonly PurchaseMap _purchaseMap;

        public PurchaseRegister()
        {
            InitializeComponent();
            _partyMap = new PartyMap();
            _purchaseMap = new PurchaseMap();

        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                int totQty = 0, cnt = 0;
                decimal totAmt = 0, totOc = 0, totGstAmt = 0, totNetAmt = 0;
                var purchase = _purchaseMap.GetAllPurchase().Where(x => x.Date >= DtpFromdate.Value.Date && x.Date <= DtptoDate.Value.Date);
                ListViewItem li;
                listview.Items.Clear();
                foreach (var item in purchase)
                {
                    cnt += 1;
                    li = listview.Items.Add(cnt.ToString());//0
                    li.SubItems.Add(item.Date.ToString("dd-MM-yyyy"));//1
                    li.SubItems.Add(item.InvoiceNo.ToString());//2
                    li.SubItems.Add(item.PartyName.ToString());//3
                    li.SubItems.Add(item.PartyVoucherNo.ToString());//4
                    li.SubItems.Add(item.PartyVoucherDate.ToString("dd-MM-yyyy"));//5                    
                    li.SubItems.Add(item.TotalQuantity.ToString());//6
                    totQty += Common.IntConvert(li.SubItems[6].Text);

                    li.SubItems.Add(item.TotalAmount.ToString());//7
                    totAmt += Common.DecimalConvert(li.SubItems[7].Text);

                    li.SubItems.Add(item.TotalGstAmount.ToString());//8
                    totGstAmt += Common.DecimalConvert(li.SubItems[8].Text);

                    li.SubItems.Add(item.TotalOtherCharge.ToString());//9
                     totOc+= Common.DecimalConvert(li.SubItems[9].Text);

                    li.SubItems.Add(item.TotalNetAmount.ToString());//10
                    totNetAmt += Common.DecimalConvert(li.SubItems[10].Text);
                }
                listview.Items.Add(new ListViewItem(new String[]
                    {
                      
                        "",//0
                        "",//1
                        "",//2
                        "",//3
                        "[ Total ]",//4
                        "",//5                        
                        totQty.ToString(),//6
                        totAmt.ToString(),//7                      
                        totGstAmt.ToString(),//8
                         totOc.ToString(),//9
                        totNetAmt.ToString(),//10                      
                    }, 0, Color.Red, Color.White, new Font("Microsoft Sans Serif", 9, FontStyle.Bold)));
                listview.TopItem = listview.Items[((listview.Items.Count) - 1)];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
