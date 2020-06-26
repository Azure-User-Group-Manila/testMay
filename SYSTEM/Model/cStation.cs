using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace SYSTEM
{
    public class cStation
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@Param", "04");
            return DB.ExecuteReader(cmm);
        }

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListStations()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@Param", "05_01");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Param", "01");
            cmm.Parameters.AddWithValue("@StationDescription", StationDescription);
            cmm.Parameters.AddWithValue("@StationStoreId", StationStoreID);
            cmm.Parameters.AddWithValue("@StationName", StationName);
            cmm.Parameters.AddWithValue("@StationLineID", StationLineID);
          
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable CheckSku()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Param", "06");
            cmm.Parameters.AddWithValue("@StationName", StationName);

            return DB.ExecuteReader(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@Param", "02");
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@StationDescription", StationDescription);
            cmm.Parameters.AddWithValue("@StationName", StationName);
            cmm.Parameters.AddWithValue("@StationStoreId", StationStoreID);
            cmm.Parameters.AddWithValue("@StationLineId", StationLineID);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@Param", "03");
            cmm.Parameters.AddWithValue("@uid", UserId);
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@isactive", false);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@Param", "05");
            cmm.Parameters.AddWithValue("@StationDescription", StationDescription);
            return DB.ExecuteReader(cmm);
        }

        public DataTable StockList()
        {
            cmm = DB.SqlCommandSp("sp_transaction_stock_card");
            cmm.Parameters.AddWithValue("@Params", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@StationId", StationId);
            return DB.ExecuteReader(cmm);
        }

        public DataTable Check()
        {
            cmm = DB.SqlCommandSp("sp_maint_Stations");
            cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@Param", "07");
           
            return DB.ExecuteReader(cmm);
        }


        public DataTable StockSearch()
        {
            cmm = DB.SqlCommandSp("sp_transaction_stock_card");
            cmm.Parameters.AddWithValue("@Params", "05");
            cmm.Parameters.AddWithValue("@isactive", isActive);
            cmm.Parameters.AddWithValue("@UID", UserId);
            cmm.Parameters.AddWithValue("@StationId", StationId);
            cmm.Parameters.AddWithValue("@name", Name);
            return DB.ExecuteReader(cmm);
        }

        public int StationId { get; set; }
        public string StationName { get; set; }
        public string StationDescription { get; set; }
        public int StationStoreID { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Boolean isActive { get; set; }
        public string UserId { get; set; }
       
        public int StationLineID { get; set; }
    }
}