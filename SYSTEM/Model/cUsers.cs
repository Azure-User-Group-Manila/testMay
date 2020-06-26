using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SYSTEM
{
    public class cUsers
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");

          cmm.Parameters.AddWithValue("@param", "01");

          cmm.Parameters.AddWithValue("@system_id", systemid);
            cmm.Parameters.AddWithValue("@password", password);
            cmm.Parameters.AddWithValue("@first_name", fname);
            cmm.Parameters.AddWithValue("@last_name", lname);
            cmm.Parameters.AddWithValue("@mi_name", mname);
            cmm.Parameters.AddWithValue("@suffix_name", sname);
            cmm.Parameters.AddWithValue("@email", email);
            cmm.Parameters.AddWithValue("@employeeid", employeeid);
            cmm.Parameters.AddWithValue("@domainid", domainid);
            cmm.Parameters.AddWithValue("@userroleid", userroleid);
            //cmm.Parameters.AddWithValue("@branchid", branchid);
            //cmm.Parameters.AddWithValue("@departmentid", departmentid);
            cmm.Parameters.AddWithValue("@isactive", isactive);
            cmm.Parameters.AddWithValue("@uid", uid);
            return DB.ExecuteNonQuery(cmm);
        }

        public void Update(ref int x)
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "02");
            cmm.Parameters.AddWithValue("@system_id", systemid);
            cmm.Parameters.AddWithValue("@first_name", fname);
            cmm.Parameters.AddWithValue("@last_name", lname);
            cmm.Parameters.AddWithValue("@mi_name", mname);
            cmm.Parameters.AddWithValue("@suffix_name", sname);
            cmm.Parameters.AddWithValue("@email", email);
            cmm.Parameters.AddWithValue("@employeeid", employeeid);
            cmm.Parameters.AddWithValue("@domainid", domainid);
            cmm.Parameters.AddWithValue("@userroleid", userroleid);
            //cmm.Parameters.AddWithValue("@branchid", branchid);
            //cmm.Parameters.AddWithValue("@departmentid", departmentid);
            cmm.Parameters.AddWithValue("@isactive", isactive);
            cmm.Parameters.AddWithValue("@uid", uid);
            cmm.Parameters.AddWithValue("@id", ID);

            x = DB.ExecuteNonQuery(cmm);
        }
                
        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "03");
            cmm.Parameters.AddWithValue("@uid", uid);
            cmm.Parameters.AddWithValue("@id", ID);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@isactive", true);
            return DB.ExecuteReader(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@isactive", true);
            cmm.Parameters.AddWithValue("@system_id", systemid);
            return DB.ExecuteReader(cmm);
        }


        public DataTable Check()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "07");
            cmm.Parameters.AddWithValue("@system_id", systemid);
            return DB.ExecuteReader(cmm);
        }


        public DataTable User()
        {
            cmm = DB.SqlCommandSp("sp_maint_users");
            cmm.Parameters.AddWithValue("@param", "08");
            return DB.ExecuteReader(cmm);
        }


        public string systemid { get; set; }
        public string password { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mname { get; set; }
        public string sname { get; set; }
        public string email { get; set; }
        public int employeeid { get; set; }
        public string domainid { get; set; }
        public int userroleid { get; set; }
        //public int branchid { get; set; }
        //public int departmentid { get; set; }
        public Boolean isactive { get; set; }
        public string uid { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedDt { get; set; }
        public string DeletedBy { get; set; }
        public int ID { get; set; }
    }
}