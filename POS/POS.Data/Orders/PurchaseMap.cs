using POS.Core;
using POS.Core.Orders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Orders
{
   public partial class PurchaseMap
    {
        private readonly DataMapService _dataMapService;
        public PurchaseMap()
        {
            _dataMapService = new DataMapService();
        }
        public int UpsertPurchase(Purchase _purchase,SaveTypes saveType)
        {
            SqlTransaction sqlTrans = null;
            int result = 0,detailsResult=0;
            try
            {
                if (saveType == SaveTypes.Insert)
                {
                    int purchaseId = Common.IntConvert(_dataMapService.maxId("Id", "Purchase")) + 1;
                    string invoiceNo = "PUR-" + DateTime.Now.ToString("MM-yy") + "-" + purchaseId;
                    _purchase.InvoiceNo = invoiceNo;
                }
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _purchase.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@FinacialId", _purchase.FinacialId));
                sqlParameter.Add(new SqlParameter("@InvoiceNo", _purchase.InvoiceNo));
                sqlParameter.Add(new SqlParameter("@Date", _purchase.Date));
                sqlParameter.Add(new SqlParameter("@PartyId", _purchase.PartyId));
                sqlParameter.Add(new SqlParameter("@PartyVoucherNo", _purchase.PartyVoucherNo));
                sqlParameter.Add(new SqlParameter("@PartyVoucherDate", _purchase.PartyVoucherDate));
                sqlParameter.Add(new SqlParameter("@TotalQuantity", _purchase.TotalQuantity));
                sqlParameter.Add(new SqlParameter("@TotalAmount", _purchase.TotalAmount));
                sqlParameter.Add(new SqlParameter("@TotalOtherCharge", _purchase.TotalOtherCharge));
                sqlParameter.Add(new SqlParameter("@TotalGstAmount", _purchase.TotalGstAmount));
                sqlParameter.Add(new SqlParameter("@TotalNetAmount", _purchase.TotalNetAmount));
                sqlParameter.Add(new SqlParameter("@Narration", _purchase.Narration));
                sqlParameter.Add(new SqlParameter("@Status", _purchase.Status));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveType));
                SQL_Helper.SqlCn.Open();
                sqlTrans = SQL_Helper.SqlCn.BeginTransaction();
                result = _dataMapService.Upsert(sqlParameter, "SpdPurchase", ref sqlTrans);
                if(result>0)
                detailsResult = UpsertPurchaseDetails(_purchase._purchaseDetailsList, saveType, result, ref sqlTrans);
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
        public int UpsertPurchaseDetails(List<PurchaseDetails>_purchaseDetailsList, SaveTypes saveType,int refPurchaseId,ref SqlTransaction sqlTrans)
        {           
            int result = 0;
            try
            {
                if (saveType == SaveTypes.Update)
                    _dataMapService.Delete(refPurchaseId, "PurchaseId", "PurchaseDetails",ref sqlTrans);
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                 foreach (var purchaseDetails in _purchaseDetailsList)
                {
                    SqlParameter IdentityParameter = new SqlParameter("@Id", purchaseDetails.Id);
                    IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                    sqlParameter.Add(IdentityParameter);
                    sqlParameter.Add(new SqlParameter("@PurchaseId", refPurchaseId));
                    sqlParameter.Add(new SqlParameter("@ItemId", purchaseDetails.ItemId));
                    sqlParameter.Add(new SqlParameter("@BrandId", purchaseDetails.BrandId));
                    sqlParameter.Add(new SqlParameter("@MUnitId", purchaseDetails.MUnitId));
                    sqlParameter.Add(new SqlParameter("@BatchNo", purchaseDetails.BatchNo));
                    sqlParameter.Add(new SqlParameter("@ItemExpiryDate", purchaseDetails.ItemExpiryDate));
                    sqlParameter.Add(new SqlParameter("@Quantity", purchaseDetails.Quantity));
                    sqlParameter.Add(new SqlParameter("@Amount", purchaseDetails.Amount));
                    sqlParameter.Add(new SqlParameter("@GstPercentage", purchaseDetails.GstPercentage));
                    sqlParameter.Add(new SqlParameter("@GstAmount", purchaseDetails.GstAmount));
                    sqlParameter.Add(new SqlParameter("@OtherCharge", purchaseDetails.OtherCharge));
                    sqlParameter.Add(new SqlParameter("@NetAmount", purchaseDetails.NetAmount));
                    sqlParameter.Add(new SqlParameter("@RateperItem", purchaseDetails.RateperItem));
                    sqlParameter.Add(new SqlParameter("@MinSalePrice", purchaseDetails.MinSalePrice));
                    sqlParameter.Add(new SqlParameter("@Mrp", purchaseDetails.Mrp));
                    sqlParameter.Add(new SqlParameter("@Status", purchaseDetails.Status));
                    sqlParameter.Add(new SqlParameter("@Action_Flag", saveType));
                    result = _dataMapService.Upsert(sqlParameter, "SpdPurchaseDetails", ref sqlTrans);
                    sqlParameter.Clear();// = null;


                }
            }
            catch (Exception exception)
            {               
                throw new Exception(exception.Message, exception);
            }
            return result;
        }
        public List<Purchase> GetAllPurchase()
        {
            List<Purchase> _itemsList = new List<Purchase>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwPurchase");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var purchase = new Purchase
                    {
                        Id = (int)dr["Id"],
                        FinacialId = (int)dr["FinacialId"],
                        InvoiceNo = (string)dr["InvoiceNo"],
                        Date= (DateTime)dr["Date"],
                        PartyId = (int)dr["PartyId"],
                        PartyName = (string)dr["PartyName"],
                        PartyVoucherNo = (string)dr["PartyVoucherNo"],
                        PartyVoucherDate = (DateTime)dr["PartyVoucherDate"],
                        TotalQuantity = (int)dr["TotalQuantity"],
                        TotalAmount = (decimal)dr["TotalAmount"],
                        TotalGstAmount = (decimal)dr["TotalGstAmount"],
                        TotalOtherCharge= (decimal)dr["TotalOtherCharge"],
                        TotalNetAmount = (decimal)dr["TotalNetAmount"],                       
                        Narration = dr["Narration"].ToString(),
                    };
                    _itemsList.Add(purchase);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _itemsList;
        }
        public List<PurchaseDetails> GetAllPurchaseDetails()
        {
            List<PurchaseDetails> _itemsList = new List<PurchaseDetails>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwPurchaseDetails");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var purchaseDetails = new PurchaseDetails
                    {
                        Id = (int)dr["Id"],
                        PurchaseId = (int)dr["PurchaseId"],
                        ItemId = (int)dr["ItemId"],
                        ItemName = (string)dr["ItemName"],
                        BrandId = (int)dr["BrandId"],
                        BrandName = (string)dr["BrandName"],
                        MUnitId= (int)dr["MUnitId"],
                        MUnitName = (string)dr["MUnitName"],
                        BatchNo = (string)dr["BatchNo"],
                        ItemExpiryDate = (DateTime)dr["ItemExpiryDate"],
                        Quantity = (int)dr["Quantity"],
                        Amount = (decimal)dr["Amount"],
                        GstPercentage = (decimal)dr["GstPercentage"],
                        GstAmount = (decimal)dr["GstAmount"],
                        OtherCharge = (decimal)dr["OtherCharge"],
                        NetAmount = (decimal)dr["NetAmount"],
                        RateperItem = (decimal)dr["RateperItem"],
                        MinSalePrice = (decimal)dr["MinSalePrice"],
                        Mrp = (decimal)dr["Mrp"],                                           
                    };
                    _itemsList.Add(purchaseDetails);
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