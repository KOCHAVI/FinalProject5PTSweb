using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Home : System.Web.UI.Page
{
    private DataTable dt = null;
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["User"] == null && Session["Admin"] == null && Session["StorageManager"] == null)
            {
                HL2.Text = "Register | ";
                HL2.NavigateUrl = "Register.aspx";
                HL3.Text = "Login";
                HL3.NavigateUrl = "Login.aspx";
                HL4.Text = "";
                HL4.NavigateUrl = "";
            }
            else if (Session["Admin"] != null)
            {
                HL2.Text = "Admin Page | ";
                HL2.NavigateUrl = "AdminPage.aspx";
                HL3.Text = "Create Car | ";
                HL3.NavigateUrl = "CreateVehicle.aspx";
                HL4.Text = "Logout";
                HL4.NavigateUrl = "Logout.aspx";
            }
            else if(Session["StorageManager"] != null)
            {
                HL2.Text = "Storage Page | ";
                HL2.NavigateUrl = "StoragePage.aspx";
                HL3.Text = "Logout";
                HL3.NavigateUrl = "Logout.aspx";
                HL4.Text = "";
                HL4.NavigateUrl = "";
            }
            else
            {
                HL2.Text = "Profile | ";
                HL2.NavigateUrl = "ProfileSettings.aspx";
                HL3.Text = "My Products | ";
                HL3.NavigateUrl = "MyProducts.aspx";
                HL4.Text = "Logout";
                HL4.NavigateUrl = "Logout.aspx";
            }
            TBSearch.Attributes.Add("placeholder", "Search Giveaways");
            dt = FillDt();
            DL.DataSource = dt;
            DL.DataBind();
        }
    }
    protected void SearchBut_Click(object sender, ImageClickEventArgs e)
    {
        if (TBSearch.Text.Equals(""))
            DL.DataSource = FillDt();
        else
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = S.GetAbledGiveawayDT();
            dt1.Columns.Add("Tickets", typeof(int));
            int index;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                index = dt1.Rows.Count;
                if (S.GetProductDTByCode(dt2.Rows[i][1].ToString()).Rows[0][1].ToString().Equals(TBSearch.Text))
                {
                    dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
                    dt1.Rows[index][0] = dt2.Rows[i][5];
                }
            }
            DL.DataSource = dt1;
        }
        DL.DataBind();
    }
    protected void DL_Command(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Buy_Click")
        {
            int i = e.Item.ItemIndex;
            TextBox TBCoins = (TextBox)DL.Items[i].FindControl("TBCoins");
            if (Session["User"] == null && Session["Admin"] == null && Session["StorageManager"] == null)
            {
                string message = "עליך להתחבר על מנת להשתמש באופציה זו";
                string url = "Login.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                TBCoins.Text = "";
                return;
            }        
            Label LBLTickets = (Label)DL.Items[i].FindControl("LBLTickets");
            if (Session["Admin"] != null || Session["StorageManager"] != null)
                return;
            //Check numbers....
            if (int.Parse(((DataTable)Session["User"]).Rows[0][5].ToString()) < int.Parse(TBCoins.Text))
            {
                string message = "אין לך מספיק מטבעות על מנת לבצע פעולה זו";
                string url = "BuyCoins.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                TBCoins.Text = "";
                return;
            }
            string[] Tickets = LBLTickets.Text.Split('/');
            if (int.Parse(TBCoins.Text) > int.Parse(Tickets[1]) - int.Parse(Tickets[0]))
            {
                string message = "לא נשארו מספיק כניסות על מנת לבצע פעולה זו, הזן פחות כניסות";
                string url = "#";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                TBCoins.Text = "";
                return;
            }
            dt = (DataTable)Session["User"];
            Label LBLCode = (Label)DL.Items[i].FindControl("LBLCode");
            if (int.Parse(TBCoins.Text) == (int.Parse(Tickets[1]) - int.Parse(Tickets[0])))
            {
                if (S.GetVehicle() == null)
                {
                    string message = "אין מכוניות זמינות כרגע כדי לבצע משלוח ולכן לא נוכל לתת לך לסיים את ההגרלה. תודה";
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
                string address = dt.Rows[0][9].ToString() + "," + dt.Rows[0][10].ToString() + "-" + dt.Rows[0][7].ToString() + " " + dt.Rows[0][8].ToString();
                string VCode = S.GetVehicle();
                S.Deliver(LBLCode.Text, VCode, address);
                S.CloseGiveaway(LBLCode.Text);
                S.SetWinner(LBLCode.Text);
                S.UpdateVehicleCap(VCode);
                S.UpdateStorageExit(S.GetItemCodeByGiveawayCode(LBLCode.Text));
            }
            S.BuyTickets(LBLCode.Text, int.Parse(S.GetGiveawayDTByItemCode(LBLCode.Text).Rows[0][5].ToString()), int.Parse(dt.Rows[0][5].ToString()), dt.Rows[0][0].ToString(), int.Parse(TBCoins.Text));
            S.AddJoiner(dt.Rows[0][0].ToString(), S.GetGiveawayDTByItemCode(LBLCode.Text).Rows[0][0].ToString(), int.Parse(TBCoins.Text));
            TBCoins.Text = "";
            Response.Redirect("Home.aspx");
        }
    }
    private DataTable FillDt()
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = null;
        dt2 = S.GetAbledGiveawayDT();
        dt1.Columns.Add("Tickets", typeof(int));
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
            dt1.Rows[i]["Tickets"] = dt2.Rows[i][5];
        }
        return dt1;
    }
}