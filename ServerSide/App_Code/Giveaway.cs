using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Giveaway
/// </summary>
public class Giveaway
{
    public Giveaway() { }

    private string code;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    private string itemcode;

    public string ItemCode
    {
        get { return itemcode; }
        set { itemcode = value; }
    }

    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

    private bool isended;

    public bool IsEnded
    {
        get { return isended; }
        set { isended = value; }
    }


    private string startdate;

    public string StartDate
    {
        get { return startdate; }
        set { startdate = value; }
    }

    private int tickets;

    public int Tickets
    {
        get { return tickets; }
        set { tickets = value; }
    }

    private string winner;

    public string Winner
    {
        get { return winner; }
        set { winner = value; }
    }
}