using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UserVerification();
        if (!IsPostBack)
        {
            if (SysClient.HavePassword)
            {
                trOldPass.Visible = true;
            }
            else if (!SysClient.HavePassword)
            {
                txtbOldPassWord.Attributes.Remove("data-validate-func");
                txtbOldPassWord.Attributes.Remove("data-validate-hint");
                trOldPass.Style.Add("display", "none");
                txtbOldPassWord.Text = "";
            }
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.ChangePassWordByUser(txtbOldPassWord.Text, txtbNewPass.Text);
        ShowNotify(dbm);
    }
}