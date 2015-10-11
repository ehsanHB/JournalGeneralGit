using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// list pardazesh shode chandin maghale ra namayesh midahad. ke har paperprocedure baraye yek maghale ast
/// </summary>
public class PaperReport
{
    #region VALUES

    private List<PaperProcedures> _paperProceduresList;
    private List<PaperInfo> _paper;
    #endregion

    #region PROPERTY

    private List<PaperProcedures> PaperProceduresList
    {
        get { return _paperProceduresList; }
        set
        {

            value.Sort(
             delegate(PaperProcedures p1, PaperProcedures p2)
             {
                 int compareResult = 0;

                 if (p1.Paper.ID > p2.Paper.ID)
                     compareResult = -1;
                 else if (p1.Paper.ID < p2.Paper.ID)
                     compareResult = 1;
                 else if (p1.Paper.ID == p2.Paper.ID && p1.Date!=null && p2.Date!=null)
                 {
                     compareResult = DateTime.Compare(p1.Date.Datetime, p2.Date.Datetime);
                     if(p1.Date.Datetime==p2.Date.Datetime)
                     {
                         if (p1.ID > p2.ID)
                         {
                             compareResult = -1;
                         }
                         else if (p1.ID < p2.ID)
                         {
                             compareResult = 1;
                         }
                     }
                 }
                 
                 return compareResult;
             }
             );
            _paperProceduresList = value;
        }
    }
  
    /// <summary>
    /// maghalati ke dar in report vojod darad
    /// </summary>
    public List<PaperInfo> Papers
    {
        get { return _paper; }
    }
    #endregion


    public PaperReport(List<PaperProcedures> paperprocedureslist, List<PaperWriter> authors, List<PaperProposedReferee> proposedReferee)
    {
        _paper = new List<PaperInfo>();
        this.PaperProceduresList = paperprocedureslist;
        if (this.PaperProceduresList == null || this.PaperProceduresList.Count == 0)
            return;
        int currentpaperid = -1;
        int paperindex = -1;
        foreach (PaperProcedures item in this.PaperProceduresList)
        {
            if (item.Paper.ID != currentpaperid)
            {
                _paper.Add(new PaperInfo());
                paperindex++;
            }

            _paper[paperindex].Add(item);
            currentpaperid = item.Paper.ID;
        }
        _paper[paperindex]._proposedReferee = proposedReferee;
        _paper[paperindex]._authors = authors;

    }
    public PaperReport(List<PaperProcedures> paperprocedureslist)
    {
        _paper = new List<PaperInfo>();
        this.PaperProceduresList = paperprocedureslist;
        if (this.PaperProceduresList == null || this.PaperProceduresList.Count == 0)
            return;
        int currentpaperid = -1;
        int paperindex = -1;
        foreach (PaperProcedures item in this.PaperProceduresList)
        {
            if (item.Paper.ID != currentpaperid)
            {
                _paper.Add(new PaperInfo());
                paperindex++;
            }

            _paper[paperindex].Add(item);
            currentpaperid = item.Paper.ID;
        }

    }
}