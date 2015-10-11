using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_Evaluation : FormBase
{
    public EvaluationForm evaluation;
    protected void Page_Load(object sender, EventArgs e)
    {
        RefereeVerification();
        FillInfo();
    }
    public void FillInfo()
    {
        QuestionInfoMan_Business questionInfoMan = new QuestionInfoMan_Business();
        if (Request[RequestMSG.PaperID] != null)
        {
            int paperID = Convert.ToInt32(Request[RequestMSG.PaperID]);
            evaluation = questionInfoMan.GetEvaluationFormForPaper(paperID);
        }
        else
        {
            Response.Redirect(ServerDirectory.Host + "Dashboard.aspx");
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        int paperID = Convert.ToInt32(Request[RequestMSG.PaperID]);
        string[] OptionalQuestionsAnswer = hfOptions.Value.Split(',');
        string[] temp;
        for (int i = 0; i < evaluation.Count; i++)
        {
            if (evaluation[i] is WrittenQuestions)
            {
                WrittenQuestions written = (WrittenQuestions)evaluation[i];
                written.Answertext = Request.Form["writtenAnswer" + i];
            }
            else if (evaluation[i] is NumericQuestion)
            {
                NumericQuestion numeric = (NumericQuestion)evaluation[i];
                numeric.Score = Convert.ToInt32(Request.Form["numericAnswer" + i]);
            }
            else if (evaluation[i] is Multiple_ChoiceQuestions)
            {
                Multiple_ChoiceQuestions optional = (Multiple_ChoiceQuestions)evaluation[i];
                bool ExistOption = false;
                for (int j = 0; j < OptionalQuestionsAnswer.Length; j++)
                {
                    temp = OptionalQuestionsAnswer[j].Split('_');
                    if (temp[0] == i.ToString())
                    {
                        ExistOption = optional.SelectAnswerItem(Convert.ToInt32(temp[1]));
                        if (!ExistOption)
                            throw new MyException(QuestionEvaluation_Message.SuchAnOptionIsNotAvailable, 101, "");
                        ExistOption = false;
                    }
                }
            }
        }
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        List<string> files = new List<string>();
        DBmessage dbm = paperInfoMan.SetPointToPaperByReferee(paperID, files, evaluation);
        if (dbm.Type == DBMessageType.Sucsess)
            Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + paperID);
        else
            ShowNotify(dbm);
    }
}