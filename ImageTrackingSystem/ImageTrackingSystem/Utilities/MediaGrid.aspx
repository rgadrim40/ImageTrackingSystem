<%@ Page Title="Media Information" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MediaGrid.aspx.vb" Inherits="techpromediainc.com.MediaGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/Media.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>This page is for keeping track of Media!</h2>
    </hgroup>
    <input id="btnInsert" type="button" value="Insert New Record" />        
    <br /><br />       
    <label id="lclDesciptLbl">Sort Records by Name or Inactive</label>
    <asp:Label runat="server" Text="Inactive: "><asp:DropDownList ID="ddlInactive" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
        <asp:ListItem Text="--Select--" Value="" />
        <asp:ListItem Text="All" Value="all" />
        <asp:ListItem Text="False" Value="false" />
        <asp:ListItem Text="True" Value="true" />
    </asp:DropDownList></asp:Label>
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="RowID" 
                DataSourceID="SqlDataMedia" 
                FooterStyle-HorizontalAlign="Center" 
                PagerStyle-HorizontalAlign="Center" 
                AllowPaging="True" 
                PageSize="5" 
                ShowFooter="True" 
                Caption="Media Grid" 
                AlternatingRowStyle-BackColor="#999999" 
                BackColor="White" 
                BorderColor="#333333" 
                BorderStyle="Solid" 
                BorderWidth="3px" 
                CellPadding="4" 
                GridLines="Horizontal">
                <Columns>
                   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:linkButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click"></asp:linkButton>
                        </ItemTemplate>
                    </asp:TemplateField>           
                    <asp:BoundField DataField="RowID" HeaderText="Record" InsertVisible="False" ReadOnly="True" SortExpression="RowID" Visible="true" ShowHeader="true" HeaderStyle-HorizontalAlign="Center" >
                    </asp:BoundField>
                    <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="UserName" >
                    <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MType" HeaderText="Type" SortExpression="MType" >
                    <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MName" HeaderText="Name" SortExpression="MName" >
                    <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MDescription" HeaderText="Description" SortExpression="MDescription" >
                    <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MDate" HeaderText="Date" SortExpression="MDate" >
                    <ControlStyle Width="100px" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="Inactive" HeaderText="Inactive" SortExpression="Inactive" >
                    <ControlStyle Width="25px" />
                    </asp:CheckBoxField>
                    <asp:BoundField DataField="InactiveDate" HeaderText="InactiveDate" SortExpression="InactiveDate" Visible="False" ShowHeader="False" />
                    <asp:BoundField DataField="LastUpdate" HeaderText="LastUpdate" SortExpression="LastUpdate" Visible="False" ShowHeader="False" />
                    <asp:CommandField ShowDeleteButton="True" />
                   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:linkButton ID="btnReview" runat="server" Text="Review"  OnClick="btnReview_Click"></asp:linkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="#999999"></AlternatingRowStyle>
                <FooterStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></FooterStyle>
                <HeaderStyle HorizontalAlign="Center" BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" Mode="NextPreviousFirstLast" />
                <PagerStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></PagerStyle>
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <br /><br /><hr /> 

    <article>
        <section>
            <Div ID="divMedia">
                <fieldset id="formMedia">
                    <legend>Information Form</legend>
                    <table>
                        <tr>
                            <td>UserName:</td>
                            <td><asp:TextBox ID="lclUserName" runat="server" ToolTip="UserName" Width="200px" Height="20px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Media Type:</td>
                            <td><asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataType" DataTextField="Type" DataValueField="Type" Width="200px" Height="20px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Media Name:</td>
                            <td><asp:TextBox ID="lclMediaName" runat="server" ToolTip="Media Name" TextMode="SingleLine" Width="200px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td><asp:TextBox ID="lclDescription" runat="server" ToolTip="Description" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Media Date:</td>
                            <td><asp:TextBox ID="lclMediaDate" runat="server" Visible="true" TextMode="Date" ToolTip="Media Date" Width="200px" Height="20px" /></td>
                        </tr>
                    </table>
                </fieldset>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" />
                <input id="btnCancel" type="button" value="Cancel" />
            </Div>
            <asp:Panel id="reviewPnl" runat="server" Visible="false">
                <fieldset id="Fieldset1">
                    <legend>Information Form</legend>
                    <table>
                        <tr>
                            <td>UserName:</td>
                            <td><asp:label id="reviewUser" runat="server" onmouseover="UserName"></asp:label></td>
                        </tr>
                        <tr>
                            <td>Media Type:</td>
                            <td><asp:label id="reviewType" runat="server" onmouseover="Type"></asp:label></td>
                        </tr>
                        <tr>
                            <td>Media Name:</td>
                            <td><asp:label id="reviewName" runat="server" onmouseover="Name"></asp:label></td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td><asp:label id="reviewDescript" runat="server"  onmouseover="Description"></asp:label></td>
                        </tr>
                        <tr>
                            <td>Media Date:</td>
                            <td><asp:label id="reviewDate" runat="server" onmouseover="Date"></asp:label></td>
                        </tr>
                        <tr>
                            <td>Media Inactive:</td>
                            <td><asp:CheckBox ID="reviewInactive" runat="server" ToolTip="Inactive" /></td>
                        </tr>
                    </table>
                </fieldset>
                <input id="btnCancel3" type="button" value="Cancel" />
            </asp:Panel>            
            <asp:Panel id="editPnl" runat="server" Visible="false">
                <fieldset id="Fieldset2">
                    <legend>Information Form</legend>
                    <table>
                        <tr>
                            <td>UserName:</td>
                            <td><asp:TextBox ID="editUserName" runat="server" ToolTip="UserName" Width="200px" Height="20px" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Media Type:</td>
                            <td><asp:DropDownList ID="editDDlType" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataType" DataTextField="Type" DataValueField="Type" Width="200px" Height="20px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Media Name:</td>
                            <td><asp:TextBox ID="editName" runat="server" ToolTip="Media Name" TextMode="SingleLine" Width="200px" Height="20px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td><asp:TextBox ID="editDescript" runat="server" ToolTip="Description" TextMode="MultiLine" Width="200px" Height="50px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Media Date:</td>
                            <td><asp:TextBox ID="editDate" runat="server" Visible="true" ToolTip="Media Date" Width="200px" Height="20px" /></td>
                        </tr>
                        <tr>
                            <td>Media Inactive:</td>
                            <td><asp:CheckBox ID="editInactive" runat="server" ToolTip="Inactive" /></td>
                        </tr>
                    </table>
                </fieldset>
                <asp:Button ID="btnSave2" runat="server" OnClick="btnSave_Click" Text="Submit" />
                <input id="btnCancel2" type="button" value="Cancel" />
            </asp:Panel>                
        </section>
    </article>
        <aside>
            <h3>Message</h3>
            <asp:Panel ID="MessagePnl" runat="server" Visible="true">
                <asp:Label ID="lblMessage" runat="server" Font-Italic="True" ForeColor="#007979"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="ErrorPnl" runat="server" Visible="false">
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="MessagesPnl" runat="server" Visible="false">
                <asp:Label ID="lblMessages" runat="server" Font-Italic="True" ForeColor="#007979"></asp:Label>
            </asp:Panel>
        </aside>
              
        <asp:SqlDataSource ID="SqlDataForm" runat="server" />
        <asp:SqlDataSource ID="SqlDataMediaName" runat="server" />
        <asp:SqlDataSource ID="SqlDataInactive" runat="server" />
        <asp:SqlDataSource ID="SqlDataType" runat="server" />
        <asp:SqlDataSource ID="SqlDataMedia" runat="server" OnSelecting="SqlDataMedia_Selecting">
                       
                <DeleteParameters><asp:Parameter Name="RowID" Type="Int32" /></DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="UserName" Type="String" />
                    <asp:Parameter Name="MType" Type="String" />
                    <asp:Parameter Name="MName" Type="String" />
                    <asp:Parameter Name="MDescription" Type="String" />
                    <asp:Parameter Name="MDate" Type="DateTime" />
                    <asp:Parameter Name="Inactive" Type="Boolean" />
                    <asp:Parameter Name="InactiveDate" Type="DateTime" />
                    <asp:Parameter Name="LastUpdate" Type="DateTime" />
                    <asp:Parameter Name="RowID" Type="Int32" />
               </UpdateParameters>
            <SelectParameters>
                <asp:Parameter Name="UserName" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>   
        <asp:HiddenField ID="hiddenRowID" runat="server" />
        <asp:HiddenField ID="hiddenUser" runat="server" />
        <asp:HiddenField ID="hiddenBox" runat="server" />
</asp:Content>
