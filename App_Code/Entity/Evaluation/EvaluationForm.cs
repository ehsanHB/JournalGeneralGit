using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// yek class baraye zakhire har form arzyabi
/// </summary>
public class EvaluationForm : DBMan
{
    List<EvaluationQuestion> _questions;
    User_cls _createBy;
    PersianDateTime _date;
    string _title;
    int _id;
    PaperProcedures _paperprosedur;
    Referee _refereeevaluator;
    /// <summary>
    /// davari ke in form arzyabi ra nomre dehi kard
    /// </summary>
    public Referee RefereeEvaluator
    {
        get { return _refereeevaluator; }
        set { _refereeevaluator = value; }
    }
    public PaperProcedures Paperprosedur
    {
        get { return _paperprosedur; }
        set { _paperprosedur = value; }
    }
    public void Add(EvaluationQuestion evaluation)
    {
        _questions.Add(evaluation);
    }


    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Title
    {
        get
        {
            return this._title;
        }
        set
        {
            if (value == null || value == string.Empty)
                throw new MyException(QuestionEvaluation_Message.EmptyOrNullTitle, 101, "");
            value = value.Trim();
            _title = value;
        }
    }
    public User_cls CreateBy
    {
        get
        {
            return _createBy;
        }
        set
        {
            _createBy = value;
        }
    }
    public PersianDateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            _date = value;
        }
    }
    /// <summary>
    /// bazgasht tedade List<EvaluationQuestion>
    /// </summary>
    public int Count
    {
        get
        {
            return _questions.Count;
        }
    }
    /// <summary>
    /// neveshtan va khondan soalat mojod dar in form
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public EvaluationQuestion this[int index]
    {
        get { return _questions[index]; }
        set { _questions[index] = value; }
    }
    public EvaluationForm()
    {
        this._questions = new List<EvaluationQuestion>();
    }
    public EvaluationForm(int procedurID, Referee refereeEvaluatedUser)
    {
        this._questions = new List<EvaluationQuestion>();
        this.RefereeEvaluator = new Referee();
        this.RefereeEvaluator = refereeEvaluatedUser;
    }
    #region method
    public DBmessage Register(QuestionTable questionTable, QuestionOptionTable questionOptionTable)
    {
        conn = new System.Data.SqlClient.SqlConnection(Jurnaldb);
        cmd = new System.Data.SqlClient.SqlCommand("[EvaluationFormRegister]", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //
        SqlParameter _evaluationFormName = new SqlParameter("@EvaluationFormName", SqlDbType.NVarChar, 100);
        if (this.Title == null)
            _evaluationFormName.Value = DBNull.Value;
        else
            _evaluationFormName.Value = this.Title;
        //
        SqlParameter _questions = new SqlParameter("@Questions", SqlDbType.Structured);
        if (questionTable == null)
            _questions.Value = DBNull.Value;
        else
            _questions.Value = questionTable;
        //
        SqlParameter _options = new SqlParameter("@Options", SqlDbType.Structured);
        if (questionOptionTable == null)
            _options.Value = DBNull.Value;
        else
            _options.Value = questionOptionTable;
        //
        cmd.Parameters.Add(_evaluationFormName);
        cmd.Parameters.Add(base.CreateBy);
        cmd.Parameters.Add(_questions);
        cmd.Parameters.Add(_options);
        cmd.Parameters.Add(RetunParam);
        //
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        //
        return ResultMessage = new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    }
    /// <summary>
    /// gereftan list kamel soalat yek form arzyabi
    /// </summary>
    /// <returns></returns>
    public DataTable GetInfo()
    {
        conn = new SqlConnection(Jurnaldb);
        dt = new DataTable();
        da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand("EvaluationQuestionGet", conn);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        ///////////////
        SqlParameter _evalid = new SqlParameter("@EvaluationID", SqlDbType.Int);
        if (this.ID == 0)
            _evalid.Value = DBNull.Value;
        else
            _evalid.Value = this.ID;
        ////////////////
        da.SelectCommand.Parameters.Add(_evalid);
        //
        conn.Open();
        da.Fill(dt);
        conn.Close();
        ////////////
        return dt;

    }
    /// <summary>
    /// list tamami paperEvaluation ha
    /// </summary>
    /// <returns></returns>
    public DataTable Get()
    {
        conn = new SqlConnection(Jurnaldb);
        dt = new DataTable();
        da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand("EvaluationFormGet", conn);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        ///////////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        ////////////
        return dt;
    }
    public DBmessage Register(PaperEvaluationTable list)
    {
        cmd = new SqlCommand("PaperEvaluationRegister", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ////////////////////
        SqlParameter _list = new SqlParameter("@List", SqlDbType.Structured);
        _list.Value = list;
        //////////////////
        cmd.Parameters.Add(_list);
        cmd.Parameters.Add(RetunParam);
        ///////////////
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        ////////////

        return new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    }
    public DataTable GetEvaluationsPaper(int refereeuserid = 0)
    {
        dt = new DataTable();
        cmd = new SqlCommand("EvaluationPaperGet", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        ////////////////
        SqlParameter _paperid = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.Paperprosedur != null && this.Paperprosedur.Paper != null && this.Paperprosedur.Paper.ID == 0)
            _paperid.Value = DBNull.Value;
        else
            _paperid.Value = this.Paperprosedur.Paper.ID;
        SqlParameter _refereeid = new SqlParameter("@RefereeID", SqlDbType.Int);
        if (refereeuserid == 0)
            _refereeid.Value = DBNull.Value;
        else
            _refereeid.Value = refereeuserid;
        ////////////////
        cmd.Parameters.Add(_paperid);
        cmd.Parameters.Add(_refereeid);
        /////////////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        /////////////
        return dt;
    }
    #endregion

    #region Static member
    public static EvaluationForm Convert(DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0)
            return null;
        EvaluationForm result = new EvaluationForm();
        result.ID = (int)dt.Rows[0]["EvaluationFormID"];
        int lastqid = 0;
        Int16 type;
        string qtitle;
        int optionid;
        string optiontitle;
        int qid;
        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (!DBNull.Value.Equals(dt.Rows[i]["QuestionID"]))
            {
                qid = (int)dt.Rows[i]["QuestionID"];

                if (!DBNull.Value.Equals(dt.Rows[i]["QuestonTitle"]))
                    qtitle = dt.Rows[i]["QuestonTitle"].ToString();
                else
                    qtitle = string.Empty;
                type = (Int16)dt.Rows[i]["QuestionType"];
                if (type == EvaluationQuestionType.Comment)
                {
                    if (!DBNull.Value.Equals(dt.Rows[i]["OptionID"]))
                        optionid = (int)dt.Rows[i]["OptionID"];
                    else
                        optionid = 0;
                    if (!DBNull.Value.Equals(dt.Rows[i]["OptionTitle"]))
                        optiontitle = dt.Rows[i]["OptionTitle"].ToString();
                    else
                        optiontitle = string.Empty;
                    result.Add(new WrittenQuestions() { ID = qid, Title = qtitle, AnswerTilte = optiontitle, Type = new EvaluationQuestionType(type) });
                }
                else if (type == EvaluationQuestionType.Numeric)
                {
                    if (!DBNull.Value.Equals(dt.Rows[i]["OptionID"]))
                        optionid = (int)dt.Rows[i]["OptionID"];
                    else
                        optionid = 0;
                    if (!DBNull.Value.Equals(dt.Rows[i]["OptionTitle"]))
                        optiontitle = dt.Rows[i]["OptionTitle"].ToString();
                    else
                        optiontitle = string.Empty;
                    i++;
                    result.Add(new NumericQuestion() { ID = qid, Title = qtitle, Type = new EvaluationQuestionType(type), Min = float.Parse(optiontitle), Max = float.Parse(dt.Rows[i]["OptionTitle"].ToString()) });
                }
                else if (type == EvaluationQuestionType.Options)
                {
                    result.Add(new Multiple_ChoiceQuestions() { ID = qid, Title = qtitle });
                    while (i < dt.Rows.Count && lastqid != (int)dt.Rows[i]["QuestionID"])
                    {
                        if (!DBNull.Value.Equals(dt.Rows[i]["OptionID"]))
                            optionid = (int)dt.Rows[i]["OptionID"];
                        else
                            optionid = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["OptionTitle"]))
                            optiontitle = dt.Rows[i]["OptionTitle"].ToString();
                        else
                            optiontitle = string.Empty;
                        ((Multiple_ChoiceQuestions)result[result.Count - 1]).Add(new AnswerOption() { ID = optionid, Title = optiontitle });
                        i++;
                    }
                    i--;
                }
                lastqid = result[result.Count-1].ID;
            }
        }
        return result;
    }
    #endregion

    

 
}
public class PaperEvaluationTable : DataTable
{
    public PaperEvaluationTable()
    {
        this.Columns.Add("QuestionID");
        this.Columns.Add("AnswerID");
        this.Columns.Add("Comment");
        this.Columns.Add("ProcID");
        this.Columns.Add("CreateBy");
        this.Columns.Add("PaperID");
        this.Columns.Add("Date");
    }
    public void Add(int QuestionID, int AnswerID, string Comment, int ProcID, int paperid, int CreateBy)
    {
        this.Rows.Add(QuestionID, AnswerID, Comment, ProcID, paperid, CreateBy);
    }
    public static PaperEvaluationTable Convert(EvaluationForm evaluation)
    {
        PaperEvaluationTable result = new PaperEvaluationTable();
        int qid=0;
        int aid=0;
        string comment=string.Empty;
        int procid=evaluation.Paperprosedur.ID;
        int paperid = evaluation.Paperprosedur.Paper.ID;
        for (int i = 0; i < evaluation.Count;i++ )
        {
            qid = evaluation[i].ID;
            if(evaluation[i] is NumericQuestion)
            {
                aid = 0;
                comment = ((NumericQuestion)evaluation[i]).Score.ToString();
            }
            else if(evaluation[i] is WrittenQuestions)
            {
                aid = 0;
                comment = ((WrittenQuestions)evaluation[i]).Answertext;

            }
            else if(evaluation[i] is Multiple_ChoiceQuestions )
            {
                if(((Multiple_ChoiceQuestions)evaluation[i]).SelectedOption==null)
                    throw new MyException(QuestionEvaluation_Message.OneOfAnswersIsEmpty, 101,"" );
                aid = ((Multiple_ChoiceQuestions)evaluation[i]).SelectedOption.ID;
                comment = string.Empty;
            }
            result.Add(qid, aid, comment, procid, paperid, SysProperty.Client.UserID);
        }
        return result;
    }
}