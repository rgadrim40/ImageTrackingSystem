<%@ Page Title="User-Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditUserProfile.aspx.vb" Inherits="techpromediainc.com.EditUserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Use the form below to update your information.</h2>
    </hgroup>
    <div class="InputForm">
    <article>
        <section id="InfoForm">
                    <fieldset>
                        <legend>Information Form</legend>
                        <table>
                            <tr>
                                <td>First Name:</td>
                                <td>
                                    <asp:TextBox ID="lclFirstName" runat="server" ToolTip="First Name"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Last Name:</td>
                                <td>
                                    <asp:TextBox ID="lclLastName" runat="server" ToolTip="Last Name"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Address-1:</td>
                                <td>
                                    <asp:TextBox ID="lclAddress1" runat="server" ToolTip="Address 1"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Address-2:</td>
                                <td>
                                    <asp:TextBox ID="lclAddress2" runat="server" ToolTip="Address 2"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>City:</td>
                                <td>
                                    <asp:TextBox ID="lclCity" runat="server" ToolTip="City"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>State:</td>
                                <td>
                                    <asp:TextBox ID="lclState" runat="server" ToolTip="State"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Email:</td>
                                <td>
                                    <asp:TextBox ID="lclEmail" runat="server" ToolTip="Email"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>UserName:</td>
                                <td>
                                    <asp:TextBox ID="lclUserName" runat="server" ToolTip="UserName"></asp:TextBox></td>
                            </tr>
                        </table>
                </fieldset>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </section>
    </article>
        <aside>
            <h3>Message</h3>
            <asp:Panel ID="ErrorPnl" runat="server" Visible="false">
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="MessagePnl" runat="server" Visible="false">
                <asp:Label runat="server" ID="lblMessage" Font-Bold="True" Font-Italic="True" Font-Size="X-Large" ForeColor="#575757"></asp:Label>
            </asp:Panel>
        </aside>
        <asp:HiddenField ID="hiddenRowID" runat="server" />
    </div>
</asp:Content>

