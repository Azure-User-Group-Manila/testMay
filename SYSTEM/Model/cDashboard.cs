using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace SYSTEM
{
    public class cDashboard
    { 
        DBHelper DB = new DBHelper();
        SqlCommand cmm = new SqlCommand();
         
        public string PONotYetReceived { get; set; }
        public string FATMForApproval { get; set; }
        public string AssetAccountabilityForApproval { get; set; }
        public string IntransitTransferToStore { get; set; }
        public string IntransitTransferToHo { get; set; }
        public string CancelTransfer { get; set; }
        public string CancelPORR { get; set; }
        public string CancelTransferRR { get; set; }
        public string InventoryTotalEnt { get; set; }
        public string PercentBudget { get; set; }
        public string totalStore { get; set; }
         

        //public DataTable Select_All()
        //{
        //    cmm = DB.SqlCommandSp("sp_get_Dashboard"); 
        //    return DB.ExecuteReader(cmm);
        //}
        //  public DataTable ListP()
        //{
        //    cmm = DB.SqlCommandSp("sp_maint_dashboard_PieChart"); 
        //    return DB.ExecuteReader(cmm);
        //}

        public DataTable Select_Asset_By_Location()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "01");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Select_Asset_By_Area()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "03");
            return DB.ExecuteReader(cmm);             
        }


        public DataTable Select_Stock_Level()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "02");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Select_Budget_Actual()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "04");
            return DB.ExecuteReader(cmm);
        }


        public DataTable Get_Critical()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "05");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Get_Overstocked()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "06");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Get_Asset_By_Location()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "07");
            return DB.ExecuteReader(cmm);
        }


        public DataTable Get_OpenPO_Count()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "10");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Get_POReceiving_Count()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "11");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Get_FATMApproval_Count()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "12");
            return DB.ExecuteReader(cmm);
        }

        public DataTable Get_InTransit_Count()
        {
            cmm = DB.SqlCommandSp("sp_get_Dashboard");
            cmm.Parameters.AddWithValue("@Params", "13");
            return DB.ExecuteReader(cmm);
        }
    }
}