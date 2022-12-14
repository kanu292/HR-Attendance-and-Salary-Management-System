<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <div class="HomeDiv">
        <asp:Image ID="Image1" runat="server" CssClass="homeDiv" ImageUrl="~/BackGrounds/hr2.png"/>
    </div>
    <div class="homeData">
        <div class="homeD">
            <div class="homeimg" style="background-image:url(/BackGrounds/person_images/hp.jpeg)"></div><br />
            <span class="hometxt">"I subscribed to the Recertification Program to complete the credits for my SPHR renewal. I found the e-learning courses and webinars very interesting, helpful and up to date on current information. I would not have been able to get all of my credits without this very convenient and affordable option. Thank you for a great resource!"</span>
        </div>
        <div class="homeD">
            <div class="homeimg" style="background-image:url(/BackGrounds/person_images/sr.jpeg)"></div><br />
            <span class="hometxt">"One of the things that really inspired me about being part of the LEAD conference is being in the presence of all of these great HR leaders and learning and hearing their stories and thinking about how we can take back some of the pieces of great information that they've shared with us."</span>

        </div>
        <div class="homeD">
            <div class="homeimg" style="background-image:url(/BackGrounds/person_images/uv.jpeg)"></div><br />
            <span class="hometxt">"Your website and resource offerings which are low or no cost have vastly improved my knowledge in the HR/Payroll/Benefits/Legislation worlds and have made it possible for me to learn as much as I can to make me a better more well rounded HR professional. You have been and are a trusted source of information and a positive impact for my professional development. Thank you!"</span>

        </div>
        <div class="homeD">
            <div class="homeimg" style="background-image:url(/BackGrounds/person_images/msd.jpeg)"></div><br />
            <span class="hometxt">"The Excellence Essentials magazines provide a different perspective that allows an individual to view a topic from a fresh, new angle, so one can reflect, and possibly even be challenged to change for the better. The Excellence Essentials magazines provide an indispensable outlet for the sharing of HR knowledge."</span>

        </div>
        <div class="homeD">
            <div class="homeimg"  style="background-image:url(/BackGrounds/person_images/vk.jpg)"></div><br />
            <span class="hometxt">"I truly enjoy attending the webinars. With such a busy work schedule it really helps with learning different items and hearing others thought. the webinars also allow me to stay up-to-date with different HR needs and trends. Every speaker that I have encountered has made the information clear and easy to follow and have kept my attention. Thanks HR.com"</span>
        </div>       
    </div>
    </center>
</asp:Content>
