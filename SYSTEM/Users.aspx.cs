using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SYSTEM
{
    public partial class Users : System.Web.UI.Page
    {
        //Helper hp = new Helper();
        cUsers US = new cUsers();
        cUserRoles UR = new cUserRoles();
        //cDepartment DP = new cDepartment();
        //Branches_M BR = new Branches_M();
        //cEmployee EM = new cEmployee();
        int res = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                LOAD_LIST();
                LOAD_USERROLE();
                //LOAD_BRANCH();
                //LOAD_DEPARTMENT();
                //LOAD_USERTYPE();
                //LOAD_EMPLOYEES();
            }

        }

        private void LOAD_USERTYPE() {
            ddUserType.Items.Add(new ListItem("Employee", "0"));
            ddUserType.Items.Add(new ListItem("Non Employee", "1"));
            ddUserType.SelectedValue = "0";
        }

        private void LOAD_EMPLOYEES(){
            /*
            DataTable DT = new DataTable();
            EM.IsActive = true;
            EM.UserId = Session["uid"].ToString();
            DT = EM.List();

            ddListOfEmployee.DataSource = DT;
            ddListOfEmployee.DataTextField = "FULL_NAME";
            ddListOfEmployee.DataValueField = "ID";
            ddListOfEmployee.DataBind();

            ddListOfEmployee.Items.Add(new ListItem("---", "0"));
            ddListOfEmployee.SelectedValue = "0";
                */

        }

        private void LOAD_USERROLE()
        {

            DataTable DT = new DataTable();
            UR.isActive = true;
            DT = UR.List();

             
            ddUserRole.DataSource = DT;
            ddUserRole.DataTextField = "UserRole";
            ddUserRole.DataValueField = "UserRoleId";
            ddUserRole.DataBind();

            ddUserRole.Items.Add(new ListItem("---", "0"));
            ddUserRole.SelectedValue = "0";

            _ddUserRole.DataSource = DT;
            _ddUserRole.DataTextField = "UserRole";
            _ddUserRole.DataValueField = "UserRoleId";
            _ddUserRole.DataBind();

            _ddUserRole.Items.Add(new ListItem("---", "0"));
            _ddUserRole.SelectedValue = "0";

        }

        private void LOAD_BRANCH()
        {
            /*
            DataTable DT = new DataTable();
            BR.isActive = true;
            DT = BR.List();

            ddBranch.DataSource = DT;
            ddBranch.DataTextField = "brch_name";
            ddBranch.DataValueField = "id";
            ddBranch.DataBind();

            ddBranch.Items.Add(new ListItem("---", "0"));
            ddBranch.SelectedValue = "0";

            _ddBranch.DataSource = DT;
            _ddBranch.DataTextField = "brch_name";
            _ddBranch.DataValueField = "id";
            _ddBranch.DataBind();

            _ddBranch.Items.Add(new ListItem("---", "0"));
            _ddBranch.SelectedValue = "0";
            */

        }

        private void LOAD_DEPARTMENT()
        {
            /*
            DataTable DT = new DataTable();
            DP.isActive = true;
            DT = DP.List();

            ddDepartment.DataSource = DT;
            ddDepartment.DataTextField = "name";
            ddDepartment.DataValueField = "id";
            ddDepartment.DataBind();

            ddDepartment.Items.Add(new ListItem("---", "0"));
            ddDepartment.SelectedValue = "0";

            _ddDepartment.DataSource = DT;
            _ddDepartment.DataTextField = "name";
            _ddDepartment.DataValueField = "id";
            _ddDepartment.DataBind();

            _ddDepartment.Items.Add(new ListItem("---", "0"));
            _ddDepartment.SelectedValue = "0";
            */
        }

        private void LOAD_LIST()
        {

            DataTable DT = new DataTable();
            US.isactive = true;
            DT = US.List();
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

            US.systemid = txtSearch.Text.Trim();
            DataTable DT = new DataTable();
            US.isactive = true;
            US.uid = Session["uid"].ToString();
            DT = US.Search();

            ViewState["Record"] = DT;
            lbRec.Text = DT.Rows.Count.ToString();
            BIND_GRID();
        }

        protected void LOAD_LIST_ALL(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            US.uid = Session["uid"].ToString();
            DT = US.ListAll();
            ViewState["Record"] = DT;
            lbRec.Text = DT.Rows.Count.ToString();
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

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            BIND_GRID();
        }

        private void ExportGridToExcel()
        {
            gvExport.DataSource = ViewState["Record"];
            gvExport.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Users.xls");
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

        protected void SAVE(object sender, EventArgs e)
        {
            US.uid = Session["uid"].ToString();
            US.password = txtPassword.Text.Trim();            

            if(ddUserType.SelectedValue=="1")
            {
                US.fname = txtFname.Text.Trim();
                US.mname = txtMname.Text.Trim();
                US.lname = txtLname.Text.Trim();
                US.sname = txtSname.Text.Trim();
                US.email = txtEmail.Text.Trim();
                US.domainid = txtDomain.Text.Trim();
            }
            else if (ddUserType.SelectedValue == "0")
            {
                US.fname = hdfirst_name.Value.Trim().ToString();
                US.mname = hdmi_name.Value.Trim().ToString();
                US.lname = hdlast_name.Value.Trim().ToString();
                US.sname = hdsuffix_name.Value.Trim().ToString();
                US.email    = hdemail.Value.Trim().ToString();
                US.domainid = hddomain_id.Value.Trim().ToString();
            }
            US.systemid = txtSysID.Text.Trim();
            //US.employeeid = (Convert.ToInt32(ddUserType.SelectedValue) > 0) ? 0 : Convert.ToInt32(ddListOfEmployee.SelectedValue);
            US.userroleid = Convert.ToInt32(ddUserRole.SelectedValue);
            //US.branchid = Convert.ToInt32(ddBranch.SelectedValue);
            //US.departmentid = Convert.ToInt32(ddDepartment.SelectedValue);
            US.isactive = true;
            
            US.Insert();
         
            SET_DEFAULT();
            ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Save');", true);
            LOAD_LIST();
            LOAD_USERROLE();
            //LOAD_BRANCH();
            //LOAD_DEPARTMENT();

        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "toUpdate")
            {
                string xsystemid = e.CommandArgument.ToString();
                txtID.Value = xsystemid;

                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;

                US.uid = Session["uid"].ToString();

                hdfirst_name.Value=gvList.Rows[RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                hdmi_name.Value=gvList.Rows[RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                hdlast_name.Value = gvList.Rows[RowIndex].Cells[5].Text.Replace("&nbsp;", "");
                hdsuffix_name.Value=gvList.Rows[RowIndex].Cells[6].Text.Replace("&nbsp;", "");
                hdemail.Value=gvList.Rows[RowIndex].Cells[7].Text.Replace("&nbsp;", "");
                hddomain_id.Value = gvList.Rows[RowIndex].Cells[9].Text.Replace("&nbsp;", "");

                hdEmpOrNot.Value = gvList.Rows[RowIndex].Cells[8].Text.Replace("&nbsp;", "");

                _txtSysID.Text = gvList.Rows[RowIndex].Cells[1].Text.Replace("&nbsp;", "");
                _txtFname.Text = gvList.Rows[RowIndex].Cells[3].Text.Replace("&nbsp;", "");
                _txtMname.Text = gvList.Rows[RowIndex].Cells[4].Text.Replace("&nbsp;", "");
                _txtLname.Text = gvList.Rows[RowIndex].Cells[5].Text.Replace("&nbsp;", "");
                _txtSname.Text = gvList.Rows[RowIndex].Cells[6].Text.Replace("&nbsp;", "");
                _txtEmail.Text = gvList.Rows[RowIndex].Cells[7].Text.Replace("&nbsp;", "");
                _txtDomain.Text = gvList.Rows[RowIndex].Cells[9].Text.Replace("&nbsp;", "");
                _ddUserRole.SelectedValue = gvList.Rows[RowIndex].Cells[16].Text;
                _ddBranch.SelectedValue = gvList.Rows[RowIndex].Cells[17].Text;
                _ddDepartment.SelectedValue = gvList.Rows[RowIndex].Cells[18].Text;
                txtIsActive.Value = gvList.Rows[RowIndex].Cells[13].Text.Replace("&nbsp;", "");
                _txtPassword.Text = gvList.Rows[RowIndex].Cells[14].Text.Replace("&nbsp;", "");
                _txtCPassword.Text = gvList.Rows[RowIndex].Cells[14].Text.Replace("&nbsp;", "");
                ScriptManager.RegisterStartupScript(this, GetType(), "Update", "Update();", true);
            }

        }

        private void SET_DEFAULT()
        {
            txtSysID.Text = "";
            txtPassword.Text = "";
            txtCPassword.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtMname.Text = "";
            txtSname.Text = "";
            txtEmail.Text = "";
            txtDomain.Text = "";
            _txtSysID.Text = "";
            _txtPassword.Text = "";
            _txtCPassword.Text = "";
            _txtFname.Text = "";
            _txtLname.Text = "";
            _txtMname.Text = "";
            _txtSname.Text = "";
            _txtEmail.Text = "";
            _txtDomain.Text = "";

        }

        protected void UPDATE(object sender, EventArgs e)
        {
            if (hdEmpOrNot.Value == "0")
            {
                US.fname = _txtFname.Text.Trim();
                US.mname = _txtMname.Text.Trim();
                US.lname = _txtLname.Text.Trim();
                US.sname = _txtSname.Text.Trim();
                US.email = _txtEmail.Text.Trim();
                US.domainid = _txtDomain.Text.Trim();
            }
            else
            {
                US.fname    = hdfirst_name.Value.Trim().ToString();
                US.mname    = hdmi_name.Value.Trim().ToString();
                US.lname    = hdlast_name.Value.Trim().ToString();
                US.sname    = hdsuffix_name.Value.Trim().ToString();
                US.email    = hdemail.Value.Trim().ToString();
                US.domainid = hddomain_id.Value.Trim().ToString();
            }
            US.uid = Session["uid"].ToString();
            US.systemid = _txtSysID.Text.Trim();
            US.fname = _txtFname.Text.Trim();
            US.mname = _txtMname.Text.Trim();
            US.lname = _txtLname.Text.Trim();
            US.sname = _txtSname.Text.Trim();
            US.email = _txtEmail.Text.Trim();
            //US.employeeid = (Convert.ToInt32(ddUserType.SelectedValue) > 0) ? 0 : Convert.ToInt32(ddListOfEmployee.SelectedValue);
            US.domainid = _txtDomain.Text.Trim();
            US.userroleid = Convert.ToInt32(_ddUserRole.SelectedValue);
            //US.branchid = Convert.ToInt32(_ddBranch.SelectedValue);
            //US.departmentid = Convert.ToInt32(_ddDepartment.SelectedValue);
            US.ID = Convert.ToInt32(txtID.Value);

            US.Update(ref res);

            if (txtIsActive.Value == "No")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err(' Data cannot be edited!.. Record InActive');", true);
            }
            else
            {
                if (res == 1)
                {
                    
                    SET_DEFAULT();
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Save');", true);
                    LOAD_LIST();
                }
                else { ScriptManager.RegisterStartupScript(this, GetType(), "err", "err('Cannot Be Saved.. Check Your Entries');", true); }
            }
        }

        protected void DELETE(object sender, EventArgs e)
        {
            if (txtIsActive.Value == "No")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "err('Already Deleted');", true);
            }
            else
            {
                US.uid = Session["uid"].ToString();
                US.ID = Convert.ToInt32(txtID.Value);

                if (US.Delete() == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Successfully Deleted');", true);
                    LOAD_LIST();
                }
            }

        }

        protected void ddListOfEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
                    /*
            DataTable DT = new DataTable();
            EM.IsActive = true;
            EM.UserId = Session["uid"].ToString();
            EM.ID = Convert.ToInt32(ddListOfEmployee.SelectedValue);
            DT = EM.SelectEMP();
            if (DT.Rows.Count > 0)
            {                
                //hdsystem_id.Value = DT.Rows[0]["DomainID"].ToString();
                hdfirst_name.Value = DT.Rows[0]["First_Name"].ToString();
                hdmi_name.Value = DT.Rows[0]["Middle_Name"].ToString();
                hdlast_name.Value = DT.Rows[0]["Last_Name"].ToString();
                hdsuffix_name.Value = DT.Rows[0]["Suffix_Name"].ToString();
                hdemail.Value = DT.Rows[0]["iEmail"].ToString();
                hddomain_id.Value = DT.Rows[0]["DomainID"].ToString();

                txtSysID.Text = DT.Rows[0]["DomainID"].ToString();
                txtFname.Text = DT.Rows[0]["First_Name"].ToString();
                txtMname.Text = DT.Rows[0]["Middle_Name"].ToString();
                txtLname.Text = DT.Rows[0]["Last_Name"].ToString();
                txtSname.Text = DT.Rows[0]["Suffix_Name"].ToString();
                txtEmail.Text = DT.Rows[0]["iEmail"].ToString();
                txtDomain.Text = DT.Rows[0]["DomainID"].ToString();
                ddBranch.SelectedValue = DT.Rows[0]["BranchID"].ToString();
                ddDepartment.SelectedValue = DT.Rows[0]["DepartmentID"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "NewUser", "NewUser();", true);
                //UpdatePanel1.Update();
                txtSysID.Focus();

                DataTable CID = new DataTable();
                US.systemid = txtSysID.Text;
                CID = US.Check();
                hdDuplicate.Value = CID.Rows.Count.ToString();
            
            }
            else if (ddListOfEmployee.SelectedValue =="0") {
                txtSysID.Text = "";
                txtFname.Text = "";
                txtMname.Text = "";
                txtLname.Text = "";
                txtSname.Text = "";
                txtEmail.Text = "";
                txtDomain.Text = "";
                ddBranch.SelectedValue = "0";
                ddDepartment.SelectedValue = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "NewUser", "NewUser();", true);
                //UpdatePanel1.Update();
                ddListOfEmployee.Focus();
            }
            */
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddListOfEmployee.SelectedValue = "0";
            ddBranch.SelectedValue = "0";
            ddDepartment.SelectedValue = "0";
            ScriptManager.RegisterStartupScript(this, GetType(), "ModalEmployeeOrNot", "ModalEmployeeOrNot();", true);
            ddUserType.Focus();
        }
        
        protected void txtSysID_TextChanged(object sender, EventArgs e)
        {
            DataTable CID = new DataTable();
            US.systemid = txtSysID.Text;
            CID = US.Check();
            hdDuplicate.Value = CID.Rows.Count.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "checkID", "checkID()();", true);
            UpdatePanel1.Update();
        }

        public string sysid { get; set; }

    }
}