using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LogicLayer
{


    /// <summary>
    /// Summary description for PaperInfoMan_Logic
    /// </summary>
    public class PaperInfoMan_Logic
    {
        public PaperInfoMan_Logic()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// pak kardan yek maghale , tamame entity marbote ham pak mishavad
        /// </summary>
        /// <param name="paperid"></param>
        /// <returns></returns>
        public DBmessage DeletePaper(int paperid)
        {
            Paper p = new Paper();
            p.ID = paperid;
            return p.Delete();
        }
        /// <summary>
        /// sabte chand nevisande baraye maghale , tavajo shavad ke user ha bayad ghablan sabt mishodan
        /// </summary>
        /// <param name="writers"></param>
        /// <returns></returns>
        public DBmessage RegisterPaperWriter(List<PaperWriter> writers)
        {
            DBmessage result = new DBmessage(DBMessageType.Error, SystemMessage_PaperInfoMan.EmptyPaperWriterError);
            if (writers != null && writers.Count != 0)
            {
                PaperWriter paperWriter = new PaperWriter();
                PaperWriterTable paperWriterTable = PaperWriterTable.Convert(writers);
                //
                paperWriter.Paper = new Paper();
                paperWriter.Paper.ID = writers[0].Paper.ID;
                result = paperWriter.Register(paperWriterTable);
            }
            return result;
        }
        public PaperInfo GetPaperInfo(int id)
        {
            PaperProcedures sp = new PaperProcedures();
            sp.Paper = new Paper() { ID = id };
            DataSet ds = sp.Get();
            PaperReport report = new PaperReport(PaperProcedures.ConvertToListPaperProcedures(ds.Tables[0], delegate (PaperProcedures p1) { return -1; }, 1),
                PaperWriter.ConvertToListPaperWriter(ds.Tables[1]), PaperProposedReferee.ConvertToListPaperProposedReferee(ds.Tables[2]));

            return report.Papers[0];
        }
        public DBmessage EditPaper(int paperID, int ownerUserID, string title, string Abstract, string refrence, string keyword, string whatOrginal
            , string whyOrginal, string whatMajor,string feilds, string ownerComment)
        {
            Paper paper = new Paper();
            paper.ID = paperID;
            paper.Owner = new Author();
            paper.Owner.User = new User_cls();
            paper.Owner.User.UserID = ownerUserID;
            paper.Title = title;
            paper.Abstracts = Abstract;
            paper.Reference = refrence;
            paper.Keyword = keyword;
            paper.WhatOrginal = whatOrginal;
            paper.WhyOrginal = whyOrginal;
            paper.WhatMajor = whatMajor;
            paper.Feilds = feilds;
            paper.OwnerComment = ownerComment;
            //
            return paper.Edit();
        }
        public PaperReport GetPaperList(int Id, int OwnerId, string Title, string Reference, string Keyword
         , string WhatOrginal, string WhyOrginal, string WhatMajor, Func<PaperProcedures, int> Compair, int numberforremove,int? editorid=null)
        {
            Paper myPaper = new Paper();
            myPaper.ID = Id;
            myPaper.Owner = new Author();
            myPaper.Owner.User = new User_cls();
            myPaper.Owner.User.UserID = OwnerId;
            if (Title == string.Empty)
                myPaper._title = Title;
            else
                myPaper.Title = Title;
            //if (Abstract == string.Empty)
            //    myPaper._abstracts = Abstract;
            //else
            //    myPaper.Abstracts = Abstract;
            if (Reference == string.Empty)
                myPaper._reference = Reference;
            else
                myPaper.Reference = Reference;
            if (Keyword == string.Empty)
                myPaper._keyword = Keyword;
            else
                myPaper.Keyword = Keyword;
            if (WhatOrginal == string.Empty)
                myPaper._whatOrginal = WhatOrginal;
            else
                myPaper.WhatOrginal = WhatOrginal;
            if (WhyOrginal == string.Empty)
                myPaper._whyOrginal = WhyOrginal;
            else
                myPaper.WhyOrginal = WhyOrginal;
            if (WhatMajor == string.Empty)
                myPaper._whyOrginal = WhyOrginal;
            else
                myPaper.WhatMajor = WhatMajor;
            ///
            DataTable dt = myPaper.GetList(editorid);
            PaperReport report = new PaperReport(PaperProcedures.ConvertToListPaperProcedures(dt, Compair, numberforremove));

            return report;
        }
        public DBmessage RegisterPaperProsedReferee(List<User_cls> users,int paperid)
        {
            PaperProposedReferee p = new PaperProposedReferee();
            p.Paper = new Paper() { ID = paperid };
            return  p.Register(UserTable.Convert(users));
        }
  
    }

}