using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Client
{
    public int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string name;
    public string email;
    public string address;
    public string country;
    public string tel;
    public string money;
    public DateTime date;
    public string fame;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public string Country
    {
        get { return country; }
        set { country = value; }
    }
    public string Fame
    {
        get { return fame; }
        set { fame = value; }
    }
    public string Tel
    {
        get { return tel; }
        set { tel = value; }
    }
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    public string Money
    {
        get { return money; }
        set { money = value; }
    }

    public Client(int id, string name, string email, string address, string tel, DateTime date, string money, string country, string fame)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.address = address;
        this.tel = tel;
        this.date = date;
        this.money = money;
        this.country = country;
        this.fame = fame;
    }
}

