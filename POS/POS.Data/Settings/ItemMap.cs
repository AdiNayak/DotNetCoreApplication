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
    public partial class ItemMap
    {
        private readonly DataMapService _dataMapService;
       public ItemMap()
        {
            _dataMapService = new DataMapService();
        }
        public List<Item> GetAllItem()
        {
            List<Item> _itemsList = new List<Item>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("vwItem");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var item = new Item
                    {
                        Id = (int)dr["Id"],
                        BrandId = (int)dr["BrandId"],
                        BrandName = (string)dr["BrandName"],
                        ItemName = (string)dr["ItemName"],
                        Date = (DateTime)dr["Date"],
                        Narration =  dr["Narration"].ToString(),
                    };
                    _itemsList.Add(item);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
           
            return _itemsList;
        }
        public Item GetItemByItemId(int itemId)
        {
            Item item = null;
            try
            {
                var dr = (SqlDataReader)_dataMapService.GetById("vwItem", itemId);
                while (dr.Read())
                {
                    item = new Item
                    {
                        Id = (int)dr["Id"],
                        BrandId = (int)dr["BrandId"],
                        BrandName = (string)dr["BrandId"],
                        ItemName = (string)dr["ItemName"],
                        Date = (DateTime)dr["Date"],
                        Narration = (string)dr["Narration"],
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
               
            }
           
            return item;
        }
        public int UpsertItem(Item _item,SaveTypes saveTypes)
        {
            int result = 0;
            try
            {
                IList<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _item.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@BrandId", _item.BrandId));
                sqlParameter.Add(new SqlParameter("@ItemName", _item.ItemName));
                sqlParameter.Add(new SqlParameter("@Date", _item.Date));
                sqlParameter.Add(new SqlParameter("@Narration", _item.Narration));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveTypes));
                result = _dataMapService.Upsert(sqlParameter, "SpdItem");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
           
            return result;
        }
    
        
    }
}
