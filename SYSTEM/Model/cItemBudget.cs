using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cItemBudget
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "04");
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "01");
            cmm.Parameters.AddWithValue("@Name", Name);
            cmm.Parameters.AddWithValue("@uid", UserId);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "02");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@Name", Name);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_itembudgetclass");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@name", Name);

            return DB.ExecuteReader(cmm);
        }


        public string Name { get; set; }
        public int Id { get; set; }
        public Boolean isActive { get; set; }
        public string UserId { get; set; }

    }
}