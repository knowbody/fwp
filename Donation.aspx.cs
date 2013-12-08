using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWP;

public partial class Donation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Client> donation = DBConnectivity.LoadDonations();
        gvDonationDetails.DataSource = donation;
        gvDonationDetails.AllowPaging = true;
        gvDonationDetails.DataBind();

        // Total money donated
        Donation_lbl.Text = "TOTAL MONEY DONATED: £" + Convert.ToString(DBConnectivity.getMoney());
    }

    protected void ButtonSpieces_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Spieces");
    }

    protected void ButtonBreeds_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage-Breeds");
    }

    protected void ButtonDonation_Click(object sender, EventArgs e)
    {
        Response.Redirect("Donation");
    }
}