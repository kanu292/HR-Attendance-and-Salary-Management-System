using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class viewAttendance : System.Web.UI.Page
{
    Database db = new Database();
    int pday;
    int wday;
    int absent;
    DataTable dt = new DataTable();

    int monthval;
    String[] Months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    protected void Page_Load(object sender, EventArgs e)
    {

        ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "alert('" + Session["loggeduser"] + "')", true);
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
        }

        if (Page.IsPostBack == false)
        {
            monthval = int.Parse(Session["monthss"].ToString());
            displaymonth();
        }
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label Lb = e.Item.FindControl("Label1") as Label;
        TextBox label = e.Item.FindControl("TextBox1") as TextBox;
        if (label.Text == "P")
        {
            label.BackColor = System.Drawing.Color.FromArgb(54, 54, 54);
            pday++;
            wday++;
        }
        else if (label.Text == "A")
        {
            label.BackColor = System.Drawing.Color.LightGray;
            absent++;
            wday++;
        }
        else if (label.Text == "L")
        {
            label.BackColor = System.Drawing.Color.Goldenrod;
            wday++;
            absent++;
        }
        else if (label.Text == "H")
        {
            label.BackColor = System.Drawing.Color.DeepSkyBlue;
        }
        else
        {
            label.BackColor = System.Drawing.Color.Transparent;
            Lb.BackColor = System.Drawing.Color.Transparent;
        }
    }

    public void setAngle()
    {
        ProgressText.InnerText = ((pday * 100) / wday) + "%";
        LblTotalDays.Text = "Working Days : " + wday;
        LblPresent.Text = "Present Days : " + pday;
        LblAbsent.Text = "Absent Days : " + absent;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataList1.DataSource = null;
        DataList1.DataBind();
        Button2.Visible = true;
        monthval = int.Parse(Session["monthss"].ToString());
        monthval--;
        displaymonth();
        Session["monthss"] = monthval;
        if (monthval <= 0)
            Button1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataList1.DataSource = null;
        DataList1.DataBind();
        Button1.Visible = true;
        monthval = int.Parse(Session["monthss"].ToString());
        monthval++;
        displaymonth();
        Session["monthss"] = monthval;
        if (monthval >= 11)
            Button2.Visible = false;
    }

    public void displaymonth()
    {
        pday = int.Parse(Session["p"].ToString());
        absent = int.Parse(Session["a"].ToString());
        wday = int.Parse(Session["w"].ToString());
        dt = db.getATT(Session["loginID"].ToString(), Months[monthval], "22");
        if (dt.Rows.Count > 0)
        {

            Label2.Text = Months[monthval] + "   2022";
            DataList1.DataSource = dt;
            DataList1.DataBind();
            setAngle();
        }
        else
        {
            Response.Write("<script>alert('No More Attendance Found')</script>");
       //     ClientScript.RegisterClientScriptBlock(this.GetType(), "hi", "alert('No More Attendance Found')", true);
            pday = 0;
            absent = 0;
            wday = 0;
            monthval--;
            monthval = int.Parse(Session["monthss"].ToString());
            DataList1.DataSource = null;
            DataList1.DataBind();
        }

    }
}