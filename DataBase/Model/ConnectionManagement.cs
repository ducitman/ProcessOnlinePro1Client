using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public class ConnectionManagement:IDisposable
    {
        private OracleConnection oraConn;
        private SqlConnection sqlConn;

        string bossConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.118.11.26)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=BOSSDB)));User Id=BOSS;Password=BOSS;";
        string specConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.118.11.26)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=BOSSDB)));User Id=VIEWER;Password=VIEWER;";
        string sqlConnectionString = "Data Source=10.118.11.111,1433;Network Library=DBMSSOCN;Initial Catalog=BLDG_APPS; User ID = ituser; Password = Data@1511;";
        private bool disposedValue;

        public ConnectionManagement(string connecDB)
        {
            if (connecDB.Equals(ApplicationUtils.BOSS))
                oraConn = new OracleConnection(bossConnectionString);
            if (connecDB.Equals(ApplicationUtils.SPEC))
                oraConn = new OracleConnection(specConnectionString);
            else if (connecDB.Equals(ApplicationUtils.SQL))
                sqlConn = new SqlConnection(sqlConnectionString);
        }

        public OracleConnection GetOraConnection()
        {
            if (oraConn != null && oraConn.State == System.Data.ConnectionState.Closed)
            {
                oraConn.Open();
            }
            return oraConn;
        }
        public SqlConnection GetSqlConnection()
        {
            try
            {
                if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Closed)
                {
                    sqlConn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sqlConn;
        }

        public SqlConnection GetSqlConnectionNotOpen()
        {

            return sqlConn;
        }

        public bool ConnectionOraIsOpen()
        {
            bool result = false;
            if (oraConn != null && oraConn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            return result;
        }

        public void CloseOra()
        {
            if (oraConn != null && oraConn.State == System.Data.ConnectionState.Open)
            {
                oraConn.Close();
            }
        }

        public void CloseSql()
        {
            if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                CloseSql();
                CloseOra();
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
