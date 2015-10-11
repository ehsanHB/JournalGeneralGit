using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaperInformation : FormBase
{
    public UserInfoMan_Business userInfoMan = new UserInfoMan_Business();


    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/PaperInformation.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UserVerification();
        if (!IsPostBack)
        {
            ShowNotify();
        }
        FillInfo();
    }

    public void ShowNotify()
    {
        if(Session[RequestMSG.Notify]!=null)
        {
            ShowNotify((DBmessage)Session[RequestMSG.Notify]);
            Session[RequestMSG.Notify] = null;
        }
    }

    public PaperInfo info;
    public void FillInfo()
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        info = paperInfoMan.GetPaperInfo(paperID);
        if (info != null)
        {
            btnRefereesSelection.Visible = info.CanBeSelectRefrees;
            btnEditorSelection.Visible = info.CanBeSelectEditorByChefEditor;
            btnLanguageEditorSelection.Visible = info.CanBeSelectLanguageEditor;
            btnAcceptByChefEditor.Visible = info.CanBeAcceptByChefEditor;
            ddlEvaluationForm.Visible = info.CanBeAcceptByChefEditor;
            btnRejectByChefEditor.Visible = info.CanBeRejectByChefEditor;
            btnAcceptArbitration.Visible = info.CanBeAcceptByReferee;
            btnRejectArbitrationArticle.Visible = info.CanBeRejectByReferee;
            btnEvaluation.Visible = info.CanBeEvaluatByReferee;
            btnRevise.Visible = info.CanBeReviseByEditor;
            btnReviseComment.Visible = info.CanBeReviseByEditor;
            btnReviseByAuthor.Visible = info.CanBeReviseByAuthor_Step1;
            //btnRefereesOpinion.Visible = info.canbe
            btnFinalApproval.Visible = info.CanBeTechnicalApproval;
            //
            lblTitle.Text = info.Title;
            lblAbstract.Text = info.Abstracts;
            lblFieldPaper.Text = info.Feilds;
            lblKeyWord.Text = info.Keyword;
            //------Fill GridView --------//
            gvAuthors.DataSource = info.Authors;
            DataBind();
            //
            gvReferees.DataSource = info.Referees;
            DataBind();
            //-----------Files------------//
            QuestionInfoMan_Business questionInfoMan = new QuestionInfoMan_Business();
            List<EvaluationForm> list = questionInfoMan.GetEvaluationForms();
            for (int i = 0; i < list.Count; i++)
            {
                ddlEvaluationForm.Items.Add(new ListItem(list[i].Title, list[i].ID.ToString()));
            }
        }

    }
    protected void btnAcceptByChefEditor_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.AcceptByChefEditor(paperID, Convert.ToInt32(ddlEvaluationForm.SelectedValue));
        FillInfo();
        ShowNotify(dbm);
    }

    protected void btnRejectByChefEditor_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.RejectByChefEditor(paperID);
        ShowNotify(dbm);
    }

    protected void btnAcceptArbitration_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.AcceptByReferee(paperID);
        FillInfo();
        ShowNotify(dbm);
    }

    protected void btnRejectArbitrationArticle_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.RejectByReferee(paperID);
        FillInfo();
        ShowNotify(dbm);
    }

    protected void btnSelectEditor_Click(object sender, EventArgs e)
    {
        // in ghesmat dar handler PaperInfoEditorSelection anjam shod

        //int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        //PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        //DBmessage dbm = paperInfoMan.SelectEditor(paperID, Convert.ToInt32(ddlEditors.SelectedValue));
        //FillInfo();
        //ShowNotify(dbm);
    }

    protected void btnEvaluation_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        Response.Redirect(ServerDirectory.Paper + "/Evaluation.aspx?" + RequestMSG.PaperID + "=" + paperID);
    }


    protected void lnkbDelete_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        LinkButton lnkb = (LinkButton)sender;
        int refereeID = 0;
        if (lnkb != null)
            refereeID = Convert.ToInt32(lnkb.CommandArgument);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.RemoveReferee(paperID, refereeID);
        ShowNotify(dbm);
        FillInfo();
    }

    protected void btnRevise_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage msg = paperInfoMan.ReviseByEditor(paperID, txtbReviseComment.InnerText);
        ShowNotify(msg);
    }
    protected void btnRefereesOpinion_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        Response.Redirect(ServerDirectory.Paper + "/RefereesOpinion.aspx?" + RequestMSG.PaperID + "=" + paperID);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //HttpPostedFile pofPDF = fuPDF.PostedFile;
        //HttpPostedFile pofDOC = fuDOC.PostedFile;
        //HttpPostedFile pofFigure = fuFigures.PostedFile;
        //HttpPostedFile TableOfContent = fuTable.PostedFile;
        //string Comment = txtbComment.Text;
        ////
        //int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        //PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        //DBmessage dbm = paperInfoMan.ReviseByAuthor(paperID, pofPDF, pofDOC, pofFigure, TableOfContent);
        //ShowNotify(dbm);
        //FillInfo();
    }

    protected void btnReviseByAuthor_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        Response.Redirect(ServerDirectory.Paper + "/ReviseByAuthor.aspx?" + RequestMSG.PaperID + "=" + paperID);
    }

    protected void btnFinalApproval_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.ID]);
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        DBmessage dbm = paperInfoMan.TechnicalApproval(paperID);
        ShowNotify(dbm);
        FillInfo();
    }
}



