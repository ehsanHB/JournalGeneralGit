using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PaperProcedures
/// </summary>
public class PaperProcedures : DBMan
{
    #region Attribute
    int _id;
    Paper _paper;
    PaperStatus _status;
    string _fileaddress;
    User_cls _creator;
    Position _as;
    PaperFileType _filetype;
    PersianDateTime _date;
    User_cls _another;
    int _version;
    string _comment;
    PersianDateTime _expDate;





    #endregion

    #region Property
    public int Version
    {
        get { return _version; }
        set { _version = value; }
    }
    public User_cls Another
    {
        get { return _another; }
        set { _another = value; }
    }
    public PaperFileType FileType
    {
        get { return _filetype; }
        set { _filetype = value; }
    }
    public Position As
    {
        get { return _as; }
        set { _as = value; }
    }
    public User_cls Creator
    {
        get { return _creator; }
        set { _creator = value; }
    }

    public string FileAddress
    {
        get { return _fileaddress; }
        set { _fileaddress = value; }
    }

    public PaperStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public Paper Paper
    {
        get { return _paper; }
        set { _paper = value; }
    }
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    public string Comment
    {
        get { return _comment; }
        set { _comment = value; }
    }
    /// <summary>
    /// tarikh engheza, momken ast baraye in paperproce tarikh engheza moshakhas konad
    /// </summary>
    public PersianDateTime ExpDate
    {
        get { return _expDate; }
        set { _expDate = value; }
    }
    #endregion

