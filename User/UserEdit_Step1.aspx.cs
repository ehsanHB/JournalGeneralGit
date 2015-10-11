using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserEdit_Step1 : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.User + "/UserEdit_Step1.aspx"; }
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
            FillPageInfo();
        }
    }
    public void FillPageInfo()
    {
        int userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        FullUser user = userInfoMan.GetUserFullInfo(userID);
        //
        txtbName.Text = user.User.Fname;
        txtbLastName.Text = user.User.Lname;
        txtbAffiliations.Text = user.User.Affiliations;
        txtbPhoneNumber.Text = user.User.Phone;
        txtbFax.Text = user.User.Fax;
        txtbFieldsOfInterest.Text = user.User.Fields;
        txtbNationalCode.Text = user.User.Melli;
        txtbEducation.Text = user.User.Education;
        txtbEmail.Text = user.User.Email;
        ViewState[RequestMSG.UserImage] = user.User.Image;
        if (user.User.Birthdate != null && user.User.Birthdate.Datetime != null)
            txtbBirthDate.Text = user.User.Birthdate.Datetime.ToString("yyyy.MM.dd");
        if (user.User.Sex != null)
            ddlGender.SelectedValue = user.User.Sex.ID.ToString();
    }
    protected void btnUserEdit_Click(object sender, EventArgs e)
    {
        
        int userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.EditUser(userID, txtbEmail.Text, txtbName.Text, txtbLastName.Text, txtbAffiliations.Text, txtbPhoneNumber.Text, txtbFax.Text, txtbNationalCode.Text,
            txtbFieldsOfInterest.Text, txtbBirthDate.Text, txtbEducation.Text, Convert.ToInt32(ddlGender.SelectedValue));
        if (dbm.Type == DBMessageType.Sucsess)
            Response.Redirect(ServerDirectory.User + "/UserEdit_Step2.aspx?" + RequestMSG.UsrID + "=" + userID);
        else
            ShowNotify(dbm);

    }

    protected void btnEditPassword_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.ChangePassWordByAdmin(userID, txtbPass.Text);
        ShowNotify(dbm);
    }

}