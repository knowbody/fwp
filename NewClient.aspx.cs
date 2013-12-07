using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using FWP;

public partial class NewClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            hideClient();
        }
    }

    protected void AddClient_btn_Click(object sender, EventArgs e)
    {
        string Name = Name_txtb.Text;
        string Email = Email_txtb.Text;
        string Address = Address_txtb.Text;
        string Country = Country_ddl.Text;
        string Tel = Tel_txtb.Text;
        DateTime Date = DateTime.Now;
        double m = Convert.ToDouble(Money_txtb.Text);
        string Money = Convert.ToString(currency(m));

        // add new client to the database
        Client newClient = DBConnectivity.addClient(Name, Email, Address, Tel, Date, Money, Country);
    }

    protected void Adopt_btn_Click(object sender, EventArgs e)
    {
        BindCountry();
        Country_ddl.Enabled = false;
        Country_chb.Checked = true;
        TotalD_lbl.Text = "TOTAL MONEY DONATED: £" + Convert.ToString(DBConnectivity.getMoney());

        showClient();
        
    }

    protected void showClient()
    {
        Name_txtb.Visible = true;
        Email_txtb.Visible = true;
        Address_txtb.Visible = true;
        Country_ddl.Visible = true;
        Country_chb.Visible = true;
        Tel_txtb.Visible = true;
        Money_txtb.Visible = true;
        Money_ddl.Visible = true;
        AddClient_btn.Visible = true;
    }

    protected void hideClient()
    {
        Name_txtb.Visible = false;
        Email_txtb.Visible = false;
        Address_txtb.Visible = false;
        Country_ddl.Visible = false;
        Country_chb.Visible = false;
        Tel_txtb.Visible = false;
        Money_txtb.Visible = false;
        Money_ddl.Visible = false;
        AddClient_btn.Visible = false;
    }

    protected void Country_chb_CheckChanged(object sender, EventArgs e)
    {
        Country_ddl.Enabled = true;
        if (Country_chb.Checked) { Country_ddl.Enabled = false; }
    }

    protected double currency(double m)
    {
        if (Money_ddl.Text == "€ (euro)")
        {
            m = m * 0.83;
        }
        else if (Money_ddl.Text == "Lei")
        {
            m = m * 0.19;
        }
        else
        {
            // money in pounds
        }
        return m;
    }

    // loading countries from XML file to drop down list
    private void BindCountry()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("countries.xml"));

        foreach (XmlNode node in doc.SelectNodes("//country"))
        {
            Country_ddl.Items.Add(new ListItem(node.InnerText, node.Attributes["code"].InnerText));
        }
    }


    // Reacting to filtering dropdown list change
    protected void DDLViewBy_OnSelectedIndexChanged(Object sender, EventArgs e)
    {
        int selValue = int.Parse(DDLViewBy.SelectedValue);

        switch (selValue)
        {
            case 0:
                // Emptying and disabling breeds dropdownlist
                DDLFilter.Items.Clear();
                DDLFilter.Items.Insert(0, new ListItem("Select value...", "0"));
                DDLFilter.Attributes.Add("disabled", "disabled");
                break;
            case 1:
                // Loading breeds to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.DataSource = DBConnectivity.LoadBreeds();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();
                break;
            case 2:
                // Loading spieces to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.DataSource = DBConnectivity.LoadSpieces();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();
                break;
            default:
                // Loading sanctuaries to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.Items.Insert(0, new ListItem("Sanctuary 1", "1"));
                DDLFilter.Items.Insert(1, new ListItem("Sanctuary 2", "2"));
                DDLFilter.Items.Insert(2, new ListItem("Sanctuary 3", "3"));
                break;
        }
    }

    // Reacting to filtering dropdown list change
    protected void DDLFilter_OnSelectedIndexChanged(Object sender, EventArgs e)
    {
        int selValue = int.Parse(DDLViewBy.SelectedValue);
        string setPet = DDLFilter.SelectedValue;

        switch (selValue)
        {
            case 0:
                // Emptying and disabling breeds dropdownlist
                DDLPet.Items.Clear();
                DDLPet.Items.Insert(0, new ListItem("Select value...", "0"));
                DDLPet.Attributes.Add("disabled", "disabled");
                break;
            case 1:
                // Loading breeds to dropdownlist
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("breed", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
            case 2:
                // Loading spieces to dropdownlist
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("species", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
            default:
                // Loading spieces to dropdownlist
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("sanctuary", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
        }
    }

    // Handling filtering of the results 
    protected void BFiltert_Click(object sender, EventArgs e)
    {
        int selValue = int.Parse(DDLViewBy.SelectedValue);
        string selValueId = DDLFilter.SelectedValue;
        List<Pet> pets;

        switch (selValue)
        {
            case 0:
                // Loading all pets
                pets = DBConnectivity.LoadPets();
                break;
            case 1:
                pets = DBConnectivity.LoadPets("breed", selValueId);
                break;
            case 2:
                pets = DBConnectivity.LoadPets("spieces", selValueId);
                break;
            default:
                pets = DBConnectivity.LoadPets("sanctuary", selValueId);
                break;
        }
    }
}