using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WrittenQuestions
/// </summary>
public class WrittenQuestions:EvaluationQuestion
{
    string _answertext;
    string _answerTilte;

   
    /// <summary>
    /// javab karbar be in soal
    /// </summary>
    public string Answertext
    {
        get { return _answertext; }
        set { _answertext = value; }
    }
    /// <summary>
    /// unvane bakhshi ke bayad karbar darash javabe khod ra benviad
    /// </summary>
    public string AnswerTilte
    {
        get { return _answerTilte; }
        set { _answerTilte = value; }
    }
	public WrittenQuestions()
	{
		
	}
}