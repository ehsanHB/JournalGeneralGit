using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
        ////Get the required section of the web.config file by using configuration object.
        //CompilationSection compilation =
        //    (CompilationSection)config.GetSection("system.web/compilation");
        //AppSettingsSection sec = (AppSettingsSection)config.GetSection("appSettings");
        //sec.Settings["testkey"].Value="dynamicvalues";
        ////Update the new values.
        //compilation.Debug = true;
        ////save the changes by using Save() method of configuration object.
        //if (!compilation.SectionInformation.IsLocked)
        //{
        //    config.Save();
        //    Response.Write("New Compilation Debug" + compilation.Debug);
        //}
        //else
        //{
        //    Response.Write("Could not save configuration.");
        //}
        
    }
}