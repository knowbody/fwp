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
            // hide form for user when page loaded
            hideClient();
        }
    }

    // reaction after clicking Adopt button
    protected void Adopt_btn_Click(object sender, EventArgs e)
    {
        string Name = Name_txtb.Text;
        string Email = Email_txtb.Text;
        string Address = Address_txtb.Text;
        string Country = Country_ddl.Text;
        string Tel = Tel_txtb.Text;
        DateTime Date = DateTime.Now;
        double m = Convert.ToDouble(Money_txtb.Text);
        string Money = Convert.ToString(currency(m));
        string Fame = "False";

        // if donated amount bigger than minimum donation set Fame to True
        if (currency(m) > minDonation())
            Fame = "True";

        // if checkbox ticked get the country name from grid view
        if (Country_chb.Checked == true)
        {
            Country = GVPetsDetails.Rows[0].Cells[2].Text;
        }

        // add new client to the database
        Client newClient = DBConnectivity.addClient(Name, Email, Address, Tel, Date, Money, Country, Fame);

        // assigning adoption date in pets table
        DBConnectivity.adoptPet(DDLPet.SelectedValue, DateTime.Now);
    }

    // reaction after clicking Check button
    protected void Check_btn_Click(object sender, EventArgs e)
    {
        // look for particular pet in db based on its Id
        string setValueId = DDLPet.SelectedValue;
        List<Pet> pets;
        pets = DBConnectivity.LoadPets("pet", setValueId);

        GVPetsDetails.DataSource = pets;
        GVPetsDetails.AllowPaging = true;
        GVPetsDetails.DataBind();
        Checkout_btn.Visible = true;
    }

    // reaction after clicking Checkout button
    protected void Checkout_btn_Click(object sender, EventArgs e)
    {
        // add countries to drop down list
        BindCountry();

        // disable countries drop down list
        Country_ddl.Enabled = false;

        // tick countries check box
        Country_chb.Checked = true;

        // Total money donated
        TotalD_lbl.Text = "TOTAL MONEY DONATED: £" + Convert.ToString(DBConnectivity.getMoney());

        // show form to the user
        showClient();
    }

    // show all textboxes etc.
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
        Adopt_btn.Visible = true;
    }

    // hiding all text boxes etc.
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
        Adopt_btn.Visible = false;
    }

    // if countries checkbox is not ticked enable textbox or the other way round
    protected void Country_chb_CheckChanged(object sender, EventArgs e)
    {
        Country_ddl.Enabled = true;
        if (Country_chb.Checked) { Country_ddl.Enabled = false; }
    }

    // change currency from Lei to Pounds or Euro to Pounds
    // 1 pound = 0.19 Lei || 1 pound = 0.83 Euro
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

    private double minDonation()
    {
        double min = 0.0;
        if (DDLFilter.SelectedValue == "Cats")
            min = 50.0;
        else if (DDLFilter.SelectedValue == "Dogs")
            min = 100.0;
        else if (DDLFilter.SelectedValue == "Ferrets")
            min = 20.0;
        else if (DDLFilter.SelectedValue == "Chinchillas")
            min = 20.0;
        else if (DDLFilter.SelectedValue == "Guinea Pigs")
            min = 15.0;
        else if (DDLFilter.SelectedValue == "Rabbits")
            min = 30.0;
        else
            min = 0.0;
        return min;
    }


    // Reacting to filtering dropdown list change
    protected void DDLViewBy_OnSelectedIndexChanged(Object sender, EventArgs e)
    {
        int selValue = int.Parse(DDLViewBy.SelectedValue);
        string setPet;

        switch (selValue)
        {
            // case 0 (Select by...)
            case 0:
                // Emptying and disabling filter and pet dropdownlist
                DDLFilter.Items.Clear();
                DDLFilter.Items.Insert(0, new ListItem("Select value...", "0"));
                DDLFilter.Attributes.Add("disabled", "disabled");
                DDLPet.Items.Clear();
                DDLPet.Items.Insert(0, new ListItem("Select value...", "0"));
                DDLPet.Attributes.Add("disabled", "disabled");
                break;
           
            // case 1 (Breeds)
            case 1:
                // Loading breeds to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.DataSource = DBConnectivity.LoadBreeds();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();

                // updating pet drop sown list based on first item in breed list
                setPet = DDLFilter.SelectedValue;
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("breed", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;

            // case 2 (Spieces)
            case 2:
                // Loading spieces to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.DataSource = DBConnectivity.LoadSpieces();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();

                // updating pet drop sown list based on first item in spieces list
                setPet = DDLFilter.SelectedValue;
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("spieces", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;

            // (Sanctuary)
            default:
                // Loading sanctuaries to dropdownlist
                DDLFilter.Attributes.Remove("disabled");
                DDLFilter.Items.Clear();
                DDLFilter.DataSource = DBConnectivity.LoadSanctuaries();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();

                // updating pet drop sown list based on first item in sanctuaries list
                setPet = DDLFilter.SelectedValue;
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("sanctuary", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
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
            case 1:
                // Loading filtreted pets in breed
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("breed", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
            case 2:
                // Loading filtreted pets in spieces
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("spieces", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
            default:
                // Loading filtreted pets in snactuary
                DDLPet.Attributes.Remove("disabled");
                DDLPet.Items.Clear();
                DDLPet.DataSource = DBConnectivity.LoadPets("sanctuary", setPet);
                DDLPet.DataTextField = "name";
                DDLPet.DataValueField = "id";
                DDLPet.DataBind();
                break;
        }
    }
}