using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cUserRoles
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "01");
            cmm.Parameters.AddWithValue("@userrole", UserRole);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", true);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "02");
            cmm.Parameters.AddWithValue("@userroleid", Id);
            cmm.Parameters.AddWithValue("@userrole", UserRole);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "03");
            cmm.Parameters.AddWithValue("@userroleid", Id);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }
                
        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");

          cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@userrole", UserRole);
            return DB.ExecuteReader(cmm);
        }


        public DataTable Check()
        {
            cmm = DB.SqlCommandSp("sp_maint_userroles");
            cmm.Parameters.AddWithValue("@param", "06");
            cmm.Parameters.AddWithValue("@userrole", UserRole);
            return DB.ExecuteReader(cmm);
        }

        public string UserRole { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public Boolean isActive { get; set; }
    }
}