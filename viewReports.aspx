<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewReports.aspx.cs" Inherits="viewReports" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="PageDiv">
            <table class="loginTable">
                <tr height="10%">
                    <td width="60%">
                       <table class="profileTable">
                           <tr>
                               <td><asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Report ID" CssClass="profiletxt"></asp:TextBox></td>
                               <td><asp:Button ID="Button1" runat="server" Text="View Report" CssClass="lgbtn" OnClick="Button1_Click"></asp:Button></td>
                           </tr>
                       </table>
                    </td>
                    <td rowspan="2">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" CssClass="reportSS"></rsweb:ReportViewer>
                    </td>
                </tr>
                <tr>
                    <td><asp:GridView ID="GridView1" runat="server" CssClass="allGridview" CellPadding="5" style="float:left"></asp:GridView></td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

