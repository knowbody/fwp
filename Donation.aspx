<%@ Page Title="Donation overview" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Donation.aspx.cs" Inherits="Donation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Manage Pets</h3>

    <div class="row-fluid">
        <div class="span6">
            <p>On this page you can view an overview of all the people who adopted/donated to "Friend with Paws". You can also see the total donation amount.</p>
        </div><!-- /.span6 -->
    </div><!-- /.row-fluid -->

    <div class="field-group">
        <asp:Button ID="ButtonSpieces" runat="server" OnClick="ButtonSpieces_Click" Text="Manage Spieces" CssClass="btn btn-primary btn" CausesValidation="False" />
        <asp:Button ID="ButtonBreeds" runat="server" OnClick="ButtonBreeds_Click" Text="Manage Breeds" CssClass="btn btn-primary btn" CausesValidation="False" />
        <asp:Button ID="ButtonDonation" runat="server" OnClick="ButtonDonation_Click" Text="Donation overview" CssClass="btn btn-primary btn" CausesValidation="False" />
    </div><!-- /.field-group -->

    <br />
    <b><asp:Label ID="Donation_lbl" runat="server" Text=""></asp:Label></b>
    <br />

    <asp:GridView ID="gvDonationDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No data available...">

                <columns>
                    <asp:boundfield datafield="ID" headertext="ID"/>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:boundfield datafield="Email" headertext="Email"/>
                    <asp:boundfield datafield="Address" headertext="Address"/>
                    <asp:boundfield datafield="Tel" headertext="Telephone"/>
                    <asp:boundfield datafield="Date" headertext="Date"/>
                    <asp:boundfield datafield="Money" headertext="Donation"/>
                    <asp:boundfield datafield="Country" headertext="Country"/>
                    <asp:boundfield datafield="Fame" headertext="Hall of Fame"/>
                </columns>
    </asp:GridView>


</asp:Content>