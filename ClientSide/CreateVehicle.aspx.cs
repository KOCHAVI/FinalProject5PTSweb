using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CreateVehicle : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    private localhost.Vehicle V = new localhost.Vehicle();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
            Response.Redirect("Home.aspx");
        if (!Page.IsPostBack)
        {
            TBName.Attributes.Add("placeholder", "Vehicle Name");
            TBType.Attributes.Add("placeholder", "Vehicle Type");
            TBCapacity.Attributes.Add("placeholder", "Vehicle Capacity");
        }
    }
    protected void BTNConfirm_Click(object sender, EventArgs e)
    {
        string message, url, script;
        if (TBName.Text.Length == 0 || TBType.Text.Length == 0 || TBCapacity.Text.Length == 0)
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
        V.Vcode = TBName.Text + S.GetVehicles();
        V.Vname = TBName.Text;
        V.Vtype = TBType.Text;
        V.Capacity = "0/" + TBCapacity.Text;
        if (!FileUp.HasFile && IMG.ImageUrl == "~/images/YourPic.png")
        {
            message = "תמונת הרכב הינה חובה";
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
        if (FileUp.HasFile)
            V.Pic = FileUp.FileName;
        else
            V.Pic = IMG.ImageUrl.Remove(0, 13);
        V.Status = false;
        S.CreateVehicle(V);
        message = "הרכב נוסף בהצלחה";
        url = "MyProducts.aspx";
        script = "window.onload = function(){ alert('";
        script += message;
        script += "');";
        script += "window.location = '";
        script += url;
        script += "'; }";
        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
    }
    protected void BTNCheck_Click(object sender, EventArgs e)
    {
        string message, url, script;
        if (!FileUp.HasFile)
        {
            message = "תמונת הרכב הינה חובה";
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
        if (TBName.Text.Length == 0 || TBType.Text.Length == 0 || TBCapacity.Text.Length == 0)
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
        FileUp.SaveAs(Server.MapPath("ProductIMGS/") + FileUp.FileName);
        IMG.ImageUrl = "~/ProductIMGS/" + FileUp.FileName;
        LBLName.Text = TBName.Text;
        LBLCapacity.Text = "0/" + TBCapacity.Text;
    }
}