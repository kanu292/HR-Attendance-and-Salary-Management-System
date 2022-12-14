<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAttendance.aspx.cs" Inherits="ManageAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">
        <div class="timeldiv">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="timelinetxt"/><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yy" TargetControlID="TextBox1"></cc1:CalendarExtender>
        <asp:Button ID="BtnFind" runat="server" CssClass="search" OnClick="BtnFind_Click"></asp:Button>
        </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="allGridview"  CellPadding="5" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand" ShowFooter="True">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>Make Present</HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" height="90%" Width="45px"></asp:CheckBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="BtnPresent" runat="server" Text="Save" CommandName="xSave" CssClass="lgbtn"></asp:Button>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</center>
</asp:Content>

