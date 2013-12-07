using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class View_Animals : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            loadGrid();
        }
    }

    // Load grid with fresh data from data source
    private void loadGrid()
    {
        List<Pet> pets = DBConnectivity.LoadPets();
        GVPetsDetails.DataSource = pets;
        GVPetsDetails.AllowPaging = true;
        GVPetsDetails.DataBind();
    }

    // Handling pagination click (need to change page)
    protected void GVPetsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVPetsDetails.PageIndex = e.NewPageIndex;
        GVPetsDetails.DataBind();
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
                DDLFilter.DataSource = DBConnectivity.LoadSanctuaries();
                DDLFilter.DataTextField = "name";
                DDLFilter.DataValueField = "id";
                DDLFilter.DataBind();
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
        
        GVPetsDetails.DataSource = pets;
        GVPetsDetails.AllowPaging = true;
        GVPetsDetails.DataBind();
    }
}