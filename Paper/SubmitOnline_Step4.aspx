<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitOnline_Step4.aspx.cs" Inherits="SubmitOnline_Step4" %>


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

                    <div class="cell auto-size padding20 bg-white">
                        <div>
                            <ul class="breadcrumbs">
                                <li><a href="#"><span class="icon mif-home"></span></a></li>
                                <li><a href="#">Submit Online</a></li>
                                <li><a href="SubmitOnline.aspx">Step 1</a></li>
                                <li><a href="SubmitOnline_Step2.aspx">Step 2</a></li>
                                <li><a href="SubmitOnline_Step3.aspx">Step 3</a></li>
                                <li><a href="#">Step 4</a></li>


                            </ul>
                        </div>


                        <h3 style="padding-left: 5%;">Step 4 : Referee Proposal</h3>
                        <div style="padding-left: 5%;">


                            <script type="text/javascript">
                                $(document).ready(function () {
                                    var counter = 2;
                                    $("#addRow").click(function () {
                                        if (counter > 10) {
                                            alert("Only 10 Authors allow");
                                            return false;
                                        }
                                        var newRow = $(document.createElement('tr')).attr("id", 'tr' + counter);
                                        newRow.after().html(
                                              '<td id="test1">' + counter + '<lable> .Name: </lable> </td>'
                                            + '<td id="test2">  <div class="input-control text">  <input class="name" type="text" id="txtbName ' + counter + ' " /> </div> </td>'
                                            + '<td id="test3">  <label>LastName : </label> </td>'
                                            + '<td id="test4">  <div class="input-control text">  <input class="lastname" type="text" id="txtbLastName ' + counter + '" /> <div/> </td>  '
                                            + '<td id="test5">  <label>Email : </label> </td>'
                                            + '<td id="test6">  <div class="input-control text">  <input class="mail" type="text" id="txtbEmail ' + counter + '" /> <div/> </td>  '

                                        );

                                        newRow.appendTo("#tbPersons");
                                        counter++;
                                    });

                                    $("#delRow").click(function () {
                                        if (counter == 2) {
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
                                    <table class="table" style="width: auto;" id="tbPersons">
                                        <tr>
                                            <td>
                                                <label>1. Name : </label>
                                            </td>
                                            <td>
                                                <div class="input-control text">
                                                    <input class="name" type='text' id='txtbName1' />
                                                </div>
                                            </td>
                                            <td>
                                                <label>LastName : </label>
                                            </td>
                                            <td>
                                                <div class="input-control text">
                                                    <input class="lastname" type='text' id='txtbLastName1' />
                                                </div>
                                            </td>
                                            <td>
                                                <label>Email : </label>
                                            </td>
                                            <td>
                                                <div class="input-control text">
                                                    <input class="mail" type='text' id='txtbEmail' />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                        </tr>
                                    </table>
                                    <div>
                                        <input type='button' value='Add Referee' id='addRow' class="success" />
                                        <input type='button' value='Delete Last Referee' id='delRow' class="danger" />
                                        <asp:Button ID="btnFinish" runat="server" class="button loading-pulse lighten primary" Text="Finish" OnClick="btnFinish_Click" OnClientClick="setValue('name','lastname','mail', 10)"></asp:Button>
                                        <asp:HiddenField runat="server" ID="hfFirstName" Value="" />
                                        <asp:HiddenField runat="server" ID="hflastName" Value="" />
                                        <asp:HiddenField runat="server" ID="hfEmail" Value="" />
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
<script>

    function setValue(inputValueName, inputValueLastName, inputValueIncharge, counter) {

        var val1 = $("." + inputValueName);
        var val2 = $("." + inputValueLastName);
        var val3 = $("." + inputValueIncharge);
        for (var i = 0; i < counter; i++) {
            if (val1[i] != null && val1[i] != "")
                document.getElementById("hfFirstName").value += val1[i].value + ',';
            if (val2[i] != null && val2[i] != "")
                document.getElementById("hflastName").value += val2[i].value + ',';
            if (val3[i] != null && val3[i] != "")
                document.getElementById("hfEmail").value += val3[i].value + ',';

        }
    }
</script>
