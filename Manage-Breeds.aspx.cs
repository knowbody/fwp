using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Breeds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DDLSpieces.DataSource = DBConnectivity.LoadSpieces();
            DDLSpieces.DataTextField = "name";
            DDLSpieces.DataValueField = "id";
            DDLSpieces.DataBind();
        }

        loadGrid();
    }
    protected void BAddBreed_Click(object sender, EventArgs e)
    {
        String breedName = TBBreed.Text;
        int spiecesId = int.Parse(DDLSpieces.SelectedValue);
        Breed newBreed = DBConnectivity.addBreed(breedName, spiecesId);
        loadGrid(); 
    }

    private void loadGrid()
    {
        gvBreedsDetails.DataSource = DBConnectivity.LoadBreeds();
        gvBreedsDetails.AllowPaging = true;
        gvBreedsDetails.DataBind();
    }

    protected void gvBreedsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBreedsDetails.PageIndex = e.NewPageIndex;
        gvBreedsDetails.DataBind();
    }
}