using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vehicle
/// </summary>
public class Vehicle
{
    public Vehicle() { }

    private string vcode;

    public string Vcode
    {
        get { return vcode; }
        set { vcode = value; }
    }

    private string vtype;

    public string Vtype
    {
        get { return vtype; }
        set { vtype = value; }
    }

    private string vname;

    public string Vname
    {
        get { return vname; }
        set { vname = value; }
    }

    private string capacity;

    public string Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    private string pic;

    public string Pic
    {
        get { return pic; }
        set { pic = value; }
    }

    private bool ststus;

    public bool Status
    {
        get { return ststus; }
        set { ststus = value; }
    }

}