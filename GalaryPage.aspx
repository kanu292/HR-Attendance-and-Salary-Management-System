<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GalaryPage.aspx.cs" Inherits="GalaryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <center>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                  
                      <asp:Image ID="Image1" runat="server" CssClass="PageDiv1" />
                      <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>    
            </asp:UpdatePanel>
     </div>
  </center>
</asp:Content>

