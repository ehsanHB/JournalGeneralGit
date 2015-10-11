using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace LogicLayer
{
    /// <summary>
    /// Summary description for UserAuthorizeMan_Logic
    /// </summary>
    public class UserAuthorizeMan_Logic
    {
        public UserAuthorizeMan_Logic()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public Role GetRol(int userid)
        {
            SysClient thisclient = new SysClient();
            thisclient.UserID = userid;
            DataTable dt = thisclient.GetRol();
            if (dt.Rows.Count > 1)
                throw new Exception("role table for this client is more than one record!!! this is invalid data");
            return Role.Convert(dt);
        }
        private bool Login(string username, string password)
        {
            SysProperty.Client.Username = username;
            SysProperty.Client.Password = password;
            if (SysProperty.Client.Login())
            {
                //SysProperty.Client.Roles.Check();
                return true;
            }
            return false;
        }

        
        public bool SessionCheck()
        {
            SysClient session = SysProperty.Client;
            return session.SessionCheck();
        }
        public void Logout()
        {
            SysProperty.Client = new SysClient();
            HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
           
        }
      
    }
}