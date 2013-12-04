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
        Spieces newSpiece = DBConnectivity.addBreed(spieceName);
        loadGrid(); 
    }

    private void loadGrid() 
    {
        gvSpiecesDetails.DataSource = DBConnectivity.LoadSpieces();
        gvSpiecesDetails.AllowPaging = true;
        gvSpiecesDetails.DataBind();
    }

    private void addNewTableRow(string name)
    {
        TableRow row = new TableRow();
        TableCell cellName = new TableCell();
        cellName.Text = name;
        TableCell cellAction = new TableCell();
        cellAction.Text = "Ha";

        row.Cells.Add(cellName);
        row.Cells.Add(cellAction);
        //TableSpieces.Rows.Add(row); 
    }

    protected void gvSpiecesDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSpiecesDetails.PageIndex = e.NewPageIndex;
        gvSpiecesDetails.DataBind();

    }

}