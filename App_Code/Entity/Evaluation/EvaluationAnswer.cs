using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EvaluationAnswer
{

    int _id;
    string _title;
    private User_cls _createBy;
    private PersianDateTime _date;
    private EvaluationQuestion _parentQuestion;

    public EvaluationQuestion ParentQuestion
    {
        get { return _parentQuestion; }
        set { _parentQuestion = value; }
    }

    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    public User_cls CreatBy
    {
        get { return _createBy; }
        set { _createBy = value; }
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    

    public EvaluationAnswer(EvaluationQuestion EQ)
    {
        ParentQuestion = EQ;
    }
}
