using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace SYSTEM
{
    public partial class Login : System.Web.UI.Page
    {
        iLogin LOGIN = new iLogin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "hwa", "  $('#myModal').modal({ show: true });", true);
                txtUserName.Focus();
            }
        }

        private void LOAD_BRANCH()
        {
            /*
            DataTable dt = new DataTable();

            cUserBranch UB = new cUserBranch();
            UB.vUID = Session["Uid"].ToString();
            dt = UB.Search();
            
            ddBranch.DataSource = dt;
            ddBranch.DataTextField = "BRCH_NAME";
            ddBranch.DataValueField = "BRANCHID";
            ddBranch.DataBind();

            if (dt.Rows.Count > 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "Branch();", true);
            }
            else
            {

                //Session["BranchId"] = 12;
                //Session["UserRoleId"] = 1;

                //DataTable DT2 = new DataTable();
                //LOGIN.Uid = Session["Uid"].ToString();
                //DT2 = LOGIN.CheckUserRole();
                //Session["ApproverCount"] = DT2.Rows.Count;
                //if (Convert.ToInt32(Session["ApproverCount"]) > 0)
                //{
                //    Response.Redirect("StockMovementApproval.aspx");
                //}
                //else
                //{
                //    Response.Redirect("Home.aspx");
                //}
                Response.Redirect("Home.aspx");
            }
            */
        }

        private void Check()
        {
            LOGIN.Uid = txtUserName.Text;

            if (LOGIN.Select().Rows.Count > 0)
            {
                DataTable DTLOGIN = new DataTable();

                DTLOGIN = LOGIN.Select();
                //LOGIN.Password = DTLOGIN.Rows[0][23].ToString();
                //LOGIN.Fname = DTLOGIN.Rows[0][1].ToString();
                LOGIN.Password = DTLOGIN.Rows[0][2].ToString();
                LOGIN.Fname = DTLOGIN.Rows[0][3].ToString();
                

                if (LOGIN.CheckPassword(txtPassword.Text) == 1)
                {
                    Session["Uid"] = LOGIN.Uid;
                    Session["Fname"] = LOGIN.Fname;
                    //Session["BranchId"] = DTLOGIN.Rows[0]["brch_code"].ToString();
                    //Session["UserRoleId"] = DTLOGIN.Rows[0][9].ToString();
                    //Session["roleID"] = DTLOGIN.Rows[0][9].ToString();
                    //Session["User_Branch"] = DTLOGIN.Rows[0][12].ToString();
                    Session["Short_Branch"] = "";//DTLOGIN.Rows[0][24].ToString();
                    Session["UserID"] = DTLOGIN.Rows[0]["id"].ToString();

                    //LOAD_BRANCH();
                    //Page.ClientScript.RegisterStartupScript(GetType(), "hwa", "  $('#myModalBranch').modal({ show: true });", true);
                }
                else
                {                    
                    ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myModal').modal({ show: true });", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "err2", "err('Invalid Username or Password!');", true);
                }
            }
            else
            {                
                ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myModal').modal({ show: true });", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "err2", "err('Invalid Username or Password!');", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Check();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //Session["BranchId"] = ddBranch.SelectedValue.ToString();
            //Session["User_Branch"] = ddBranch.SelectedItem.ToString();
            Session["BranchId"] = "";
            Session["User_Branch"] = "";
            Session["Short_Branch"] = "";

            //DataTable dt = new DataTable();            
            //LOGIN.BiD = Convert.ToInt32(Session["BranchId"].ToString());
            //dt = LOGIN.GetShortBranchName();
            //Session["Short_Branch"] = dt.Rows[0]["Short_Desc"];
          
            Response.Redirect("Home.aspx");
        }

        protected void lbtnChange_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "cnahe", "$('#myChangePassword').modal({ show: true });", true);
        }

        //protected void lbtnForgot_Click(object sender, EventArgs e)
        //{

        //    if (txtUserName.Text == "")
        //    {
        //        lbMsg.Text = "Please enter Username";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myModal').modal({ show: true });", true);
        //    }
        //    else
        //    {
        //        LOGIN.Uid = txtUserName.Text;

        //        if (LOGIN.Select().Rows.Count > 0)
        //        {

        //            MailMessage mailMessage = new MailMessage();
        //            mailMessage.To.Add("ITBS.Retek-DevGrp1.Watsons.HO@sm-shoemart.com");
        //            mailMessage.From = new MailAddress("ITBS.Retek-DevGrp2.Watsons.HO@sm-shoemart.com");
        //            mailMessage.Subject = "ASP.NET e-mail test";
        //            mailMessage.Body = "Hello world,\n\nThis is an ASP.NET test e-mail!";
        //            SmtpClient smtpClient = new SmtpClient("172.17.224.12");
        //            smtpClient.Send(mailMessage);
                    



        //            lbMsg.Text = "Email sent. Please check email.";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "success", "$('#myModal').modal({ show: true });", true);
        //        }
        //        else
        //        {
        //            lbMsg.Text = "Username does not exist.";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myModal').modal({ show: true });", true);
        //        }
        //    }
            
            
            



        //}

        protected void bntCSave_Click(object sender, EventArgs e)
        {
            LOGIN.Uid = txtCUserName.Text;

            if (LOGIN.Select().Rows.Count > 0)
            {
                LOGIN.Password = LOGIN.Select().Rows[0]["PASSWORD"].ToString();
                LOGIN.Fname = LOGIN.Select().Rows[0][1].ToString();

                if (LOGIN.CheckPassword(txtCOld.Text) == 1)
                {
                    LOGIN.Password = txtCNew.Text;
                    LOGIN.ChangePassword();

                    ScriptManager.RegisterStartupScript(this, GetType(), "success", "success('Change Password Successful');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "hwa", "$('#myModal').modal({ show: true });", true);
                }
                else
                {
                    lblChange.Text = "Invalid Username or Password !";
                    ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myChangePassword').modal({ show: true });", true);
                }
            }
            else
            {
                lblChange.Text = "Invalid Username or Password !";

                ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#myChangePassword').modal({ show: true });", true);
            }

            txtCUserName.Text = "";
        }

       

       
    }
}