using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestLeave : System.Web.UI.Page
{

    Database db;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggeduser"].ToString().Equals("null") == false)
        {
            //ImageButton p = (ImageButton)Master.FindControl("menubar");
            //p.Visible = true;
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
            ModalPopupExtender1.Show();
            displayLeaves();
        }
    }

    public void displayLeaves()
    {
        db=new Database();
        String EID=Session["loginID"].ToString();
        GridView1.DataSource=db.getEmployeeLeave(EID);
        GridView1.DataBind();
    }

    protected void BtnAddLeave_Click(object sender, EventArgs e)
    {
        String EID = Session["loginID"].ToString();
        String Date = TxtLeaveDate.Text;
        String Reason = TxtLeaveReason.Text;
        db = new Database();
        if (db.SentLeaveRequest(EID, Date, Reason))
        {
            displayLeaves();
            Response.Redirect("RequestLeave.aspx");
        }
        else
        {
            Response.Redirect("RequestLeave.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("xCancel"))
        {

        }
    }
}