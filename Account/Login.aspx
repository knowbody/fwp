<%@ Page Title="Staff Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <div class="row-fluid">
        <div class="span7">
            <section id="loginForm">
                
                <fieldset class="form-horizontal">
                    <legend></legend>
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-error">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="control-group">
                        <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TBEmail" CssClass="control-label">Email</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="TBEmail" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBEmail"
                                CssClass="text-error" ErrorMessage="The user name field is required." />
                        </div>
                    </div>

                    <div class="control-group">
                        <asp:Label ID="LabelPassword" runat="server" AssociatedControlID="TBPass" CssClass="control-label">Password</asp:Label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="TBPass" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TBPass" CssClass="text-error" ErrorMessage="The password field is required." />
                        </div>
                    </div>

                    <div class="form-actions no-color">
                        <asp:Button ID="Button1" runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-primary" />
                    </div>
                </fieldset>
            </section>
        </div>

        
    </div>
</asp:Content>

