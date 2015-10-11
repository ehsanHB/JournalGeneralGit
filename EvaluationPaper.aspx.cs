using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EvaluationPaper : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ChefEditorVerification();
    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {

        string txtbDescriptiveQuestionTitle = "";
        string txtbAnswerTitle = "";

        string txtbNumQuestionTitle = "";
        string txtbMin = "";
        string txtbMax = "";

        string txtbOptionalQuestionTitle = "";
        string txtbOptions = "";
        string[] Options;
        //
        Multiple_ChoiceQuestions multiChoice = null;
        NumericQuestion numeric = null;
        WrittenQuestions written = null;
        QuestionInfoMan_Business business = new QuestionInfoMan_Business();
        EvaluationForm evaluationForm = new EvaluationForm();
        evaluationForm.Title = txtbEvaTitle.Text;
        //
        for (int i = 0; i < 100; i++)
        {
            txtbDescriptiveQuestionTitle = Request.Form["txtbDescriptiveQuestionTitle" + (i + 1)];
            txtbAnswerTitle = Request.Form["txtbAnswerTitle" + (i + 1)];

            txtbNumQuestionTitle = Request.Form["txtbNumQuestionTitle" + (i + 1)];
            txtbMin = Request.Form["txtbMinScore" + (i + 1)];
            txtbMax = Request.Form["txtbmaxScore" + (i + 1)];

            txtbOptionalQuestionTitle = Request.Form["txtbOptionalQuestionTitle" + (i + 1)];
            txtbOptions = Request.Form["txtbOptions" + (i + 1)];
            //

            if (txtbDescriptiveQuestionTitle != null && txtbAnswerTitle != null && txtbDescriptiveQuestionTitle != string.Empty && txtbAnswerTitle != string.Empty)
            {
                written = new WrittenQuestions();
                written.Title = txtbDescriptiveQuestionTitle;
                written.AnswerTilte = txtbAnswerTitle;
                evaluationForm.Add(written);
            }
            else if (txtbNumQuestionTitle != null && txtbMin != null && txtbMax != null && txtbNumQuestionTitle != string.Empty && txtbMin != string.Empty && txtbMax != string.Empty)
            {
                numeric = new NumericQuestion();
                numeric.Title = txtbNumQuestionTitle;
                numeric.Min = float.Parse(txtbMin);
                numeric.Max = float.Parse(txtbMax);
                evaluationForm.Add(numeric);
            }
            else if (txtbOptionalQuestionTitle != null && txtbOptions != null && txtbOptionalQuestionTitle != string.Empty && txtbOptions != string.Empty)
            {
                multiChoice = new Multiple_ChoiceQuestions();
                multiChoice.Title = txtbOptionalQuestionTitle;
                Options = txtbOptions.Split(';');
                for (int j = 0; j < Options.Length; j++)
                {
                    multiChoice.Add(new AnswerOption() { Title = Options[j] });
                }
                evaluationForm.Add(multiChoice);
            }
            else
            {
                break;
            }
        }
        DBmessage dbm = business.RegisterEvaluationForm(txtbEvaTitle.Text, evaluationForm);
        ShowNotify(dbm);
    }
}