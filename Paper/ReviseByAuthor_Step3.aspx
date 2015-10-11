<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviseByAuthor_Step3.aspx.cs" Inherits="Paper_ReviseByAuthor_Step3" %>

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
    <form id="form1" runat="server">
        <% Response.Write(HtmlMaster.Header_Full); %>

        <div class="page-content">
            <div class="flex-grid no-responsive-future" style="height: 100%;">
                <div class="row" style="height: 100%">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>

                    <div class="cell auto-size padding20 bg-white OverFlowScrol">
                        <div>
                            <ul class="breadcrumbs">
                                <li><a href="#"><span class="icon mif-home"></span></a></li>
                                <li><a href="#">Revise By Author</a></li>
                                <li><a href="SubmitOnline.aspx">Step 1</a></li>
                                <li><a href="SubmitOnline_Step2.aspx">Step 2</a></li>
                                <li><a href="#">Step 3</a></li>
                            </ul>
                        </div>
                        <h3 style="padding-left: 5%;">Step 3 : Send Your Files </h3>

                        <div style="padding-left: 5%;">

                            <div>
                                <table class="table" style="width: 50%;" id="tbPersons">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblPFD" Text="Paper File (PDF) :" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                        <td>
                                            <div class="input-control file text full-size" data-role="input">
                                                <input type="file" id="fuPDF" runat="server" accept=".pdf,.PDF" />

                                                <button class="button"><span class="mif-file-pdf"></span></button>
                                            </div>
                                            <div style="color: crimson; padding-top: 2%">
                                                <asp:Label runat="server" ID="lblPDFAllow" Text='".PDF"'></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblDOC" Text="Paper File (Word) :" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                        <td>
                                            <div class="input-control file full-size" data-role="input">
                                                <input type="file" id="fuDOC" runat="server" accept=".doc,.DOC,.docx,.DOCX" />

                                                <button class="button"><span class="mif-file-word"></span></button>
                                            </div>
                                            <div style="color: crimson; padding-top: 2%">
                                                <asp:Label runat="server" ID="lblOfficeAllow" Text='".DOC" , ".DOCX"'></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblFigures" Text="Figures :" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                        <td>
                                            <div class="input-control file full-size" data-role="input">
                                                <input type="file" id="fuFigures" runat="server" accept=".png,.PNG,.gif,.GIF,.jpg,.JPG,.jpeg,.JPEG" />
                                                <button class="button"><span class="mif-file-image"></span></button>
                                            </div>
                                            <div style="color: crimson; padding-top: 2%">
                                                <asp:Label runat="server" ID="lblFigureAllow" Text='".GIF", ".PNG", ".JPG", ".JPEG" '></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblTable" Text="Table: (Any File) :" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                        <td>
                                            <div class="input-control file full-size" data-role="input">
                                                <input type="file" id="fuTable" runat="server" />
                                                <button class="button"><span class="mif-stack3"></span></button>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2">

                                            <asp:Label runat="server" ID="lblComment" Text="Comment:" CssClass="lbl fieldlbl"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td colspan="2">
                                            <div class="input-control text full-size big-input">
                                                <asp:TextBox runat="server" ID="txtbComment" TextMode="MultiLine"
                                                    placeholder="Write Your Comment..."></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 30px;">
                                            <asp:Button ID="btnUpload" runat="server" class="button loading-pulse lighten primary"
                                                Text="Upload & Go To Next Step >" OnClick="btnUpload_Click"></asp:Button>
                                        </td>
                                    </tr>

                                </table>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

<script type="text/javascript">

    $(document).ready(
        function () {
            $('#btnUpload').click(
               function (e) {
                   if ($('#fuDOC').val() == '') {
                       showNotifyDefault('Please Upload Your DOC File', 'alert');
                       e.preventDefault();
                       e.stopPropagation();
                   }

                   if ($('#fuPDF').val() == '') {
                       showNotifyDefault('Please Upload Your PDF File', 'alert');
                       e.preventDefault();
                       e.stopPropagation();
                   }
               });

            $('#fuDOC').change(
                function () {

                    var ext1 = $('#fuDOC').val().split('.').pop().toLowerCase();
                    if ($.inArray(ext1, ['doc', 'docx']) == -1) {
                        $('input:submit').attr('disabled', true);
                    }
                    else {
                        $('input:submit').attr('disabled', false);
                    }
                }
        );

            $('#fuPDF').change(
                function () {

                    var ext2 = $('#fuPDF').val().split('.').pop().toLowerCase();
                    if ($.inArray(ext2, ['pdf']) == -1) {
                        $('input:submit').attr('disabled', true);
                    }
                    else {
                        $('input:submit').attr('disabled', false);
                    }

                });
            $('#fuFigures').change(
                           function () {
                               var ext3 = $('#fuFigure').val().split('.').pop().toLowerCase();
                               if ($.inArray(ext3, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                                   $('input:submit').attr('disabled', true);
                               }
                               else {
                                   $('input:submit').attr('disabled', false);
                               }
                           });
        });
</script>
