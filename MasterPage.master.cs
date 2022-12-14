using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text.Equals("Login"))
        { 
        //    menubar.Visible = true;
            Response.Redirect("LoginPage.aspx");
        }
        else 
        {          
        //    menubar.Visible = false;
            Response.Redirect("Homepage.aspx");
            Button1.Text = "Login";
            Session["loggeduser"] = "null";
            Session["loginID"] = "null";
        }
    }
}
