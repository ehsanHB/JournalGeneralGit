using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UsersList : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.User + "/UsersList.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AdminVerification();

        if (!IsPostBack)
        {
            //fill dropdown gender
            ddlGender.Items.Add(new ListItem("All", "0"));
            ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Male), Gender.Male.ToString()));
            ddlGender.Items.Add(new ListItem(Gender.Convert(Gender.Female), Gender.Female.ToString()));
            //end fill
            FillGridView();

        }
    }
    public void FillGridView()
    {
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        gvUsers.DataSource = userInfoMan.GetUsersFullInfo(txtbAffiliations.Text, txtbFieldsOfInterest.Text, txtbName.Text
            , txtbLastName.Text, txtbEmail.Text, Convert.ToInt32(ddlGender.SelectedValue));
        gvUsers.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridView();
    }

    protected void lnkbShow_Click(object sender, EventArgs e)
    {
        LinkButton lnkb = (LinkButton)sender;
        Response.Redirect(ServerDirectory.User +"/UserProfile.aspx?" + RequestMSG.UsrID + "=" + lnkb.CommandArgument);
    }

    protected void lnkbEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnkb = (LinkButton)sender;
        Response.Redirect(ServerDirectory.User + "/UserEdit_Step1.aspx?" + RequestMSG.UsrID + "=" + lnkb.CommandArgument);
    }
}