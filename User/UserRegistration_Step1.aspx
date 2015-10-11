<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/User/UserRegistration_Step1.aspx.cs" Inherits="EditorRegistration" EnableEventValidation="false" %>

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
                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content" >

                        <h3 style="padding-left: 5%;">User Registration Step 1 :</h3>

                        <div style="padding-left: 5%;">

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
                                        <asp:Label runat="server" ID="lblFieldsOfInterest" Text="Fields:" CssClass="lbl fieldlbl"></asp:Label>
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

                                <%--                                    <tr>
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

                                <%--           <tr>
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
                                    <td>
                                        <asp:Button ID="btnUserRegister" runat="server" class="button loading-pulse lighten primary " Text="Register And Next Step" ValidationGroup="test"
                                            OnClick="btnUserRegister_Click"></asp:Button>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCansel" runat="server" class="button loading-pulse" Text="Cansel"></asp:Button>
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
