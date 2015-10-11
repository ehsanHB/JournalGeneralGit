using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    #region attribute
    private string _address;
    private string _password;
    private string _displayName;
    #endregion
    #region prop
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public string DisplayName
    {
        get { return _displayName; }
        set { _displayName = value; }
    }
    #endregion
    #region method
    public Email()
    {

    }
    public Email(string address, string password)
    {
        this.Address = address;
        this.Password = password;
        this.DisplayName = SysProperty.SystemEmailDisplayName;
    }
    public static void SendMail(string to, string subject, string Body)
    {
        string from = SysProperty.SystemEmail.Address;
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(from, SysProperty.SystemEmail.DisplayName, System.Text.Encoding.UTF8);
        mail.Subject = subject;
        mail.IsBodyHtml = true;

        mail.Body = Body + "<br/><br/> Please do NOT respond to this E-mail as it is automatically generated.";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.Priority = MailPriority.High;
        mail.To.Add(to);
        SmtpClient smtp = new SmtpClient();

        smtp.Credentials = new System.Net.NetworkCredential(from, SysProperty.SystemEmail.Password);
        smtp.Port = 25;
        smtp.Host = SysProperty.SystemEmailHostName;
        //smtp.UseDefaultCredentials = false;
        //smtp.EnableSsl = true;
        Thread thread_sentMail = new Thread(() => smtp.Send(mail));
        thread_sentMail.Start();
        
        //btnSend.Text = "succesfully";

    }
    public static void SendMail(List<string> to, string subject, string Body)
    {
        string from = SysProperty.SystemEmail.Address;
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(from, SysProperty.SystemEmail.DisplayName, System.Text.Encoding.UTF8);
        mail.Subject = subject;
        mail.IsBodyHtml = true;

        mail.Body = Body + "<br/><br/> Please do NOT respond to this E-mail as it is automatically generated.";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.Priority = MailPriority.High;
        for (int i = 0; i < to.Count; i++)
        {
            mail.To.Add(to[i]);
        }
        SmtpClient smtp = new SmtpClient();

        smtp.Credentials = new System.Net.NetworkCredential(from, SysProperty.SystemEmail.Password);
        smtp.Port = 25;
        smtp.Host = SysProperty.SystemEmailHostName;
        //smtp.UseDefaultCredentials = false;
        //smtp.EnableSsl = true;
        Thread thread_sentMail = new Thread(() => smtp.Send(mail));
        thread_sentMail.Start();

        //btnSend.Text = "succesfully";

    }
    #endregion
    #region static member
    /// <summary>
    /// gereftane linke yek maghale
    /// </summary>
    /// <param name="paperProcedure"></param>
    /// <returns></returns>
    public static string GetPaperProfileLink(PaperProcedures paperProcedure)
    {
        throw new Exception("fill code here");
    }
    //----------------
    public static void SendEditUserInfoToUser(string email)
    {
        Email.SendMail(email, "Edit Account", "Your account information was edited successfully.");
    }
    public static void SendAcceptedPaperByChefEditor(PaperProcedures paperProcedure)
    {
        Email.SendMail(paperProcedure.Paper.Owner.User.Email, "Initial verification Article", "Your article as a " + paperProcedure.Paper.Title + " was first confirmed by the chef editor");
    }
    public static void SendRejectedPaperByChefEditor(PaperProcedures paperProcedure)
    {
        Email.SendMail(paperProcedure.Paper.Owner.User.Email, "Reject Article", "Your article titled " + paperProcedure.Paper.Title + " was rejected\nChef Editor Comment:\n"
            + paperProcedure.Comment);
    }
    public static void SendSelectEditorByChefEditor(PaperProcedures paperProcedure , User_cls editor)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.Password, RequestMSG.NextURL }, 
            new string[] { editor.Email, editor.Hash, ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + paperProcedure.Paper.ID });
        Email.SendMail(editor.Email, "Your chosen as editor", "As editor of the paper " + paperProcedure.Paper.Title + " have been chosen\n"
            + "Article link:\n" + "Follow up this artical:<br/>" + "<a href='" + url + "'>" + "Artical Information" + "</a>");
    }
    /// <summary>
    /// email ersali bade sabte name yek author
    /// </summary>
    /// <param name="user"></param>
    public static void SendAuthorRegisteration(User_cls user)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.Password, RequestMSG.NextURL },
            new string[] { user.Email, user.Password, ServerDirectory.User + "/UserProfile.aspx" });
        Email.SendMail(user.Email, "You have successfully registered as author", "You have successfully been registered as an author.<br/>Username :" + user.Email + "<br/>Please change your password from settings after you loged in. <br/>"
            + "Profile link:<br/>" + "<a href='" + url + "'>" + "Go To Profile" + "</a>");
    }
    public static void SendUserRegisteration(User_cls user)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.Password, RequestMSG.NextURL },
            new string[] { user.Email, user.Password, ServerDirectory.Host + "/UserProfile.aspx" });
        Email.SendMail(user.Email, "Successfully registered", "You have successfully been registered as an user.<br/>Username :" + user.Email + "<br/>Password :"
            + user.Password + "<br/>"
            + "Profile link:<br/>" + "<a href='" + url + "'>" + "Go To Profile" + "</a>");
    }
    /// <summary>
    /// email ersali bade sabte nam editor
    /// </summary>
    /// <param name="user"></param>
    public static void SendEditorRegisteration(User_cls user)
    {
        Email.SendMail(user.Email, "You have successfully registered as editor", "You have successfully been registered as an author.\n"
            + "Login link:\n" + ServerDirectory.Host + @"\Login.aspx");//hash URL
    }
    public static void SendPaperRegisterationToChefEditor(User_cls chefEditor,PaperInfo paperInfo)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.NextURL }, new string[]
            { chefEditor.Email , ServerDirectory.Paper+"/PaperInfo.aspx"});
        Email.SendMail(chefEditor.Email, "New article submited", "A new article entitled " +paperInfo.Title+ " by " +paperInfo.Owner.User.FullName+ " was recorded<br/>"
            + "Follow up artical:<br/>"+ "<a href='" + url + "'>" + "Artical Information" + "</a>");
    }
    public static void SendPaperRegisterationToAuthor(PaperInfo paperInfo)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.NextURL }, new string[]
            { paperInfo.Owner.User.Email , ServerDirectory.Paper+"/PaperInfo.aspx"});
        Email.SendMail(paperInfo.Owner.User.Email, "You have successfully registered artical", "You have successfully been registered your artical in " + SysProperty.SystemName + ".<br/>"
             + "Follow up your artical:<br/>" + "<a href='" + url + "'>" + "Artical Information" + "</a>");
    }
    internal static void SendSelectReferee(PaperInfo paperInfo, User_cls Referee,PersianDateTime expiration)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName,RequestMSG.Password, RequestMSG.NextURL }, new string[] { Referee.Email,Referee.Password, ServerDirectory.Paper + "/PaperInformation.aspx?"+RequestMSG.ID+"="+paperInfo.ID });
        Email.SendMail(Referee.Email, "You selected as referee", "You selected as referee for  "+paperInfo.Title+" in " + SysProperty.SystemName + ".<br/>Articale abstract:<br/>"
            +paperInfo.Abstracts+"<br/>You are on " + expiration.Datetime.Date+" you time to confirm article"
             + "Follow up this artical:<br/>" + "<a href='" + url + "'>" + "Artical Information" + "</a>");
    }
    public static void SentAcceptArbitration(PaperInfo info)
    {
        Email.SendMail(info.ThisReferee.LastSelector.User.Email, "Judgment confirms article", "Referee "+info.ThisReferee.User.FullName+" article judgment as "+
            info.Title+" accepted");
    }
    public static void SendSelectLanguageEditor(FullUser languageEditor , PaperInfo paperInfo)
    {
        string url = FormBase.SendRequestInString(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.UserName, RequestMSG.Password, RequestMSG.NextURL }, new string[] { languageEditor.User.Email, languageEditor.User.Hash, ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + paperInfo.ID });
        Email.SendMail(languageEditor.User.Email, "Language Editor Selection", "You selected as language Editor for  " + paperInfo.Title + " in " + SysProperty.SystemName + ".<br/>Articale abstract:<br/>"
            + paperInfo.Abstracts + "<br/>You are on you time to confirm article"
             + "Follow up this artical:<br/>" + "<a href='" + url + "'>" + "Artical Information" + "</a>");
    }
    public static void SentRejectArbitration(PaperInfo info)
    {
        Email.SendMail(info.ThisReferee.LastSelector.User.Email, "Reject arbitration article", info.ThisReferee.User.FullName + " refused the judgement of the " +
            info.Title );
    }
    public static void SentRevisedPaperToReferees(PaperInfo info)
    {
        List<string> emails = new List<string>();
        if (info.Referees.Count != 0)
        {
            for (int i = 0; i < info.Referees.Count; i++)
            {
                emails.Add(info.Referees[i].User.Email);
            }
            Email.SendMail(emails, "Article Revised", "Article entitled " + info.Title + " revised by chef editor");
        }
    }
    #endregion


}