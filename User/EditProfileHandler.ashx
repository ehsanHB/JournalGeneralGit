<%@ WebHandler Language="C#" Class="EditProfileHandler" %>

using System;
using System.Web;

public class EditProfileHandler : FormBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {        
        context.Response.ContentType = "text/plain";
        UserVerification();

        string Email = context.Request.Form["txtbEmail"].ToString();
        string Name = context.Request.Form["txtbName"].ToString();
        string Lastname = context.Request.Form["txtbLastName"].ToString();
        string Affiliations = context.Request.Form["txtbAffiliations"].ToString();
        string PhoneNumber = context.Request.Form["txtbPhoneNumber"].ToString();
        string Fax = context.Request.Form["txtbFax"].ToString();
        string NationalCode = context.Request.Form["txtbNationalCode"].ToString();
        string Interest = context.Request.Form["txtbFieldsOfInterest"].ToString();
        string BirthDate = context.Request.Form["txtbBirthDate"].ToString();
        string Education = context.Request.Form["txtbEducation"].ToString();
        int sex =Convert.ToInt32( context.Request.Form["ddlGender"].ToString());
               
        int userID = SysProperty.Client.UserID;
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        DBmessage dbm = userInfoMan.EditUserProfile(Email, Name, Lastname, Affiliations,
            PhoneNumber, Fax, NationalCode,
            Interest, BirthDate, Education, sex);
        ShowNotify(dbm);
        
        context.Response.Redirect(ServerDirectory.User + "/EditProfile.aspx");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}