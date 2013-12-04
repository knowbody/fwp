using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_Spieces : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadGrid(); 
    }

    protected void BAddSpiece_Click(object sender, EventArgs e)
    {
        String spieceName = TBSpiece.Text;
        Spieces newSpiece = DBConnectivity.addSpieces(spieceName);
        loadGrid(); 
    }

    private void loadGrid() 
    {
        gvSpiecesDetails.DataSource = DBConnectivity.LoadSpieces();
        gvSpiecesDetails.AllowPaging = true;
        gvSpiecesDetails.DataBind();
    }

    protected void gvSpiecesDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSpiecesDetails.PageIndex = e.NewPageIndex;
        gvSpiecesDetails.DataBind();

    }

}