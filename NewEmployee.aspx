<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewEmployee.aspx.cs" Inherits="NewEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">
        <table class="loginTable">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Name : " CssClass="profilelabel"/></td>
                <td><asp:TextBox ID="Txtname" runat="server" Text="" CssClass="profiletxt"/></td>
                <td><asp:Label ID="Label2" runat="server" Text="Email : " CssClass="profilelabel"/></td>
                <td><asp:TextBox ID="TxtEmail" runat="server" Text="" CssClass="profiletxt"/></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="Txtname" CssClass="ValidErrors"/>
                </td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TxtEmail" CssClass="ValidErrors"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email ID" ControlToValidate="TxtEmail" CssClass="ValidErrors" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                 </td>  
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Birth Date : " CssClass="profilelabel"/></td>
                <td><asp:TextBox ID="TxtBdate" runat="server" Text="" CssClass="timelinetxt"/><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txtBdate"></cc1:CalendarExtender></td>
                <td><asp:Label ID="Label6" runat="server" Text="Cast : " CssClass="profilelabel"/></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" CssClass="profiletxt"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="TxtBdate" CssClass="ValidErrors" ValidationGroup="pr"/>
                </td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label7" runat="server" Text="Mobile No. : " CssClass="profilelabel"/></td>
                <td><asp:TextBox ID="Txtmob" runat="server" Text="" CssClass="profiletxt"/></td>
                <td><asp:Label ID="Label8" runat="server" Text="Gender : " CssClass="profilelabel"/></td>
                <td><asp:DropDownList ID="DropDownList5" runat="server" CssClass="profiletxt">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="Txtmob" CssClass="ValidErrors" ValidationGroup="pr"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Mobile No" ControlToValidate="Txtmob" CssClass="ValidErrors" ValidationExpression="[0-9]{10}" ValidationGroup="pr"></asp:RegularExpressionValidator>
                </td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label11" runat="server" Text="Profile Picture : " CssClass="profilelabel"/></td>
                <td colspan="2"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="profiletxt"/></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ControlToValidate="FileUpload1" CssClass="ValidErrors" ValidationGroup="pr"/>
                </td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Department : " CssClass="profilelabel"/></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="profiletxt"></asp:DropDownList></td>
                <td><asp:Label ID="Label4" runat="server" Text="Designation : " CssClass="profilelabel"/></td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" CssClass="profiletxt"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label9" runat="server" Text="Shift Time : " CssClass="profilelabel"/></td>
                <td><asp:DropDownList ID="DropDownList4" runat="server" CssClass="profiletxt"></asp:DropDownList></td>
                <td><asp:Label ID="Label10" runat="server" Text="Basic Salary : " CssClass="profilelabel"/></td>
                <td><asp:TextBox ID="Txtbasic" runat="server" Text="" CssClass="profiletxt"/></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" ControlToValidate="Txtbasic" CssClass="ValidErrors" ValidationGroup="pr"/>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Basic Salary" ControlToValidate="Txtbasic" CssClass="ValidErrors" ValidationExpression="[0-9]*" ValidationGroup="pr"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="buttonSign" OnClick="Button1_Click" ValidationGroup="pr" />
                </td>
            </tr>
        </table>
    </div>
</center>
</asp:Content>

