<%@ WebHandler Language="C#" Class="PaperInfoRefereesSelection" %>

using System;
using System.Web;

public class PaperInfoRefereesSelection : FormBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
         UserVerification();

        DBmessage dbm = new DBmessage(DBMessageType.Error, SystemMessage.EmailCannotEmpty);
        string selectedItem = context.Request.Form["ddlReferee"].ToString();
        int paperID = Convert.ToInt32(context.Request.UrlReferrer.Query.Split('=')[1]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        if (selectedItem != string.Empty)
            dbm = paperInfoMan.SelectRefree(paperID, context.Request.Form["ddlReferee"].ToString(), new PersianDateTime(Convert.ToDateTime(context.Request.Form["txtbExpDate"].ToString())));
        else if (context.Request.Form["hf_ddlReferee"] != string.Empty && context.Request.Form["hf_ddlReferee"] != null)
            dbm = paperInfoMan.SelectRefree(paperID, context.Request.Form["hf_ddlReferee"].ToString(), new PersianDateTime(Convert.ToDateTime(context.Request.Form["txtbExpDate"].ToString())));
       // ShowNotify(dbm);
        // FillInfo();

        Session[RequestMSG.Notify] = dbm;
        context.Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + paperID);


    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}