using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace SYSTEM
{
    public class cHistoryOrder
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_order_history");
            cmm.Parameters.AddWithValue("@Param", "11");
            return DB.ExecuteReader(cmm);
        }
        public DataTable ListFileName()
        {
            cmm = DB.SqlCommandSp("sp_order_history");
            cmm.Parameters.AddWithValue("@Param", "12");
            return DB.ExecuteReader(cmm);
        }
        public DataTable LoadFileName()
        {
            cmm = DB.SqlCommandSp("sp_order_history");
            cmm.Parameters.AddWithValue("@Param", "13");
            cmm.Parameters.AddWithValue("@filename", file_name);
            return DB.ExecuteReader(cmm);
        }
        public DataTable SearchFileName()
        {
            cmm = DB.SqlCommandSp("sp_order_history");
            cmm.Parameters.AddWithValue("@Param", "14");
            cmm.Parameters.AddWithValue("@filename", file_name);
            cmm.Parameters.AddWithValue("@search", search_string);
            return DB.ExecuteReader(cmm);
        }
        public DataTable SearchAllFileName()
        {
            cmm = DB.SqlCommandSp("sp_order_history");
            cmm.Parameters.AddWithValue("@Param", "15");
            cmm.Parameters.AddWithValue("@search", search_string);
            return DB.ExecuteReader(cmm);
        }
        public string UID { get; set; }
        public string file_name { get; set; }
        public string search_string { get; set; }
    }
}