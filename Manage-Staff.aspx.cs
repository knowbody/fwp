using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using FWP;

public partial class Manage_Users : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkPermissions(1);
        loadGrid();
    }

    // Handling adding new staff member button click
    protected void BAddStaff_Click(object sender, EventArgs e)
    {
        // Collecting data
        String pass = TBPassword.Text;
        String passRep = TBPasswordRep.Text;
        String email = TBEmail.Text;

        // Checking email is unique
        if (!DBConnectivity.checkEmailUnique(email))
        {
            displayErrorMessage("Member with this email is already registered.");
            return;
        }

        // Checking passwords are same
        if (pass != passRep)
        {
            displayErrorMessage("Passwords are not the same. Please try again.");
            return;
        }

        // Checking if access level was selected
        if (DDLAccess.SelectedValue == "0")
        {
            displayErrorMessage("Please select access level.");
            return;
        }

        // Hashing password
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
        pass = Convert.ToBase64String(md5.Hash);

        // Collecting data
        string[,] staffData = new string[5, 2] { 
            { "first_name", TBFirstName.Text }, 
            { "last_name", TBLastName.Text },
            { "email", email },
            { "password", pass },
            { "access", DDLAccess.SelectedValue },
        };

        // Adding new spieces to database
        Boolean added = DBConnectivity.addStaff(staffData);

        // Checking if record was added
        if (added)
        {
            displaySuccessMessage("Staff member was added successfully");
            // Reloading GridView
            loadGridLast();
        }
        else
        {
            displayErrorMessage("Error adding member. Please try again.");
        }

        // Reseting form
        resetForm();
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBFirstName.Text = "";
        TBLastName.Text = "";
        TBEmail.Text = "";
        DDLAccess.ClearSelection();
    }

    private void displaySuccessMessage(string message = "")
    {
        AppHelper.displaySuccessMessage(SuccessMessage, SuccessText, message);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
        AppHelper.hideWarningMessage(WarningMessage, WarningText);
    }

    private void displayErrorMessage(string message = "")
    {
        AppHelper.displayErrorMessage(ErrorMessage, ErrorText, message);
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideWarningMessage(SuccessMessage, SuccessText);
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
        GVUsersDetails.DataSource = DBConnectivity.LoadStaff();
        GVUsersDetails.AllowPaging = true;
        GVUsersDetails.DataBind();
    }

    // Load grid and list to last page (after inserting new record)
    private void loadGridLast()
    {
        if (GVUsersDetails.PageCount > 1)
        {
            GVUsersDetails.PageIndex = GVUsersDetails.PageCount - 1;
        }
        loadGrid();
    }

    // Handling pagination click (need to change page)
    protected void GVUsersDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVUsersDetails.PageIndex = e.NewPageIndex;
        GVUsersDetails.DataBind();
    }

    // Binding javascript confirm window to every delete button
    protected void GVUsersDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[0].Text;
            foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
            {
                button.Attributes["onclick"] = "if(!confirm('Are you sure about deleting this staff member?')){ return false; };";
            }
        }
    }

    // Handling delete button click (deleting record)
    protected void GVUsersDetails_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Deleting spieces
        TableCell idCell = GVUsersDetails.Rows[e.RowIndex].Cells[0];
        DBConnectivity.DeleteStaff(idCell.Text);
        loadGrid();

        // Displaying warning message
        displayWarningMessage("Member was deleted successfully");
    }

}