using POS.Core;
using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Settings
{
  public partial  class ProductMap
    {

        private readonly DataMapService _dataMapService;
        public ProductMap()
        {
            _dataMapService = new DataMapService();
        }
        public List<Product> GetAllProduct()
        {
            List<Product> _productList = new List<Product>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwProduct");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var product = new Product
                    {
                        Id = (int)dr["Id"],
                        ProductName = (string)dr["ProductName"],
                        BrandId = (int)dr["BrandId"],
                        BrandName = (string)dr["BrandName"],
                        Date = (DateTime)dr["Date"],
                        Narration = (string)dr["Narration"],
                    };
                    _productList.Add(product);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return _productList;
        }
        public int UpsertProduct(Product _product, SaveTypes saveTypes)
        {
            int result = 0;
            try
            {
                IList<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _product.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@ProductName", _product.ProductName));
                sqlParameter.Add(new SqlParameter("@BrandId", _product.BrandId));
                sqlParameter.Add(new SqlParameter("@Date", _product.Date));
                sqlParameter.Add(new SqlParameter("@Narration", _product.Narration));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveTypes));
                result = _dataMapService.Upsert(sqlParameter, "SpdProduct");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return result;
        }

    }
}
