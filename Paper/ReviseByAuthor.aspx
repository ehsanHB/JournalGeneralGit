<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviseByAuthor.aspx.cs" Inherits="Paper_ReviseByAuthor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="description" content="Journal" />
    <meta name="keywords" content="Journal" />
    <meta name="author" content="Batis Programing group" />

    <link rel='shortcut icon' type='App_Themes/metro/image/x-icon' href='../favicon.ico' />
    <title></title>

    <link href="../App_Themes/metro/css/metro.css" rel="stylesheet" />
    <link href="../App_Themes/metro/css/metro-icons.css" rel="stylesheet" />
    <link href="../App_Themes/metro/css/metro-responsive.css" rel="stylesheet" />
    <link href="../App_Themes/metro/css/StyleSheet.css" rel="stylesheet" />

    <script src="../App_Themes/metro/js/jquery-2.1.3.min.js"></script>
    <script src="../App_Themes/metro/js/jquery.dataTables.min.js"></script>

    <script src="../App_Themes/metro/js/metro.js"></script>
    <script src="../App_Themes/metro/js/js.js"></script>

</head>
<body class="bg-steel">
    <form id="form1" runat="server" data-role="validator">
        <% Response.Write(HtmlMaster.Header_Full); %>

        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>

                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">
                        <div>
                            <ul class="breadcrumbs">
                                <li><a href="#"><span class="icon mif-home"></span></a></li>
                                <li><a href="#">Revise By Author</a></li>
                                <li><a href="#">Step 1</a></li>
                            </ul>
                        </div>
                        <h3 style="padding-left: 5%;">Step 1 : General Information</h3>
                        <div style="padding-left: 5%;">

                            <table class="table" style="width: 55%;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblAbstract" Text="Abstract:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-stack3 "></span>
                                            <asp:TextBox runat="server" ID="txtbAbstract" TextMode="SingleLine" placeholder=" Abstract..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblFeildPaper" Text="Field Of Paper:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-books "></span>
                                            <asp:TextBox runat="server" ID="txtbFeildPaper" TextMode="SingleLine" placeholder=" Field Of Paper..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblKeyWord" Text="Key Word:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-tag"></span>
                                            <asp:TextBox runat="server" ID="txtbKeyWord" TextMode="SingleLine" placeholder=" Key Word..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                            <div style="color: crimson; padding-top: 2%">
                                                <asp:Label runat="server" ID="lblkeyWordTag" Text=' * Seperate Your Keys By " , "'></asp:Label>
                                            </div>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnStep2" runat="server" class="button loading-pulse lighten primary full-size" 
                                            Text="Next Step >" OnClick="btnStep2_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
