<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="techpromediainc.com._Default" %>

<asp:Content runat="server" ID="HeadContent" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
               You may login to Dark Moon Media if you are registered or select register to create an account.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>This site is for Members Only! You Must Login or Register</h3>
</asp:Content>