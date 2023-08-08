using System;
using System.Data;
using System.Data.SqlClient;

namespace Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods
{
    public static class DataHelperConnections
    {
        public static SqlConnection DBConnect (this SqlConnection sqlConn, string connString )
        {
            try 
            {
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();
                return sqlConn;
            }
            catch ( Exception ex ) 
            { 
            }

            return null;
        }

        public static void DBClose(this SqlConnection sqlConn)
        {
            try 
            {
                sqlConn.Close();
            }
            catch ( Exception ex ) { }
        }

        public static DataTable ExecuteQuery(this SqlConnection sqlConn, string queryString)
        {
            DataSet dataSet;

            try
            {
                if (sqlConn == null || ((sqlConn != null && (sqlConn.State == ConnectionState.Closed || sqlConn.State == ConnectionState.Broken))))
                    sqlConn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString,sqlConn);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet,"table");
                sqlConn.Close();
                return dataSet.Tables["table"];
            }
            catch( Exception ex ) 
            {
                dataSet = null;
                sqlConn.Close();
                return null;
            }
            finally 
            {
                sqlConn.Close();
                dataSet = null; 
            }
        }
    }
}
