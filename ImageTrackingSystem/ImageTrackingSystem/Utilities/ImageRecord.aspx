<%@ Page Title="" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="ImageRecord.aspx.vb" Inherits="Utilities_ImageRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Content/Site.css" rel="stylesheet" />    
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/Image.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="pnlContent" BorderStyle="none" HorizontalAlign="center" Width="100%" runat="server">
        <asp:Panel ID="pnlHeader" CssClass="Body_Panel" runat="server">
            <asp:Panel ID="pnlCaption" runat="server" CssClass="Caption">
                <asp:Label ID="lblCaption" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlGreet" runat="server" CssClass="Greet">
                <asp:Label ID="lblGreet" runat="server" Text="&nbsp;&nbsp;Hello "></asp:Label>
            </asp:Panel>
        </asp:Panel> 
    </asp:panel>
<!------------------------------------------------General Panel---------------------------------------------------------------->
    <asp:Panel ID="pnlBody" runat="server" CssClass="Body_Panel">
        <asp:Panel ID="GenCompPnl" runat="server" Height="150px">
          <div id="NewDiv">
            <asp:Table ID="lclCompInfoTbl" runat="server" CssClass="Table">
                <asp:TableRow ID="TableRow16" runat="server">
                    <asp:TableCell ID="TableCell34" runat="server" ColumnSpan="4">
                        <div id="lclExistCompDiv" style="text-align: right"><input id="existCompBtn" type="button" value="Existing Computer" /></div>             
                    </asp:TableCell>
                </asp:TableRow>          
                <asp:TableRow ID="TableRow214" runat="server">
                    <asp:TableCell ID="TableCell12" runat="server">
                        <asp:Label ID="Label2" runat="server" Text="ComputerID:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell13" runat="server" HorizontalAlign="Left">
                        <div id="divAssetId" align="left" runat="server"><asp:TextBox ID="txtAssetID" runat="server" CssClass="Ctrl"></asp:TextBox></div>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell14" runat="server">
                        <asp:Label ID="Label3" runat="server" Text="Serial#:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell15" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="txtSerialNum" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow15" runat="server">
                    <asp:TableCell ID="TableCell29" runat="server">
                        <asp:Label ID="Label22" runat="server" Text="ImageID:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell32" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="txtImageID" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell33" runat="server">
                        <asp:Label ID="Label23" runat="server" Text="Technician:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell35" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="txtTech" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow184" runat="server">
                    <asp:TableCell ID="TableCell238" runat="server" CssClass="Separator" ColumnSpan="4"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
          </div>
          <div id="ExistingDiv">
            <asp:Table ID="Table1" runat="server" CssClass="Table">
                <asp:TableRow ID="TableRow1" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="4">
                        <div id="lclNewCompDiv" style="text-align: right"><input id="newCompBtn" type="button" value="New Computer" /></div>             
                    </asp:TableCell>
                </asp:TableRow>          
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell2" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="ComputerID:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server" HorizontalAlign="Left">
                        <div id="div1" align="left" runat="server"><asp:TextBox ID="TextBox1" runat="server" CssClass="Ctrl"></asp:TextBox></div>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell4" runat="server">
                        <asp:Label ID="Label4" runat="server" Text="Serial#:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server">
                        <asp:Label ID="Label5" runat="server" Text="ImageID:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell8" runat="server">
                        <asp:Label ID="Label6" runat="server" Text="Technician:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="Ctrl"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell10" runat="server" CssClass="Separator" ColumnSpan="4"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
          </div>
          <div id="tblErrorDiv">
            <asp:Table ID="TblError" runat="server" CssClass="Table" >
                <asp:TableRow ID="tblRowerror" runat="server" CssClass="RedCenter">
                    <asp:TableCell ID="TableCell236" runat="server" ColumnSpan="4">
                        <div id="errorSpan"></div>
                    </asp:TableCell>
                </asp:TableRow>                
            </asp:Table>
          </div>
        </asp:Panel>                            
        <asp:Table ID="Table10" CssClass="Table" HorizontalAlign="center" runat="server">
            <asp:TableRow ID="TableRow21" runat="server" CssClass="ColHdr">
                <asp:TableCell ID="TableCell57" runat="server">
                    <asp:Button ID="mainMenuBtn" runat="server" Text="Submit Computer Information" PostBackUrl="./ImageInsert.aspx" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
