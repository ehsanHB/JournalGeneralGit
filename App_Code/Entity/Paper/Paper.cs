using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Paper : DBMan
{
    #region//VALUES

    public int _id;
    public string _title;
    public string _abstracts;
    public string _reference;
    public string _keyword;
    public string _whatOrginal;
    public string _whyOrginal;
    public string _whatMajor;
    public PersianDateTime _date;
    public Author _owner;
    public string _ownerComment;
    public string _feilds;
    #endregion

    #region//PROPERTY

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Title
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 100)
            {
                MyException ex = new MyException(PaperTxt.TitleGraterThan, 101, "Paper.Title");
                throw ex;
            }
            else if (value == "")
            {
                MyException ex = new MyException(PaperTxt.TitleCantNull, 102, "Paper.Title");
                throw ex;
            }
            _title = value;
        }
        get { return _title; }
    }
    public string Abstracts
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.AbstractsGraterThan, 101, "Paper.Abstracts");
                throw ex;
            }
            else if (value == "")
            {
                MyException ex = new MyException(PaperTxt.AbstractsCantNull, 102, "Paper.Abstracts");
                throw ex;
            }
            _abstracts = value;
        }
        get { return _abstracts; }
    }
    public string Reference
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.ReferenceGraterThan, 101, "Paper.Reference");
                throw ex;
            }

            _reference = value;
        }
        get { return _reference; }
    }
    public string Keyword
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.KeywordGraterThan, 101, "Paper.Keyword");
                throw ex;
            }
            else if (value == "")
            {
                MyException ex = new MyException(PaperTxt.KeywordCantNull, 102, "Paper.Keyword");
                throw ex;
            }
            _keyword = value;
        }
        get { return _keyword; }
    }
    public string WhatOrginal
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.WhatOrginalCantNull, 101, "Paper.WhatOrginal");
                throw ex;
            }
            _whatOrginal = value;
        }
        get { return _whatOrginal; }
    }
    public string WhyOrginal
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.WhyOrginalGraterThan, 101, "Paper.WhyOrginal");
                throw ex;
            }
            _whyOrginal = value;
        }
        get { return _whyOrginal; }
    }
    public string WhatMajor
    {
        set
        {
            if (value == null)
                value = string.Empty;
            value = value.Trim();
            if (value.Length >= 200)
            {
                MyException ex = new MyException(PaperTxt.WhatMajorGraterThan, 101, "Paper.WhatMajor");
                throw ex;
            }
            _whatMajor = value;
        }
        get { return _whatMajor; }
    }
    public PersianDateTime Date
    {
        set
        {
            _date = value;
        }
        get { return _date; }
    }
    public Author Owner
    {
        set
        {
            _owner = value;
        }
        get { return _owner; }
    }
    public string OwnerComment
    {
        set
        {
            _ownerComment = value;
        }
        get { return _ownerComment; }
    }
    public string Feilds
    {
        set
        {
            _feilds = value;
        }
        get { return _feilds; }
    }
    #endregion

    #region//FUNCTION

    public Paper()
    {
        //_author = new string[6];
        //_reviewer = new Reviewer[5];
        //_date = new PersianDateTime();
        //_field = new Field();
        //_owner = new Author();

    }

    //public string SetId()
    //{
    //    Random r = new Random();
    //    Id = DateTime.Now.Year.ToString();
    //    Id += DateTime.Now.Month.ToString();
    //    Id += DateTime.Now.Day.ToString();
    //    Id += DateTime.Now.Hour.ToString();
    //    Id += DateTime.Now.Minute.ToString();
    //    Id += DateTime.Now.Second.ToString();
    //    Id += DateTime.Now.Millisecond.ToString();
    //    Id += r.Next(10001, 99999).ToString();
    //    return Id;
    //}
    /// <summary>
    /// sabte yek maghale , dar attribute id meghdar id sabt shode vared mishavad
    /// </summary>
    /// <returns></returns>
    public DBmessage Register()
    {
        cmd = new SqlCommand("PaperRegister", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///////////////////////////////
        SqlParameter ownerId = new SqlParameter("@OwnerId", SqlDbType.Int);
        if (this.Owner == null)
            ownerId.Value = DBNull.Value;
        else
            ownerId.Value = this.Owner.User.UserID;
        //
        SqlParameter title = new SqlParameter("@Title", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Title))
            title.Value = DBNull.Value;
        else
            title.Value = this.Title;
        //
        SqlParameter abstracts = new SqlParameter("@Abstracts", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Abstracts))
            abstracts.Value = DBNull.Value;
        else
            abstracts.Value = this.Abstracts;
        //
        SqlParameter reference = new SqlParameter("@Reference", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Reference))
            reference.Value = DBNull.Value;
        else
            reference.Value = this.Reference;
        //
        SqlParameter keyword = new SqlParameter("@Keyword", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Keyword))
            keyword.Value = DBNull.Value;
        else
            keyword.Value = this.Keyword;
        //
        SqlParameter whatOrginal = new SqlParameter("@WhatOrginal", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.WhatOrginal))
            whatOrginal.Value = DBNull.Value;
        else
            whatOrginal.Value = this.WhatOrginal;
        //
        SqlParameter whyOrginal = new SqlParameter("@WhyOrginal", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.WhyOrginal))
            whyOrginal.Value = DBNull.Value;
        else
            whyOrginal.Value = this.WhyOrginal;
        //
        SqlParameter whatMajor = new SqlParameter("@WhatMajor", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.WhatMajor))
            whatMajor.Value = DBNull.Value;
        else
            whatMajor.Value = this.WhatMajor;
        //
        SqlParameter Feilds = new SqlParameter("@feilds", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.Feilds))
            Feilds.Value = DBNull.Value;
        else
            Feilds.Value = this._feilds;
        SqlParameter _paperid = new SqlParameter("@PaperID", SqlDbType.Int);
        _paperid.Direction = ParameterDirection.Output;
        ////////////////////////
        cmd.Parameters.Add(ownerId);
        cmd.Parameters.Add(title);
        cmd.Parameters.Add(abstracts);
        cmd.Parameters.Add(reference);
        cmd.Parameters.Add(keyword);
        cmd.Parameters.Add(whatOrginal);
        cmd.Parameters.Add(whyOrginal);
        cmd.Parameters.Add(whatMajor);
        cmd.Parameters.Add(Feilds);
        cmd.Parameters.Add(_paperid);
        cmd.Parameters.Add(RetunParam);
        ///////////////////////////
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        this._id = Convert.ToInt32(cmd.Parameters[_paperid.ParameterName].Value);
        return ResultMessage = new DBmessage(Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    }

    public DataTable GetList(int? editorid=null)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        dt = new DataTable();
        cmd = new SqlCommand("PaperListGet", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //////////
        SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
        if (this.ID == 0)
            Id.Value = DBNull.Value;
        else
            Id.Value = this._id;
        //////////
        SqlParameter ownerId = new SqlParameter("@OwnerId", SqlDbType.Int);
        if (this.Owner == null || this.Owner.User == null || this.Owner.User.UserID == 0)
            ownerId.Value = DBNull.Value;
        else
            ownerId.Value = this.Owner.User.UserID;
        /////////
        SqlParameter title = new SqlParameter("@Title", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.Title))
            title.Value = DBNull.Value;
        else
            title.Value = this._title;
        /////////
        //SqlParameter Abstract = new SqlParameter("@Abstract", SqlDbType.NVarChar);
        //if (string.IsNullOrEmpty(this.Abstracts ))
        //    Id.Value = DBNull.Value;
        //else
        //    Id.Value = this.Abstracts;
        /////////
        SqlParameter reference = new SqlParameter("@Reference", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.Reference))
            reference.Value = DBNull.Value;
        else
            reference.Value = this._reference;
        /////////
        SqlParameter keyword = new SqlParameter("@Keyword", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.Keyword))
            keyword.Value = DBNull.Value;
        else
            keyword.Value = this._keyword;
        //////////
        SqlParameter whatOrginal = new SqlParameter("@WhatOrginal", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.WhatOrginal))
            whatOrginal.Value = DBNull.Value;
        else
            whatOrginal.Value = this._whatOrginal;
        //////////
        SqlParameter whyOrginal = new SqlParameter("@WhyOrginal", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.WhyOrginal))
            whyOrginal.Value = DBNull.Value;
        else
            whyOrginal.Value = this._whyOrginal;
        //
        SqlParameter whatMajor = new SqlParameter("@WhatMajor", SqlDbType.NVarChar);
        if (string.IsNullOrEmpty(this.WhatMajor))
            whatMajor.Value = DBNull.Value;
        else
            whatMajor.Value = this._whatMajor;
        SqlParameter _editorid = new SqlParameter("@EditorID", SqlDbType.Int);
        if (editorid.HasValue)
            _editorid.Value = editorid.Value;
        else
            _editorid.Value = DBNull.Value;
        //////////
        cmd.Parameters.Add(Id);
        cmd.Parameters.Add(ownerId);
        cmd.Parameters.Add(title);
        //cmd.Parameters.Add(Abstracts);
        cmd.Parameters.Add(reference);
        cmd.Parameters.Add(keyword);
        cmd.Parameters.Add(whatOrginal);
        cmd.Parameters.Add(whyOrginal);
        cmd.Parameters.Add(whatMajor);
        cmd.Parameters.Add(_editorid);
        cmd.Parameters.Add(RetunParam);
        da.SelectCommand = cmd;
        //////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public DBmessage Delete()
    {
        cmd = new SqlCommand("PaperDelete", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter paperId = new SqlParameter("@PaperID", SqlDbType.Int);
        paperId.Value = this.ID;
        cmd.Parameters.Add(RetunParam);
        ///////////////////////////////
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        ResultMessage = new DBmessage(Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    public DBmessage Edit()
    {
        conn = new SqlConnection(SysProperty.Jurnaldb);
        cmd = new SqlCommand("[PaperEdit]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        //////////
        SqlParameter _Id = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.ID == 0)
            _Id.Value = DBNull.Value;
        else
            _Id.Value = this._id;
        //////////
        SqlParameter _ownerId = new SqlParameter("@OwnerID", SqlDbType.Int);
        if (this.Owner == null || this.Owner.User == null || this.Owner.User.UserID == 0)
            _ownerId.Value = DBNull.Value;
        else
            _ownerId.Value = this.Owner.User.UserID;
        /////////
        SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar,100);
        if (string.IsNullOrEmpty(this.Title))
            _title.Value = DBNull.Value;
        else
            _title.Value = this._title;
        /////////
        SqlParameter _Abstract = new SqlParameter("@Abstract", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.Abstracts))
            _Abstract.Value = DBNull.Value;
        else
            _Abstract.Value = this._abstracts;
        /////////
        SqlParameter _reference = new SqlParameter("@Refrence", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.Reference))
            _reference.Value = DBNull.Value;
        else
            _reference.Value = this._reference;
        /////////
        SqlParameter _keyword = new SqlParameter("@Keyword", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.Keyword))
            _keyword.Value = DBNull.Value;
        else
            _keyword.Value = this._keyword;
        //////////
        SqlParameter _whatOrginal = new SqlParameter("@WhatOrginal", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.WhatOrginal))
            _whatOrginal.Value = DBNull.Value;
        else
            _whatOrginal.Value = this._whatOrginal;
        //////////
        SqlParameter _whyOrginal = new SqlParameter("@WhyOrginal", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.WhyOrginal))
            _whyOrginal.Value = DBNull.Value;
        else
            _whyOrginal.Value = this._whyOrginal;
        //
        SqlParameter _whatMajor = new SqlParameter("@WhatMajor", SqlDbType.NVarChar,200);
        if (string.IsNullOrEmpty(this.WhatMajor))
            _whatMajor.Value = DBNull.Value;
        else
            _whatMajor.Value = this._whatMajor;
        //
        SqlParameter _OwnerComment = new SqlParameter("@OwnerComment", SqlDbType.NVarChar,100000);
        if (string.IsNullOrEmpty(this.OwnerComment))
            _OwnerComment.Value = DBNull.Value;
        else
            _OwnerComment.Value = this._ownerComment;
        //
        SqlParameter _Feilds = new SqlParameter("@feilds", SqlDbType.NVarChar,100000);
        if (string.IsNullOrEmpty(this.Feilds))
            _Feilds.Value = DBNull.Value;
        else
            _Feilds.Value = this._feilds;
        //////////
        cmd.Parameters.Add(_Id);
        cmd.Parameters.Add(_ownerId);
        cmd.Parameters.Add(_title); 
        cmd.Parameters.Add(_Abstract);
        cmd.Parameters.Add(_reference);
        cmd.Parameters.Add(_keyword);
        cmd.Parameters.Add(_whatOrginal);
        cmd.Parameters.Add(_whyOrginal);
        cmd.Parameters.Add(_whatMajor);
        cmd.Parameters.Add(_OwnerComment);
        cmd.Parameters.Add(_Feilds);
        cmd.Parameters.Add(RetunParam);
        //////////
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        //////////
        ResultMessage = new DBmessage(Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    #endregion
}


