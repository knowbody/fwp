using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;
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

        // Hashing password
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
        password = Convert.ToBase64String(md5.Hash);

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