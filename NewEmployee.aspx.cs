using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewEmployee : System.Web.UI.Page
{
    Employee emp;
    Database db;

    protected void Page_Load(object sender, EventArgs e)
    {
        db = new Database();
        if (Page.IsPostBack == false)
        {
            db = new Database();
            DropDownList1.DataSource = db.getAllDesg();
            DropDownList1.DataBind();
            DropDownList2.DataSource = db.getAllDept();
            DropDownList2.DataBind();
            DropDownList3.DataSource = db.getAllCast();
            DropDownList3.DataBind();
            DropDownList4.DataSource = db.getAllShift();
            DropDownList4.DataBind();
        }

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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType.Equals("image/jpeg"))
            {
                emp = new Employee();
                emp.Ename1 = Txtname.Text;
                emp.Eemail1 = TxtEmail.Text;
                emp.EBdate1 = TxtBdate.Text;
                emp.Ecast1 = DropDownList3.SelectedItem.ToString();
                emp.Emob1 = Txtmob.Text;
                emp.EGender1 = DropDownList5.SelectedItem.ToString();
                emp.EDesignation1 = DropDownList2.SelectedItem.ToString();
                emp.EDepartment1 = DropDownList1.SelectedItem.ToString();
                emp.EshiftTime1 = DropDownList4.SelectedItem.ToString();
                emp.EshiftID1 = db.getShiftID(emp.EshiftTime1);
                emp.Ebasic1 = double.Parse(Txtbasic.Text);
                String filename=db.InsertEmployee(emp);
                FileUpload1.SaveAs(Server.MapPath("~/BackGrounds/person_images/") + filename + ".jpg");
            }
            else
            {
                Response.Write("<script>alert('Please Upload Jpg / Jpeg File Only')</script>");
            }
        }
    }
}