class PaperTxt
{
    /// <summary>
    /// txti ke be karbr dar morede tole in propery dade mishavad
    /// </summary>
    public static string TitleGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 100 characters are allowed for Title";
            }
            else
            {
                return "";
            }
        }
    }
    public static string TitleCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Title Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\//////////////////////
    public static string AbstractsGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for Abstracts";
            }
            else
            {
                return "";
            }
        }
    }

    public static string AbstractsCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Abstracts Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\/////////////////////////////////////
    public static string ReferenceGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for Reference";
            }
            else
            {
                return "";
            }
        }
    }

    public static string ReferenceCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Reference Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\////////////////////////////////////
    public static string KeywordGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for Keyword";
            }
            else
            {
                return "";
            }
        }
    }

    public static string KeywordCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Keyword Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\//////////////////////
    public static string WhatOrginalGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for WhatOrginal";
            }
            else
            {
                return "";
            }
        }
    }

    public static string WhatOrginalCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "WhatOrginal Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\/////////////////////////////////
    public static string WhyOrginalGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for WhyOrginal";
            }
            else
            {
                return "";
            }
        }
    }

    public static string WhyOrginalCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "WhyOrginal Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    //\/////////////////////////////////
    public static string WhatMajorGraterThan
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Max 200 characters are allowed for WhatOrginal";
            }
            else
            {
                return "";
            }
        }
    }

    public static string WhatMajorCantNull
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "WhatOrginal Must be Filled";
            }
            else
            {
                return "";
            }
        }
    }
    ///////////////////////////////////
    //public static string StatusInvalidValue
    //{
    //    get
    //    {
    //        if (SysProperty.SiteLanguage == Languages.English)
    //        {
    //            return "invalid value";
    //        }
    //        else
    //        {
    //            return "";
    //        }
    //    }
    //}
    ///////////////////////////////////
    public static string DateIllegal
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "Illegal to assign Date.";
            }
            else
            {
                return "";
            }
        }
    }
    //\/////////////////////////////////


}