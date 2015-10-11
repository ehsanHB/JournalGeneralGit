using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Author
/// </summary>
public class Author : DBMan
{
    public Author()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region //attribute
    /// <summary>
    /// Author id
    /// </summary>
    private int _id;
    private string _title;
    private string _institu;
    private string _department;
    private string _prof;
    private PersianDateTime _date;
    private User_cls _user;//!!!
    //string _country;
    //int _no;
    //Field _field; 
    #endregion attribute
    #region //Property

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }


    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Institu
    {
        get { return _institu; }
        set { _institu = value; }
    }

    public string Department
    {
        get { return _department; }
        set { _department = value; }
    }

    public string Prof
    {
        get { return _prof; }
        set { _prof = value; }
    }
    /// <summary>
    /// tarikhe sabte in fard
    /// </summary>
    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public User_cls User
    {
        get { return _user; }
        set { _user = value; }
    }

    #endregion Property
    public DataTable Get(int active = 0)
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("AuthorGet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////////
        SqlParameter _active = new SqlParameter("@Active", SqlDbType.Bit);
        if (active == 0)
            _active.Value = DBNull.Value;
        else if (active == 1)
            _active.Value = 1;
        else if (active == 2)
            _active.Value = 0;
        /////////////////////
        da.SelectCommand.Parameters.Add(_active);
        da.SelectCommand.Parameters.Add(RetunParam);
        ////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        /////////////
        return dt;
    }
    public DataTable InfoGet()
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("AuthorInfoGet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////////
        SqlParameter _id = new SqlParameter("@usrID", SqlDbType.Int);
        _id.Value = this.User.UserID;
        /////////////////////
        da.SelectCommand.Parameters.Add(_id);
        da.SelectCommand.Parameters.Add(RetunParam);
        ////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        /////////////
        return dt;
    }
    public DBmessage Register()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("AuthorRegister", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        /////////////////////////
        SqlParameter _userId = new SqlParameter("@UsrID", SqlDbType.Int) { Value = User.UserID };
        SqlParameter _title = new SqlParameter("@Title", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Title))
            _title.Value = DBNull.Value;
        else
            _title.Value = this.Title;
        SqlParameter _institu = new SqlParameter("@Institu", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Institu))
            _institu.Value = DBNull.Value;
        else
            _institu.Value = this.Institu;
        SqlParameter _department = new SqlParameter("@Department", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Department))
            _department.Value = DBNull.Value;
        else
            _department.Value = this.Department;
        SqlParameter _prof = new SqlParameter("@Prof", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Prof))
            _prof.Value = DBNull.Value;
        else
            _prof.Value = this.Prof;
        //
        newcmd.Parameters.Add(_userId);
        newcmd.Parameters.Add(_title);
        newcmd.Parameters.Add(_institu);
        newcmd.Parameters.Add(_department);
        newcmd.Parameters.Add(_prof);
        newcmd.Parameters.Add(RetunParam);
        //
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    /// <summary>
    /// hazfe ye author
    /// </summary>
    /// <returns></returns>
    public DBmessage Delete()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("AuthorDelete", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter _authorId = new SqlParameter("@AuthorID", SqlDbType.Int);
        if (this.ID == 0)
            _authorId.Value = DBNull.Value;
        else
            _authorId.Value = this.ID;

        SqlParameter _userId = new SqlParameter("@UserID", SqlDbType.Int);
        if (this.User == null || this.User.UserID == 0)
            _userId.Value = DBNull.Value;
        else
            _userId.Value = this.User.UserID;
        //////////////////
        newcmd.Parameters.Add(_authorId);
        newcmd.Parameters.Add(_userId);
        newcmd.Parameters.Add(RetunParam);
        ////////////////////
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ///////////////
        return new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
    }
    #region static member
    public static Author Convert(DataTable dt)
    {
        Author author = new Author();
        if (dt.Rows.Count > 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["ID"]))
                author.ID = System.Convert.ToInt32(dt.Rows[0]["ID"]);
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["UserID"]))
            {
                author.User = new User_cls();
                author.User.UserID = System.Convert.ToInt32(dt.Rows[0]["UserID"]);
            }
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Title"]))
                author.Title = dt.Rows[0]["Title"].ToString();
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Institu"]))
                author.Institu = dt.Rows[0]["Institu"].ToString();
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Department"]))
                author.Department = dt.Rows[0]["Department"].ToString();
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Prof"]))
                author.Prof = dt.Rows[0]["Prof"].ToString();
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Date"]))
                author.Date = new PersianDateTime(System.Convert.ToDateTime(dt.Rows[0]["Date"].ToString()));
            //

        }
        return author;
    }
    #endregion
}