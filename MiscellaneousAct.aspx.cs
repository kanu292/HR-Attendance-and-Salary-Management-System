using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MiscellaneousAct : System.Web.UI.Page
{
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
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
          //  Panel1.Visible = false;
        }
        else if (Session["loggeduser"].ToString().Equals("2"))
        {
            Menu m = (Menu)Master.FindControl("menu1");
            m.Visible = true;
            //Panel2.Visible = false;
        }

        if (Page.IsPostBack == false)
        {
            GridView1.DataSource = db.displaySalaryStructure();
            GridView1.DataBind();
            GridView2.DataSource = db.displayLookup();
            GridView2.DataBind();
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (db.OpenApplications(DropDownList2.SelectedItem.ToString()))
        {
            Response.Write("<script>alert('Successfully Updated')</script>");
        }
        else
        {
            Response.Write("<script>alert('Error ! Try Again Later')</script>");
        }
    }
    protected void BtnAttendance_Click(object sender, EventArgs e)
    {
        String dates = TextBox3.Text;
        if(db.isAttendanceTake(dates))
        {
            Response.Write("<script>alert('Attendance is Already Taken ! ')</script>");
        }
        else
        {
            if (db.isHoliday(dates) || DateTime.Parse(dates).ToString("ddd").Equals("Sun"))
            {
                Response.Write("<script>alert('Holiday On That Day')</script>");
                int r=db.makeEntrys(dates,"H");
                Response.Write("<script>alert('"+r+" Record Inserted')</script>");
            }
            else
            {
                Response.Write("<script>alert('Regular Schedule on That Day')</script>");
                int r = db.makeEntry(dates, "A");
                Response.Write("<script>alert('" + r + " Record Inserted')</script>");
            }           
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Database dd = new Database();
        String monthname = DropDownList1.SelectedItem.ToString();
        if(dd.isSalaryPaid(monthname))
        {
            Response.Write("<script>alert('Salary is Already Paid For Month :"+monthname+"')</script>");
        }
        else
        {
            if (dd.calculateSalary(monthname))
            {
                Response.Write("<script>alert('Salary is Paid For Month :" + monthname + "')</script>");
            }
        }
    }
}