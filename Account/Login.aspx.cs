using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using FWP;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void LogIn(object sender, EventArgs e)
    {
        // Colecting data
        string email = TBEmail.Text;
        string password = TBPass.Text;

        // Checking login details
        Staff account = DBConnectivity.login(email, password);

        if (account != null)
        {
            // Loging OK
            Session["auth_email"] = account.email;
            Session["first_name"] = account.firstName;
            Session["access"] = account.access;
            Response.Redirect("~/Manage-Pets");
        }
        else
        {
            // Bad details
            ErrorMessage.Visible = true;
            FailureText.Text = "Bad credentials. Try again.";
        }

        
    }
}