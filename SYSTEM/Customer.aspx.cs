using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SYSTEM
{
    public partial class Customer : System.Web.UI.Page
    {
        Helper hp = new Helper();
        cCustomer IC = new cCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                LIST();
            }
        }
          protected void LIST (object sender, EventArgs e)
        {
            LIST();
        }
        private void LIST()
        {
            DataTable DT = new DataTable();
            IC.vUID = Session["uid"].ToString();
            IC.vCust_Nm = "";
            DT = IC.List();
            ViewState["Record"] = DT;
            lbRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }

        protected void BIND_GRID()
        {
            gvList.DataSource = ViewState["Record"];
            gvList.DataBind();
        }

        protected void LISTALL(object sender, EventArgs e)
        {
            LISTALL();
        }
        private void LISTALL()
        {

            DataTable DT = new DataTable();
            IC.vUID = Session["uid"].ToString();
            DT = IC.ListAll();
            ViewState["Record"] = DT;
            lbRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LOAD_LIST_SEARCH();
        }


        private void LOAD_LIST_SEARCH()
        {
            DataTable DT = new DataTable();
            IC.vUID = Session["uid"].ToString();
            IC.vCust_Nm = txtSearch.Text;
            DT = IC.Search();
            ViewState["Record"] = DT;
            lbRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            IC.vUID = Session["uid"].ToString();
            IC.vCust_Nm = txtCust_Nm.Text.ToString();

            var ret = IC.Insert();

            if (ret == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Save');", true);
                LIST();
                txtCust_Nm.Text = "";
            }
            else if (ret == 2)
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Item Class already exists');", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' An error has occurred');", true);
        }


        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            BIND_GRID();
        }


        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "toUpdate")
            {
                string xsystemid = e.CommandArgument.ToString();
                txtId.Value = xsystemid;

                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;

                txtCust_Nm_.Text = gvList.Rows[RowIndex].Cells[1].Text;

                txtisActive.Value = gvList.Rows[RowIndex].Cells[2].Text.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "Update", "Update();", true);
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtisActive.Value == "No")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Data cannot be edited!.. Record InActive');", true);
            }
            else
            {
                IC.vUID = Session["uid"].ToString();
                IC.vCust_Nm = txtCust_Nm_.Text.ToString();

                IC.vID = Convert.ToInt32(txtId.Value);
                if (IC.Update() == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Updated');", true);
                    LIST();
                    txtCust_Nm_.Text = "";
                }
            }
        }


        protected void Delete(object sender, EventArgs e)
        {
            if (txtisActive.Value == "No")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err('Already Deleted');", true);
            }
            else
            {

                IC.vUID = Session["uid"].ToString();
                IC.vCust_Nm = txtCust_Nm.Text.ToString();

                if (IC.Delete() == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Deleted');", true);
                    LIST();
                }
            }
        }


        private void ExportGridToExcel()
        {
            gvExport.DataSource = ViewState["Record"];
            gvExport.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Customerification.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvExport.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (gvList.Rows.Count > 0)
                ExportGridToExcel();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "err('No records to export');", true);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LOAD_LIST_SEARCH();
        }

      
    }
}