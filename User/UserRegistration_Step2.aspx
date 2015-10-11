<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration_Step2.aspx.cs" Inherits="UserRegistration_Step" %>


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

    <script type="text/javascript">
        function ChefEditorsChb() {
            if (document.getElementById("chbCheffEditor").checked == true) {
                document.getElementById("chbEditor").checked = true;
            }
        };
        function EditorsChb() {
            if (document.getElementById("chbEditor").checked == false) {
                document.getElementById("chbCheffEditor").checked = false;
            }
        };
       
    </script>

</head>
<body class="bg-steel">
    <form id="form1" runat="server" data-role="validator">
        <% Response.Write(HtmlMaster.Header_Full); %>

        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>

                    <div class="cell auto-size padding20 bg-white">

                        <h3 style="padding-left: 5%;">User Registration Step 2 :</h3>
                        <br />
                        <h4 style="padding-left: 5%;">Select Role :</h4>

                        <table>
                            <tr>
                                <div style="padding-left: 5%;">

                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbCheffEditor" onchange="ChefEditorsChb()" />
                                        <span class="check"></span>
                                        <span class="caption">Cheff Editor</span>
                                    </label>
                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbEditor" onchange="EditorsChb()" />
                                        <span class="check"></span>
                                        <span class="caption">Editor</span>
                                    </label>
                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbAuthor" />
                                        <span class="check"></span>
                                        <span class="caption">Author</span>
                                    </label>
                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbReferee" />
                                        <span class="check"></span>
                                        <span class="caption">Referee</span>
                                    </label>
                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbLanguageEditor" />
                                        <span class="check"></span>
                                        <span class="caption">LanguageEditor</span>
                                    </label>
                                    <label class="input-control checkbox">
                                        <input type="checkbox" runat="server" id="chbSyntaxEditor" />
                                        <span class="check"></span>
                                        <span class="caption">Syntax Editor</span>
                                    </label>


                                </div>
                            </tr>
                            <tr>
                                <div style="padding-left: 5%;">
                                    <asp:Button ID="btnRoleRegister" runat="server" class="button loading-pulse lighten primary " Text="Register Role" ValidationGroup="test"
                                        OnClick="btnRoleRegister_Click"></asp:Button>
                                </div>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
