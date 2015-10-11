using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Editor
/// </summary>
public class Editor:DBMan
{
	public Editor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region attribute
    private int _id;
    private PersianDateTime _date;
    private User_cls _user;
    private string _contacts;
    private string _resume;
    #endregion
    #region //Property

    public int ID
    {
        get { return _id; }
        set { _id = value; }
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
    public string Contacts
    {
        get { return _contacts; }
        set { _contacts = value; }
    }
    public string Resume
    {
        get { return _resume; }
        set { _resume = value; }
    }

    public bool Active { get; set; }
    #endregion Property
    public DBmessage Register()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("EditorRegister", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        /////////////////////////
        SqlParameter _userId = new SqlParameter("@UsrID", SqlDbType.Int) { Value = User.UserID };
        SqlParameter _contacts = new SqlParameter("@Contact", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Contacts))
            _contacts.Value = DBNull.Value;
        else
            _contacts.Value = this.Contacts;

        SqlParameter _resume = new SqlParameter("@Resume", SqlDbType.NVarChar, 100);
        if (string.IsNullOrEmpty(this.Resume))
            _resume.Value = DBNull.Value;
        else
            _resume.Value = this.Resume;
        //
        newcmd.Parameters.Add(_userId);
        newcmd.Parameters.Add(_contacts);
        newcmd.Parameters.Add(_resume);
        newcmd.Parameters.Add(RetunParam);
        //
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    public DBmessage Delete()
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("[EditorDelete]", sqlConnection)
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
    public DataTable GetEditor()
    {
        cmd = new SqlCommand("EditorGet", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        da=new SqlDataAdapter(cmd);
        dt=new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable Get(int active = 0)
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("EditorGetList", con);
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
        SqlCommand cmd = new SqlCommand("EditorInfoGet", con);
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
    public static Editor Convert(DataTable dt)
    {
        Editor editor = new Editor();
        if (dt.Rows.Count > 0)
        {
            if (!DBNull.Value.Equals(dt.Rows[0]["ID"]))
                editor.ID = System.Convert.ToInt32(dt.Rows[0]["ID"]);
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["UserID"]))
            {
                editor.User = new User_cls();
                editor.User.UserID = System.Convert.ToInt32(dt.Rows[0]["UserID"]);
            }
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Contacts"]))
                editor.ID = System.Convert.ToInt32(dt.Rows[0]["Contacts"]);
            //
            if (!DBNull.Value.Equals(dt.Rows[0]["Resume"]))
                editor.ID = System.Convert.ToInt32(dt.Rows[0]["Resume"]);
        }
        return editor;
    }
}