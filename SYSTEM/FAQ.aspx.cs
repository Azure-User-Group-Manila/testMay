using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using System.Configuration;

namespace SYSTEM
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        cFAQ cfaq = new cFAQ();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uId"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                DataTable DT = new DataTable();
                cfaq.isActive = true;
                DT = cfaq.List();
                string x = "";
                int y = 1;
                lblFAQ.Text = ConfigurationManager.AppSettings["FAQ"].ToString();
                foreach (DataRow row in DT.Rows)

                {

                    y++;
                    string question = row["Question"].ToString();
                    string answer = row["Answer"].ToString();
                    answer = answer.Replace("'", "&#39;");
                    question = question.Replace("'", "&#39;");
                    x = x + "<div class=\"panel panel-primary\"><div style=\"background-color: white;color:#006666;padding:4px;border-color: #bce8f1;\" class=\"panel-heading\"><h4 style=\"font-weight: bold;\" class=\"panel-title\"><a data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#collapseITF" + y.ToString() + "\">" + question + "</a></h4></div><div id=\"collapseITF" + y.ToString() + "\" style=\"padding:2px;\"  class=\"panel-collapse collapse\"><div style=\"font-style: italic;\" class=\"panel-body\">" + answer + "</div></div></div>";
                    //&#39;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "err", "$('#DivAccordion').html('" + x + "');", true);
                
            }
        }

private void replace(char p1,char p2,char p3)
{
 	throw new NotImplementedException();
}

        public object index { get; set; }
    }
}