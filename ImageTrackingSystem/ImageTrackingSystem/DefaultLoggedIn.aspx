<%@ Page Title="Logged-In" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultLoggedIn.aspx.vb" Inherits="techpromediainc.com.DefaultLoggedIn" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
               Welcome! Thank you for joining my site.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <h3>A little Information About Us:</h3>
    <article>
        <ol class="round">
            <li class="one">
                <h5>Dark Moon Media</h5>
                is here to work with you to create a custom website design that will educate your customers on 
                who you are, what you do, and how you can help them. Our focus is to design a website that 
                will allow you to connect to your customers and provide them with a good first impression 
                when they visit your site. Our design team is here to help turn a potential client into a 
                loyal customer just from visiting your website. We offer professional, custom, high quality 
                web design services. All of our websites are custom designed to meet every client's needs and 
                requirements. 
            </li>
            <li class="two">
                <h5>Make An Impression</h5>
                First impressions can never be taken back and they are essential when you are conducting 
                business. Your website can tell your customer everything they want to know about your 
                business, so we are here to help you design a website that conveys everything you want. 
                A website can make or break your business. Your website is at the center of your marketing 
                and all that you do to promote your business. Our focus is to get to know you and your 
                company so that we can illustrate your company philosophy through the website we design 
                for you. We want to help you build a relationship between your company and your customers.
            </li>
            <li class="three">
                <h5>Web Design</h5>
                we believe that users should have the same, awesome experience on their 
                desktop, laptop, tablet, and mobile devices. For that reason, all of the 
                websites that we build work flawless on any device and give you the same, 
                gorgeous functionality, regardless of your Internet surfing weapon of choice. 
                We want to make your experience with your website more intimate than ever. 
                Yellow pages are dead and traditional marketing such as billboards, TV, and 
                print are changing their focus towards driving people to the Internet. This 
                shift in the way we gather information affects every business owner. It has 
                become absolutely imperative for companies and marketers to keep their web-presence 
                up to date with information surrounding their business; Hours of operation, 
                holiday schedules, and promotions.
            </li>
        </ol>
    </article>
    <aside>
        <h3>Information</h3>
        <ul>
            <li><a id="A1" runat="server" href="Utilities/EditUserProfile.aspx">Edit Profile Information</a></li>
            <li><a id="A2" runat="server" href="Utilities/Assignments.aspx">Assignment Information</a></li>
        </ul>    
        <h3>Follow-Us</h3>
        <ul>
            <li><a id="A4" runat="server" href="#">Facebook</a></li>
            <li><a id="A5" runat="server" href="#">Twitter</a></li>
            <li><a id="A6" runat="server" href="#">Linkedin</a></li>
        </ul>    
        <h3>Management</h3>
        <ul>
            <li><a id="A7" runat="server" href="Utilities/MediaGrid.aspx">Manage Media</a></li>
            <li><a id="A3" runat="server" href="Utilities/MediaType.aspx">Manage Media Types</a></li>
            <li><a id="A8" runat="server" href="Utilities/ImageRecord.aspx">Imaging Record</a></li>
            <li><a id="A9" runat="server" href="Utilities/ImageItems.aspx">Manage Image Items</a></li>
        </ul>    
        <h3>Project</h3>
        <ul>
            <li><a id="A13" runat="server" href="ImageTrackingSystem/Default.aspx">Image Tracking System</a></li>
        </ul>    
    </aside>
</asp:Content>
