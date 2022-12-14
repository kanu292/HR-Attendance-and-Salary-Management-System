using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Timeline : System.Web.UI.Page
{
    Database db=new Database();
    
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
            PanelTimeline.Visible = true;
        }
        else if (Session["loggeduser"].ToString().Equals("2"))
        {
            Menu m = (Menu)Master.FindControl("menu1");
            m.Visible = true;
            PanelTimeline.Visible = true;
        }
        if (Page.IsPostBack==false)
        {
            Repeater1.DataSource = db.viewTimeline();
            Repeater1.DataBind();
        }
    }
    protected void BtnAddTimeline_Click(object sender, EventArgs e)
    {       
            DateTime dt = DateTime.Now;
            String desc = TxtTimeline.Text;
            String type = null;
            if (Session["loggeduser"].ToString().Equals("2"))
                type = "HR Manager";
            else if (Session["loggeduser"].ToString().Equals("1"))
                type = "Accountant";

            db = new Database();
            if (db.AddnewTimeline(dt, desc, type))
            {
                Response.Write("<script>alert('Timeline Added')</script>");
                Response.Redirect("Timeline.aspx");
                Repeater1.DataSource = db.viewTimeline();
                Repeater1.DataBind();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "alert('Sorry ! Try Again ')", true);
            }      
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Repeater1.DataSource = db.viewTimeline();
        Repeater1.DataBind();
    }
    protected void BtnnewTime_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Repeater1.DataSource = db.viewTimelinebyDate(TextBox1.Text);
        Repeater1.DataBind();
    }
}