using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer;
/// <summary>
/// Summary description for QuestionInfoMan_Business
/// </summary>
public class QuestionInfoMan_Business
{
    public EvaluationForm GetEvaluationFormForPaper(int paperID)
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperInfo info = paperInfoMan.GetPaperInfoForReferee(paperID);
        QuestionInfoMan_Logic logic = new QuestionInfoMan_Logic();
        EvaluationForm eval = info.EvaluationForm;
        if (info != null && info.EvaluationForm != null)
            return logic.GetEvaluationForm(info.EvaluationForm.ID);
        return null;
    }
    public List<EvaluationForm> GetEvaluationForms()
    {
        List<EvaluationForm> list = new List<EvaluationForm>();
        if (!SysProperty.Client.Roles[RoleType.CheifEditor])
            return list;
        QuestionInfoMan_Logic logic = new QuestionInfoMan_Logic();
        return logic.GetEvaluationForms();
    }
    public DBmessage RegisterEvaluationForm(string evaluationFormTitle, EvaluationForm evaluationForm)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        Multiple_ChoiceQuestions multiChoice = null;
        NumericQuestion numeric = null;
        WrittenQuestions written = null;
        //
        QuestionTable questionTable = new QuestionTable();
        QuestionOptionTable questionOptionTable = new QuestionOptionTable();
        //
        EvaluationQuestionType questionType = null;
        if (evaluationForm != null)
        {
            evaluationForm.Title = evaluationFormTitle;
            for (int i = 0; i < evaluationForm.Count; i++)
            {
                if (evaluationForm[i] is Multiple_ChoiceQuestions)
                {
                    multiChoice = new Multiple_ChoiceQuestions();
                    multiChoice = (Multiple_ChoiceQuestions)evaluationForm[i];
                    multiChoice.ID = i + 1;
                    for (int j = 0; j < multiChoice.Count; j++)
                    {
                        questionOptionTable.Add(0, multiChoice[j].Title, multiChoice.ID, 0, null);
                    }
                    questionType = new EvaluationQuestionType((Int16)EvaluationQuestionType.Options);
                }
                else if (evaluationForm[i] is NumericQuestion)
                {
                    numeric = new NumericQuestion();
                    numeric = (NumericQuestion)evaluationForm[i];
                    numeric.ID = i + 1;
                    questionOptionTable.Add(0, numeric.Min.ToString(), numeric.ID, 0, null);
                    questionOptionTable.Add(0, numeric.Max.ToString(), numeric.ID, 0, null);
                    questionType = new EvaluationQuestionType((Int16)EvaluationQuestionType.Numeric);
                }
                else if (evaluationForm[i] is WrittenQuestions)
                {
                    written = new WrittenQuestions();
                    written = (WrittenQuestions)evaluationForm[i];
                    written.ID = i + 1;
                    questionOptionTable.Add(0, written.AnswerTilte, written.ID, 0, null);
                    questionType = new EvaluationQuestionType((Int16)EvaluationQuestionType.Comment);

                }
                questionTable.Add(evaluationForm[i].ID, evaluationForm[i].Title, questionType.ID, 0, null, 0);
            }
            EvaluationForm eval = new EvaluationForm();
            eval.Title = evaluationFormTitle;
            return eval.Register(questionTable, questionOptionTable);
        }
        return null;
    }
}