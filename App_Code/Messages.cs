using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
	public Messages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string Login_Error 
    {
        get { return "Username Or password is incorrect !"; } 
    }
    public static string Password_Error
    {
        get { return "Password and retype password isn't match !"; }
    }
    public static string Login_Roll_Error
    {
        get { return "Please select your role and try again !"; }
    }
}