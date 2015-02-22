<%@ Page Title="Image Tracking System" Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="ImageTrackingSystem_Default" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
               Welcome! Thank you for for the interest in the system.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <h3>A little Information About ITS:</h3>
    <article>
        <ol class="round">
            <li class="one">
                <h5>Image Tracking System</h5>
                is here to work with you to create a custom website design that will educate your customers on 
                who you are, what you do, and how you can help them. Our focus is to design a website that 
                will allow you to connect to your customers and provide them with a good first impression 
                when they visit your site. Our design team is here to help turn a potential client into a 
                loyal customer just from visiting your website. We offer professional, custom, high quality 
                web design services. All of our websites are custom designed to meet every client's needs and 
                requirements. 
            </li>
        </ol>
    </article>
    <aside>
        <h3>Management</h3>
        <ul>
            <li><a id="A8" runat="server" href="~/Utilities/ImageRecord.aspx">Imaging Record</a></li>
            <li><a id="A9" runat="server" href="~/Utilities/ImageItems.aspx">Manage Image Items</a></li>
        </ul>    
    </aside>
</asp:Content>
