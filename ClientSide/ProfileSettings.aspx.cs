using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProfileSettings : System.Web.UI.Page
{
    private DataTable dt = null;
    private localhost.Service S = new localhost.Service();
    private localhost.User U = new localhost.User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null || (Session["Admin"] == null && Session["User"] == null))
            Response.Redirect("Home.aspx");
        dt = (DataTable)Session["User"];
        if (!Page.IsPostBack)
        {
            TBFname.Attributes.Add("placeholder", " First Name");
            TBLname.Attributes.Add("placeholder", " Last Name");
            TBUname.Attributes.Add("placeholder", " Username");
            TBPass.Attributes.Add("placeholder", " Password");
            TBEmail.Attributes.Add("placeholder", " Email");
            TBPhone.Attributes.Add("placeholder", " Phone");
            TBAddress.Attributes.Add("placeholder", " Address");
            TBNumaddress.Attributes.Add("placeholder", " Address Number");
            DDLCountry.Items.Add("ISRAEL");
            DDLCountry.Items.Add("CANADA");
            DDLCountry.Items.Add("USA");
            DDLCountry.Items.Add("BRAZIL");

            TBUname.Text = dt.Rows[0][0].ToString();
            TBPass.Text = dt.Rows[0][1].ToString();
            TBFname.Text = dt.Rows[0][2].ToString();
            TBLname.Text = dt.Rows[0][3].ToString();
            TBPhone.Text = dt.Rows[0][4].ToString();
            TBEmail.Text = dt.Rows[0][6].ToString();
            TBAddress.Text = dt.Rows[0][7].ToString();
            TBNumaddress.Text = dt.Rows[0][8].ToString();
            DDLCity.SelectedValue = dt.Rows[0][9].ToString();
            DDLCountry.SelectedValue = dt.Rows[0][10].ToString();
            TBPass.Attributes.Add("value", TBPass.Text);
        }
        string SelectedValue = DDLCity.SelectedValue;
        if (DDLCountry.SelectedValue == "ISRAEL")
        {
            DDLCity.Items.Clear();
            DDLCity.Items.Add("RAMAT GAN");
            DDLCity.Items.Add("TEL AVIV");
            DDLCity.Items.Add("GIVATAYIM");
            DDLCity.Items.Add("PETAH TIKVA");
        }
        if (DDLCountry.SelectedValue == "CANADA")
        {
            DDLCity.Items.Clear();
            DDLCity.Items.Add("TORONTO");
            DDLCity.Items.Add("MONTREAL");
            DDLCity.Items.Add("CALGARY");
            DDLCity.Items.Add("OTTAWA");
        }
        if (DDLCountry.SelectedValue == "USA")
        {
            DDLCity.Items.Clear();
            DDLCity.Items.Add("NEW YORK");
            DDLCity.Items.Add("LOS ANGELES");
            DDLCity.Items.Add("CHICAGO");
            DDLCity.Items.Add("HOUSTON");
        }
        if (DDLCountry.SelectedValue == "BRAZIL")
        {
            DDLCity.Items.Clear();
            DDLCity.Items.Add("São Paulo");
            DDLCity.Items.Add("Rio de Janeiro");
            DDLCity.Items.Add("Brasília");
            DDLCity.Items.Add("Salvador");
        }
        if (DDLCity.Items.FindByValue(SelectedValue) != null)
        {
            DDLCity.SelectedValue = SelectedValue;
        }
    }

	protected void BTNUpdate_Click(object sender, EventArgs e)
	{
        string message, url, script;
        U.Username = TBUname.Text;
        U.Pass = TBPass.Text;
        U.Firstname = TBFname.Text;
        U.Lastname = TBLname.Text;
        U.Phone = TBPhone.Text;
        U.Coins = Int32.Parse(dt.Rows[0][5].ToString());
        U.Email = TBEmail.Text;
        U.Address = TBAddress.Text;
        U.NumAddress = TBNumaddress.Text;
        U.City = DDLCity.SelectedValue;
        U.Country = DDLCountry.SelectedValue;
        if (U.Username.Length == 0 || U.Pass.Length == 0 || U.Firstname.Length == 0 || U.Lastname.Length == 0 || U.Phone.Length == 0 || U.Email.Length == 0 || U.Address.Length == 0 || U.NumAddress.Length == 0)
        {
            message = "אין להשאיר נתונים ריקים";
            url = "#";
            script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
        S.Update(U);
        Session["User"] = S.Login(U.Username,U.Pass);
        message = "הנתונים עודכנו בהצלחה";
        url = "Home.aspx";
        script = "window.onload = function(){ alert('";
        script += message;
        script += "');";
        script += "window.location = '";
        script += url;
        script += "'; }";
        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
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