<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewProfile.aspx.cs" Inherits="viewProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="PageDiv">      
          <table class="profileTable">
              <tr class="tralign">
                  <td><asp:Image ID="Image1" runat="server" CssClass="profilepic"/></td>
                  <td rowspan="2" colspan="3">
                      <table class="profMiniTable">
                          <tr class="tralign">
                              <td colspan="2"><asp:TextBox ID="TxtName" runat="server" CssClass="profilename"/></td>
                              <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="TxtName" CssClass="ValidErrors" ValidationGroup="vv1"/></td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label2" runat="server" Text="Email ID  :" CssClass="profilelabel"/></td>
                              <td><asp:TextBox ID="TxtEmail" runat="server" CssClass="profiletx"/></td>
                              <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Email Address" CssClass="ValidErrors" ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vv1"/><br />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="TxtEmail" CssClass="ValidErrors" ValidationGroup="vv1" />
                              </td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label3" runat="server" Text="Mobile No.  :" CssClass="profilelabel"/></td>
                              <td><asp:TextBox ID="TxtMob" runat="server" CssClass="profiletx"/></td>
                              <td><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid MobileNo" CssClass="ValidErrors" ControlToValidate="TxtMob" ValidationExpression="[0-9]{10}" ValidationGroup="vv1"/><br />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="TxtMob" CssClass="ValidErrors" ValidationGroup="vv1"/>
                              </td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label4" runat="server" Text="Cast :" CssClass="profilelabel"/></td>
                              <td><asp:DropDownList ID="DropDownCast" runat="server" CssClass="profiletx"></asp:DropDownList></td>
                              <td></td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label1" runat="server" Text="Gender :" CssClass="profilelabel"/></td>
                              <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="profiletx">
                                  <asp:ListItem>Male</asp:ListItem>
                                  <asp:ListItem>Female</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td></td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label5" runat="server" Text="Birth Date :" CssClass="profilelabel"/></td>
                              <td><asp:TextBox ID="txtBdate" runat="server" CssClass="profiletx" placeholder="Select Birthdate"></asp:TextBox>
                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="TxtBdate"></cc1:CalendarExtender>
                              </td>
                              <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="txtBdate" CssClass="ValidErrors"/></td>
                          </tr>
                      </table>
                  </td>
              </tr>
              <tr class="tralign">
                  <td>
                      <table class="tblcss" cellpadding="5">
                          <tr><td class="tralign"><asp:Label ID="LblEmpID" runat="server" Text="E0107" CssClass="profilelabel"/></td></tr>
                          <tr><td><asp:Label ID="LblEmpDesignation" runat="server" Text="Manager" CssClass="profilelabel"/></td></tr>
                          <tr><td><asp:Label ID="LblDept" runat="server" Text="Department : IT" CssClass="profilelabel"/></td></tr>
                          <tr><td><asp:Label ID="LblShift" runat="server" Text="Shift : 10:00 - 18:00" CssClass="profilelabel"/></td></tr>
                      </table>
                  </td>
              </tr>
              <tr>
                    <td><asp:Label ID="LblWorkingDays" runat="server" Text="Working Days : 65" CssClass="profilelabel"></asp:Label></td>
                    <td><asp:Label ID="LblPresentDays" runat="server" Text="Present Days : 60" CssClass="profilelabel"></asp:Label></td>                            
                    <td><asp:Label ID="LblTotLeaves" runat="server" Text="Total Leaves : 5" CssClass="profilelabel"></asp:Label></td>
                   <%-- <td><asp:Label ID="LblLeaves" runat="server" Text="Leave Remaining : 20 Days" CssClass="profilelabel"/></td>                       --%>
              </tr>
              <tr>
                  <td colspan="4"><asp:Button ID="BtnProfileSave" runat="server" Text="Save"  CssClass="buttonSign" OnClick="BtnProfileSave_Click" ValidationGroup="vv1"/>
                  </td>
              </tr>
          </table>
        
    </div>
</center>
</asp:Content>

