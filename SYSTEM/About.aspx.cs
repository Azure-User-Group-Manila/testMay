using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SYSTEM
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] == null) Response.Redirect("Login.aspx");
            Label1.Text = System.Configuration.ConfigurationSettings.AppSettings["Saying1"];
            Label2.Text = System.Configuration.ConfigurationSettings.AppSettings["Saying2"];
        }
    }
}