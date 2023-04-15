using POS.Core;
using POS.Core.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Sales
{
  public partial  class RetailInvoiceMap
    {
        private readonly DataMapService _dataMapService;
        public RetailInvoiceMap()
        {
            _dataMapService = new DataMapService();
        }
        public int UpsertInvoice(Invoice _invoice, SaveTypes saveType)
        {
            SqlTransaction sqlTrans = null;
            int result = 0, detailsResult = 0;
            try
            {
                if (saveType == SaveTypes.Insert)
                {
                    int invoiceId = Common.IntConvert(_dataMapService.maxId("Id", "RetailInvoice")) + 1;
                    string invoiceNo = "RI-" + DateTime.Now.ToString("MM-yy") + "-" + invoiceId;
                    _invoice.InvoiceNo = invoiceNo;
                }
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _invoice.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@FinacialId",_invoice.FinacialId));
                sqlParameter.Add(new SqlParameter("@InvoiceNo",_invoice.InvoiceNo));
                sqlParameter.Add(new SqlParameter("@Date",_invoice.Date));
                sqlParameter.Add(new SqlParameter("@SellerId", _invoice.SellerId));
                sqlParameter.Add(new SqlParameter("@CustomerName", _invoice.CustomerName));
                sqlParameter.Add(new SqlParameter("@Address", _invoice.Address));
                sqlParameter.Add(new SqlParameter("@MobileNo", _invoice.MobileNo));
                sqlParameter.Add(new SqlParameter("@GstinNo", _invoice.GstinNo));
                sqlParameter.Add(new SqlParameter("@TotalQuantity", _invoice.TotalQuantity));
                sqlParameter.Add(new SqlParameter("@TotalAmount", _invoice.TotalAmount));                
                sqlParameter.Add(new SqlParameter("@TotalDiscountAmount", _invoice.TotalDiscountAmount));
                sqlParameter.Add(new SqlParameter("@TotalSaleAmount", _invoice.TotalSaleAmount));
                sqlParameter.Add(new SqlParameter("@TotalGstAmount",_invoice.TotalGstAmount)); 
                sqlParameter.Add(new SqlParameter("@TotalNetAmount",_invoice.TotalNetAmount));
                sqlParameter.Add(new SqlParameter("@Narration",_invoice.Narration));
                sqlParameter.Add(new SqlParameter("@Status",_invoice.Status));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveType));
                SQL_Helper.SqlCn.Open();
                sqlTrans = SQL_Helper.SqlCn.BeginTransaction();
                result = _dataMapService.Upsert(sqlParameter, "SpdRetailInvoice", ref sqlTrans);
                if (result > 0)
                    detailsResult = UpsertInvoiceDetails(_invoice._invoiceDetailsList, saveType, result, ref sqlTrans);
                if (detailsResult <= 0)
                    result = 0;
                sqlTrans.Commit();
            }
            catch (Exception exception)
            {
                sqlTrans.Rollback();
                SQL_Helper.SqlCn.Close();
                throw new Exception(exception.Message, exception);
            }
            return result;
        }
        public int UpsertInvoiceDetails(List<InvoiceDetails> _invoiceDetailsList, SaveTypes saveType, int refInvoiceId, ref SqlTransaction sqlTrans)
        {
            int result = 0;
            try
            {
                if(saveType==SaveTypes.Update)
                _dataMapService.Delete(refInvoiceId, "RetailInvoiceId", "RetailInvoiceDetails", ref sqlTrans);
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                foreach (var invoiceDetails in _invoiceDetailsList)
                {
                    SqlParameter IdentityParameter = new SqlParameter("@Id", invoiceDetails.Id);
                    IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                    sqlParameter.Add(IdentityParameter);
                    sqlParameter.Add(new SqlParameter("@RetailInvoiceId", refInvoiceId));
                    sqlParameter.Add(new SqlParameter("@ItemId", invoiceDetails.ItemId));
                    sqlParameter.Add(new SqlParameter("@BrandId", invoiceDetails.BrandId));
                    sqlParameter.Add(new SqlParameter("@MUnitId", invoiceDetails.MUnitId));
                    sqlParameter.Add(new SqlParameter("@BatchNo", invoiceDetails.BatchNo));
                    sqlParameter.Add(new SqlParameter("@ItemExpiryDate", invoiceDetails.ItemExpiryDate));
                    sqlParameter.Add(new SqlParameter("@Quantity", invoiceDetails.Quantity));
                    sqlParameter.Add(new SqlParameter("@Rate", invoiceDetails.Rate));
                    sqlParameter.Add(new SqlParameter("@Amount", invoiceDetails.Amount));
                    sqlParameter.Add(new SqlParameter("@DiscountPercentage", invoiceDetails.DiscountPercentage));
                    sqlParameter.Add(new SqlParameter("@DiscountAmount", invoiceDetails.DiscountAmount));
                    sqlParameter.Add(new SqlParameter("@SaleAmount", invoiceDetails.SaleAmount));
                    sqlParameter.Add(new SqlParameter("@GstPercentage", invoiceDetails.GstPercentage));
                    sqlParameter.Add(new SqlParameter("@GstAmount", invoiceDetails.GstAmount));
                    sqlParameter.Add(new SqlParameter("@NetAmount", invoiceDetails.NetAmount));                    
                    sqlParameter.Add(new SqlParameter("@Status", invoiceDetails.Status));
                    sqlParameter.Add(new SqlParameter("@Action_Flag", saveType));
                    result = _dataMapService.Upsert(sqlParameter, "SpdRetailInvoiceDetails", ref sqlTrans);
                    sqlParameter.Clear();// = null;


                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return result;
        }
        public List<Invoice> GetAllInvoice()
        {
            List<Invoice> _itemsList = new List<Invoice>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwRetailInvoice");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var invoice = new Invoice
                    {
                        Id = (int)dr["Id"],
                        FinacialId = (int)dr["FinacialId"],
                        InvoiceNo = (string)dr["InvoiceNo"],
                        Date = (DateTime)dr["Date"],
                        SellerId = (int)dr["SellerId"],
                        UserName = (string)dr["UserName"],
                        CustomerName = (string)dr["CustomerName"],
                        Address = dr["Address"].ToString(),
                        MobileNo = dr["MobileNo"].ToString(),
                        GstinNo = dr["GstinNo"].ToString(),
                        TotalQuantity= (int)dr["TotalQuantity"],
                        TotalAmount = (decimal)dr["TotalAmount"],
                        TotalDiscountAmount = (decimal)dr["TotalDiscountAmount"],
                        TotalSaleAmount = (decimal)dr["TotalSaleAmount"],
                        TotalGstAmount = (decimal)dr["TotalGstAmount"], 
                        TotalNetAmount = (decimal)dr["TotalNetAmount"],
                        Narration = dr["Narration"].ToString(),
                    };
                    _itemsList.Add(invoice);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _itemsList;
        }
        public List<InvoiceDetails> GetAllInvoiceDetails()
        {
            List<InvoiceDetails> _itemsList = new List<InvoiceDetails>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwRetailInvoiceDetails");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var invoiceDetails = new InvoiceDetails
                    {
                        Id = (int)dr["Id"],
                        RetailInvoiceId = (int)dr["RetailInvoiceId"],
                        ItemId = (int)dr["ItemId"],
                        ItemName = (string)dr["ItemName"],
                        BrandId = (int)dr["BrandId"],
                        MUnitId=(int)dr["MUnitId"],
                        MUnitName= (string)dr["MUnitName"],
                        BrandName = (string)dr["BrandName"],
                        BatchNo = (string)dr["BatchNo"],
                        ItemExpiryDate = (DateTime)dr["ItemExpiryDate"],
                        Quantity = (int)dr["Quantity"],
                        Rate = (decimal)dr["Rate"],
                        Amount = (decimal)dr["Amount"],
                        DiscountPercentage = (decimal)dr["DiscountPercentage"],
                        DiscountAmount = (decimal)dr["DiscountAmount"],
                        SaleAmount = (decimal)dr["SaleAmount"],                       
                        GstPercentage = (decimal)dr["GstPercentage"],
                        GstAmount = (decimal)dr["GstAmount"],                       
                        NetAmount = (decimal)dr["NetAmount"],                      
                    };
                    _itemsList.Add(invoiceDetails);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _itemsList;
        }
        public void DeletePurchaseDetails(int refPurchaseId)
        {
            try
            {
                _dataMapService.Delete(refPurchaseId, "PurchaseId", "PurchaseDetails");

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

    }
}
