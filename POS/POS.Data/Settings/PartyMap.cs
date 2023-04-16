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
   public partial class PartyMap
    {       
        private readonly DataMapService _dataMapService;
        public PartyMap()
        {
            _dataMapService = new DataMapService();
        }
        public int UpsertParty(Party _party, SaveTypes saveTypes)
        {
            int result = 0;
            try
            {
                IList<SqlParameter> sqlParameter = new List<SqlParameter>();
                sqlParameter = new List<SqlParameter>();
                SqlParameter IdentityParameter = new SqlParameter("@Id", _party.Id);
                IdentityParameter.Direction = System.Data.ParameterDirection.InputOutput;
                sqlParameter.Add(IdentityParameter);
                sqlParameter.Add(new SqlParameter("@PartyName", _party.PartyName));
                sqlParameter.Add(new SqlParameter("@GstinNo", _party.GstinNo));
                sqlParameter.Add(new SqlParameter("@Address", _party.Address));
                sqlParameter.Add(new SqlParameter("@ContactNo", _party.ContactNo));
                sqlParameter.Add(new SqlParameter("@Email", _party.Email));
                sqlParameter.Add(new SqlParameter("@WebSite", _party.WebSite));
                sqlParameter.Add(new SqlParameter("@Date", _party.Date));
                sqlParameter.Add(new SqlParameter("@Narration", _party.Narration));
                sqlParameter.Add(new SqlParameter("@Action_Flag", saveTypes));
                result = _dataMapService.Upsert(sqlParameter, "SpdParty");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return result;
        }
        public List<Party> GetAllParty()
        {
            List<Party> _partyList = new List<Party>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("Party");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var party = new Party
                    {
                        Id = (int)dr["Id"],
                        PartyName = (string)dr["PartyName"], 
                        GstinNo= dr["GstinNo"].ToString(),
                        Address = (string)dr["Address"].ToString(),
                        ContactNo= (string)dr["ContactNo"].ToString(),
                        Email= dr["Email"].ToString(),
                        WebSite= dr["WebSite"].ToString(),
                        Date= (DateTime)dr["Date"],
                        Narration= dr["Narration"].ToString(),
                    };
                    _partyList.Add(party);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return _partyList;
        }


    }
}
