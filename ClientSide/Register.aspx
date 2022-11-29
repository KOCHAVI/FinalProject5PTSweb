<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Register</title>
    <link rel="stylesheet" href="Register.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
      <div class="u-clearfix u-sheet u-sheet-1">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-1" src="images/aaaaa-min.png" alt="" data-image-width="709" data-image-height="709" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" data-animation-delay="250">
        <img class="u-hover-feature u-image u-image-contain u-image-round u-image-2" src="images/vcvc.png" alt="" data-image-width="300" data-image-height="666" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Make an Account </h1>
          <table style="position:absolute; margin-left:auto; margin-right:auto; left: 0; right:0; text-align:right; background-color:rgba(255,255,255,0.3); border-spacing:15px 35px; border-radius:30px;">
              <tr>
                  <td>
                      <asp:TextBox ID="TBFname" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px"></asp:TextBox>
                  </td>
                  <td>
                      <asp:TextBox ID="TBLname" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:TextBox ID="TBUname" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px"></asp:TextBox>
                  </td>
                  <td>
                      <asp:TextBox ID="TBPass" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" TextMode="Password" CssClass="Pass"></asp:TextBox>
                      <asp:ImageButton ID="IMGViewPass" ImageUrl="~/images/EYEC.png" OnClick="IMGViewPass_Click" runat="server" Width="40px" CssClass="But"/>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:TextBox ID="TBEmail" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="100%"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:TextBox ID="TBPhone" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="100%"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:TextBox ID="TBAddress" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px"></asp:TextBox>
                  </td>
                  <td>
                      <asp:TextBox ID="TBNumaddress" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                     <asp:DropDownList ID="DDLCountry" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" AutoPostBack="true"></asp:DropDownList>
                  </td>
                  <td>
                      <asp:DropDownList ID="DDLCity" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" style="max-width:500%"></asp:DropDownList>   
                  </td>
              </tr>
              <tr>
                  <td style="border-width:0px; background-color:transparent" colspan="2">
                      <asp:Button ID="BTNReg" runat="server" Text="Register Now!" OnClick="BTNReg_Click" BorderWidth="0px" CssClass="BTN"/>
                  </td>
              </tr>
          </table>
        <img class="u-hover-feature u-image u-image-contain u-image-default u-image-3" src="images/s.png" alt="" data-image-width="791" data-image-height="681" data-animation-name="customAnimationIn" data-animation-duration="1000">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-4" src="images/xxxx.png" alt="" data-image-width="1155" data-image-height="900" data-animation-name="customAnimationIn" data-animation-duration="1250">







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
        .Pass{
            position:relative;
        }
        .But{
            padding-block: 10px;
            position:absolute;
            margin-left: -50px;
        }
    </style>
</asp:Content>