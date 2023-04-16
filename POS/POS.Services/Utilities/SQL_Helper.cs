using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
   public static class SQL_Helper
    {
        //public static SqlConnection SqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["resDBcon"].ConnectionString);
        public static SqlConnection SqlCn = new SqlConnection("");
        public static void Open()
        {
            try
            {
                if (SqlCn.State != System.Data.ConnectionState.Open)
                    SqlCn.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Close()
        {
            try
            {
                if (SqlCn.State == System.Data.ConnectionState.Open)
                    SqlCn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void setParameters(this SqlCommand sqlCmd, List<SqlParameter> parameters)
        {
            try
            {
                if (parameters != null)
                    foreach (SqlParameter sqlParameter in parameters)
                        sqlCmd.Parameters.Add(sqlParameter.Validate());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
        private static SqlParameter Validate(this SqlParameter sqlParameter)
        {
            if (sqlParameter.Value == null)
                sqlParameter.Value = DBNull.Value;

            return sqlParameter;
        }
        public static int executeNonQuery(string SqlQuery)
        {
            int Result = 0;

            try
            {
                SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlCn);
                SqlCn.Open();
                Result = SqlCmd.ExecuteNonQuery();
                SqlCn.Close();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return Result;
        }
        public static object executeScalar(string SqlQuery)
        {
            object Result;

            try
            {

                SqlCommand SqlCmd = new SqlCommand(SqlQuery, SqlCn);
                SqlCn.Open();
                Result = SqlCmd.ExecuteScalar();
                SqlCn.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return Result;
        }
        public static int executeNonQuery(string cmdText, List<SqlParameter> parameters)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(cmdText, SqlCn);
                sqlCmd.setParameters(parameters);

                SqlCn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }
        public static int executeNonQuery(string cmdText, ref SqlTransaction sqlTrans)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText, SqlCn);
                sqlCommand.Transaction = sqlTrans;
                //SqlCn.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            //finally
            //{
            //    SqlCn.Close();
            //}
            return result;
        }
        public static DataSet fillDataset(string SqlQuery, string dataTable)
        {
            DataSet Ds = new DataSet();

            try
            {
                Ds.Clear();
                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlQuery, SqlCn);
                SqlDa.Fill(Ds, dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return Ds;
        }
        public static DataSet fillDataset(StringBuilder SqlQuery, string dataTable)
        {
            DataSet Ds = new DataSet();

            try
            {
                Ds.Clear();
                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlQuery.ToString(), SqlCn);
                SqlDa.Fill(Ds, dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return Ds;
        }
        public static DataSet fillDataset(string SqlQuery, List<SqlParameter> sqlParameter, string dataTable)
        {
            DataSet Ds = new DataSet();

            try
            {
                Ds.Clear();
                SqlCommand sqlcmd = new SqlCommand(SqlQuery.ToString(), SqlCn);
                sqlcmd.setParameters(sqlParameter);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDa = new SqlDataAdapter(sqlcmd);

                SqlDa.Fill(Ds, dataTable);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return Ds;
        }
        public static DataSet fillDataset(StringBuilder cmdText)
        {
            try
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmdText.ToString(), SqlCn);
                sqlDa.Fill(dataSet);
                return dataSet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static DataTable fillDataTable(string SqlQuery, string tblName)
        {
            DataSet Ds = new DataSet();
            DataTable dt = new DataTable(tblName);
            try
            {
                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlQuery.ToString(), SqlCn);
                SqlDa.Fill(dt);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return dt;
        }
        public static Int32 maxRowId(String columnName, String dataTable)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select isnull(Max(" + columnName + "),0) from " + dataTable + "", SqlCn);
                SqlCn.Open();
                result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }
        public static int executeStoredProcedure(string cmdText, List<SqlParameter> parameters)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(cmdText, SqlCn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.setParameters(parameters);

                SqlCn.Open();
                sqlCmd.ExecuteNonQuery();
                result = Convert.ToInt32(sqlCmd.Parameters[0].Value);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }
        public static int executeStoredProcedure(string cmdText, List<SqlParameter> parameters, ref SqlTransaction sqlTrans)
        {
            int result = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText, SqlCn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.setParameters(parameters);

                sqlCommand.Transaction = sqlTrans;
                sqlCommand.ExecuteNonQuery();
                result = Convert.ToInt32(sqlCommand.Parameters[0].Value);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            return result;
        }
        public static string executeStoredProcedureString(string cmdText, List<SqlParameter> parameters)
        {
            string result = "";
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(cmdText, SqlCn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.setParameters(parameters);

                    SqlCn.Open();
                    sqlCmd.ExecuteNonQuery();
                    result = (sqlCmd.Parameters[0].Value.ToString());
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(string cmdText)
        {
            SqlDataReader result;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, SqlCn);
                cmd.CommandTimeout = 0;
                SqlCn.Open();
                result = cmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                //SqlCn.Close();
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(string cmdText, SqlConnection sqlCon)
        {
            SqlDataReader result;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, sqlCon);
                cmd.CommandTimeout = 0;
                //OpenConnection();
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                result = cmd.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(StringBuilder cmdText, List<SqlParameter> sqlParameter)
        {
            try
            {

                SqlCommand sqlCommand = new SqlCommand(cmdText.ToString(), SqlCn);
                sqlCommand.setParameters(sqlParameter);
                SqlCn.Open();
                return sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }

        }
        public static SqlDataReader ExecuteReader(StringBuilder cmdText, List<SqlParameter> sqlParameter, ref SqlTransaction sqlTrans)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText.ToString(), SqlCn);
                sqlCommand.setParameters(sqlParameter);
                sqlCommand.Transaction = sqlTrans;

                return sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
        }
        public static SqlDataReader ExecuteReader(string cmdText, List<SqlParameter> sqlParameter)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText, SqlCn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.setParameters(sqlParameter);
                SqlCn.Open();
                return sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
        }
        public static SqlDataReader ExecuteReader(StringBuilder cmdText, ref SqlTransaction sqlTrans)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText.ToString(), SqlCn);
                sqlCommand.Transaction = sqlTrans;
                //SqlCn.Open();
                return sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            //finally
            //{
            //    SqlCn.Close();
            //}
        }
        public static SqlDataReader ExecuteReader(StringBuilder cmdText, List<SqlParameter> sqlParameter, SqlConnection SqlCn)
        {
            SqlDataReader result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmdText.ToString(), SqlCn);
                sqlCommand.setParameters(sqlParameter);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (SqlCn.State == ConnectionState.Closed)
                    SqlCn.Open();
                result = sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
            finally
            {
                SqlCn.Close();
            }
            return result;
        }

    }
}
