using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageLeave : System.Web.UI.Page
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
        }
        else if (Session["loggeduser"].ToString().Equals("2"))
        {
            Menu m = (Menu)Master.FindControl("menu1");
            m.Visible = true;
        }

        if (Page.IsPostBack == false)
        {
            getLeaveData();
        }

  
    }

    public void getLeaveData()
    {
        GridView1.DataSource = db.getAllPendingLeaves();
        GridView1.DataBind();
        GridView2.DataSource = db.getAllLeaves();
        GridView2.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("xApprove"))
        {
            String LID=e.CommandArgument.ToString();
            if (db.approveLeave(LID))
            {
                getLeaveData();
            }
        }
        else if (e.CommandName.Equals("xReject"))
        {
            String LID = e.CommandArgument.ToString();
            if (db.RejectLeave(LID))
            {
                getLeaveData();
            }
        }

    }
}