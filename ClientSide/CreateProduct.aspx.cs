using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CreateProduct : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    private localhost.Product P = new localhost.Product();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null || (Session["Admin"] == null && Session["User"] == null))
            Response.Redirect("Home.aspx");
        if (!Page.IsPostBack)
        {
            TBName.Attributes.Add("placeholder","Product Name");
            TBDescription.Attributes.Add("placeholder","Product Description");
            TBPrice.Attributes.Add("placeholder","Product Price");
        }
    }

    protected void BTNConfirm_Click(object sender, EventArgs e)
    {
        string message, url, script;
        if (TBName.Text.Length == 0 || TBDescription.Text.Length == 0 || TBPrice.Text.Length == 0)
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
        string OwnerName = ((DataTable)Session["User"]).Rows[0][0].ToString();
        P.Code = OwnerName + "-" + S.GetUserProductDT(OwnerName).Rows.Count.ToString();
        P.PName = TBName.Text;
        P.Description = TBDescription.Text;
        P.Price = Int32.Parse(TBPrice.Text);
        if (!FileUp.HasFile && IMG.ImageUrl == "~/images/YourPic.png")
        {
            message = "תמונת המוצר הינה חובה";
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
            P.Pic = FileUp.FileName;
        else
            P.Pic = IMG.ImageUrl.Remove(0,13);
        P.Owner = OwnerName;
        P.Status = false;
        S.CreateProduct(P);
        message = "המוצר נוסף בהצלחה";
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
            message = "תמונת המוצר הינה חובה";
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
        if (TBName.Text.Length == 0 || TBDescription.Text.Length == 0 || TBPrice.Text.Length == 0)
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
        LBLPrice.Text = TBPrice.Text;
    }
}