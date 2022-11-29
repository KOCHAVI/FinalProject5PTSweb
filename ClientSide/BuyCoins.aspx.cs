using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BuyCoins : System.Web.UI.Page
{
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null || (Session["Admin"] == null && Session["User"] == null))
            Response.Redirect("Home.aspx");
        if (!Page.IsPostBack)
        {
            for (int i = 1; i < 13; i++)
            {
                DDLM2.Items.Add(i.ToString());
            }
            for (int i = 22; i < 31; i++)
            {
                DDLY2.Items.Add(i.ToString());
            }
            DataTable dt = (DataTable)Session["User"];
            LBLU2.Text = dt.Rows[0][0].ToString();
            DL.DataSource = S.GetCreditCards(dt.Rows[0][0].ToString());
            DL.DataBind();
            TBCN2.Attributes.Add("placeholder","Card Number");
            TBCVV2.Attributes.Add("placeholder","CVV");
        }
    }

    protected void BTNBuy_Click(object sender, EventArgs e)
    {
        if (int.Parse(TBCoins.Text) <= 0)
        {
            string message = "לא ניתן לרכוש פחות מ-0 מטבעות";
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
        DataTable dt = (DataTable)Session["User"];
        if (S.GetCreditCards(dt.Rows[0][0].ToString()).Rows.Count==0)
        {
            string message = "ראשית, הזן פרטי אשראי";
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
        S.BuyCoins(dt.Rows[0][0].ToString(), int.Parse(dt.Rows[0][5].ToString()) + int.Parse(TBCoins.Text));
        Session["User"] = S.GetDTByUsername(dt.Rows[0][0].ToString());
        Response.Redirect("BuyCoins.aspx");
    }
    protected void DL_Command(object source, DataListCommandEventArgs e)
    {
        int i = e.Item.ItemIndex;
        Label LBLCardNumber = (Label)DL.Items[i].FindControl("LBLCardNumber");
        TextBox TBCN = (TextBox)DL.Items[i].FindControl("TBCN");
        Label LBLExpDate = (Label)DL.Items[i].FindControl("LBLExpDate");
        DropDownList DDLM = (DropDownList)DL.Items[i].FindControl("DDLM");
        Label LBLS = (Label)DL.Items[i].FindControl("LBLS");
        DropDownList DDLY = (DropDownList)DL.Items[i].FindControl("DDLY");
        Label LBLCVV = (Label)DL.Items[i].FindControl("LBLCVV");
        TextBox TBCVV = (TextBox)DL.Items[i].FindControl("TBCVV");
        Button BTNBack = (Button)DL.Items[i].FindControl("BTNBack");
        Button BTNEdit = (Button)DL.Items[i].FindControl("BTNEdit");
        DataTable dt = (DataTable)Session["User"];
        string month = LBLExpDate.Text.ToString().Split('/')[0];
        string year = LBLExpDate.Text.ToString().Split('/')[1];
        if (e.CommandName == "Edit_Click")
        {
            TBCN.Text = TrimMakaf(LBLCardNumber.Text);
            TBCVV.Text = TrimMakaf(LBLCVV.Text);
            for (int j = 1; j < 13; j++)
            {
                DDLM.Items.Add(j.ToString());
            }
            for (int j = 22; j < 31; j++)
            {
                DDLY.Items.Add(j.ToString());
            }
            DDLM.SelectedValue = month;
            DDLY.SelectedValue = year;
            LBLCardNumber.Visible = false;
            TBCN.Visible = true;
            LBLExpDate.Visible = false;
            DDLM.Visible = true;
            LBLS.Visible = true;
            DDLY.Visible = true;
            LBLCVV.Visible = false;
            TBCVV.Visible = true;
            BTNEdit.Text = "Save";
            BTNEdit.CommandName = "Save_Click";
            BTNBack.Visible = true;
        }
        if (e.CommandName == "Save_Click")
        {
            if (TBCN.Text.Length != 16 || TBCVV.Text.Length != 3)
            {
                string message = "פרטי אשראי אינם תקינים.";
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
            string EXPD = DDLM.SelectedValue + "/" + DDLY.SelectedValue;
            S.UpdatePaymentInfo(dt.Rows[0][0].ToString(), GetCardNumberWithMAKAFS(TBCN.Text), EXPD, TBCVV.Text);
            LBLCardNumber.Visible = true;
            TBCN.Visible = false;
            LBLExpDate.Visible = true;
            DDLM.Visible = false;
            LBLS.Visible = false;
            DDLY.Visible = false;
            LBLCVV.Visible = true;
            TBCVV.Visible = false;
            BTNEdit.Text = "Edit";
            BTNEdit.CommandName = "Edit_Click";
            BTNBack.Visible = false;
            DDLM.Items.Clear();
            DDLY.Items.Clear();
            DL.DataSource = S.GetCreditCards(dt.Rows[0][0].ToString());
            DL.DataBind();
        }
        if (e.CommandName == "Back_Click")
        {
            DDLM.Items.Clear();
            DDLY.Items.Clear();
            LBLCardNumber.Visible = true;
            TBCN.Visible = false;
            LBLExpDate.Visible = true;
            DDLM.Visible = false;
            LBLS.Visible = false;
            DDLY.Visible = false;
            LBLCVV.Visible = true;
            TBCVV.Visible = false;
            BTNEdit.Text = "Edit";
            BTNEdit.CommandName = "Edit_Click";
            BTNBack.Visible = false;
        }
    }
    protected void BTNSave_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["User"];
        if (TBCN2.Text.Length !=16 || TBCVV2.Text.Length!=3)
        {
            string message = "פרטי אשראי אינם תקינים.";
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
        string EXPD = DDLM2.SelectedValue + "/" + DDLY2.SelectedValue;
        S.AddPaymentInfo(dt.Rows[0][0].ToString(), GetCardNumberWithMAKAFS(TBCN2.Text), EXPD, TBCVV2.Text);
        DL.DataSource = S.GetCreditCards(dt.Rows[0][0].ToString());
            DL.DataBind();
    }
    private string GetCardNumberWithMAKAFS(string CN)
    {
        string CN1 = "";
        for (int i = 0; i < 16; i+=4)
        {
            CN1 += CN[i];
            CN1 += CN[i+1];
            CN1 += CN[i+2];
            CN1 += CN[i+3];
            if (i!=12)
            {
                CN1 += "-";
            }
        }
        return CN1;
    }
    private string TrimMakaf(string CN)
    {
        string cn2 = "";
        for (int i = 0; i < CN.Length; i++)
        {
            if (CN[i] != '-')
            {
                cn2 += CN[i];
            }
        }
        return cn2;
    }
}