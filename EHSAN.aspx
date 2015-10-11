<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EHSAN.aspx.cs" Inherits="EHSAN" %>

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

    <link href="App_Themes/metro/css/metro.css" rel="stylesheet" />
    <link href="App_Themes/metro/css/metro-icons.css" rel="stylesheet" />
    <link href="App_Themes/metro/css/metro-responsive.css" rel="stylesheet" />
    <link href="App_Themes/metro/css/StyleSheet.css" rel="stylesheet" />

    <script src="App_Themes/metro/js/jquery-2.1.3.min.js"></script>
    <script src="App_Themes/metro/js/jquery.dataTables.min.js"></script>

    <script src="App_Themes/metro/js/metro.js"></script>
    <script src="App_Themes/metro/js/js.js"></script>

    <link href="App_Themes/metro/DropDown/jquery-ui.min.css" rel="stylesheet" />
    <script src="App_Themes/metro/DropDown/jquery-ui.min.js"></script>
    <style>
       
    </style>
</head>
<body class="bg-steel">
    <!-- header -->
    <% Response.Write(HtmlMaster.Header_Full); %>

    <div class="page-content">
        <div class="flex-grid no-responsive-future OverFlowScrol" style="height: 100%;">
            <div class="row" style="height: 100%">

                <% Response.Write(HtmlMaster.Sidebar_Full); %>
                <form id="form1" runat="server">

                    <div class="cell auto-size padding20 bg-white " id="cell-content">
                        <div id="pupup" data-role="dialog">

                            <div class="full-size">
                            </div>
                        </div>
                        <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                        <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="btn 1" OnClick="btn1_Click" />

                    </div>
                </form>
                <form action="ehsan.ashx" method="post">
                    <input type="text" name="testtest" id="txt1" value="<%=this.test %>" />
                    <input type="text" id="txt2" />
                    <input id="btn" type="submit" />
                </form>

            </div>
        </div>
    </div>


</body>
</html>
<script>
    function btnCloseClick() {
        alert('close');
        var dialog = $('#popup').data('dialog');
        dialog.close();
    }
</script>
