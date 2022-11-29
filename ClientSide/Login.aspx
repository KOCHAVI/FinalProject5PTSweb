<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Login</title>
    <link rel="stylesheet" href="Login.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-1" src="images/aaaaa-min.png" alt="" data-image-width="709" data-image-height="709" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" data-animation-delay="250">
        <img class="u-hover-feature u-image u-image-contain u-image-round u-image-2" src="images/vcvc.png" alt="" data-image-width="300" data-image-height="666" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Log In</h1>
        <table style="position:absolute; margin-left:auto; margin-right:auto; left: 0; right:0; text-align:right; background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px;">
            <tr>
                <td>
                    <asp:TextBox ID="TBUname" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="95%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TBPass" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="95%" TextMode="Password"></asp:TextBox>
                    <asp:ImageButton ID="IMGViewPass" ImageUrl="~/images/EYEC.png" OnClick="IMGViewPass_Click" runat="server" Width="40px" CssClass="But"/>
                </td>
            </tr>
            <tr>
                <td style="border-width:0px; background-color:transparent; border-collapse:collapse; border-spacing:0">
                    <asp:CheckBox ID="CB" runat="server" /> Remember me
                </td>
            </tr>
            <tr>
                <td style="border-width:0px; background-color:transparent">
                    <asp:Label ID="LBLMSG" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label></br>
                    <asp:Button ID="BTNLog" runat="server" Text="Login Now!" OnClick="BTNLog_Click" BorderWidth="0px" CssClass="BTN"/>
                </td>
            </tr>
        </table>
        <img class="u-hover-feature u-image u-image-contain u-image-default u-image-3" src="images/s.png" alt="" data-image-width="791" data-image-height="681" data-animation-name="customAnimationIn" data-animation-duration="1000" style="visibility:hidden">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-4" src="images/xxxx.png" alt="" data-image-width="1155" data-image-height="900" data-animation-name="customAnimationIn" data-animation-duration="1250" style="visibility:hidden">
       
      </div>
    </section>
    <style>
        td{
            border: 2px solid black;
            border-radius:40px;
            background-color:white;
            text-align:center;
            align-content:center;
        }
        .BTN{
            border-radius: 20px;
            width:300px;
            height:30px;
            background:rgb(220 39 228 / 0.80);
            font-size:20px
        }
        .But{
            padding-block: 10px;
            position:absolute;
            margin-left: -50px;
        }
    </style>
</asp:Content>

