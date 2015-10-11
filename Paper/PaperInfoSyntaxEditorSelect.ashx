<%@ WebHandler Language="C#" Class="PaperInfoSyntaxEditorSelect" %>

using System;
using System.Web;

public class PaperInfoSyntaxEditorSelect : FormBase, IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        UserVerification();


        int paperID = Convert.ToInt32(context.Request.UrlReferrer.Query.Split('=')[1]);

      //  Session[RequestMSG.Notify] = dbm;
        context.Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + paperID);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}