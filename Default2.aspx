<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

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
    <form id="form1" runat="server">

        <div class="container">
            <header class="margin20 no-margin-left no-margin-right">
                <div class="clear-float">
                    <div class="place-right">
                        <form>
                            <div class="input-control text margin20" style="width: 300px">
                                <input type="text" name="q" placeholder="Search..." />
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
                        <li><a href="Login.aspx">Login</a></li>
                        <li><a href="#">Contacts</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="AuthorRegistration.aspx">Author Registration</a></li>
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
                        <div class="tile-large tile-super-y ol-transparent" style="float: right;">
                            <div class="tile-content">
                                <div class="brand ">
                                    <!-- With icon (font) -->
                                    <div class="panel">
                                        <div class="heading">
                                            <span class="icon mif-link"></span>
                                            <span class="title">Links</span>
                                        </div>
                                        <div class="content">
                                            <a href="#">link to ...</a>
                                            <br />
                                            <br />
                                            <a href="#">link to ...</a>
                                            <br />
                                            <br />
                                            <a href="#">link to ...</a>
                                            <br />
                                            <br />
                                            <a href="#">link to ...</a>
                                            <br />
                                            <br />
                                            <a href="#">link to ...</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tile-large ol-transparent" data-role="tile">
                            <div class="tile-content">
                                <div class="carousel" data-role="carousel" data-height="100%" data-width="100%" data-controls="false">
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/Image/1.jpg" data-role="fitImage" data-format="fill" />
                                    </div>
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/Image/2.jpg" data-role="fitImage" data-format="fill" />
                                    </div>
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/Image/3.jpg" data-role="fitImage" data-format="fill" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- publication newer -->
                        <div class="tile" data-role="tile">
                            <div class="tile-content slide-right fg-white">
                                <div class="slide">
                                    <img src="App_Themes/metro/images/Image/bizspark_b.png" />
                                </div>
                                <div class="slide-over op-cyan fg-white">
                                    The first publication
                                </div>
                            </div>
                        </div>
                        <div class="tile" data-role="tile">
                            <div class="tile-content slide-right fg-white">
                                <div class="slide">
                                    <img src="App_Themes/metro/images/Image/bizspark_b_2.png" />
                                </div>
                                <div class="slide-over op-green fg-white">
                                    The second publication
                                </div>
                            </div>
                        </div>
                        <div class="tile" data-role="tile">
                            <div class="tile-content slide-right fg-white">
                                <div class="slide">
                                    <img src="App_Themes/metro/images/Image/bizspark_b_2.png" />
                                </div>
                                <div class="slide-over op-red fg-white">
                                    The third publication
                                </div>
                            </div>
                        </div>
                        <div class="tile" data-role="tile">
                            <div class="tile-content slide-right fg-white">
                                <div class="slide">
                                    <img src="App_Themes/metro/images/Image/clouds2.png" />
                                </div>
                                <div class="slide-over op-yellow fg-white">
                                    The fourth publication
                                </div>
                            </div>
                        </div>
                        <!-- older Publication -->
                        <div class="tile-group no-margin no-padding" style="width: 66.66666666%;">
                            <h3 class="fg-amber text-light margin5">Older Version Publications <span class="mif-chevron-right mif-2x" style="vertical-align: top !important;"></span></h3>

                            <div class="tile" data-role="tile">
                                <div class="tile-content slide-right fg-white">
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/whats-new.jpg" />
                                    </div>
                                    <div class="slide-over op-darkMagenta fg-white">
                                        The Old publication
                                    </div>
                                </div>
                            </div>
                            <div class="tile" data-role="tile">
                                <div class="tile-content slide-right fg-white">
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/whats-new.jpg" />

                                    </div>
                                    <div class="slide-over op-darkBrown fg-white">
                                        The Old publication
                                    </div>
                                </div>
                            </div>
                            <div class="tile" data-role="tile">
                                <div class="tile-content slide-right fg-white">
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/whats-new.jpg" />
                                    </div>
                                    <div class="slide-over op-darkOrange fg-white">
                                        The Old publication
                                    </div>
                                </div>
                            </div>
                            <div class="tile" data-role="tile">
                                <div class="tile-content slide-right fg-white">
                                    <div class="slide">
                                        <img src="App_Themes/metro/images/whats-new.jpg" />
                                    </div>
                                    <div class="slide-over op-darkTeal fg-white">
                                        The Old publication
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tile-group no-margin no-padding" style="width: 66.66666666%;">

                            <!-- NEWS -->
                            <h3 class="fg-darkCobalt text-light margin5">NEWS <span class="mif-chevron-right mif-2x" style="vertical-align: top !important;"></span></h3>

                            <!-- Tile with zooming -->
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkCobalt fg-white"><span class="title text-light">news#1 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkCobalt fg-white"><span class="title text-light">news#2 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkCobalt fg-white"><span class="title text-light">news#3 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tile-group no-margin no-padding" style="width: 66.66666666%;">


                            <!-- Article most visited -->
                            <h3 class="fg-darkGreen text-light margin5">Most Visited Articles <span class="mif-chevron-right mif-2x" style="vertical-align: top !important;"></span></h3>

                            <!-- Tile with zooming -->
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkGreen fg-white"><span class="title text-light">Article#1 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkGreen fg-white"><span class="title text-light">Article#2 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tile tile-super-x bg-white" data-role="tile">
                                <div class="tile-content">
                                    <div class="panel" style="height: 100%">
                                        <div class="heading bg-darkGreen fg-white"><span class="title text-light">Article#3 title</span></div>
                                        <div class="content fg-dark clear-float" style="height: 100%">
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End of tiles -->

            <footer>
                <div class="bottom-menu-wrapper">
                    <ul class="horizontal-menu compact">
                        <li><a href="www.batisapp.ir">&copy; 2015 Batis Programing Group</a></li>
                        <li class="place-right"><a href="#">Privacy</a></li>
                        <li class="place-right"><a href="#">Legal</a></li>
                        <li class="place-right"><a href="#">Login</a></li>
                        <li class="place-right"><a href="#">About</a></li>
                        <li class="place-right"><a href="#">Feedback</a></li>
                    </ul>
                </div>
            </footer>
        </div>
    </form>
</body>
</html>
