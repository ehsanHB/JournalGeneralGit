using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : FormBase
{
    public byte[] userpic;
    public static string PageAddress
    {
        get { return ServerDirectory.Host + "/UserProfile.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UserVerification();
        FillInfo();
    }

    public void FillInfo()
    {
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        FullUser fulluser;
        if (Request[RequestMSG.UsrID] == null)
            fulluser = userInfoMan.GetClientFullUserInfo();
        else
            fulluser = userInfoMan.GetUserFullInfo(Convert.ToInt32(Request[RequestMSG.UsrID]));
        lblName.Text = fulluser.User.Fname;
        lblLastName.Text = fulluser.User.Lname;
        lblEmail.Text = fulluser.User.Email;
        lblAffiliations.Text = fulluser.User.Affiliations;
        lblPhoneNumber.Text = fulluser.User.Phone;
        lblFax.Text = fulluser.User.Fax;
        lblFieldsOfInterest.Text = fulluser.User.Fields;
        lblNationalCode.Text = fulluser.User.Melli;
        lblEducation.Text = fulluser.User.Education;
        lblbBirthDate.Text = fulluser.User.Birthdate.Datetime.ToString("yyyy.MM.dd");
        lblGender.Text = fulluser.User.Sex.Title;
        userpic = fulluser.User.Image;

    }


    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        if (Request[RequestMSG.UsrID] != null)
            Response.Redirect(ServerDirectory.User + "/EditProfile.aspx?" + RequestMSG.UsrID + "=" + Request[RequestMSG.UsrID].ToString());
        else
            Response.Redirect(ServerDirectory.User + "/EditProfile.aspx");
    }
}