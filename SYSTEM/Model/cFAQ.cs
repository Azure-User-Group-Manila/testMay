using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SYSTEM
{
    public class cFAQ
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_faqs");

          cmm.Parameters.AddWithValue("@Param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_faqs");

          cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_faqs");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@Question",Question);
            return DB.ExecuteReader(cmm);
        }

        public Boolean isActive { get; set; }
        public string Question { get; set; }
    }
}
