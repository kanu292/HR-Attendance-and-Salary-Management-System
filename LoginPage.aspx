<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div class="PageDiv">       
        <div class="loginpanel">
            <table class="loginTable">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="Sign In" CssClass="loglbl"></asp:Label>
                    </td>
                </tr>
                <tr>                
                    <td colspan="2"><asp:TextBox ID="TextBox1" runat="server" CssClass="logintext" placeholder="Username"></asp:TextBox></td>
                </tr>
                <tr>                   
                    <td colspan="2"><asp:TextBox ID="TextBox2" runat="server" CssClass="logintext" placeholder="Password" TextMode="Password"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td colspan="2"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="logintext">
                        <asp:ListItem>Employee</asp:ListItem>
                        <asp:ListItem>Accountant</asp:ListItem>
                        <asp:ListItem>Manager</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Forgot Password ?</asp:LinkButton></td>
                    <td><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Change Password</asp:LinkButton></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Btnlog" runat="server" Text="Login" CssClass="loginButton" OnClick="Btnlog_Click"/>
                    </td>
                </tr>
            </table>           
        </div>   
    </div>
  </center>
</asp:Content>

