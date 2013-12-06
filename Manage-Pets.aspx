<%@ Page Title="Manage Pets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Manage-Pets.aspx.cs" Inherits="Manage_Pets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Manage Pets</h3>

    <div class="field-group">
        <asp:Button ID="ButtonSpieces" runat="server" OnClick="ButtonSpieces_Click" Text="Manage Spieces" CssClass="btn btn-primary btn" CausesValidation="False" />
        <asp:Button ID="ButtonBreeds" runat="server" OnClick="ButtonBreeds_Click" Text="Manage Breeds" CssClass="btn btn-primary btn" CausesValidation="False" />
    </div><!-- /.field-group -->

    <br />

    <div class="row">
        <div class="span3">
            <h4>Create New Pet</h4>
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
                    <asp:Label ID="LabelPetName"
                        Text="Name"
                        AssociatedControlID="TBName"
                        runat="server" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server"
                        Display="Dynamic"   
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBName"
                        CssClass="text-error">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="TBName" runat="server"></asp:TextBox>&nbsp;        
                    
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="Label2"
                       Text="Spieces"
                       AssociatedControlID="DDLSpieces"
                       runat="server" />
                    <asp:DropDownList ID="DDLSpieces" runat="server" 
                        AutoPostBack="true" 
                        OnDataBound="DDLSpieces_OnDataBound" 
                        OnSelectedIndexChanged="DDLSpieces_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelBreeds"
                       Text="Breed"
                       AssociatedControlID="DDLBreeds"
                       runat="server" />
                    <asp:DropDownList ID="DDLBreeds" 
                        OnDataBound="DDLBreeds_OnDataBound"
                        runat="server">
                    </asp:DropDownList>
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelSanctuary"
                       Text="Sanctuary"
                       AssociatedControlID="DDLSanctuary"
                       runat="server" />
                    <asp:DropDownList ID="DDLSanctuary" runat="server">
                        <asp:ListItem Value="1">Sanctuary 1</asp:ListItem>
                        <asp:ListItem Value="2">Sanctuary 2</asp:ListItem>
                        <asp:ListItem Value="3">Sanctuary 3</asp:ListItem>
                    </asp:DropDownList>
                </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelAge"
                       Text="Age"
                       AssociatedControlID="TBAge"
                       runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBAge" />
                    <asp:CompareValidator ID="CompareValidator3"  
                       Display="Dynamic" 
                       runat="server" 
                       CssClass="text-error" 
                       ControlToValidate="TBAge" 
                       Type="Double" 
                       Operator="DataTypeCheck" 
                       ErrorMessage="Only numbers" />
                    <asp:TextBox ID="TBAge" runat="server"></asp:TextBox>&nbsp;

               </div><!-- /.field -->

               <div class="field">
                    <asp:Label ID="Label1"
                       Text="Gender"
                       AssociatedControlID="RBLGender"
                       runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="RBLGender">
                   </asp:RequiredFieldValidator>
                   <asp:RadioButtonList ID="RBLGender" runat="server" RepeatDirection="Horizontal" CellPadding="5">
                   <asp:ListItem Value="1">Male</asp:ListItem>
                   <asp:ListItem Value="2">Female</asp:ListItem>
                   </asp:RadioButtonList>
               </div><!-- /.field -->

               <div class="field">
                    <asp:Label ID="LabelWeight"
                       Text="Weight (in Kg)"
                       AssociatedControlID="TBWeight"
                       runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server"
                        Display="Dynamic"  
                        CssClass="text-error"
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBWeight" />
                    <asp:CompareValidator ID="CompareValidator2"  
                       Display="Dynamic" 
                       runat="server" 
                       CssClass="text-error" 
                       ControlToValidate="TBWeight" 
                       Type="Double" 
                       Operator="DataTypeCheck" 
                       ErrorMessage="Only numbers" />
                    <asp:TextBox ID="TBWeight" runat="server"></asp:TextBox>&nbsp;
               </div><!-- /.field -->

               <div class="field">
                    <asp:Label ID="LabelBills"
                       Text="Vet Bills (in £)"
                       AssociatedControlID="TBBills"
                       runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                        Display="Dynamic"  
                        runat="server"
                        CssClass="text-error" 
                        ErrorMessage="Required Field" 
                        ControlToValidate="TBBills" />
                   <asp:CompareValidator ID="CompareValidator1"  
                       Display="Dynamic" 
                       runat="server" 
                       CssClass="text-error" 
                       ControlToValidate="TBBills" 
                       Type="Double" 
                       Operator="DataTypeCheck" 
                       ErrorMessage="Only numbers" />
                    <asp:TextBox ID="TBBills" runat="server"></asp:TextBox>&nbsp;
               </div><!-- /.field -->

                <div class="field">
                    <asp:Label ID="LabelPicture"
                       Text="Picture"
                       AssociatedControlID="FileUploadPicture"
                       runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                        Display="Dynamic"  
                        runat="server"
                        CssClass="text-error" 
                        ErrorMessage="Required Field" 
                        ControlToValidate="FileUploadPicture" /><br />
                   <asp:FileUpload ID="FileUploadPicture" runat="server" />
               </div><!-- /.field -->

               <br />

               <div class="field">
                    <asp:Label ID="LabelRescueDate"
                       Text="Rescue Date"
                       AssociatedControlID="CalendarRescue"
                       runat="server" />
                    <asp:Calendar ID="CalendarRescue" runat="server"></asp:Calendar>
               </div><!-- /.field -->

               <br />

               <div class="field">
                    <asp:Button ID="BAddPet" 
                        OnClick="BAddPet_Click" 
                        runat="server" 
                        Text="Add New Pet" 
                        CssClass="btn btn-primary" />
                </div><!-- /.field -->

            </div><!-- /.field-group -->

        </div><!-- /.span4 -->

        <div class="span9">
            <h4>Pets List</h4>

            <asp:PlaceHolder runat="server" ID="WarningMessage" Visible="false">
                    <div class="alert alert-warning" style="width:320px;">
                        <asp:Literal runat="server" ID="WarningText" />
                    </div>
            </asp:PlaceHolder>

            <strong>Total Maintenance Cost: </strong><asp:Label ID="LabelTotalCost" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="gvPetsDetails" runat="server" CssClass="table table-striped" GridLines="None" CellSpacing="-1"
                autogeneratecolumns="false"
                emptydatatext="No data available..."
                OnRowDeleting="gvPetsDetails_OnRowDeleting"
                OnRowDataBound = "gvPetsDetails_OnRowDataBound"
                onpageindexchanging="gvPetsDetails_PageIndexChanging" >

                <columns>
                    <asp:boundfield datafield="Id" headertext="ID"/>
                    <asp:boundfield datafield="Name" headertext="Name"/>
                    <asp:ImageField ControlStyle-Height="55" DataImageUrlField="PicturePath" dataimageurlformatstring="~\img\Upload\{0}" HeaderText="Picture"></asp:ImageField>
                    <asp:boundfield datafield="Breed.Name" headertext="Breed"/>
                    <asp:boundfield datafield="Spieces.Name" headertext="Spieces"/>
                    <asp:boundfield datafield="sanctuaryName" headertext="Sanctuary"/>
                    <asp:boundfield datafield="Age" headertext="Age"/>
                    <asp:boundfield datafield="GenderString" headertext="Gender"/>
                    <asp:boundfield datafield="WeightKg" headertext="Weight"/>
                    <asp:boundfield datafield="FormatedBills" headertext="Bills"/>
                    <asp:boundfield datafield="RescueDShort" headertext="Rescue date"/>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" HeaderText="Action" ButtonType="Button" />
                </columns>

            </asp:GridView>

        </div><!-- /.span8 -->

    </div><!-- /.row-fluid -->


    <script type="text/javascript">
        var deletePet = function(id) {
                
            };
        
    </script>
</asp:Content>