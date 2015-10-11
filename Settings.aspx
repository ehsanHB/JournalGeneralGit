<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

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

                        <h3 style="padding-left: 3%;">Settings</h3>

                        <div style="padding-left: 3%;">

                            <table class="table" style="width: 65%;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblInterimCodePaper" Text="Interim Code Paper:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-file-empty "></span>
                                            <asp:TextBox runat="server" ID="txtbInterimCodePaper" TextMode="SingleLine" placeholder="Interim..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblPermanentCodePaper" Text="Permanent Code Paper:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-file-empty "></span>
                                            <asp:TextBox runat="server" ID="txtbPermanentCodePaper" TextMode="SingleLine" placeholder="Permanent..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblNameEnglish" Text="English Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-quote "></span>
                                            <asp:TextBox runat="server" ID="txtbNameEnglish" TextMode="SingleLine" placeholder="English..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblNamePersian" Text="Persian Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-quote "></span>
                                            <asp:TextBox runat="server" ID="txtbNamePersian" TextMode="SingleLine" placeholder="Persian..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <hr />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblExpSubmitOnline" Text="SubmitOnline Expiration (Day):" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-calendar "></span>
                                            <asp:TextBox runat="server" ID="txtbExpSubmitOnline" TextMode="SingleLine" placeholder="SubmitOnline Exp Days..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblExpSelectReferee" Text="Select Referee Expiration (Day):" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-calendar "></span>
                                            <asp:TextBox runat="server" ID="txtbExpSelectReferee" TextMode="SingleLine" placeholder="SelectReferee Exp Days..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr />
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSysEmailDisplayName" Text="System Email Display Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-display "></span>
                                            <asp:TextBox runat="server" ID="txtbSysEmailDisplayName" TextMode="SingleLine" placeholder="DisplayName..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSysEmailHostName" Text="System Email Host Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-mail-read "></span>
                                            <asp:TextBox runat="server" ID="txtbsysEmailHostName" TextMode="SingleLine" placeholder="HostName..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSysEmailAddress" Text="System Email Address:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-mail "></span>
                                            <asp:TextBox runat="server" ID="txtbSysEmailAddress" TextMode="SingleLine" placeholder="EmailAddress..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSystemEmailPass" Text="System Email Password:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-lock "></span>
                                            <asp:TextBox runat="server" ID="txtbSysEmailPass" TextMode="SingleLine" placeholder="Password..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td colspan="3">
                                        <hr />
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblMinReferee" Text="Minimum Referees:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-justice "></span>
                                            <asp:TextBox runat="server" ID="txtbMinReferee" TextMode="SingleLine" placeholder="Referees..."
                                                data-validate-func="number"
                                                data-validate-hint="just numbers allowed!"></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                </tr>



                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" class="button loading-pulse lighten primary "
                                            Text="Save" OnClick="btnSave_Click"></asp:Button>
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
