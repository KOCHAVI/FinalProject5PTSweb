using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public class Connect
{
    private static string my_path;

    private static OleDbConnection my_con;
    //------------------------------------------------------------------

	public static void Connect_me(string path)
	{
        my_path = @"Provider=microsoft.jet.oledb.4.0;Data Source=" + path;

        my_con = new OleDbConnection(my_path);
	}
//------------------------------------------------------------------
    public static DataTable DowonloadData(string my_sql, string tableName,string my_path)
    {
        Connect_me(my_path);


        DataSet ds = new DataSet();

        OleDbCommand cmd = new OleDbCommand(my_sql, my_con);


        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        da.Fill(ds, tableName);

        DataTable dt = ds.Tables[0];

        return (dt);
    }
    //------------------------------------------------------------------
    public static void TakeAction(OleDbCommand cmd, string path)
    {
        Connect_me(path);

        cmd.Connection = my_con;

        my_con.Open();

        cmd.ExecuteNonQuery();

        my_con.Close();
    }
    //------------------------------------------------------------------
    public static int ReturnValue(string sql)
    {
        OleDbCommand cmd = new OleDbCommand(sql, my_con);

        my_con.Open();

        int result =(int) cmd.ExecuteScalar();

        my_con.Close();

        return (result);
    }
   
}
