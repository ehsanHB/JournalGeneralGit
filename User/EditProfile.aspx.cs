using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfile : FormBase
{
    public int userID;
    public FullUser user;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserVerification();
        FillPageInfo();

        // کد های این قسمت به هندلر منتقل شد

        //if (!IsPostBack)
        //{
            //fill dropdown gender
            //ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Male), Gender.Male.ToString()));
            //ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Female), Gender.Female.ToString()));
            //end fill         
        //}
    }
    public void FillPageInfo()
    {
        userID = 0;
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        if (Request[RequestMSG.UsrID] != null)
        {
            userID = Convert.ToInt32(Request[RequestMSG.UsrID]);
            user = userInfoMan.GetUserFullInfo(userID);
        }
        else
            user = userInfoMan.GetClientFullUserInfo();
        // کد های این قسمت به هندلر منتقل شد
        //txtbName.Text = user.User.Fname;
        //txtbLastName.Text = user.User.Lname;
        //txtbAffiliations.Text = user.User.Affiliations;
        //txtbPhoneNumber.Text = user.User.Phone;
        //txtbFax.Text = user.User.Fax;
        //txtbFieldsOfInterest.Text = user.User.Fields;
        //txtbNationalCode.Text = user.User.Melli;
        //txtbEducation.Text = user.User.Education;
        //txtbEmail.Text = user.User.Email;
        //ViewState[RequestMSG.UserImage] = user.User.Image;
        //if (user.User.Birthdate != null && user.User.Birthdate.Datetime != null)
        //    txtbBirthDate.Text = user.User.Birthdate.Datetime.ToString("yyyy.MM.dd");
        //if (user.User.Sex != null)
        //    ddlGender.SelectedValue = user.User.Sex.ID.ToString();
    }
    protected void btnChangeAvatar_Click(object sender, EventArgs e)
    {
        try
        {
            HttpPostedFile Avatar = fuAvatar.PostedFile;
            string[] validType = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            byte[] userImage = null;
            if (Avatar != null)
                userImage = FileOperations.getFile(Avatar, ServerDirectory.UploadPhysical, validType);
            else if (ViewState[RequestMSG.UserImage] != null)
                userImage = (byte[])ViewState[RequestMSG.UserImage];
            //

            UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
            DBmessage dbm = userInfoMan.EditUserProfileImage(userImage);
            ShowNotify(dbm);
        }
        catch (MyException ex)
        {
            ShowNotify(ex);
        }
        catch (Exception ex)
        {
            ShowNotify(ex);
        }
    }

    // کد های این قسمت به هندلر منتقل شد
    //protected void btnEditProfile_Click(object sender, EventArgs e)
    //{
        //int userID = SysProperty.Client.UserID;
        //UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        //DBmessage dbm = userInfoMan.EditUserProfile(txtbEmail.Text, txtbName.Text, txtbLastName.Text, txtbAffiliations.Text, txtbPhoneNumber.Text, txtbFax.Text, txtbNationalCode.Text,
        //    txtbFieldsOfInterest.Text, txtbBirthDate.Text, txtbEducation.Text, Convert.ToInt32(ddlGender.SelectedValue));
        //ShowNotify(dbm);
    //}

    public string isMaleOrFemale(int gender)
    {
        if (user.User.Sex != null && Gender.Convert(user.User.Sex.ID) == "Male" && gender == 1)
        {
            return "selected='selected'";
        }
        else if (user.User.Sex != null && Gender.Convert(user.User.Sex.ID) == "Female" && gender == 2)
        {
            return "selected='selected'";
        }
        else
        { return ""; }
    }

}