using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Host + "/Dashboard.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UserVerification();
    }
}