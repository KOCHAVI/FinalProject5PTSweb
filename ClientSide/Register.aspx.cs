using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    private localhost.User U = new localhost.User();
    protected void Page_Load(object sender, EventArgs e)
    {
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
            DDLCity.ClearSelection();
            DDLCountry.ClearSelection();
        }
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
    }

    protected void BTNReg_Click(object sender, EventArgs e)
    {
        string message, url, script;

        U.Username = TBUname.Text;
        U.Pass = TBPass.Text;
        U.Firstname = TBFname.Text;
        U.Lastname = TBLname.Text;
        U.Phone = TBPhone.Text;
        U.Coins = 0;
        U.Email = TBEmail.Text;
        U.Address = TBAddress.Text;
        U.NumAddress = TBNumaddress.Text;
        U.City = DDLCity.Text;
        U.Country = DDLCountry.Text;
        if (S.IsUsernameTaken(U.Username))
        {
            message = "שם המשתמש תפוס, נסה שם משתמש אחר";
            url = "#";
            script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            return;
        }
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
            return;
        }
        S.Register(U);

        message = "ברוך הבא! עכשיו תועבר לדף הכניסה";
        url = "Login.aspx";
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