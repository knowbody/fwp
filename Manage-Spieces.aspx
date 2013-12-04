<%@ Page Title="Manage Spieces" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Manage-Spieces.aspx.cs" Inherits="Manage_Spieces" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Spieces</h3>

    <div class="row-fluid">

        <div class="span6">
            <div class="input-group">
                <asp:TextBox ID="TBSpiece" runat="server" placeholder="Spiece name" class="form-control"></asp:TextBox>
                <asp:Button ID="BAddSpiece" runat="server" OnClick="BAddSpiece_Click" Text="Add New Spiece" class="btn btn-primary btn" />
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-md-2 -->

        <div class="span6">
            <asp:GridView ID="gvSpiecesDetails" runat="server" class="table table-striped" Width="300px" GridLines="None" CellSpacing="-1"
                onpageindexchanging="gvSpiecesDetails_PageIndexChanging">
            </asp:GridView>
        </div>
        <!-- /.col-md-10 -->

    </div>
    <!-- /.row -->

</asp:Content>
