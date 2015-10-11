using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SysClient
/// </summary>
public class SysClient : User_cls
{
    public SysClient()
    {
        ClientInfo = "";
        Fname = "";
        Lname = "";
        FullName = "";
        ImageDirectoryVitual = "";
        Roles = new Role();

    }
    private string _clientinfo;
    private string _imagedirectoryvitual;
    private string _imagedirectoryphisycal;
    private static bool _havePassword;
    public static bool HavePassword
    {
        get
        {
            return _havePassword;
        }
        set
        {
            _havePassword = value;
        }
    }

    public string ClientInfo
    {
        get { return _clientinfo; }
        set { _clientinfo = value; }
    }

    public string ImageDirectoryVitual
    {
        get { return _imagedirectoryvitual; }
        set { _imagedirectoryvitual = value; }
    }
    public string ImageDirectoryPhisycal
    {
        get { return _imagedirectoryphisycal; }
        set { _imagedirectoryphisycal = value; }
    }

    public string Browser
    {
        get
        {

            System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            return browser.Browser;

        }

    }
    public void Logout()
    {
        SysClient.Client = new SysClient();
        SysProperty.Client = new SysClient();
        HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/Login.aspx");
    }
    /// <summary>
    /// vorode modir,//HOSSEIN\\
    /// </summary>
    /// <returns></returns>
    public bool LoginAdmin()
    {
        cmd = new SqlCommand("AdminLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///
        SqlParameter _username = new SqlParameter("@UserID", SqlDbType.Int);
        _username.Value = this.UserID;

        SqlParameter _browseer = new SqlParameter("@Browser", SqlDbType.NVarChar, 50);
        _browseer.Value = this.Browser;

        SqlParameter _result = new SqlParameter("@Result", SqlDbType.NVarChar, 50);
        _result.Direction = ParameterDirection.Output;
        ///
        cmd.Parameters.Add(_username);
        cmd.Parameters.Add(_browseer);
        cmd.Parameters.Add(_result);
        ///
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        this.ClientInfo = System.Convert.ToString(cmd.Parameters["@Result"].Value);
        if (this.ClientInfo == "")
            return false;
        return true;

    }

    public static string DefaulImageAddressVirtual
    {
        get { return ServerDirectory.UploadVirtual + "/Default.jpg"; }
    }
    //public static string defualtImageAddressPhisycal
    //{
    //    get { return ServerDirectory.UserImagePathPhysical + "\\userimage.jpg"; }
    //}
    /// <summary>
    /// vorode negahbani,//HOSSEIN\\
    /// </summary>
    /// <returns></returns>
    public bool LoginAuthor()
    {
        cmd = new SqlCommand("AutorLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///
        SqlParameter _username = new SqlParameter("@UserID", SqlDbType.Int);
        _username.Value = this.UserID;

        SqlParameter _browseer = new SqlParameter("@Browser", SqlDbType.NVarChar, 50);
        _browseer.Value = this.Browser;

        SqlParameter _result = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
        _result.Direction = ParameterDirection.Output;
        ///
        cmd.Parameters.Add(_username);

        cmd.Parameters.Add(_browseer);
        cmd.Parameters.Add(_result);
        ///
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        this.ClientInfo = System.Convert.ToString(cmd.Parameters["@Result"].Value);
        if (this.ClientInfo == "")
            return false;
        return true;
    }
    public bool LoginReferee()
    {
        cmd = new SqlCommand("RefereeLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///
        SqlParameter _username = new SqlParameter("@UserID", SqlDbType.Int);
        _username.Value = this.UserID;

        SqlParameter _browseer = new SqlParameter("@Browser", SqlDbType.NVarChar, 50);
        _browseer.Value = this.Browser;

        SqlParameter _result = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
        _result.Direction = ParameterDirection.Output;
        ///
        cmd.Parameters.Add(_username);

        cmd.Parameters.Add(_browseer);
        cmd.Parameters.Add(_result);
        ///
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        this.ClientInfo = System.Convert.ToString(cmd.Parameters["@Result"].Value);
        if (this.ClientInfo == "")
            return false;
        return true;
    }

    public bool LoginEditor()
    {
        cmd = new SqlCommand("EditorLogin", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///
        SqlParameter _username = new SqlParameter("@UserID", SqlDbType.Int);
        _username.Value = this.UserID;

        SqlParameter _browseer = new SqlParameter("@Browser", SqlDbType.NVarChar, 50);
        _browseer.Value = this.Browser;

        SqlParameter _result = new SqlParameter("@Result", SqlDbType.NVarChar, 100);
        _result.Direction = ParameterDirection.Output;
        ///
        cmd.Parameters.Add(_username);

        cmd.Parameters.Add(_browseer);
        cmd.Parameters.Add(_result);
        ///
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        this.ClientInfo = System.Convert.ToString(cmd.Parameters["@Result"].Value);
        if (this.ClientInfo == "")
            return false;
        return true;
    }
    /// <summary>
    /// chech kardane inke aya session ba etelate feli yeki hast ya kheyr,//HOSSEIN\\
    /// </summary>
    /// <param name="sessionvalue">meghdare felie session</param>
    /// <param name="ip"></param>
    /// <param name="browser"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool SessionCheck()
    {
        cmd = new SqlCommand("SessionCheck", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///
        SqlParameter _hashtext = new SqlParameter("@HashText", SqlDbType.NVarChar, 50);
        _hashtext.Value = this.ClientInfo;
        SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
        _userid.Value = this.UserID;
        SqlParameter _browseer = new SqlParameter("@Browser", SqlDbType.NVarChar, 50);
        _browseer.Value = this.Browser;

        SqlParameter _result = new SqlParameter("@Result", SqlDbType.Bit);
        _result.Direction = ParameterDirection.Output;
        ///
        cmd.Parameters.Add(_hashtext);
        cmd.Parameters.Add(_userid);

        cmd.Parameters.Add(_browseer);
        cmd.Parameters.Add(_result);
        ///
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        return System.Convert.ToBoolean(cmd.Parameters["@Result"].Value);
    }
    public bool Login()
    {
        SqlCommand newcmd = new SqlCommand();
        SqlDataAdapter newda = new SqlDataAdapter();
        DataTable newdt = new DataTable();
        newcmd = new SqlCommand("UserLogin", new SqlConnection(SysProperty.AutoSysDB));
        newcmd.CommandType = CommandType.StoredProcedure;
        ///////////////////////////////////////////////////////
        SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
        _username.Value = this.Username;
        SqlParameter _pass = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        _pass.Value = this.Password;
        SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
        _userid.Direction = ParameterDirection.Output;
        SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
        _name.Direction = ParameterDirection.Output;
        SqlParameter _family = new SqlParameter("@Family", SqlDbType.NVarChar, 50);
        _family.Direction = ParameterDirection.Output;
        SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
        _email.Direction = ParameterDirection.Output;
        SqlParameter _havePass = new SqlParameter("@HavePass", SqlDbType.Bit);
        _havePass.Direction = ParameterDirection.Output;
        /////////////////////////////
        newcmd.Parameters.Add(_username);
        newcmd.Parameters.Add(_pass);
        newcmd.Parameters.Add(_userid);
        newcmd.Parameters.Add(_name);
        newcmd.Parameters.Add(_family);
        newcmd.Parameters.Add(_email);
        newcmd.Parameters.Add(_havePass);
        newcmd.Parameters.Add(RetunParam);

        newda.SelectCommand = newcmd;
        /////////////////////////////////////////
        newcmd.Connection.Open();
        newda.Fill(newdt);
        newcmd.Connection.Close();
        newcmd = newda.SelectCommand;
        if(newcmd.Parameters["@UserID"].Value != DBNull.Value)
            this.UserID = System.Convert.ToInt32(newcmd.Parameters["@UserID"].Value);
        if (newcmd.Parameters["@Name"].Value != DBNull.Value)
            this.Fname = newcmd.Parameters["@Name"].Value.ToString();
        if (newcmd.Parameters["@Family"].Value != DBNull.Value)
            this.Lname = newcmd.Parameters["@Family"].Value.ToString();
        if (newcmd.Parameters["@Email"].Value != DBNull.Value)
            this.Email = newcmd.Parameters["@Email"].Value.ToString();
        SysClient.HavePassword = System.Convert.ToBoolean(newcmd.Parameters["@HavePass"].Value);
        this.FullName = this.Fname + " " + this.Lname;
        if (newdt.Rows.Count != 0)
            if (!newdt.Rows[0]["UserImage"].Equals(DBNull.Value))
            {

                string direc = clsSecurity.ComputeMD5(UserID.ToString() + Lname + Fname + "adaksuDhe1234");
                ImageDirectoryPhisycal = ServerDirectory.UploadPhysical + "\\" + direc + ".jpg";
                File.WriteAllBytes(ImageDirectoryPhisycal, (byte[])newdt.Rows[0]["UserImage"]);
                ImageDirectoryVitual = ServerDirectory.UploadVirtual + "/" + direc + ".jpg";
            }
            else
                ImageDirectoryVitual = DefaulImageAddressVirtual;

        if (System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value) == 0)
            return false;
        else
            return true;
    }
    public DataTable GetRol()
    {
        da = new SqlDataAdapter();
        dt = new DataTable();
        cmd = new SqlCommand("GetRole", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        /////////////
        SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
        _userid.Value = this.UserID;
        ////////////
        cmd.Parameters.Add(_userid);
        //////////
        da.SelectCommand = cmd;
        conn.Open();
        da.Fill(dt);
        conn.Close();
        //////////


        return dt;
    }

}
public class Role : Dictionary<RoleType, bool>
{
    public int ID
    {
        get;
        set;
    }
    public string RoleInString
    {
        get
        {
            string result = "";
            if (this[RoleType.Admin])
                result += Position.Convert(Position.Admin);
            if (this[RoleType.Editor])
                result += "," + Position.Convert(Position.Editor);
            if (this[RoleType.Author])
                result += "," + Position.Convert(Position.Author);
            if (this[RoleType.Referee])
                result += "," + Position.Convert(Position.Refree);
            if (this[RoleType.User])
                result += "," + Position.Convert(Position.User);
            if (this[RoleType.CheifEditor])
                result += "," + Position.Convert(Position.ChefEditor);
            if (this[RoleType.LanguageEditor])
                result += "," + Position.Convert(Position.LanguageEditor);
            if (this[RoleType.SyntaxEditor])
                result += "," + Position.Convert(Position.SyntaxEditor);
            return result;
        }
    }
    /// <summary>
    /// tamami rol ha ba meghdare x meghdar dehi mishavad
    /// </summary>
    /// <param name="x"></param>
    public Role(bool x)
    {
        SetValue(x);
    }
    /// <summary>
    /// tamami rol ha ba meghdar false meghdar dehi mishavad
    /// </summary>
    public Role()
    { SetValue(false); }
    private void SetValue(bool x)
    {
        base.Add(RoleType.Admin, x);
        base.Add(RoleType.Author, x);
        base.Add(RoleType.CheifEditor, x);
        base.Add(RoleType.Editor, x);
        base.Add(RoleType.Referee, x);
        base.Add(RoleType.User, x);
        base.Add(RoleType.LanguageEditor, x);
        base.Add(RoleType.SyntaxEditor, x);

    }
    /// <summary>
    /// check kardan sathe dastrasi baraye karbar ; agar role vorudi ra nadasht exception khahad andakht va dar gheye in surat ejaze dastrasi darad
    /// </summary>
    /// <param name="role"></param>
    public void Check(RoleType role)
    {
        if (!this[role])
            throw new MyException(SystemMessage.AccessDeny, 101, "");
    }
    private void SetValue(RoleType key, bool Value)
    {
        base[key] = Value;
    }
    /// <summary>
    /// you can't call this method
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public new void Add(RoleType key, bool value) { throw new Exception("you cant use add method for Role!!"); }

    #region static member
    public static Role Convert(DataTable dt)
    {
        Role result = new Role();
        if (dt.Rows.Count == 0)
            return result;
        if (!DBNull.Value.Equals(dt.Rows[0]["Admin"]) && (bool)dt.Rows[0]["Admin"] == true)
            result.SetValue(RoleType.Admin, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["Author"]) && (bool)dt.Rows[0]["Author"] == true)
            result.SetValue(RoleType.Author, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["CheifEditor"]) && (bool)dt.Rows[0]["CheifEditor"] == true)
            result.SetValue(RoleType.CheifEditor, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["Editor"]) && (bool)dt.Rows[0]["Editor"] == true)
            result.SetValue(RoleType.Editor, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["Referee"]) && (bool)dt.Rows[0]["Referee"] == true)
            result.SetValue(RoleType.Referee, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["User"]) && (bool)dt.Rows[0]["User"] == true)
            result.SetValue(RoleType.User, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["LanguageEditor"]) && (bool)dt.Rows[0]["LanguageEditor"] == true)
            result.SetValue(RoleType.LanguageEditor, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["SyntaxEditor"]) && (bool)dt.Rows[0]["SyntaxEditor"] == true)
            result.SetValue(RoleType.SyntaxEditor, true);
        return result;
    }
    public static Role Convert(string roles)
    {
        Role role = new Role();
        string[] userRoles = roles.Split(',');
        for (int i = 0; i < userRoles.Length; i++)
        {
            if (Position.Admin.ToString() == userRoles[i])
                role[RoleType.Admin] = true;

            else if (Position.Editor.ToString() == userRoles[i])
                role[RoleType.Editor] = true;

            else if (Position.Author.ToString() == userRoles[i])
                role[RoleType.Author] = true;

            else if (Position.Refree.ToString() == userRoles[i])
                role[RoleType.Referee] = true;

            else if (Position.User.ToString() == userRoles[i])
                role[RoleType.User] = true;

            else if (Position.ChefEditor.ToString() == userRoles[i])
                role[RoleType.CheifEditor] = true;

            else if (Position.LanguageEditor.ToString() == userRoles[i])
                role[RoleType.LanguageEditor] = true;

            else if (Position.SyntaxEditor.ToString() == userRoles[i])
                role[RoleType.SyntaxEditor] = true;
        }
        return role;
    }
    #endregion


}
public class Position
{

