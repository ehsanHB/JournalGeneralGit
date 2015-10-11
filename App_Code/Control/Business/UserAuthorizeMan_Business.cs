using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer;

/// <summary>
/// Summary description for UserAuthorizeMan_Business
/// </summary>
public class UserAuthorizeMan_Business
{
	public UserAuthorizeMan_Business()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private void Login(string username, string password)
    {
        SysProperty.Client.Username = username;
        SysProperty.Client.Password = password;
        if (!SysProperty.Client.Login())
            FormBase.SendRequest(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.Msg }, new string[] { "نام کاربری یا رمز عبور اشتباه است" });
        else
        {
            UserAuthorizeMan_Logic u = new UserAuthorizeMan_Logic();
            SysProperty.Client.Roles =u.GetRol(SysProperty.Client.UserID);
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Dashboard.aspx", false);
        }
    }
    public void Login(string username, string password , string nextURL=null)
    {
        if (nextURL != null)
        {
            SysProperty.Client.Username = username;
            SysProperty.Client.Password = password;
            if (!SysProperty.Client.Login())
                FormBase.SendRequest(ServerDirectory.Host + "/Login.aspx", new string[] { RequestMSG.Msg }, new string[] { "نام کاربری یا رمز عبور اشتباه است" });
            else
            {
                UserAuthorizeMan_Logic u = new UserAuthorizeMan_Logic();
                SysProperty.Client.Roles = u.GetRol(SysProperty.Client.UserID);
                HttpContext.Current.Response.Redirect(nextURL);
            }
        }
        else
        {
            Login(username, password);
        }
    }
}
public  class SystemMessage_UserAuthorizeMan : SystemMessage
{
    
}