<%@ Page Title="Manage Breeds" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Manage-Breeds.aspx.cs" Inherits="Manage_Breeds" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Manage Breeds</h3>

    <div class="row-fluid">
        <div class="span6">
            <p>On this page you can create new breeds or delete existing one. All fields are required. Alternatively, to manage pets or spieces, click on the buttons bellow.</p>
        </div><!-- /.span6 -->
    </div><!-- /.row-fluid -->

    <div class="field-group">
        <asp:Button ID="ButtonPets" runat="server" OnClick="ButtonPets_Click" Text="Manage Pets" CssClass="btn btn-primary btn" CausesValidation="False" />
        <asp:Button ID="ButtonSpieces" runat="server" OnClick="ButtonSpieces_Click" Text="Manage Spieces" CssClass="btn btn-primary btn" CausesValidation="False" />
        <asp:Button ID="ButtonDonation" runat="server" OnClick="ButtonDonation_Click" Text="Donation overview" CssClass="btn btn-primary btn" CausesValidation="False" />
    </div><!-- /.field-group -->

    <br />

    <div class="row-fluid">

        <div class="span4">
            <h4>Create New Breed</h4>
            <div class="field-group">

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
                    <asp:Label ID="LabelBreedName"
                       Text="Breed Name"
                       AssociatedControlID="TBBreedName"
                       runat="server" />
                    <asp:TextBox ID="TBBreedName" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBBreedName" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelSpieces"
                       Text="Spieces"
                       AssociatedControlID="DDLSpieces"
                       runat="server" />
                    <asp:DropDownList ID="DDLSpieces" runat="server"></asp:DropDownList>
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelFoodPrice"
                       Text="Food Cost per KG (in £)"
                       AssociatedControlID="TBFoodPrice"
                       runat="server" />
                    <asp:TextBox ID="TBFoodPrice" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBFoodPrice" />
                    <asp:CompareValidator ID="CompareValidator1"  
                       Display="Dynamic" 
                       runat="server" 
                       CssClass="text-error" 
                       ControlToValidate="TBFoodPrice" 
                       Type="Double" 
                       Operator="DataTypeCheck" 
                       ErrorMessage="Only numbers" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelHousingCosts"
                       Text="Housing Costs (in £)"
                       AssociatedControlID="TBHousingCosts"
                       runat="server" />
                    <asp:TextBox ID="TBHousingCosts" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBHousingCosts" />
                    <asp:CompareValidator ID="CompareValidator3"  
                       Display="Dynamic" 
                       runat="server" 
                       CssClass="text-error" 
                       ControlToValidate="TBHousingCosts" 
                       Type="Double" 
                       Operator="DataTypeCheck" 
                       ErrorMessage="Only numbers" />
                </div><!-- /.field -->

                <div class="field">
                    <asp:Button ID="BAddBreed" 
                        OnClick="BAddBreed_Click" 
                        runat="server" 
                        Text="Add New Breed" 
                        CssClass="btn btn-primary btn" />
                </div><!-- /.field -->

            </div><!-- /.field-group -->

        </div><!-- /.span4 -->

        <div class="span7">
            <h4>Breeds List</h4>

            <asp:PlaceHolder runat="server" ID="WarningMessage" Visible="false">
                    <div class="alert alert-warning" style="width:320px;">
                        <asp:Literal runat="server" ID="WarningText" />
                    </div>
            </asp:PlaceHolder>

            <asp:GridView ID="gvBreedsDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No data available..."
                OnRowDeleting="gvBreedsDetails_OnRowDeleting"
                OnRowDataBound = "gvBreedsDetails_OnRowDataBound"
                onpageindexchanging="gvBreedsDetails_PageIndexChanging" >

                <columns>
                    <asp:boundfield datafield="ID" headertext="Id"/>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:boundfield datafield="Spieces.Name" headertext="Spieces"/>
                    <asp:boundfield datafield="FormatedFoodCost" headertext="Food Cost"/>
                    <asp:boundfield datafield="FormatedhousCost" headertext="Housing Cost"/>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" HeaderText="Action" ButtonType="Button" />
                </columns>

            </asp:GridView>
        </div><!-- /.span7 -->

    </div><!-- /.row -->

</asp:Content>

