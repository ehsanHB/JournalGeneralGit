using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yashar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfoMan_Business p = new UserInfoMan_Business();
        List<User_cls> users = p.GetLanguageEditorsList();
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        //paperInfoMan.SelectLanguegEditor(2043, 3104);
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        string a = Request.Form["testSelect"].ToString();
    }
}