﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test_DDL.aspx.cs" Inherits="Test_DDL" %>


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

        <link href="../App_Themes/chosen/chosen.css" rel="stylesheet" />
    <%--<link href="../App_Themes/chosen/docsupport/style.css" rel="stylesheet" />--%>
    <%--<link href="../App_Themes/chosen/docsupport/prism.css" rel="stylesheet" />--%>

    <script src="../App_Themes/metro/js/jquery-2.1.3.min.js"></script>

    <script src="../App_Themes/metro/js/metro.js"></script>
    <script src="../App_Themes/metro/js/js.js"></script>


    <script src="../App_Themes/chosen/chosen.jquery.js"></script>
    <%--<script src="../App_Themes/chosen/docsupport/prism.js"></script>--%>


</head>
<body class="bg-steel">
    <form id="form1" runat="server" data-role="validator">
        <% Response.Write(HtmlMaster.Header_Full); %>
        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>
                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">

                        <h3 style="padding-left: 5%;">Dashboard</h3>

                        <div class="side-by-side clearfix select">
                            <asp:DropDownList runat="server" ID="ddltest" data-placeholder="Choose a Country..."
                                class="chosen-select" Style="width: 350px;" TabIndex="2">
                            </asp:DropDownList>
                        </div>



                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>



<script type="text/javascript">
    var config = {
        '.chosen-select': {},
        '.chosen-select-deselect': { allow_single_deselect: true },
        '.chosen-select-no-single': { disable_search_threshold: 10, disable_search: false },
        '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
        '.chosen-select-width': { width: "95%" }
    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }
  </script>


