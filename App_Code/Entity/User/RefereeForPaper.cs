using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// faghat paper proceduri ke davare anha yeki hast bayad be in class add shavad
/// </summary>
public class RefereeForPaper : Referee
{
    #region Atriibute
    List<PaperProcedures> _paperprocedures;
    PaperInfo _paperinfo;
    #endregion
    public PaperStatus Status
    {
        get
        {
            if (this.LastSelectorVersion.HasValue && this.LastSelectorVersion.Value == _paperinfo.LastVersion)
                return new PaperStatus(PaperStatus.InOlderVersion_FakeStatus);
                
            //PaperStatus tempStatus;
            //foreach (PaperProcedures item in this._paperprocedures)
            //{
            //    if (item.Status.ID == PaperStatus.AcceptByReferee)
            //        tempStatus= item.Status;
            //    if (item.Status.ID == PaperStatus.RejectByReferee)
            //        tempStatus = item.Status;
            //    if (item.Status.ID == PaperStatus.RemoveReferee)
            //        tempStatus = item.Status;
            //}

            //return new PaperStatus(PaperStatus.SelectRefree);
            return PaperProcedures[PaperProcedures.Count - 1].Status;
        }
    }
    /// <summary>
    /// editori ke akharin bar in davar ra entekhab kard
    /// </summary>
    public Editor LastSelector
    {
        get
        {
            Editor editor = new Editor();
            PaperProcedures procedure = LastSelectorProcedure;
            if (procedure != null)
            {
                editor.User = procedure.Creator;
                return editor;
            }
            return null;
        }

    }
    /// <summary>
    /// akharin version ra bazgasht midahad 
    /// </summary>
    public int? LastSelectorVersion
    {
        get
        {
            PaperProcedures procedure = LastSelectorProcedure;
            if (procedure != null)
                return procedure.Version;
            return null;
        }

    }
    /// <summary>
    /// akharin paperprocedure ee ke in davar dar an entekhab shod
    /// </summary>
    public PaperProcedures LastSelectorProcedure
    {
        get
        {
            PaperProcedures procedure = this.PaperProcedures.FindLast(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.SelectRefree) return true; return false; });
            return procedure;
        }

    }
    public bool CanBeRemoveReferee
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.Editor])
                return false;
            if (_paperinfo.Procedure[_paperinfo.Procedure.Count - 1].Version != this.PaperProcedures[this.PaperProcedures.Count - 1].Version)
                return false;
            if (PaperProcedures[PaperProcedures.Count - 1].Status.ID != PaperStatus.RemoveReferee)
                return true;
            return false;
        }
    }

    public bool CanBeEvaluatByReferee
    {
        get
        {
            if (!this._paperinfo.RoleForThis[RoleType.Referee])
                return false;
            if (_paperinfo.Procedure[_paperinfo.Procedure.Count - 1].Version != this.PaperProcedures[this.PaperProcedures.Count - 1].Version)
                return false;
            if (this.Status.ID == PaperStatus.AcceptByReferee)
                return true;
            if (this._paperinfo.IsRejectByEditor)
                return false;
            return false;
        }
    }
    public bool CanBeAcceptByReferee
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.Referee])
                return false;
            PaperProcedures proc = this.PaperProcedures[this.PaperProcedures.Count - 1];
            if (_paperinfo.Procedure[_paperinfo.Procedure.Count - 1].Version != proc.Version)
                return false;
            if (proc.Status.ID == PaperStatus.SelectRefree)
                return true;
            return false;
        }
    }
    public bool CanBeRejectByReferee
    {
        get
        {
            if (!this._paperinfo.RoleForThis[RoleType.Referee])
                return false;
            PaperProcedures proc = this.PaperProcedures[this.PaperProcedures.Count - 1];
            if (_paperinfo.Procedure[_paperinfo.Procedure.Count - 1].Version != proc.Version)
                return false;
            if (proc.Status.ID == PaperStatus.SelectRefree || proc.Status.ID == PaperStatus.AcceptByReferee)
                return true;
            return false;
        }
    }
    public bool CanBeSeeEvaluate
    {
        get
        {

            if (this.IsRemoved)
                return false;
            return true;
        }
    }
    public List<PaperProcedures> PaperProcedures
    {
        get
        {
            return this._paperprocedures;
        }
    }
    public bool IsRemoved
    {
        get
        {
            if (this.PaperProcedures[this.PaperProcedures.Count - 1].Status.ID == PaperStatus.RemoveReferee)
                return true;
            return false;
        }
    }
    public RefereeForPaper(PaperInfo info)
    {
        this._paperinfo = info;
        this._paperprocedures = new List<PaperProcedures>();
    }
    public void Add(PaperProcedures proc)
    {
        this._paperprocedures.Add(proc);
        if (this._paperprocedures.Count == 1)
        {
            if (proc.Status.ID == PaperStatus.SelectRefree)

                this.User = proc.Another;
            else
                this.User = proc.Creator;
        }

    }




}