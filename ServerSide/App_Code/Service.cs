using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service()
    {
    }

    [WebMethod]
    private string Get_DB_Path()
    {
        return Server.MapPath("App_Data/DB.mdb");
    }
    [WebMethod]
    public void Register(User user)
    {
        string sql = "INSERT INTO [User] values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = user.Username;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = user.Pass;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = user.Firstname;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = user.Lastname;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = user.Phone;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.Integer));
        cmd.Parameters["@p6"].Value = user.Coins;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
        cmd.Parameters["@p7"].Value = user.Email;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));
        cmd.Parameters["@p8"].Value = user.Address;

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));
        cmd.Parameters["@p9"].Value = user.NumAddress;

        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));
        cmd.Parameters["@p10"].Value = user.City;

        cmd.Parameters.Add(new OleDbParameter("@p11", OleDbType.VarChar));
        cmd.Parameters["@p11"].Value = user.Country;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    private DataTable dt = null;
    [WebMethod]
    public DataTable Login(string Username, string Pass)
    {
        string sql = "Select * FROM [User] Where [Username]='" + Username + "' And [Pass]='" + Pass + "'";

        dt = Connect.DowonloadData(sql, "User", Get_DB_Path());

        if (dt.Rows.Count > 0)
            return dt;
        return null;
    }
    [WebMethod]
    public DataTable LoginAdmin(string Username, string Pass)
    {
        string sql = "Select * FROM [Admin] Where [Username]='" + Username + "' And [Pass]='" + Pass + "'";

        dt = Connect.DowonloadData(sql, "Admin", Get_DB_Path());

        if (dt.Rows.Count > 0)
            return dt;
        return null;
    }
    [WebMethod]
    public void Update(User user)
    {
        string sql = "UPDATE [User] Set [Pass]=@p1,[Firstname]=@p2,[Lastname]=@p3,[Phone]=@p4,[Email]=@p5,[Address]=@p6,[NumAddress]=@p7,[City]=@p8,[Country]=@p9 WHERE [Username]=@p10";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = user.Pass;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = user.Firstname;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = user.Lastname;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = user.Phone;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = user.Email;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
        cmd.Parameters["@p6"].Value = user.Address;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
        cmd.Parameters["@p7"].Value = user.NumAddress;

        cmd.Parameters.Add(new OleDbParameter("@p8", OleDbType.VarChar));
        cmd.Parameters["@p8"].Value = user.City;

        cmd.Parameters.Add(new OleDbParameter("@p9", OleDbType.VarChar));
        cmd.Parameters["@p9"].Value = user.Country;

        cmd.Parameters.Add(new OleDbParameter("@p10", OleDbType.VarChar));
        cmd.Parameters["@p10"].Value = user.Username;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public bool IsUsernameTaken(string U)
    {
        string sql = "SELECT * FROM [User] WHERE [Username]= '" + U + "'";

        dt = Connect.DowonloadData(sql, "User", Get_DB_Path());

        if (dt.Rows.Count != 0)
            return true;

        sql = "SELECT * FROM [Admin] WHERE [Username]= '" + U + "'";

        dt = Connect.DowonloadData(sql, "Admin", Get_DB_Path());

        if (dt.Rows.Count != 0)
            return true;
        return false;
    }
    [WebMethod]
    public DataTable GetDT()
    {
        string sql = "SELECT * FROM [User]";

        dt = Connect.DowonloadData(sql, "User", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetDTByUsername(string U)
    {
        string sql = "SELECT * FROM [User] where [Username]= '" + U + "'";

        dt = Connect.DowonloadData(sql, "User", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public void CreateProduct(Product product)
    {
        string sql = "INSERT INTO [Product] values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = product.Code;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = product.PName;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = product.Description;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Integer));
        cmd.Parameters["@p4"].Value = product.Price;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = product.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
        cmd.Parameters["@p6"].Value = product.Owner;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.Boolean));
        cmd.Parameters["@p7"].Value = product.Status;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetProductDT()
    {
        string sql = "SELECT * FROM [Product]";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetUserProductDT(string username)
    {
        string sql = "SELECT * FROM [Product] WHERE [Owner]= '" + username + "'";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetUserProductDTByName(string username, string name)
    {
        string sql = "SELECT * FROM [Product] WHERE [Pname]= '" + name + "' AND [Owner]= '" + username + "'";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetProductDTByName(string name)
    {
        string sql = "SELECT * FROM [Product] WHERE [Pname]= '" + name + "'";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetUnPublishedProductDT(string username)
    {
        string sql = "SELECT * FROM [Product] WHERE [Status]= " + false + " AND [Owner]= '" + username + "'";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public void UpdateProduct(Product product)
    {
        string sql = "UPDATE [Product] SET [Pname]=@p1,[Description]=@p2,[Price]=@p3,[Pic]=@p4 Where [Code]=@p5";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = product.PName;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = product.Description;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = product.Price;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = product.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = product.Code;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void CreateGiveaway(Giveaway giveaway, string Code)
    {
        string sql = "INSERT INTO [Giveaway] values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = giveaway.Code;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = giveaway.ItemCode;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.Boolean));
        cmd.Parameters["@p3"].Value = giveaway.Status;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Boolean));
        cmd.Parameters["@p4"].Value = giveaway.IsEnded;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = giveaway.StartDate;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.Integer));
        cmd.Parameters["@p6"].Value = giveaway.Tickets;

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.VarChar));
        cmd.Parameters["@p7"].Value = giveaway.Winner;

        Connect.TakeAction(cmd, Get_DB_Path());

        sql = "UPDATE [Product] Set [Status]= " + true + " Where [Code]= '" + Code + "'";

        cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void UpdateGiveaway(string ItemCode)
    {
        string sql = "UPDATE [Giveaway] SET [Status]=" + true + " WHERE [ItemCode]= '" + ItemCode + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void CloseGiveaway(string ItemCode)
    {
        string sql = "UPDATE [Giveaway] SET [IsEnded]=" + true + " WHERE [ItemCode]= '" + ItemCode + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void BuyTickets(string ItemCode, int Tickets, int Coins, string Username, int Bet)
    {
        string sql = "UPDATE [Giveaway] SET [Tickets]='" + (Tickets + Bet) + "' WHERE [ItemCode]= '" + ItemCode + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());

        sql = "UPDATE [User] SET [Coins]='" + (Coins - Bet) + "' WHERE [Username]= '" + Username + "'";

        cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetGiveawayDT()
    {
        string sql = "SELECT * FROM [Giveaway]";

        dt = Connect.DowonloadData(sql, "Giveaway", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetGiveawayDTByItemCode(string ItemCode)
    {
        string sql = "SELECT * FROM [Giveaway] WHERE [ItemCode]= '" + ItemCode + "'";

        dt = Connect.DowonloadData(sql, "Giveaway", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetUnabledGiveawayDT()
    {
        string sql = "SELECT * FROM [Giveaway] WHERE [Status]= " + false + "";

        dt = Connect.DowonloadData(sql, "Giveaway", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetAbledGiveawayDT()
    {
        string sql = "SELECT * FROM [Giveaway] WHERE [Status]= " + true + " AND [IsEnded]= " + false + "";

        dt = Connect.DowonloadData(sql, "Giveaway", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetProductDTByCode(string Code)
    {
        string sql = "SELECT * FROM [Product] WHERE [Code]= '" + Code + "'";

        dt = Connect.DowonloadData(sql, "Product", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public void BuyCoins(string Username, int coins)
    {
        string sql = "Update [User] Set [Coins]= '" + coins + "' Where [Username]= '" + Username + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void AddJoiner(string Username, string GiveawayCode, int Tickets)
    {
        string sql = "SELECT * FROM [Joiners] Where [Username]= '" + Username + "' AND [GiveawayCode]= '" + GiveawayCode + "'";
        int T;
        if (Connect.DowonloadData(sql, "Joiners", Get_DB_Path()).Rows.Count != 0)
        {
            T = int.Parse(Connect.DowonloadData(sql, "Joiners", Get_DB_Path()).Rows[0][2].ToString()) + Tickets;
            sql = "UPDATE [Joiners] SET [Tickets]= '" + T + "' Where [Username]= '" + Username + "' AND [GiveawayCode]= '" + GiveawayCode + "'";
        }
        else
            sql = "INSERT INTO [Joiners] Values(@p1,@p2,@p3)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = Username;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = GiveawayCode;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.Integer));
        cmd.Parameters["@p3"].Value = Tickets;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetGiveawayDTByGiveawayCode(string Code)
    {
        string sql = "SELECT * FROM [Giveaway] WHERE [Code] = '" + Code + "'";

        dt = Connect.DowonloadData(sql, "Giveaway", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public DataTable GetJoinersDTByGiveawayCode(string Code)
    {
        string sql = "SELECT * FROM [Joiners] WHERE [GiveawayCode]= '" + Code + "'";

        dt = Connect.DowonloadData(sql, "Joiners", Get_DB_Path());

        return dt;
    }
    private DataTable dt1 = null;
    [WebMethod]
    public void SetWinner(string ItemCode)
    {
        string Code = GetGiveawayDTByItemCode(ItemCode).Rows[0][0].ToString();

        dt1 = GetJoinersDTByGiveawayCode(Code);

        int Sum = int.Parse(GetGiveawayDTByGiveawayCode(Code).Rows[0][5].ToString());

        Random rnd = new Random();

        int num = rnd.Next(0, Sum + 1);

        int Row = 0;

        string Tickets;

        while (num > 0)
        {
            Tickets = dt1.Rows[Row][2].ToString();
            num -= int.Parse(Tickets);
            if (num > 0)
                Row++;
        }

        string sql = "UPDATE [Giveaway] SET [Winner]= '" + dt1.Rows[Row][0].ToString() + "' WHERE [Code]= '" + Code + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public bool IsStore(string Code)
    {
        string sql = "SELECT * FROM [Storage] Where [ItemCode]= '" + Code + "'";

        dt = Connect.DowonloadData(sql, "Storage", Get_DB_Path());

        if (dt.Rows.Count != 0)
            return true;
        return false;
    }
    [WebMethod]
    public bool IsRealStore(string Code)
    {
        string sql = "SELECT * FROM [Storage] Where [ItemCode]= '" + Code + "' AND [Status]= " + true + "";

        dt = Connect.DowonloadData(sql, "Storage", Get_DB_Path());

        if (dt.Rows.Count != 0)
            return true;
        return false;
    }
    [WebMethod]
    public void Store(Product product)
    {
        string sql = "INSERT INTO [Storage] values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = product.Code;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = product.PName;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = product.Description;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Integer));
        cmd.Parameters["@p4"].Value = product.Price;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = DateTime.Now.ToString("dd/MM/yyyy");

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.VarChar));
        cmd.Parameters["@p6"].Value = "";

        cmd.Parameters.Add(new OleDbParameter("@p7", OleDbType.Boolean));
        cmd.Parameters["@p7"].Value = false;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetUnstoredProductsDT()
    {
        string sql = "SELECT * FROM [Storage] WHERE [Status]= " + false + "";

        dt = Connect.DowonloadData(sql, "Storage", Get_DB_Path());

        return dt;
    }
    [WebMethod]
    public void AcceptStore(string code)
    {
        string sql = "UPDATE [Storage] SET [Status]= " + true + " WHERE [ItemCode]= '" + code + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public bool IsOnDelivery(string code)
    {
        string sql = "SELECT * FROM [Delivery] WHERE [ItemCode]= '" + code + "'";

        dt = Connect.DowonloadData(sql, "Delivery", Get_DB_Path());

        if (dt.Rows.Count == 0)
            return false;
        if (bool.Parse(dt.Rows[0][3].ToString()) == true)
            return false;
        return true;
    }
    [WebMethod]
    public void Deliver(string ICode, string VCode, string Address)
    {
        string sql = "INSERT INTO [Delivery] values(@p1,@p2,@p3,@p4)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = ICode;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = VCode;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = Address;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.Boolean));
        cmd.Parameters["@p4"].Value = false;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void CreateVehicle(Vehicle vehicle)
    {
        string sql = "INSERT INTO [Vehicle] values(@p1,@p2,@p3,@p4,@p5,@p6)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = vehicle.Vcode;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = vehicle.Vtype;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = vehicle.Vname;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = vehicle.Capacity;

        cmd.Parameters.Add(new OleDbParameter("@p5", OleDbType.VarChar));
        cmd.Parameters["@p5"].Value = vehicle.Pic;

        cmd.Parameters.Add(new OleDbParameter("@p6", OleDbType.Boolean));
        cmd.Parameters["@p6"].Value = false;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public string GetVehicle()
    {
        string sql = "SELECT * FROM [Vehicle] Where [Status]= " + false + "";

        dt = Connect.DowonloadData(sql, "Vehicle", Get_DB_Path());
        if (dt.Rows.Count == 0)
            return null;
        string[] capacity = dt.Rows[0][3].ToString().Split('/');
        int min = int.Parse(capacity[1]) - int.Parse(capacity[0]);
        string code = dt.Rows[0][0].ToString();
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            capacity = dt.Rows[i][3].ToString().Split('/');
            if (int.Parse(capacity[1]) - int.Parse(capacity[0]) < min)
            {
                min = int.Parse(capacity[1]) - int.Parse(capacity[0]);
                code = dt.Rows[i][0].ToString();
            }
        }
        return code;
    }
    [WebMethod]
    public int GetVehicles()
    {
        string sql = "SELECT * FROM [Vehicle]";

        return Connect.DowonloadData(sql, "Vehicle", Get_DB_Path()).Rows.Count;
    }
    [WebMethod]
    public void AcceptArrived(string code)
    {
        string sql = "UPDATE [Delivery] SET [Status]= " + true + " WHERE [ItemCode]= '" + code + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void UpdateVehicle(string code, bool flag)
    {
        string sql = "UPDATE [Vehicle] SET [Status]= " + flag + " WHERE [VCode]= '" + code + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void UpdateVehicleCap(string code)
    {
        string sql = "SELECT * FROM [Vehicle] Where [VCode]= '" + code + "'";

        string[] x = Connect.DowonloadData(sql, "Vehicle", Get_DB_Path()).Rows[0][3].ToString().Split('/');

        OleDbCommand cmd;
        string capa = (int.Parse(x[0]) + 1) + "/" + x[1];
        if (int.Parse(x[1]) - int.Parse(x[0]) > 1)
        {
            sql = "UPDATE [Vehicle] SET [Capacity] = '" + capa + "'";

            cmd = new OleDbCommand(sql);

            Connect.TakeAction(cmd, Get_DB_Path());

            return;
        }
        sql = "UPDATE [Vehicle] SET [Capacity] = '" + capa + "' WHERE [VCode]= '" + code + "'";

        cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());

        UpdateVehicle(code, true);
    }
    [WebMethod]
    public void UpdateVehicleCap2(string code)
    {
        string sql = "SELECT * FROM [Vehicle] Where [VCode]= '" + code + "'";

        string[] x = Connect.DowonloadData(sql, "Vehicle", Get_DB_Path()).Rows[0][3].ToString().Split('/');

        OleDbCommand cmd;

        string capa = (int.Parse(x[0]) - 1) + "/" + x[1];

        if (int.Parse(x[0]) > 1)
        {
            sql = "UPDATE [Vehicle] SET [Capacity] = '" + capa + "' WHERE [VCode]= '" + code + "'";

            cmd = new OleDbCommand(sql);

            Connect.TakeAction(cmd, Get_DB_Path());

            return;
        }

        sql = "UPDATE [Vehicle] SET [Capacity] = '" + capa + "' WHERE [VCode]= '" + code + "'";

        cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());

        UpdateVehicle(code, false);
    }
    [WebMethod]
    public string GetVCodeByGiveaway(string ICode)
    {
        string sql = "SELECT * FROM [Delivery] Where [ItemCode]= '" + ICode + "'";

        return Connect.DowonloadData(sql, "Delivery", Get_DB_Path()).Rows[0][1].ToString();
    }
    [WebMethod]
    public bool IsArrived(string code)
    {
        string sql = "SELECT * FROM [Vehicle] Where [VCode]= '" + code + "'";

        return bool.Parse(Connect.DowonloadData(sql, "Vehicle", Get_DB_Path()).Rows[0][5].ToString());
    }
    [WebMethod]
    public bool IsAtUser(string code)
    {
        string sql = "SELECT * FROM [Delivery] Where [ItemCode]= '" + code + "'";

        bool Flag = bool.Parse(Connect.DowonloadData(sql, "Delivery", Get_DB_Path()).Rows[0][3].ToString());

        return Flag;
    }
    [WebMethod]
    public string GetItemCodeByGiveawayCode(string code)
    {
        string sql = "SELECT * FROM [Giveaway] Where [ItemCode]= '" + code + "'";

        return Connect.DowonloadData(sql, "Giveaway", Get_DB_Path()).Rows[0][1].ToString();
    }
    [WebMethod]
    public void AddPaymentInfo(string username,string cardnumber,string expdate,string cvv)
    {
        string sql = "INSERT INTO [CreditCard] values(@p1,@p2,@p3,@p4)";

        OleDbCommand cmd = new OleDbCommand(sql);

        cmd.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        cmd.Parameters["@p1"].Value = username;

        cmd.Parameters.Add(new OleDbParameter("@p2", OleDbType.VarChar));
        cmd.Parameters["@p2"].Value = cardnumber;

        cmd.Parameters.Add(new OleDbParameter("@p3", OleDbType.VarChar));
        cmd.Parameters["@p3"].Value = expdate;

        cmd.Parameters.Add(new OleDbParameter("@p4", OleDbType.VarChar));
        cmd.Parameters["@p4"].Value = cvv;

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public void UpdatePaymentInfo(string username, string cardnumber, string expdate, string cvv)
    {
        string sql = "UPDATE [CreditCard] SET [CardNumber]= '" + cardnumber + "', [ExpDate]= '" + expdate + "',[CVV]= '" + cvv + "' WHERE [Username]= '" + username + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetCreditCards(string username)
    {
        string sql = "SELECT * FROM [CreditCard] Where [Username]= '" + username + "'";

        return Connect.DowonloadData(sql, "CreditCard", Get_DB_Path());
    }
    [WebMethod]
	public void UpdateStorageExit(string code)
	{
        string sql = "UPDATE [Storage] SET [ExitDate]= '" + DateTime.Now.ToString("dd/MM/yyyy") + "' WHERE [ItemCode]= '" + code + "'";

        OleDbCommand cmd = new OleDbCommand(sql);

        Connect.TakeAction(cmd, Get_DB_Path());
	}
    [WebMethod]
    public DataTable GetVehicleDt()
    {
        string sql = "SELECT * FROM [Vehicle]";

        return Connect.DowonloadData(sql,"Vehicle",Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetDeliveryByVehicleCode(string code)
    {
        string sql = "SELECT * FROM [Delivery] Where [VCode]= '" + code + "' AND [Status]= " + false + "";

        return Connect.DowonloadData(sql, "Delivery", Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetStorageByDate(string date)
    {
        string sql = "SELECT * FROM [Storage] Where [ExitDate]= '" + date + "'";

        return Connect.DowonloadData(sql, "Storage", Get_DB_Path());
    }
    [WebMethod]
    public DataTable GetVehicleDTByItemCode(string Code)
    {
        string sql = "SELECT * FROM [Delivery] WHERE [ItemCode]= '" + Code + "'";

        string sql1 = "SELECT * FROM [Vehicle] WHERE [VCode]= '" + Connect.DowonloadData(sql, "Delivery", Get_DB_Path()).Rows[0][1] + "'";

        return Connect.DowonloadData(sql1, "Vehicle", Get_DB_Path());
    }
}