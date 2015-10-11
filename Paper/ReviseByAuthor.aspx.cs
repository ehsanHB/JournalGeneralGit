using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_ReviseByAuthor : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        if (!IsPostBack)
        {
            FillInfo();
        }
    }
    public void FillInfo()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperInfo paper = paperInfoMan.GetPaperInfoForAuthor(Convert.ToInt32(Request[RequestMSG.PaperID]));
        if (paper != null)
        {
            txtbAbstract.Text = paper.Abstracts;
            txtbFeildPaper.Text = paper.Feilds;
            txtbKeyWord.Text = paper.Keyword;
        }
    }

    protected void btnStep2_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.PaperID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.ReviseByAuthor_Step1(paperID, txtbAbstract.Text, txtbKeyWord.Text, txtbFeildPaper.Text);
        if (dbm.Type == DBMessageType.Sucsess)
            FormBase.SendRequest(ServerDirectory.Paper + "/ReviseByAuthor_Step2.aspx", new string[] { RequestMSG.PaperID }, new string[] { paperID.ToString() });
        else
            ShowNotify(dbm);
    }
}