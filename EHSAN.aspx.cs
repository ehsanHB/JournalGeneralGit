using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EHSAN : FormBase
{
   public string test = "Hello World";

    protected void Page_Load(object sender, EventArgs e)
    {
        NotifyShow("this is test notify", NotifyType.alert);
        NotifyShow("this is test notify", NotifyType.alert);
        NotifyShow("this is test notify", NotifyType.alert);
        NotifyShow("this is test notify", NotifyType.alert);
        //Request.Form["testtest"] = "vhjgvhjgb";
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        //string s = "";
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        //string s = "";
    }
}