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

    // Handling adding new species button click
    protected void BAddSpiece_Click(object sender, EventArgs e)
    {
        // Collecting data
        String spieceName = TBSpiece.Text;

        // Adding new spieces to database
        Boolean added = DBConnectivity.addSpieces(spieceName);

        // Checking if record was added
        if (added)
        {
            displaySuccessMessage("New spieces was created successfully.");
            // Reloading GridView
            loadGridLast();
        }
        else
        {
            displayErrorMessage("Error adding spieces. Please try again.");
        }

        // Reseting form
        resetForm();
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBSpiece.Text = "";
    }

    private void displaySuccessMessage(string message)
    {
        AppHelper.displaySuccessMessage(SuccessMessage, SuccessText, message);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
        AppHelper.hideWarningMessage(WarningMessage, WarningText);
    }

    private void displayErrorMessage(string message)
    {
        AppHelper.displayErrorMessage(ErrorMessage, ErrorText, message);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideWarningMessage(WarningMessage, WarningText);
    }

    private void displayWarningMessage(string message)
    {
        AppHelper.displayWarningMessage(WarningMessage, WarningText, message);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
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
        displayWarningMessage("Spieces was deleted successfully");
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

    protected void ButtonDonation_Click(object sender, EventArgs e)
    {
        Response.Redirect("Donation");
    }

}