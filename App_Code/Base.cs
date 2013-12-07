using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public class Base : Page
{
    // Check login
    public void checkPermissions()
    {
        // Check if user is logged in
        if (Session["auth_email"] == null)
        {
            Response.Redirect("~/");
        }
    }
}