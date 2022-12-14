<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SalarySlip.aspx.cs" Inherits="SalarySlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <center>
    <div class="PageDiv">
        <div class="salarySearchDiv">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="lgbtn"></asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="lgbtn"></asp:DropDownList>
        <asp:Button ID="BtnSalSearch" runat="server" CssClass="lgbtn" Text="Search" OnClick="BtnSalSearch_Click"/>
        </div>
    <div style="background-color:#f1f1f1; width:1300px; height:600px;margin-top:50px">
        <table border="1" class="tblSalary">
            <tr class="tr1">
                <td rowspan="2"></td>
                <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Salary Slip" CssClass="salaryhead"></asp:Label></td>
                 <td rowspan="2"></td>
            </tr>
            <tr class="tr1">
                <td colspan="2"><asp:Label ID="Label2" runat="server" Text="March 2018" CssClass="salarylbl"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" width="50%">
                    <table class="tblsal">
                        <tr><td><asp:Label ID="Label3" runat="server" Text="ID : " CssClass="salarylbl"></asp:Label></td></tr>
                        <tr><td><asp:Label ID="Label4" runat="server" Text="Name : " CssClass="salarylbl"></asp:Label></td></tr>
                    </table>
                </td>
                <td colspan="2" style="text-align:right">
                    <table class="tblsal">
                        <tr><td><asp:Label ID="Label5" runat="server" Text="Slip ID : 1" CssClass="salarylbl"></asp:Label></td></tr>
                        <tr><td><asp:Label ID="Label6" runat="server" Text="Department : IT" CssClass="salarylbl"></asp:Label></td></tr>
                    </table>
                </td>
            </tr>
            <tr class="tr1">
                <td colspan="4">
                    <table border="1" class="tblsal">
                        <tr>
                        <td class="td1" width="50%"><asp:Label ID="Label7" runat="server" Text="Description" CssClass="salarylbl"/></td>
                        <td class="td1"><asp:Label ID="Label8" runat="server" Text="Earnings" CssClass="salarylbl"/></td>
                        <td class="td1"><asp:Label ID="Label9" runat="server" Text="Deduction" CssClass="salarylbl"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label10" runat="server" Text="Basic" CssClass="salarytxt"/></td>
                            <td><asp:Label ID="Labelbasic" runat="server" Text="lblBasic" CssClass="salarytxt"/></td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label17" runat="server" Text="Penalty" CssClass="salarytxt"/></td>
                            <td>-</td>
                            <td><asp:Label ID="LabelPenalty" runat="server" Text="lblPenalty" CssClass="salarytxt"/></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label11" runat="server" Text="DA" CssClass="salarytxt"/></td>
                            <td><asp:Label ID="LabelDA" runat="server" Text="lblDA" CssClass="salarytxt"/></td>
                            <td>-</td>
                        </tr>
                         <tr>
                             <td><asp:Label ID="Label12" runat="server" Text="HRA" CssClass="salarytxt"/></td>
                            <td><asp:Label ID="LabelHRA" runat="server" Text="lblHRA" CssClass="salarytxt"/></td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label13" runat="server" Text="MA" CssClass="salarytxt"/></td>
                            <td><asp:Label ID="LabelMA" runat="server" Text="lblMA" CssClass="salarytxt"/></td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label14" runat="server" Text="TA" CssClass="salarytxt"/></td>
                            <td><asp:Label ID="LabelTA" runat="server" Text="lblTA" CssClass="salarytxt"/></td>
                            <td>-</td>
                        </tr>
                        <tr>
                            <td class="td1"><asp:Label ID="Label15" runat="server" Text="Total" CssClass="salarylbl"/></td>
                            <td><asp:Label ID="LabelTot" runat="server" Text="lblTotal" CssClass="salarylbl"/></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="tblsal">
                        <tr><td><asp:Label ID="LabelDays" runat="server" Text="Working Days : 23" CssClass="salarytxt"/></td></tr>
                         <tr><td><asp:Label ID="LabelPresent" runat="server" Text="Present Days : 20" CssClass="salarytxt"/></td></tr>
                          <tr><td><asp:Label ID="LabelLate" runat="server" Text="Is Late ?? : 2" CssClass="salarytxt"/></td></tr>
                         <tr><td><asp:Label ID="LabelLeave" runat="server" Text="This Month's Leave : 3" CssClass="salarytxt"/></td></tr>
                        <tr><td><asp:Label ID="LabelLeaveBal" runat="server" Text="CarryForward Leaves : 18" CssClass="salarytxt"/></td></tr>
                    </table>
                </td>
                <td colspan="2">
                    <table class="tblsal">
                        <tr><td class="td1"><asp:Label ID="Label16" runat="server" Text="Net Pay" CssClass="salarylbl"/></td></tr>
                        <tr class="tr1"><td><asp:Label ID="LabelAmount" runat="server" Text="Total Amount" CssClass="salarylbl"/></td></tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </div>
        </center>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

