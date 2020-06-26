using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SYSTEM
{
    public partial class UserRoles : System.Web.UI.Page
    {
        cUserRoles UR = new cUserRoles();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["uId"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                LOAD_LIST();
            }
        }


        private void LOAD_LIST()
        {
            DataTable DT = new DataTable();
            UR.isActive = true;
            DT = UR.ListAll();
            ViewState["Record"] = DT;
            lblRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LOAD_LIST_SEARCH();
        }


        private void LOAD_LIST_SEARCH()
        {
            DataTable DT = new DataTable();
            
            UR.UserRole = this.txtSearch.Text.Trim();
            DT = UR.Search();
            ViewState["Record"] = DT;
            lblRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }


        protected void LOAD_LIST_ALL(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();

            DT = UR.ListAll();
            ViewState["Record"] = DT;
            lblRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }


        protected void LOAD_LIST(object sender, EventArgs e)
        {
            LOAD_LIST();
        }


        protected void BIND_GRID()
        {
            gvList.DataSource = ViewState["Record"];
            gvList.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            UR.UserId = Session["uId"].ToString();
            UR.UserRole = txtDescription.Text;

            var ret = UR.Insert();

            if (ret == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Save');", true);
                LOAD_LIST();
                txtDescription.Text = "";
            }
            else if (ret == 2)
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' User Role already exists');", true);
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Cannot Be Saved.. Check Your Entries');", true);
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

                txtDescription_.Text = gvList.Rows[RowIndex].Cells[1].Text;

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
                UR.UserId = Session["uId"].ToString();
                UR.UserRole = txtDescription_.Text;
                UR.Id = Convert.ToInt32(txtId.Value);

                var ret = UR.Update();
                if (ret == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Updated');", true);
                    LOAD_LIST();
                    txtDescription_.Text = "";
                }
                else if (ret == 2)
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' User Role already exists');", true);
            else
                    ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Cannot Be Saved.. Check ');", true);
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
                UR.UserId = Session["uId"].ToString();
                UR.Id = Convert.ToInt32(txtId.Value);
                if (UR.Delete() == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Deleted');", true);
                    LOAD_LIST();
                }
            }
        }


        private void ExportGridToExcel()
        {
            gvExport.DataSource = ViewState["Record"];
            gvExport.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=UserRoles.xls");
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