using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class Manage_Pets : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void BAddPet_Click(object sender, EventArgs e)
    {
        // Checking if breed and spieces was selected
        if (DDLBreeds.SelectedValue == "0")
        {
            displayErrorMessage("Please select spieces and breed");
            DDLSpieces.ClearSelection();
            return;
        }

        // Checking file extension
        string fileExt = System.IO.Path.GetExtension(FileUploadPicture.FileName);
        if (fileExt == ".jpeg" || fileExt == ".jpg"  || fileExt == ".png")
        {
            // Uploading picture
            FileUploadPicture.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "img/Upload/" + FileUploadPicture.FileName);
        }
        else
        {
            displayErrorMessage("Wrong picture file extension.");
            return;
        }

        // Checking calendar value is selected
        DateTime? rescueD = CalendarRescue.SelectedDate;
        if (!rescueD.HasValue || rescueD.Value == DateTime.MaxValue || rescueD.Value == DateTime.MinValue)
        {
            displayErrorMessage("Please select rescue date.");
            return;
        }

        // Collecting data
        string[,] petData = new string[9, 2] { 
            { "name", TBName.Text }, 
            { "breed_id", DDLBreeds.SelectedValue },
            { "sanctuary_id", DDLSanctuary.SelectedValue },
            { "age", TBAge.Text },
            { "gender", RBLGender.SelectedValue.ToString() },
            { "weight", TBWeight.Text },
            { "bills", TBBills.Text },
            { "rescue_date", CalendarRescue.SelectedDate.ToString() },
            { "pricture_path", FileUploadPicture.FileName },
        };

        // Adding new breed to database
        Boolean added = DBConnectivity.addPet(petData);

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
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBName.Text = "";
        DDLSpieces.ClearSelection();
        DDLBreeds.ClearSelection();
        DDLSanctuary.ClearSelection();
        TBAge.Text = "";
        RBLGender.ClearSelection();
        TBWeight.Text = "";
        TBBills.Text = "";
        CalendarRescue.VisibleDate = DateTime.Today;
        CalendarRescue.SelectedDates.Clear(); 
    }

    private void displaySuccessMessage() 
    {
        AppHelper.displaySuccessMessage(SuccessMessage, SuccessText, "New pet was created.");
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
    }

    private void displayErrorMessage(string message = "")
    {
        AppHelper.displayErrorMessage(ErrorMessage, ErrorText, message);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
    }

    private void displayWarningMessage(string message = "")
    {
        AppHelper.displayWarningMessage(WarningMessage, WarningText, message);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
    }

    // Load grid with fresh data from data source
    private void loadGrid()
    {
        List<Pet> pets = DBConnectivity.LoadPets();
        gvPetsDetails.DataSource = pets;
        gvPetsDetails.AllowPaging = true;
        gvPetsDetails.DataBind();
        LabelTotalCost.Text = AppHelper.getTotalCost(pets).ToString("C2");
    }

    // Load grid and list to last page (after inserting new record)
    private void loadGridLast()
    {
        if (gvPetsDetails.PageCount > 1)
        {
            gvPetsDetails.PageIndex = gvPetsDetails.PageCount - 1;
        }
        loadGrid();
    }

    // Handling pagination click (need to change page)
    protected void gvPetsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPetsDetails.PageIndex = e.NewPageIndex;
        gvPetsDetails.DataBind();
    }

    // Handling delete button click (deleting record)
    protected void gvPetsDetails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Deleting pet
        TableCell idCell = gvPetsDetails.Rows[e.RowIndex].Cells[0];
        DBConnectivity.DeletePet(idCell.Text);
        loadGrid();

        // Displaying warning message
        displayWarningMessage("Pet was deleted successfully");
    }

    // Binding javascript confirm window to every delete button
    protected void gvPetsDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[11].Controls.OfType<Button>())
            {
                button.Attributes["onclick"] = "if(!confirm('Are you sure about deleting this pet?')){ return false; };";
            }
        }
    }

    // Reacting to spieces dropdown list change
    protected void DDLSpieces_OnSelectedIndexChanged(Object sender, EventArgs e)
    {
        if (DDLSpieces.SelectedValue != "0")
        {
            // Loading breeds dropdownlist by spieces id
            DDLBreeds.Attributes.Remove("disabled");
            DDLBreeds.DataSource = DBConnectivity.LoadBreedsBySpieces(DDLSpieces.SelectedValue);
            DDLBreeds.DataTextField = "name";
            DDLBreeds.DataValueField = "id";
            DDLBreeds.DataBind();
        }
        else
        {
            // Emptying and disabling breeds dropdownlist
            DDLBreeds.Items.Clear();
            DDLBreeds.Items.Insert(0, new ListItem("Select spieces...", "0"));
            DDLBreeds.Attributes.Add("disabled", "disabled");
        }
    }

    // Appending empty element at the begining of the list
    protected void DDLSpieces_OnDataBound(Object sender, EventArgs e)
    {
        DDLSpieces.Items.Insert(0, new ListItem("Select spieces...", "0"));
    }

    // Appending empty element at the begining of the list
    protected void DDLBreeds_OnDataBound(Object sender, EventArgs e)
    {
        DDLBreeds.Items.Insert(0, new ListItem("Select breed...", "0"));
    }

    protected void ButtonSpieces_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Spieces");
    }

    protected void ButtonBreeds_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Breeds");
    }

}