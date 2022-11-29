<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>AdminPage</title>
    <link rel="stylesheet" href="BuyCoins.css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <section class="u-align-center u-clearfix u-image u-section-1" id="carousel_cb7a" data-image-width="1197" data-image-height="598">
        <div class="u-clearfix u-sheet u-sheet-1">
            <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250">Admin Page</h1>
            <asp:TextBox ID="TBSearch" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="2px" Width="20%" BorderColor="Black"></asp:TextBox>
            <asp:ImageButton ID="SearchBut" runat="server" OnClick="SearchBut_Click" CssClass="SRH" ImageUrl="~/images/SRC.png"/></br></br>
            <asp:GridView ID="GV" runat="server" CssClass="GV" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" EnableModelValidation="True" ForeColor="Black">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        <asp:Label ID="LBLTEXT" runat="server" Text="">
            <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="height:60%">Products</h1>
        </asp:Label>      
            <asp:DataList ID="DL" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
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
                    <asp:Label ID="LBLPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Price") + " Coins" %>' Visible="true" ForeColor="Green"></asp:Label>
                </td>   
            </tr>
        </table>       
    </ItemTemplate>
</asp:DataList>
            <asp:Label ID="LBLTEXT2" runat="server" Text="">
            <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="height:60%">Waiting For Confirmation</h1>
            </asp:Label>
            <asp:DataList ID="DL2" OnItemCommand="DL2_Command" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
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
        <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="height:60%">Giveaways</h1>
    <asp:TextBox ID="TBSearch1" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="2px" Width="20%" BorderColor="Black"></asp:TextBox>
        <asp:ImageButton ID="SearchBut1" runat="server" OnClick="SearchBut2_Click" CssClass="SRH" ImageUrl="~/images/SRC.png"/></br></br>
            <asp:DataList ID="DL3" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
    <ItemTemplate>
        <table style="background-color:rgba(255,255,255,0.3); border-radius:30px; margin-left:auto; margin-right:auto; height: 440px;">
            <tr>
                <td>
                    <asp:Label ID="LBLWinner" runat="server" Text=' <%# "Winner: " + DataBinder.Eval(Container.DataItem,"Winner") %>' Visible="true" Font-Size="X-Large" Font-Bold="true"></asp:Label>              
                </td>
            </tr>
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
                    <asp:Label ID="LBLPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Price") + " Coins" %>' Visible="true" ForeColor="Green"></asp:Label>              
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GStatus") %>' Visible="true"></asp:Label>
                    <asp:Label ID="LBLStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StartDate") %>' Visible="true"></asp:Label>
                </td>
            </tr>
        </table>       
    </ItemTemplate>
            </asp:DataList>
            <h1 class="u-hover-feature u-text u-text-body-alt-color u-text-1" data-animation-name="customAnimationIn" data-animation-duration="1250" data-animation-delay="250" style="height:60%">All Vehicles</h1>
            <asp:TextBox ID="TextBox1" runat="server" BackColor="Transparent" Font-Size="20px" BorderWidth="2px" Width="20%" BorderColor="Black"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="SearchBut2_Click" CssClass="SRH" ImageUrl="~/images/SRC.png"/></br></br>
        <asp:CheckBox runat="server" id="CHECKBX" OnCheckedChanged="CHECKBX_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
        <asp:DropDownList runat="server" id="DDLday" CssClass="DDL" OnSelectedIndexChanged="DDL_SelectedIndexChanged"></asp:DropDownList><asp:DropDownList runat="server" id ="DDLmonth" CssClass="DDL" OnSelectedIndexChanged="DDL_SelectedIndexChanged"></asp:DropDownList><asp:DropDownList runat="server" id="DDLyear" CssClass="DDL" OnSelectedIndexChanged="DDL_SelectedIndexChanged"></asp:DropDownList>
        <asp:Datalist ID="DL4" runat="server" RepeatLayout="Flow" RepeatColumns="3" EditItemStyle-HorizontalAlign="center" ItemStyle-Width="33%" Width="100%">
            <ItemTemplate>
                <table style="background-color:rgba(255,255,255,0.3); border-radius:30px; margin-left:auto; margin-right:auto; height: 440px;">
            <tr>
                <td style="width:300px; height:200px;">
                    <asp:Label ID="LBLVCode" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem,"VCode") %>' Visible="false"></asp:Label>
                    <asp:Image ID="IMG" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","ProductIMGS/{0}") %>' CssClass="IMG"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLName" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem,"VName").ToString() + DataBinder.Eval(Container.DataItem,"VType").ToString()%>' Visible="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLCapacity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Capacity") %>' Visible="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"VStatus") %>' Visible="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="accordion">
                        <div class="contentBx">
                            <div class="label">All Products</div>
                            <div class="content">
                                <asp:Label ID="LBLContent" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Content") %>' Visible="true"></asp:Label>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>  
            </ItemTemplate>
        </asp:Datalist>
            <script>
                const arr = document.getElementsByClassName
                    ('contentBx')

                for (var i = 0; i < arr.length; i++) {
                    arr[i].addEventListener('click', function(){
                        this.classList.toggle('active')
                    })
                }
            </script>
    </div>
    </section>
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
        .accordion {
            max-width:800px;
        }
        .accordion .contentBx {
            position:relative;
            margin:10px 20px;
        }
        .accordion .contentBx .label {
            position:relative;
            padding:10px;
            cursor:pointer;
        }
        .accordion .contentBx .label:before {
            content: '+';
            position:absolute;
            top:50%;
            right:20%;
            transform:translateY(-50%);
            font-size:1.5em;
        }
        .accordion .contentBx.active .label:before {
            content:'-';
        }
        .accordion .contentBx .content {
            position:relative;
            height:0;
            overflow:hidden;
            transition:0.5s;
            overflow-y:auto;
        }
        .accordion .contentBx.active .content {
            height:150px;
            padding:10px;
        }
        .DDL {
            -webkit-appearance: none;
            border-radius:5px;
            background-color:transparent;
            border-color:black;
            margin-right:5px;
        }
    </style>
</asp:Content>