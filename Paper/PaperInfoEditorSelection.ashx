<%@ WebHandler Language="C#" Class="PaperInfoEditorSelection" %>

using System;
using System.Web;

public class PaperInfoEditorSelection : FormBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        UserVerification();
        
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
        DBmessage dbm = paperInfoMan.SelectEditor(paperID, Convert.ToInt32(context.Request.Form["ddlEditors"].ToString()));
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