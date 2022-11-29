<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="MyProducts.aspx.cs" Inherits="MyProducts" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>My Products</title>
    <link rel="stylesheet" href="Login.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-1" src="images/aaaaa-min.png" alt="" data-image-width="709" data-image-height="709" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" data-animation-delay="250">
        <img class="u-hover-feature u-image u-image-contain u-image-round u-image-2" src="images/vcvc.png" alt="" data-image-width="300" data-image-height="666" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">My Products</h1>
        <asp:TextBox ID="TBSearch" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="2px" Width="20%" BorderColor="Black"></asp:TextBox>
        <asp:ImageButton ID="SearchBut" runat="server" OnClick="SearchBut_Click" CssClass="SRH" ImageUrl="~/images/SRC.png"/></br></br>

<asp:DataList ID="DL" OnItemCommand="DL_Command" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px; margin-left:auto; margin-right:auto;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","ProductIMGS/{0}") %>' CssClass="IMG"/>
                    <asp:FileUpload ID="FUPic" runat="server" Visible="false"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pname") %>' Visible="true" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="TBName" runat="server" Visible="false" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="90%"></asp:TextBox>
                    <asp:TextBox ID="TBDescription" runat="server" Visible="false" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="90%"></asp:TextBox>
                    <asp:TextBox ID="TBPrice" runat="server" Visible="false" BackColor="Transparent" Font-Size="20px" BorderWidth="0px" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Price") + " Coins" %>' Visible="true" ForeColor="Green"></asp:Label>              
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTNEdit" runat="server" Text="Edit" CommandName="Edit_Click"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTNPublish" runat="server" Text="Publish" CommandName="Publish_Click"/>               
                    <asp:Button ID="BTNStore" runat="server" Text="Send To Storage" CommandName="Store_Click"/>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
            <table style="background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px; margin-left:auto; margin-right:auto;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:ImageButton ID="IMGBtn" runat="server" ImageUrl="~/images/IMGadd.png" PostBackUrl="~/CreateProduct.aspx"/>
                </td>
            </tr>
        </table>
      
        <asp:label class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Won Giveaways</asp:label>
            <asp:DataList ID="DL2" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%" OnItemCommand="DL2_Command">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-radius:30px; margin-left:auto; margin-right:auto; height: 440px;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","ProductIMGS/{0}") %>' CssClass="IMG"/>
                    <asp:Label ID="LBLCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Code") %>' Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pname") %>' Visible="true" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>' Visible="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTNAccept" runat="server" Text="Arrived" CommandName="Arrived_Click"/>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
            </div>
    </section>
    <style>
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