using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_PaperListAuthor : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        FillGridView();
        if(Request[RequestMSG.Msg] != null && Request[RequestMSG.Msg] != string.Empty && Request[RequestMSG.Type] != null && Request[RequestMSG.Type] != string.Empty)
        {
            DBMessageType type = DBMessageType.NoShow;
            if (DBMessageType.Sucsess.ToString() == FormBase.UrlDecode(Request[RequestMSG.Type].ToString()))
                type = DBMessageType.Sucsess;
            if (DBMessageType.Error.ToString() == FormBase.UrlDecode(Request[RequestMSG.Type].ToString()))
                type = DBMessageType.Error;
            DBmessage dbm = new DBmessage(type, FormBase.UrlDecode(Request[RequestMSG.Msg].ToString()));
            ShowNotify(dbm);
        }
    }

    public void FillGridView()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperReport paperReport = paperInfoMan.GetPaperListForAuther();
        gvPapers.DataSource = paperReport.Papers;
        gvPapers.DataBind();
    }

    public string DateTimeInString(DateTime dt)
    {
        return dt.ToString("yyyy.MM.dd");
    }

    public string PaperStatusInString(int statusID)
    {
        return PaperStatus.Convert(statusID);
    }

    protected void lnkbShow_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandArgument);
        Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + id);
    }
    public bool ContinueToolVisible(object obj)
    {
        PaperInfo paperInfo = (PaperInfo)obj;
        return paperInfo.IsNew;
    }
    public bool ContinueRevisedToolVisible(object obj)
    {
        PaperInfo paperInfo = (PaperInfo)obj;
        return paperInfo.IsRevised;
    }
    protected void lnkbContinue_Click(object sender, EventArgs e)
    {
        string[] IDs = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        int statusID = int.Parse(IDs[0]);
        int paperID = int.Parse(IDs[1]);
        if(statusID == PaperStatus.Preparing_step1)
            FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step2.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paperID.ToString() });
        if (statusID == PaperStatus.Preparing_step2)
            FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step3.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paperID.ToString() });
        if (statusID == PaperStatus.Preparing_step3)
            FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step4.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paperID.ToString() });

    }

    protected void lnkbReviseContinue_Click(object sender, EventArgs e)
    {
        string[] IDs = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        int statusID = int.Parse(IDs[0]);
        int paperID = int.Parse(IDs[1]);
        if (statusID == PaperStatus.ReviseByAuthor_Step1)
            FormBase.SendRequest(ServerDirectory.Paper + "/ReviseByAuthor_Step2.aspx", new string[] { RequestMSG.PaperID }, new string[] { paperID.ToString() });
        if (statusID == PaperStatus.ReviseByAuthor_Step2)
            FormBase.SendRequest(ServerDirectory.Paper + "/ReviseByAuthor_Step3.aspx", new string[] { RequestMSG.PaperID }, new string[] { paperID.ToString() });
    }
}