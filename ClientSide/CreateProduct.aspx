<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="CreateProduct.aspx.cs" Inherits="CreateProduct" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Create Product</title>
    <link rel="stylesheet" href="Login.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-1" src="images/aaaaa-min.png" alt="" data-image-width="709" data-image-height="709" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" data-animation-delay="250" style="visibility:hidden">
        <img class="u-hover-feature u-image u-image-contain u-image-round u-image-2" src="images/vcvc.png" alt="" data-image-width="300" data-image-height="666" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" style="visibility:hidden">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Create A Product</h1>
        <table style="position:absolute; margin-left:auto; margin-right:auto; left: 0; right:0; text-align:right; background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px;">
            <tr>
                <td>
                    <asp:TextBox ID="TBName" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="95%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TBDescription" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="85%" TextMode="MultiLine" CssClass="TB"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TBPrice" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="90%"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="viewRegularExpressionValidator" runat="server" ValidationExpression="[0-9]{1,50}" ControlToValidate="TBPrice">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="border: 4px dotted gray; background-color: transparent; border-radius: 0px; background: url(http://localhost:49945/images/Fup.png); background-repeat:no-repeat; background-position:center; background-size:150px;">
                    <label class="file-upload">
                    <asp:FileUpload ID="FileUp" runat="server" ></asp:FileUpload>
                    </label>
                </td>
            </tr>
            <tr>
                <td style="border-width:0px; background-color:transparent">
                    <asp:Button ID="BTNCheck" runat="server" Text="Check" OnClick="BTNCheck_Click" BorderWidth="0px" CssClass="BTN"/>
                    <asp:Button ID="BTNConfirm" runat="server" Text="Confirm!" OnClick="BTNConfirm_Click" BorderWidth="0px" CssClass="BTN"/>
                </td>
            </tr>
        </table>
        <table style="text-align:right; background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px;">
            <tr>
                <td style="border-width:0px; background-color:transparent; width:300px;height:200px">
                    <asp:Image ID="IMG" runat="server" ImageUrl="~/images/YourPic.png" Width="200px" BackColor="#e2e2e2"/>
                </td>
            </tr>
            <tr>
                <td style="border-width:0px; background-color:transparent">
                    <asp:Label ID="LBLName" runat="server" Text="Product Name!" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-width:0px; background-color:transparent">
                    <asp:Label ID="LBLPrice" runat="server" Text="Product Price!" ForeColor="Green"></asp:Label>
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
            margin:auto;
            background-color:white;
            text-align:center;
            align-content:center;
        }
        .BTN{
            border-radius: 20px;
            height:40px;
            margin-block:auto;
            background:rgb(220 39 228 / 0.80);
            font-size:20px;
        }
        .TB{
            resize:none;
        }
        .FU{
            display:none;
        }
        .file-upload {
            display: inline;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            font-family: Arial;
            color: #fff;
            border-radius: 6px;
            -moz-border-radius: 6px;
            cursor: pointer;
            text-shadow: #000 1px 1px 2px;
            -webkit-border-radius: 6px;
        }
        .IMG{
            position:relative;
        }
/* The button size */
.file-upload {
    height: 30px;
}

.file-upload, .file-upload span {
        width: 90px;
}

.file-upload input {
            top: 0;
            left: 0;
            margin: 0;
            font-weight: bold;
            /* Loses tab index in webkit if width is set to 0 */
            opacity: 0;
            padding-block:80px;
}

.file-upload strong {
            font: normal 12px Tahoma,sans-serif;
            text-align: center;
            vertical-align: middle;
}
        </style>
</asp:Content>

