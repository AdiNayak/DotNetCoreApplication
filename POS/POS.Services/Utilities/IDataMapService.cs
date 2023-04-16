using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public partial interface IDataMapService
    {
        SqlDataReader GetById(string tableName, int id);
        DataSet GetDetailsById(string tableName, int refId);
        int Insert(IEnumerable<SqlParameter> entities, string spdName);
        int Update(IEnumerable<SqlParameter> entities, string spdName);
        void Delete(int id);
        DataSet GetAll(string tableName);

    }
}
