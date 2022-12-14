<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div class="PageDiv">       
        <asp:Panel ID="changepanel1" runat="server" CssClass="loginpanel" Visible="false">
            <table class="loginTable">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Change Password" CssClass="loglbl"></asp:Label>
                    </td>
                </tr>
                <tr>                
                    <td><asp:TextBox ID="TextBox1" runat="server" CssClass="logintext" placeholder="Username"></asp:TextBox></td>
                </tr>
                <tr>                   
                    <td><asp:TextBox ID="TextBox2" runat="server" CssClass="logintext" placeholder="Old Password" TextMode="Password"></asp:TextBox></td>                    
                </tr>
                <tr>
                   <td><asp:TextBox ID="TextBox3" runat="server" CssClass="logintext" placeholder="New Password" TextMode="Password"></asp:TextBox></td>                     
                </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox4" runat="server" CssClass="logintext" placeholder="Confirm Password" TextMode="Password"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Btnchnage" runat="server" Text="Save Password" CssClass="loginButton" OnClick="Btnchnage_Click"/>
                    </td>
                </tr>
            </table>           
        </asp:Panel> 
       <asp:Panel ID="forgotpanel1" runat="server" CssClass="loginpanel" Visible="false">
            <table class="loginTable">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Forgot Password" CssClass="loglbl"></asp:Label>
                    </td>
                </tr>
                <tr>                
                    <td><asp:TextBox ID="TextBox5" runat="server" CssClass="logintext" placeholder="Username"></asp:TextBox></td>
                </tr>
                <tr>                   
                    <td><asp:TextBox ID="TextBox6" runat="server" CssClass="logintext" placeholder="Email Address" TextMode="Password"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnForget" runat="server" Text="Send Me Mail" CssClass="loginButton" OnClick="BtnForget_Click"/>
                    </td>
                </tr>
            </table>           
        </asp:Panel>  
    </div>
  </center>
</asp:Content>

