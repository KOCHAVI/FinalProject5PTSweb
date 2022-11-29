<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Home</title>
    <link rel="stylesheet" href="Home.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
      <div class="u-clearfix u-sheet u-sheet-1">
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-1" src="images/aaaaa-min.png" alt="" data-image-width="709" data-image-height="709" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="" data-animation-delay="250">
        <img class="u-hover-feature u-image u-image-contain u-image-round u-image-2" src="images/vcvc.png" alt="" data-image-width="300" data-image-height="666" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction="">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Win Big Prices!</h1>
        <div class="u-align-left u-container-style u-expanded-width-xs u-gradient u-group u-radius-50 u-shape-round u-group-1" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-delay="250">
          <div class="u-container-layout u-container-layout-1">
              <table style="margin:auto; font-size:30px;padding-top: 10px;">
                  <tr>
                      <td>
                          <asp:HyperLink ID="HL1" runat="server" CssClass="HL" Text="Home | " NavigateUrl="Home.aspx"></asp:HyperLink>
                          <asp:HyperLink ID="HL2" runat="server" CssClass="HL" Text="Register | " NavigateUrl="Register.aspx"></asp:HyperLink>
                          <asp:HyperLink ID="HL3" runat="server" CssClass="HL" Text="Login" NavigateUrl="Login.aspx"></asp:HyperLink>
                          <asp:HyperLink ID="HL4" runat="server" CssClass="HL" Text="" NavigateUrl=""></asp:HyperLink>
                      </td>
                  </tr>
              </table>
          </div>
        </div>
        <a href="BuyCoins.aspx" class="infinite u-border-2 u-border-hover-palette-1-dark-1 u-border-palette-1-base u-btn u-btn-round u-button-style u-gradient u-hover-palette-1-base u-none u-radius-50 u-btn-1" data-animation-name="tada" data-animation-duration="1000" data-animation-direction="">Buy Coins</a>
        <img class="u-hover-feature u-image u-image-default u-preserve-proportions u-image-3" src="images/xxxx.png" alt="" data-image-width="1155" data-image-height="900" data-animation-name="customAnimationIn" data-animation-duration="1250">
        <img class="u-hover-feature u-image u-image-contain u-image-default u-image-4" src="images/s.png" alt="" data-image-width="791" data-image-height="681" data-animation-name="customAnimationIn" data-animation-duration="1000">
      </div>
    </section>
    <section class="u-align-center u-clearfix u-section-2" id="carousel_440a">
      <div class="u-clearfix u-sheet u-sheet-1">
        <h2 class="u-text u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="500">How It Works?</h2>
        <div class="u-expanded-width u-list u-list-1">
          <div class="u-repeater u-repeater-1">
            <div class="u-container-style u-list-item u-repeater-item u-white u-list-item-1">
              <div class="u-container-layout u-similar-container u-valign-top-lg u-valign-top-md u-container-layout-1"><span class="u-file-icon u-icon u-icon-1" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction=""><img src="images/yyy.png" alt=""></span>
                <div class="u-container-style u-expanded-width-md u-group u-group-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-direction="" data-animation-delay="250">
                  <div class="u-container-layout u-container-layout-2">
                    <h5 class="u-text u-text-palette-1-base u-text-2">1. Buy coins</h5>
                    <p class="u-text u-text-3">Go to Buy Coins page<br>1$ = 100&nbsp;<span class="u-file-icon u-icon"><img src="images/1039714.png" alt=""></span>
                    </p>
                  </div>
                </div>
              </div>
            </div>
            <div class="u-container-style u-list-item u-repeater-item u-white u-list-item-2">
              <div class="u-container-layout u-similar-container u-valign-top-lg u-valign-top-md u-container-layout-3"><span class="u-file-icon u-icon u-icon-3" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction=""><img src="images/1.png" alt=""></span>
                <div class="u-container-style u-expanded-width-md u-group u-video-cover u-group-2" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-direction="" data-animation-delay="250">
                  <div class="u-container-layout u-container-layout-4">
                    <h5 class="u-text u-text-palette-1-base u-text-4">2. use coins on products</h5>
                    <p class="u-text u-text-5">More coins = More % to Win!</p>
                  </div>
                </div>
              </div>
            </div>
            <div class="u-container-style u-list-item u-repeater-item u-white u-list-item-3">
              <div class="u-container-layout u-similar-container u-valign-top-lg u-valign-top-md u-container-layout-5"><span class="u-file-icon u-icon u-icon-4" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction=""><img src="images/2.png" alt=""></span>
                <div class="u-container-style u-expanded-width-md u-group u-video-cover u-group-3" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-direction="" data-animation-delay="250">
                  <div class="u-container-layout u-container-layout-6">
                    <h5 class="u-text u-text-palette-1-base u-text-6">3. giveaway end</h5>
                    <p class="u-text u-text-7">Only one WINNER we be choosen</p>
                  </div>
                </div>
              </div>
            </div>
            <div class="u-container-style u-list-item u-repeater-item u-white u-list-item-4">
              <div class="u-container-layout u-similar-container u-valign-top-lg u-valign-top-md u-container-layout-7"><span class="u-file-icon u-icon u-icon-5" data-animation-name="customAnimationIn" data-animation-duration="1000" data-animation-direction=""><img src="images/56.png" alt=""></span>
                <div class="u-container-style u-expanded-width-md u-group u-video-cover u-group-4" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-direction="" data-animation-delay="250">
                  <div class="u-container-layout u-container-layout-8">
                    <h5 class="u-text u-text-palette-1-base u-text-8">4. you get the price!</h5>
                    <p class="u-text u-text-9">Winner will get the price in less then 10 days!</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <section class="u-clearfix u-image u-shading u-section-3 u-section-1 u-align-center" data-image-width="1980" data-image-height="1457" id="sec-d400">
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="width:auto">Giveaways</h1>
        <asp:TextBox ID="TBSearch" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="2px" Width="20%" BorderColor="Black"></asp:TextBox>
        <asp:ImageButton ID="SearchBut" runat="server" OnClick="SearchBut_Click" CssClass="SRH" ImageUrl="~/images/SRC.png"/></br></br>

        <asp:DataList ID="DL" OnItemCommand="DL_Command" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-spacing:15px 20px; border-radius:30px; margin-left:auto; margin-right:auto;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Image ID="IMG" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","ProductIMGS/{0}") %>' CssClass="IMG"/>
                    <asp:Label ID="LBLCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Code") %>' Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Pname") %>' Visible="true" Font-Bold="true" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLTickets" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Tickets") + "/" + DataBinder.Eval(Container.DataItem,"Price")%>' Visible="true" ForeColor="Green"></asp:Label>              
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TBCoins" runat="server" ForeColor="black"></asp:TextBox>
                    <asp:Button ID="BTNBuy" runat="server" Text="Buy" CommandName="Buy_Click"/>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
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
        HL{
            font-size:30px;
        }
    </style>
</asp:Content>