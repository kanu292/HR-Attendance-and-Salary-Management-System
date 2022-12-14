<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HolidayList.aspx.cs" Inherits="HolidayList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <center>
    <div class="PageDiv">
        <asp:Panel ID="Panel1" runat="server" CssClass="timeldiv" Visible="false"><asp:Button ID="BtnNewHoliday" runat="server" Text="New" CssClass="buttonSign" OnClick="BtnNewHoliday_Click"></asp:Button></asp:Panel>
        
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="BtnNewHoliday" PopupControlID="PanelHoliday" CancelControlID="btnclose"></cc1:ModalPopupExtender>
        <asp:Panel ID="PanelHoliday" runat="server" CssClass="loginpanel" Visible="false">
                <table class="loginTable">
                    <tr><td><asp:Button ID="Btnclose" runat="server" Text="x" CssClass="closepop"></asp:Button></td></tr>
                     <tr><td colspan="2"><asp:Label ID="Label3" runat="server" Text="New Holiday" CssClass="loglbl"></asp:Label></td></tr>
                    <tr>
                        <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Date : " CssClass="profilelabel"></asp:Label><br />
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Select Date" CssClass="LeaveHoliday1"/>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yy" TargetControlID="TextBox1"></cc1:CalendarExtender><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TextBox1" CssClass="ValidErrors" ValidationGroup="holi1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Description : " CssClass="profilelabel"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Description" CssClass="LeaveHoliday2"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TextBox2" CssClass="ValidErrors" ValidationGroup="holi1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2"><asp:Button ID="BtnAddHoliday" runat="server" Text="Add Holiday" CssClass="loginButton" OnClick="BtnAddHoliday_Click" ValidationGroup="holi1"/></td>
                    </tr>
                </table>
        </asp:Panel>
        <asp:GridView ID="GridView1" runat="server" CssClass="allGridview" GridLines="Horizontal" CellPadding="5">
        </asp:GridView>
    </div>
    </center>
</asp:Content>

