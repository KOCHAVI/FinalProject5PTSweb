<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="BuyCoins.aspx.cs" Inherits="BuyCoins" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Buy Coins</title>
    <link rel="stylesheet" href="BuyCoins.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Buy Coins!</h1>
            <asp:DataList ID="DL" OnItemCommand="DL_Command" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px; margin-left:auto; margin-right:auto;">
            <tr class="Blur">
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG" runat="server" ImageUrl="~/images/CreditCard.png" CssClass="IMG"/>
                    <asp:Label ID="LBLU" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Username") %>' Visible="true" CssClass="TBX LBLU2"></asp:Label>
                    <asp:Label ID="LBLCardNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CardNumber") %>' Visible="true" CssClass="TBX TBCN2"></asp:Label>
                    <asp:TextBox ID="TBCN" runat="server" CssClass="TBX TBCN2" Visible="false"></asp:TextBox>
                    <asp:Label ID="LBLExpDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ExpDate")%>' Visible="true" CssClass="TBX DDLM2"></asp:Label>
                    <asp:DropDownList ID="DDLM" runat="server" CssClass="TBX DDLM2" Visible="false"></asp:DropDownList>
                    <asp:Label ID="LBLS" runat="server" CssClass="TBX LBLS2" Text="/" Visible="false"></asp:Label>   
                    <asp:DropDownList ID="DDLY" runat="server" CssClass="TBX DDLY2" Visible="false"></asp:DropDownList>
                    <asp:Label ID="LBLCVV" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CVV")%>' Visible="true" CssClass="TBX TBCVV2"></asp:Label>
                    <asp:TextBox ID="TBCVV" runat="server" CssClass="TBX TBCVV2" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTNBack" runat="server" Text="Cancel" CommandName="Back_Click" Visible="false"/>
                    <asp:Button ID="BTNEdit" runat="server" Text="Edit" CommandName="Edit_Click"/>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
            <table style="background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px; margin-left:auto; margin-right:auto;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG2" runat="server" ImageUrl="~/images/CreditCard.png" CssClass="IMG"/>
                    <asp:Label ID="LBLU2" runat="server" CssClass="TBX LBLU" Text=""></asp:Label>               
                    <asp:TextBox ID="TBCN2" runat="server" CssClass="TBX TBCN"></asp:TextBox>
                    <asp:DropDownList ID="DDLM2" runat="server" CssClass="TBX DDLM"></asp:DropDownList>
                    <asp:Label ID="LBLS2" runat="server" CssClass="TBX LBLS" Text="/"></asp:Label>   
                    <asp:DropDownList ID="DDLY2" runat="server" CssClass="TBX DDLY"></asp:DropDownList>
                    <asp:TextBox ID="TBCVV2" runat="server" CssClass="TBX TBCVV"></asp:TextBox>
                    <asp:Button ID="BTNSave" runat="server" Text="Add Card" OnClick="BTNSave_Click"/>
               </td>
            </tr>
        </table>  
        <asp:TextBox ID="TBCoins" runat="server"></asp:TextBox>
        <asp:Button ID="BTNBuy" runat="server" Text="Buy" OnClick="BTNBuy_Click"/> 
    </div></section>
    <style>
        .IMG{
            max-height:190px;
            max-width:350px;
        }
        .TBX{
            position:absolute;
            border-color:transparent;
            background-color:transparent;
            font-family:fantasy;
        }
        .LBLU{
            left:30px;
            bottom:70px;
        }
        .LBLU2{
            left:15px;
            bottom:20px;
        }
        .LBLS{
            left:170px;
            bottom:80px;
        }
        .LBLS2{
            left:156px;
            bottom:30px;
        }
        .TBCN{
            left:30px;
            bottom:114px;
        }
        .TBCN2{
            left:20px;
            bottom:60px;
        }
        .TBCVV{
            left:90px;
            bottom:80px;
            width:40px;
        }
        .TBCVV2{
            left:70px;
            bottom:30px;
            width:40px;
        }
        .DDLM{
            left:160px;
            bottom:80px;
            -webkit-appearance: none;
        }
        .DDLM2{
            left:146px;
            bottom:30px;
            -webkit-appearance: none;
        }
        .DDLY{
            left:177px;
            bottom:80px;
            -webkit-appearance: none;
        }
        .DDLY2{
            left:163px;
            bottom:30px;
            -webkit-appearance: none;
        }
        .Blur{
            webkit-filter: blur(4px);
            filter: blur(4px);
        }
        .Blur:hover{
            webkit-filter: blur(0px);
            filter: blur(0px);
        }
        input {
            background-color: transparent;
            border-radius: 10px;
            font-family: 'Montserrat';
        }
    </style>
<style>
/* Popup container */
.popup {
  position: relative;
  display: inline-block;
  cursor: pointer;
}

/* The actual popup (appears on top) */
.popup .popuptext {
  visibility: hidden;
  width: 160px;
  background-color: #555;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 8px 0;
  position: absolute;
  z-index: 1;
  bottom: 125%;
  left: 50%;
  margin-left: -80px;
}

/* Popup arrow */
.popup .popuptext::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border-color: #555 transparent transparent transparent;
}

/* Toggle this class when clicking on the popup container (hide and show the popup) */
.popup .show {
  visibility: visible;
  -webkit-animation: fadeIn 1s;
  animation: fadeIn 1s
}

/* Add animation (fade in the popup) */
@-webkit-keyframes fadeIn {
  from {opacity: 0;}
  to {opacity: 1;}
}

@keyframes fadeIn {
  from {opacity: 0;}
  to {opacity:1 ;}
}
</style>
</asp:Content>