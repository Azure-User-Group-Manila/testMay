using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SYSTEM
{
    public partial class Home : System.Web.UI.Page
    {
        cDashboard DASH = new cDashboard();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] != null)
            {
                this.Master.ServerInfo();
                this.Master.UserInfo();
                if (!IsPostBack)
                {
                    if (Convert.ToInt32(Session["ApproverCount"]) > 0)
                    {
                        Response.Redirect("StockMovementApproval.aspx");
                    }
                    //LOAD_DASHBOARD();
                }
            }
            else
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        private void LOAD_DASHBOARD()
        {
            DataTable DT = new DataTable();
            DT = DASH.Select_Asset_By_Location();
            Chart1.DataSource = DT;
            Chart1.Series["Series1"].XValueMember = "DashDesc";
            Chart1.Series["Series1"].YValueMembers = "cnt";
            Chart1.Series["Series1"]["PieLabelStyle"] = "outside";
            Chart1.DataBind();
            Chart1.Style.Add("width", "100%");
            lblC1Total.Text = "Total Assets: " + String.Format("{0:#,##0}", DT.Compute("Sum(cnt)", ""));
            DataTable DT2 = new DataTable();
            DT2 = DASH.Select_Asset_By_Area();
            Chart2.DataSource = DT2;
            Chart2.Series["Series1"].XValueMember = "DashDesc";
            Chart2.Series["Series1"].YValueMembers = "cnt";
            Chart2.Series["Series1"]["PieLabelStyle"] = "outside";
            Chart2.DataBind();
            Chart2.Style.Add("width", "100%");
            lblC2Total.Text = "Total Assets: " + String.Format("{0:#,##0}", DT2.Compute("Sum(cnt)", ""));
            DataTable DT3 = new DataTable();
            DT3 = DASH.Select_Stock_Level();
            Chart3.DataSource = DT3;
            Chart3.Series["Series1"].XValueMember = "CATEGORY";
            Chart3.Series["Series1"].YValueMembers = "CNT";
            Chart3.Series["Series1"]["PieLabelStyle"] = "outside";
            Chart3.DataBind();
            Chart3.Style.Add("width", "100%");
            //lblC3Total.Text = "Total Assets: " + String.Format("{0:#,##0}", DT3.Compute("Sum(CNT)", ""));
            DataTable DT4 = new DataTable();
            DT4 = DASH.Select_Budget_Actual();
            ViewState["xBudget"] = DT4;
            Chart4.DataSource = DT4;
            Chart4.Series["Budget"].XValueMember = "NAME";
            Chart4.Series["Budget"].YValueMembers = "BUDGET";
            Chart4.Series["Actual"].XValueMember = "NAME";
            Chart4.Series["Actual"].YValueMembers = "ACTUAL";
            Chart4.DataBind();
            Chart4.Style.Add("width", "100%");
            grdView.DataSource = DT4;
            grdView.DataBind();
            DataTable DT5 = new DataTable();
            DT5 = DASH.Get_Critical();
            ViewState["xCritical"] = DT5;
            grdCritical.DataSource = DT5;
            grdCritical.DataBind();
            lblCritical.Text = DT5.Rows.Count.ToString();
            DataTable DT6 = new DataTable();
            DT6 = DASH.Get_Overstocked();
            ViewState["xOverstocked"] = DT6;
            grdOverstocked.DataSource = DT6;
            grdOverstocked.DataBind();
            lblOverstocked.Text = DT6.Rows.Count.ToString();
            DataTable DT7 = new DataTable();
            DT7 = DASH.Get_Asset_By_Location();
            ViewState["xByLocation"] = DT7;
            grdByLocation.DataSource = DT7;
            grdByLocation.DataBind();
            lblByLocation.Text = DT7.Rows.Count.ToString();
            lblStockSummary.Text = DT7.Compute("Sum(CNT)", "").ToString();
            //COUNTS
            DataTable DT10 = new DataTable();
            DT10 = DASH.Get_OpenPO_Count();
            lblOpenPo.Text = DT10.Rows[0][0].ToString();
            DataTable DT11 = new DataTable();
            DT11 = DASH.Get_POReceiving_Count();
            lblPOReceiving.Text = DT11.Rows[0][0].ToString();
            DataTable DT12 = new DataTable();
            DT12 = DASH.Get_FATMApproval_Count();
            lblFATMApproval.Text = DT12.Rows[0][0].ToString();
            DataTable DT13 = new DataTable();
            DT13 = DASH.Get_InTransit_Count();
            lblInTransit.Text = DT13.Rows[0][0].ToString();
        }
        private void INVENTORY_STATUS()
        {
        }
        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdView.PageIndex = e.NewPageIndex;
            grdView.DataSource = ViewState["xBudget"];
            grdView.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "ViewBudget", "ViewBudget();", true);
            LOAD_DASHBOARD();
        }
        protected void grdCritical_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCritical.PageIndex = e.NewPageIndex;
            grdCritical.DataSource = ViewState["xCritical"];
            grdCritical.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "ViewCritical", "ViewCritical();", true);
            LOAD_DASHBOARD();
        }
        protected void grdOverstocked_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOverstocked.PageIndex = e.NewPageIndex;
            grdOverstocked.DataSource = ViewState["xOverstocked"];
            grdOverstocked.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "ViewOverStocked", "ViewOverStocked();", true);
            LOAD_DASHBOARD();
        }
        protected void grdByLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdByLocation.PageIndex = e.NewPageIndex;
            grdByLocation.DataSource = ViewState["xByLocation"];
            grdByLocation.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "ViewByLocation", "ViewByLocation();", true);
            LOAD_DASHBOARD();
        }
        protected void btnBudgetExport_Click(object sender, EventArgs e)
        {
            gvBudgetExport.DataSource = ViewState["xBudget"];
            gvBudgetExport.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=BudgetVsActual.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvBudgetExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            LOAD_DASHBOARD();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        protected void bntForAllocationExport_Click(object sender, EventArgs e)
        {
            grdByLocationExport.DataSource = ViewState["xByLocation"];
            grdByLocationExport.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=AssetsForAllocation.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdByLocationExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            LOAD_DASHBOARD();
        }
        protected void bntCriticalExport_Click(object sender, EventArgs e)
        {
            grdCriticalExport.DataSource = ViewState["xCritical"];
            grdCriticalExport.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=StockLevelCritical.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdCriticalExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            LOAD_DASHBOARD();
        }
        protected void bntOverstockedExport_Click(object sender, EventArgs e)
        {
            grdOverstockedExport.DataSource = ViewState["xOverstocked"];
            grdOverstockedExport.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=StockLevelOverstocked.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdOverstockedExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
            LOAD_DASHBOARD();
        }
    }
}