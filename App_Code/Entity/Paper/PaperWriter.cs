using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// classi ke baraye yek moalef paper ast, dar vaghe har paper daraye listi az moalefin (in class) ast
/// </summary>
public class PaperWriter : User_cls
{
    #region attribute
    private int _id;
    private Paper _paper;
    private PersianDateTime _date;
    private User_cls _createBy;
    private PaperWriterResponsibility _responsibility;

    
    #endregion
    #region prop
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public Paper Paper
    {
        get { return _paper; }
        set { _paper = value; }
    }
    public PersianDateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }
    public User_cls CreateBy
    {
        get { return _createBy; }
        set { _createBy = value; }
    }
    /// <summary>
    /// dar in maghale fard che naghshi dasht
    /// </summary>
    public PaperWriterResponsibility Responsibility
    {
        get { return _responsibility; }
        set {  _responsibility = value; }
    }
    #endregion
    #region methods
    public DBmessage Register(PaperWriterTable userList)
    {
        cmd = new SqlCommand("PaperWriterRegister", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///////////////////////////////
        SqlParameter _userList = new SqlParameter("@UserList", SqlDbType.Structured);
        _userList.Value = userList;
        //
        SqlParameter _paperId = new SqlParameter("@PaperID", SqlDbType.Int);
        if (this.Paper == null)
            _paperId.Value = DBNull.Value;
        else
            _paperId.Value = this.Paper.ID;
        //
        SqlParameter _createBy = new SqlParameter("@CreateBy", SqlDbType.Int);
        _createBy.Value = Client.UserID;
        ////////////////////////
        cmd.Parameters.Add(_userList);
        cmd.Parameters.Add(_paperId);
        cmd.Parameters.Add(_createBy);
        cmd.Parameters.Add(RetunParam);
        ///////////////////////////
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        //
        return ResultMessage = new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    }
    #endregion
    #region members
    public static List<PaperWriter> ConvertToListPaperWriter(DataTable dt)
    {
        List<PaperWriter> result = new List<PaperWriter>();
        int lastindex = 0;
        if (dt == null || dt.Rows.Count == 0)
            return result;
        foreach (DataRow item in dt.Rows)
        {
            result.Add(new PaperWriter());
            if (dt.Columns.Contains("ID") && item["ID"] != DBNull.Value)
            {
                result[lastindex].ID = System.Convert.ToInt32(item["ID"]);
            }
            
            if (dt.Columns.Contains("Name") && item["Name"] != DBNull.Value)
            {
                result[lastindex].Fname = item["Name"].ToString();
            }
            if (dt.Columns.Contains("LastName") && item["LastName"] != DBNull.Value)
            {
                result[lastindex].Lname = item["LastName"].ToString();
            }
            result[lastindex].FullName = result[lastindex].Fname + " " + result[lastindex].Lname;
            if (dt.Columns.Contains("PaperID") && item["PaperID"] != DBNull.Value)
            {
                result[lastindex].Paper = new Paper();
                result[lastindex].Paper.ID = System.Convert.ToInt32(item["PaperID"]);
            }
            if (dt.Columns.Contains("Date") && item["Date"] != DBNull.Value)
            {
                result[lastindex].Date = new PersianDateTime(System.Convert.ToDateTime(item["Date"]));
            }
            if (dt.Columns.Contains("CreateBy") && item["CreateBy"] != DBNull.Value)
            {
                result[lastindex].CreateBy = new User_cls();
                result[lastindex].CreateBy.UserID = System.Convert.ToInt32(item["CreateBy"]);
            }
            if (dt.Columns.Contains("Responsibility") && item["Responsibility"] != DBNull.Value)
            {
                result[lastindex].Responsibility = new PaperWriterResponsibility();
                result[lastindex].Responsibility.ID = System.Convert.ToInt32(item["Responsibility"]);
            }
            lastindex = result.Count;
        }
        return result;
    }
    #endregion

}
public class PaperWriterTable : DataTable
{
    public PaperWriterTable()
    {
        this.Columns.Add("Name");
        this.Columns.Add("LastName"); 
        this.Columns.Add("InCharge"); 
    }

    public void Add(string name, string lastName , int inCharge)
    {
        this.Rows.Add(name, lastName, inCharge);
    }
    public static PaperWriterTable Convert(List<PaperWriter> source)
    {
        PaperWriterTable paperWriterTable = new PaperWriterTable();
        for (int i = 0; i < source.Count; i++)
        {
            paperWriterTable.Add(source[i].Fname, source[i].Lname , source[i].Responsibility.ID); // momkene responsibility null bashe ; badan check beshe
        }
        return paperWriterTable;
    }
}
public class PaperWriterResponsibility
{
    int id;
    string _title;
    public PaperWriterResponsibility()
    { }
    public PaperWriterResponsibility(int id)
    {
        this.ID = id;
    }
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
            _title = PaperWriterResponsibility.Convert(value);
            id = value;
        }
    }
    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return SystemMessage_PaperWriter.Normal;
            case 2:
                return SystemMessage_PaperWriter.Encharge;
           
            default: throw new Exception("invalid paperstatus id");
        }
    }
    public static int Normal
    { get { return 1; } }
    public static int Encharge
    { get { return 2; } }


}
public static class SystemMessage_PaperWriter
{
    /// <summary>
    /// 
    /// </summary>
    public static string Normal
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "";
            return "";
        }
    }
    public static string Encharge
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Encharge";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "مسئول";
            return "";
        }

    }
}