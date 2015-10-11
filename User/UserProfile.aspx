<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>


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

                        <div style="padding-left: 10%;">

                            <table class="table " style="width: 80%;">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large" ID="lblName" Text="---"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large" ID="lblLastName" Text="---"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button CssClass="button danger" ID="btnEditProfile" runat="server" Text="Edit Profile >" OnClick="btnEditProfile_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <%-- <%
                                            if (userpic != null)
                                            {
                                                string imageBase64 = Convert.ToBase64String(userpic);
                                                string imageSrc = string.Format("data:image/jpg;base64,{0}", imageBase64);
                                                Response.Write(imageSrc);
                                            }
                                            else
                                            {
                                                Response.Write("../Uploaded/Default.JPG");
                                            }                                       
                                             %>--%>
                                        <%--SysClient.Client.ImageDirectoryVitual--%>
                                        <img src="<% Response.Write( SysClient.Client.ImageDirectoryVitual); %>" id='imgProfile' style='height: 200px; width: 170px;' />

                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>&nbsp
                                    </td>
                                </tr>--%>
                            </table>
                            <table class="table striped" style="width: 80%;">

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblEmail" Text="Email:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblEmail" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblAffiliations" Text="Affiliations:" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblAffiliations" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblPhoneNumber" Text="Phone Number:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPhoneNumber" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblFax" Text="Fax:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFax" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblFieldsOfInterest" Text="Fields:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFieldsOfInterest" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblNationalCode" Text="National Code:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblNationalCode" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblEducation" Text="Education:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblEducation" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblbBirthDate" Text="BirthDate:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblbBirthDate" Text="---" CssClass="lbl fieldlbl"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblGender" Text="Gender:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblGender" Text="---" CssClass="lbl fieldlbl"></asp:Label>

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
