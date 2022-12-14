using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;

public partial class viewReports : System.Web.UI.Page
{
    Database db = new Database();
    SqlConnection con;
    SqlCommand cmd;
    DataTable dt;
    SqlDataReader dr;

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
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Suraj-iMCA\Third_year iMCA\Semester-6\Software Project Development\HRAttendance\App_Data\HRDatabase.mdf;Integrated Security=True";
            con.Open();
            GridView1.DataSource = db.getReports();
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Suraj-iMCA\Third_year iMCA\Semester-6\Software Project Development\HRAttendance\App_Data\HRDatabase.mdf;Integrated Security=True";
        con.Open();
        cmd = new SqlCommand();      
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select * from Tbl_Reports where Id=" + TextBox1.Text;
        dr = cmd.ExecuteReader();
        dt=new DataTable();
        dt.Load(dr);
        if(dt.Rows.Count>0)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandText = dt.Rows[0][2].ToString();
            SqlDataAdapter adp = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet(dt.Rows[0][4].ToString());
            adp.Fill(ds,dt.Rows[0][6].ToString());
           // ds.WriteXml(Server.MapPath("~") + "\\ReportFiles\\"+dt.Rows[0][5].ToString()+".xml");
           // ds.WriteXmlSchema(Server.MapPath("~") + "\\ReportFiles\\" + dt.Rows[0][5].ToString() +".xsd");
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportFiles/"+dt.Rows[0][3].ToString());
            ReportViewer1.LocalReport.DataSources.Clear();
            DataTable dt1 = new DataTable();
            dt1 = ds.Tables[0];
            ReportDataSource rsource = new ReportDataSource(dt.Rows[0][5].ToString(), dt1);
            ReportViewer1.LocalReport.DataSources.Add(rsource);
            ReportViewer1.LocalReport.Refresh();
        }
   
    
       
    }
}