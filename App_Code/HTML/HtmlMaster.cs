using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HtmlMaster
/// </summary>
public static class HtmlMaster
{

    public static string Header_Full
    {
        get
        {
            return string.Format("<div class='app-bar fixed-top darcula' data-role='appbar'>" +
            "<a href='" + ServerDirectory.Host + "/Default2.aspx' class='app-bar-element branding'>Jurnal General</a>" +
          // "<li><a href='" + ServerDirectory.Host + "/Default2.aspx'>Jurnal General</a></li>" +
          // " <a href='" + ServerDirectory.Host + "/Default2.aspx'>Jurnal General</a> "+
          "<span class='app-bar-divider'></span>" +
            "<ul class='app-bar-menu'>" +
                "<li><a href='" + ServerDirectory.Host + "/Dashboard.aspx'>Dashboard</a></li>" +
                //"<li>" +
                //    "<a href='' class='dropdown-toggle'>Help</a>" +
                //    "<ul class='d-menu' data-role='dropdown'>" +
                //        "<li><a href=''>ChatOn</a></li>" +
                //        "<li><a href=''>Community support</a></li>" +
                //        "<li class='divider'></li>" +
                //        "<li><a href=''>About</a></li>" +
                //    "</ul>" +
                //"</li>" +
            "</ul>" +
            "<div class='app-bar-element place-right'>" +
                "<span class='dropdown-toggle'><span class='mif-cog'></span ><asp:Label runat='server' ID='lblUserFullname'></asp:Label></span>" +
                "<div class='app-bar-drop-container padding10 place-right no-margin-top block-shadow fg-dark' data-role='dropdown' data-no-close='true' style='width: 220px'>" +
                // "<h2 class='text-light'>Quick settings</h2>"
                     "<img runat='server' src='" + SysClient.Client.ImageDirectoryVitual + "' id='imgProfile' style='height:160px; width:140px;'/>" +
                    "<ul class='unstyled-list fg-dark'>" +
                        "<li><a href='" + ServerDirectory.User + "/UserProFile.aspx' class='fg-white1 fg-hover-yellow'>Profile</a></li>" +
                        "<li><a href='" + ServerDirectory.Host + "/ChangePassword.aspx' class='fg-white2 fg-hover-yellow'>Change Password</a></li>" +
                        "<li><a href='" + ServerDirectory.Host + "/Logout.aspx' class='fg-white3 fg-hover-yellow'>Exit</a></li>" +
                    "</ul>" +
                "</div>" +
            "</div>" +
        "</div>");
        }
    }
    public static string Sidebar_Full
    {
        get
        {
            return string.Format(

                " <div class='cell size-x200' id='cell-sidebar' style='background-color: rgb(0,35,66);   height: 100%'>" +
                        "<ul class='sidebar2' style='background-color: rgb(0,35,66);'>" +
                            //"<li><a href='#'><span class='mif-home icon'></span>Home</a></li>" +
                            "<li class='divider'></li>" +
                            "<li><a href='" + ServerDirectory.User + "/UserRegistration_Step1.aspx'><span class='mif-user-plus icon'></span>User Register</a></li>" +
                            "<li><a href='" + ServerDirectory.Host + "/EvaluationPaper.aspx'><span class='mif-pencil icon'></span>EvaluationPaper</a></li>" +
                            "<li><a href='" + ServerDirectory.User + "/UsersList.aspx'><span class='mif-users icon'></span>Users List</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListChefEditor.aspx'><span class='mif-stack3 icon'></span>PaperListChefEditor</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListEditor.aspx'><span class='mif-stack3 icon'></span>PaperList Editor</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListSyntaxEditor.aspx'><span class='mif-stack3 icon'></span>PaperList SyntaxEditor</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListLanguageEditor.aspx'><span class='mif-stack3 icon'></span>PaperList LanguageEditor</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListReferee.aspx'><span class='mif-stack3 icon'></span>PaperList Referee</a></li>" +
                            "<li><a href='" + ServerDirectory.Paper + "/PaperListAuthor.aspx'><span class='mif-stack3 icon'></span>PaperList Author</a></li>" +
                            "<li><a href='" + ServerDirectory.Host + "/Paper/SubmitOnline.aspx'><span class='mif-files-empty icon'></span>Submit online</a></li>" +
                            "<li><a href='" + ServerDirectory.Host + "/Settings.aspx'><span class='mif-cogs icon'></span>Settings</a></li>" +
                           // "<li><a href='" + ServerDirectory.Host + "/ChangePassword.aspx'><span class='mif-lock icon'></span>ChangePass</a></li>" +

                           // "<li><a href='" + ServerDirectory.Host + "/UserProfile.aspx'><span class='mif-user icon'></span>User Profile</a></li>" +

                            //"<li>" +
                //    "<a href='#' class='dropdown-toggle'><span class='mif-mail-read icon'></span>Messages</a>" +
                //    "<ul class='d-menu' data-role='dropdown'>" +
                //        "<li><a href='#'>Send</a></li>" +
                //        "<li><a href='#'>Inbox</a></li>" +
                //        "<li><a href='#'>SentBox</a></li>" +
                //    "</ul>" +
                //"</li>" +
                        "</ul>" +
                    "</div>"

                    );
        }
    }
}