using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// in class moshakhasate pardazesh shode yek maghale ro dar khod gharar midahad pass hatman bayad list paperprocedures ke dade mishavad male yek paper bashad
/// </summary>
public class PaperInfo : Paper
{
    #region attribute
    List<PaperProcedures> _procedure;
    List<RefereeForPaper> _referee;
    public string _code;
    private Role _roleForThis;
    public List<PaperWriter> _authors;
    public List<PaperProposedReferee> _proposedReferee;
    public LanguageEditors _languageEditors;



    #endregion

    #region Property
    /// <summary>
    /// in karbar bar roye in maghale che naghshi darad
    /// </summary>
    public Role RoleForThis
    {
        get
        {
            if (_roleForThis == null)
            {
                this._roleForThis = new Role(false);
                #region barresi author
                if (this.Owner != null && this.Owner.User != null)
                    if (this.Owner.User.UserID == SysProperty.Client.UserID && SysProperty.Client.Roles[RoleType.Author])
                        this._roleForThis[RoleType.Author] = true;
                #endregion
                #region barresi Editor
                if (SysProperty.Client.Roles[RoleType.Editor] && this.Editors.Find(delegate (Editor e) { if (e.User != null && e.User.UserID == SysProperty.Client.UserID) return true; return false; }) != null)
                    this._roleForThis[RoleType.Editor] = true;
                #endregion
                #region barresi chef editor
                this._roleForThis[RoleType.CheifEditor] = SysProperty.Client.Roles[RoleType.CheifEditor];
                #endregion
                #region barresi Admin
                this._roleForThis[RoleType.Admin] = SysProperty.Client.Roles[RoleType.Admin];
                #endregion
                #region barassi referee
                if (SysProperty.Client.Roles[RoleType.Referee] && this.Referees.Find(delegate (RefereeForPaper r) { if (r.User != null && r.User.UserID == SysClient.Client.UserID) return true; return false; }) != null)
                    this._roleForThis[RoleType.Referee] = true;
                #endregion
                #region barassi language editor
                if (SysProperty.Client.Roles[RoleType.LanguageEditor] && this.LanguageEditors.SelectedLanguageEditors != null && this.LanguageEditors.SelectedLanguageEditors.UserID==SysProperty.Client.UserID)
                    this._roleForThis[RoleType.LanguageEditor] = true;

                #endregion
            }
            return _roleForThis;
        }

    }
    /// <summary>
    /// aya in karbar naghshi dar in maghale darad
    /// </summary>
    public bool HaveAnyRole
    {
        get
        {
            if (this.RoleForThis[RoleType.Author] || this.RoleForThis[RoleType.CheifEditor] || this.RoleForThis[RoleType.Editor] || this.RoleForThis[RoleType.Referee] || this.RoleForThis[RoleType.LanguageEditor] || this.RoleForThis[RoleType.SyntaxEditor])
                return true;
            return false;
        }
    }
    /// <summary>
    /// akharin version in maghale
    /// </summary>
    public int LastVersion
    {
        get
        {
            if (this.Procedure[Procedure.Count - 1].Status.ID == PaperStatus.ReviseByEditor)
                return this.Procedure[Procedure.Count - 1].Version - 1;
            return this.Procedure[Procedure.Count - 1].Version;
        }
    }
    /// <summary>
    /// list editor haye in maghale
    /// </summary>
    public List<Editor> Editors
    {
        get
        {
            List<PaperProcedures> editorproc = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.SelectEditor) return true; return false; });
            List<Editor> result = new List<Editor>();
            foreach (PaperProcedures item in editorproc)
            {
                result.Add(new Editor() { User = item.Another });
            }
            return result;
        }
    }
    public List<PaperProcedures> Procedure
    {
        get { return _procedure; }

    }
    public LanguageEditors LanguageEditors
    {
        get
        {
            return _languageEditors;
        }
    }
    public string Code
    {
        get
        {
            if (this._code == null || this._code == string.Empty)
            {
                if (this.Status.ID < 6)
                    _code = SysProperty.InterimCodePaper + this.ID;
                else
                    _code = SysProperty.PermanentCodePaper + this.ID;
            }
            return this._code;
        }
    }
    public PaperStatus Status
    {
        get
        {
            PaperStatus result = this.Procedure[this.Procedure.Count - 1].Status;
            if (result.ID == PaperStatus.SelectRefree)
                return new PaperStatus(PaperStatus.InEvaluating_FakeStatus);
            else if (result.ID == PaperStatus.RejectByReferee)
                return new PaperStatus(PaperStatus.InEvaluating_FakeStatus);
            else if (result.ID == PaperStatus.AcceptByReferee)
                return new PaperStatus(PaperStatus.InEvaluating_FakeStatus);
            else if (result.ID == PaperStatus.RemoveReferee)
                return new PaperStatus(PaperStatus.InEvaluating_FakeStatus);
            else if (result.ID == PaperStatus.EvaluatedByReferee)
                return new PaperStatus(PaperStatus.InEvaluating_FakeStatus);
            else
                return result;
        }
    }
    public PaperStatus StatusForReferee
    {
        get
        {
            RefereeForPaper findreferee = this.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == SysProperty.Client.UserID) return true; return false; });
            if (findreferee == null)
                return null;
            return findreferee.PaperProcedures[findreferee.PaperProcedures.Count - 1].Status;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public List<RefereeForPaper> Referees
    {
        get
        {
            return _referee;
        }
    }
    /// <summary>
    /// davarani ke entekhab shodand va taeed kardand
    /// </summary>
    public List<Referee> Referees_Accept
    {
        get
        {
            return null;
        }
    }
    /// <summary>
    /// davarani ke entekhab shodand va taeed kardand 
    /// </summary>
    public List<Referee> Referees_Reject
    {
        get
        {
            return null;
        }
    }
    EvaluationForm _evaluationform;
    /// <summary>
    /// form arzyabi ee ke bayad baraye in maghale estefade shavad
    /// </summary>
    public EvaluationForm EvaluationForm
    {
        get
        {
            if (_evaluationform == null)
            {

                PaperProcedures temp = this.Procedure.Find(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.AcceptByChefEditor) return true; return false; });
                if (temp == null || temp.Another == null)
                    return null;
                _evaluationform = new EvaluationForm() { ID = temp.Another.UserID };
            }
            return _evaluationform;
        }
        set
        {
            _evaluationform = value;
        }
    }
    /// <summary>
    /// aya in karbar mitavanad in maghale ra acceptbyadmin konad?
    /// </summary>
    public bool CanBeAcceptByChefEditor
    {
        get
        {
            if (!this.RoleForThis[RoleType.CheifEditor])
                return false;
            if (this.Procedure[this.Procedure.Count - 1].Status.ID == PaperStatus.New || this.Procedure[this.Procedure.Count - 1].Status.ID == PaperStatus.RejectByChefEditor)
                return true;
            return false;
        }
    }
    /// <summary>
    /// aya karbar mitavanad in maghale ra rejectByadmin konad?
    /// </summary>
    public bool CanBeRejectByChefEditor
    {
        get
        {
            if (!this.RoleForThis[RoleType.CheifEditor] && !this.RoleForThis[RoleType.Editor])
                return false;
            if (this.IsTechnicalApproval)
                return false;
            if (!this.IsRejectByChefEditor) return true; return false;
        }
    }
    public bool CanBeSelectRefrees
    {
        get
        {
            if (!this.RoleForThis[RoleType.Editor])
                return false;
            if (!this.IsAcceptByChefEditor)
                return false;
            if (this.IsRejectByEditor)
                return false;
            if (this.Procedure[Procedure.Count - 1].Status.ID == PaperStatus.ReviseByEditor)
                return false;
            if (this.IsTechnicalApproval)
                return false;
            if (this.IsAcceptByChefEditor || this.Status.ID == PaperStatus.SelectRefree)
                return true;
            return false;
        }
    }
    public bool CanBeSelectLanguageEditor
    {
        get
        {
            if (!this.RoleForThis[RoleType.Editor])
                return false;
            if (!IsTechnicalApproval)
                return false;
            PaperProcedures procedure = Procedure[Procedure.Count - 1];
            if (procedure.Status.ID == PaperStatus.SelectLanguegEditor)
                return false;
            if (procedure.Status.ID == PaperStatus.VerifyLanguageEditor)
                return false;
            if (procedure.Status.ID == PaperStatus.DisapprovalLanguageEditor)
                return true;
            if (procedure.Status.ID == PaperStatus.TechnicalApproval)
                return true;
            return false;
        }
    }
    public bool CanBeSelectEditorByChefEditor
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.CheifEditor])
                return false;
            if (this.IsAcceptByChefEditor && !this.HaveEditor)
                return true;
            return false;
        }
    }
    public bool HaveEditor
    {
        get
        {
            if (this.Editors != null && this.Editors.Count > 0)
                return true;
            return false;
        }
    }
    public bool CanBeRejectByEditor
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.Editor])
                return false;
            if (this.Status.ID == PaperStatus.AcceptByChefEditor)
                return true;
            return false;
        }
    }
    public bool CanBeAcceptByReferee
    {

        get
        {
            RefereeForPaper referee = this.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == Client.UserID) return true; return false; });
            if (referee != null)
                return referee.CanBeAcceptByReferee;
            return false;
        }

    }
    public bool CanBeRejectByReferee
    {
        get
        {
            RefereeForPaper referee = this.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == Client.UserID) return true; return false; });
            if (referee != null)
                return referee.CanBeRejectByReferee;
            return false;
        }
    }
    public bool CanBeFinalChefEditor
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.CheifEditor])
                return false;
            if (this.IsRejectByEditor)
                return false;
            if (this.IsFinalAcceptByEditor)
                return false;
            if (this.IsAcceptByChefEditor)
                return true;
            return false;

        }
    }
    public bool CanBeReviseByEditor
    {
        get
        {
            if (!SysProperty.Client.Roles[RoleType.CheifEditor])
                return false;
            if (this.IsRejectByEditor)
                return false;
            if (this.IsAcceptByChefEditor)
                return true;
            return false;
        }
    }
    public bool CanBeReviseByAuthor_Step1
    {
        get
        {
            if (!RoleForThis[RoleType.Author])
                return false;
            if (this.Procedure[this.Procedure.Count - 1].Status.ID != PaperStatus.ReviseByEditor)
                return false;
            return true;
        }
    }
    public bool CanBeTechnicalApproval
    {
        get
        {
            if (!RoleForThis[RoleType.Editor])
                return false;
            if (IsAcceptByChefEditor)
                return true;
            return false;
        }
    }
    public bool CanBeReviseByAuthor_Step2
    {
        get
        {
            if (!RoleForThis[RoleType.Author])
                return false;
            if (this.Procedure[this.Procedure.Count - 1].Status.ID != PaperStatus.ReviseByAuthor_Step1)
                return false;
            return true;
        }
    }
    public bool CanBeReviseByAuthor_Step3
    {
        get
        {
            if (!RoleForThis[RoleType.Author])
                return false;
            if (this.Procedure[this.Procedure.Count - 1].Status.ID != PaperStatus.ReviseByAuthor_Step2)
                return false;
            return true;
        }
    }
    public bool IsRejectByChefEditor
    {
        get
        {
            List<PaperProcedures> acceptlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.AcceptByChefEditor) return true; return false; });
            List<PaperProcedures> rejectlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.RejectByChefEditor) return true; return false; });
            if (rejectlist == null || rejectlist.Count == 0)
                return false;
            if (acceptlist == null || acceptlist.Count == 0)
                return true;
            if (acceptlist[acceptlist.Count - 1].Date.Datetime > rejectlist[rejectlist.Count - 1].Date.Datetime)
                return false;
            return true;

        }
    }
    public bool IsRejectByEditor
    {
        get
        {

            List<PaperProcedures> acceptlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.SelectRefree) return true; return false; });
            List<PaperProcedures> rejectlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.RejectByEditor) return true; return false; });
            if (rejectlist == null || rejectlist.Count == 0)
                return false;
            if (acceptlist == null || acceptlist.Count == 0)
                return true;
            if (acceptlist[acceptlist.Count - 1].Date.Datetime > rejectlist[rejectlist.Count - 1].Date.Datetime)
                return false;
            return true;
        }
    }
    public bool CanBeEvaluatByReferee
    {
        get
        {
            RefereeForPaper referee = this.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == Client.UserID) return true; return false; });
            if (referee != null)
                return referee.CanBeEvaluatByReferee;
            return false;
        }
    }
    public bool IsFinalAcceptByEditor
    {
        get
        {
            if (this.Procedure.FindIndex(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.FinalAcceptByEditor) return true; return false; }) != -1)
                return true;
            return false;
        }
    }
    public bool IsAcceptByChefEditor
    {
        get
        {

            List<PaperProcedures> acceptlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.AcceptByChefEditor) return true; return false; });
            List<PaperProcedures> rejectlist = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.RejectByChefEditor) return true; return false; });

            if (acceptlist == null || acceptlist.Count == 0)
                return false;
            if (rejectlist == null || rejectlist.Count == 0)
                return true;
            if (acceptlist[acceptlist.Count - 1].Date.Datetime > rejectlist[rejectlist.Count - 1].Date.Datetime)
                return true;
            return false;


        }
    }
    public bool IsTechnicalApproval
    {
        get
        {
            PaperProcedures procedure = this.Procedure.Find(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.TechnicalApproval) return true; return false; });
            if (procedure == null )
                return false;
            return true;
        }
    }
    public int CountOfReviseByEditor
    {
        get
        {
            TimeSpan compair = new TimeSpan(0, 0, 0, 2);
            int repetcount = 0;
            List<PaperProcedures> result = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.ReviseByEditor) return true; return false; });
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i].Date.Datetime - result[i - 1].Date.Datetime < compair)
                    repetcount++;

            }
            return result.Count - repetcount;
        }
    }
    public int CountOfReviseByAuthor
    {
        get
        {
            TimeSpan compair = new TimeSpan(0, 0, 0, 2);
            int repetcount = 0;
            List<PaperProcedures> result = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.Status.ID == PaperStatus.ReviseByAuthor_Step3) return true; return false; });
            for (int i = 1; i < result.Count; i++)
            {
                if (result[i].Date.Datetime - result[i - 1].Date.Datetime < compair)
                    repetcount++;

            }
            return result.Count - repetcount;
        }
    }
    public List<PaperWriter> Authors
    {
        get { return _authors; }

    }
    public List<PaperProposedReferee> ProposedReferee
    {
        get { return _proposedReferee; }

    }
    public RefereeForPaper ThisReferee
    {
        get
        {
            RefereeForPaper referee = this.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == SysProperty.Client.UserID) return true; return false; });
            return referee;
        }
    }
    public bool IsNew
    {
        get
        {
            if (Procedure[Procedure.Count - 1].Status.Index < 4)
                return true;
            return false;
        }
    }
    public bool IsRevised
    {
        get
        {
            if (16 < Procedure[Procedure.Count - 1].Status.Index && Procedure[Procedure.Count - 1].Status.Index < 19)
                return true;
            return false;
        }
    }
    /// <summary>
    /// aya in davar mitavanad nomre dehi khod ra bebinad
    /// </summary>
    public bool CanBeSeeMyEValuate
    {
        get
        {
            if (!this.RoleForThis[RoleType.Referee])
                return false;
            RefereeForPaper result = this.ThisReferee;
            if (result == null)
                return false;
            return result.CanBeSeeEvaluate;
        }
    }

    #endregion

    public PaperInfo()
    {
        _procedure = new List<PaperProcedures>();
        _referee = new List<RefereeForPaper>();
        _languageEditors = new LanguageEditors();
    }
    /// <summary>
    /// ezafe kardan yek prosedur. bad az ezafe kardan hame procedur ha in object amade gereftane etelat ast
    /// </summary>
    /// <param name="procedure"></param>
    public void Add(PaperProcedures procedure)
    {
        this._procedure.Add(procedure);
        if (this.Procedure.Count == 1)
        {
            this.ID = procedure.Paper.ID;
            this.Abstracts = procedure.Paper.Abstracts;
            this.Date = procedure.Paper.Date;
            this.Keyword = procedure.Paper.Keyword;
            this.Owner = procedure.Paper.Owner;
            this.Reference = procedure.Paper.Reference;
            this.Title = procedure.Paper.Title;
            this.WhatMajor = procedure.Paper.WhatMajor;
            this.WhatOrginal = procedure.Paper.WhatOrginal;
            this.WhyOrginal = procedure.Paper.WhyOrginal;
            this.Feilds = procedure.Paper.Feilds;

            //this.LastVersion = procedure.Version;
        }



        RefereeForPaper referee = new RefereeForPaper(this);
        if (procedure.Status.ID == PaperStatus.SelectRefree)
        {
            referee.User = procedure.Another;
        }
        else if (procedure.Status.ID == PaperStatus.AcceptByReferee)
        {
            referee.User = procedure.Creator;
        }
        else if (procedure.Status.ID == PaperStatus.RejectByReferee)
        {
            referee.User = procedure.Creator;
        }
        else if (procedure.Status.ID == PaperStatus.RemoveReferee)
        {
            referee.User = procedure.Another;
        }
        else if (procedure.Status.ID == PaperStatus.EvaluatedByReferee)
        {
            referee.User = procedure.Creator;
        }
        if (referee.User != null)
        {
            RefereeForPaper refereeinlist = this._referee.Find(delegate (RefereeForPaper r) { if (r.User.UserID == referee.User.UserID) return true; return false; });
            if (refereeinlist != null)
            {
                refereeinlist.Add(procedure);
            }
            else
            {
                this._referee.Add(referee);
                this._referee[_referee.Count - 1].Add(procedure);
            }
        }
        // if (this._referee.FindIndex())
        //------------------
        User_cls languageEditor =null ;//= new User_cls();
        if (procedure.Status.ID == PaperStatus.SelectLanguegEditor)
        {
            languageEditor = procedure.Another;
        }
        else if(procedure.Status.ID == PaperStatus.VerifyLanguageEditor)
        {
            languageEditor = procedure.Creator;
        }
        else if(procedure.Status.ID == PaperStatus.DisapprovalLanguageEditor)
        {
            languageEditor = procedure.Creator;
        }
        else if(procedure.Status.ID == PaperStatus.ConfrimationLanguageEditting)
        {
            languageEditor = procedure.Another;
        }
        else if (procedure.Status.ID == PaperStatus.DisapprovalLanguageEditting)
        {
            languageEditor = procedure.Another;
        }
        if (languageEditor != null)
        {
            LanguageEditor leditor = new LanguageEditor(this);
            leditor.FullName = languageEditor.FullName;
            leditor.UserID = languageEditor.UserID;
            //
            LanguageEditor lanEditor = this._languageEditors.Find(delegate (LanguageEditor lan) { if (lan.UserID == languageEditor.UserID) return true; return false; });
            if (lanEditor != null)
            {
                lanEditor.Add(procedure);
            }
            else
            {
                this._languageEditors.Add(leditor);
                this._languageEditors[_languageEditors.Count - 1].Add(procedure);
            }
        }
        
        if (this.ID != procedure.Paper.ID)
            throw new Exception("procedur ke gharare add beshe paper un ba paper in class motefavete");
    }
    /// <summary>
    /// gereftane list file haye khasi az yek paper
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public List<PaperFile> GetFile(PaperFileType type)
    {
        List<PaperFile> result = new List<PaperFile>();
        List<PaperProcedures> source = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.FileType != null && p.FileType.ID == type.ID) return true; return false; });
        int index = 1;
        foreach (PaperProcedures item in source)
        {
            result.Add(new PaperFile()
            {
                Filename = item.FileAddress,
                Type = item.FileType,
                Title = item.FileType.Title + " " + index.ToString(),
                Date = item.Date
            }
            );
            index++;
        }
        return result;
    }
    public List<PaperFile> GetFile(int version)
    {
        List<PaperFile> result = new List<PaperFile>();
        List<PaperProcedures> source = this.Procedure.FindAll(delegate (PaperProcedures p) { if (p.FileType != null && p.Version == version) return true; return false; });
        int index = 1;
        foreach (PaperProcedures item in source)
        {
            result.Add(new PaperFile()
            {
                Filename = item.FileAddress,
                Type = item.FileType,
                Title = item.FileType.Title + " " + index.ToString(),
                Date = item.Date
            }
            );
            index++;
        }
        return result;
    }




}
/// <summary>
/// file yek paper dar in ghaleb dade mishavad
/// </summary>
public class PaperFile
{
    string _filename;

    public string Filename
    {
        get { return _filename; }
        set { _filename = value; }
    }
    PaperFileType _type;

    public PaperFileType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    string _title;

    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    int _version;

    public int Version
    {
        get { return _version; }
        set { _version = value; }
    }
    PersianDateTime _date;

    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

}