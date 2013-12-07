<%@ Page Title="New Client" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="NewClient.aspx.cs" Inherits="NewClient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Adopt a pet</h3>

    <div class="row-fluid">

        <div class="span6">
            <h4>Select by:</h4>
            <div class="field-group">
                <div class="field">
                    <asp:DropDownList ID="DDLViewBy" 
                        AutoPostBack="true" style="float:left;"
                        OnSelectedIndexChanged="DDLViewBy_OnSelectedIndexChanged"
                        runat="server">
                        <asp:ListItem Value="0">Select by...</asp:ListItem>
                        <asp:ListItem Value="1">Breeds</asp:ListItem>
                        <asp:ListItem Value="2">Spieces</asp:ListItem>
                        <asp:ListItem Value="3">Sanctuary</asp:ListItem>
                    </asp:DropDownList><br /><br />

                    <asp:DropDownList ID="DDLFilter"
                        AutoPostBack="true" style="float: left;"
                        OnSelectedIndexChanged="DDLFilter_OnSelectedIndexChanged" 
                        runat="server">
                        <asp:ListItem Value="0">...</asp:ListItem>
                    </asp:DropDownList><br /><br />

                    <asp:DropDownList ID="DDLPet" 
                        runat="server">
                        <asp:ListItem Value="0">...</asp:ListItem>
                    </asp:DropDownList><br /><br />

                    

                </div><!-- /.field -->
                <div class="field">
                    <asp:Button ID="Adopt_btn" 
                        OnClick="Adopt_btn_Click" 
                        runat="server" 
                        Text="Adopt" 
                        CssClass="btn btn-primary" />
                </div><!-- /.field -->
            </div><!-- /.field-group -->
        </div><!-- /.span6 -->

        <div class="span6">
            <div class="input-group">
                <!-- NAME BOX-->
                <asp:TextBox ID="Name_txtb" runat="server" placeholder="Name" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name_txtb" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CausesValidation="True" runat="server" ControlToValidate="Name_txtb" ValidationExpression="^[a-zA-Z ]+$" ErrorMessage="RegularExpressionValidator" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />
                
                <!-- EMAIL BOX-->
                <asp:TextBox ID="Email_txtb" runat="server" placeholder="Email address" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email_txtb" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CausesValidation="True" runat="server" ControlToValidate="Email_txtb" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Invalid Email address" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />

                <!-- ADDRESS BOX-->
                <asp:TextBox ID="Address_txtb" runat="server" placeholder="Address" class="form-control" rows="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Address_txtb" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <!-- COUNTRY BOX-->
                <asp:DropDownList runat="server" ID="Country_ddl" />
                <asp:CheckBox ID="Country_chb" runat="server" Text="same as pet country" OnCheckedChanged="Country_chb_CheckChanged" AutoPostBack="true" CssClass="checkbox inline"/>
                <br />

                <!-- TELEPHONE BOX-->
                <asp:TextBox ID="Tel_txtb" runat="server" placeholder="Telephone number" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Tel_txtb" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" CausesValidation="True" runat="server" ControlToValidate="Tel_txtb" ValidationExpression="^[0-9]+$" ErrorMessage="Numbers only" ForeColor="Red"></asp:RegularExpressionValidator>
                <br />

                <!-- DONATION AMOUNT BOX-->
                <asp:TextBox ID="Money_txtb" runat="server" placeholder="Donation amount" class="form-control"></asp:TextBox>&nbsp
                <asp:DropDownList ID="Money_ddl" runat="server">
                    <asp:ListItem>£ (pounds)</asp:ListItem>
                    <asp:ListItem>€ (euro)</asp:ListItem>
                    <asp:ListItem>Lei</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Money_txtb" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Money_txtb" ErrorMessage="Invalid amount" Type="Currency" ForeColor="Red" MinimumValue="0" MaximumValue="9999999999999999"></asp:RangeValidator>
                <br />

                <!-- ADD BUTTON -->
                <asp:Button ID="AddClient_btn" runat="server" Text="Add New Client" class="btn btn-primary btn" OnClick="AddClient_btn_Click" />
                <br /><br />
                <asp:Label ID="TotalD_lbl" runat="server"></asp:Label>
            </div><!-- /input-group -->
        </div><!-- /.span6 -->
    </div><!-- /.row -->
</asp:Content>

