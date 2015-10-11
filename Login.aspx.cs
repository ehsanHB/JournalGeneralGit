using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public static string PageAddress
    {
        get { return ServerDirectory.Host + "/Login.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserAuthorizeMan_Business userAuthorize = new UserAuthorizeMan_Business();
            string nextURl = null;
            if (!string.IsNullOrEmpty(Request[RequestMSG.UserName]))
            {
                txtEmail.Text = FormBase.UrlDecode(Request[RequestMSG.UserName]);
            }
            if (!string.IsNullOrEmpty(Request[RequestMSG.NextURL]))
            {
                nextURl = FormBase.UrlDecode(Request[RequestMSG.NextURL]);
            }
            if (!string.IsNullOrEmpty(Request[RequestMSG.Password]))
            {
                txtPass.Text = FormBase.UrlDecode(Request[RequestMSG.Password]);
            }
            if (txtEmail.Text != string.Empty && txtPass.Text != string.Empty)
            {
                userAuthorize.Login(txtEmail.Text, txtPass.Text, nextURl);
            }
            if (SysProperty.Client.Roles[RoleType.User])
                Response.Redirect(ServerDirectory.Host + "/Dashboard.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserAuthorizeMan_Business userAuthorize = new UserAuthorizeMan_Business();
        userAuthorize.Login(txtEmail.Text, txtPass.Text);
    }
}