<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Assignments.aspx.vb" Inherits="techpromediainc.com.Assignments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <p>
               Welcome! This is my assignments page, here you will find information <br />
                about my assignments when they are completed..
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Assignments:</h3>
    <article>
        <ol class="round">
            <li class="one">
                <h5>Assignment I</h5>
                <p>Website up and running - Using Arvixe hosting, with .net, php and sql server.</p>
            </li>
            <li class="two">
                <h5>Assignment II</h5>
                    <p>Website has ability for user to register user name and password then will be redirected<br /> 
                    to register credentials through a form before they enter site, also user can retrive information.<br />
                    Database is created for storing the users credentials and has connection string linking to database,<br />
                    for accessing the data.</p>
            </li>
            <li class="three">
                <h5>Assignment III</h5>
                   <p>once the user has registered and logged in the user has an option available to Edit Profile 
                       Information. Clicking on this information will bring up the edit form with any current data 
                       in the fields. The data is saved to the database and the user is returned to the previous 
                       screen</p>                 
            </li>
            <li class="four">
                <h5>Assignment IV</h5>
                   <p>Have created the ability to select from a grid and edit or view records, also with the ability to insert new records per user,
                       the user will only see their records for editing or deleting. when deleting a record the record is set to inactive.
                   </p>                 
            </li>
            <li class="five">
                <h5>Assignment V</h5>
                   <p>Have created the appropriate documentation for the assignment as requested from the project.
                   </p>                 
            </li>
            <li class="six">
                <h5>Assignment VI</h5>
                   <p>Have created a repository and submitted the appropriate form.
                   </p>                 
            </li>

        </ol>
    </article>
    <aside>
        <h3>Information</h3>
        <ul>
            <li><a id="A1" runat="server" href="EditUserProfile.aspx">Edit Profile Information</a></li>
            <li><a id="A2" runat="server" href="#">Assignment Information</a></li>
        </ul>    
        <h3>Follow-Us</h3>
        <ul>
            <li><a id="A4" runat="server" href="#">Facebook</a></li>
            <li><a id="A5" runat="server" href="#">Twitter</a></li>
            <li><a id="A6" runat="server" href="#">Linkedin</a></li>
        </ul>    
    </aside>
</asp:Content>
