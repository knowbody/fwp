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
    public void checkPermissions(int access_zone)
    {
        // Check if user is still logged in
        if (Session["auth_email"] == null || (int) Session["access"] > access_zone)
        {
            // Permission are not OK, logging out
            Session.Clear();
            Response.Redirect("~/");
        }
        else
        {
            // All OK
            Session["last_activity"] = DateTime.Now.TimeOfDay;
        }
    }
}