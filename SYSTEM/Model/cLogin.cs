using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class iLogin
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable Select()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "10");
            cmm.Parameters.AddWithValue("@system_id", Uid);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ChangePassword()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "06");
            cmm.Parameters.AddWithValue("@system_id", Uid);
            cmm.Parameters.AddWithValue("@password",Password);
            return DB.ExecuteReader(cmm);
        }


        public DataTable GetShortBranchName()
        {
            cmm = DB.SqlCommandSp("sp_maint_branch");
            cmm.Parameters.AddWithValue("@params", "06");
            cmm.Parameters.AddWithValue("@BiD", BiD);
            return DB.ExecuteReader(cmm);
        }


        public DataTable CheckUserRole()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "09");
            cmm.Parameters.AddWithValue("@system_id", Uid);            
            return DB.ExecuteReader(cmm);
        }


        public int BiD { get; set; }
        public string Uid { get; set; }
        public string Password { get;set;}
        public string Fname { get; set; }

        public int CheckPassword(string pwr)
        {
            if (Password == pwr)
                return 1;
            else
                return 0;
        }
    }
}