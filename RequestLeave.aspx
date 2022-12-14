<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RequestLeave.aspx.cs" Inherits="RequestLeave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">
        <asp:Label ID="ig1" runat="server" CssClass="popup"></asp:Label>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="PanelLeave" TargetControlID="ig1" CancelControlID="bb"></cc1:ModalPopupExtender>
        <asp:Panel ID="PanelLeave" runat="server" CssClass="loginpanel">
                <table class="loginTable">
                    <tr height="10%">
                        <td colspan="2"><asp:Button ID="bb" runat="server" Text="x" CssClass="closepop"/></td>
                    </tr>
                    <tr>
                    <td colspan="2"><asp:Label ID="Label3" runat="server" Text="Leave Request" CssClass="loglbl"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Date : " CssClass="profilelabel"></asp:Label><br />
                        <asp:TextBox ID="TxtLeaveDate" runat="server" placeholder="Select Date" CssClass="LeaveHoliday1"/>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yy" TargetControlID="TxtLeaveDate"></cc1:CalendarExtender><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TxtLeaveDate" CssClass="ValidErrors" ValidationGroup="leave1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Label ID="Label2" runat="server" Text="Description : " CssClass="profilelabel"></asp:Label><br />
                        <asp:TextBox ID="TxtLeaveReason" runat="server" placeholder="Enter Reason" CssClass="LeaveHoliday2" Rows="3" TextMode="MultiLine"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TxtLeaveReason" CssClass="ValidErrors" ValidationGroup="leave1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button ID="BtnAddLeave" runat="server" Text="New Leave Request" CssClass="loginButton" OnClick="BtnAddLeave_Click" ValidationGroup="leave1" /></td>          
                    </tr>
                </table>
        </asp:Panel>
        <asp:GridView ID="GridView1" runat="server" CssClass="allGridview" OnRowCommand="GridView1_RowCommand" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Cancel Request</HeaderTemplate>
                    <ItemTemplate><asp:Button ID="Button1" runat="server" Text="Cancel Request" CssClass="lgbtn" CommandName="xCancel"/></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        
    </div>
    </center>
</asp:Content>

