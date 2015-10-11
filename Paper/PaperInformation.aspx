<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperInformation.aspx.cs" Inherits="PaperInformation" %>

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

    <link href="../App_Themes/chosen/chosen.css" rel="stylesheet" />

    <script src="../App_Themes/metro/js/jquery-2.1.3.min.js"></script>
    <script src="../App_Themes/metro/js/jquery.dataTables.min.js"></script>

    <script src="../App_Themes/metro/js/metro.js"></script>
    <script src="../App_Themes/metro/js/js.js"></script>

    <script src="../App_Themes/chosen/chosen.jquery.js"></script>

    <style>
        .infoDialog {
            background-color: red;
        }

        .dataTable td {
            align-content: center;
            text-align: center;
        }
    </style>


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
                                <li><a href="#">Paper Info</a></li>
                            </ul>
                        </div>
                     
                        <div style="padding-left: 5%; display: inline; float: left; width: 35%;" class="treeview" data-role="treeview">
                            <h3>Paper Info :</h3>

                            <table class="table">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblTitle" Text="Title:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblTitle" Text="---" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblAbstract" Text="Abstract:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblAbstract" Text="---" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblFieldOfPaper" Text="Field Of Paper:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFieldPaper" Text="---" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="_lblKeyWord" Text="Key Word:" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblKeyWord" Text="---" CssClass="lbl fieldlbl"></asp:Label>
                                    </td>
                                </tr>

                            </table>


                            <h3>Paper Files</h3>
                            <%
                                for (int i = 1; i <= info.LastVersion; i++)
                                {%>
                            <ul>
                                <li class="node collapsed">
                                    <span class="leaf">Versions <% Response.Write(i); %> Files</span>
                                    <span class="node-toggle"></span>
                                    <ul>
                                        <%
                                            List<PaperFile> Files = info.GetFile(i);
                                            for (int j = 0; j < Files.Count; j++)
                                            {%>
                                        <li><span class="leaf"><a href='<%Response.Write(ServerDirectory.Host + "/PaperFileHandler.ashx?" + SessionType.FileName + "=" + Files[j].Filename); %>'><%Response.Write(Files[j].Title); %></a></span></li>

                                        <%  }
                                        %>
                                    </ul>
                                </li>
                            </ul>
                            <%}
                            %>
                        </div>
                        <div style="padding-left: 5%; display: inline; float: left;">
                            <h3>Authors :</h3>
                            <asp:GridView ID="gvAuthors" runat="server" AutoGenerateColumns="false"
                                CssClass="dataTable striped hovered cell-hovered border bordered " data-role="datatable">
                                <Columns>
                                    <asp:BoundField HeaderText="Authors Full Name" DataField="FullName" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="padding-left: 5%; display: inline; float: left;">
                            <h3>Referees :</h3>
                            <asp:GridView ID="gvReferees" runat="server" AutoGenerateColumns="false"
                                CssClass="dataTable striped hovered cell-hovered border bordered " data-role="datatable">
                                <Columns>
                                    <asp:BoundField HeaderText="Referees Email" DataField="User.Email" />
                                    <asp:BoundField DataField="Status.Name" HeaderText="Status" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbDelete" CssClass="mif-bin" runat="server" Text="" CommandArgument='<%# Eval("User.UserID") %>'
                                                OnClick="lnkbDelete_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <table class="table">
                        </table>

                        <input type="button" id="btnRefereesSelection" runat="server" onclick="showDialog('#wRefereesSelection')" value="Referees selection" class="button loading-pulse lighten success" />
                        <input type="button" id="btnLanguageEditorSelection" runat="server" onclick="showDialog('#wLanguageEditors')" value="Language Editor selection" class="button loading-pulse lighten success" />
                        <input type="button" id="btnSyntaxEditorSelection" runat="server" onclick="showDialog('#wSyntaxSelection')" value="Syntax Editor selection" class="button loading-pulse lighten success" />

                        <input type="button" id="btnEditorSelection" runat="server" onclick="showDialog('#wEditorSelection')" value="Editor selection" class="button loading-pulse lighten primary" />
                        <asp:Button ID="btnAcceptByChefEditor" runat="server" class="button loading-pulse lighten success " Text="Initial confirmation" OnClick="btnAcceptByChefEditor_Click"></asp:Button>
                        <asp:DropDownList ID="ddlEvaluationForm" CssClass="input-control text full-size " runat="server"></asp:DropDownList>
                        <asp:Button ID="btnRejectByChefEditor" runat="server" class="button loading-pulse lighten danger " Text="Reject article" OnClick="btnRejectByChefEditor_Click"></asp:Button>
                        <asp:Button ID="btnAcceptArbitration" runat="server" class="button loading-pulse lighten success " Text="Accept arbitration" OnClick="btnAcceptArbitration_Click"></asp:Button>
                        <asp:Button ID="btnRejectArbitrationArticle" runat="server" class="button loading-pulse lighten danger " Text="Reject arbitration article" OnClick="btnRejectArbitrationArticle_Click"></asp:Button>
                        <asp:Button ID="btnEvaluation" runat="server" class="button loading-pulse lighten success " Text="Evaluation" OnClick="btnEvaluation_Click" />
                        <input type="button" id="btnReviseComment" runat="server" onclick="showDialog('#wReviseComment')" value="Revise Comment" class="button loading-pulse lighten primary" />
                        <asp:Button ID="btnReviseByAuthor" runat="server" class="button loading-pulse lighten warning " Text="Revise" OnClick="btnReviseByAuthor_Click" />
                        <asp:Button ID="btnRefereesOpinion" runat="server" class="button loading-pulse lighten warning " Text="RefereesOpinion" OnClick="btnRefereesOpinion_Click" />
                        <asp:Button ID="btnFinalApproval" runat="server" class="button loading-pulse lighten warning " Text="Final Approval" OnClick="btnFinalApproval_Click" />
                    </div>

                </div>
            </div>
        </div>
         
        <div id="wReviseComment" data-type="default" data-close-button="true" data-width="auto"
            data-background="bg-grayLighter" class="DialogB">

            <h4>Revise Comment :</h4>
            <table class="table">
                <tr>
                    <td>
                        <div class="input-control text textarea" style="width: 500px;">
                            <textarea runat="server" id="txtbReviseComment" style="resize: none;"
                                placeholder="Write Your Comment..."></textarea>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRevise" runat="server" class="button loading-pulse lighten danger " Text="Revise" OnClick="btnRevise_Click" />
                        &nbsp
                        <input id="btnCancelReviseComment" type="button" value="Cancel" class="btn btn-danger" />

                    </td>
                </tr>

            </table>

        </div>
    </form>

    <form id="frmRefereesSelection" action="PaperInfoRefereesSelection.ashx" method="post">
        <div id="wRefereesSelection" data-type="default" data-close-button="true" data-width="auto"
            data-background="bg-grayLighter" class="DialogB">
            <h3>Select Referee</h3>
            <div>
                <table class="table">
                    <tr>
                        <td>
                            <label id="lblDDLReferee" class="lbl fieldlbl">Referee:</label>

                        </td>
                        <td>
                            <div class="side-by-side clearfix">

                                <select id="ddlReferee" name="ddlReferee" class="chosen-select"
                                    style="width: 250px; height: 50px;" data-placeholder="Choose an Email...">
                                    <option value="-1"></option>
                                    <%
                                        List<User_cls> users = userInfoMan.GetRefereesList();
                                        if (users != null)
                                            for (int i = 0; i < users.Count; i++)
                                            {%>
                                    <option value="<% Response.Write(users[i].UserID.ToString()); %>">
                                        <% Response.Write(users[i].Email); %>
                                    </option>
                                    <%  }

                                    %>
                                </select>

                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <label id="lblExpDate" class="lbl fieldlbl">Expiration Date:</label>
                        </td>
                        <td style="resize: none;">
                            <div class="input-control text full-size" data-role="datepicker">
                                <input type="text" id="txtbExpDate" name="txtbExpDate" placeholder="ExpirationDate..."
                                    value="<% Response.Write(DateTime.Now.Add(SysProperty.ExpirationForSelectReferee).ToString("yyyy.MM.dd")); %>" />
                                <%-- data-validate-func="required"
                                    data-validate-hint="This field can not be empty!"--%>
                            </div>
                        </td>

                    </tr>

                    <tr>

                        <td>
                            <input type="submit" id="btnSelectReferee" class="button loading-pulse lighten primary "
                                value="Select"
                                ondblclick="GetValue('custom-combobox-input','TextBox')" />
                        </td>
                        <td>
                            <div class="buttons">
                                <input id="btnCancelSelectionRefereesDialog" type="button" value="Cancel" class="btn btn-danger" />
                            </div>

                        </td>
                    </tr>

                </table>
                <input type="hidden" id="hfRefereeMail" value="" />
            </div>

        </div>

    </form>

    <form id="frmEditorSelection" method="post" action="PaperInfoEditorSelection.ashx">
        <div id="wEditorSelection" data-type="default" data-close-button="true" data-width="auto"
            data-background="bg-grayLighter" class="DialogB">
            <h3>Select Editor</h3>
            <div>
                <table class="table">
                    <tr>
                        <td>
                            <div class="side-by-side clearfix">

                                <select id="ddlEditors" name="ddlEditors" class="chosen-select"
                                    style="width: 300px;" data-placeholder="Editor Name...">
                                    <option value="-1"></option>

                                    <%
                                        List<User_cls> editorusers = userInfoMan.GetEditorList();
                                        if (users != null && editorusers != null)
                                            for (int i = 0; i < editorusers.Count; i++)
                                            {%>

                                    <option value="<% Response.Write(editorusers[i].UserID.ToString()); %>">
                                        <% Response.Write(editorusers[i].FullName); %>
                                    </option>
                                    <%  }
                                    %>
                                </select>
                            </div>
                        </td>
                    </tr>
                     
                    <tr>
                        <td>
                            <div class="buttons">
                                <input type="submit" id="btnSelectEditor" class="button loading-pulse lighten primary " value="Select" onclick="HClick()" />
                               
                                &nbsp                          
                                <input id="btnCancelSelectionEditorDialog" type="button" value="Cancel" class="btn btn-danger" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>

     <form id="frmLanguageEditors" method="post" action="PaperInfoLanguageEditorSelect.ashx">
        <div id="wLanguageEditors" data-type="default" data-close-button="true" data-width="auto"
            data-background="bg-grayLighter" class="DialogB">
            <h3>Select Language Editor</h3>
            <div>
                <table class="table" >
                    <tr>
                         <td>
                            <label id="lblDDLLanguageEditor" class="lbl fieldlbl">Referee:</label>

                        </td>
                        <td>
                            <div class="side-by-side clearfix">

                                <select id="ddlLanguageEditors" name="ddlLanguageEditors" class="chosen-select"
                                    data-placeholder="Language Editor...">
                                    <option value="-1"></option>                                   
                                   <%
                                       List<User_cls> Laneditorusers = userInfoMan.GetLanguageEditorsList();
                                       if (Laneditorusers != null)
                                           for (int i = 0; i < Laneditorusers.Count; i++)
                                           {%>
                                    <option style="width: 300px !important;" value="<% Response.Write(Laneditorusers[i].UserID.ToString()); %>">
                                        <% Response.Write(Laneditorusers[i].FullName); %>
                                    </option>
                                    <%  }
                                    %>
                                </select>
                            </div>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <label id="lblEditorExpDate" class="lbl fieldlbl">Expiration Date:</label>
                        </td>
                        <td style="resize: none;">
                            <div class="input-control text full-size" data-role="datepicker">
                                <input type="text" id="txtbEditorExpDate" name="txtbLanEditorExpDate" placeholder="ExpirationDate..."
                                    value="<% Response.Write(DateTime.Now.Add(SysProperty.ExpirationForSelectReferee).ToString("yyyy.MM.dd")); %>" />
                                <%-- data-validate-func="required"
                                    data-validate-hint="This field can not be empty!"--%>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <div class="buttons">
                                <input type="submit" id="btnSelectLanguageEditor" class="button loading-pulse lighten primary " value="Select" />                             
                                &nbsp                          
                                <input id="btnCancelSelectLanguageEditor" type="button" value="Cancel" class="btn btn-danger" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>

     <form id="frmSyntaxSelection" method="post" action="PaperInfoSyntaxEditorSelect.ashx" >
        <div id="wSyntaxSelection" data-type="default" data-close-button="true" data-width="auto"
            data-background="bg-grayLighter" class="DialogB" >
            <h3>Select Syntax Editor</h3>
            <div>
                <table class="table">
                    <tr>
                        <td>
                            <div class="side-by-side clearfix">
                                <select id="ddlSyntaxEditors" name="ddlSyntaxEditors" class="chosen-select"
                                    style="width: 300px;" data-placeholder="Syntax Editor Name...">
                                    <option value="-1"></option>

