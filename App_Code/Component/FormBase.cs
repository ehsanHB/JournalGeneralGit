using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Web.UI;


/// <summary>
/// Summary description for FormBase
/// </summary>
public class FormBase : System.Web.UI.Page
{
    public FormBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    private static string RequestHash(string request)
    {
        if (request == null)
            throw new Exception("request cannot be null !!!");
        return Convert.ToBase64String(Encoding.Unicode.GetBytes(request));
    }
    public static void SendRequest(string URL, string[] ReqName, string[] ReqValue)
    {
        string Reqs = string.Empty;
        for (int i = 0; i < ReqName.Length && i < ReqValue.Length; i++)
        {
            Reqs += ReqName[i] + "=" + RequestHash(ReqValue[i]) + "&";
            //Reqs += ReqName[i] + "=" + ReqValue[i] + "&";
        }
        HttpContext.Current.Response.Redirect(URL + "?" + Reqs);
    }
    public static string SendRequestInString(string URL, string[] ReqName, string[] ReqValue)
    {
        string Reqs = string.Empty;
        for (int i = 0; i < ReqName.Length && i < ReqValue.Length; i++)
        {
            Reqs += ReqName[i] + "=" + RequestHash(ReqValue[i]) + "&";
        }
        return URL + "?" + Reqs;
    }
    public static string UrlDecode(string request)
    {
        try
        {
            byte[] result = Convert.FromBase64String(request);
            return Encoding.Unicode.GetString(result);
        }
        catch (Exception)
        {
            return "";
        }
    }
    

    //private GodFather _godfather;
    //public GodFather Godfather
    //{
    //    set { _godfather = value; }
    //    get { return _godfather; }
    //}

    protected void UserVerification()
    {
        if(!SysProperty.Client.Roles[RoleType.User] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void AuthorVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.Author] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void AdminVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.Admin] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void ChefEditorVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.CheifEditor] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void EditorVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.Editor] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void SyntaxEditorVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.SyntaxEditor] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void LanguageEditorVerification()
    {
        if (!SysProperty.Client.Roles[RoleType.LanguageEditor] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void RefereeVerification() // bayad virayesh shavad
    {
        if (!SysProperty.Client.Roles[RoleType.Referee] == true)
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    protected void CheckSession()
    {
        //UserAuthorizeMan sm = new UserAuthorizeMan();

        //if (!sm.SessionCheck())
        //{
        //    HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
        //}
        throw new Exception("this function is empty, what should happened?? :D");
    }
    public void CheckAuthorSession()
    {
        //CheckSession();
        //if (!GodFather.Client.Role.Author)
        //    HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
        throw new Exception("fill code here");
    }
    public void CheckAdminSession()
    {
        //CheckSession();
        //if (!GodFather.Client.Role.Admin)
        //    HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
        throw new Exception("fill code here");
    }
    public void CheckRefereeSession()
    {
        //CheckSession();
        //if (!GodFather.Client.Role.Referee)
        //    HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
        throw new Exception("fill code here");

    }
    public void CheckEditorSession()
    {
        //CheckSession();
        //if (!GodFather.Client.Role.Editor)
        //    HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
        throw new Exception("fill code here");

    }
    ///////############## S T A R T    Notify Source Code
    ///


    protected void NotifyAlert(string msg)
    {
        NotifyShow(msg, NotifyType.warning);
    }
    protected void NotifyError(string msg)
    {
        NotifyShow(msg, NotifyType.alert);

    }
    protected void NotifyInfo(string msg)
    {
        NotifyShow(msg, NotifyType.info);
    }
    protected void NotifySuccess(string msg)
    {
        NotifyShow(msg, NotifyType.success);
    }
    public void ShowNotify(DBmessage message)
    {
        switch (message.Type)
        {
            case DBMessageType.Sucsess: NotifySuccess(message.Message);
                break;
            case DBMessageType.Info: NotifyInfo(message.Message);
                break;
            case DBMessageType.Alert: NotifyAlert(message.Message);
                break;
            case DBMessageType.Error: NotifyError(message.Message);
                break;
            case DBMessageType.NoShow:
                break;
            default:
                break;
        }
    }
    public void ShowNotify(Exception exc)
    {
        NotifyError(exc.Message);
    }
    public void ShowNotify(MyException exc)
    {
        NotifyError(exc.Message);
    }
    protected void NotifyShow(string msg, NotifyType type)
    {
        string myScript = string.Format("showNotify('', '{0}', '{1}',true,7000,false,'','')", msg, type);
        StringBuilder str = new StringBuilder();

        str.Append(myScript); 

        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            "AlertJS", str.ToString(), true);
    }


    public enum NotifyType
    {
        success,
        alert,
        info,
        warning
    }
    ///////############## E N D    Notify Source Code
    
    public void GetException(Exception ex)
    {
        NotifyShow(ex.Message, NotifyType.alert);
    }
   
}




