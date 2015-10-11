<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


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

    <script src="../App_Themes/metro/js/metro.js"></script>
    <script src="../App_Themes/metro/js/js.js"></script>

    <style>
        .login-form {
            width: 25rem;
            height: 18.75rem;
            position: fixed;
            top: 50%;
            margin-top: -9.375rem;
            left: 50%;
            margin-left: -12.5rem;
            background-color: #ffffff;
            opacity: 0;
            -webkit-transform: scale(.8);
            transform: scale(.8);
        }
    </style>

    <script>
        $(function () {
            var form = $(".login-form");

            form.css({
                opacity: 1,
                "-webkit-transform": "scale(1)",
                "transform": "scale(1)",
                "-webkit-transition": ".5s",
                "transition": ".5s"
            });
        });
    </script>


</head>
<body class="bg-darkTeal">
    <div class="login-form padding20 block-shadow">
        <form runat="server" data-role="validator">
            <h1 class="text-light">Login to Jurnal</h1>
            <hr class="thin" />
            <br />
            <div class="input-control text full-size" data-role="input">
                <span class=" prepend-icon mif-mail "></span>
                <asp:TextBox runat="server" ID="txtEmail" TextMode="SingleLine" placeholder="Email..."
                    data-validate-func="email"
                    data-validate-hint="Not valid email address!">                     
                </asp:TextBox>  
                 <span class="input-state-error mif-warning"></span>            
                <span class="input-state-success mif-checkmark"></span>             
                <br />
            </div>
            <br />
            <br />
            <div class="input-control password full-size" data-role="input">
                <span class=" prepend-icon mif-lock "></span>
                <asp:TextBox runat="server" ID="txtPass" TextMode="Password" placeholder="Password..."
                    data-validate-func="required"
                    data-validate-hint="This field can not be empty!"></asp:TextBox>
                <div class="button-group">
                    <button class="button helper-button reveal"><span class="mif-looks"></span></button>
                    <span class="input-state-error mif-warning"></span>
                    <span class="input-state-success mif-checkmark"></span>
                </div>
            </div>
            <br />
            <br />
            <div class="form-actions">
                <asp:Button ID="btnLogin" runat="server" class="button loading-pulse lighten primary" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                <%--  <a href="UserRegistration.aspx">Sing up as author</a>
                Or
                <a href="Admin/Default2.aspx">Go to dashboard</a>--%>

            </div>
        </form>
    </div>

    <!-- hit.ua -->
    <a href='http://hit.ua/?x=136046' target='_blank'>
        <script language="javascript" type="text/javascript"><!--
    Cd = document; Cr = "&" + Math.random(); Cp = "&s=1";
    Cd.cookie = "b=b"; if (Cd.cookie) Cp += "&c=1";
    Cp += "&t=" + (new Date()).getTimezoneOffset();
    if (self != top) Cp += "&f=1";
    //--></script>
        <script language="javascript1.1" type="text/javascript"><!--
    if (navigator.javaEnabled()) Cp += "&j=1";
    //--></script>
        <script language="javascript1.2" type="text/javascript"><!--
    if (typeof (screen) != 'undefined') Cp += "&w=" + screen.width + "&h=" +
    screen.height + "&d=" + (screen.colorDepth ? screen.colorDepth : screen.pixelDepth);
    //--></script>
        <script language="javascript" type="text/javascript"><!--
    Cd.write("<img src='http://c.hit.ua/hit?i=136046&g=0&x=2" + Cp + Cr +
    "&r=" + escape(Cd.referrer) + "&u=" + escape(window.location.href) +
    "' border='0' wi" + "dth='1' he" + "ight='1'/>");
    //--></script>
    </a>
    <!-- / hit.ua -->


</body>
</html>
