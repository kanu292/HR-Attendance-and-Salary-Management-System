<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Session["p"] = "0";
        Session["a"] = "0";
        Session["w"] = "0";
        DateTime dt = DateTime.Now;
        Session["monthss"] = dt.Month-1;
        Session["password"] = "null";
        Session["val"] = 0;
        Session["loggeduser"] = "null";
        Session["loginID"] = "null";
        Session["values"] = 0;
        Response.Redirect("Homepage.aspx");

    }

    void Session_End(object sender, EventArgs e) 
    {
        Session.Abandon();
    }
       
</script>
