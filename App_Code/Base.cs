using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

// Base class
public abstract class Base : Page
{
    // Check login
    public void checkPermissions(int access_zone)
    {
        // Check if user is still logged in and have access to this access_zone
        if (Session["auth_email"] == null || (int) Session["access"] > access_zone)
        {
            // Permission are not OK, logging out
            Session.Clear();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}