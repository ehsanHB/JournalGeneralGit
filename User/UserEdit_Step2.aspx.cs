using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserEdit_Step2 : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.User + "/UserEdit_Step2.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminVerification();
        if (!IsPostBack)
        {
            FillPageInfo();
        }
    }
    public void FillPageInfo()
    {
        int userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        FullUser user = userInfoMan.GetUserFullInfo(userID);
        if (user != null && user.User != null && user.User.Roles != null)
        {
            chbAuthor.Checked = user.User.Roles[RoleType.Author];
            chbCheffEditor.Checked = user.User.Roles[RoleType.CheifEditor];
            chbEditor.Checked = user.User.Roles[RoleType.Editor];
            chbLanguageEditor.Checked = user.User.Roles[RoleType.LanguageEditor];
            chbReferee.Checked = user.User.Roles[RoleType.Referee];
            chbSyntaxEditor.Checked = user.User.Roles[RoleType.SyntaxEditor];
        }
    }
    protected void btnRoleEdit_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        //
        DBmessage dbm = userInfoMan.RegisterRole(userID, chbCheffEditor.Checked,
            chbEditor.Checked, chbAuthor.Checked, chbReferee.Checked, chbLanguageEditor.Checked, chbSyntaxEditor.Checked);
        ShowNotify(dbm);
    }
}