using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cFAQMaintenance
    {

        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public string question { get; set; }
        public string answer { get; set; }
        public int ID { get; set; }
        public string UserId { get; set; }


        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_FAQs");

          cmm.Parameters.AddWithValue("@Param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_FAQs");

          cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@question", question);
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_FAQs");
            cmm.Parameters.AddWithValue("@Param", "01");
            cmm.Parameters.AddWithValue("@question", question);
            cmm.Parameters.AddWithValue("@answer", answer);
            cmm.Parameters.AddWithValue("@isActive", true);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_FAQs");
            cmm.Parameters.AddWithValue("@Param", "02");
            cmm.Parameters.AddWithValue("@id", ID);
            cmm.Parameters.AddWithValue("@question", question);
            cmm.Parameters.AddWithValue("@answer", answer);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_FAQs");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@id", ID);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }
    }
}