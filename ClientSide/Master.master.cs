using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master : System.Web.UI.MasterPage
{
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            DataTable dt = (DataTable)Session["User"];
            Session["User"] = S.GetDTByUsername(dt.Rows[0][0].ToString());
            HLReg.Text = "Profile";
            HLReg.NavigateUrl = "~/ProfileSettings.aspx";
            HLLogIn.Text = "Log Out";
            HLLogIn.NavigateUrl = "~/LogOut.aspx";
            HLAdmin.Visible = false;
            HLMyProducts.Visible = true;
            HLBuyCoins.Visible = true;
            LBLCoins.Text = "Coins: " + ((DataTable)Session["User"]).Rows[0][5].ToString();
        }
        else if (Session["Admin"] != null)
        {
            HLReg.Visible = false;
            HLLogIn.Text = "Log Out";
            HLLogIn.NavigateUrl = "~/LogOut.aspx";
            HLAdmin.Visible = true;
            HLMyProducts.Visible = false;
            HLBuyCoins.Visible = false;
            LBLCoins.Text = "";
        }
        else if (Session["StorageManager"] != null)
        {
            HLReg.Visible = false;
            HLLogIn.Text = "Log Out";
            HLLogIn.NavigateUrl = "~/LogOut.aspx";
            HLAdmin.Visible = true;
            HLAdmin.Text = "StoragePage";
            HLAdmin.NavigateUrl = "~/StoragePage.aspx";
            HLMyProducts.Visible = false;
            HLBuyCoins.Visible = false;
            LBLCoins.Text = "";
        }
        else
        {
            HLReg.Text = "Register";
            HLReg.NavigateUrl = "~/Register.aspx";
            HLLogIn.Text = "Log In";
            HLLogIn.NavigateUrl = "~/Login.aspx";
            HLAdmin.Visible = false;
            HLMyProducts.Visible = false;
            HLBuyCoins.Visible = false;
            LBLCoins.Text = "";
        }
    }
}
