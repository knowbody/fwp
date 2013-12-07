using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class Manage_Spieces : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkPermissions(2);
        loadGrid(); 
    }

    protected void BAddSpiece_Click(object sender, EventArgs e)
    {
        // Collecting data
        String spieceName = TBSpiece.Text;

        // Adding new spieces to database
        Boolean added = DBConnectivity.addSpieces(spieceName);

        // Checking if record was added
        if (added)
        {
            displaySuccessMessage();
            // Reloading GridView
            loadGridLast();
        }
        else
        {
            displayErrorMessage();
            // Reloading GridView
            loadGrid();
        }

        // Displaying success message
        SuccessMessage.Visible = true;
        SuccessText.Text = "New spieces was created.";

        // Reseting form
        resetForm();

        // Reloading grid with fresh data
        loadGridLast();
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBSpiece.Text = "";
    }

    private void displaySuccessMessage()
    {
        AppHelper.displaySuccessMessage(SuccessMessage, SuccessText, "New spieces was created.");
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
        AppHelper.hideWarningMessage(WarningMessage, WarningText);
    }

    private void displayErrorMessage()
    {
        AppHelper.displayErrorMessage(ErrorMessage, ErrorText);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideWarningMessage(WarningMessage, WarningText);
    }

    // Load grid with fresh data from data source
    private void loadGrid() 
    {
        gvSpiecesDetails.DataSource = DBConnectivity.LoadSpieces();
        gvSpiecesDetails.AllowPaging = true;
        gvSpiecesDetails.DataBind();
    }

    // Load grid and list to last page (after inserting new record)
    private void loadGridLast()
    {
        if (gvSpiecesDetails.PageCount > 1)
        {
            gvSpiecesDetails.PageIndex = gvSpiecesDetails.PageCount - 1;
        }
        loadGrid();
    }

    // Handling pagination click (need to change page)
    protected void gvSpiecesDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSpiecesDetails.PageIndex = e.NewPageIndex;
        gvSpiecesDetails.DataBind();
    }

    // Handling delete button click (deleting record)
    protected void gvSpiecesDetails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Deleting spieces
        TableCell idCell = gvSpiecesDetails.Rows[e.RowIndex].Cells[0];
        DBConnectivity.DeleteSpieces(idCell.Text);
        loadGrid();

        // Displaying warning message
        AppHelper.displayWarningMessage(WarningMessage, WarningText, "Spieces was deleted successfully");
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
    }

    // Handling delete button click (deleting record)
    protected void gvSpiecesDetails_OnRowDeleted(Object sender, GridViewDeletedEventArgs e)
    {
        // Displaying success message
       
    }

    // Binding javascript confirm window to every delete button
    protected void gvSpiecesDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
            {
                button.Attributes["onclick"] = "if(!confirm('Are you sure about deleting this spieces?')){ return false; };";
            }
        }
    }

    protected void ButtonPets_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Pets");
    }

    protected void ButtonBreeds_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Breeds");
    }

}