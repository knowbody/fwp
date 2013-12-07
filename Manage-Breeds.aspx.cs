using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class Manage_Breeds : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkPermissions(2);
        if (!Page.IsPostBack)
        {
            // Loading spieces dropdownlist
            DDLSpieces.DataSource = DBConnectivity.LoadSpieces();
            DDLSpieces.DataTextField = "name";
            DDLSpieces.DataValueField = "id";
            DDLSpieces.DataBind();
        }
        loadGrid();
    }

    // Handling adding new breed button click
    protected void BAddBreed_Click(object sender, EventArgs e)
    {
        // Collecting data
        string[,] breedData = new string[4, 2] { 
            { "name", TBBreedName.Text }, 
            { "spieces_id", DDLSpieces.SelectedValue },
            { "food_cost", TBFoodPrice.Text },
            { "housing_cost", TBHousingCosts.Text }
        };

        // Adding new breed to database
        Boolean added = DBConnectivity.addBreed(breedData);

        // Checking if record was added
        if (added)
        {
            displaySuccessMessage("New breed was added successfully.");
            // Reloading GridView
            loadGridLast();
        }
        else
        {
            displayErrorMessage("Error while creating breed. Please try again.");
        }

        // Reseting form
        resetForm();
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBBreedName.Text = "";
        TBFoodPrice.Text = "";
        DDLSpieces.ClearSelection();
        TBHousingCosts.Text = "";
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
        gvBreedsDetails.DataSource = DBConnectivity.LoadBreeds();
        gvBreedsDetails.AllowPaging = true;
        gvBreedsDetails.DataBind();
    }

    // Load grid and list to last page (after inserting new record)
    private void loadGridLast()
    {
        if (gvBreedsDetails.PageCount > 1)
        {
            gvBreedsDetails.PageIndex = gvBreedsDetails.PageCount - 1;
        }
        loadGrid();
    }

    // Handling pagination click (need to change page)
    protected void gvBreedsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBreedsDetails.PageIndex = e.NewPageIndex;
        gvBreedsDetails.DataBind();
    }

    // Handling delete button click (deleting record)
    protected void gvBreedsDetails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Deleting breed
        TableCell idCell = gvBreedsDetails.Rows[e.RowIndex].Cells[0];
        DBConnectivity.DeleteBreed(idCell.Text);
        loadGrid();

        // Displaying warning message
        displayWarningMessage("Breed was deleted successfully");
    }

    // Binding javascript confirm window to every delete button
    protected void gvBreedsDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[5].Controls.OfType<Button>())
            {
                button.Attributes["onclick"] = "if(!confirm('Are you sure about deleting this breed?')){ return false; };";
            }
        }
    }

    protected void ButtonPets_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Pets");
    }

    protected void ButtonSpieces_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Spieces");
    }

}