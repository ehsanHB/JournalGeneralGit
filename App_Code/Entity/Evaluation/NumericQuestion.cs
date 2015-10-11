using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// soalati ke bayad nomre dehi shavad dar in object gharar migirad
/// </summary>
public class NumericQuestion : EvaluationQuestion
{
    float _min;
    float _max;
    float _score;


    /// <summary>
    /// hade aksar nomre ee ke mitavanad dahad
    /// </summary>
    public float Max
    {
        get { return _max; }
        set
        {
            if (_min != 0 && value < _min)
                throw new MyException("Max can not bigger than min", 101, "");
            _max = value;
        }
    }
    /// <summary>
    /// hadeaghal nomre
    /// </summary>
    public float Min
    {
        get { return _min; }
        set
        {
            if (_max != 0 && value > _max)
                throw new MyException("Min can not bigger than max", 101, "");
            _min = value;
        }
    }
    /// <summary>
    /// emtiazi karbar dar pasokh be in soal midahad
    /// </summary>
    public float Score
    {
        get { return _score; }
        set
        {
            if (_min != 0 && _max != 0)
                if (_min <= value && value <= _max)
                    _score = value;
                else
                    throw new MyException(QuestionEvaluation_Message.ScoreNotInRange, 101, "");
            _score = value;
        }
    }
    public NumericQuestion()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}