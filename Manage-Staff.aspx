<%@ Page Title="Manage Staff" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Manage-Staff.aspx.cs" Inherits="Manage_Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Staff</h3>

    <div class="row-fluid">
        <div class="span5">
            <p>On this page you can create new staff or delete existing one. All fields are required.</p>
        </div><!-- /.span6 -->
    </div><!-- /.row-fluid -->

    <div class="row-fluid">

        <div class="span4">
            <h4>Create New Member</h4>

            <div class="input-group">

                <asp:PlaceHolder runat="server" ID="SuccessMessage" Visible="false">
                    <div class="alert alert-success" style="width:170px;">
                        <asp:Literal runat="server" ID="SuccessText" />
                    </div>
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <div class="alert alert-error" style="width:170px;">
                        <asp:Literal runat="server" ID="ErrorText" />
                    </div>
                </asp:PlaceHolder>

                <div class="field">
                    <asp:Label ID="LabelFirstName"
                           Text="First Name"
                           AssociatedControlID="TBFirstName"
                           runat="server" />
                    <asp:TextBox ID="TBFirstName" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBFirstName" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelSecondName"
                           Text="Last Name"
                           AssociatedControlID="TBLastName"
                           runat="server" />
                    <asp:TextBox ID="TBLastName" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBLastName" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelEmail"
                           Text="Email"
                           AssociatedControlID="TBEmail"
                           runat="server" />
                    <asp:TextBox ID="TBEmail" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBEmail" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelPassword"
                           Text="Password"
                           AssociatedControlID="TBPassword"
                           runat="server" />
                    <asp:TextBox runat="server" ID="TBPassword" TextMode="Password" />&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBPassword" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelPasswordRep"
                           Text="Repeat Password"
                           AssociatedControlID="TBPasswordRep"
                           runat="server" />
                    <asp:TextBox runat="server" ID="TBPasswordRep" TextMode="Password" />&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBPasswordRep" />
                </div><!-- /.field -->

                <div class="field">
                     <asp:Label ID="Label1"
                           Text="Access Level"
                           AssociatedControlID="DDLAccess"
                           runat="server" />
                    <asp:DropDownList ID="DDLAccess" runat="server">
                        <asp:ListItem Value="0">Select access level...</asp:ListItem>
                        <asp:ListItem Value="2">Moderator</asp:ListItem>
                        <asp:ListItem Value="1">Administrator</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.field -->

                <div class="field">
                    <asp:Button ID="BAddStaff" runat="server" OnClick="BAddStaff_Click" Text="Add New Staff Member" CssClass="btn btn-primary btn" />
                </div><!-- /.field -->
                
            </div><!-- /.input-group -->

        </div><!-- /.span4 -->

        <div class="span6">
            <h4>Staff List</h4>

            <asp:PlaceHolder runat="server" ID="WarningMessage" Visible="false">
                    <div class="alert alert-warning" style="width:320px;">
                        <asp:Literal runat="server" ID="WarningText" />
                    </div>
            </asp:PlaceHolder>

            <asp:GridView ID="GVUsersDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No data available..." 
                OnRowDeleting="GVUsersDetails_OnRowDeleting"
                OnRowDataBound = "GVUsersDetails_OnRowDataBound"
                onpageindexchanging="GVUsersDetails_PageIndexChanging">

                <columns>
                    <asp:boundfield datafield="ID" headertext="Id"/>
                    <asp:boundfield datafield="FullName" headertext="Name"/>
                    <asp:boundfield datafield="Email" headertext="Email"/>
                    <asp:boundfield datafield="AccessLevelName" headertext="Access Level"/>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" HeaderText="Action" ButtonType="Button" />
                </columns>

            </asp:GridView>
        </div><!-- /.span4 -->

    </div><!-- /.row-fluid -->

</asp:Content>
