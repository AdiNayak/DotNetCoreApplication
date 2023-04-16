using POS.Core.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Settings
{
   public partial class UserMap
    {
        private readonly DataMapService _dataMapService;
        public UserMap()
        {
            _dataMapService = new DataMapService();
        }

        public List<User> GetAllUser()
        {
            List<User> _userList = new List<User>();
            try
            {
                var ds = (DataSet)_dataMapService.GetAll("User");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var user = new User
                    {
                        Id = (int)dr["Id"],
                        UserName = (string)dr["UserName"],
                        UserId= (string)dr["UserId"],
                        Password= (string)dr["Password"],
                        ConfirmPassword= (string)dr["ConfirmPassword"],
                        Date = (DateTime)dr["Date"],
                        Narration = (string)dr["Narration"],
                    };
                    _userList.Add(user);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return _userList;
        }
    }
}
