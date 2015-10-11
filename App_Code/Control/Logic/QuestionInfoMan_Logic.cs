using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace LogicLayer
{
    /// <summary>
    /// Summary description for QuestionInfoMan_Logic
    /// </summary>
    public class QuestionInfoMan_Logic
    {
        public EvaluationForm GetEvaluationForm(int id)
        {
            EvaluationForm evaluationForm = new EvaluationForm();
            evaluationForm.ID = id;
            DataTable dt = evaluationForm.GetInfo();
            return EvaluationForm.Convert(dt);
        }
        public List<EvaluationForm> GetEvaluationForms()
        {
            EvaluationForm evalForm = new EvaluationForm();
            DataTable dt = evalForm.Get();
            return ConvertToListEvaluationForm(dt);
        }
        public List<EvaluationForm> GetPaperEvaluation(int paperid, int refereeid)
        {

            EvaluationForm evaluation = new EvaluationForm();
            evaluation.Paperprosedur = new PaperProcedures() { Paper = new Paper() { ID = paperid } };
            DataTable dt = evaluation.GetEvaluationsPaper(refereeid);
            List<EvaluationForm> result = new List<EvaluationForm>();
            int resultindex = -1;
            int lastprocid = 0;
            int lastquestionid = 0;
            int questionindex = -1;


            Int16 type = -1;
            int procid = -1;
            string qtitle = string.Empty;
            int qid = -1;
            string comment = string.Empty;
            int aid = 0;
            string atitle = string.Empty;
            foreach (DataRow row in dt.Rows)
            {

                type = System.Convert.ToInt16(row["QuestionType"]);
                procid = Convert.ToInt32(row["ProcID"]);
                qtitle = row["QuestionTitle"].ToString();
                qid = Convert.ToInt32(row["QuestionID"]);
                if (!DBNull.Value.Equals(row["Comment"]))
                    comment = row["Comment"].ToString();
                else
                    comment = string.Empty;
                if (!DBNull.Value.Equals(row["AnswerID"]))
                    aid = Convert.ToInt32(row["AnswerID"]);
                else
                    aid = 0;
                if (!DBNull.Value.Equals(row["AnswerTitle"]))
                    atitle = row["AnswerTitle"].ToString();
                else
                    atitle = "";

                if (procid != lastprocid)// yani form arzyabi avaz shode
                {

                    result.Add(new EvaluationForm(procid, new Referee() { User = new User_cls() { UserID = Convert.ToInt32(row["CreateBy"]), FullName = row["CreatorFullName"].ToString() } }));
                    resultindex++;
                    questionindex = -1;
                    lastprocid = procid;
                }
                if (type == EvaluationQuestionType.Comment)
                {
                    result[resultindex].Add(new WrittenQuestions() { Answertext = comment });
                    questionindex++;
                }
                else if (type == EvaluationQuestionType.Numeric)
                {
                    result[resultindex].Add(new NumericQuestion() { Score = float.Parse(comment) });
                    questionindex++;
                }
                else if (type == EvaluationQuestionType.Options)
                {
                    result[resultindex].Add(new Multiple_ChoiceQuestions());
                    questionindex++;
                    ((Multiple_ChoiceQuestions)result[resultindex][questionindex]).Add(new AnswerOption() { ID = aid, IsSelected = true, Title = atitle });
                }
                result[resultindex][questionindex].Date = new PersianDateTime(Convert.ToDateTime(row["Date"]));
                result[resultindex][questionindex].ID = qid;
                result[resultindex][questionindex].Title = qtitle;
                result[resultindex][questionindex].Type = new EvaluationQuestionType(type);

            }
            return result;
        }
        #region Static members
        public static List<EvaluationForm> ConvertToListEvaluationForm(DataTable dt)
        {
            EvaluationForm eval = null;
            List<EvaluationForm> list = new List<EvaluationForm>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                eval = new EvaluationForm();
                if (!DBNull.Value.Equals(dt.Rows[i]["ID"]))
                {
                    eval.ID = System.Convert.ToInt32(dt.Rows[i]["ID"]);
                }
                if (!DBNull.Value.Equals(dt.Rows[i]["Title"]))
                {
                    eval.Title = dt.Rows[i]["Title"].ToString();
                }
                if (!DBNull.Value.Equals(dt.Rows[i]["Date"]))
                {
                    eval.Date = new PersianDateTime(Convert.ToDateTime(dt.Rows[i]["Date"]));
                }
                if (!DBNull.Value.Equals(dt.Rows[i]["CreateBy"]))
                {
                    eval.CreateBy = new User_cls();
                    eval.CreateBy.UserID = System.Convert.ToInt32(dt.Rows[i]["CreateBy"]);
                }
                list.Add(eval);
            }
            return list;
        }
        #endregion
    }
}