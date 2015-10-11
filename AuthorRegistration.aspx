<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuthorRegistration.aspx.cs" Inherits="UserRegistration" EnableEventValidation="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="description" content="Metro, a sleek, intuitive, and powerful framework for faster and easier web development for Windows Metro Style." />
    <meta name="keywords" content="HTML, CSS, JS, JavaScript, framework, metro, front-end, frontend, web development" />
    <meta name="author" content="Sergey Pimenov and Metro UI CSS contributors" />

    <link rel='shortcut icon' type='App_Themes/metro/image/x-icon' href='../favicon.ico' />
    <title></title>

    <link href="App_Themes/metro/css/metro.css" rel="stylesheet" />
    <link href="App_Themes/metro/css/metro-icons.css" rel="stylesheet" />
    <link href="App_Themes/metro/css/metro-responsive.css" rel="stylesheet" />

    <script src="App_Themes/metro/js/jquery-2.1.3.min.js"></script>
    <script src="App_Themes/metro/js/metro.js"></script>
    <script src="App_Themes/metro/js/ga.js"></script>
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>

</head>
<body>
    <form id="form1" runat="server" data-role="validator">

        <div class="container">
            <header class="margin20 no-margin-left no-margin-right">
                <div class="clear-float">
                    <div class="place-right">
                        <form>
                            <div class="input-control text margin20" style="width: 300px">
                                <input type="text" name="q" placeholder="Search...">
                                <button class="button"><span class="mif-search"></span></button>
                            </div>
                        </form>
                    </div>
                    <a class="place-left" href="#" title="">
                        <h1>Journal Portal</h1>
                    </a>
                </div>

                <div class="main-menu-wrapper">
                    <ul class="horizontal-menu" style="margin-left: -20px">
                        <li><a href="#">Home</a></li>
                        <li><a href="#">Login</a></li>
                        <li><a href="#">Contacts</a></li>
                        <li><a href="#">About</a></li>
                        <li class="place-right">
                            <a href="#" class="dropdown-toggle">Paper</a>
                            <ul class="d-menu place-right" data-role="dropdown">
                                <li><a href="#">Editorial Board</a></li>
                                <li><a href="#">Submit online</a></li>
                                <li><a href="#">Aims and Scopes</a></li>
                                <li><a href="#">Instruction for author</a></li>

                            </ul>
                        </li>
                    </ul>
                </div>
            </header>

            <div class="main-content clear-float">
                <div class="tile-area no-padding">
                    <div class="tile-group no-margin no-padding" style="width: 100%">
                        <div class="tile-large tile-super-y bg-gray ol-transparent" style="float: right;">
                            <div class="tile-content">
                                <div class="brand padding10">
                                    <h3 class="fg-white">Adverts</h3>
                                    <!-- Google adsense block -->
                                    <div><ins class="adsbygoogle" style="display: block" data-ad-client="ca-pub-1632668592742327" data-ad-slot="8347181909" data-ad-format="auto"></ins></div>
                                    <script>
                                        (adsbygoogle = window.adsbygoogle || []).push({});
                                    </script>
                                    <!-- End of gad block -->
                                    <!-- Google adsense block -->
                                    <br />
                                    <br />
                                    <div><ins class="adsbygoogle" style="display: block" data-ad-client="ca-pub-1632668592742327" data-ad-slot="8347181909" data-ad-format="auto"></ins></div>
                                    <script>
                                        (adsbygoogle = window.adsbygoogle || []).push({});
                                    </script>
                                    <!-- End of gad block -->
                                </div>
                            </div>
                            <%--<label>Test Slide</label>--%>
                        </div>


                        <table class="table" style="width: 50%;">
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblName" Text="First Name:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size">
                                        <span class=" prepend-icon mif-user "></span>
                                        <asp:TextBox runat="server" ID="txtbName" TextMode="SingleLine" placeholder="FirstName..."
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblLastName" Text="Last Name:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-user "></span>
                                        <asp:TextBox runat="server" ID="txtbLastName" TextMode="SingleLine" placeholder="LastName..."
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEmail" Text="Email:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-mail "></span>
                                        <asp:TextBox runat="server" ID="txtbEmail" TextMode="SingleLine" placeholder="Email..."
                                            data-validate-func="email"
                                            data-validate-hint="Not valid email address!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblAffiliations" Text="Affiliations:" CssClass="lbl fieldlbl"></asp:Label>

                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-users "></span>
                                        <asp:TextBox runat="server" ID="txtbAffiliations" TextMode="SingleLine" placeholder="Affiliations..."
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPhoneNumber" Text="Phone Number:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-phone "></span>
                                        <asp:TextBox runat="server" ID="txtbPhoneNumber" TextMode="SingleLine" placeholder="Phone Number..."
                                            data-validate-func="pattern"
                                            data-validate-arg="[0-9]{1,50}"
                                            data-validate-hint="Only numbers!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFax" Text="Fax:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-printer "></span>
                                        <asp:TextBox runat="server" ID="txtbFax" TextMode="SingleLine" placeholder="Fax..."
                                            data-validate-func="pattern"
                                            data-validate-arg="[0-9]{1,50}"
                                            data-validate-hint="Only numbers!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFieldsOfInterest" Text="Fields :" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size">
                                        <span class=" prepend-icon mif-favorite "></span>
                                        <asp:TextBox runat="server" ID="txtbFieldsOfInterest" TextMode="SingleLine" placeholder="Interest..."
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <%--      <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblPass" Text="Password:" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                        <td>
                                            <div class="input-control text full-size">
                                                <span class=" prepend-icon mif-lock "></span>
                                                <asp:TextBox runat="server" ID="txtbPass" TextMode="Password" placeholder="Password..."
                                                    data-validate-func="required"
                                                    data-validate-hint="This field can not be empty!"></asp:TextBox>
                                                <span class="input-state-error mif-warning"></span>
                                                <span class="input-state-success mif-checkmark"></span>
                                            </div>
                                        </td>
                                    </tr>--%>

                            <%--     <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblRePass" Text="Password:" CssClass="lbl fieldlbl"></asp:Label>

                                        </td>
                                        <td>
                                            <div class="input-control text full-size">
                                                <span class=" prepend-icon mif-lock "></span>
                                                <asp:TextBox runat="server" ID="txtbRePass" TextMode="Password" placeholder="Retype Password..."
                                                    data-validate-func="required"
                                                    data-validate-hint="This field can not be empty!"></asp:TextBox>
                                                <span class="input-state-error mif-warning"></span>
                                                <span class="input-state-success mif-checkmark"></span>
                                            </div>
                                        </td>
                                    </tr>--%>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNationalCode" Text="National Code:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-earth "></span>
                                        <asp:TextBox runat="server" ID="txtbNationalCode" TextMode="SingleLine" placeholder="National Code..."
                                            data-validate-func="pattern"
                                            data-validate-arg="[0-9]{1,50}"
                                            data-validate-hint="Only numbers!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEducation" Text="Education:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="input">
                                        <span class=" prepend-icon mif-school "></span>
                                        <asp:TextBox runat="server" ID="txtbEducation" TextMode="SingleLine" placeholder="Education..." ValidationGroup="test"
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <span class="input-state-error mif-warning"></span>
                                        <span class="input-state-success mif-checkmark"></span>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblbBirthDate" Text="BirthDate:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control text full-size" data-role="datepicker">
                                        <asp:TextBox runat="server" ID="txtbBirthDate" placeholder="BirthDate..." ValidationGroup="test"
                                            data-validate-func="required"
                                            data-validate-hint="This field can not be empty!"></asp:TextBox>
                                        <button class="button"><span class="mif-calendar"></span></button>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblGender" Text="Gender:" CssClass="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>
                                    <div class="input-control select full-size">
                                        <asp:DropDownList runat="server" CssClass="input-control select" ID="ddlGender">
                                            <%--                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnUserRegister" runat="server" class="button loading-pulse lighten primary " Text="Register" OnClick="btnUserRegister_Click"></asp:Button>
                                </td>
                                <%--   <td>
                                            <asp:Button ID="btnCansel" runat="server" class="button loading-pulse" Text="Cancel"></asp:Button>
                                        </td>--%>
                            </tr>

                        </table>
                        <%--<asp:Button ID="Button1" runat="server" Text="Register" OnClick="btnUserRegister_Click"></asp:Button>--%>



                        <!-- Tile with slide-right effect -->

                    </div>
                    <!-- End first group -->



                    <div class="tile-group no-margin no-padding" style="width: 100%">
                        <div class="tile-wide bg-cyan" data-role="tile">
                            <div class="tile-content image-set">
                                <img src="../images/jeki_chan.jpg">
                                <img src="../images/shvarcenegger.jpg">
                                <img src="../images/vin_d.jpg">
                                <img src="../images/jolie.jpg">
                                <img src="../images/jek_vorobey.jpg">
                            </div>
                        </div>
                        <div class="tile bg-green" data-role="tile" data-effect="slideUpDown">
                            <div class="tile-content">
                                <div class="live-slide">
                                    <img src="../images/jeki_chan.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/shvarcenegger.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/vin_d.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/jolie.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/jek_vorobey.jpg" data-role="fitImage" data-format="fill">
                                </div>
                            </div>
                        </div>
                        <div class="tile bg-green" data-role="tile" data-effect="slideLeftRight">
                            <div class="tile-content">
                                <div class="live-slide">
                                    <img src="../images/vin_d.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/jolie.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/jek_vorobey.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/jeki_chan.jpg" data-role="fitImage" data-format="fill">
                                </div>
                                <div class="live-slide">
                                    <img src="../images/shvarcenegger.jpg" data-role="fitImage" data-format="fill">
                                </div>
                            </div>
                        </div>
                        <div class="tile-wide bg-red" data-role="tile">
                            <div class="tile-content image-set">
                                <img src="../images/jeki_chan.jpg">
                                <img src="../images/shvarcenegger.jpg">
                                <img src="../images/vin_d.jpg">
                                <img src="../images/jolie.jpg">
                                <img src="../images/jek_vorobey.jpg">
                            </div>
                        </div>
                    </div>


                    <h3 class="fg-orange text-light margin5">NEWS <span class="mif-chevron-right mif-2x" style="vertical-align: top !important;"></span></h3>
                    <div class="tile-group no-margin no-padding" style="width: 100%;">
                        <div class="tile-large ol-transparent" data-role="tile"></div>
                        <div class="tile-wide ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile-wide ol-transparent" data-role="tile"></div>
                    </div>

                    <h3 class="fg-blue text-light margin5">SPORT <span class="mif-chevron-right mif-2x" style="vertical-align: top !important;"></span></h3>
                    <div class="tile-group no-margin no-padding" style="width: 100%;">
                        <div class="tile-large ol-transparent" data-role="tile"></div>
                        <div class="tile-wide ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile ol-transparent" data-role="tile"></div>
                        <div class="tile-wide ol-transparent" data-role="tile"></div>
                    </div>
                </div>
            </div>
            <!-- End of tiles -->

            <footer>
                <div class="bottom-menu-wrapper">
                    <ul class="horizontal-menu compact">
                        <li><a>&copy; 2014 Metro UI CSS</a></li>
                        <li class="place-right"><a href="#">Privacy</a></li>
                        <li class="place-right"><a href="#">Legal</a></li>
                        <li class="place-right"><a href="#">Advertise</a></li>
                        <li class="place-right"><a href="#">Help</a></li>
                        <li class="place-right"><a href="#">Feedback</a></li>
                    </ul>
                </div>
            </footer>
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

    </form>
</body>
</html>
