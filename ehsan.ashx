<%@ WebHandler Language="C#" Class="ehsan" %>

using System;
using System.Web;

public class ehsan : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        string str= context.Request.Form["testtest"].ToString();        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}