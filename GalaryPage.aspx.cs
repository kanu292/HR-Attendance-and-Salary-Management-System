using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class GalaryPage : System.Web.UI.Page
{
    String path;
    String[] imgfiles;
    FileInfo fi;
    int val;

    protected void Page_Load(object sender, EventArgs e)
    {
        path = Server.MapPath("~/BackGrounds/Profile");
        imgfiles = Directory.GetFiles(path);
        val = int.Parse(Session["values"].ToString());
        if (val < imgfiles.Length)
        {
            fi = new FileInfo(imgfiles[val]);
            Image1.ImageUrl = "BackGrounds/Profile/" + fi.Name;
            val++;
            Session["values"] = val;
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        val = int.Parse(Session["values"].ToString());      
        if (val < imgfiles.Length)
        {
            fi = new FileInfo(imgfiles[val]);
            Image1.ImageUrl = "BackGrounds/Profile/" + fi.Name;
            val++;
            Session["values"] = val;
        }
        else
        {
            val = 0;
            Session["values"] = val;
        }
    }
}