using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace SYSTEM
{
    public class cHistoryBank
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_bank_history");
            cmm.Parameters.AddWithValue("@Param", "01");
            return DB.ExecuteReader(cmm);
        }
        public DataTable ListFileName()
        {
            cmm = DB.SqlCommandSp("sp_bank_history");
            cmm.Parameters.AddWithValue("@Param", "02");
            return DB.ExecuteReader(cmm);
        }
        public DataTable LoadFileName()
        {
            cmm = DB.SqlCommandSp("sp_bank_history");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@uid", UID);
            cmm.Parameters.AddWithValue("@filename", file_name);
            return DB.ExecuteReader(cmm);
        }
        public DataTable SearchFileName()
        {
            cmm = DB.SqlCommandSp("sp_bank_history");
            cmm.Parameters.AddWithValue("@Param", "04");
            cmm.Parameters.AddWithValue("@uid", UID);
            cmm.Parameters.AddWithValue("@filename", file_name);
            cmm.Parameters.AddWithValue("@SEARCH", search_string);
            return DB.ExecuteReader(cmm);
        }

        public DataTable SearchAllFileName()
        {
            cmm = DB.SqlCommandSp("sp_bank_history");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@uid", UID);
            cmm.Parameters.AddWithValue("@SEARCH", search_string);
            return DB.ExecuteReader(cmm);
        }
        public string UID { get; set; }
        public string file_name { get; set; }
        public string search_string { get; set; }
    }
}