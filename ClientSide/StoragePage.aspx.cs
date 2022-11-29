using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StoragePage : System.Web.UI.Page
{
    private DataTable dt = null;
    private localhost.Service S = new localhost.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StorageManager"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        if (!Page.IsPostBack)
        {
            dt = FillDt();
            DL.DataSource = dt;
            DL.DataBind();
        }
    }
    protected void DL_Command(object source, DataListCommandEventArgs e)
    {
        int i = e.Item.ItemIndex;
        Label TXTCode = (Label)DL.Items[i].FindControl("LBLCode");
        if (e.CommandName == "Accept_Click")
        {
            S.AcceptStore(TXTCode.Text);
            DL.DataSource = FillDt();
            DL.DataBind();
        }
    }
    private DataTable FillDt()
    {
        DataTable dt1 = new DataTable();
        dt1 = S.GetUnstoredProductsDT();
        dt1.Columns.Add("Pic", typeof(string));
        for (int i = 0; i < dt1.Rows.Count; i++)
            dt1.Rows[i]["Pic"] = S.GetProductDTByCode(dt1.Rows[i][0].ToString()).Rows[0][4];
        return dt1;
    }
}