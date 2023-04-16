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
   public partial  class BrandMap
    {

        private readonly DataMapService _dataMapService;
        public BrandMap()
        {
            _dataMapService = new DataMapService();
        }


        public int UpsertBrand(Brand _brand, SaveTypes saveTypes)
        {
            int result = 0;
            try
            {
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _brand.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@BrandName", _brand.BrandName));               
                sqlParameter.Add(new SqlParameter("@Date", _brand.Date));
                sqlParameter.Add(new SqlParameter("@Narration", _brand.Narration));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveTypes));
                result = _dataMapService.Upsert(sqlParameter, "SpdBrand");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return result;
        }
        public List<Brand> GetAllBrand()
        {
            List<Brand> _brandList = new List<Brand>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("Brand");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var brand = new Brand
                    {
                        Id = (int)dr["Id"],
                        BrandName = (string)dr["BrandName"],
                        Date=(DateTime)dr["Date"],
                        Narration=(string)dr["Narration"],
                    };
                    _brandList.Add(brand);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return _brandList;
        }
    }
}
