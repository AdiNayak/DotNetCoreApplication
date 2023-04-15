using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Settings;
using System.Data.SqlClient;
using System.Data;

namespace POS.Services.Settings
{
    public partial class ItemService : IItemService
    {
        private readonly IDataMapService _dataMapService;
        public ItemService(IDataMapService dataMapService)
        {
            _dataMapService = dataMapService;
        }
        public void DeleteItem(int itemId)
        {
            throw new NotImplementedException();
        }
        public List<Item> GetAllItem()
        {
            List<Item> items = new List<Item>();
            try
            {                
                var ds = (DataSet)_dataMapService.GetAll("Item");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                   var item = new Item
                    {
                        Id = (int)dr["Id"],
                        BrandId = (int)dr["BrandId"],
                        BrandName = (string)dr["BrandId"],
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        ItemName = (string)dr["ItemName"],
                        Date = (DateTime)dr["Date"],
                        Description = (string)dr["Description"],
                    };
                    items.Add(item);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                items = null;
            }
            return items;
        }
        public Item GetItemByItemId(int itemId)
        {
            Item item = null;
            try
            {
                var dr  =(SqlDataReader)_dataMapService.GetById("Item", itemId);
                while(dr.Read())
                {
                    item = new Item
                    {
                        Id =(int)dr["Id"],
                        BrandId= (int)dr["BrandId"],
                        BrandName=(string)dr["BrandId"],
                        ProductId=(int)dr["ProductId"],
                        ProductName=(string)dr["ProductName"],
                        ItemName = (string)dr["ItemName"],
                        Date = (DateTime)dr["Date"],
                        Description = (string)dr["Description"],                      
                    }; 
                }  
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                item= null;
            }
            return item;
        }
        public int InsertItem(Item item)
        {
            int result = 0;
            try
            {               
                IList<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", item.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@BrandId", item.BrandId));
                sqlParameter.Add(new SqlParameter("@ProductId", item.ProductId));
                sqlParameter.Add(new SqlParameter("@ItemName", item.ItemName));
                sqlParameter.Add(new SqlParameter("@Date", item.Date));
                sqlParameter.Add(new SqlParameter("@Description", item.Description));
                sqlParameter.Add(new SqlParameter("@Action_Flag", 0));
                result = _dataMapService.Insert(sqlParameter, "");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {               
                 result =0;
            }
            return result;
        }
        public int UpdateItem(Item item)
        {
            int result = 0;
            try
            {
                IList<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", item.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@BrandId", item.BrandId));
                sqlParameter.Add(new SqlParameter("@ProductId", item.ProductId));
                sqlParameter.Add(new SqlParameter("@ItemName", item.ItemName));
                sqlParameter.Add(new SqlParameter("@Date", item.Date));
                sqlParameter.Add(new SqlParameter("@Description", item.Description));
                sqlParameter.Add(new SqlParameter("@Action_Flag", 0));
                result = _dataMapService.Update(sqlParameter, "");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                result = 0;
            }
            return result;
        }

        public List<Brand> GetAllBrand()
        {
            List<Brand> brands = new List<Brand>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("Product");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var brand = new Brand
                    {
                        Id = (int)dr["Id"],
                        BrandName = (string)dr["ProductName"],
                    };
                    brands.Add(brand);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                brands = null;
            }
            return brands;
        }

        public List<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("Product");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var product = new Product
                    {
                        Id = (int)dr["Id"],
                        ProductName = (string)dr["ProductName"],                        
                    };
                    products.Add(product);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                products = null;
            }
            return products;
        }

    }
}
