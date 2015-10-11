<%@ Application Language="C#" %>

<script RunAt="server">

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        //HttpContext.Current.Response.Cache.SetNoStore();
    }
    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        //if (HttpContext.Current.Session != null)
        //{
        //    HttpContext context = base.Context;
        //    HttpRequest request = context.Request;
        //    string pageName = System.IO.Path.GetFileNameWithoutExtension(path: request.RawUrl);


        //    if (pageName != "EmployeeRegistration")
        //        if (HttpContext.Current.Session[SessionType.UserId_EmployeeRegistration] != null)
        //            HttpContext.Current.Session.Remove(SessionType.UserId_EmployeeRegistration);
        //}
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        //HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
       
    }
    void Application_Start(object sender, EventArgs e)
    {
        ServerDirectory.PhysicalPath = HttpContext.Current.Server.MapPath(".");

        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        Uri uri = HttpContext.Current.Request.Url;
        String host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
        ServerDirectory.Host = host;
        /////////////////////////////////
        SysProperty.Client = new SysClient();
        SysProperty.Client.Roles = new Role(false);
        SysProperty.Client.ClientInfo = "";
        SysProperty.ChangeSiteLanguage(Languages.English);
        
    }

    void Session_End(object sender, EventArgs e)
    {


    }
       
</script>
