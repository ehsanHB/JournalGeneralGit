<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="User_UsersList" %>

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
                        <h3 style="padding-left: 1%;">Users List</h3>
                        <div style="padding-left: 2%;">


                            <table class="table" style="width: 80%;">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblName" Text="First Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-user "></span>
                                            <asp:TextBox runat="server" ID="txtbName" TextMode="SingleLine" placeholder="FirstName..."></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" ID="lblLastName" Text="Last Name:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-user "></span>
                                            <asp:TextBox runat="server" ID="txtbLastName" TextMode="SingleLine" placeholder="LastName..."></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" ID="lblEmail" Text="Email:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size" data-role="input">
                                            <span class=" prepend-icon mif-mail "></span>
                                            <asp:TextBox runat="server" ID="txtbEmail" TextMode="SingleLine" placeholder="Email..."></asp:TextBox>
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
                                            <asp:TextBox runat="server" ID="txtbAffiliations" TextMode="SingleLine" placeholder="Affiliations..."></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" ID="lblFieldsOfInterest" Text="Fields:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control text full-size">
                                            <span class=" prepend-icon mif-stack2 "></span>
                                            <asp:TextBox runat="server" ID="txtbFieldsOfInterest" TextMode="SingleLine" placeholder="Fields..."></asp:TextBox>
                                            <span class="input-state-error mif-warning"></span>
                                            <span class="input-state-success mif-checkmark"></span>
                                        </div>
                                    </td>

                                    <td>
                                        <asp:Label runat="server" ID="Label1" Text="Gender:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="input-control select full-size" >
                                            <asp:DropDownList runat="server" CssClass="input-control select full-size" ID="ddlGender"></asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnSearch" runat="server" class="button loading-cube lighten primary full-size" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                            <div style="width:80%">
                                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="dataTable striped hovered cell-hovered border bordered "
                                    data-role="datatable">
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO" ItemStyle-CssClass="GridAlignCenter">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Fname" HeaderText="Firstname" />
                                        <asp:BoundField DataField="Lname" HeaderText="LastName" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Affiliations" HeaderText="Affiliations" />
                                        <asp:BoundField DataField="Fields" HeaderText="Fields" />
                                        <asp:BoundField DataField="Roles.RoleInString" HeaderText="Roles" />
                                        <asp:TemplateField HeaderText="Show" ItemStyle-CssClass="GridAlignCenter">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbShow" CssClass="mif-display" runat="server" OnClick="lnkbShow_Click" Text="" CommandArgument='<%# Eval("UserID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="GridAlignCenter">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbEdit" CssClass="mif-pencil" runat="server" OnClick="lnkbEdit_Click" Text="" CommandArgument='<%# Eval("UserID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>

