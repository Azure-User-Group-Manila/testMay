using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cItemCategory
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "01");
            cmm.Parameters.AddWithValue("@Desc", Name);
            cmm.Parameters.AddWithValue("@sku", Code);
            cmm.Parameters.AddWithValue("@itembudgetid", ItemBudgetID);
            cmm.Parameters.AddWithValue("@itemclassid", ItemClassID);
            cmm.Parameters.AddWithValue("@uid", UserId);

            //if (sqlParam != null)
            //{
            //    cmm.Parameters.AddWithValue(sqlParam);
            //}
            
            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "02");
            cmm.Parameters.AddWithValue("@Desc", Name);
            cmm.Parameters.AddWithValue("@sku", Code);
            cmm.Parameters.AddWithValue("@itembudgetid", ItemBudgetID);
            cmm.Parameters.AddWithValue("@itemclassid", ItemClassID);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@id", Id);

            //if (sqlParam != null)
            //{
            //    cmm.Parameters.AddWithValue(sqlParam);
            //}
            
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "04");
            cmm.Parameters.AddWithValue("@Desc", Name);
            return DB.ExecuteReader(cmm);
        }

        public DataTable image()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@id", Id);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ActiveList()
        {
            cmm = DB.SqlCommandSp("sp_maint_itemcategory");
            cmm.Parameters.AddWithValue("@param", "06");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Boolean isActive { get; set; }
        public string UserId { get; set; }
        public byte Image { get; set; }
        public SqlParameter sqlParam { get; set; }
        public int ItemBudgetID { get; set; }
        public int ItemClassID { get; set; }
    }
}