using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["password"].ToString().Equals("change"))
        {
            changepanel1.Visible=true;
        }
        else if(Session["password"].ToString().Equals("forget"))
        {
            forgotpanel1.Visible=true;
        }
    }
    protected void Btnchnage_Click(object sender, EventArgs e)
    {
        Employee e1=new Employee();
        e1.Eid1=TextBox1.Text;
        e1.Epassword1=TextBox2.Text;
        String newpwd = TextBox3.Text;
        if (db.updatePassword(e1,newpwd))
        {
            Response.Write("<script>alert('Password Changed')</script>");
        }
        else
        {
            Response.Write("<script>alert('UnAuhorize User')</script>");
        }
    }
    protected void BtnForget_Click(object sender, EventArgs e)
    {
        Employee e1 = new Employee();
        e1.Eid1 = TextBox5.Text;
        e1.Eemail1 = TextBox6.Text;
        if (db.forgetpassword(e1))
        {
            Response.Write("<script>alert('Password Changed')</script>");
        }
        else
        {
            Response.Write("<script>alert('Unauthorize User')</script>");
        }
    }
}