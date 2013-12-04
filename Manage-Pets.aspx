<%@ Page Title="Manage Pets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Manage-Pets.aspx.cs" Inherits="Manage_Pets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Manage Spieces" class="btn btn-primary btn" />
    </div>

    <br />

    <div class="row">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Manage Breeds" class="btn btn-primary btn" />
    </div>

</asp:Content>