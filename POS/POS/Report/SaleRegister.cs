using POS.Data.Sales;
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
    public partial class SaleRegister : formTemplate
    {
        private readonly RetailInvoiceMap _retailInvoiceMap;
        private readonly UserMap _userMap;

        public SaleRegister()
        {
            InitializeComponent();
            _retailInvoiceMap = new RetailInvoiceMap();
            _userMap = new UserMap();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                int totQty = 0,cnt=0;
                decimal totAmt = 0, totDisAmt = 0, totGstAmt = 0, totNetAmt = 0;
                var invoice = _retailInvoiceMap.GetAllInvoice().Where(x => x.Date >= DtpFromdate.Value.Date && x.Date <= DtptoDate.Value.Date);
                ListViewItem li;
                listview.Items.Clear();
                foreach (var item in invoice)
                {
                    cnt += 1;
                    li = listview.Items.Add(cnt.ToString());//0
                    li.SubItems.Add(item.Date.ToString("dd-MM-yyyy"));//1
                    li.SubItems.Add(item.InvoiceNo.ToString());//2
                    li.SubItems.Add(item.UserName.ToString());//3
                    li.SubItems.Add(item.CustomerName.ToString());//4
                    li.SubItems.Add(item.Address.ToString());//5
                    li.SubItems.Add(item.MobileNo.ToString());//6
                    li.SubItems.Add(item.GstinNo.ToString());//7
                    li.SubItems.Add(item.TotalQuantity.ToString());//8
                    totQty += Common.IntConvert(li.SubItems[8].Text);

                    li.SubItems.Add(item.TotalAmount.ToString());//9
                    totAmt += Common.DecimalConvert(li.SubItems[9].Text);

                    li.SubItems.Add(item.TotalDiscountAmount.ToString());//10
                    totDisAmt += Common.DecimalConvert(li.SubItems[10].Text);

                    li.SubItems.Add(item.TotalGstAmount.ToString());//11
                    totGstAmt += Common.DecimalConvert(li.SubItems[11].Text);

                    li.SubItems.Add(item.TotalNetAmount.ToString());//12
                    totNetAmt += Common.DecimalConvert(li.SubItems[12].Text);
                }
                listview.Items.Add(new ListViewItem(new String[]
                    {
                        "",//0
                        "",//0
                        "",//1
                        "",//2
                        "",//3
                        "",//4
                        "[ Total ]",//5
                        "",//6                        
                        totQty.ToString(),//7
                        totAmt.ToString(),//8
                        totDisAmt.ToString(),//9
                        totGstAmt.ToString(),//10
                        totNetAmt.ToString(),//11                      
                    }, 0, Color.Red, Color.White, new Font("Microsoft Sans Serif", 9, FontStyle.Bold)));
                listview.TopItem = listview.Items[((listview.Items.Count) - 1)];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
