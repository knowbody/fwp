<%@ Page Title="Manage Users" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Manage-Users.aspx.cs" Inherits="Manage_Users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Users</h3>

    <div class="row-fluid">

        <div class="span4">
            <h4>Create New User</h4>

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
                    <asp:Label ID="LabelWeight"
                           Text="Spieces Name"
                           AssociatedControlID="TBSpiece"
                           runat="server" />
                    <asp:TextBox ID="TBSpiece" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBSpiece" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Button ID="BAddSpiece" runat="server" OnClick="BAddSpiece_Click" Text="Add New Spieces" CssClass="btn btn-primary btn" />
                </div><!-- /.field -->
                
            </div><!-- /.input-group -->

        </div><!-- /.span4 -->

        <div class="span4">
            <h4>Spieces List</h4>

            <asp:PlaceHolder runat="server" ID="WarningMessage" Visible="false">
                    <div class="alert alert-warning" style="width:320px;">
                        <asp:Literal runat="server" ID="WarningText" />
                    </div>
            </asp:PlaceHolder>

            <asp:GridView ID="gvSpiecesDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No data available..." 
                OnRowDeleting="gvSpiecesDetails_OnRowDeleting"
                OnRowDeleted="gvSpiecesDetails_OnRowDeleted"
                OnRowDataBound = "gvSpiecesDetails_OnRowDataBound"
                onpageindexchanging="gvSpiecesDetails_PageIndexChanging">

                <columns>
                    <asp:boundfield datafield="ID" headertext="Id"/>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" HeaderText="Action" ButtonType="Button" />
                </columns>

            </asp:GridView>
        </div><!-- /.span4 -->

    </div><!-- /.row-fluid -->

</asp:Content>
