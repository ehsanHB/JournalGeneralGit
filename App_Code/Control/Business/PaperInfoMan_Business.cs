using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer;
using System.Data;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// class controli marbot be laye Business ke boundry az an estefade mikonad
/// </summary>
public class PaperInfoMan_Business
{
    public PaperInfoMan_Business()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void TechnicalApprovalVerification(PaperInfo paperInfo)
    {
        if (!paperInfo.CanBeTechnicalApproval)
        {
            throw new MyException(SystemMessage_PaperInfoMan.CanNotTechnicalApproval, 101, "");
        }
    }
    public DBmessage TechnicalApproval(int paperID)
    {
        SysClient.Client.Roles.Check(RoleType.Editor);
        PaperInfo info = GetPaperInfoForEditor(paperID);
        TechnicalApprovalVerification(info);
        PaperProcedures procedure = new PaperProcedures
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.TechnicalApproval),
            Creator = SysClient.Client,
            As = new Position(Position.Editor),
            Version = info.LastVersion
        };
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(procedure);
        DBmessage dbm = procedure.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        return dbm;
    }
    public void ReviseByAuthor_Step1_Verification(PaperInfo paperInfo)
    {
        if (!paperInfo.CanBeReviseByAuthor_Step1)
        {
            throw new MyException(SystemMessage_PaperInfoMan.CanNotReviseByAuthorStep1, 101,"");
        }
    }
    public DBmessage ReviseByAuthor_Step1(int paperID,string abstracts, string keyword, string feild)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        PaperInfo info = GetPaperInfoForAuthor(paperID);
        ReviseByAuthor_Step1_Verification(info);
        info.Abstracts = abstracts;
        info.Keyword = keyword;
        info.Feilds = feild;
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        DBmessage resultedite = logic.EditPaper(info.ID, info.Owner.User.UserID, info.Title, info.Abstracts, info.Reference, info.Keyword, info.WhatOrginal, info.WhyOrginal, info.WhatMajor, info.Feilds,"");
        if (resultedite.Type == DBMessageType.Sucsess)
        {
            List<PaperProcedures> procList = new List<PaperProcedures>();
            PaperProcedures proc = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step1),
                Version = info.LastVersion
            };
            procList.Add(proc);

            DBmessage dbm = proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
            return dbm;
        }
        return resultedite;
    }
    public void ReviseByAuthor_Step2_Verification(List<PaperWriter> writers, PaperInfo paperInfo)
    {
        if (writers != null)// barresi inke in maghale faghat yek moalef be unvane incharg( masol) dashte bashad
        {
            if (writers.FindAll(delegate (PaperWriter p) { if (p.Responsibility.ID == PaperWriterResponsibility.Encharge) return true; return false; }).Count > 1)
                throw new MyException(SystemMessage_PaperInfoMan.TwoInCharge_Error, 101, "");
            else if (writers.FindAll(delegate (PaperWriter p) { if (p.Responsibility.ID == PaperWriterResponsibility.Encharge) return true; return false; }).Count == 0)
                throw new MyException(SystemMessage_PaperInfoMan.HaveNotIncharge_Error, 101, "");
        }
        else
            throw new MyException(SystemMessage_PaperInfoMan.HaveNotIncharge_Error, 101, "");
        if (!paperInfo.CanBeReviseByAuthor_Step2)
        {
            throw new MyException(SystemMessage_PaperInfoMan.CanNotReviseByAuthorStep2, 101, "");
        }
    }
    public DBmessage ReviseByAuthor_Step2(List<PaperWriter> userlist, int paperID)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        PaperInfo info = GetPaperInfoForAuthor(paperID);
        ReviseByAuthor_Step2_Verification(userlist, info);
        PaperInfoMan_Logic paperlogic = new PaperInfoMan_Logic();
        UserInfoMan_Logic userlogic = new UserInfoMan_Logic();
        DBmessage userresult = userlogic.RegisterUsers(User_cls.Convert(userlist));
        DataTable useridlist = (DataTable)userresult.Parameter[0];
        List<PaperWriter> paperwriters = new List<PaperWriter>();
        Paper wpaper = new Paper() { ID = paperID };
        for (int i = 0; i < useridlist.Rows.Count; i++)
        {
            paperwriters.Add(new PaperWriter() { UserID = Convert.ToInt32(useridlist.Rows[i]["ID"]), Paper = wpaper, Responsibility = userlist[i].Responsibility });
        }
        if (paperlogic.RegisterPaperWriter(paperwriters).Type != DBMessageType.Sucsess)
            throw new MyException(SystemMessage.TryAgain, 101, "");
        List<PaperProcedures> procList = new List<PaperProcedures>();
        PaperProcedures proc = new PaperProcedures
        {
            As = new Position(Position.Author),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step2),
            Version = info.LastVersion
        };
        procList.Add(proc);
        return proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
    }
    public void ReviseByAuthor_Step3_Verification(PaperInfo paperInfo)
    {
        if (!paperInfo.CanBeReviseByAuthor_Step3)
        {
            throw new MyException(SystemMessage_PaperInfoMan.CanNotReviseByAuthorStep3, 101, "");
        }
    }
    public DBmessage ReviseByAuthor_Step3(int paperID, HttpPostedFile pofPDF, HttpPostedFile pofDOC, HttpPostedFile pofFigure, HttpPostedFile TableOfContent)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        string pdfname = string.Empty;
        string docname = string.Empty;
        string tablename = string.Empty;
        string figurename = string.Empty;
        DBmessage dbmPDF = FileOperations.SaveAs(pofPDF, ServerDirectory.PaperFilesPhysical, new List<string> { ".pdf", ".PDF" });
        if (dbmPDF.Type == DBMessageType.Sucsess)
            pdfname = dbmPDF.Parameter[0].ToString();
        DBmessage dbmDOC = FileOperations.SaveAs(pofDOC, ServerDirectory.PaperFilesPhysical, new List<string> { ".doc", ".DOC", ".docx", ".DOCX" });
        if (dbmDOC.Type == DBMessageType.Sucsess)
            docname = dbmDOC.Parameter[0].ToString();
        DBmessage dbmFigure = FileOperations.SaveAs(pofFigure, ServerDirectory.PaperFilesPhysical, new List<string> { ".gif", ".GIF", ".png", ".PNG", ".jpg", ".JPG", ".jpeg", ".JPEG" });
        if (dbmFigure.Type == DBMessageType.Sucsess)
            figurename = dbmFigure.Parameter[0].ToString();
        DBmessage dbmTABLE = FileOperations.SaveAs(TableOfContent, ServerDirectory.PaperFilesPhysical, null);
        if (dbmTABLE.Type == DBMessageType.Sucsess)
            tablename = dbmTABLE.Parameter[0].ToString();
        //
        PaperInfo info = GetPaperInfo(paperID);
        ReviseByAuthor_Step3_Verification(info);
        List<PaperProcedures> procList = new List<PaperProcedures>();

        if (docname == string.Empty)
        {
            throw new MyException(SystemMessage.RequierDocFile, 101, "word file");
        }
        PaperProcedures WordFile = new PaperProcedures
        {
            As = new Position(Position.Author),
            Creator = SysProperty.Client,
            FileAddress = docname,
            FileType = new PaperFileType(PaperFileType.WordFile),
            Paper = info,
            Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step3),
            Version = info.LastVersion 
        };
        WordFile.Paper.ID = paperID;
        procList.Add(WordFile);
        //
        if (pdfname != string.Empty)
        {
            PaperProcedures PdfFile = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                FileAddress = pdfname,
                FileType = new PaperFileType(PaperFileType.PdfFile),
                Paper =info,
                Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step3),
                Version = info.LastVersion

            };
            PdfFile.Paper.ID = paperID;
            procList.Add(PdfFile);
        }
        //
        if (figurename != string.Empty)
        {
            PaperProcedures Figures = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                FileAddress = figurename,
                FileType = new PaperFileType(PaperFileType.Figures),
                Paper = info,
                Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step3),
                Version = info.LastVersion

            };
            Figures.Paper.ID = paperID;
            procList.Add(Figures);
        }
        //
        if (tablename != string.Empty)
        {
            PaperProcedures Tables = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                FileAddress = tablename,
                FileType = new PaperFileType(PaperFileType.Tables),
                Paper = info,
                Status = new PaperStatus(PaperStatus.ReviseByAuthor_Step3),
                Version = info.LastVersion

            };
            Tables.Paper.ID = paperID;
            procList.Add(Tables);
        }
        return WordFile.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
    }
    public DBmessage ReviseByEditor(int paperid , string comment)
    {
        PaperInfo info = GetPaperInfoForEditor(paperid);
        if (!info.CanBeReviseByEditor)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures proc = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures()
        {
            Comment = comment,
            Creator = SysProperty.Client,
            As = new Position(Position.Editor),
            Status = new PaperStatus(PaperStatus.ReviseByEditor),
            Paper = info,
            Version = info.LastVersion + 1
        }
                );
        DBmessage dbm = proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (dbm.Type == DBMessageType.Sucsess)
            Email.SentRevisedPaperToReferees(info);
        return dbm;
    }
    public DBmessage RemoveReferee(int paperid, int refereeuserid)
    {
        SysProperty.Client.Roles.Check(RoleType.Editor);
        PaperInfo info = GetPaperInfoForEditor(paperid);
        if (!info.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == refereeuserid) return true; return false; }).CanBeRemoveReferee)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures remove = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures()
        {
            Another = new User_cls() { UserID = refereeuserid },
            As = new Position(Position.Editor),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.RemoveReferee),
            Version = info.LastVersion

        });
        return remove.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
    }
    public PaperReport GetPaperListForReferee(int paperid = 0)
    {
        if (!SysProperty.Client.Roles[RoleType.Referee])
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures proc = new PaperProcedures();
        proc.Paper = new Paper() { ID = paperid };
        DataTable dt = proc.GetForReferee(SysProperty.Client.UserID);
        List<PaperProcedures> list = PaperProcedures.ConvertToListPaperProcedures(dt, delegate (PaperProcedures p1) { return -1; }, 1);
        PaperReport report = new PaperReport(list);
        report.Papers.RemoveAll(delegate (PaperInfo p)
        {
            RefereeForPaper referee = p.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == SysProperty.Client.UserID) return true; return false; });
            if (referee.Status.ID == PaperStatus.SelectRefree || referee.Status.ID == PaperStatus.AcceptByReferee)
                return false;
            if (referee.LastSelectorVersion.HasValue && referee.LastSelectorVersion.Value == p.LastVersion)
                return false;
            return true;
        });
        return report;
    }
    public PaperInfo GetPaperInfoForReferee(int id)
    {
        PaperReport report = GetPaperListForReferee(id);
        if (report.Papers.Count == 0)
            return null;
        if (!report.Papers[0].RoleForThis[RoleType.Referee])
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        return report.Papers[0];
    }
    public DBmessage RejectByReferee(int paperid)
    {
        PaperInfo info = GetPaperInfoForReferee(paperid);
        if (info != null && !info.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == SysProperty.Client.UserID) return true; return false; }).CanBeRejectByReferee)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures reject = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures()
        {
            As = new Position(Position.Refree),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.RejectByReferee),
            Version = info.LastVersion

        });
        #region kamel kardane etelate lastSelector
        UserInfoMan_Logic userLogic = new UserInfoMan_Logic();
        Editor editor = info.ThisReferee.LastSelector;
        User_cls user = userLogic.GetUserInfo(editor.User.UserID);
        info.ThisReferee.LastSelector.User.Email = user.Email;
        #endregion
        DBmessage dbm = reject.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (dbm.Type == DBMessageType.Sucsess)
        {
            Email.SentRejectArbitration(info);
        }
        return dbm;
    }
    public DBmessage AcceptByReferee(int paperid)
    {
        PaperInfo info = GetPaperInfoForEditor(paperid);
        if (!info.CanBeAcceptByReferee)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures accept = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures()
        {
            As = new Position(Position.Refree),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.AcceptByReferee),
            Version = info.LastVersion

        });
        #region kamel kardane etelate lastSelector
        UserInfoMan_Logic userLogic = new UserInfoMan_Logic();
        Editor editor = info.ThisReferee.LastSelector;
        User_cls user = userLogic.GetUserInfo(editor.User.UserID);
        info.ThisReferee.LastSelector.User.Email = user.Email;
        #endregion
        DBmessage dbm = accept.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (dbm.Type == DBMessageType.Sucsess)
        {
            Email.SentAcceptArbitration(info);
        }
        return dbm;
    }
    private void RegisterPaper_Step2_Verification(List<PaperWriter> writers, PaperInfo info)
    {
        if (info.Owner.User.UserID != SysProperty.Client.UserID)
            throw new MyException(SystemMessage_PaperInfoMan.NotBelong_Error, 101, "");
        if (writers != null)// barresi inke in maghale faghat yek moalef be unvane incharg( masol) dashte bashad
        {
            if (writers.FindAll(delegate (PaperWriter p) { if (p.Responsibility.ID == PaperWriterResponsibility.Encharge) return true; return false; }).Count > 1)
                throw new MyException(SystemMessage_PaperInfoMan.TwoInCharge_Error, 101, "");
            else if (writers.FindAll(delegate (PaperWriter p) { if (p.Responsibility.ID == PaperWriterResponsibility.Encharge) return true; return false; }).Count == 0)
                throw new MyException(SystemMessage_PaperInfoMan.HaveNotIncharge_Error, 101, "");
        }
        PaperInfoMan_Logic paperlogic = new PaperInfoMan_Logic();
        if (info.Procedure[info.Procedure.Count - 1].Status.ID != PaperStatus.Preparing_step1)// in maghale akharin bar dar faghat step1 ra tey karde
        {
            throw new MyException(SystemMessage.InvalidOperation, 101, "");

        }
        PersianDateTime exp = PersianDateTime.Add(info.Procedure[0].Date, new TimeSpanBatis(SysProperty.ExpirationForSubmitOnline));// be dast avardan tarikh engheza
        if (DateTime.Now > exp.Datetime)// aya tarikh engheza gozashte
        {
            paperlogic.DeletePaper(info.ID);
            throw new MyException(SystemMessage_PaperInfoMan.ExpirationError, 101, "");
        }
    }

    /// <summary>
    /// sabte maghale tavasote author, marhale aval 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="abstracts"></param>
    /// <param name="keyword"></param>
    /// <returns>dar surate movafaghiyat amiz budan tavasote key "paper" be paper dastrasi darim</returns>
    public DBmessage RegisterPaper_Step1(string title, string abstracts, string keyword, string feild)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        Paper paper = new Paper
        {
            Title = title,
            Abstracts = abstracts,
            //Reference = refrence,
            Keyword = keyword,
            Feilds = feild
            //WhatOrginal = whatorginal,
            //WhyOrginal = whyorginal,
            //WhatMajor = whatmajor,
        };
        paper.Owner = new Author();
        paper.Owner.User = SysProperty.Client;
        DBmessage resultpaperregister = paper.Register();
        if (resultpaperregister.Type == DBMessageType.Sucsess)// sabte maghale ba movafaghiat anjam shod
        {
            List<PaperProcedures> procList = new List<PaperProcedures>();


            PaperProcedures proc = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = paper,
                Status = new PaperStatus(PaperStatus.Preparing_step1),
                Version = 1
            };
            procList.Add(proc);

            DBmessage dbm = proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
            if (dbm.Type == DBMessageType.Sucsess)
                dbm.Parameter["paper"] = paper;
            return dbm;
        }
        return resultpaperregister;
    }
    /// <summary>
    /// ersale maghale marhale 2
    /// </summary>
    /// <param name="userlist"></param>
    /// <param name="paperID"></param>
    /// <returns></returns>
    public DBmessage RegisterPaper_Step2(List<PaperWriter> userlist, int paperID)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        PaperInfo info = GetPaperInfoForAuthor(paperID);
        RegisterPaper_Step2_Verification(userlist, info);

        PaperInfoMan_Logic paperlogic = new PaperInfoMan_Logic();
        UserInfoMan_Logic userlogic = new UserInfoMan_Logic();
        //DBmessage userresult = userlogic.RegisterUsers(User_cls.Convert(userlist));
        //DataTable useridlist = (DataTable)userresult.Parameter[0];
        List<PaperWriter> paperwriters = new List<PaperWriter>();
        Paper wpaper = new Paper() { ID = paperID };
        for (int i = 0; i < userlist.Count; i++)
        {
            paperwriters.Add(new PaperWriter() { Fname = userlist[i].Fname,Lname = userlist[i].Lname, Paper = wpaper, Responsibility = userlist[i].Responsibility });
        }
        if (paperlogic.RegisterPaperWriter(paperwriters).Type != DBMessageType.Sucsess)
            throw new MyException(SystemMessage.TryAgain, 101, "");
        List<PaperProcedures> procList = new List<PaperProcedures>();
        PaperProcedures proc = new PaperProcedures
        {
            As = new Position(Position.Author),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.Preparing_step2),
            Version = 1
        };
        procList.Add(proc);
        return proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pofPDF"></param>
    /// <param name="pofDOC"></param>
    /// <param name="pofFigure"></param>
    /// <param name="TableOfContent"></param>
    /// <param name="comment"></param>
    /// <param name="paperid"></param>
    /// <returns></returns>
    public DBmessage RegisterPaper_Step3(HttpPostedFile pofPDF, HttpPostedFile pofDOC, HttpPostedFile pofFigure, HttpPostedFile TableOfContent, string comment, int paperid)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        string pdfname = string.Empty;
        string docname = string.Empty;
        string tablename = string.Empty;
        string figurename = string.Empty;
        DBmessage dbmPDF = FileOperations.SaveAs(pofPDF, ServerDirectory.PaperFilesPhysical, new List<string> { ".pdf", ".PDF" });
        if (dbmPDF.Type == DBMessageType.Sucsess)
            pdfname = dbmPDF.Parameter[0].ToString();
        DBmessage dbmDOC = FileOperations.SaveAs(pofDOC, ServerDirectory.PaperFilesPhysical, new List<string> { ".doc", ".DOC", ".docx", ".DOCX" });
        if (dbmDOC.Type == DBMessageType.Sucsess)
            docname = dbmDOC.Parameter[0].ToString();
        DBmessage dbmFigure = FileOperations.SaveAs(pofFigure, ServerDirectory.PaperFilesPhysical, new List<string> { ".gif", ".GIF", ".png", ".PNG", ".jpg", ".JPG", ".jpeg", ".JPEG" });
        if (dbmFigure.Type == DBMessageType.Sucsess)
            figurename = dbmFigure.Parameter[0].ToString();
        DBmessage dbmTABLE = FileOperations.SaveAs(TableOfContent, ServerDirectory.PaperFilesPhysical, null);
        if (dbmTABLE.Type == DBMessageType.Sucsess)
            tablename = dbmTABLE.Parameter[0].ToString();
        //
        PaperInfo info = GetPaperInfoForAuthor(paperid);
        RegisterPaper_Step3_Verification(info, pdfname, docname);
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        DBmessage resultedite = logic.EditPaper(info.ID, info.Owner.User.UserID, info.Title, info.Abstracts, info.Reference, info.Keyword, info.WhatOrginal, info.WhyOrginal, info.WhatMajor, info.Feilds, comment);
        if (resultedite.Type != DBMessageType.Sucsess)
            return resultedite;

        List<PaperProcedures> procList = new List<PaperProcedures>();
        if (docname != null || docname != string.Empty)
        {
            PaperProcedures doc = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.Preparing_step3),
                Version = 1,
                FileAddress = docname,
                FileType = new PaperFileType(PaperFileType.WordFile),
            };
            procList.Add(doc);
        }
        if (pdfname != null || pdfname != string.Empty)
        {
            PaperProcedures pdf = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.Preparing_step3),
                Version = 1,
                FileAddress = pdfname,
                FileType = new PaperFileType(PaperFileType.PdfFile),
            };
            procList.Add(pdf);
        }
        if (figurename != null || figurename != string.Empty)
        {
            PaperProcedures pdf = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.Preparing_step3),
                Version = 1,
                FileAddress = figurename,
                FileType = new PaperFileType(PaperFileType.Figures),
            };
            procList.Add(pdf);
        }
        if (tablename != null || tablename != string.Empty)
        {
            PaperProcedures pdf = new PaperProcedures
            {
                As = new Position(Position.Author),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.Preparing_step3),
                Version = 1,
                FileAddress = tablename,
                FileType = new PaperFileType(PaperFileType.Tables),
            };
            procList.Add(pdf);
        }
        PaperProcedures proc = new PaperProcedures();
        return proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
    }

    private static void RegisterPaper_Step3_Verification(PaperInfo info, string pdfname, string docname)
    {
        if (info.Owner.User.UserID != SysProperty.Client.UserID)
            throw new MyException(SystemMessage_PaperInfoMan.NotBelong_Error, 101, "");
        if (info.Procedure[info.Procedure.Count - 1].Status.ID != PaperStatus.Preparing_step2)
            throw new MyException(SystemMessage.InvalidOperation, 101, "");
        PersianDateTime exp = PersianDateTime.Add(info.Procedure[0].Date, new TimeSpanBatis(SysProperty.ExpirationForSubmitOnline));// be dast avardan tarikh engheza
        PaperInfoMan_Logic paperlogic = new PaperInfoMan_Logic();
        if (DateTime.Now > exp.Datetime)// aya tarikh engheza gozashte
        {
            paperlogic.DeletePaper(info.ID);
            throw new MyException(SystemMessage_PaperInfoMan.ExpirationError, 101, "");
        }
        if (pdfname == string.Empty || pdfname == null || docname == string.Empty || docname == null)
            throw new MyException(SystemMessage_PaperInfoMan.PaperFileRequeird, 101, "");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="referees">bayad name, family va email por shavad</param>
    /// <param name="paperid"></param>
    /// <returns></returns>
    public DBmessage RegisterPaper_Step4(List<User_cls> referees, int paperid)
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        PaperInfo info = GetPaperInfoForAuthor(paperid);
        info.Owner.User.Email = SysClient.Client.Email;
        RegisterPaper_Step4_Verification(info);
        DBmessage resultreferee = new DBmessage(DBMessageType.Sucsess, "");
        if (referees != null && referees.Count != 0)
        {
            PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
            resultreferee = logic.RegisterPaperProsedReferee(referees, info.ID);
        }
        if (resultreferee.Type != DBMessageType.Sucsess)
            return resultreferee;
        List<PaperProcedures> procList = new List<PaperProcedures>();
        PaperProcedures proc = new PaperProcedures
        {
            As = new Position(Position.Author),
            Creator = SysProperty.Client,
            Paper = info,
            Status = new PaperStatus(PaperStatus.New),
            Version = 1
        };
        procList.Add(proc);
        DBmessage dbm = proc.Register(PaperProcedureTable.ConvertToPaperProcedureTable(procList));
        if (dbm.Type == DBMessageType.Sucsess)
        {
            UserInfoMan_Business user = new UserInfoMan_Business();
            User_cls chefEditor = user.GetChefEditor();
            Email.SendPaperRegisterationToChefEditor(chefEditor, info);
            Email.SendPaperRegisterationToAuthor(info);
        }
        return dbm;
    }
    private static void RegisterPaper_Step4_Verification(PaperInfo info)
    {
        if (info.Owner.User.UserID != SysProperty.Client.UserID)
            throw new MyException(SystemMessage_PaperInfoMan.NotBelong_Error, 101, "");
        if (info.Procedure[info.Procedure.Count - 1].Status.ID != PaperStatus.Preparing_step3)
            throw new MyException(SystemMessage.InvalidOperation, 101, "");
        PersianDateTime exp = PersianDateTime.Add(info.Procedure[0].Date, new TimeSpanBatis(SysProperty.ExpirationForSubmitOnline));// be dast avardan tarikh engheza
        PaperInfoMan_Logic paperlogic = new PaperInfoMan_Logic();
        if (DateTime.Now > exp.Datetime)// aya tarikh engheza gozashte
        {
            paperlogic.DeletePaper(info.ID);
            throw new MyException(SystemMessage_PaperInfoMan.ExpirationError, 101, "");
        }


    }
    public DBmessage RejectByChefEditor(int paperid)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(paperid);
        if (!info.CanBeRejectByChefEditor)
            throw new MyException(SystemMessage.InvalidOperation, 101, "");
        PaperProcedures reject = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures()
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.RejectByChefEditor),
            Creator = SysProperty.Client,
            As = new Position(Position.ChefEditor),
            Version = info.LastVersion
        }
            );
        DBmessage msg = reject.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (msg.Type == DBMessageType.Sucsess)
        {
            UserInfoMan_Logic user = new UserInfoMan_Logic();
            list[0].Paper.Owner.User = user.GetUserInfo(list[0].Paper.Owner.User.UserID);
            Email.SendRejectedPaperByChefEditor(list[0]);
        }
        return msg;
    }
    public PaperInfo GetPaperInfoForAuthor(int paperid)
    {
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(paperid);
        if (info.Owner.User.UserID == SysProperty.Client.UserID)
            return info;
        return null;
    }
    /// <summary>
    /// taeed avalie maghale tavasote modir
    /// </summary>
    /// <param name="paperId"></param>
    /// <param name="evaluationformid">id form arzyabi ke bayad tavasote davaran bar an asas arzyabi sorat girad</param>
    /// <returns></returns>
    public DBmessage AcceptByChefEditor(int paperId, int evaluationformid)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(paperId);
        if (!info.CanBeAcceptByChefEditor)
            throw new MyException(SystemMessage_PaperInfoMan.AcceptedByChefEditor_Error, 101, "");
        PaperProcedures accept = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        list.Add(new PaperProcedures());
        list[0].Paper = info;
        list[0].Status = new PaperStatus() { ID = PaperStatus.AcceptByChefEditor };
        list[0].Creator = SysProperty.Client;
        list[0].As = new Position() { ID = Position.ChefEditor };
        list[0].Version = info.LastVersion;
        list[0].Another = new User_cls() { UserID = evaluationformid };

        DBmessage msg = accept.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (msg.Type == DBMessageType.Sucsess)
        {
            UserInfoMan_Logic user = new UserInfoMan_Logic();
            list[0].Paper.Owner.User = user.GetUserInfo(list[0].Paper.Owner.User.UserID);
            Email.SendAcceptedPaperByChefEditor(list[0]);
        }
        return msg;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="OwnerId"></param>
    /// <param name="Title"></param>
    /// <param name="Reference"></param>
    /// <param name="Keyword"></param>
    /// <returns></returns>
    public PaperReport GetPaperListForChefEditor(int OwnerId, string Title, string Keyword)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        PaperInfoMan_Logic paperInfoMan = new PaperInfoMan_Logic();
        return paperInfoMan.GetPaperList(0, OwnerId, Title, string.Empty, Keyword, string.Empty, string.Empty, string.Empty, delegate (PaperProcedures p1) { return -1; }, 1);
    }

    public PaperReport GetPaperListForAuther()
    {
        SysProperty.Client.Roles.Check(RoleType.Author);
        PaperInfoMan_Logic paperInfoMan = new PaperInfoMan_Logic();

        return paperInfoMan.GetPaperList(0, SysProperty.Client.UserID, "", "", "", "", "", "", delegate (PaperProcedures p1) { return -1; }, 1);
    }

    public PaperReport GetPaperListForSyntaxEditor(string title)
    {
        SysProperty.Client.Roles.Check(RoleType.SyntaxEditor);
        PaperInfoMan_Logic paperInfoMan = new PaperInfoMan_Logic();

        return paperInfoMan.GetPaperList(0, SysProperty.Client.UserID, title, "", "", "", "", "", delegate(PaperProcedures p1) { return -1; }, 1);
    }
    public PaperReport GetPaperListForLanguageEditor(string title)
    {
        SysProperty.Client.Roles.Check(RoleType.LanguageEditor);
        PaperInfoMan_Logic paperInfoMan = new PaperInfoMan_Logic();

        return paperInfoMan.GetPaperList(0, SysProperty.Client.UserID, title, "", "", "", "", "", delegate(PaperProcedures p1) { return -1; }, 1);
    }
    public PaperReport GetPaperListForEditor(int OwnerId, string Title, string Keyword)
    {
        SysProperty.Client.Roles.Check(RoleType.Editor);
        PaperInfoMan_Logic paperInfoMan = new PaperInfoMan_Logic();
        return paperInfoMan.GetPaperList(0, OwnerId, Title, string.Empty, Keyword, string.Empty, string.Empty, string.Empty, delegate (PaperProcedures p1) { return -1; }, 1, SysProperty.Client.UserID);
    }

    /// <summary>
    /// entekhab davar baraye maghale
    /// </summary>
    /// <param name="paperid"></param>
    /// <param name="refreesuser">agar userid va email fard por bashad </param>
    /// <param name="requestExpirationDate">tarikh engheza in darkhast</param>
    /// <returns></returns>
    public DBmessage SelectRefree(int paperid, string refereeEmail, PersianDateTime requestExpirationDate)
    {
        refereeEmail = new User_cls() { Email = refereeEmail }.Email;
        PaperInfo info = GetPaperInfoForEditor(paperid);
        if (!info.CanBeSelectRefrees)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        UserInfoMan_Logic userlogic = new UserInfoMan_Logic();
        string hash = FileOperations.SetId();
        int userid = 0;
        #region Referee Register
        if (refereeEmail != null || refereeEmail != string.Empty)
        {
            DBmessage resultregisterReferee = new DBmessage(DBMessageType.Error, "");
            List<User_cls> users = userlogic.GetUsersFullInfo(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, refereeEmail, null);
            if (users != null && users.Count != 0)// user(s) ba in email vojod darad
            {

                if (users.Count > 1)// agar tedade user haee ke in adrese email ro darand bish az 1 bashad
                {
                    User_cls haveusername = users.Find(delegate (User_cls u) { if (u.Username != null && u.Username == refereeEmail) return true; return false; });
                    userid = haveusername.UserID;
                    resultregisterReferee = RegisterUserForReferee_InRefereSelection(refereeEmail, requestExpirationDate, hash, haveusername);
                    if (resultregisterReferee.Type != DBMessageType.Sucsess)
                        return resultregisterReferee;
                }
                else// faghat yek karbar yaft shod
                {
                    User_cls us = users[0];
                    userid = us.UserID;
                    resultregisterReferee = RegisterUserForReferee_InRefereSelection(refereeEmail, requestExpirationDate, hash, us);
                    if (resultregisterReferee.Type != DBMessageType.Sucsess)
                        return resultregisterReferee;
                }
            }
            else
            {
                resultregisterReferee = userlogic.RegisterUser(refereeEmail, hash, requestExpirationDate, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, refereeEmail, string.Empty, string.Empty, null, string.Empty, null, out userid);
                if (resultregisterReferee.Type != DBMessageType.Sucsess)
                    throw new MyException(SystemMessage_UserINfoMan.ProblmeInRefereeRegistration, 101, "");
                resultregisterReferee = userlogic.RegisterReferee(userid);
                if (resultregisterReferee.Type != DBMessageType.Sucsess)
                    return resultregisterReferee;

            }
        }
        else
            throw new MyException(SystemMessage.EmailCannotEmpty, 101, "");
        #endregion

        PaperProcedures selectrefree = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();

        if (info.Owner.User.UserID == userid)
            throw new MyException(SystemMessage_PaperInfoMan.OwnerNotBeReferee, 101, "");
        //throw new NotImplementedException("davar tekrari bayad check beshe" );
        list.Add(new PaperProcedures()
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.SelectRefree),
            Creator = SysProperty.Client,
            Another = new User_cls() { UserID = userid },
            As = new Position(Position.Editor),
            Version = info.LastVersion
        });
        DBmessage resultmessage = selectrefree.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (resultmessage.Type == DBMessageType.Sucsess)
        {
            User_cls user = new User_cls() { UserID = userid, Email = refereeEmail, Password = hash };
            Email.SendSelectReferee(info, user, requestExpirationDate);

        }
        return resultmessage;
    }
    public void YourUploadMethod(object state)
    {
        Thread.Sleep(7000);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="refereesuser">useri ke bayad barresi shavad ke che etefaghi baraye vey rokh dahad, az nazar sabt dar jadval user va referee, az tarafe karbar in user dade mishavad</param>
    /// <param name="requestExpirationDate"></param>
    /// <param name="hash"></param>
    /// <param name="haveusername"></param>
    /// <returns></returns>
    private static DBmessage RegisterUserForReferee_InRefereSelection(string refereeEmail, PersianDateTime requestExpirationDate, string hash, User_cls haveusername)
    {
        DBmessage resulthaveusername = new DBmessage(DBMessageType.Sucsess, "");
        UserInfoMan_Logic userlogic = new UserInfoMan_Logic();
        if (haveusername.Username != null && haveusername.Username != string.Empty)// user mojod daraye username ast
        {
            if (!haveusername.Roles[RoleType.Referee])// agar user role referee nadasht dar referee sabt mishad
            {
                resulthaveusername = userlogic.RegisterReferee(haveusername.UserID);
                if (resulthaveusername.Type != DBMessageType.Sucsess)
                    throw new MyException(SystemMessage_UserINfoMan.ProblmeInRefereeRegistration, 101, "");
            }
            resulthaveusername = userlogic.EditUser(haveusername.UserID, refereeEmail, refereeEmail, haveusername.Fname, haveusername.Lname, haveusername.Affiliations, haveusername.Phone, haveusername.Fax, haveusername.Fields, haveusername.Melli, haveusername.Birthdate, haveusername.Education, haveusername.Sex, hash, requestExpirationDate);
        }
        else
        {
            resulthaveusername = userlogic.EditUser(haveusername.UserID, refereeEmail, refereeEmail, haveusername.Fname, haveusername.Lname, haveusername.Affiliations, haveusername.Phone, haveusername.Fax, haveusername.Fields, haveusername.Melli, haveusername.Birthdate, haveusername.Education, haveusername.Sex, hash, requestExpirationDate);
            if (resulthaveusername.Type != DBMessageType.Sucsess)
                throw new MyException(resulthaveusername.Message, 101, "");
            resulthaveusername = userlogic.RegisterReferee(haveusername.UserID);
            if (resulthaveusername.Type != DBMessageType.Sucsess)
                throw new MyException(SystemMessage_UserINfoMan.ProblmeInRefereeRegistration, 101, "");


        }
        return resulthaveusername;
    }
    public PaperInfo GetPaperInfoForEditor(int id)
    {
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(id);
        if (!info.RoleForThis[RoleType.Editor])
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        return info;
    }
    public PaperInfo GetPaperInfo(int paperid)
    {
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(paperid);
        if (!info.HaveAnyRole)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        return info;
    }
    /// <summary>
    /// entekhab editor baraye maghale
    /// </summary>
    /// <param name="paperID"></param>
    /// <param name="editorUserID"></param>
    /// <returns></returns>
    public DBmessage SelectEditor(int paperID, int editorUserID)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        PaperProcedures paperProcedure = new PaperProcedures();
        PaperInfoMan_Logic logic = new PaperInfoMan_Logic();
        PaperInfo info = logic.GetPaperInfo(paperID);
        if (!info.CanBeSelectEditorByChefEditor)
            throw new MyException(SystemMessage.InvalidOperation, 101, "");
        List<PaperProcedures> list = new List<PaperProcedures>();

        list.Add(new PaperProcedures()
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.SelectEditor),
            Creator = SysProperty.Client,
            As = new Position(Position.ChefEditor),
            Another = SysProperty.Client,
            Version = info.LastVersion
        });
        list.Add(new PaperProcedures()
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.SelectEditor),
            Creator = SysProperty.Client,
            As = new Position(Position.ChefEditor),
            Another = new User_cls() { UserID = editorUserID },
            Version = info.LastVersion
        });
        DBmessage msg = paperProcedure.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if (msg.Type == DBMessageType.Sucsess)
        {
            UserInfoMan_Logic user = new UserInfoMan_Logic();
            //list[1].Paper.Owner.User = user.GetUserInfo(list[1].Paper.Owner.User.UserID);
            //
            User_cls editor = user.GetUserInfo(editorUserID);
            Email.SendSelectEditorByChefEditor(list[1], editor);
        }
        return msg;
    }
    /// <summary>
    /// sabte nomerate yek maghale
    /// </summary>
    /// <param name="paperid"></param>
    /// <param name="files"></param>
    /// <param name="evaluationform"></param>
    /// <returns></returns>
    public DBmessage SetPointToPaperByReferee(int paperid, List<string> files, EvaluationForm evaluationform)
    {
        PaperInfo info = GetPaperInfoForReferee(paperid);
        RefereeForPaper refereefp = info.Referees.Find(delegate (RefereeForPaper r) { if (r.User.UserID == SysProperty.Client.UserID) return true; return false; });
        if (refereefp == null || !refereefp.CanBeRejectByReferee)
            throw new MyException(SystemMessage.AccessDeny, 101, "");
        PaperProcedures evaluation = new PaperProcedures();
        List<PaperProcedures> list = new List<PaperProcedures>();
        foreach (string item in files)
        {
            list.Add(new PaperProcedures
            {
                As = new Position(Position.Refree),
                Creator = SysProperty.Client,
                FileAddress = item,
                FileType = new PaperFileType(PaperFileType.EvaluatedDoc),
                Paper = info,
                Status = new PaperStatus(PaperStatus.EvaluatedByReferee),
                Version = info.LastVersion

            });
        }
        if (list.Count == 0)// agar fili vojod nadasht
        {
            list.Add(new PaperProcedures
            {
                As = new Position(Position.Refree),
                Creator = SysProperty.Client,
                Paper = info,
                Status = new PaperStatus(PaperStatus.EvaluatedByReferee),
                Version = info.LastVersion

            });
        }
        DBmessage msg = evaluation.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        DataTable dt = (DataTable)msg.Parameter[0];
        if (msg.Type == DBMessageType.Sucsess)// in farayand movafaghiat amiz sabt shod
        {
            evaluationform.Paperprosedur = new PaperProcedures() { ID = Convert.ToInt32(dt.Rows[0]["ID"]), Paper = new Paper() { ID = paperid } };
            //evaluationform.RefereeEvaluator = new Referee() { User = new User_cls() { UserID = SysProperty.Client.UserID } };
            DBmessage evmsg = evaluationform.Register(PaperEvaluationTable.Convert(evaluationform));
            if (evmsg.Type == DBMessageType.Sucsess)
                return evmsg;
            else
            {
                IntTable idlist = new IntTable();
                foreach (DataRow item in dt.Rows)
                {
                    idlist.Add(Convert.ToInt32(item["ID"]));
                }
                evaluation.Delete(idlist);
                return evmsg;
            }

        }
        return msg;
    }
    /// <summary>
    /// gereftan list maghalat yek 
    /// </summary>
    /// <param name="paperid"></param>
    /// <returns></returns>
    public List<EvaluationForm> GetEvaluateForReferee(int paperid)
    {
        throw new NotImplementedException("malom nist estefade beshe ya na");
        //PaperInfo info=GetPaperInfoForReferee(paperid);
        //if (info.CanBeSeeMyEValuate)
        //    return null;
        //QuestionInfoMan_Logic qlogic = new QuestionInfoMan_Logic();
        //return qlogic.GetPaperEvaluation(paperid, SysProperty.Client.UserID);
    }
    /// <summary>
    ///  
    /// </summary>
    /// <param name="paperid"></param>
    /// <returns></returns>
    public List<EvaluationForm> GetEvaluate(int paperid)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        QuestionInfoMan_Logic qlogic = new QuestionInfoMan_Logic();
        return qlogic.GetPaperEvaluation(paperid, 0);
    }
    public DBmessage SelectLanguegEditor(int paperid,int languegEditorUserID, PersianDateTime requestExpirationDate)
    {
        SysProperty.Client.Roles.Check(RoleType.CheifEditor);
        PaperInfo info = GetPaperInfo(paperid);
        List<PaperProcedures> list = new List<PaperProcedures>();
        PaperProcedures paperProcedure = new PaperProcedures();
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        list.Add(new PaperProcedures()
        {
            Paper = info,
            Status = new PaperStatus(PaperStatus.SelectLanguegEditor),
            Creator = SysProperty.Client,
            As = new Position(Position.ChefEditor),
            Another = new User_cls() { UserID=languegEditorUserID},
            Version = info.LastVersion
        });
       
        DBmessage msg = paperProcedure.Register(PaperProcedureTable.ConvertToPaperProcedureTable(list));
        if(msg.Type==DBMessageType.Sucsess)
        {
            string hash = FileOperations.SetId();
            FullUser languageEditorInfo = userInfoMan.GetUserFullInfo(languegEditorUserID);
            UserInfoMan_Logic userInfoManLogic = new UserInfoMan_Logic();
            //
            DBmessage dbm = userInfoManLogic.EditUser(languageEditorInfo.User.UserID, languageEditorInfo.User.Username, languageEditorInfo.User.Email,
                languageEditorInfo.User.Fname, languageEditorInfo.User.Lname, languageEditorInfo.User.Affiliations, languageEditorInfo.User.Phone,
                languageEditorInfo.User.Fax, languageEditorInfo.User.Fields, languageEditorInfo.User.Melli, languageEditorInfo.User.Birthdate,
                languageEditorInfo.User.Education, languageEditorInfo.User.Sex, hash, requestExpirationDate);
            //
            languageEditorInfo.User.Hash = hash;
            Email.SendSelectLanguageEditor(languageEditorInfo, info );
        }
        return msg;
    }

}
public static class SystemMessage_PaperInfoMan
{

