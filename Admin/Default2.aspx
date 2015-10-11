<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

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
    <form id="form1" runat="server">
        <!-- header -->
        <% Response.Write(HtmlMaster.Header_Full); %>
        <%-- <div class="app-bar fixed-top darcula" data-role="appbar">
            <a class="app-bar-element branding">Site Name</a>
            <span class="app-bar-divider"></span>
            <ul class="app-bar-menu">
                <li><a href="../Admin/Default2.aspx">Dashboard</a></li>
                
                <li>
                    <a href="" class="dropdown-toggle">Help</a>
                    <ul class="d-menu" data-role="dropdown">
                        <li><a href="">ChatOn</a></li>
                        <li><a href="">Community support</a></li>
                        <li class="divider"></li>
                        <li><a href="">About</a></li>
                    </ul>
                </li>
            </ul>

            <div class="app-bar-element place-right">
                <span class="dropdown-toggle"><span class="mif-cog"></span ><asp:Label runat="server" ID="lblUserFullname"></asp:Label></span>
                <div class="app-bar-drop-container padding10 place-right no-margin-top block-shadow fg-dark" data-role="dropdown" data-no-close="true" style="width: 220px">
                    <h2 class="text-light">Quick settings</h2>
                    <ul class="unstyled-list fg-dark">
                        <li><a href="../ProFile.aspx" class="fg-white1 fg-hover-yellow">Profile</a></li>
                        <li><a href="" class="fg-white2 fg-hover-yellow">Security</a></li>
                        <li><a href="../Logout.aspx" class="fg-white3 fg-hover-yellow">Exit</a></li>
                    </ul>
                </div>
            </div>
        </div>--%>

        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <%--   <% Response.Write(HtmlMaster.Sidebar_Full); %>--%>
                    <%-- <div class="cell size-x200" id="cell-sidebar" style="background-color: rgb(66,66,66); height: 100%">
                        <ul class="sidebar2 dark">
                            <li class="title">Tools</li>
                            <li><a href="#"><span class="mif-home icon"></span>Home</a></li>
                            <li class="divider"></li>
                            <li>
                                <a href="#" class="dropdown-toggle"><span class="mif-user icon"></span>User Registration</a>
                                <ul class="d-menu" data-role="dropdown">
                                    <li><a href="#">Referee</a></li>
                                    <li><a href="#">Editor</a></li>
                                </ul>
                            </li>
                            <li><a href="#"><span class="mif-list2 icon"></span>Users List</a></li>
                            <li><a href="#"><span class="mif-list icon"></span>Paper List</a></li>
                            <li><a href="../Paper/SubmitOnline.aspx"><span class="mif-list icon"></span>Submit online</a></li>
                            <li>
                                <a href="#" class="dropdown-toggle"><span class="mif-mail-read icon"></span>Messages</a>
                                <ul class="d-menu" data-role="dropdown">
                                    <li><a href="#">Send</a></li>
                                    <li><a href="#">Inbox</a></li>
                                    <li><a href="#">SentBox</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>--%>

                  <%--  <div class="cell">
                        <ul class="sidebar2 bg-darkBlue dark compact ">
                            <li><a href="#">
                                <span class="mif-apps icon"></span>
                                <span class="title">Paper</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li class="stick bg-darkBlue">
                                <a class="dropdown-toggle" href="#"><span class="mif-tree icon"></span>Sub menu</a>
                                <ul class="t-menu horizontal" data-role="dropdown">
                                    <li><a href="#"><span class="icon mif-home"></span></a></li>
                                    <li><a href="#" class="dropdown-toggle"><span class="icon mif-compass"></span></a>
                                        <ul class="t-menu" data-role="dropdown">
                                            <li><a href="#"><span class="icon mif-home"></span></a></li>
                                            <li><a href="#"><span class="icon mif-compass"></span></a></li>
                                            <li><a href="#"><span class="icon mif-bubbles"></span></a></li>
                                            <li><a href="#"><span class="icon mif-file-empty"></span></a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#"><span class="icon mif-bubbles"></span></a></li>
                                </ul>
                            </li>

                            <li class="stick bg-green">
                                <a class="dropdown-toggle" href="#"><span class="mif-tree icon"></span>Sub menu</a>
                                <ul class="d-menu" data-role="dropdown">
                                    <li><a href=""><span class="mif-vpn-lock icon"></span> Subitem 1</a></li>
                                    <li><a href="">Subitem 2</a></li>
                                    <li><a href="">Subitem 3</a></li>
                                    <li><a href="">Subitem 4</a></li>
                                    <li class="disabled"><a href="">Subitem 5</a></li>
                                </ul>
                            </li>
                            <li><a href="#">
                                <span class="mif-drive-eta icon"></span>
                                <span class="title">Virtual machines</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-cloud icon"></span>
                                <span class="title">Cloud services</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-database icon"></span>
                                <span class="title">SQL Databases</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-cogs icon"></span>
                                <span class="title">Automation</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-apps icon"></span>
                                <span class="title">all items</span>
                                <span class="counter">0</span>
                            </a></li>

                        </ul>
                    </div>--%>

                    <%--     <div class="cell">
                     <ul class="sidebar " >
                            <li><a href="#">
                                <span class="mif-apps icon"></span>
                                <span class="title">all items</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-vpn-publ icon"></span>
                                <span class="title">websites</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li class="active"><a href="#">
                                <span class="mif-drive-eta icon"></span>
                                <span class="title">Virtual machines</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-cloud icon"></span>
                                <span class="title">Cloud services</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-database icon"></span>
                                <span class="title">SQL Databases</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-cogs icon"></span>
                                <span class="title">Automation</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-apps icon"></span>
                                <span class="title">all items</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-vpn-publ icon"></span>
                                <span class="title">websites</span>
                                <span class="counter">0</span>
                            </a></li>
                            <li><a href="#">
                                <span class="mif-vpn-lock icon"></span>
                                <span class="title">websites</span>
                                <span class="counter">0</span>
                            </a></li>
                        </ul>
                        </div>--%>




                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">
                        <h1 class="text-light">Virtual machines <span class="mif-drive-eta place-right"></span></h1>
                        <hr class="thin bg-grayLighter">
                        <button class="button primary" onclick="pushMessage('info')"><span class="mif-plus"></span>Create...</button>
                        <button class="button success" onclick="pushMessage('success')"><span class="mif-play"></span>Start</button>
                        <button class="button warning" onclick="pushMessage('warning')"><span class="mif-loop2"></span>Restart</button>
                        <button class="button alert" onclick="pushMessage('alert')">Stop all machines</button>
                        <hr class="thin bg-grayLighter">
                        <table class="dataTable border bordered" data-role="datatable" data-auto-width="false">
                            <thead>
                                <tr>
                                    <td style="width: 20px"></td>
                                    <td class="sortable-column sort-asc" style="width: 100px">ID</td>
                                    <td class="sortable-column">Machine name</td>
                                    <td class="sortable-column">Address</td>
                                    <td class="sortable-column" style="width: 20px">Status</td>
                                    <td style="width: 20px">Switch</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <label class="input-control checkbox small-check no-margin">
                                            <input type="checkbox">
                                            <span class="check"></span>
                                        </label>
                                    </td>
                                    <td>123890723212</td>
                                    <td>Machine number 1</td>
                                    <td><a href="http://virtuals.com/machines/123890723212">link</a></td>
                                    <td class="align-center"><span class="mif-checkmark fg-green"></span></td>
                                    <td>
                                        <label class="switch-original">
                                            <input type="checkbox" checked>
                                            <span class="check"></span>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label class="input-control checkbox small-check no-margin">
                                            <input type="checkbox">
                                            <span class="check"></span>
                                        </label>
                                    </td>
                                    <td>123890723212</td>
                                    <td>Machine number 2</td>
                                    <td><a href="http://virtuals.com/machines/123890723212">link</a></td>
                                    <td class="align-center"><span class="mif-stop fg-red"></span></td>
                                    <td>
                                        <label class="switch-original">
                                            <input type="checkbox">
                                            <span class="check"></span>
                                        </label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
