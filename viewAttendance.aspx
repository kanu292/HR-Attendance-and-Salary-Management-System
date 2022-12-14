<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewAttendance.aspx.cs" Inherits="viewAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="PageDiv">
        <center>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="tblList">
                    <table class="tblsal" cellpadding="10">
                        <tr>
                            <td colspan="2">
                                <%--  <div id="circularProgess" class="circularprogress background" runat="server">  
                        <div id="ProgressText" class="overlay" runat="server">75%</div>  
                   </div>--%>
                                <div id="ProgressText" class="circularprogress" runat="server">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LblTotalDays" runat="server" CssClass="HeadLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LblPresent" runat="server" CssClass="HeadLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LblAbsent" runat="server" CssClass="HeadLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="tblP"></div>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Present" CssClass="HeadLabel" /></td>
                        </tr>
                        <tr>
                            <td>
                                <div class="tblA"></div>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Absent" CssClass="HeadLabel" /></td>
                        </tr>
                        <tr>
                            <td>
                                <div class="tblH"></div>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Holiday" CssClass="HeadLabel" /></td>
                        </tr>
                        <tr>
                            <td>
                                <div class="tblL"></div>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Leave" CssClass="HeadLabel" /></td>
                        </tr>
                    </table>
                </div>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
                <div class="AttendanceDiv">
                    <table class="tblcss">
                        <tr>
                            <td>Mon</td>
                            <td>Tue</td>
                            <td>Wed</td>
                            <td>Thu</td>
                            <td>Friday</td>
                            <td>Sat</td>
                            <td>Sun</td>
                        </tr>
                    </table>
                    <table class="tblcss" border="1">
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="<" CssClass="lgbtn" OnClick="Button1_Click"></asp:Button></td>
                            <td colspan="5">
                                <asp:Label ID="Label2" runat="server" Text="March 2018" CssClass="attDate" /></td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text=">" CssClass="lgbtn" OnClick="Button2_Click"></asp:Button></td>
                        </tr>
                    </table>
                    <asp:DataList ID="DataList1" runat="server" CssClass="DisplayAttendance" RepeatColumns="7" HorizontalAlign="Center" RepeatDirection="Horizontal" OnItemDataBound="DataList1_ItemDataBound" BorderColor="Black">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("A_Date") %>' CssClass="attDate"></asp:Label><br />
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("A_Type") %>' CssClass="attdiv" ReadOnly="true" />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

