<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

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

    <% Response.Write(HtmlMaster.Header_Full); %>

    <div class="page-content">
        <div class="flex-grid no-responsive-future" style="height: 100%;">
            <div class="row" style="height: 100%">
                <% Response.Write(HtmlMaster.Sidebar_Full); %>

                <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">
                    <form id="form2" data-role="validator" action="EditProfileHandler.ashx" method="post" style="height: auto;">
                        <h3 style="padding-left: 3%;">Edit Profile</h3>

                        <div style="padding-left: 4%;">

                            <table class="table" style="width: 70%;">
                                <tr>
                                    <td>
                                        <label id="lblName" class="lbl fieldlbl">First Name:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-user "></span>
                                            <input type="text" id="txtbName" name="txtbName" placeholder="FirstName..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<% Response.Write(user.User.Fname); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label id="lblLastName" class="lbl fieldlbl">Last Name:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-user "></span>
                                            <input type="text" id="txtbLastName" name="txtbLastName" placeholder="LastName..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<% Response.Write(user.User.Lname); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label id="lblEmail" class="lbl fieldlbl">Email:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-mail "></span>
                                            <input type="text" id="txtbEmail" name="txtbEmail" placeholder="Email..."
                                                data-validate-func="email"
                                                data-validate-hint="Not valid email address!" value="<% Response.Write(user.User.Email); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label id="lblAffiliations" class="lbl fieldlbl">Affiliations:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-users "></span>
                                            <input type="text" id="txtbAffiliations" name="txtbAffiliations" placeholder="Affiliations..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<% Response.Write(user.User.Affiliations); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label id="lblPhoneNumber" class="lbl fieldlbl">Phone Number:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-phone "></span>
                                            <input type="text" id="txtbPhoneNumber" name="txtbPhoneNumber" placeholder="Phone Number..."
                                                data-validate-func="pattern"
                                                data-validate-arg="[0-9]{1,50}"
                                                data-validate-hint="Only numbers!" value="<% Response.Write(user.User.Phone); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <label id="lblFax" class="lbl fieldlbl">Fax:</label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-printer "></span>
                                            <input type="text" id="txtbFax" name="txtbFax" placeholder="Fax..."
                                                data-validate-func="pattern"
                                                data-validate-arg="[0-9]{1,50}"
                                                data-validate-hint="Only numbers!" value="<% Response.Write(user.User.Fax); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <lable id="lblFieldsOfInterest" class="lbl fieldlbl">Fields:</lable>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-favorite "></span>
                                            <input type="text" id="txtbFieldsOfInterest" name="txtbFieldsOfInterest" placeholder="Interest..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<% Response.Write(user.User.Fields); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <lable id="lblNationalCode" class="lbl fieldlbl">National Code:</lable>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-earth "></span>
                                            <input type="text" id="txtbNationalCode" name="txtbNationalCode" placeholder="National Code..."
                                                data-validate-func="pattern"
                                                data-validate-arg="[0-9]{1,50}"
                                                data-validate-hint="Only numbers!" value="<% Response.Write(user.User.Melli); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <lable id="lblEducation" class="lbl fieldlbl">Education:</lable>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-school "></span>
                                            <input type="text" id="txtbEducation" name="txtbEducation" placeholder="Education..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<% Response.Write(user.User.Education); %>" />
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <lable id="lblbBirthDate" class="lbl fieldlbl">BirthDate:</lable>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="datepicker">
                                            <input type="text" id="txtbBirthDate" name="txtbBirthDate" placeholder="BirthDate..."
                                                data-validate-func="required"
                                                data-validate-hint="This field can not be empty!" value="<%
                                                if (user.User.Birthdate != null && user.User.Birthdate.Datetime != null)
                                                    Response.Write(user.User.Birthdate.Datetime.ToString("yyyy.MM.dd"));
                                                 %>" />
                                            <button class="button"><span class="mif-calendar"></span></button>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <lable id="lblGender" class="lbl fieldlbl">Gender:</lable>
                                    </td>
                                    <td>
                                        <div class="input-control select full-size">
                                            <%--<asp:DropDownList runat="server" CssClass="input-control select" ID="ddlGender">
                                            </asp:DropDownList>--%>
                                            <select id="ddlGender" name="ddlGender" class="input-control select">
                                                <option value="<%Response.Write(Gender.Male.ToString()); %>" <% Response.Write(isMaleOrFemale(Gender.Male)); %>>
                                                    <% Response.Write(Gender.Convert(Gender.Male));%>                                                 
                                                </option>
                                                <option value="<%Response.Write(Gender.Female.ToString()); %>" <% Response.Write(isMaleOrFemale(Gender.Female)); %>>
                                                    <% Response.Write(Gender.Convert(Gender.Female));%>                                                
                                                </option>
                                            </select>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <input type="submit" id="btnEditProfile" class="button loading-pulse lighten primary "
                                            value="Edit Profile" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </form>
                    <div style="clear: both"></div>
                    <form id="form1" runat="server" data-role="validator" style="height: auto; padding-left: 4%;">
                        <table class="table" style="width: 70%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAvatar" runat="server" Text="Profile Picture :"
                                        class="lbl fieldlbl"></asp:Label>
                                </td>
                                <td>

                                    <div class="input-control file full-size" data-role="input">
                                        <input type="file" id="fuAvatar" runat="server" accept=".png,.PNG,.gif,.GIF,.jpg,.JPG,.jpeg,.JPEG" />
                                        <button class="button"><span class="mif-file-image"></span></button>
                                    </div>

                                    <div style="color: crimson; padding-top: 2%">
                                        <asp:Label runat="server" ID="lblAvatarFormats">".GIF", ".PNG", ".JPG", ".JPEG"</asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Button runat="server" ID="btnChangeAvatar" class="button primary"
                                        Text="Change Avatar" OnClick="btnChangeAvatar_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </form>

                </div>
            </div>
            <%--<form action="EditProfileHandler.ashx" method="post" enctype="multipart/form-data" id="frmAvatar" style="clear: both;">
                <table class="table" style="width: 70%;">
                </table>
            </form>--%>
        </div>
    </div>






</body>
</html>
