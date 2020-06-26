using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
namespace SYSTEM
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        //cTravel travel = new cTravel();
        //cOBP obp = new cOBP();
        //cAssetAccountability aa = new cAssetAccountability();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Menu"] != null) //CheckAccess();
            if (Session["uId"] != null)
            {
                ServerInfo();
                UserInfo();
                Menus();
            }
        }
        public void ServerInfo()
        {
            DBHelper DB = new DBHelper();
            lbFooter.Text = DB.Server();
        }
        protected void travelRequest_Click(object sender, EventArgs e)
        {
            /*
            if (travel.ScheduleTravel() == 1)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Travel Request schedule is successfully executed!');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Error in execution!');", true);
            }
            */
        }
        protected void OBPRequest_Click(object sender, EventArgs e)
        {
            /*
            if (obp.ScheduleOfficialBusinessPass() == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Official business pass schedule is successfully executed!');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Error in execution!');", true);
            }
            */
        }
        protected void AssetAccountabilityRequest_Click(object sender, EventArgs e)
        {
            /*
            if (aa.ScheduleAssetAccountability() == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Asset accountability schedule is successfully executed!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Error in execution!');", true);
            }
            */
        }
        public void UserInfo()
        {
            //cUserBranch UB = new cUserBranch();
            //UB.vUID = Session["uId"].ToString();
            //UB.vBRANCHID = Convert.ToInt32(Session["BranchId"]);
            //lbUser.Text = "Current User : " + Session["Fname"].ToString().ToUpper() + " | Branch : " + Session["Short_Branch"].ToString().ToUpper();
            lbUser.Text = "Current User : " + Session["Fname"].ToString().ToUpper() ;
        }
        private void Menus()
        {
            DataTable DT = new DataTable();
            DataTable dtMenu = new DataTable();
            StringBuilder SB = new StringBuilder();
            cAccesslevel AC = new cAccesslevel();
            AC.UID = Session["uId"].ToString();
            Session["roleID"] = AC.UserRole();
            AC.UserRoleId = Convert.ToInt32(Session["roleID"]);
            AC.SubMenuId = 0;
            AC.MenuId = 7;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            foreach (DataRow row in DT.Rows)
            {
                SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
            }
            MenuFM.InnerHtml = SB.ToString(); // FILE MAINTENANCE
            //-------------------------------------------------------------------------------------------------------------
            //AC.SubMenuId = 0;
            //AC.MenuId = 2;
            //DT = AC.ActiveMenuModule();
            //dtMenu.Merge(DT);
            SB.Clear();
            //foreach (DataRow row in DT.Rows)
            //{
            //    SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
            //}
            //Budget
            /*
            AC.SubMenuId = 1;
            AC.MenuId = 2;
            DT = AC.ActiveMenuModule();
            if (DT.Rows.Count != 0)
            {
                SB.Append("<li class='dropdown dropdown-submenu' id ='menuBudget' runat='server'><a href='#' class='dropdown-toggle' data-toggle='dropdown'>Budget</a>");
                SB.Append("<ul class='dropdown-menu'>");
                dtMenu.Merge(DT);
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
                }
                SB.Append("</ul>");
            }
            */
            //Budget
            //Procurement
            /*
            AC.SubMenuId = 2;
            AC.MenuId = 2;
            DT = AC.ActiveMenuModule();
            if (DT.Rows.Count != 0)
            {
                SB.Append("<li class='dropdown dropdown-submenu' id ='menuProcurement' runat='server'><a href='#' class='dropdown-toggle' data-toggle='dropdown'>Procurement</a>");
                SB.Append("<ul class='dropdown-menu'>");
                dtMenu.Merge(DT);
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
                }
                SB.Append("</ul>");
            }
            */
            //Procurement
            //Issuance
            /*
            AC.SubMenuId = 3;
            AC.MenuId = 2;
            DT = AC.ActiveMenuModule();
            if (DT.Rows.Count != 0)
            {
                SB.Append("<li class='dropdown dropdown-submenu' id ='menuIssuance' runat='server'><a href='#' class='dropdown-toggle' data-toggle='dropdown'>Issuance of Equipment</a>");
                SB.Append("<ul class='dropdown-menu'>");
                dtMenu.Merge(DT);
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
                }
                SB.Append("</ul>");
            }
            */
            //Issuance
            //AC.SubMenuId = 0;
            //AC.MenuId = 2;
            //DT = AC.ActiveMenuModule();
            //dtMenu.Merge(DT);
            //SB.Clear();
            //foreach (DataRow row in DT.Rows)
            //{
            //    SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
            //}
            //MenuTRAN.InnerHtml = SB.ToString(); // TRANSACTION
            //-------------------------------------------------------------------------------------------------------------
            /*
            AC.SubMenuId = 0;
            AC.MenuId = 5;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            foreach (DataRow row in DT.Rows)
            {
                SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
            }
            MenuUtilities.InnerHtml = SB.ToString(); // UTILITIES
            */
            //-------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------
            AC.SubMenuId = 0;
            AC.MenuId = 7;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            foreach (DataRow row in DT.Rows)
            {
                SB.Append(string.Format("<li><a href={0}>{1}</a></li>", row[7], row[6]));
            }
            //MenuUtilities.InnerHtml = SB.ToString(); // UTILITIES
            //-------------------------------------------------------------------------------------------------------------
            /*
            AC.SubMenuId = 0;
            AC.MenuId = 3;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
           // MenuReport.InnerHtml = "";
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                SB.Append(string.Format("<a href={0}>{1}</a>", row[7], row[6]));
                }
                // MenuReport.InnerHtml = SB.ToString(); // APPROVER
            }
            //-------------------------------------------------------------------------------------------------------------
            AC.SubMenuId = 0;
            AC.MenuId = 6;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            // MenuReport.InnerHtml = "";
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<a href={0}>{1}</a>", row[7], row[6]));
                }
                // MenuReport.InnerHtml = SB.ToString(); // REPORT
            }
            //-------------------------------------------------------------------------------------------------------------
            AC.SubMenuId = 0;
            AC.MenuId = 7;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            // MenuReport.InnerHtml = "";
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<a href={0}>{1}</a>", row[7], row[6]));
                }
                // MenuReport.InnerHtml = SB.ToString(); // REPORT
            }
            //-------------------------------------------------------------------------------------------------------------
            /*
            AC.SubMenuId = 0;
            AC.MenuId = 9;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            MenuCalendar.InnerHtml = "";
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<a href={0}>{1}</a>", row[7], row[6]));
                }
                MenuCalendar.InnerHtml = SB.ToString(); // CALENDAR
            }
            */
            //-------------------------------------------------------------------------------------------------------------
            /*
            AC.SubMenuId = 0;
            AC.MenuId = 4;
            DT = AC.ActiveMenuModule();
            dtMenu.Merge(DT);
            SB.Clear();
            MenuCalendar.InnerHtml = "";
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow row in DT.Rows)
                {
                    SB.Append(string.Format("<a href={0}>{1}</a>", row[7], row[6]));
                }

                MenuCalendar.InnerHtml = SB.ToString(); // CALENDAR
            }
            */
            Session["Menu"] = dtMenu;
        }
        private void CheckAccess()
        {
            DataTable dt = Session["Menu"] as DataTable;
            var url = Request.Url.AbsolutePath.Replace("/", "");
            var withAccess = dt.AsEnumerable()
                .Where(x => x["url"].ToString() == url).Count();
            if (url == "Home.aspx") withAccess = 0;
            /*
            if (url == "Transfer.aspx") withAccess = 1;
            if (url == "TransferHeader.aspx") withAccess = 1;

            if (url == "HistoryOrder.aspx") withAccess = 1;
            if (url == "OrderHistory.aspx") withAccess = 1;
            if (url == "POSHistory.aspx") withAccess = 1;
            if (url == "DepositHistory.aspx") withAccess = 1;
            if (url == "StatementofAcccountHistory.aspx") withAccess = 1;

            if (url == "SoaVsOrderReport.aspx") withAccess = 1;
            if (url == "SoaVsDepositReport.aspx") withAccess = 1;
            if (url == "SoaVsPOSReport.aspx") withAccess = 1;

            if (url == "Login.aspx") withAccess = 1;
            if (url == "Logout.aspx") withAccess = 1;
            if (url == "Users.aspx") withAccess = 1;
            if (url == "UserRoles.aspx") withAccess = 1;
            if (url == "AccessLevels.aspx") withAccess = 1;
            */
            if (url == "About.aspx") withAccess = 1;
            if (url == "FAQ.aspx") withAccess = 1;
            //if (url == "UserBranch.aspx") withAccess = 1;
            //if (url == "PO.aspx") withAccess = 1;
            //if (url == "ReportAssetAcct.aspx") withAccess = 1;
            //if (url == "ReportBudget.aspx") withAccess = 1;
            //if (url == "ReportFATM.aspx") withAccess = 1;
            //if (url == "ReportLedger.aspx") withAccess = 1;
            //if (url == "ReportPO.aspx") withAccess = 1;
            //if (url == "ReportReceivePO.aspx") withAccess = 1;
            //if (url == "ReportRRFATM.aspx") withAccess = 1;
            //if (url == "ReportSOH.aspx") withAccess = 1;
            //if (url == "ReportTRF.aspx") withAccess = 1;
            //if (url == "ReportOBP.aspx") withAccess = 1;
            /*if (withAccess == 0) Response.Redirect("Home.aspx");*/
        }

    }
}