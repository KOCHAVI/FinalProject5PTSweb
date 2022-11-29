using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public User() { }
    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    private string pass;

    public string Pass
    {
        get { return pass; }
        set { pass = value; }
    }
    private string firstname;

    public string Firstname
    {
        get { return firstname; }
        set { firstname = value; }
    }
    private string lastname;

    public string Lastname
    {
        get { return lastname; }
        set { lastname = value; }
    }
    private string phone;

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    private int coins;

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }
    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    private string numaddress;

    public string NumAddress
    {
        get { return numaddress; }
        set { numaddress = value; }
    }
    private string city;

    public string City
    {
        get { return city; }
        set { city = value; }
    }
    private string country;

    public string Country
    {
        get { return country; }
        set { country = value; }
    }
}