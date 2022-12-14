using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewProfile : System.Web.UI.Page
{
    Database db = new Database();
    Employee eb = new Employee();

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
            DropDownCast.DataSource = db.getAllCast();
            DropDownCast.DataBind();
            DisplayEmployee();
        }
    }

    public void DisplayEmployee()
    {
        eb = db.profileDetails(Session["loginID"].ToString());
        Image1.ImageUrl = "BackGrounds/person_images/" + eb.EPic1;
        TxtName.Text = eb.Ename1;
        TxtEmail.Text = eb.Eemail1;
        TxtMob.Text = eb.Emob1;      
        DropDownCast.DataTextField = eb.Ecast1;
        DropDownList1.DataTextField = eb.EGender1;
        CalendarExtender1.SelectedDate = DateTime.Parse(eb.EBdate1);
        LblEmpID.Text = eb.Eid1;
        LblEmpDesignation.Text = eb.EDesignation1;
        LblDept.Text = "Department : " + eb.EDepartment1;
        LblShift.Text = "Time : " + eb.EshiftTime1;
    //    LblLeaves.Text = "Remaining Leave :" + eb.Eleavebalance1;
    }

    protected void BtnProfileSave_Click(object sender, EventArgs e)
    {
        Employee emp = new Employee();
        emp.Eid1 = Session["loginID"].ToString();
        emp.Ename1 = TxtName.Text;
        emp.Eemail1 = TxtEmail.Text;
        emp.Emob1 = TxtMob.Text;
        emp.Ecast1 = DropDownCast.SelectedItem.ToString();
        emp.EGender1 = DropDownList1.SelectedItem.ToString();
        emp.EBdate1 = txtBdate.Text;
        if (db.updatePersonalDetails(emp))
        {
            Response.Write("<script>alert('Update Successsfully'</script>");
            DisplayEmployee();
        }
        else
        {
            Response.Write("<script>alert('Error ! Try Again Later'</script>");
        }
    }
}