<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Evaluation.aspx.cs" Inherits="Paper_Evaluation" %>

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
                        <h3 style="padding-left: 2%;">Evaluation</h3>
                        <div>
                            <table>
                                <%
                                    for (int i = 0; i < evaluation.Count; i++)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%
                                        if (evaluation[i] is WrittenQuestions)
                                        {
                                            WrittenQuestions written = (WrittenQuestions)evaluation[i];
                                        %>
                                        <table class="table" style="padding-left: 5%;">
                                            <tr>
                                                <td>

                                                    <%Response.Write(written.Title);%>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td><%Response.Write(written.AnswerTilte); %></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="input-control textarea">
                                                        <textarea  style="width: 500px; resize: none;" name='<%Response.Write("writtenAnswer" + i.ToString());%>'></textarea>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>
                                        <%
                                        }
                                        else if (evaluation[i] is NumericQuestion)
                                        {
                                            NumericQuestion numeric = (NumericQuestion)evaluation[i];
                                        %>
                                        <table class="table" style="padding-left: 5%;">
                                            <tr>
                                                <td><% Response.Write(numeric.Title); %></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="input-control text">
                                                        <input type="text" name='<%Response.Write("numericAnswer" + i.ToString());%>' />
                                                    </div>
                                                    <label style="padding-top: 10px; font-size: 11px; color: red;">
                                                        <% Response.Write("Range: " + numeric.Min.ToString() + " - " + numeric.Max.ToString()); %>
                                                    </label>
                                                </td>
                                            </tr>
                                        </table>
                                        <%
                                        }
                                        else if (evaluation[i] is Multiple_ChoiceQuestions)
                                        {
                                            Multiple_ChoiceQuestions multiChoice = (Multiple_ChoiceQuestions)evaluation[i];
                                            if (multiChoice != null)
                                            {
                                        %>
                                        <table class="table" style="padding-left: 5%;">
                                            <tr>
                                                <td><% Response.Write(multiChoice.Title); %></td>
                                            </tr>
                                            <tr>
                                                <td>

                                                    <%
                                                for (int j = 0; j < multiChoice.Count; j++)
                                                {
                                                    %>
                                                    <label class="input-control radio">
                                                         <input type="radio" id='<%Response.Write(i + "_" + multiChoice[j].ID); %>' name='<%Response.Write("name" + i); %>' class='<%Response.Write("rb" + i); %>' />
                                                        <span class="check"></span>
                                                        <span class="caption"><%Response.Write(multiChoice[j].Title); %></span>
                                                    </label>

                                                    <%
                                                }
                                                    %>
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                        <%
                                            }
                                        }
                                        %>
                                        <hr />
                                    </td>
                                </tr>
                                <%
                                    }
                                %>
                            </table>
                            <asp:Button ID="Submit" runat="server" class="button success" Text="Submit" 
                                OnClick="Submit_Click" OnClientClick="test()" />
                            <asp:HiddenField runat="server" ID="hfOptions" Value="" />

                        </div>
                </div>
            </div>
        </div>
        </div>

    </form>
</body>
</html>
<script type="text/javascript">
    function test() {
        for (var i = 0; i < 100; i++) {
            var val = $(".rb" + i);
            if (val.length != 0)
                for (var j = 0; j < val.length; j++) {
                    if (val[j].checked != false)
                        document.getElementById("hfOptions").value += val[j].id + ',';
                }
        }
    }
</script>
