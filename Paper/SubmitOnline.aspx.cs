using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitOnline : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/SubmitOnline.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

       AuthorVerification();
    }
    protected void btnStep2_Click(object sender, EventArgs e)
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.RegisterPaper_Step1(txtbTitle.Text, txtbAbstract.Text, txtbKeyWord.Text, txtbFeildPaper.Text);
        Paper paper = (Paper)dbm.Parameter["paper"];
        if (dbm.Type == DBMessageType.Sucsess)
            FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step2.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paper.ID.ToString() });
        else
            ShowNotify(dbm);
    }
}