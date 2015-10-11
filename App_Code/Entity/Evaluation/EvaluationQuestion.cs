using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for EvaluationQuestion
/// </summary>

public abstract class EvaluationQuestion
{
    #region Attribute
    int _id;
    string _title;
    
    private PersianDateTime _date;
    EvaluationQuestionType _type;
   // PaperProcedures _procedur;
    User_cls _createby;
    #endregion

    #region Property
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    /// <summary>
    /// matne soal
    /// </summary>
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public EvaluationQuestionType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    //public PaperProcedures Procedur
    //{
    //    get { return _procedur; }
    //    set { _procedur = value; }
    //}
    public User_cls Createby
    {
        get { return _createby; }
        set { _createby = value; }
    }
    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    #endregion
    

}
public class EvaluationQuestionType
{
    Int16 _id;
    string _title;

    public string Title
    {
        get { return _title; }
       
    }
    public Int16 ID
    {
        get { return _id; }
        set
        {
            _title = EvaluationQuestionType.Convet(value);
            _id = value;
        }
    }

    public EvaluationQuestionType(Int16 id)
    {
        this.ID = id;
    }
    #region Static member
    /// <summary>
    /// soal chand gozine ee 
    /// </summary>
    public static int Options
    {
        get { return 1; }
    }
    /// <summary>
    /// soale tashrihi
    /// </summary>
    public static int Comment
    {
        get { return 2; }
    }
    /// <summary>
    /// soalee ke bayad nomre dahad
    /// </summary>
    public static int Numeric
    {
        get { return 3; }
    }
    public static string Convet(int id)
    {
        switch (id)
        {
            case 1:
                return "Option";
            case 2:
                return "Comment";
            case 3:
                return "Numeric";
            default:
                throw new Exception("invalid EvaluationQuestionType id");
        }
    }
    #endregion
}
public class QuestionTable : DataTable
{
    public QuestionTable()
    {
        this.Columns.Add("ID");
        this.Columns.Add("Title");
        this.Columns.Add("Type");
        this.Columns.Add("CreateBy");
        this.Columns.Add("Date");
        this.Columns.Add("EvaluationFormID");
    }
    public void Add(int id , string title , Int16 type , int createBy , PersianDateTime date
        ,int evaluationFormID)
    {
        object obj_id = null;
        if (id != 0)
            obj_id = id;
        //
        object obj_type = null;
        if (type != 0)
            obj_type = type;
        //
        object obj_createBy = null;
        if (createBy != 0)
            obj_createBy = createBy;
        //
        object obj_date = null;
        if (date != null)
            obj_date = date.Datetime;
        //
        object obj_evaluationFromID = null;
        if (evaluationFormID != 0)
            obj_evaluationFromID = evaluationFormID;
        //
        this.Rows.Add(obj_id,
            title == string.Empty ? null : title,
            obj_type,
            obj_createBy,
            obj_date,
            obj_evaluationFromID);
    }
}
public class QuestionOptionTable : DataTable
{
    public QuestionOptionTable()
    {
        this.Columns.Add("ID");
        this.Columns.Add("Title");
        this.Columns.Add("QuestionID");
        this.Columns.Add("CreateBy");
        this.Columns.Add("Date");
    }
    public void Add(int id, string title , int questionID, int createBy , PersianDateTime date)
    {
        object obj_id = null;
        if (id != 0)
            obj_id = id;
        //
        object obj_questionID = null;
        if (questionID != 0)
            obj_questionID = questionID;
        //
        object obj_createBy = null;
        if (createBy != 0)
            obj_createBy = createBy;
        //
        object obj_date = null;
        if (date != null)
            obj_date = date.Datetime;
        //
        this.Rows.Add(obj_id,
            title == string.Empty ? null : title,
            obj_questionID,
            obj_createBy,
            obj_date);
    }
}
public class QuestionEvaluation_Message
{
    public static string OnlySelectOneItem
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "For multiple choice questions, only one option is selected";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "برای سوال چند گزینه ای فقط باید یک گزینه انتخاب شود";
            return "";
        }
    }
    public static string ScoreNotInRange
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Score is not set in the range";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "امتیاز در بازه تعیین شده نیست";
            return "";
        }
    }
    public static string SuchAnOptionIsNotAvailable
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Such an option is not available in replies";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "چنین گزینه ای در پاسخ ها موجود نیست";
            return "";
        }
    }
    public static string EmptyOrNullTitle
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Title can not be null or empty";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عنوان نمی تواند خالی باشد";
            return "";
        }
    }
    public static string OneOfAnswersIsEmpty
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "No option was not selected for one of the questions";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "برای یکی از سوالات هیچ گزینه ای انتخاب نشد";
            return "";
        }
    }
}