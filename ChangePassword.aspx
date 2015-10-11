<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

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

                        <h3 style="padding-left: 3%;">Change Password</h3>

                        <div style="padding-left: 3%;">

                            <table class="table" style="width: 50%;">


                                <tr runat="server" id="trOldPass">
                                    <td>
                                        <asp:Label runat="server" ID="lblOldPassword" Text="Old Password:" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-lock "></span>
                                            <asp:TextBox runat="server" ID="txtbOldPassWord" TextMode="Password" placeholder="OldPassword..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>

                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblNewPass" Text="New Password:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control password full-size" data-role="input">
                                            <span class=" prepend-icon mif-lock "></span>
                                            <asp:TextBox runat="server" ID="txtbNewPass" TextMode="Password" placeholder="NewPassword..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <div class="button-group">
                                                <button class="button helper-button reveal"><span class="mif-looks"></span></button>
                                                <span class="input-state-error mif-warning"></span>
                                                <span class="input-state-success mif-checkmark"></span>
                                            </div>

                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Button ID="btnChangePassword" runat="server" class="button loading-pulse lighten primary " Text="Change PassWord" OnClick="btnChangePassword_Click"></asp:Button>
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
