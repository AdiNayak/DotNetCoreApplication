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
  public partial   class MUnitMap
    {
        private readonly DataMapService _dataMapService;
        public MUnitMap()
        {
            _dataMapService = new DataMapService();
        }


        public int UpsertMUnit(MUnit _mUnit, SaveTypes saveTypes)
        {
            int result = 0;
            try
            {
                List<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _mUnit.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@MUnitName", _mUnit.MUnitName));
                sqlParameter.Add(new SqlParameter("@Date", _mUnit.Date));
                sqlParameter.Add(new SqlParameter("@Narration", _mUnit.Narration));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveTypes));
                result = _dataMapService.Upsert(sqlParameter, "SpdMUnit");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return result;
        }
        public List<MUnit> GetAllMUnit()
        {
            List<MUnit> _mUnitList = new List<MUnit>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("MUnit");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var mUnit = new MUnit
                    {
                        Id = (int)dr["Id"],
                        MUnitName = (string)dr["MUnitName"],
                        Date = (DateTime)dr["Date"],
                        Narration = dr["Narration"].ToString(),
                    };
                    _mUnitList.Add(mUnit);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return _mUnitList;
        }
    }
}
