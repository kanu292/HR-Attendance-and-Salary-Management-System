<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageLeave.aspx.cs" Inherits="ManageLeave" %>

<asp:Content ID="Co5ntent1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div class="PageDiv">
        <asp:GridView ID="GridView1" runat="server" CssClass="allGridview" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate> Approve </HeaderTemplate>
                    <ItemTemplate><asp:Button ID="Button1" runat="server" Text="Approve" CssClass="lgbtn" CommandName="xApprove" CommandArgument='<%#Eval("Leave_Id") %>' /></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate> Reject</HeaderTemplate>
                    <ItemTemplate><asp:Button ID="Button2" runat="server" Text="Reject" CssClass="lgbtn" CommandName="xReject" CommandArgument='<%#Eval("Leave_Id") %>' /></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView><br />
        <asp:GridView ID="GridView2" runat="server" CssClass="allGridview"></asp:GridView>
    </div>
    </center>
</asp:Content>

