using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class NewClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            Country_txtb.Enabled = false;
            Country_chb.Checked = true;
            TotalD_lbl.Text = "TOTAL MONEY DONATED: £" + Convert.ToString(DBConnectivity.getMoney());
        }
    }

    protected void AddClient_btn_Click(object sender, EventArgs e)
    {
        string Name = Name_txtb.Text;
        string Email = Email_txtb.Text;
        string Address = Address_txtb.Text;
        string Country = Country_txtb.Text;
        string Tel = Tel_txtb.Text;
        DateTime Date = DateTime.Now;
        double m = Convert.ToDouble(Money_txtb.Text);
        string Money = Convert.ToString(currency(m));

        // add new client to the database
        Client newClient = DBConnectivity.addClient(Name, Email, Address, Tel, Date, Money, Country);
    }

    public void Country_chb_CheckChanged(object sender, EventArgs e)
    {
        Country_txtb.Enabled = true;
        if (Country_chb.Checked) { Country_txtb.Enabled = false; }
    }

    public double currency(double m)
    {
        if (money_dl.Text == "€ (euro)")
        {
            m = m * 0.83;
        }
        else if (money_dl.Text == "Lei")
        {
            m = m * 0.19;
        }
        else
        {
            // money in pounds
        }
        return m;
    }
}