    public Position()
    { }
    public Position(int id)
    {
        this.ID = id;
    }

    int _id;

    public int ID
    {
        get { return _id; }
        set
        {
            _title = Position.Convert(value);
            _id = value;
        }
    }
    string _title;

    public string Title
    {
        get { return _title; }
        //set { _title = value; }
    }







    //public static int Convert(string title)
    //{
    //    switch (title)
    //    {
    //        case "Admin":
    //            return 1;
    //        case "Editor":
    //            return 2;
    //        case "Author":
    //            return 3;
    //        case "Refree":
    //            return 4;
    //        case "User":
    //            return 5;
    //        default: throw new Exception("invalid paperstatus name");
    //    }
    //}

    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return "Admin";
            case 2:
                return "Editor";
            case 3:
                return "Author";
            case 4:
                return "Refree";
            case 5:
                return "User";
            case 6:
                return "ChefEditor";
            case 7:
                return "LanguageEditor";
            case 8:
                return "SyntaxEditor";
            default: throw new Exception("invalid Position id");
        }
    }
    public static int Admin
    {
        get { return 1; }
    }
    public static int Editor
    {
        get { return 2; }
    }
    public static int Author
    {
        get { return 3; }
    }
    public static int Refree
    {
        get { return 4; }
    }
    public static int User
    {
        get { return 5; }
    }
    public static int ChefEditor
    {
        get { return 6; }
    }
    public static int LanguageEditor
    {
        get { return 7; }
    }
    public static int SyntaxEditor
    {
        get { return 8; }
    }
}
public enum RoleType
{
    Admin, CheifEditor, Editor, Author, User, Referee , LanguageEditor , SyntaxEditor
}
