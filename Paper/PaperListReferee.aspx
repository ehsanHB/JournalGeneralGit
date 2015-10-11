<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperListReferee.aspx.cs" Inherits="Paper_PaperListReferee" %>

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

    <link href="../App_Themes/CSS/jquery-ui.css" rel="stylesheet" />
    <script src="../App_Themes/JS/jquery-ui.min.js"></script>

</head>
<body class="bg-steel">
    <form id="form1" runat="server" data-role="validator">
        <% Response.Write(HtmlMaster.Header_Full); %>

        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>

                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">
                        <div>
                            <ul class="breadcrumbs">
                                <li><a href="#"><span class="icon mif-home"></span></a></li>
                                <li><a href="#">Paper List Referee</a></li>
                            </ul>
                        </div>

                        <div style="padding-left: 2%;">
                       
                            <div style="width: 100%;">
                                <asp:GridView ID="gvPapers" runat="server" AutoGenerateColumns="false" CssClass="dataTable striped hovered cell-hovered border bordered "
                                    data-role="datatable">
                                    <Columns>
                                        <asp:TemplateField HeaderText="NO">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Code" HeaderText="Code" />

                                        <asp:BoundField DataField="Title" HeaderText="Title" />
                                        <asp:BoundField DataField="Owner.User.FullName" HeaderText="FullName" />

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblStatus" Text='<%# PaperStatusInString(Convert.ToInt32(Eval("Status.ID"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Keyword" HeaderText="KeyWorld" />
                                        
                                        <asp:TemplateField HeaderText="Expiration Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDate" Text='<%# DateTimeInString(Convert.ToDateTime(Eval("Date.DateTime"))) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Show">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbShow" CssClass="mif-display" runat="server" Text="" CommandArgument='<%# Eval("ID") %>'
                                                    OnClick="lnkbShow_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>              
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>