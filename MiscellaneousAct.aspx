<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MiscellaneousAct.aspx.cs" Inherits="MiscellaneousAct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="PageDiv"><br /><br />
            <table class="tblcss">
                <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" CssClass="allGridview" AutoGenerateColumns="False" CellPadding="5">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>Edit</HeaderTemplate>
                            <ItemTemplate><asp:Button ID="Button1" runat="server" Text="Edit" CssClass="lgbtn"></asp:Button></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Update</HeaderTemplate>
                            <ItemTemplate><asp:Button ID="Button2" runat="server" Text="Update" CssClass="lgbtn"></asp:Button></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>ID</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%#Eval("Id")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Desciption</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%#Eval("Description")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Amount</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%#Eval("Amount")%>'></asp:Label></ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="TextBox1" runat="server"  Text='<%#Eval("Amount")%>' ></asp:TextBox></EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate> is Percentage </HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%#Eval("isPercentage")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
                <td>
                <asp:GridView ID="GridView2" runat="server" CssClass="allGridview" CellPadding="5" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>Edit</HeaderTemplate>
                            <ItemTemplate><asp:Button ID="Button3" runat="server" Text="Edit" CssClass="lgbtn"></asp:Button></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Update</HeaderTemplate>
                            <ItemTemplate><asp:Button ID="Button4" runat="server" Text="Update" CssClass="lgbtn"></asp:Button></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Desciption</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label5" runat="server" Text='<%#Eval("Description")%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>Values</HeaderTemplate>
                            <ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%#Eval("Value")%>'></asp:Label></ItemTemplate>
                            <EditItemTemplate><asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval("Value")%>' ></asp:TextBox></EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
                </tr>
            </table><br /><br />
            <table class="tblcss">
                <tr>
                    <td>
                        <table class="tblcs">
                        <tr><td><asp:Label ID="Label9" runat="server" Text="Calculate Salary for Particular Month !" CssClass="profilelabel"></asp:Label></td></tr>
                        <tr>
                        <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="profiletxt">
                            <asp:ListItem>Jan</asp:ListItem>
                            <asp:ListItem>Feb</asp:ListItem>
                            <asp:ListItem>Mar</asp:ListItem>
                            <asp:ListItem>Apr</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>Jun</asp:ListItem>
                            <asp:ListItem>Jul</asp:ListItem>
                            <asp:ListItem>Aug</asp:ListItem>
                            <asp:ListItem>Sep</asp:ListItem>
                            <asp:ListItem>Oct</asp:ListItem>
                            <asp:ListItem>Nov</asp:ListItem>
                            <asp:ListItem>Dec</asp:ListItem>
                         </asp:DropDownList>
                         </td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Calculate Salary" CssClass="lgbtn" OnClick="Button5_Click"></asp:Button>
                        </td>
                        </tr>
                        </table>
                    </td>
                    <td>
                        <table class="tblcs">
                            <tr><td><asp:Label ID="Label8" runat="server" Text="Take Attendance" CssClass="profilelabel"></asp:Label></td></tr>
                             <tr><td><asp:TextBox ID="TextBox3" runat="server" CssClass="timelinetxt"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yy" TargetControlID="TextBox3"></cc1:CalendarExtender></td></tr>
                              <tr><td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TextBox3" CssClass="ValidErrors" ValidationGroup="att"></asp:RequiredFieldValidator></td></tr>
                              <tr><td><asp:Button ID="BtnAttendance" runat="server" Text="Make Entry" CssClass="lgbtn" ValidationGroup="att" OnClick="BtnAttendance_Click"></asp:Button></td></tr>
                        </table>
                    </td>
                    <td>
                        <table class="tblcs">
                            <tr><td><asp:Label ID="Label7" runat="server" Text="Open Application Form ? " CssClass="profilelabel"></asp:Label></td></tr>
                            <tr><td><asp:DropDownList ID="DropDownList2" runat="server" CssClass="profiletxt">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    </asp:DropDownList></td></tr>
                             <tr><td><asp:Button ID="Button6" runat="server" Text="Save" CssClass="lgbtn" OnClick="Button6_Click"></asp:Button></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