    public static string CanNotTechnicalApproval
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Your article can not confirm the technical";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما این مقاله را نمی توانید تایید فنی کنید";
            return "";
        }

    }
    /// <summary>
    /// شما نمی توانید تجدید نظر مقاله در مرحله اول را انجام دهید
    /// </summary>
    public static string CanNotReviseByAuthorStep1
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "You can not do in the first revision of the article";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما نمی توانید تجدید نظر مقاله در مرحله اول را انجام دهید";
            return "";
        }

    }
    /// <summary>
    /// شما نمی توانید تجدید نظر مقاله در مرحله دوم را انجام دهید
    /// </summary>
    public static string CanNotReviseByAuthorStep2
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "You can not do in the second revision of the article";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما نمی توانید تجدید نظر مقاله در مرحله دوم را انجام دهید";
            return "";
        }

    }
    public static string CanNotReviseByAuthorStep3
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "You can not do in the third revision of the article";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما نمی توانید تجدید نظر مقاله در مرحله سوم را انجام دهید";
            return "";
        }

    }
    /// <summary>
    /// مقاله باید دارای یک مسئول باشد
    /// </summary>
    public static string HaveNotIncharge_Error
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "the paper must have one in charge";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "مقاله باید دارای یک مسئول باشد";
            return "";
        }

    }
    /// <summary>
    /// این مقاله منقضی شده است
    /// </summary>
    public static string ExpirationError
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "the paper expired";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "این مقاله منقضی شده است";
            return "";
        }

    }
    /// <summary>
    /// هیچ نویسنده ای برای مقاله داده نشده است
    /// </summary>
    public static string EmptyPaperWriterError
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "There is no writer for article";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "هیچ نویسنده ای برای مقاله داده نشده است";
            return "";
        }

    }
    /// <summary>
    /// این مقاله از قبل توسط سردبیر تایید شده
    /// </summary>
    public static string AcceptedByChefEditor_Error
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "This article has already been Accepted by the editor";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "این مقاله از قبل توسط سردبیر تایید شده";
            return "";
        }
    }

    /// <summary>
    /// فقط یکی از مولفین می تواند مسئول باشد
    /// </summary>
    public static string TwoInCharge_Error
    {
        get
        {
            return SystemMessage.GetMessage("Only one of us can be in charge", "فقط یکی از مولفین می تواند مسئول باشد");
        }
    }

    /// <summary>
    /// این مقاله به شما تعلق ندارد
    /// </summary>
    public static string NotBelong_Error { get { return SystemMessage.GetMessage("This article does not belong to you", "این مقاله به شما تعلق ندارد"); } }
    /// <summary>
    ///  docو PDF باید داده شود
    /// </summary>
    public static string PaperFileRequeird { get { return SystemMessage.GetMessage("Doc file and PDF file must be given", "فایل docو PDF باید داده شود"); } }
    /// <summary>
    /// نویسنده مقاله نمی تواند به عنوان داور همان مقاله انتخاب شود
    /// </summary>
    public static string OwnerNotBeReferee { get { return SystemMessage.GetMessage("The author can not be elected as a referee of the same article", "نویسنده مقاله نمی تواند به عنوان داور همان مقاله انتخاب شود"); } }
}