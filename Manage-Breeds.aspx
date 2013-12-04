<%@ Page Title="Manage Breeds" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Manage-Breeds.aspx.cs" Inherits="Manage_Breeds" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Breeds</h3>

    <div class="row-fluid">

        <div class="span6">
            <div class="input-group">
                <asp:TextBox ID="TBBreed" runat="server" placeholder="Breed name" class="form-control"></asp:TextBox>
                <asp:DropDownList ID="DDLSpieces" runat="server"></asp:DropDownList>
                <asp:Button ID="BAddBreed" OnClick="BAddBreed_Click" runat="server" Text="Add New Breed" class="btn btn-primary btn" />
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.span6 -->

        <div class="span6">
            <asp:GridView ID="gvBreedsDetails" runat="server" class="table table-striped" Width="300px" GridLines="None" CellSpacing="-1"
                onpageindexchanging="gvBreedsDetails_PageIndexChanging">
            </asp:GridView>
        </div>
        <!-- /.span6 -->

    </div>
    <!-- /.row -->

</asp:Content>

