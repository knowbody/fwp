using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class Manage_Users : Base
{
    protected void Page_Load(object sender, EventArgs e)
    {
        checkPermissions(1);
        loadGrid();
    }

    protected void BAddStaff_Click(object sender, EventArgs e)
    {
        // Collecting data
        String pass = TBPassword.Text;
        String passRep = TBPasswordRep.Text;

        // Checking passwords are same
        if (pass != passRep)
        {
            displayErrorMessage("Passwords are not the same. Please try again.");
            TBPassword.Text = "";
            TBPasswordRep.Text = "";
            return;
        }

        // Collecting data
        string[,] staffData = new string[5, 2] { 
            { "first_name", TBFirstName.Text }, 
            { "last_name", TBLastName.Text },
            { "email", TBEmail.Text },
            { "password", pass },
            { "access", DDLAccess.SelectedValue.ToString() },
        };
    }

    // Reseting form to default state
    private void resetForm()
    {
        TBFirstName.Text = "";
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
        AppHelper.displayWarningMessage(WarningMessage, WarningText, "Member was deleted successfully");
        AppHelper.hideSuccessMessage(SuccessMessage, SuccessText);
        AppHelper.hideErrorMessage(ErrorMessage, ErrorText);
    }

}