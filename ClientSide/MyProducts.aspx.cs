using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyProducts : System.Web.UI.Page
{
    private DataTable dt = null;
    private localhost.Service S = new localhost.Service();
    private localhost.Product P = new localhost.Product();
    private localhost.Giveaway G = new localhost.Giveaway();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null || (Session["Admin"] == null && Session["User"] == null))
            Response.Redirect("Home.aspx");
        if (!Page.IsPostBack)
        {
            TBSearch.Attributes.Add("placeholder", "Search Product");
            string OwnerName = ((DataTable)Session["User"]).Rows[0][0].ToString();
            DL.DataSource = S.GetUnPublishedProductDT(OwnerName);
            DL.DataBind();
            DL2.DataSource = FillDt2();
            DL2.DataBind();
        }
    }

    protected void SearchBut_Click(object sender, ImageClickEventArgs e)
    {
        String OwnerName = ((DataTable)Session["User"]).Rows[0][0].ToString();
        if (TBSearch.Text.Equals(""))
            DL.DataSource = S.GetUserProductDT(OwnerName);
        else
            DL.DataSource = S.GetUserProductDTByName(OwnerName, TBSearch.Text);
        DL.DataBind();
    }

    protected void DL_Command(object source, DataListCommandEventArgs e)
    {
        string message, url, script;
        String OwnerName = ((DataTable)Session["User"]).Rows[0][0].ToString();
        int i = e.Item.ItemIndex;
        Image IMG = (Image)DL.Items[i].FindControl("IMG");
        FileUpload FUPic = (FileUpload)DL.Items[i].FindControl("FUPic");
        Label LBLName = (Label)DL.Items[i].FindControl("LBLName");
        Label LBLPrice = (Label)DL.Items[i].FindControl("LBLPrice");
        TextBox TBName = (TextBox)DL.Items[i].FindControl("TBName");
        TextBox TBDescription = (TextBox)DL.Items[i].FindControl("TBDescription");
        TextBox TBPrice = (TextBox)DL.Items[i].FindControl("TBPrice");
        Button BTNEdit = (Button)DL.Items[i].FindControl("BTNEdit");
        Button BTNPublish = (Button)DL.Items[i].FindControl("BTNPublish");
        dt = S.GetUserProductDTByName(OwnerName, LBLName.Text);
        if (e.CommandName == "Edit_Click")
        {
            FUPic.Visible = true;
            LBLName.Visible = false;
            LBLPrice.Visible = false;
            TBName.Visible = true;
            TBDescription.Visible = true;
            TBPrice.Visible = true;
            TBName.Attributes.Add("placeholder","Product Name");
            TBPrice.Attributes.Add("placeholder","Price");
            TBDescription.Attributes.Add("placeholder","Description");
            TBName.Text = dt.Rows[0][1].ToString();
            TBDescription.Text = dt.Rows[0][2].ToString();
            TBPrice.Text = dt.Rows[0][3].ToString();
            BTNEdit.Text = "Save";
            BTNEdit.CommandName = "Save_Click";
        }
        if (e.CommandName == "Save_Click")
        {
            FUPic.Visible = false;
            LBLName.Visible = true;
            LBLPrice.Visible = true;
            TBName.Visible = false;
            TBDescription.Visible = false;
            TBPrice.Visible = false;

            P.Code = dt.Rows[0][0].ToString();
            P.PName = TBName.Text;
            P.Description = TBDescription.Text;
            P.Price = Int32.Parse(TBPrice.Text);
            if (FUPic.HasFile)
            {
                P.Pic = FUPic.FileName;
                FUPic.SaveAs(Server.MapPath("ProductIMGS/") + P.Pic);
            }
            else
                P.Pic = dt.Rows[0][4].ToString();
            P.Owner = OwnerName;
            if (P.PName.Length == 0 || P.Description.Length == 0 || P.Price == 0)
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
            S.UpdateProduct(P);
            DL.DataSource = S.GetUserProductDT(OwnerName);
            DL.DataBind();
        }
        if (e.CommandName == "Publish_Click")
        {
            if (!S.IsRealStore(dt.Rows[0][0].ToString()))
            {
                message = "המוצר טרם מאוחסן. שלח אותו למחסן ולאחר מכן תוכל להתחיל בהגרלה.";
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
            G.Code = S.GetGiveawayDT().Rows.Count.ToString();
            G.ItemCode = dt.Rows[0][0].ToString();
            G.Status = false;
            G.IsEnded = false;
            G.StartDate = DateTime.Now.ToString("dd/MM/yyyy");
            G.Tickets = 0;
            G.Winner = "";
            S.CreateGiveaway(G,dt.Rows[0][0].ToString());
            DL.DataSource = S.GetUnPublishedProductDT(OwnerName);
            DL.DataBind();
        }
        if (e.CommandName == "Store_Click")
        {
            if (S.IsStore(dt.Rows[0][0].ToString()))
            {
                message = "המוצר כבר במחסן";
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
            P.Code = dt.Rows[0][0].ToString();
            P.PName = dt.Rows[0][1].ToString();
            P.Description = dt.Rows[0][2].ToString();
            P.Price = int.Parse(dt.Rows[0][3].ToString());
            P.Pic = dt.Rows[0][4].ToString();
            P.Owner = dt.Rows[0][5].ToString();
            S.Store(P);
            message = "המוצר נשלח לאחסון, ברגע שיגיע למחסן תוכל להתחיל בהגרלה.";
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
    }
    protected void DL2_Command(object source, DataListCommandEventArgs e)
    {
        int i = e.Item.ItemIndex;
        Label LBLCode = (Label)DL2.Items[i].FindControl("LBLCode");
        string VCode = S.GetVCodeByGiveaway(LBLCode.Text);
        if (e.CommandName == "Arrived_Click")
        {
            if (!S.IsArrived(VCode))
            {
                string message = "המוצר עוד לא נשלח ולכן עוד לא הגיע אליך. תודה";
                string url = "#";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                return;
            }
            if (S.IsAtUser(LBLCode.Text) == true)
            {
                string message = "המוצר כבר אצלך. תודה";
                string url = "#";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                return;
            }
            S.UpdateVehicleCap2(VCode);
            S.AcceptArrived(S.GetItemCodeByGiveawayCode(LBLCode.Text));
        }
    }
   private DataTable FillDt2()
    {
        string Username = ((DataTable)Session["User"]).Rows[0][0].ToString();
        DataTable dt1 = new DataTable();
        DataTable dt2 = S.GetGiveawayDT();
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            if (dt2.Rows[i][6].Equals(Username) && S.IsAtUser(dt2.Rows[i][1].ToString()) == false)
                dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
        }
        return dt1;
    }
}