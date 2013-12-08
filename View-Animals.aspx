<%@ Page Title="Our Animals" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="View-Animals.aspx.cs" Inherits="View_Animals" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row-fluid">
        <div class="span5">
            <h3>Our Animals</h3>
            These is the list of the animals that need your help!
            
        </div><!-- /.span4 -->

        <div class="span4">
            <h4>View By</h4>

            <div class="field-group">

                <div class="field">
                    <asp:DropDownList ID="DDLViewBy" 
                        AutoPostBack="true" style="float:left;"
                        OnSelectedIndexChanged="DDLViewBy_OnSelectedIndexChanged"
                        runat="server">
                        <asp:ListItem Value="0">Select view by...</asp:ListItem>
                        <asp:ListItem Value="2">Spieces</asp:ListItem>
                        <asp:ListItem Value="1">Breeds</asp:ListItem>
                        <asp:ListItem Value="3">Sanctuary</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DDLFilter" 
                        runat="server">
                        <asp:ListItem Value="0">...</asp:ListItem>
                    </asp:DropDownList>
                    </div><!-- /.field -->
                <div class="field">
                    <asp:Button ID="BFilter" 
                        OnClick="BFiltert_Click" 
                        runat="server" 
                        Text="Filter" 
                        CssClass="btn btn-primary" />
                </div><!-- /.field -->

            </div><!-- /.field-group -->
            
        </div><!-- /.span8 -->

    </div><!-- /.row-fluid -->

    <br />

    <div class="row-fluid">

        <div class="span12">

            <asp:PlaceHolder runat="server" ID="WarningMessage" Visible="false">
                    <div class="alert alert-warning" style="width:320px;">
                        <asp:Literal runat="server" ID="WarningText" />
                    </div>
            </asp:PlaceHolder>
            <asp:GridView ID="GVPetsDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No records..."
                onpageindexchanging="GVPetsDetails_PageIndexChanging" >

                <columns>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:ImageField ControlStyle-Height="90" DataImageUrlField="PicturePath" dataimageurlformatstring="~\img\Upload\{0}" HeaderText="Picture"></asp:ImageField>
                    <asp:boundfield datafield="Breed.Name" headertext="Breed"/>
                    <asp:boundfield datafield="Spieces.Name" headertext="Spieces"/>
                    <asp:boundfield datafield="Sanctuary.Name" headertext="Sanctuary"/>
                    <asp:boundfield datafield="ageString" headertext="Age"/>
                    <asp:boundfield datafield="GenderString" headertext="Gender"/>
                    <asp:boundfield datafield="WeightKg" headertext="Weight"/>
                    <asp:boundfield datafield="RescueDShort" headertext="Rescue date"/>
                </columns>

            </asp:GridView>
           
        </div><!-- /.span12 -->

    </div><!-- /.row-flui -->

</asp:Content>
