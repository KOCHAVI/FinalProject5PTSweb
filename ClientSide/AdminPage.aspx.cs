using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminPage : System.Web.UI.Page
{
    private DataTable dt = null;
    private DataTable dt1 = null;
    private DataTable dt2 = null;
    private localhost.Service S = new localhost.Service();
    private string GetDb_Name_Path()
    {
        return Server.MapPath("App_Data/DB.mdb");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        if (!Page.IsPostBack)
        {
            TBSearch.Attributes.Add("placeholder", "Search User");
            TBSearch1.Attributes.Add("placeholder", "Search Giveaway");
            GV.DataSource = S.GetDT();
            GV.DataBind();
            dt = FillDt();
            dt1 = FillDt2();
            DL2.DataSource = dt;
            DL2.DataBind();
            DL3.DataSource = dt1;
            DL3.DataBind();
            LBLTEXT.Visible = false;
            if (DL2.Items.Count == 0)
                LBLTEXT2.Visible = false;
            else
                LBLTEXT2.Visible = true;
            DL4.DataSource = FillDt3();
            DL4.DataBind();
            DateTime Now = DateTime.Now;
            for (int i = 1; i < 31; i++)
            {
                DDLday.Items.Add(i.ToString());
            }
            for (int i = 1; i < 13; i++)
            {
                DDLmonth.Items.Add(i.ToString());
            }
            for (int i = 2000; i < 2023; i++)
            {
                DDLyear.Items.Add(i.ToString());
            }
        }
    }

    protected void SearchBut_Click(object sender, ImageClickEventArgs e)
    {
        if (TBSearch.Text.Equals(""))
        {
            GV.DataSource = S.GetDT();
            LBLTEXT.Visible = false;
            DL.Visible = false;
        }
        else
        {
            GV.DataSource = S.GetDTByUsername(TBSearch.Text);
            DL.DataSource = S.GetUserProductDT(TBSearch.Text);
            LBLTEXT.Visible = true;
            DL.Visible = true;
        }
        GV.DataBind();
        DL.DataBind();
    }
    protected void SearchBut2_Click(object sender, ImageClickEventArgs e)
    {
        if (TBSearch1.Text.Equals(""))
            DL3.DataSource = FillDt2();
        else
        {
            int i1;
            DataTable dt1 = new DataTable();
            DataTable dt2 = S.GetGiveawayDT();
            dt1.Columns.Add("Price2", typeof(string));
            dt1.Columns.Add("Winner", typeof(string));
            dt1.Columns.Add("StartDate", typeof(string));
            dt1.Columns.Add("GStatus", typeof(string));
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                i1 = dt1.Rows.Count;
                if (S.GetProductDTByCode(dt2.Rows[i][1].ToString()).Rows[0][1].Equals(TBSearch1.Text))
                {
                    dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
                    dt1.Rows[i1]["StartDate"] = dt2.Rows[i][4];
                    dt1.Rows[i1]["Status"] = dt2.Rows[i][2];
                    dt1.Rows[i1]["Price2"] = dt2.Rows[i][5].ToString() + "/" + dt1.Rows[i1]["Price"].ToString();
                    if (dt2.Rows[i][6].Equals(""))
                        dt1.Rows[i1]["Winner"] = "Giveaway Is Not Over Yet!";
                    else
                        dt1.Rows[i1]["Winner"] = dt2.Rows[i][6];
                    if (bool.Parse(dt2.Rows[i][2].ToString()) == true && bool.Parse(dt2.Rows[i][3].ToString()) == false)
                        dt1.Rows[i1]["Gstatus"] = "🟢";
                    else if (bool.Parse(dt2.Rows[i][2].ToString()) == false && bool.Parse(dt2.Rows[i][3].ToString()) == false)
                        dt1.Rows[i1]["Gstatus"] = "🟠";
                    else
                        dt1.Rows[i1]["Gstatus"] = "🔴";
                }
            }
            DL3.DataSource = dt1;
        }
        DL3.DataBind();
    }
    protected void DL2_Command(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Accept_Click")
        {
            int i = e.Item.ItemIndex;
            Label LBLCode = (Label)DL2.Items[i].FindControl("LBLCode");
            S.UpdateGiveaway(LBLCode.Text);
            dt = FillDt();
            DL2.DataSource = dt;
            DL2.DataBind();
            DL3.DataSource = FillDt2();
            DL3.DataBind();
        }
    }
    //Fill the Products DataTable!
    private DataTable FillDt()
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = null;
        dt2 = S.GetUnabledGiveawayDT();
        for (int i = 0; i < dt2.Rows.Count; i++)
            dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
        return dt1;
    }
    //Fill the Giveaways DataTable!
    private DataTable FillDt2()
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = S.GetGiveawayDT();
        dt1.Columns.Add("Price2", typeof(string));
        dt1.Columns.Add("Winner", typeof(string));
        dt1.Columns.Add("StartDate", typeof(string));
        dt1.Columns.Add("GStatus", typeof(string));
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            dt1.Merge(S.GetProductDTByCode(dt2.Rows[i][1].ToString()));
            dt1.Rows[i]["StartDate"] = dt2.Rows[i][4];
            dt1.Rows[i]["Status"] = dt2.Rows[i][2];
            dt1.Rows[i]["Price2"] = dt2.Rows[i][5].ToString() + "/" + dt1.Rows[i]["Price"].ToString();
            if (dt2.Rows[i][6].Equals(""))
                dt1.Rows[i]["Winner"] = "Giveaway Is Not Over Yet!";
            else
                dt1.Rows[i]["Winner"] = dt2.Rows[i][6];
            if (bool.Parse(dt2.Rows[i][2].ToString()) == true && bool.Parse(dt2.Rows[i][3].ToString()) == false)
                dt1.Rows[i]["Gstatus"] = "🟢";
            else if (bool.Parse(dt2.Rows[i][2].ToString()) == false && bool.Parse(dt2.Rows[i][3].ToString()) == false)
                dt1.Rows[i]["Gstatus"] = "🟠";
            else
                dt1.Rows[i]["Gstatus"] = "🔴";
        }
        return dt1;
    }
    private DataTable FillDt3()
    {
        DataTable dt = S.GetVehicleDt();
        dt.Columns.Add("VStatus", typeof(string));
        dt.Columns.Add("Content", typeof(string));
        for (int i = 0; i < S.GetVehicleDt().Rows.Count; i++)
        {
            if (bool.Parse(dt.Rows[i]["Status"].ToString()) == false)
            {
                dt.Rows[i]["VStatus"] = "🔴";
            }
            else
            {
                dt.Rows[i]["VStatus"] = "🟢";
            }
            for (int J = 0; J < S.GetDeliveryByVehicleCode(dt.Rows[i]["VCode"].ToString()).Rows.Count; J++)
            {
                dt.Rows[i]["Content"] += " " + S.GetProductDTByCode(S.GetDeliveryByVehicleCode(dt.Rows[i]["VCode"].ToString()).Rows[J][0].ToString()).Rows[0][1].ToString();
            }
        }
        return dt;
    }
    private DataTable FillDt4(string date)
    {
        DataTable dt = new DataTable();
        DataTable dt1 = S.GetStorageByDate(date);
        dt.Columns.Add("VStatus", typeof(string));
        dt.Columns.Add("Content", typeof(string));
        dt.Columns.Add("VCode", typeof(string));
        dt.Columns.Add("VName", typeof(string));
        dt.Columns.Add("VType", typeof(string));
        dt.Columns.Add("Capacity", typeof(string));
        for (int i = 0; i < dt1.Rows.Count; i++)
        {    
            dt.Merge(S.GetProductDTByCode(dt1.Rows[i][0].ToString()));
            dt.Rows[i]["VStatus"] = "";
            dt.Rows[i]["Content"] = dt1.Rows[i][2].ToString();
            dt.Rows[i]["VCode"] = S.GetVehicleDTByItemCode(dt1.Rows[i][0].ToString()).Rows[0][0].ToString();
            dt.Rows[i]["VType"] = "";
            dt.Rows[i]["VName"] = dt1.Rows[i][1].ToString();
            dt.Rows[i]["Capacity"] = dt1.Rows[i][4].ToString();
        }
        return dt;
    }
    protected void CHECKBX_CheckedChanged(object sender, EventArgs e)
    {
        if (!CHECKBX.Checked)
        {
            DL4.DataSource = FillDt3();
        }
        else
        {
            DL4.DataSource = FillDt4(DDLday.SelectedValue + "/" + DDLmonth.SelectedValue + "/" + DDLyear.SelectedValue);          
        }
        DL4.DataBind();
    }
    protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CHECKBX.Checked)
        {
            DL4.DataSource = FillDt4(DDLday.SelectedValue + "/" + DDLmonth.SelectedValue + "/" + DDLyear.SelectedValue);
            DL4.DataBind();
        }
    }
}