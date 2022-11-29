using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TBUname.Attributes.Add("placeholder", "Username");
            TBPass.Attributes.Add("placeholder", "Password");
        }
        LBLMSG.Visible = false;
    }

    protected void BTNLog_Click(object sender, EventArgs e)
    {
        string U = TBUname.Text;
        string P = TBPass.Text;
        if (S.LoginAdmin(U, P) != null)
        {
            if (S.LoginAdmin(U, P).Rows[0][2].ToString().Equals("Admin"))
            {
                Session["Admin"] = S.LoginAdmin(U, P);
                Response.Redirect("Home.aspx");
            }         
        }
        if (S.LoginAdmin(U, P) != null)
        {
            if (S.LoginAdmin(U, P).Rows[0][2].ToString().Equals("StorageManager"))
            {
                Session["StorageManager"] = S.LoginAdmin(U, P);
                Response.Redirect("Home.aspx");
            } 
        }
        if (S.Login(U,P) == null)
        {
            LBLMSG.Visible = true;
            LBLMSG.Text = "Username OR Password Incorrect";
        }
        else
		{
            Session["User"] = S.Login(U, P);
            Response.Redirect("Home.aspx");
        }      
    }
    protected void IMGViewPass_Click(object sender, ImageClickEventArgs e)
    {
        if (TBPass.TextMode == TextBoxMode.Password)
        {
            TBPass.TextMode = TextBoxMode.SingleLine;
            IMGViewPass.ImageUrl = "~/images/EYEO.png";
        }
        else
        {
            TBPass.TextMode = TextBoxMode.Password;
            TBPass.Attributes.Add("value", TBPass.Text);
            IMGViewPass.ImageUrl = "~/images/EYEC.png";
        }
    }
}