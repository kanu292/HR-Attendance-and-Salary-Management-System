using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{

    Database db;

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["loggeduser"].ToString().Equals("0"))
        {
            Menu m = (Menu)Master.FindControl("menu3");
            m.Visible = true;
        }
        else if (Session["loggeduser"].ToString().Equals("1"))
        {
            Menu m = (Menu)Master.FindControl("menu2");
            m.Visible = true;
        }
        else if (Session["loggeduser"].ToString().Equals("2"))
        {
            Menu m = (Menu)Master.FindControl("menu1");
            m.Visible = true;
        }
    }
    protected void Btnlog_Click(object sender, EventArgs e)
    {
        db = new Database();
        String uname = TextBox1.Text;
        String passw = TextBox2.Text;
        String cat = DropDownList1.SelectedItem.ToString();
        if (db.validEmployee(uname, passw, cat))
        {
            if(cat.Equals("Employee"))
                Session["loggeduser"] = "0";
            else if(cat.Equals("Accountant"))
                Session["loggeduser"] = "1";
            else if(cat.Equals("Manager"))
                Session["loggeduser"] = "2";

            Button b = (Button)Master.FindControl("Button1");
            b.Text = "logout";
            Session["loginID"] = uname;
            Response.Redirect("viewAttendance.aspx");
         }
         else
         {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "alert('Authentication Faild')", true);
         }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["password"] = "forget";
        Response.Redirect("ChangePassword.aspx");

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Session["password"] = "change";
        Response.Redirect("ChangePassword.aspx");
    }
}