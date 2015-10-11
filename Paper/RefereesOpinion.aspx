<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RefereesOpinion.aspx.cs" Inherits="Paper_RefereesOpinion" %>

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
                        <h3 style="padding-left: 2%;">Referees opinion</h3>
                        <br />
                        <div style="padding-left: 4%; width: 50%;">
                            <table class="table bordered border hover striped">
                                <tr>
                                    <td>Questions Title / Referees </td>
                                    <%
                                        for (int p = 0; p < evaluations.Count; p++)
                                        {
                                    %>
                                    <td><%Response.Write(evaluations[p].RefereeEvaluator.User.FullName); %></td>
                                    <%
                                        }
                                    %>
                                </tr>
                                <%
                                    for (int i = 0; i < evaluations[0].Count; i++)
                                    {
                                %>
                                <tr>
                                    <%
                                    
                                        for (int j = 0; j < evaluations.Count; j++)
                                        {
                                    %>
                                    <td><%Response.Write(evaluations[j][i].Title); %></td>

                                    <td>

                                        <%
                                        
                                        if (evaluations[j][i] is WrittenQuestions)
                                        {
                                            WrittenQuestions written = (WrittenQuestions)evaluations[j][i];
                                            Response.Write(written.Answertext);
                                        }
                                        else if (evaluations[j][i] is NumericQuestion)
                                        {
                                            NumericQuestion numeric = (NumericQuestion)evaluations[j][i];
                                            Response.Write(numeric.Score);
                                        }
                                        else if (evaluations[j][i] is Multiple_ChoiceQuestions)
                                        {
                                            Multiple_ChoiceQuestions optional = (Multiple_ChoiceQuestions)evaluations[j][i];
                                            Response.Write(optional.SelectedOption.Title);
                                        }
                                        %></td>
                                    <%
                                    }
                                    %>
                                </tr>
                                <%
                                    }
                                %>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