    public PaperProcedures()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DBmessage Register(PaperProcedureTable paperProcedure)
    {
        da = new SqlDataAdapter();
        dt = new DataTable();
        cmd = new SqlCommand("PaperProceduresRegister", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ////////
        SqlParameter _paperprocedure = new SqlParameter("@paperProcedure", SqlDbType.Structured);
        if (paperProcedure == null)
            _paperprocedure.Value = DBNull.Value;
        else
            _paperprocedure.Value = paperProcedure;

        /////////////////////
        cmd.Parameters.Add(_paperprocedure);
        cmd.Parameters.Add(RetunParam);
        //////////////////////
        conn.Open();
        da.SelectCommand = cmd;
        da.Fill(dt);
        conn.Close();
        DBmessage msg = new DBmessage((int)cmd.Parameters[RetunParam.ParameterName].Value);
        msg.Parameter["ProcIDs"] = dt;
        return msg;
    }
    public DataSet Get(IntTable Statustable = null, IntTable refereetable = null)
    {
        da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        cmd = new SqlCommand("PaperProcedureInfoGet", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //////////
        SqlParameter _Id = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.Paper == null || this.Paper.ID == 0)
            _Id.Value = DBNull.Value;
        else
            _Id.Value = this.Paper.ID;
        SqlParameter _status = new SqlParameter("@StatusID", SqlDbType.Structured);
        if (Statustable == null)
            _status.Value = new IntTable();
        else
            _status.Value = Statustable;
        SqlParameter _referee = new SqlParameter("@RefereeID", SqlDbType.Structured);
        if (refereetable == null)
            _referee.Value = new IntTable();
        else
            _referee.Value = refereetable;
        //////////
        cmd.Parameters.Add(_Id);
        cmd.Parameters.Add(_referee);
        cmd.Parameters.Add(_status);
        cmd.Parameters.Add(RetunParam);
        da.SelectCommand = cmd;
        //////////
        conn.Open();
        da.Fill(ds);
        conn.Close();
        return ds;
    }
    public DataTable GetForReferee(int refereeid)
    {
        da = new SqlDataAdapter();
        dt = new DataTable();
        cmd = new SqlCommand("PaperProcedurInfoGetForReferee", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //////////
        SqlParameter _Id = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.Paper == null || this.Paper.ID == 0)
            _Id.Value = DBNull.Value;
        else
            _Id.Value = this.Paper.ID;
        SqlParameter _referee = new SqlParameter("@RefereeID", SqlDbType.Int);
        if (refereeid == 0)
            _referee.Value = DBNull.Value;
        else
            _referee.Value = refereeid;

        //////////
        cmd.Parameters.Add(_Id);
        cmd.Parameters.Add(_referee);
        cmd.Parameters.Add(RetunParam);
        da.SelectCommand = cmd;
        //////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public DBmessage Delete(IntTable idlist)
    {
        cmd = new SqlCommand("PaperProceduresDelete", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ////////
        SqlParameter _idlist = new SqlParameter("@IDList", SqlDbType.Structured);
        if (idlist == null)
            _idlist.Value = DBNull.Value;
        else
            _idlist.Value = idlist;

        /////////////////////
        cmd.Parameters.Add(_idlist);
        cmd.Parameters.Add(RetunParam);
        //////////////////////
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        return new DBmessage((int)cmd.Parameters[RetunParam.ParameterName].Value);
    }
    #region static member
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt">data tabli ke bayad convert shavad</param>
    /// <param name="Compair"> arg1 un objecti hast ke har bar barresi mishavad </param>
    /// <param name="numberforremove">agar natije Compair che adadi bod un paperproc bayad hazf shavad</param>
    /// <returns></returns>
    public static List<PaperProcedures> ConvertToListPaperProcedures(DataTable dt, Func<PaperProcedures, int> Compair, int numberforremove)
    {
        List<PaperProcedures> result = new List<PaperProcedures>();
        int lastindex = 0;
        if (dt == null || dt.Rows.Count == 0)
            return result;
        foreach (DataRow item in dt.Rows)
        {
            result.Add(new PaperProcedures());
            if (dt.Columns.Contains("PaperID") && item["PaperID"] != DBNull.Value)
            {
                if (lastindex > 0 && result[lastindex - 1].Paper.ID == int.Parse(item["PaperID"].ToString()))
                    result[lastindex].Paper = result[lastindex - 1].Paper;
                else
                {
                    result[lastindex].Paper = new Paper();
                    result[lastindex].Paper.ID = int.Parse(item["PaperID"].ToString());
                    if (dt.Columns.Contains("PaperOwnerId") && item["PaperOwnerId"] != DBNull.Value)
                    {
                        if (result[lastindex].Paper.Owner == null)
                            result[lastindex].Paper.Owner = new Author();
                        if (result[lastindex].Paper.Owner.User == null)
                            result[lastindex].Paper.Owner.User = new User_cls();
                        result[lastindex].Paper.Owner.User.UserID = Convert.ToInt32(item["PaperOwnerId"]);
                    }
                    if (dt.Columns.Contains("PaperOwnerFullName") && item["PaperOwnerFullName"] != DBNull.Value)
                    {
                        if (result[lastindex].Paper.Owner == null)
                            result[lastindex].Paper.Owner = new Author();
                        if (result[lastindex].Paper.Owner.User == null)
                            result[lastindex].Paper.Owner.User = new User_cls();
                        result[lastindex].Paper.Owner.User.FullName = item["PaperOwnerFullName"].ToString();
                    }
                    if (dt.Columns.Contains("PaperTitle") && item["PaperTitle"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Title = item["PaperTitle"].ToString();
                    }
                    if (dt.Columns.Contains("PaperAbstracts") && item["PaperAbstracts"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Abstracts = item["PaperAbstracts"].ToString();
                    }
                    if (dt.Columns.Contains("PaperReference") && item["PaperReference"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Reference = item["PaperReference"].ToString();
                    }
                    if (dt.Columns.Contains("PaperKeyword") && item["PaperKeyword"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Keyword = item["PaperKeyword"].ToString();
                    }
                    if (dt.Columns.Contains("PaperWhatOrginal") && item["PaperWhatOrginal"] != DBNull.Value)
                    {
                        result[lastindex].Paper.WhatOrginal = item["PaperWhatOrginal"].ToString();
                    }
                    if (dt.Columns.Contains("PaperWhyOrginal") && item["PaperWhyOrginal"] != DBNull.Value)
                    {
                        result[lastindex].Paper.WhyOrginal = item["PaperWhyOrginal"].ToString();
                    }
                    if (dt.Columns.Contains("PaperWhyOrginal") && item["PaperWhyOrginal"] != DBNull.Value)
                    {
                        result[lastindex].Paper.WhyOrginal = item["PaperWhyOrginal"].ToString();
                    }
                    if (dt.Columns.Contains("PaperWhatMajor") && item["PaperWhatMajor"] != DBNull.Value)
                    {
                        result[lastindex].Paper.WhatMajor = item["PaperWhatMajor"].ToString();
                    }
                    if (dt.Columns.Contains("PaperFeilds") && item["PaperFeilds"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Feilds = item["PaperFeilds"].ToString();
                    }
                    if (dt.Columns.Contains("PaperDate") && item["PaperDate"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Date = new PersianDateTime(Convert.ToDateTime(item["PaperDate"]));
                    }
                    if (dt.Columns.Contains("PaperDate") && item["PaperDate"] != DBNull.Value)
                    {
                        result[lastindex].Paper.Date = new PersianDateTime(Convert.ToDateTime(item["PaperDate"]));
                    }
                }
            }
            if (dt.Columns.Contains("PaperProceduresID") && item["PaperProceduresID"] != DBNull.Value)
            {
                result[lastindex].ID = int.Parse(item["PaperProceduresID"].ToString());
            }
            if (dt.Columns.Contains("PaperProceduresStatus") && item["PaperProceduresStatus"] != DBNull.Value)
            {
                if (result[lastindex].Status == null)
                    result[lastindex].Status = new PaperStatus();
                result[lastindex].Status.ID = int.Parse(item["PaperProceduresStatus"].ToString());
            }
            if (dt.Columns.Contains("PaperProceduresFileAddress") && item["PaperProceduresFileAddress"] != DBNull.Value)
            {
                result[lastindex].FileAddress = item["PaperProceduresFileAddress"].ToString();
            }
            if (dt.Columns.Contains("PaperProceduresCreatorID") && item["PaperProceduresCreatorID"] != DBNull.Value)
            {
                if (result[lastindex].Creator == null)
                    result[lastindex].Creator = new User_cls();
                result[lastindex].Creator.UserID = int.Parse(item["PaperProceduresCreatorID"].ToString());
            }
            if (dt.Columns.Contains("PaperProceduresCreatorFullName") && item["PaperProceduresCreatorFullName"] != DBNull.Value)
            {
                if (result[lastindex].Creator == null)
                    result[lastindex].Creator = new User_cls();
                result[lastindex].Creator.FullName = item["PaperProceduresCreatorFullName"].ToString();
            }
            if (dt.Columns.Contains("PaperProceduresAnotherUserEmail") && item["PaperProceduresAnotherUserEmail"] != DBNull.Value)
            {
                if (result[lastindex].Another == null)
                    result[lastindex].Another = new User_cls();
                result[lastindex].Another.Email = item["PaperProceduresAnotherUserEmail"].ToString();
            }
            if (dt.Columns.Contains("PaperProceduresDate") && item["PaperProceduresDate"] != DBNull.Value)
            {
                result[lastindex].Date = new PersianDateTime(Convert.ToDateTime(item["PaperProceduresDate"]));
            }
            if (dt.Columns.Contains("PaperProceduresAs") && item["PaperProceduresAs"] != DBNull.Value)
            {
                if (result[lastindex].As == null)
                    result[lastindex].As = new Position();
                result[lastindex].As.ID = int.Parse(item["PaperProceduresAs"].ToString());
            }
            if (dt.Columns.Contains("PaperProceduresFileType") && item["PaperProceduresFileType"] != DBNull.Value)
            {
                if (result[lastindex].FileType == null)
                    result[lastindex].FileType = new PaperFileType();
                result[lastindex].FileType.ID = int.Parse(item["PaperProceduresFileType"].ToString());
            }
            if (dt.Columns.Contains("PaperProceduresAnotherUserFullName") && !DBNull.Value.Equals(item["PaperProceduresAnotherUserFullName"]))
            {
                if (result[lastindex].Another == null)
                    result[lastindex].Another = new User_cls();
                result[lastindex].Another.FullName = item["PaperProceduresAnotherUserFullName"].ToString();
            }
            if (dt.Columns.Contains("PaperProceduresAnotherUserID") && !DBNull.Value.Equals(item["PaperProceduresAnotherUserID"]))
            {
                if (result[lastindex].Another == null)
                    result[lastindex].Another = new User_cls();
                result[lastindex].Another.UserID = Convert.ToInt32(item["PaperProceduresAnotherUserID"]);
            }
            if (dt.Columns.Contains("PaperProceduresVersion") && !DBNull.Value.Equals(item["PaperProceduresVersion"]))
            {
                result[lastindex].Version = Convert.ToInt32(item["PaperProceduresVersion"]);

            }
            if (dt.Columns.Contains("PaperProceduresComment") && !DBNull.Value.Equals(item["PaperProceduresComment"]))
            {
                result[lastindex].Comment = item["PaperProceduresComment"].ToString();

            }
            if (dt.Columns.Contains("PaperProceduresExpDate") && !DBNull.Value.Equals(item["PaperProceduresExpDate"]))
            {
                result[lastindex].ExpDate = new PersianDateTime(Convert.ToDateTime(item["PaperProceduresExpDate"]));
            }
            if (Compair(result[lastindex]) == numberforremove)
                result.RemoveAt(lastindex);
            lastindex = result.Count;

        }
        return result;
    }
    #endregion

}
public class PaperStatus
{
    public PaperStatus()
    { }
    public PaperStatus(int id)
    {
        this.ID = id;
    }

    int _id;
    string _name;
    int _index;
    /// <summary>
    /// neshandahande in ast ke chandomin marhale az kar ast
    /// </summary>
    public int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            _id = PaperStatus.Convert(value);
            _name = value;
        }
    }
    public int ID
    {
        get { return _id; }
        set
        {
            _name = PaperStatus.Convert(value);
            _index = GetIndex(value);
            _id = value;
        }
    }

    public static int Convert(string name)
    {
        switch (name)
        {
            case "new":
                return 1;
            case "Accept by admin":
                return 2;
            case "Reject by admin":
                return 3;
            case "Reject by editor":
                return 4;
            case "Pending acception by referee":
                return 5;
            case "Reject by referee":
                return 6;
            case "Accept by referee":
                return 7;
            case "Remove Referee":
                return 8;
            case "Evaluated by referee":
                return 9;
            case "Final Accept":
                return 10;
            case "Revise":
                return 11;
            case "Revise By Author":
                return 12;
            case "Preparing step 1":
                return 13;
            case "Preparing step 2":
                return 14;
            case "Preparing step 3":
                return 15;
            case "Select Editor":
                return 16;
            case "Revise By Author Step 1":
                return 17;
            case "Revise By Author Step 2":
                return 18;
            case "Revise By Author Step 3":
                return 19;
            case "Technical Approval":
                return 20;
            case "Select Langueg Editor":
                return 21;
            case "Verify Language Editor":
                return 22;
            case "Disapproval Language Editor":
                return 23;
            case "Delivery of the edited file":
                return 24;
            case "Confrimation language editting":
                return 25;
            case "Disapproval language editting":
                return 26;
            case "In Evaluating":
                return 100;
            case "In Older Version":
                return 101;
            default: throw new Exception("invalid paperstatus name");
        }
    }
    public static int GetIndex(int id)
    {
        switch (id)
        {
            case 1:
                return 4;
            case 2:
                return 6;
            case 3:
                return 5;
            case 4:
                return 7;
            case 5:
                return 8;
            case 6:
                return 9;
            case 7:
                return 10;
            case 8:
                return 11;
            case 9:
                return 12;
            case 10:
                return 13;
            case 11:
                return 14;
            case 12:
                return 15;
            case 13:
                return 1;
            case 14:
                return 2;
            case 15:
                return 3;
            case 16:
                return 16;
            case 17:
                return 17;
            case 18:
                return 18;
            case 19:
                return 19;
            case 20:
                return 20;
            case 21:
                return 21;
            case 22:
                return 22;
            case 23:
                return 23;
            case 24:
                return 24;
            case 25:
                return 25;
            case 26:
                return 26;
            case 100:
                return 17;
            case 101:
                return 18;
            default: throw new Exception("invalid paperstatus id");
        }
    }
    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return "new";
            case 2:
                return "Accept by chef editor";
            case 3:
                return "Reject by chef editor";
            case 4:
                return "Reject by editor";
            case 5:
                return "Pending acception by referee";
            case 6:
                return "Reject by referee";
            case 7:
                return "Accept by referee";
            case 8:
                return "Remove Referee";
            case 9:
                return "Evaluated by referee";
            case 10:
                return "Final Accept";
            case 11:
                return "Revise";
            case 12:
                return "Revise By Author";
            case 13:
                return "Preparing step 1";
            case 14:
                return "Preparing step 2";
            case 15:
                return "Preparing step 3";
            case 16:
                return "Select Editor";
            case 17:
                return "Revise By Author Step 1";
            case 18:
                return "Revise By Author Step 2";
            case 19:
                return "Revised By Author";
            case 20:
                return "Technical Approval";
            case 21:
                return "Select Langueg Editor";
            case 22:
                return "Verify Language Editor";
            case 23:
                return "Disapproval Language Editor";
            case 24:
                return "Delivery of the edited file";
            case 25:
                return "Confrimation Language Editting";
            case 26:
                return "Disapproval Language Editting";
            
            case 100:
                return "In Evaluating";
            case 101:
                return "In Older Version";
            default: throw new Exception("invalid paperstatus id");
        }
    }

    #region static member
    /// <summary>
    /// marhale aval sabte maghale
    /// </summary>
    public static int Preparing_step1
    {
        get { return 13; }
    }
    /// <summary>
    /// marhale dovome sabte maghale
    /// </summary>
    public static int Preparing_step2
    {
        get { return 14; }
    }
    /// <summary>
    /// marhale sevom sabte maghale
    /// </summary>
    public static int Preparing_step3
    {
        get { return 15; }
    }
    /// <summary>
    /// pas az anjame marhale 4 sabte maghale, maghale be status new miravad
    /// </summary>
    public static int New
    {
        get { return 1; }
    }
    /// <summary>
    /// tayide avaliye maghale jadid
    /// </summary>
    public static int AcceptByChefEditor
    {
        get { return 2; }
    }
    /// <summary>
    /// rade maghale
    /// </summary>
    public static int RejectByChefEditor
    {
        get { return 3; }
    }
    /// <summary>
    /// entekhabe editor baraye maghale
    /// </summary>
    public static int SelectEditor
    {
        get
        {
            return 16;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static int RejectByEditor
    {
        get { return 4; }
    }
    /// <summary>
    /// entekhabe davar
    /// </summary>
    public static int SelectRefree
    {
        get { return 5; }
    }
    /// <summary>
    /// adame tayide davariye in maghale
    /// </summary>
    public static int RejectByReferee
    {
        get { return 6; }
    }
    /// <summary>
    /// tayide davariye in maghale
    /// </summary>
    public static int AcceptByReferee
    {
        get { return 7; }
    }
    /// <summary>
    /// hazfe davare entekhab shode
    /// </summary>
    public static int RemoveReferee
    {
        get { return 8; }
    }
    /// <summary>
    /// nazar sanji shode tavasote davar
    /// </summary>
    public static int EvaluatedByReferee
    {
        get { return 9; }
    }
    /// <summary>
    /// revise maghale tavasote author marhale 1
    /// </summary>
    public static int ReviseByAuthor_Step1
    {
        get { return 17; }
    }
    /// <summary>
    /// revise maghale tavasote author marhale 2
    /// </summary>
    public static int ReviseByAuthor_Step2
    {
        get { return 18; }
    }
    /// <summary>
    /// revise maghale tavasote author marhale 3
    /// </summary>
    public static int ReviseByAuthor_Step3
    {
        get { return 19; }
    }
    /// <summary>
    /// tayide fani maghale  
    /// </summary>
    public static int TechnicalApproval
    {
        get { return 20; }
    }
    /// <summary>
    /// tayide virayeshe zabani tavasote language editor
    /// </summary>
    public static int VerifyLanguageEditor
    {
        get { return 22; }
    }
    /// <summary>
    /// rade virayeshe zabani tavasote language editor
    /// </summary>
    public static int DisapprovalLanguageEditor
    {
        get { return 23; }
    }
    /// <summary>
    /// daryafte file virayesh shode
    /// </summary>
    public static int DeliveryOfTheEditedFile
    {
        get { return 24; }
    }
    /// <summary>
    /// tayide file virayesh shode
    /// </summary>
    public static int ConfrimationLanguageEditting
    {
        get { return 25; }
    }
    /// <summary>
    /// radde file virayesh shode  
    /// </summary>
    public static int DisapprovalLanguageEditting
    {
        get { return 26; }
    }
    /// <summary>
    /// tayide nahayi maghale
    /// </summary>
    public static int FinalAcceptByEditor
    {
        get { return 10; }
    }
    /// <summary>
    /// revise tavasote editor barayr in maghale
    /// </summary>
    public static int ReviseByEditor
    { get { return 11; } }
    

    public static int InEvaluating_FakeStatus
    {
        get { return 100; }
    }
    public static int SelectLanguegEditor { get { return 21; } }
    public static int InOlderVersion_FakeStatus
    {
        get { return 101; }
    }


    #endregion
}
public class PaperFileType
{
    public PaperFileType()
    { }
    public PaperFileType(int id)
    {
        this.ID = id;
    }
    int id;
    string _title;

    public string Title
    {
        get { return _title; }
        // set { _title = value; }
    }
    public int ID
    {
        get { return id; }
        set
        {
            _title = PaperFileType.Convert(value);
            id = value;
        }
    }

    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return "Word File";
            case 2:
                return "Pdf File";
            case 3:
                return "Figures";
            case 4:
                return "Tables";
            case 5:
                return "Suported Doc";
            case 6:
                return "EvaluatedDoc";
            default: throw new Exception("invalid paperstatus id");
        }
    }


    public static int WordFile
    { get { return 1; } }
    public static int PdfFile
    { get { return 2; } }
    public static int Figures
    { get { return 3; } }
    public static int Tables
    { get { return 4; } }
    public static int SuportedDoc
    { get { return 5; } }
    public static int EvaluatedDoc
    { get { return 6; } }
}
public class PaperProcedureTable : DataTable
{
    public PaperProcedureTable()
    {
        this.Columns.Add("PaperID");
        this.Columns.Add("Status");
        this.Columns.Add("FileAdress");
        this.Columns.Add("CreatorID");
        this.Columns.Add("As");
        this.Columns.Add("FileType");
        this.Columns.Add("AnotherUserID");
        this.Columns.Add("Version");
        this.Columns.Add("Comment");
        this.Columns.Add("ExpDate");
    }
    public static PaperProcedureTable ConvertToPaperProcedureTable(List<PaperProcedures> paperProcedureList)
    {
        PaperProcedureTable paperProcedureTable = new PaperProcedureTable();
        List<object> expdate = new List<object>();

        foreach (PaperProcedures item in paperProcedureList)
        {
            if (item.ExpDate == null)
                expdate.Add(null);
            else
                expdate.Add(item.ExpDate.Datetime);
            paperProcedureTable.Rows.Add(item.Paper != null ? item.Paper.ID : 0, item.Status != null ? item.Status.ID : 0, item.FileAddress, item.Creator != null ? item.Creator.UserID : 0, item.As != null ? item.As.ID : 0, item.FileType != null ? item.FileType.ID : 0, item.Another != null ? item.Another.UserID : 0, item.Version, item.Comment != string.Empty ? item.Comment : null, expdate[expdate.Count - 1]);
        }
        return paperProcedureTable;
    }
}