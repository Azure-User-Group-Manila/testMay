using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYSTEM
{
    public class cStationStore
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();

        public DataTable List()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@name", vNAME);
            cmm.Parameters.AddWithValue("@uid", vUID);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "04");
            cmm.Parameters.AddWithValue("@uid", vUID); 
            return DB.ExecuteReader(cmm);
        }

        public int Insert()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "01");
            cmm.Parameters.AddWithValue("@name", vNAME);
            cmm.Parameters.AddWithValue("@uid", vUID);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Update()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "02");
            cmm.Parameters.AddWithValue("@name", vNAME);
            cmm.Parameters.AddWithValue("@uid", vUID);
            cmm.Parameters.AddWithValue("@id", vID);
            return DB.ExecuteNonQuery(cmm);
        }

        public int Delete()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "03");
            cmm.Parameters.AddWithValue("@uid", vUID);
            cmm.Parameters.AddWithValue("@id", vID);
            return DB.ExecuteNonQuery(cmm);
        }

        public DataTable Search()
        {
            cmm = DB.SqlCommandSp("sp_maint_StationStore");
            cmm.Parameters.AddWithValue("@param", "06");
            cmm.Parameters.AddWithValue("@name", vNAME);
            cmm.Parameters.AddWithValue("@uid", vUID);
            return DB.ExecuteReader(cmm);
        }

        public int vID { get; set; }
        public string vUID { get; set; }
        public string vNAME { get; set; } 

        public bool isActive { get; set; }
    }
}