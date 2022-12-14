using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HolidayList : System.Web.UI.Page
{
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        if (Session["loggeduser"].ToString().Equals("null") == false)
        {
            Button b = (Button)Master.FindControl("Button1");
            b.Text = "logout";
            Menu m1 = (Menu)Master.FindControl("menu4");
            m1.Visible = false;
        }

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
            Panel1.Visible = true;
        }
        GridView1.DataSource = db.DisplayHolidays();
        GridView1.DataBind();
    }
  
    protected void BtnAddHoliday_Click(object sender, EventArgs e)
    {
        String d = TextBox1.Text;
        String Desc = TextBox2.Text.ToString();
        if (db.InsertHolidays(d,Desc))
        {
            GridView1.DataSource = db.DisplayHolidays();
            GridView1.DataBind();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "alert('Inserted')", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "alert('Try Again')", true);
        }
    }
    protected void BtnNewHoliday_Click(object sender, EventArgs e)
    {
        PanelHoliday.Visible = true;
    }
}