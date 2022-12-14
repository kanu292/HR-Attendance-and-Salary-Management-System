<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Timeline.aspx.cs" Inherits="Timeline" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <div class="PageDiv">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="timeldiv" >
        <asp:Button ID="BtnClear" runat="server" Text="Clear" CssClass="buttonSign" OnClick="BtnClear_Click" />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="timelinetxt"/><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yy" TargetControlID="TextBox1"></cc1:CalendarExtender>
        <asp:Button ID="BtnSearch" runat="server"  CssClass="buttonSign" Text="Search" OnClick="BtnSearch_Click"/>
        <asp:Button ID="BtnnewTime" runat="server" Text=" New " CssClass="buttonSign" OnClick="BtnnewTime_Click" />    
        </div>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnnewTime" PopupControlID="PanelTimeLine"></cc1:ModalPopupExtender>
        <asp:Panel ID="PanelTimeline" runat="server" CssClass="loginpanel">
        <table class="loginTable">
            <tr height="10%">
                <td>
                    <asp:Button ID="Button1" runat="server" Text=" x " CssClass="closepop"></asp:Button>
                </td>
            </tr>
             <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="New Timeline" CssClass="loglbl"></asp:Label>
                    </td>
                </tr>
            <tr>
                <td><asp:TextBox ID="TxtTimeline" runat="server" placeholder="Enter Description" CssClass="timelinedesc"/></td>
            </tr>
            <tr>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TxtTimeline" CssClass="ValidErrors" ValidationGroup="tt"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Button ID="BtnAddTimeline" runat="server" Text="Add To Timeline" CssClass="loginButton" OnClick="BtnAddTimeline_Click" ValidationGroup="tt" /></td>
            </tr>
        </table>    
        </asp:Panel>
        <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                <div class="timelined">
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Timeline_Date") %>' CssClass="timeline-Date"/>
                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Description") %>' CssClass="timeline-content"/>
                <asp:Label ID="Label3" runat="server" Text='<%#Eval("AddedBy") %>' CssClass="timeline-Date1" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</center>
</asp:Content>