using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Referee
/// </summary>
public class Referee : DBMan
{
    #region attribute
    private int _id;
    private PersianDateTime _date;
    private User_cls _user;
    private int _active;
    #endregion

    #region //Property

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public int Active
    {
        get { return _active; }
        set { _active = value; }
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
    public Referee()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public DataTableBatis GetOneRefereeInfo()
    //{
    //    dt = new DataTableBatis();
    //    SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
    //    SqlCommand cmd = new SqlCommand("RefreeGet", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    ////////
    //    SqlParameter _ID = new SqlParameter("@ID", SqlDbType.Int);
    //    _ID.Value = this.ID;

    //}
    public DBmessage Register()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("RefereeRegister", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        /////////////////////////
        SqlParameter _userId = new SqlParameter("@UsrID", SqlDbType.Int) { Value = User.UserID };
        //
        newcmd.Parameters.Add(_userId);
        newcmd.Parameters.Add(CreateBy);
        newcmd.Parameters.Add(RetunParam);
        //
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }

    public DataTable Get(int active=0)
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("RefreeGet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////////
        SqlParameter _active = new SqlParameter("@Active", SqlDbType.Bit);
        if (active == 0)
            _active.Value = DBNull.Value;
        else if(active == 1)
            _active.Value = 1;
        else if(active == 2)
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
    public DBmessage Delete()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("[RefereeDelete]", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure 
        };
        /////////////////////////
        SqlParameter _userId = new SqlParameter("@UserID", SqlDbType.Int) { Value = User.UserID };
        //
        newcmd.Parameters.Add(_userId);
        newcmd.Parameters.Add(RetunParam);
        //
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    public DataTable InfoGet()
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("RefereeInfoGet", con);
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
    #region static member
    public static Referee Convert(DataTable dt)
    {
        Referee referee = new Referee();
        if (dt.Rows.Count > 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["ID"]))
                referee.ID = System.Convert.ToInt32(dt.Rows[0]["ID"]);
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["UserId"]))
            {
                referee.User = new User_cls();
                referee.User.UserID = System.Convert.ToInt32(dt.Rows[0]["UserId"]);
            }
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Date"]))
                referee.Date = new PersianDateTime(System.Convert.ToDateTime(dt.Rows[0]["Date"].ToString()));
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Active"]))
                referee.Active = System.Convert.ToInt32(dt.Rows[0]["Active"]);
            //

        }
        return referee;
    }
    #endregion
}