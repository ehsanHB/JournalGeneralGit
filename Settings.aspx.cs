using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Settings : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminVerification();
        txtbInterimCodePaper.Text = WebConfig.showConfig().interimCodePaper;
        txtbPermanentCodePaper.Text = WebConfig.showConfig().permanentCodePaper;
        txtbNameEnglish.Text = WebConfig.showConfig().systemNameEnglish;
        txtbNamePersian.Text = WebConfig.showConfig().systemNamePersian;
        txtbExpSelectReferee.Text = WebConfig.showConfig().expirationForSelectReferee.Days.ToString();
        txtbExpSubmitOnline.Text = WebConfig.showConfig().expirationForSubmitOnline.Days.ToString();
        txtbsysEmailHostName.Text = WebConfig.showConfig().systemEmailHostName;
        txtbSysEmailDisplayName.Text = WebConfig.showConfig().systemEmailDisplayName;
        txtbSysEmailAddress.Text = WebConfig.showConfig().systemEmail.Address;
        txtbSysEmailPass.Text = WebConfig.showConfig().systemEmail.Password;
        txtbMinReferee.Text = WebConfig.showConfig().theMinimumReferees.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        WebConfig saveconfig = new WebConfig();

        saveconfig.interimCodePaper = txtbInterimCodePaper.Text;
        saveconfig.permanentCodePaper = txtbPermanentCodePaper.Text;

        saveconfig.systemNameEnglish = txtbNameEnglish.Text;
        saveconfig.systemNamePersian = txtbNamePersian.Text;

        saveconfig.expirationForSelectReferee = TimeSpan.Parse(txtbExpSelectReferee.Text);
        saveconfig.expirationForSubmitOnline = TimeSpan.Parse(txtbExpSubmitOnline.Text);

        saveconfig.systemEmailHostName = txtbsysEmailHostName.Text;
        saveconfig.systemEmailDisplayName = txtbSysEmailDisplayName.Text;
        saveconfig.systemEmail = new Email(txtbSysEmailAddress.Text, txtbSysEmailPass.Text);

        saveconfig.theMinimumReferees = int.Parse(txtbMinReferee.Text);

        SysProperty.SaveConfig(saveconfig);
    }
}