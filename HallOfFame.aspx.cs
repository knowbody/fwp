using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class HallOfFame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Client> clients;
        clients = DBConnectivity.LoadClient();

        GVFameDetails.DataSource = clients;
        GVFameDetails.AllowPaging = true;
        GVFameDetails.DataBind();
    }
}