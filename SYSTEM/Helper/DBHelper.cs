using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class DBHelper
    {

        public DataTable ExecuteReader(SqlCommand comm)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(ConStr()))
            {
                cnn.Open();
                comm.Connection = cnn;
                SqlDataReader dr = comm.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }

        public int ExecuteNonQuery(SqlCommand comm)
        {
            using (SqlConnection cnn = new SqlConnection(ConStr()))
            {
                try
                {
                    cnn.Open();
                    comm.Connection = cnn;
                    comm.ExecuteNonQuery();
                    return 1;
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Record already exists"))
                        return 2;

                    return 0;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public SqlCommand SqlCommandSp(string Tsql)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = Tsql;
            return comm;
        }

        public string ConStr()
        {
            string serverActive = System.Configuration.ConfigurationSettings.AppSettings["ACTIVE_SERVER"];
            return System.Configuration.ConfigurationSettings.AppSettings[serverActive];
        }

        public string Server()
        {
            string Servername = System.Configuration.ConfigurationSettings.AppSettings["SERVER_NAME"];
            string Dbname = System.Configuration.ConfigurationSettings.AppSettings["DB_NAME"];
            return string.Format("Server Host : {0}  ;  Database : {1}", Servername, Dbname);
        }
    }
}