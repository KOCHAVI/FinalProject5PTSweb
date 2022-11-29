using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public Product() { }

    private string code;
    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    private string pname;
    public string PName
    {
        get { return pname; }
        set { pname = value; }
    }

    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private int price;

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    private string pic;

    public string Pic
    {
        get { return pic; }
        set { pic = value; }
    }

    private string owner;

    public string Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    private bool status;

    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

}