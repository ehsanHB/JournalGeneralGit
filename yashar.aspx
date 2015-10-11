﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yashar.aspx.cs" Inherits="yashar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head lang="en">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="description" content="Metro, a sleek, intuitive, and powerful framework for faster and easier web development for Windows Metro Style.">
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, framework, metro, front-end, frontend, web development">
    <meta name="author" content="Sergey Pimenov and Metro UI CSS contributors">

    <link rel='shortcut icon' type='image/x-icon' href='favicon.ico' />
    <title>Notify system :: Metro UI CSS - The front-end framework for developing projects on the web in Windows Metro Style</title>

    <link href="css/metro.css" rel="stylesheet">
    <link href="css/metro-icons.css" rel="stylesheet">
    <link href="css/metro-responsive.css" rel="stylesheet">
    <link href="css/metro-schemes.css" rel="stylesheet">

    <link href="css/docs.css" rel="stylesheet">

    <script src="js/jquery-2.1.3.min.js"></script>
    <script src="js/metro.js"></script>
    <script src="js/docs.js"></script>
    <script src="js/prettify/run_prettify.js"></script>
    <script src="js/ga.js"></script>
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>

    <style>
        .example .notify {
            width: 100%;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">

        <table>
            <tr>
                <td>
                    <input type="text" name="MyBox" />
                    <asp:Button ID="btn" runat="server" Text="btn" OnClick="btn_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <select id="testSelect" name="testSelect">
                        <option value="1">One</option>
                        <option value="2">Two</option>
                    </select>
                    <asp:Button ID="btnTest" runat="server" Text="Test it!" OnClick="btnTest_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
