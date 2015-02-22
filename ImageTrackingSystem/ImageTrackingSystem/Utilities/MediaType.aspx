<%@ Page Title="Media Type" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MediaType.aspx.vb" Inherits="techpromediainc.com.MediaType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/Media.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <hgroup class="title">
            <h1><%: Title %>.</h1>
            <h2>This page allows for keeping track of Media types!</h2>
        </hgroup>
            <article>
                <section>
                    <asp:GridView ID="GridView1" runat="server" 
                        AllowPaging="True" 
                        AutoGenerateColumns="False" 
                        BackColor="White" 
                        BorderColor="#336666" 
                        BorderWidth="3px" 
                        CellPadding="4" 
                        DataKeyNames="RowID" 
                        DataSourceID="SqlDataMediaType" 
                        Height="131px" 
                        Width="578px" 
                        BorderStyle="Inset"
                        GridLines="Both">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="RowID" HeaderText="RowID" InsertVisible="False" ReadOnly="True" SortExpression="RowID" ShowHeader="False" Visible="False" />
                            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type">
                            <ControlStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LastUpdate" HeaderText="LastUpdate" InsertVisible="False" ReadOnly="True" SortExpression="LastUpdate" >
                            <ControlStyle Width="100px" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="Inactive" HeaderText="Inactive" SortExpression="Inactive" />
                            <asp:CommandField ShowDeleteButton="True" >
                            <ControlStyle Width="50px" />
                            </asp:CommandField>
                        </Columns>
                        <AlternatingRowStyle BackColor="#999999" />                
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                </section>
            </article>
            <aside>
                <asp:UpdatePanel ID="UpdateTypeGrid" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <h3>Message</h3>
                        <asp:Panel ID="MessagePnl" runat="server" Visible="true">
                            <asp:Label ID="lblMessage" runat="server" Font-Italic="True" ForeColor="#007979"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="ErrorPnl" runat="server" Visible="false">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </asp:Panel>
                        <asp:Panel ID="MessagesPnl" runat="server" Visible="false">
                            <asp:Label ID="lblMessages" runat="server" Font-Italic="True" ForeColor="#007979"></asp:Label>
                        </asp:Panel><br /><hr />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <input id="selectInsertBtn" type="button" value="Insert New Record" />
                <br /><br />
                <article>
                    <section>
                        <div id="divMedia">
                        <fieldset id="formMedia">
                            <legend>Information Form</legend>
                            <table>
                                <tr>
                                    <td>Media Type:</td>
                                    <td><asp:TextBox ID="lclType" runat="server" ToolTip="Type of Media" Width="200px" Height="20px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </fieldset>
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Submit" />
                        <input id="btnCancel" type="button" value="Cancel" />
                        </div>
                    </section>
                </article>
            </aside>

            <asp:SqlDataSource ID="SqlDataMediaType" runat="server" ConnectionString="<%$ ConnectionStrings:FormData %>" 
                SelectCommand="SELECT * FROM [MediaType]" 
                DeleteCommand="UPDATE [MediaType] SET [Inactive] = 1, [InactiveDate] = getdate(), [LastUpdate] = getdate() WHERE [RowID] = @RowID" 
                UpdateCommand="UPDATE [MediaType] SET [Type] = @Type, [Inactive] = @Inactive, [InactiveDate] = @InactiveDate, [LastUpdate] = getdate() WHERE [RowID] = @RowID">
                <DeleteParameters><asp:Parameter Name="RowID" Type="Int32" /></DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Type" Type="String" />
                    <asp:Parameter Name="Inactive" Type="Boolean" />
                    <asp:Parameter Name="InactiveDate" Type="DateTime" />
                    <asp:Parameter Name="LastUpdate" Type="DateTime" />
                    <asp:Parameter Name="RowID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </asp:Content>
