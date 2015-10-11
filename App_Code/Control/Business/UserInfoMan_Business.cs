using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer;
using System.Data;

/// <summary>
/// Summary description for UserInfoMan_Business
/// </summary>
public class UserInfoMan_Business
{
    public DBmessage EditUserProfileImage(byte[] image)
    {
        SysProperty.Client.Roles.Check(RoleType.User);
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        return logic.EditUserImage(SysProperty.Client.UserID, image); 
    }
    public User_cls GetClientInfo()
    {
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        User_cls user = logic.GetUserInfo(SysProperty.Client.UserID);
        return user;
    }
    public List<User_cls> GetRefereesList()
    {
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        return logic.GetRefereeList();
    }
    public List<User_cls> GetEditorList()
    {
        if (!SysClient.Client.Roles[RoleType.CheifEditor])
            return null;
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        return logic.GetEditorList();
    }
    public List<User_cls> GetLanguageEditorsList()
    {
        if (!SysClient.Client.Roles[RoleType.CheifEditor])
            return null;
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        return logic.GetLanguageEditors();
    }
    public DBmessage ChangePassWordByAdmin(int userID, string password)
    {
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        return logic.ChangePassword(userID, password);
    }
    public DBmessage ChangePassWordByUser(string oldPassword ,string newPassword )
    {
        DBmessage result = null;
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        if (oldPassword != string.Empty)
            result = logic.ChangePassword(SysClient.Client.UserID, oldPassword, newPassword);
        else
            result = logic.ChangePassword(SysClient.Client.UserID, newPassword);
        return result;
    }
    public DBmessage RegisterRole(int userID, bool chefEditor, bool editor, bool author, bool referee , bool languageEditor , bool syntaxEditor)
    {
        SysProperty.Client.Roles.Check(RoleType.Admin);
        UserInfoMan_Logic userInfoMan = new UserInfoMan_Logic();
        //
        Role oldRole = userInfoMan.GetRole(userID);
        //
        Role role = new Role();
        role[RoleType.Admin] = false;
        role[RoleType.CheifEditor] = chefEditor;
        role[RoleType.Editor] = editor;
        role[RoleType.Author] = author;
        role[RoleType.Referee] = referee;
        role[RoleType.LanguageEditor] = languageEditor;
        role[RoleType.SyntaxEditor] = syntaxEditor;
        role[RoleType.User] = true;
        DBmessage msg = userInfoMan.RegisterRole(userID, role , oldRole);
        if (msg.Type == DBMessageType.Sucsess)
            return new DBmessage(6101);
        return msg;
    }
    public UserInfoMan_Business()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public User_cls GetChefEditor()
    {
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        List<User_cls> users = logic.GetUsers(RoleType.CheifEditor);
        if (users != null && users.Count != 0)
            return users[0];
        return null;
    }
    public List<User_cls> GetUsersFullInfo(string affiliations, string fields, string firstname, string lastname,
             string email, int gender)
    {
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        Gender sex = null;
        if (gender != 0)
            sex = new Gender(gender);
        return logic.GetUsersFullInfo(0, affiliations, fields, firstname, lastname, "", "", email, sex);
    }
    public FullUser GetClientFullUserInfo()
    {
        SysProperty.Client.Roles.Check(RoleType.User);
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        FullUser fullUser = logic.GetUserFullInfo(SysProperty.Client.UserID);
        return fullUser;
    }
    public FullUser GetUserFullInfo(int id)
    {
        SysProperty.Client.Roles.Check(RoleType.Admin);
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        FullUser fullUser = logic.GetUserFullInfo(id);
        return fullUser;
    }
    /// <summary>
    /// baraye sabte moshakhasat az safheye register
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="affiliations"></param>
    /// <param name="phonenumber"></param>
    /// <param name="fax"></param>
    /// <param name="email"></param>
    /// <param name="nationnumber"></param>
    /// <param name="field"></param>
    /// <param name="birthdate"></param>
    /// <param name="education"></param>
    /// <param name="gender">hatman az static haye class Gender estefade shavad</param>
    /// <param name="title"></param>
    /// <returns></returns>
    public DBmessage RegisterAuthor(string firstname, string lastname, string affiliations, string phonenumber, string fax, string email, string nationnumber,
        string field, string birthdate, string education, int gender)
    {
        string password = FileOperations.SetId();
        int userid;
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        PersianDateTime birthDate = new PersianDateTime(Convert.ToDateTime(birthdate));
        DBmessage resultuserregister = logic.RegisterUser(email, password,new PersianDateTime(DateTime.Now.Add(SysProperty.ExpirationForSelectReferee)), firstname, lastname, affiliations, phonenumber, fax, email, nationnumber, field, birthDate, education, new Gender(gender), out userid);
        if (resultuserregister.Type == DBMessageType.Sucsess)
        {
            DBmessage resultauthor = logic.RegisterAuthor(userid, "", "", "", "");
            if (resultauthor.Type != DBMessageType.Sucsess)
                return resultauthor;
            User_cls user = new User_cls()
            {
                Fname = firstname,
                Lname = lastname,
                FullName = firstname + " " + lastname,
                Email = email,
                Username = email,
                Password = password
            };
            Email.SendAuthorRegisteration(user);
            return new DBmessage(DBMessageType.Sucsess, SystemMessage_UserINfoMan.AuthorRegister_sucsess);
        }
        return resultuserregister;
    }
    /// <summary>
    /// sabte yek editor
    /// </summary>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="affiliations"></param>
    /// <param name="phonenumber"></param>
    /// <param name="fax"></param>
    /// <param name="email"></param>
    /// <param name="nationnumber"></param>
    /// <param name="field"></param>
    /// <param name="birthdate"></param>
    /// <param name="education"></param>
    /// <param name="gender"></param>
    /// <param name="resume"></param>
    /// <param name="contacts"></param>
    /// <returns></returns>
    public DBmessage RegisterEditor(string firstname, string lastname, string affiliations, string phonenumber, string fax, string email, string nationnumber,
             string field, PersianDateTime birthdate, string education, int gender, string resume, string contacts)
    {
        string password = FileOperations.SetId();
        int userid;
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        DBmessage resultuserregister = logic.RegisterUser(email, password, new PersianDateTime(DateTime.Now.Add(SysProperty.ExpirationForSelectReferee)), firstname, lastname, affiliations, phonenumber, fax, email, nationnumber, field, birthdate, education, new Gender(gender), out userid);
        if (resultuserregister.Type == DBMessageType.Sucsess)
        {
            DBmessage resulteditor = logic.RegisterEditor(userid, resume, contacts);
            if (resulteditor.Type != DBMessageType.Sucsess)
                return resulteditor;
            User_cls user = new User_cls()
            {
                Fname = firstname,
                Lname = lastname,
                FullName = firstname + " " + lastname,
                Email = email,
                Username = email

            };
            Email.SendAuthorRegisteration(user);
            return new DBmessage(DBMessageType.Sucsess, SystemMessage_UserINfoMan.AuthorRegister_sucsess);
        }
        return resultuserregister;
    }
    public DBmessage RegisterUser(string firstname, string lastname, string affiliations, string phonenumber, string fax, string email, string nationnumber,
        string field, string birthdate, string education, int gender)
    {
        SysProperty.Client.Roles.Check(RoleType.Admin);
        int userid;
        string password = FileOperations.SetId();
        PersianDateTime birthDate = new PersianDateTime(Convert.ToDateTime(birthdate));
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        DBmessage resultuserregister = logic.RegisterUser(email, password, new PersianDateTime(DateTime.Now.Add(SysProperty.ExpirationForSelectReferee)), firstname, lastname, affiliations, phonenumber, fax, email, nationnumber, field, birthDate, education, new Gender(gender), out userid);
        resultuserregister.Parameter[RequestMSG.UsrID] = userid;
        if (resultuserregister.Type == DBMessageType.Sucsess)
        {
            User_cls user = new User_cls() { Email = email, UserID = userid, Password = password };
            Email.SendUserRegisteration(user);
        }
        return resultuserregister;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="Email"></param>
    /// <param name="firstname"></param>
    /// <param name="lastname"></param>
    /// <param name="affiliations"></param>
    /// <param name="phonenumber"></param>
    /// <param name="fax"></param>
    /// <param name="nationnumber"></param>
    /// <param name="field"></param>
    /// <param name="birthdate"></param>
    /// <param name="education"></param>
    /// <param name="gender">hatman az static class fgender por shavad</param>
    /// <returns></returns>
    public DBmessage EditUser(int userID,string email, string firstname, string lastname, string affiliations, string phonenumber, string fax, string nationnumber,
        string field, string birthdate, string education, int gender)
    {
        SysProperty.Client.Roles.Check(RoleType.Admin);
        PersianDateTime birthDate = new PersianDateTime(Convert.ToDateTime(birthdate));
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        DBmessage resultuserregister = logic.EditUser(userID, email, email, firstname, lastname, affiliations, phonenumber, fax, field, nationnumber,
            birthDate, education, new Gender(gender),null,null);
        if (resultuserregister.Type == DBMessageType.Sucsess)
            Email.SendEditUserInfoToUser(email);
        return resultuserregister;
    }
    public DBmessage EditUserProfile(string email, string firstname, string lastname, string affiliations, string phonenumber, string fax, string nationnumber,
        string field, string birthdate, string education, int gender)
    {
        SysProperty.Client.Roles.Check(RoleType.User);
        PersianDateTime birthDate = new PersianDateTime(Convert.ToDateTime(birthdate));
        UserInfoMan_Logic logic = new UserInfoMan_Logic();
        DBmessage resultuserregister = logic.EditUser(SysProperty.Client.UserID, email, email, firstname, lastname, affiliations, phonenumber, fax, field, nationnumber,
            birthDate, education, new Gender(gender), null, null);
        if (resultuserregister.Type == DBMessageType.Sucsess)
            Email.SendEditUserInfoToUser(email);
        return resultuserregister;
    }
}
public static class SystemMessage_UserINfoMan
{
    public static string AuthorRegister_sucsess
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Registration successfully completed. \n Check your email for get information";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "ثبت نام با موفقیت انجام شد. \n برای دریافت اطلاعات ایمیل خود را بررسی کنید.";
            return "";
        }
    }
    /// <summary>
    /// خطایی در ثبت داور به وجود آمده
    /// </summary>
    public static string ProblmeInRefereeRegistration { get {return SystemMessage.GetMessage("There was an error register referee", "خطایی در ثبت داور به وجود آمده"); } }
}