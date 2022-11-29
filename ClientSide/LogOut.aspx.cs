using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["User"] = null;
        Session["Admin"] = null;
        Session["StorageManager"] = null;
        Response.Redirect("Home.aspx");
    }
}