<%--                                       <%
                                       List<User_cls> Laneditorusers = userInfoMan.GetLanguageEditorsList();
                                       if (Laneditorusers != null)
                                           for (int i = 0; i < Laneditorusers.Count; i++)
                                           {%>

                                    <option style="width: 300px !important;" value="<% Response.Write(Laneditorusers[i].UserID.ToString()); %>">
                                        <% Response.Write(Laneditorusers[i].FullName); %>
                                    </option>
                                    <%  }
                                    %>--%>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="buttons">
                                <input type="submit" id="btnSelectSyntaxEditor" class="button loading-pulse lighten primary " value="Select" />                             
                                &nbsp                          
                                <input id="btnCancelSelectionSyntaxEditorDialog" type="button" value="Cancel" class="btn btn-danger" />
                            </div>
                        </td>

                    </tr>
                </table>
            </div>

        </div>
    </form>

</body>
</html>
<script>

    $(function () {
        $("#wReviseComment").dialog({
            autoOpen: false,
            width: 450,
            closeOnEscape: true,
            show: {
                effect: "blind",
                duration: 500
            },
            hide: {
                effect: "blind",
                duration: 500
            }
        }).parent().appendTo(jQuery("form:first"));
        $("#btnReviseComment").click(function () {
            $("#wReviseComment").dialog("open");
        });
        $("#btnCancelReviseComment").click(function () {
            $("#wReviseComment").dialog("close");
        });
    });



    $(function () {
        $("#wRefereesSelection").dialog({
            autoOpen: false,
            width: 450,
            closeOnEscape: true,
            show: {
                effect: "blind",
                duration: 500
            },
            hide: {
                effect: "blind",
                duration: 500
            }
        }).parent().appendTo(jQuery("form:first"));
        $("#btnRefereesSelection").click(function () {
            $("#wRefereesSelection").dialog("open");
        });
        $("#btnCancelSelectionRefereesDialog").click(function () {
            $("#wRefereesSelection").dialog("close");
        });
    });
    $(function () {
        $("#wEditorSelection").dialog({
            autoOpen: false,
            width: 450,
            closeOnEscape: true,
            show: {
                effect: "blind",
                duration: 500
            },
            hide: {
                effect: "blind",
                duration: 500
            }
        }).parent().appendTo(jQuery("form:first"));
        $("#btnEditorSelection").click(function () {
            $("#wEditorSelection").dialog("open");
        });
        $("#btnCancelSelectionEditorDialog").click(function () {
            $("#wEditorSelection").dialog("close");
        });
    });

    $(function () {
        $("#wLanguageEditors").dialog({
            autoOpen: false,
            width: 450,
            closeOnEscape: true,
            show: {
                effect: "blind",
                duration: 500
            },
            hide: {
                effect: "blind",
                duration: 500
            }
        }).parent().appendTo(jQuery("form:first"));
        $("#btnLanguageEditorSelection").click(function () {
            $("#wLanguageEditors").dialog("open");
        });
        $("#btnCancelSelectLanguageEditor").click(function () {
            $("#wLanguageEditors").dialog("close");
        });
    });

    $(function () {
        $("#wSyntaxSelection").dialog({
            autoOpen: false,
            width: 450,
            closeOnEscape: true,
            show: {
                effect: "blind",
                duration: 500
            },
            hide: {
                effect: "blind",
                duration: 500
            }
        }).parent().appendTo(jQuery("form:first"));
        $("#btnSyntaxEditorSelection").click(function () {
            $("#wSyntaxSelection").dialog("open");
        });
        $("#btnCancelSelectionSyntaxEditorDialog").click(function () {
            $("#wSyntaxSelection").dialog("close");
        });
    });


</script>

<script type="text/javascript">

    function showDialog(id) {
        var dialog = $(id).data('dialog');
        dialog.open();
    }
</script>

<script type="text/javascript">
    var config = {
        '.chosen-select': { allow_single_deselect: true },

    }
    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }
  </script>


