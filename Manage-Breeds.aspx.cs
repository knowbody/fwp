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

        // Reseting form
        resetForm();

        // Displaying success message
        SuccessMessage.Visible = true;
        SuccessText.Text = "New breed was created.";

        // Reloading GridView
        loadGridLast();
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBBreedName.Text = "";
        TBFoodPrice.Text = "";
        DDLSpieces.ClearSelection();
        TBHousingCosts.Text = "";
    }

    private void displaySuccessMessage()
    {
        AppHelper.displaySuccessMessage(SuccessMessage, SuccessText, "New breed was created.");
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
    }

    private void displayErrorMessage()
    {
        AppHelper.displayErrorMessage(ErrorMessage, ErrorText);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
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
        AppHelper.displayWarningMessage(WarningMessage, WarningText, "Breed was deleted successfully");
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
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