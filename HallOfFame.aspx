<%@ Page Title="Hall Of Fame" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="HallOfFame.aspx.cs" Inherits="HallOfFame" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>HALL OF FAME</h3>
    <div class="row-fluid">
        <div class="span6 offset3">
            
            <!-- GRID VIEW WITH DONATORS DETAILS -->
            <asp:GridView ID="GVFameDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1" autogeneratecolumns="false">
                <columns>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                </columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>