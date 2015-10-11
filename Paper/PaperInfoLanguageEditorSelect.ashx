<%@ WebHandler Language="C#" Class="PaperInfoLanguageEditorSelect" %>

using System;
using System.Web;

public class PaperInfoLanguageEditorSelect : FormBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        UserVerification();
        int paperID = 0;
        if(context.Request.UrlReferrer != null)
        {
            paperID = Convert.ToInt32(context.Request.UrlReferrer.Query.Split('=')[1]);
        }
        else
        {
            context.Response.Redirect(ServerDirectory.Host + "/Dashboard.aspx");
        }
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.SelectLanguegEditor(paperID, Convert.ToInt32(context.Request.Form["ddlLanguageEditors"].ToString()),new PersianDateTime(Convert.ToDateTime(context.Request.Form["txtbLanEditorExpDate"].ToString())));
        //FillInfo();
        //ShowNotify(dbm);

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