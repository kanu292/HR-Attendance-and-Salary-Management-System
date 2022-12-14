<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageEmployee.aspx.cs" Inherits="ManageEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">   
        <div>
            <asp:Button ID="Button1" runat="server" Text="Create New" CssClass="btn" OnClick="Button1_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Edit Existing" CssClass="btn" />
            <asp:Button ID="Button3" runat="server" Text="Delete Existing" CssClass="btn"/>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>            
        </div>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Button3" PopupControlID="Panel1" CancelControlID="BtnClose"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="loginpanel">
            <table class="loginTable">
            <tr height="10%">
                <td>
                    <asp:Button ID="BtnClose" runat="server" Text=" x " CssClass="closepop"></asp:Button>
                </td>
            </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="Delete Employee" CssClass="loglbl"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Enter Reason for Deleting Employee . !!!" CssClass="profilelabel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TxtReason" runat="server" CssClass="timelinedesc" placeholder="Enter Reason Here"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TxtReason" CssClass="ValidErrors" ValidationGroup="rr"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td><asp:Button ID="BtnDel" runat="server" Text="Delete" CssClass="lgbtn" ValidationGroup="rr"></asp:Button></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:GridView ID="GridView1" runat="server" CssClass="allGridview" CellPadding="5" GridLines="Horizontal">
        </asp:GridView>
    </div>
    </center>
</asp:Content>

