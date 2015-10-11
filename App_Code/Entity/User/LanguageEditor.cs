using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GrammerEditor
/// </summary>
public class LanguageEditor:User_cls
{
    #region Atriibute
    List<PaperProcedures> _paperprocedures;
    PaperInfo _paperinfo;
    #endregion
    public LanguageEditor(PaperInfo info)
    {
        this._paperinfo = info;
        this._paperprocedures = new List<PaperProcedures>();
    }
    public virtual void Add(PaperProcedures proc)
    {
        this._paperprocedures.Add(proc);
       
        //if (this._paperprocedures.Count == 1)// agar avalin procedure in editor bod pas hanoz user an drost nashode va bayad user ra ezafe konad
        //{
        //    if (proc.Status.ID == PaperStatus.SelectLanguegEditor)
        //    {
        //        this.FullName = proc.Another.FullName;
        //        this.UserID = proc.Another.UserID;
        //    }
        //    else
        //    {
        //        this.FullName = proc.Creator.FullName;
        //        this.UserID = proc.Creator.UserID;
        //    }
        //}
    }
    public PaperStatus Status
    {
        get
        {
            return _paperprocedures[_paperprocedures.Count - 1].Status;
        }
    }
}