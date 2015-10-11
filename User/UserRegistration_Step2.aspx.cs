using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegistration_Step : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.User + "/UserRegistration_Step2.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        AdminVerification();
        if (Session[RequestMSG.UsrID] == null)
            Response.Redirect(ServerDirectory.User + "/UserRegistration_Step2.aspx");
    }

    protected void btnRoleRegister_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Session[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.RegisterRole(userID, chbCheffEditor.Checked, chbEditor.Checked, chbAuthor.Checked,
            chbReferee.Checked, chbLanguageEditor.Checked, chbSyntaxEditor.Checked);
        ShowNotify(dbm);
    }
}