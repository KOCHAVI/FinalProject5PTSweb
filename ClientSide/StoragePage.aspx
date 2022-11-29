<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="StoragePage.aspx.cs" Inherits="StoragePage" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>StoragePage</title>
    <link rel="stylesheet" href="BuyCoins.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
            <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Storage Page</h1>
              <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="height:60%">Waiting For Confirmation</h1>
            <asp:DataList ID="DL" OnItemCommand="DL_Command" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-radius:30px; margin-left:auto; margin-right:auto; height: 440px;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","ProductIMGS/{0}") %>' CssClass="IMG"/>
                    <asp:Label ID="LBLCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ItemCode") %>' Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pname") %>' Visible="true" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Price") + " Tickets" %>' Visible="true" ForeColor="Green"></asp:Label>              
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTNAccept" runat="server" Text="Accept" CommandName="Accept_Click"/>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
<style>
        .GV{
            margin:auto;
        }
        .SRH{
            width:35px;
            position:absolute;
        }
        .IMG{
            max-height:190px;
            max-width:250px;
        }
        input {
            background-color: transparent;
            border-radius: 10px;
            font-family: 'Montserrat';
        }
    </style>
</asp:Content>

