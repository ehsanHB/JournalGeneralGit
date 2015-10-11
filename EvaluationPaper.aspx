<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluationPaper.aspx.cs" Inherits="EvaluationPaper" %>

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
                <div class="row" style="height: 100%;">
                    <% Response.Write(HtmlMaster.Sidebar_Full); %>

                    <div class="cell auto-size padding20 bg-white OverFlowScrol" id="cell-content">
                        <div>
                            <ul class="breadcrumbs">
                                <li><a href="#"><span class="icon mif-home"></span></a></li>
                                <li><a href="#">Evaluation Form</a></li>

                            </ul>
                        </div>


                        <h3 style="padding-left: 2%;">Evaluation Form</h3>
                        <div style="padding-left: 3%;">


                            <script type="text/javascript">
                                $(document).ready(function () {
                                    var counter = 1;

                                    $("#addDescriptiveRow").click(function () {
                                        if (counter > 10) {
                                            alert("Only 10  allow");
                                            return false;
                                        }
                                        var newRow = $(document.createElement('tr')).attr("id", 'tr' + counter);
                                        newRow.after().html(
                                                '<td style="vertical-align:top; padding-top:25px;" >' + counter + '<lable> .Question Title: </lable> <br/> <lable style="padding-top:10px;font-size:11px; color:red;">(descriptive) <lable></td>'
                                              + '<td >  <div class="input-control textarea " >  <textarea style="width:350px; resize: none;" name="txtbDescriptiveQuestionTitle' + counter + '" ></textarea> </div> </td> '
                                              + '<td style="vertical-align:top; padding-top:25px;" >  <label>Answer Title : </label> </td>'
                                              + '<td style="vertical-align:top;" >  <div class="input-control text">  <input type="text" name="txtbAnswerTitle' + counter + '" /> </div> </td>'
                                        );
                                        newRow.appendTo("#tbPersons");
                                        counter++;
                                    });

                                    $("#addNumRow").click(function () {
                                        if (counter > 10) {
                                            alert("Only 10  allow");
                                            return false;
                                        }
                                        var newRow = $(document.createElement('tr')).attr("id", 'tr' + counter);
                                        newRow.after().html(
                                                '<td style="vertical-align:top; padding-top:25px;" >' + counter + '<lable> .Question Title: </lable> <br/> <lable style="padding-top:10px;font-size:11px; color:red;">(Numeric) <lable> </td>'
                                              + '<td >  <div class="input-control textarea " >  <textarea style="width:350px; resize: none;" name="txtbNumQuestionTitle' + counter + '" ></textarea> </div> </td> '
                                              + '<td style="vertical-align:top; padding-top:25px;" >  <label>Periods : </label> </td>'
                                              + '<td style="vertical-align:top; padding-top:25px;" >  <div class="input-control text">  <label>Min Score : </label>  <input type="text" name="txtbMinScore' + counter + '" /> </div> <br/><div class="input-control text" >  <label style="padding-top:5px;">Max Score : </label>  <input style="margin-top:5px;" type="text" name="txtbmaxScore' + counter + '" /> </div> </td>'

                                        );
                                        newRow.appendTo("#tbPersons");
                                        counter++;
                                    });


                                    $("#addOptionalRow").click(function () {
                                        if (counter > 10) {
                                            alert("Only 10  allow");
                                            return false;
                                        }
                                        var newRow = $(document.createElement('tr')).attr("id", 'tr' + counter);
                                        newRow.after().html(
                                                '<td style="vertical-align:top; padding-top:25px;" >' + counter + '<lable> .Question Title: </lable> <br/> <lable style="padding-top:10px;font-size:11px; color:red;">(Optional) <lable> </td>'
                                              + '<td >  <div class="input-control textarea " >  <textarea style="width:350px; resize: none;" name="txtbOptionalQuestionTitle' + counter + '" ></textarea> </div> </td> '
                                              + '<td style="vertical-align:top; padding-top:25px;" >  <label>Options : </label> </td>'
                                              + '<td style="vertical-align:top; padding-top:25px;" >  <div class="input-control text"> <input type="text" name="txtbOptions' + counter + '" /> </div> <br/><div class="input-control text"  >  <label style="padding-top:10px;font-size:11px; color:red;"> Seperate Your Options by " ; " exp: "option1 ; option2 ; option3" </label></div> </td>'

                                        );
                                        newRow.appendTo("#tbPersons");
                                        counter++;
                                    });


                                    $("#delRow").click(function () {
                                        if (counter == 1) {
                                            alert("No more textbox to remove");
                                            return false;
                                        }
                                        counter--;
                                        $("#tr" + counter).remove();

                                    });





                                });
                            </script>



                            <div>
                                <div>
                                    <table class="table" style="width: auto;" id="tbPersons" runat="server">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblEvaTitle" Text="Evaluation Title:" CssClass="lbl fieldlbl"></asp:Label>
                                            </td>
                                            <td>
                                                <div class="input-control text full-size">
                                                    <span class=" prepend-icon mif-quote "></span>
                                                    <asp:TextBox runat="server" ID="txtbEvaTitle" TextMode="SingleLine" placeholder="Title..."
                                                        data-validate-func="required"
                                                        data-validate-hint="This field can not be empty!"></asp:TextBox>
                                                    <span class="input-state-error mif-warning"></span>
                                                    <span class="input-state-success mif-checkmark"></span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <label style="font-size: 10px; color: red;"></label>
                                <input type='button' value='Add Descriptive Question' id='addDescriptiveRow' class="success" />
                                <input type='button' value='Add Numeric Question' id='addNumRow' class="primary" />
                                <input type='button' value='Add Optional Question' id='addOptionalRow' class="warning" />
                                <input type='button' value='Delete Last Question' id='delRow' class="danger" />
                                <asp:Button ID="btnFinish" runat="server" class="button loading-pulse lighten "
                                    Text="Finish" OnClick="btnFinish_Click"></asp:Button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
