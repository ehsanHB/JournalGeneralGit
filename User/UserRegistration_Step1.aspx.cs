using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditorRegistration : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.User + "/UserRegistration_Step1.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        AdminVerification();
        if (!IsPostBack)
        {
            //fill dropdown gender
            ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Male), Gender.Male.ToString()));
            ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Female), Gender.Female.ToString()));
            //end fill
        }
    }

    protected void btnUserRegister_Click(object sender, EventArgs e)
    {
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.RegisterUser(txtbName.Text, txtbLastName.Text, txtbAffiliations.Text, txtbPhoneNumber.Text, txtbFax.Text, txtbEmail.Text, txtbNationalCode.Text,
            txtbFieldsOfInterest.Text,txtbBirthDate.Text, txtbEducation.Text, Convert.ToInt32(ddlGender.SelectedValue));
        if (dbm.Type == DBMessageType.Sucsess)
        {
            Session[RequestMSG.UsrID] = dbm.Parameter[RequestMSG.UsrID];
            Response.Redirect(ServerDirectory.User + "/UserRegistration_Step2.aspx");
        }
        else
            ShowNotify(dbm);
    }
}