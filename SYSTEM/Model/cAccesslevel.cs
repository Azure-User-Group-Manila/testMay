using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SYSTEM
{
    public class cAccesslevel
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");

          cmm.Parameters.AddWithValue("@Param", "04");


        cmm.Parameters.AddWithValue("@UserRoleId", UserRoleId);
            cmm.Parameters.AddWithValue("@MenuId", MenuId);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ActiveMenu()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "05");
            return DB.ExecuteReader(cmm);
        }

        public DataTable ActiveMenuModule()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "07");
            cmm.Parameters.AddWithValue("@UserRoleId", UserRoleId);
            cmm.Parameters.AddWithValue("@MenuId", MenuId);
            cmm.Parameters.AddWithValue("@SubMenu", SubMenuId);
            return DB.ExecuteReader(cmm);
        }


        public int Update()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@WithAccess", WithAccess);
            cmm.Parameters.AddWithValue("@AccessId", AccessId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int UpdateActive()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "03_01");
            cmm.Parameters.AddWithValue("@IsActive", IsActive);
            cmm.Parameters.AddWithValue("@ID", ID);
            return DB.ExecuteNonQuery(cmm);
        }

        public int UserRole()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "06");
            cmm.Parameters.AddWithValue("@UID", UID);
            return Convert.ToInt32(DB.ExecuteReader(cmm).Rows[0][0].ToString());
        }

        public DataTable Menu()
        {
            cmm = DB.SqlCommandSp("Sp_AccessLevel");
            cmm.Parameters.AddWithValue("@Param", "08");
            return DB.ExecuteReader(cmm);
        }

        
        public int UserRoleId  {get;set;}
        public int MenuId { get; set; }
        public int WithAccess { get; set; }
        public int AccessId { get; set; }
        public string UID { get; set; }
        public int SubMenuId { get; set; }
        public int IsActive { get; set; }
        public int ID { get; set; }
        
    }
}