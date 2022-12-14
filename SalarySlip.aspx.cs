using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalarySlip : System.Web.UI.Page
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
            String[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            DropDownList1.DataSource = months;
            DropDownList1.DataBind();
            
            int y = db.getcompanyYear();
            while (y <= DateTime.Now.Year)
            {
                DropDownList2.Items.Add(y.ToString());
                y++;
            }
            DropDownList2.DataTextField = "2018";
        }
        displaySalary();
    }

    public void displaySalary()
    {
        Double total;
        String ID=Session["loginID"].ToString();
        String Month=DropDownList1.SelectedItem.ToString();
        String Year=DropDownList2.SelectedItem.ToString().Remove(0,2);
        Salary s=db.getSalaryDetails(ID,Month,Year);
        if(s!=null)
        {
            Label2.Text = Month + " " + Year;
            Label3.Text = "ID : "+s.EmpID1;
            Label4.Text = "Name : "+db.getEmployeeName(s.EmpID1);
            Label5.Text = "Slip ID : " + s.Slipid;
            Labelbasic.Text = "Rs." + s.Basic1.ToString();
            LabelPenalty.Text = "Rs." + s.Penalty1.ToString();
            LabelDA.Text ="Rs."+ s.DA1.ToString();
            LabelHRA.Text = "Rs." + s.HRA1.ToString();
            LabelMA.Text = "Rs." + s.MA1.ToString();
            LabelTA.Text = "Rs." + s.TA1.ToString();
            total = s.Basic1 + s.DA1 + s.HRA1 + s.MA1 + s.TA1-s.Penalty1;
            LabelTot.Text = "Rs. "+(s.Basic1 + s.DA1 + s.HRA1 + s.MA1 + s.TA1);
            LabelDays.Text = "Working Days :"+s.WorkingDays.ToString();
            LabelPresent.Text = "Present Days :" + s.PresentDays1.ToString();
            LabelLate.Text = "Late Days :" + s.LateDays1.ToString();
            LabelLeave.Text = "Current Month Leaves :" + s.MonthLeaves1.ToString();
            LabelLeaveBal.Text = "Remaining Leaves :" + s.CarryForwardLeave1.ToString();

            LabelAmount.Text ="Rs. "+ total.ToString();
        }        
    }

    protected void BtnSalSearch_Click(object sender, EventArgs e)
    {
        displaySalary();
    }
}