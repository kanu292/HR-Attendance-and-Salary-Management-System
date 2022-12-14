<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OurTeam.aspx.cs" Inherits="OurTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <div class="PageDiv">
        <table class="tblcss">
            <tr>
                <td colspan="3">
                    <div class="loglbl">About Us</div>
                    <div class="HeadLabel" style="text-align:justify">
                        ABC Technologies is a software company that is specialized in commercial software
                        products for the financial markets as well as customer-specific solutions. Our
                        experienced team of developers conceives, constitutes and operates mobile
                        applications and web solutions. We also provide all associated services like hosting,
                        operation and enterprise integration for our customers.
                        We support our customers worldwide with modern products and custom
                        software. We cover the entire IT service lifecycle, from design to implementation and
                        operation. A balanced combination of leading edge technology and proven standards
                        ensures investment security, from large-scale projects to innovative start-ups. Our
                        employees have one common goal: to help our customers reach their digital business
                        targets.
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3"><br /><asp:Label ID="Label1" runat="server" Text="Leadership Team" CssClass="loglbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Image ID="Image1" runat="server" CssClass="profilepic" ImageUrl="~/BackGrounds/person_images/ks.jpg"></asp:Image></td>          
                <td><asp:Image ID="Image2" runat="server" CssClass="profilepic" ImageUrl="~/BackGrounds/person_images/ps.jpeg"></asp:Image></td>
                <td><asp:Image ID="Image3" runat="server" CssClass="profilepic" ImageUrl="~/BackGrounds/person_images/mj.jpg"></asp:Image></td>
            </tr>
            <tr>
                <td>
                    <span class="AboutDetails">
                        Karan Shah ( Director )<br />
                        +91 635555620<br />
                        ks4582200@gmail.com
                    </span>
                </td>
                <td>
                    <span class="AboutDetails">
                        Pankil Sheth ( CEO )<br />
                        +91 9106660890<br />
                        pankilsheth19@gmail.com
                    </span>
                </td>
                <td>
                     <span class="AboutDetails">
                            Meet Jhaveri ( Manager )<br />
                            +91 7778813161 <br />
                            meet4jhaveri@gmail.com
                     </span>
                </td>
            </tr>
        </table>
    </div>
</center>
</asp:Content>

