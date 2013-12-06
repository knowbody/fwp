using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void LogIn(object sender, EventArgs e)
    {
        string email = TBEmail.Text;
        string password = TBPass.Text;

        Session["auth_email"] = TBEmail.Text;
    }
}