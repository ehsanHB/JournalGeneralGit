using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// objecti ke soalat chand gozine ee dar un gharar migirad
/// </summary>
public class Multiple_ChoiceQuestions : EvaluationQuestion
{

    List<AnswerOption> _options;

    /// <summary>
    /// gereftan ya neveshtan list gozine haye in soal
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public AnswerOption this[int index]
    {
        get
        {
            return _options[index];
        }
        set
        {
            _options[index] = value;
        }
    }
    /// <summary>
    /// bazgasht tedade gozine haye in soal
    /// </summary>
    public int Count
    {
        get
        {
            return _options.Count;
        }
    }
    public Multiple_ChoiceQuestions()
    {
        _options = new List<AnswerOption>();
    }
    public void Add(AnswerOption answerOption)
    {
        _options.Add(answerOption);
    }
    /// <summary>
    /// gozine ee ke select shode ast ra bar migardanad
    /// </summary>
    public AnswerOption SelectedOption
    {
        get
        {
            List<AnswerOption> results = this._options.FindAll(delegate (AnswerOption a) { if (a.IsSelected) return true; return false; });
            if (results == null)
                return null;
            if (results.Count > 1)
                throw new MyException(QuestionEvaluation_Message.OnlySelectOneItem, 101, "");
            return results[0];
        }
    }
    public bool SelectAnswerItem(int id)
    {
        if (this._options == null)
            return false;
        AnswerOption answer = this._options.Find(delegate (AnswerOption a) { if (a.ID == id) return true; return false; });
        if (answer == null)
            return false;
        answer.IsSelected = true;
        return true;
    }
}
public class AnswerOption
{
    int _id;
    string _title;
    bool _isSelected = false;


    /// <summary>
    /// inke aya entekhab shode ya kheyr
    /// </summary>
    public bool IsSelected
    {
        get { return _isSelected; }
        set { _isSelected = value; }
    }
    /// <summary>
    /// unvane gozine chist
    /// </summary>
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
}