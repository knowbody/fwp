<%@ Page Title="New Client" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="NewClient.aspx.cs" Inherits="NewClient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Buy a pet</h3>

    <div class="row-fluid">
        <div class="span8">
            <div class="input-group">
                <!-- NAME BOX-->
                <asp:TextBox ID="Name_txtb" runat="server" placeholder="Name" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name_txtb" ErrorMessage="Field Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="Name_txtb" ErrorMessage="That's not your name!" Type="String" ForeColor="Red"></asp:RangeValidator><br /><br />
                
                <!-- EMAIL BOX-->
                <asp:TextBox ID="Email_txtb" runat="server" placeholder="Email address" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email_txtb" ErrorMessage="Field Required" ForeColor="Red"></asp:RequiredFieldValidator><br /><br />


                <!-- ADDRESS BOX-->
                <asp:TextBox ID="Address_txtb" runat="server" placeholder="Address" class="form-control" rows="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Address_txtb" ErrorMessage="Field Required" ForeColor="Red"></asp:RequiredFieldValidator><br /><br />

                
                <!-- COUNTRY BOX-->
                <asp:TextBox ID="Country_txtb" runat="server" placeholder="Country" class="form-control"></asp:TextBox>&nbsp
                <asp:CheckBox ID="Country_chb" runat="server" Text="same as pet country" OnCheckedChanged="Country_chb_CheckChanged" AutoPostBack="true"/><br /><br />
               
                <!-- TELEPHONE BOX-->
                <asp:TextBox ID="Tel_txtb" runat="server" placeholder="Telephone number" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Tel_txtb" ErrorMessage="Field Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="Tel_txtb" ErrorMessage="Enter numbers only" Type="Double" ForeColor="Red"></asp:RangeValidator><br /><br />
                
                <!-- DONATION AMOUNT BOX-->
                <asp:TextBox ID="Money_txtb" runat="server" placeholder="Donation amount" class="form-control"></asp:TextBox>&nbsp
                <asp:DropDownList ID="money_dl" runat="server">
                    <asp:ListItem>£ (pounds)</asp:ListItem>
                    <asp:ListItem>€ (euro)</asp:ListItem>
                    <asp:ListItem>Lei</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Money_txtb" ErrorMessage="Field Required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Money_txtb" ErrorMessage="Wrong format (not numbers)" Type="Currency" ForeColor="Red" MinimumValue="0" MaximumValue="9999999999999999"></asp:RangeValidator><br /><br /><br />

                <!-- ADD BUTTON -->
                <asp:Button ID="AddClient_btn" runat="server" Text="Add New Client" class="btn btn-primary btn" OnClick="AddClient_btn_Click" />
                <br />
                <br />
                
                <br />
                <br />
                <asp:Label ID="TotalD_lbl" runat="server"></asp:Label>
            </div><!-- /input-group -->
        </div><!-- /.span8 -->
    </div><!-- /.row -->
</asp:Content>

