using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public partial class DataMapService
    {
        public void Delete(int id,string columnName, string tableName)
        {
            try
            {
                SQL_Helper.executeNonQuery("delete  from " + tableName + " where " + columnName + "=" + id + ""); ;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public void Delete(int id, string columnName, string tableName, ref SqlTransaction sqlTrans)
        {
            try
            {
                SQL_Helper.executeNonQuery("delete  from " + tableName + " where " + columnName + "=" + id + "",ref sqlTrans); ;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
           
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
        public int Upsert(IEnumerable<SqlParameter> entities, string spdName)
        {
            try
            {
                if (entities == null || spdName == string.Empty)
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
        //public int Update(IEnumerable<SqlParameter> entities, string spdName)
        //{
        //    try
        //    {
        //        if (entities == null && spdName == string.Empty)
        //        { return 0; }
        //        return SQL_Helper.executeStoredProcedure(spdName, entities.ToList());
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message, exception);
        //    }
        //    finally
        //    {
        //        SQL_Helper.SqlCn.Close();
        //    }
        //}
        public int Upsert(IEnumerable<SqlParameter> entities, string spdName, ref SqlTransaction sqlTrans)
        {
            try
            {
                if (entities == null || spdName == string.Empty)
                { return 0; }
                return SQL_Helper.executeStoredProcedure(spdName, entities.ToList(),ref sqlTrans);
            }
            catch (Exception exception)
            {
                SQL_Helper.SqlCn.Close();
                throw new Exception(exception.Message, exception);
            }
           
        }

        //public int Update(IEnumerable<SqlParameter> entities, string spdName, ref SqlTransaction sqlTrans)
        //{
        //    try
        //    {
        //        if (entities == null && spdName == string.Empty)
        //        { return 0; }
        //        return SQL_Helper.executeStoredProcedure(spdName, entities.ToList());
        //    }
        //    catch (Exception exception)
        //    {
        //        SQL_Helper.SqlCn.Close();
        //        throw new Exception(exception.Message, exception);
        //    }
        //}

        public int maxId(string columnName,string tableName)
        {
            try
            {
                if (tableName ==string.Empty && columnName==string.Empty)
                { return 0; }
                return SQL_Helper.maxRowId(columnName,tableName);
            }
            catch (Exception exception)
            {
                SQL_Helper.SqlCn.Close();
                throw new Exception(exception.Message, exception);
            }
           
        }

        public object GetScalar(string columnName, string tableName)
        {
            try
            {
                if (tableName == string.Empty && columnName == string.Empty)
                { return 0; }
                return SQL_Helper.executeScalar(columnName, tableName);
            }
            catch (Exception exception)
            {
                SQL_Helper.SqlCn.Close();
                throw new Exception(exception.Message, exception);
            }

        }


    }
}
