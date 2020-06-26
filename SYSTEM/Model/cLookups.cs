using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SYSTEM
{
    public class cLookups
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListByClassID()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "06");
            cmm.Parameters.AddWithValue("@ClassID", ClassId);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "01");
            cmm.Parameters.AddWithValue("@classid", ClassId);
            cmm.Parameters.AddWithValue("@Name", Name);
            cmm.Parameters.AddWithValue("@description", Description);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            cmm.Parameters.AddWithValue("@uid", UserId);           

            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "02");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@description", Description);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteNonQuery(cmm);
        }

        public int UpdateActive()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "02_01");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "06");
            cmm.Parameters.AddWithValue("@Name", Name);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListByParentID()
        {
            cmm = DB.SqlCommandSp("sp_maint_lookups");
            cmm.Parameters.AddWithValue("@Param", "09");
            cmm.Parameters.AddWithValue("@id", Convert.ToInt32(ConfigurationManager.AppSettings["EBL_PROJECTLOV_PARENTID"].ToString())); 
            return DB.ExecuteReader(cmm);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Boolean isActive { get; set; }
        public string UserId { get; set; }
    }
}