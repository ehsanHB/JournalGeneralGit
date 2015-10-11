using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRegistration : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Host + "/AuthorRegistration.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

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
        DBmessage dbm = userInfoMan.RegisterAuthor(txtbName.Text,txtbLastName.Text,txtbAffiliations.Text,txtbPhoneNumber.Text,txtbFax.Text,txtbEmail.Text,txtbNationalCode.Text
            , txtbFieldsOfInterest.Text, txtbBirthDate.Text, txtbEducation.Text, Convert.ToInt32(ddlGender.SelectedValue));
        ShowNotify(dbm);
    }
}