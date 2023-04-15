using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public partial class DataMapService : IDataMapService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public DataSet GetAll(string tableName)
        {           
            try
            {              
             return SQL_Helper.fillDataset("select * from "+ tableName,tableName);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SQL_Helper.SqlCn.Close();
            }           
        }
        public DataSet GetDetailsById(string tableName, int refId)
        {
            try
            {
                if (refId == 0)
                { return null; }
                return SQL_Helper.fillDataset("select * from " + tableName + " where " + refId, "tableName");                
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SQL_Helper.SqlCn.Close();
            }
        }
        public SqlDataReader GetById(string tableName, int id)
        {
            try
            {
                if (id == 0)
                { return null; }
              return  SQL_Helper.ExecuteReader("select * from "+tableName+" where "+id);               
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SQL_Helper.SqlCn.Close();
            }
        }
        public int Insert(IEnumerable<SqlParameter> entities, string spdName)
        {
            try
            {
                if (entities == null && spdName == string.Empty)
                { return 0; }
                return SQL_Helper.executeStoredProcedure(spdName, entities.ToList());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SQL_Helper.SqlCn.Close();
            }
        }
        public int Update(IEnumerable<SqlParameter> entities, string spdName)
        {
            try
            {
                if (entities == null && spdName == string.Empty)
                { return 0; }
                return SQL_Helper.executeStoredProcedure(spdName, entities.ToList());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SQL_Helper.SqlCn.Close();
            }
        }
    }
}
