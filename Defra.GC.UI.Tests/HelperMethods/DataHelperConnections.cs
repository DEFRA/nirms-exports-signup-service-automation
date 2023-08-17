﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Defra.Trade.ReMos.AssuranceService.Tests.HelperMethods
{
    public interface IDataHelperConnections
    {
        public DataTable ExecuteQuery(string connString, string queryString);
    }

    public class DataHelperConnections : IDataHelperConnections
    {
        public void DBConnect (string connString )
        {
            try 
            {
                SqlConnection sqlConn = new SqlConnection(connString);
                sqlConn.Open();
                //return sqlConn;
            }
            catch ( Exception ex ) 
            { 
            }

            //return null;
        }

        public void DBClose()
        {
            try 
            {
                //sqlConn.Close();
            }
            catch ( Exception ex ) { }
        }

        public DataTable ExecuteQuery(string connString,string queryString)
        {
            DataSet dataSet;

            SqlConnection sqlConn = new SqlConnection(connString);

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
