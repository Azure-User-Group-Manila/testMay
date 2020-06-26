using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;


namespace SYSTEM
{
    public class cAuditLogs
    {
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
        public string UID { get; set; }
        public string search_string { get; set; }
        public string user_id { get; set; }
        public string event_type { get; set; }
        public string event_desc { get; set; }

        public DataTable ListAll()
        {
            cmm = DB.SqlCommandSp("sp_auditlogs");

          cmm.Parameters.AddWithValue("@param", "09");


        cmm.Parameters.AddWithValue("@uid", UID);
            return DB.ExecuteReader(cmm);
        }

        public DataTable LOADLISTSEARCH()
        {
            cmm = DB.SqlCommandSp("sp_auditlogs");
            cmm.Parameters.AddWithValue("@param", "05");
            cmm.Parameters.AddWithValue("@uid", UID);
            cmm.Parameters.AddWithValue("@event_type", event_type);
            cmm.Parameters.AddWithValue("@event_desc", search_string);
            cmm.Parameters.AddWithValue("@user_id", user_id);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListUserIDs()
        {
            cmm = DB.SqlCommandSp("sp_auditlogs");
            cmm.Parameters.AddWithValue("@param", "07");
            cmm.Parameters.AddWithValue("@uid", UID);
            return DB.ExecuteReader(cmm);
        }

        public DataTable ListEventType()
        {
            cmm = DB.SqlCommandSp("sp_auditlogs");
            cmm.Parameters.AddWithValue("@param", "08");
            cmm.Parameters.AddWithValue("@uid", UID);
            return DB.ExecuteReader(cmm);
        }
    }
}