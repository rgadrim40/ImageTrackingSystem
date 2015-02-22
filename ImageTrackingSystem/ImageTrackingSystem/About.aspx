<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="techpromediainc.com.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Welcome to my About page.</h2>
    </hgroup>

    <article>
        <p> 
            <p id="P1"><img id="lclLogo" src="images/website_trans.png" alt=""/>       
            I'm an Interactive Web Designer, based in Orlando, Florida where I, among other things practiced 
            Web Design. In my profession I have had the Opportunity to learn and intigrate many of the new 
            technics that has become popular in todays web design field. I'm passionate about all aspects 
            of interactive Web design and I pride myself in maintaining high standards and design work of 
            the highest caliber. I pay very strong attention to detail and try to stay abreast of industry 
            best practices for design and processes. One of my core values is to give 100% Original and 
            Innovative designs and solutions to the clients and have success in achieving high satisfaction 
            through my latest development methods. I follow Agile Development Methodology which is the most 
            efficient way to execute the project through cross functional and collaborative teams with our clients. 
            Agile Methodology makes it easy to adapt things according to the changing environments and also 
            makes it simple to understand the requirements of the customers and mold the development process 
            accordingly.
        </p>
        <br /><hr><br />
        <p>  
            <p id="P2"><img id="Img1" src="images/image67.png" alt=""/>      
            My name is Richard Gadrim an Orlando based designer and programmer with 4 years experience. 
            I have a passion for creating, programming, and designing websites. Also, combining a considered 
            approach with emerging technologies. I have a wide ranging experience in design from web and 
            mobile design through to large scale interactive programming installations. My portfolio is a 
            mix of work created independently and as part of studies. If you are interested in working together 
            I'm available for freelance, contract or direct client projects, some examples of my work and details 
            can be found below.
        </p>

        <p>        
            Use this area to provide additional information.
        </p>
    </article>

    <aside>
        <h3>News</h3>
        <p>        
            Menu of links for adittional Information!
        </p>
        <h3>Follow-Us</h3>
        <ul>
            <li><a id="A4" runat="server" href="#">Facebook</a></li>
            <li><a id="A5" runat="server" href="#">Twitter</a></li>
            <li><a id="A6" runat="server" href="#">Linkedin</a></li>
        </ul>    
    </aside>
</asp:Content>