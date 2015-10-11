using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaperProposedReferee
/// </summary>
public class PaperProposedReferee : DBMan
{
    int _id;

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    string _family;

    public string Family
    {
        get { return _family; }
        set { _family = value; }
    }
    string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    Paper _paper;

    public Paper Paper
    {
        get { return _paper; }
        set { _paper = value; }
    }
    User_cls _createby;

    public User_cls Createby
    {
        get { return _createby; }
        set { _createby = value; }
    }
    PersianDateTime _date;

    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    public PaperProposedReferee()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Fullname
    {
        get
        {
            if ((this.Name != null || this.Name != string.Empty) && (this.Family != null || this.Family != string.Empty))
                return this.Name + " " + this.Family;
            return "";
        }
    }
    public DBmessage Register(UserTable users)
    {
        SqlConnection sqlConnection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand newcmd = new SqlCommand("PaperProposedRefereeRegister", sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        /////////////////////////
        SqlParameter _userlist = new SqlParameter("@UserList", SqlDbType.Structured) { Value = users };
        SqlParameter _paperID = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.Paper != null || this.Paper.ID != 0)
            _paperID.Value = this.Paper.ID;
        else
            _paperID.Value = DBNull.Value;

        //
        newcmd.Parameters.Add(_userlist);
        newcmd.Parameters.Add(_paperID);
        newcmd.Parameters.Add(CreateBy);
        newcmd.Parameters.Add(RetunParam);
        //
        sqlConnection.Open();
        newcmd.ExecuteNonQuery();
        sqlConnection.Close();
        ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    #region static member
    public static List<PaperProposedReferee> ConvertToListPaperProposedReferee(DataTable dt)
    {
        List<PaperProposedReferee> result = new List<PaperProposedReferee>();
        int lastindex = 0;
        if (dt == null || dt.Rows.Count == 0)
            return result;
        foreach (DataRow item in dt.Rows)
        {
            result.Add(new PaperProposedReferee());
            if (dt.Columns.Contains("ID") && item["ID"] != DBNull.Value)
            {
                result[lastindex].ID = System.Convert.ToInt32(item["ID"]);
            }
            if (dt.Columns.Contains("Name") && item["Name"] != DBNull.Value)
            {
                result[lastindex].Name = item["Name"].ToString();
            }
            if (dt.Columns.Contains("Family") && item["Family"] != DBNull.Value)
            {
                result[lastindex].Family = item["Family"].ToString();
            }
            if (dt.Columns.Contains("Email") && item["Email"] != DBNull.Value)
            {
                result[lastindex].Email = item["Email"].ToString();
            }
            if (dt.Columns.Contains("PaperID") && item["PaperID"] != DBNull.Value)
            {
                result[lastindex].Paper = new Paper();
                result[lastindex].Paper.ID = System.Convert.ToInt32(item["PaperID"]);
            }
            if (dt.Columns.Contains("CreateBy") && item["CreateBy"] != DBNull.Value)
            {
                result[lastindex].Createby = new User_cls();
                result[lastindex].Createby.UserID = System.Convert.ToInt32(item["CreateBy"]);
            }
            if (dt.Columns.Contains("Date") && item["Date"] != DBNull.Value)
            {
                result[lastindex].Date = new PersianDateTime(System.Convert.ToDateTime(item["Date"]));
            }
            lastindex = result.Count;
        }
        return result;
    }
    #endregion
}