using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

/// <summary>
/// Summary description for User
/// </summary>
public class User_cls : DBMan
{
    public User_cls()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public User_cls(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
    #region attribute
    public Role _role;
    public string _username;
    public string _password;
    public string _fname;
    public string _lname;
    public string _fathername;
    public string _melli;
    public string _shenasname;
    public string _education;
    public string _birthplace;
    public int _userid;
    public string _email;
    public string _phone;
    public string _fax;
    public PersianDateTime _birthdate;
    public bool _active;
    public string _fullname;
    public string _marriage;
    private byte[] _image;
    public Gender _sex;
    public string _issuedfrom;
    public string _affiliations;
    public string _fields;
    private string _hash;
    private PersianDateTime _expHash;
    #endregion

    #region property
    public Role Roles
    {
        set { _role = value; }
        get { return _role; }
    }
    public bool Active
    {
        set { _active = value; }
        get { return _active; }
    }
    public int UserID
    {
        set { _userid = value; }
        get { return _userid; }
    }
    public string Username
    {
        set
        {
            value = value.Trim();
            if (value.Length > 3 && value.Length < 101)
                _username = value;
            else
            {
                throw new MyException("نام کاربری باید بین 4 تا 100 کاراکتر باشد", 101, "User_cls.Username");
            }
        }
        get { return _username; }
    }
    public string Password
    {
        set
        {
            value = value.Trim();
            if (value.Length > 5 && value.Length < 51)
                _password = value;
            else
            {
                throw new MyException("رمز عبور باید بین 6 تا 50 کاراکتر باشد", 101, "User_cls.Password");
            }
        }
        get { return _password; }
    }
    /// <summary>
    /// اسم کوچک شخص می باشد
    /// </summary>
    public string Fname
    {
        get { return _fname; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _fname = value;
            }
        }
    }
    public string Lname
    {
        get { return _lname; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _lname = value;
            }
        }
    }
    public string FullName
    {
        set
        {
            if (value != null)
            {
                value = value.Trim(); _fullname = value;
            }
        }
        get { return _fullname; }
    }
    /// <summary>
    /// اسم پدر شخص می باشد
    /// </summary>
    public string FatherName
    {
        get { return _fathername; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _fathername = value;
            }
        }
    }
    /// <summary>
    /// شماره شناسنامه می باشد که حداکثر طول آن 10 می  باشد
    /// </summary>
    public string Shenasname
    {
        get { return _shenasname; }

        set
        {
            if (value != null)
            {
                value = value.Trim();
                //if (value.Length <= 10 && value.Length > 0)
                _shenasname = value;
                //else
                //{
                // MyException exception = new MyException("فرمت شناسنامه صحیح نمی باشد", 204, "user.shenasname");
                // throw exception;
                //}
            }
        }

    }
    /// <summary>
    /// شماره ملی شخص می باشد که تنها 10 رقم می باشد
    /// </summary>
    public string Melli
    {
        get { return _melli; }

        set
        {
            if (value != null)
            {
                value = value.Trim();
                //if (value.Length != 10)
                //{
                //    MyException exeption = new MyException("طول کد ملی اشتباه می باشد", 204, "user.melli");
                //    throw exeption;
                //}
                //else
                //{
                _melli = value;
                //}
            }
        }
    }
    public PersianDateTime Birthdate
    {
        get { return _birthdate; }
        set { _birthdate = value; }
    }
    /// <summary>
    /// تحصیلات شخص می باشد
    /// </summary>
    public string Education
    {
        get { return _education; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _education = value;
            }
        }
    }
    public string Birthplace
    {
        get { return _birthplace; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _birthplace = value;
            }
        }
    }
    public string Marriage
    {
        get { return _marriage; }
        set
        {
            if (value != null)
            {
                value = value.Trim(); _marriage = value;
            }
        }
    }
    public byte[] Image
    {
        set
        {
            //if (value != null)
            _image = value;
            //else
            //{
            //    MyException ex = new MyException("عکس بدرستی وارد نشده است", 204, "user.image");
            //    throw ex;
            //}
        }
        get { return _image; }
    }
    public string Phone
    {
        set
        {
            if (value != null)
            {
                _phone = value;
            }
        }
        get { return _phone; }
    }
    public string Email
    {
        set
        {
            if (value != null)
            {
                _email = value.Trim();
            }
        }
        get { return _email; }
    }
    public Gender Sex
    {
        set { _sex = value; }
        get { return _sex; }
    }
    public string IssuedFrom
    {
        set
        {
            if (value != null)
            {
                value = value.Trim(); _issuedfrom = value;
            }
        }
        get { return _issuedfrom; }
    }
    public string Affiliations
    {
        set
        {
            if (value != null)
            {
                _affiliations = value;
            }
        }
        get { return _affiliations; }
    }
    public string Fax
    {
        set
        {
            if (value != null)
            {
                _fax = value;
            }
        }
        get { return _fax; }
    }
    public string Fields
    {
        set
        {
            if (value != null)
            {
                _fields = value;
            }
        }
        get { return _fields; }
    }

    /// <summary>
    /// tarikh enghezaye meghdar hash
    /// </summary>
    public PersianDateTime ExpHash
    {
        get { return _expHash; }
        set { _expHash = value; }
    }
    /// <summary>
    /// bejaye password estefade mishad dar login agar password dade shode ba in meghdar barabar bashad va az exphash ham tarikh nagzashte bashad login movafaghiat amiz ast
    /// </summary>
    public string Hash
    {
        get { return _hash; }
        set
        {
            if (value != null)
            {
                _hash = value;
            }
        }
    }

    #endregion
    public DataTable GetLanguageEditors()
    {
        dt = new DataTable();
        SqlConnection conn = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("[LanguageEditorsGet]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //
        conn.Open();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public DBmessage EditImage()
    {
        cmd = new SqlCommand("UserImageChange", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///////////////////////////////
        SqlParameter _id = new SqlParameter("@UserID", SqlDbType.Int);
        _id.Value = this.UserID;
        SqlParameter _image = new SqlParameter("@Image", SqlDbType.VarBinary);
        if (this.Image != null)
            _image.Value = this.Image;
        else
            _image.Value = DBNull.Value;
        //
        cmd.Parameters.Add(_id);
        cmd.Parameters.Add(_image);
        cmd.Parameters.Add(RetunParam);
        //
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        //
        DBmessage ResultMessage = new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
        return ResultMessage;
    }
    public DBmessage RegisterRole()
    {
        cmd = new SqlCommand("[RoleRegister]", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        ///////////////////////////////
        SqlParameter _admin = new SqlParameter("@Admin", SqlDbType.Bit);
        SqlParameter _chefEditor = new SqlParameter("@CheifEditor", SqlDbType.Bit);
        SqlParameter _editor = new SqlParameter("@Editor", SqlDbType.Bit);
        SqlParameter _author = new SqlParameter("@Author", SqlDbType.Bit);
        SqlParameter _user = new SqlParameter("@User", SqlDbType.Bit);
        SqlParameter _referee = new SqlParameter("@Referee", SqlDbType.Bit);
        SqlParameter _languge = new SqlParameter("@LanguageEditor", SqlDbType.Bit);
        SqlParameter _syntax = new SqlParameter("@SyntaxEditor", SqlDbType.Bit);
        if (this.Roles != null)
        {
            _admin.Value = this.Roles[RoleType.Admin];
            _chefEditor.Value = this.Roles[RoleType.CheifEditor];
            _editor.Value = this.Roles[RoleType.Editor];
            _author.Value = this.Roles[RoleType.Author];
            _referee.Value = this.Roles[RoleType.Referee];
            _languge.Value = this.Roles[RoleType.LanguageEditor];
            _syntax.Value = this.Roles[RoleType.SyntaxEditor];
            _user.Value = this.Roles[RoleType.User];
        }
        else
        {
            _admin.Value = DBNull.Value;
            _chefEditor.Value = DBNull.Value;
            _editor.Value = DBNull.Value;
            _author.Value = DBNull.Value;
            _referee.Value = DBNull.Value;
            _user.Value = DBNull.Value;
            _languge.Value = DBNull.Value;
            _syntax.Value = DBNull.Value;
        }
        SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
        if (this.UserID <= 0)
            _userID.Value = DBNull.Value;
        else
            _userID.Value = this.UserID;
        //
        cmd.Parameters.Add(_admin);
        cmd.Parameters.Add(_chefEditor);
        cmd.Parameters.Add(_editor);
        cmd.Parameters.Add(_author);
        cmd.Parameters.Add(_user);
        cmd.Parameters.Add(_referee);
        cmd.Parameters.Add(_userID);
        cmd.Parameters.Add(_languge);
        cmd.Parameters.Add(_syntax);
        cmd.Parameters.Add(CreateBy);
        cmd.Parameters.Add(RetunParam);
        //
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        return ResultMessage = new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    }
    public DBmessage Register(UserTable userTable)
    {
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("[UsersRegister]", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        ///
        SqlParameter _userTable = new SqlParameter("@userTable", SqlDbType.Structured);
        _userTable.Value = userTable;
        //
        SqlParameter _createBy = new SqlParameter("@CreateBy", SqlDbType.Int);
        _createBy.Value = Client.UserID;
        /////
        da.SelectCommand.Parameters.Add(_userTable);
        da.SelectCommand.Parameters.Add(_createBy);
        da.SelectCommand.Parameters.Add(RetunParam);
        //
        conn.Open();
        da.Fill(dt);
        conn.Close();
        //
        DBmessage ResultMessage = new DBmessage(System.Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
        ResultMessage.Parameter["UserIDList"] = dt;
        return ResultMessage;
    }
    public DataTable InfoGet(out bool Author, out bool Referee, out bool Editor)
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("UserInfoGet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////////
        SqlParameter _Id = new SqlParameter("@UsrID", SqlDbType.Int);
        _Id.Value = this.UserID;

        SqlParameter _Author = new SqlParameter("@Author", SqlDbType.Bit);
        _Author.Direction = ParameterDirection.Output;

        SqlParameter _Referee = new SqlParameter("@Referee", SqlDbType.Bit);
        _Referee.Direction = ParameterDirection.Output;

        SqlParameter _Editor = new SqlParameter("@Editor", SqlDbType.Bit);
        _Editor.Direction = ParameterDirection.Output;
        /////////////////////
        da.SelectCommand.Parameters.Add(_Id);
        da.SelectCommand.Parameters.Add(_Author);
        da.SelectCommand.Parameters.Add(_Referee);
        da.SelectCommand.Parameters.Add(_Editor);
        da.SelectCommand.Parameters.Add(RetunParam);
        ////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        /////////////
        Author = (bool)da.SelectCommand.Parameters[_Author.ParameterName].Value;
        Referee = (bool)da.SelectCommand.Parameters[_Referee.ParameterName].Value;
        Editor = (bool)da.SelectCommand.Parameters[_Editor.ParameterName].Value;
        ///////
        return dt;
    }
    public DataTable Get(int active = 0)
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("UsersGet", con);
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
    public DataTable FullGet()
    {
        dt = new DataTable();
        SqlConnection con = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand cmd = new SqlCommand("UsersFullGet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////////
        SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
        if (this.UserID == 0)
            _userID.Value = DBNull.Value;
        else
            _userID.Value = this.UserID;

        SqlParameter _affiliations = new SqlParameter("@Affiliations", SqlDbType.NVarChar, 100);
        if (this.Affiliations == null || this.Affiliations == string.Empty)
            _affiliations.Value = DBNull.Value;
        else
            _affiliations.Value = this.Affiliations;

        SqlParameter _fields = new SqlParameter("@Fields", SqlDbType.NVarChar, 100);
        if (this.Fields == null || this.Fields == string.Empty)
            _fields.Value = DBNull.Value;
        else
            _fields.Value = this.Fields;

        SqlParameter _firstName = new SqlParameter("@Fname", SqlDbType.NVarChar, 50);
        if (this.Fname == null || this.Fname == string.Empty)
            _firstName.Value = DBNull.Value;
        else
            _firstName.Value = this.Fname;

        SqlParameter _lastName = new SqlParameter("@Lname", SqlDbType.NVarChar, 50);
        if (this.Lname == null || this.Lname == string.Empty)
            _lastName.Value = DBNull.Value;
        else
            _lastName.Value = this.Lname;

        SqlParameter _melli = new SqlParameter("@MelliNumber", SqlDbType.NVarChar, 10);
        if (this.Melli == null || this.Melli == string.Empty)
            _melli.Value = DBNull.Value;
        else
            _melli.Value = this.Melli;

        SqlParameter _education = new SqlParameter("@Education", SqlDbType.NVarChar, 50);
        if (this.Education == null || this.Education == string.Empty)
            _education.Value = DBNull.Value;
        else
            _education.Value = this.Education;

        SqlParameter _email = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
        if (this.Email == null || this.Email == string.Empty)
            _email.Value = DBNull.Value;
        else
            _email.Value = this.Email;

        SqlParameter _sex = new SqlParameter("@Sex", SqlDbType.Int);
        if (this.Sex == null)
            _sex.Value = DBNull.Value;
        else
            _sex.Value = this.Sex.ID;
        /////////////////////
        da.SelectCommand.Parameters.Add(_userID);
        da.SelectCommand.Parameters.Add(_affiliations);
        da.SelectCommand.Parameters.Add(_fields);
        da.SelectCommand.Parameters.Add(_firstName);
        da.SelectCommand.Parameters.Add(_lastName);
        da.SelectCommand.Parameters.Add(_melli);
        da.SelectCommand.Parameters.Add(_education);
        da.SelectCommand.Parameters.Add(_email);
        da.SelectCommand.Parameters.Add(_sex);
        da.SelectCommand.Parameters.Add(RetunParam);
        ////////
        conn.Open();
        da.Fill(dt);
        conn.Close();
        /////////////
        return dt;
    }
    public DBmessage Register(int subsystemid)
    {
        SqlCommand newcmd = new SqlCommand("UserRegister", new SqlConnection(SysProperty.AutoSysDB));
        newcmd.CommandType = CommandType.StoredProcedure;
        /////////////////////////
        SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
        _userid.Direction = ParameterDirection.Output;
        SqlParameter _username = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        if (this.Username == "" || this.Username == null)
            _username.Value = DBNull.Value;
        else
            _username.Value = this.Username;
        SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
        if (this.Password == "" || this.Password == null)
            _password.Value = DBNull.Value;
        else
            _password.Value = this.Password;
        SqlParameter _name = new SqlParameter("@Fname", SqlDbType.NVarChar, 50);
        if (this.Fname == "" || this.Fname == null)
            _name.Value = DBNull.Value;
        else
            _name.Value = this.Fname;
        SqlParameter _family = new SqlParameter("@Lname", SqlDbType.NVarChar, 50);
        if (this.Lname == "" || this.Lname == null)
            _family.Value = DBNull.Value;
        else
            _family.Value = this.Lname;
        SqlParameter _fathername = new SqlParameter("@FatherName", SqlDbType.NVarChar, 50);
        if (this.FatherName == "" || this.FatherName == null)
            _fathername.Value = DBNull.Value;
        else
            _fathername.Value = this.FatherName;
        SqlParameter _nationalnumber = new SqlParameter("@Mellinum", SqlDbType.VarChar, 10);
        if (this.Melli == "" || this.Melli == null)
            _nationalnumber.Value = DBNull.Value;
        else
            _nationalnumber.Value = this.Melli;
        SqlParameter _shno = new SqlParameter("@Shenasnamenum", SqlDbType.VarChar, 10);
        if (this.Shenasname == "" || this.Shenasname == null)
            _shno.Value = DBNull.Value;
        else
            _shno.Value = this.Shenasname;
        SqlParameter _dateofbirth = new SqlParameter("@Birthday", SqlDbType.Date);
        if (this.Birthdate == null)
            _dateofbirth.Value = DBNull.Value;
        else
            _dateofbirth.Value = this.Birthdate.Datetime.Date;

        SqlParameter _birthplace = new SqlParameter("@Birthdayplace", SqlDbType.NVarChar, 50);
        if (this.Birthplace == "" || this.Birthplace == null)
            _birthplace.Value = DBNull.Value;
        else
            _birthplace.Value = this.Birthplace;
        if (this.Birthplace == null)
            _birthplace.Value = DBNull.Value;
        SqlParameter _education = new SqlParameter("@Education", SqlDbType.NVarChar, 50);
        if (this.Education == "" || this.Education == null)
            _education.Value = DBNull.Value;
        else
            _education.Value = this.Education;
        SqlParameter _image = new SqlParameter("@UserImage", SqlDbType.Image);
        _image.Value = this.Image;
        if (this.Image == null)
            _image.Value = DBNull.Value;
        SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
        if (this.Phone == "" || this.Phone == null)
            _phone.Value = DBNull.Value;
        else
            _phone.Value = this.Phone;
        SqlParameter _email = new SqlParameter("@Email", SqlDbType.VarChar, 100);
        if (this.Email == "" || this.Email == null)
            _email.Value = DBNull.Value;
        else
            _email.Value = this.Email;
        SqlParameter _sex = new SqlParameter("@Sex", SqlDbType.NVarChar, 50);
        if (this.Sex == null)
            _sex.Value = DBNull.Value;
        else
            _sex.Value = this.Sex.ID;
        SqlParameter _issuedfrom = new SqlParameter("@IssuedFrom", SqlDbType.NVarChar, 50);
        if (this.IssuedFrom == "" || this.IssuedFrom == null)
            _issuedfrom.Value = DBNull.Value;
        else
            _issuedfrom.Value = this.IssuedFrom;
        SqlParameter _marriage = new SqlParameter("@Marriage", SqlDbType.NVarChar, 50);
        if (this.Marriage == "" || this.Marriage == null)
            _marriage.Value = DBNull.Value;
        else
            _marriage.Value = this.Marriage;
        SqlParameter _subsytemid = new SqlParameter("@Subsystem", SqlDbType.Int);
        _subsytemid.Value = subsystemid;

        SqlParameter _affiliations = new SqlParameter("@Affiliations", SqlDbType.NVarChar, 100);
        if (this.Affiliations == null || this.Affiliations == "")
            _affiliations.Value = DBNull.Value;
        else
            _affiliations.Value = this.Affiliations;
        SqlParameter _fax = new SqlParameter("@Fax", SqlDbType.NVarChar);
        if (this.Fax == null || this.Fax == "")
            _fax.Value = DBNull.Value;
        else
            _fax.Value = this.Fax;

        SqlParameter _field = new SqlParameter("@Fields", SqlDbType.NVarChar);
        if (this.Fields == null || this.Fields == "")
            _field.Value = DBNull.Value;
        else
            _field.Value = this.Fields;
        SqlParameter _hash = new SqlParameter("@Hash", SqlDbType.NVarChar, 100);
        _hash = SetParameterValue(_hash, this.Hash);
        SqlParameter _exphash = new SqlParameter("@ExpHash", SqlDbType.SmallDateTime);
        if (this.ExpHash != null)
            _exphash.Value = this.ExpHash.Datetime;
        else
            _exphash.Value = DBNull.Value;
        //////////////////////////
        newcmd.Parameters.Add(_userid);
        newcmd.Parameters.Add(_username);
        newcmd.Parameters.Add(_password);
        newcmd.Parameters.Add(_name);
        newcmd.Parameters.Add(_family);
        newcmd.Parameters.Add(_fathername);
        newcmd.Parameters.Add(_nationalnumber);
        newcmd.Parameters.Add(_marriage);
        newcmd.Parameters.Add(_dateofbirth);
        newcmd.Parameters.Add(_shno);
        newcmd.Parameters.Add(_education);
        newcmd.Parameters.Add(_birthplace);
        newcmd.Parameters.Add(_issuedfrom);
        newcmd.Parameters.Add(_sex);
        newcmd.Parameters.Add(_image);
        newcmd.Parameters.Add(_phone);
        newcmd.Parameters.Add(_email);
        newcmd.Parameters.Add(_subsytemid);
        newcmd.Parameters.Add(_affiliations);
        newcmd.Parameters.Add(_fax);
        newcmd.Parameters.Add(_field);
        newcmd.Parameters.Add(CreateBy);
        newcmd.Parameters.Add(_hash);
        newcmd.Parameters.Add(_exphash);
        newcmd.Parameters.Add(RetunParam);
        //////////////////////////////
        newcmd.Connection.Open();
        newcmd.ExecuteNonQuery();
        newcmd.Connection.Close();
        this.UserID = System.Convert.ToInt32(newcmd.Parameters[_userid.ParameterName].Value);
        return ResultMessage = new DBmessage(System.Convert.ToInt32(newcmd.Parameters[RetunParam.ParameterName].Value));
    }
    //public DBmessage DeleteAdmin()
    //{
    //    cmd = new SqlCommand("AdminDelete", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    ////
    //    SqlParameter _CardNo = new SqlParameter("@UserID", SqlDbType.Int);
    //    _CardNo.Value = this.UserID;
    //    ///
    //    cmd.Parameters.Add(_CardNo);
    //    cmd.Parameters.Add(RetunParam);
    //    ///
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    return ResultMessage = new DBmessage(Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    //}
    //public DBmessage DeleteSecurity()
    //{
    //    cmd = new SqlCommand("SecurityDelete", conn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    ////
    //    SqlParameter _CardNo = new SqlParameter("@UserID", SqlDbType.Int);
    //    _CardNo.Value = this.UserID;
    //    ///
    //    cmd.Parameters.Add(_CardNo);
    //    cmd.Parameters.Add(RetunParam);
    //    ///
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    return ResultMessage = new DBmessage(Convert.ToInt32(cmd.Parameters[RetunParam.ParameterName].Value));
    //}

    //public DataTableBatis Get()
    //{
    //    SqlConnection newcon = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AutoSysDB"].ConnectionString);
    //    SqlCommand newcmd = new SqlCommand("UserInfoGet", newcon);
    //    newcmd.CommandType = CommandType.StoredProcedure;

    //    SqlDataAdapter da = new SqlDataAdapter(newcmd);
    //    dt = new DataTableBatis();

    //    ////////////
    //    SqlParameter _userid = new SqlParameter("@UsrID", SqlDbType.Int);
    //    _userid.Value = this.UserID;
    //    //////////////////////
    //    da.SelectCommand.Parameters.Add(_userid);
    //    da.SelectCommand.Parameters.Add(RetunParam);
    //    /////////////
    //    conn.Open();
    //    da.Fill(dt);
    //    conn.Close();
    //    dt.Message = new DBmessage(Convert.ToInt32(da.SelectCommand.Parameters[RetunParam.ParameterName].Value));
    //    return dt;
    //}

    //public DBmessage ChangePassword(string oldpassword, string newpassword)
    //{
    //    SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AutoSysDB"].ConnectionString);
    //    SqlCommand command = new SqlCommand("UserPasswordChange", connection);

    //    command.CommandType = CommandType.StoredProcedure;
    //    ////
    //    SqlParameter _usrid = new SqlParameter("@UsrID", SqlDbType.Int);
    //    _usrid.Value = this.UserID;
    //    SqlParameter _oldpassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
    //    _oldpassword.Value = oldpassword;
    //    SqlParameter _newpassword = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50);
    //    _newpassword.Value = newpassword;
    //    ///
    //    command.Parameters.Add(_usrid);
    //    command.Parameters.Add(_oldpassword);
    //    command.Parameters.Add(_newpassword);
    //    command.Parameters.Add(RetunParam);
    //    ///
    //    connection.Open();
    //    command.ExecuteNonQuery();
    //    connection.Close();
    //    return ResultMessage = new DBmessage(Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));
    //}
    //public DBmessage RegisterOnJurnal()
    //{
    //    SqlCommand command = new SqlCommand("UserRegister", conn);
    //    command.CommandType = CommandType.StoredProcedure;
    //    //SqlParameter _usrid = new SqlParameter("@UsrID", SqlDbType.Int);
    //    //_usrid.Value = this.UserID;

    //    SqlParameter _affiliations = new SqlParameter("@Affiliations", SqlDbType.NVarChar, 100);
    //    _affiliations.Value = this.Affiliations;

    //    SqlParameter _fax = new SqlParameter("@Fax", SqlDbType.NVarChar);
    //    _fax.Value = this.Fax;

    //    SqlParameter _field = new SqlParameter("@Fields", SqlDbType.NVarChar);
    //    _field.Value = this.Fields;

    //    ////////////////////////////////////////////
    //    //command.Parameters.Add(_usrid);
    //    command.Parameters.Add(_affiliations);
    //    command.Parameters.Add(_fax);
    //    command.Parameters.Add(_field);
    //    command.Parameters.Add(RetunParam);
    //    /////////////////////////////////////////////
    //    conn.Open();
    //    command.ExecuteNonQuery();
    //    conn.Close();
    //    return ResultMessage = new DBmessage(Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));
    //}

    public DBmessage Delete(int subsystemid)
    {
        SqlConnection connection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand command = new SqlCommand("UserDelete", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlParameter _usrid = new SqlParameter("@UserID", SqlDbType.Int);
        _usrid.Value = this.UserID;
        SqlParameter _ssi = new SqlParameter("@SubSystemID", SqlDbType.Int);
        _ssi.Value = subsystemid;
        ////////////////////////////////////////////
        command.Parameters.Add(_usrid);
        command.Parameters.Add(_ssi);
        command.Parameters.Add(RetunParam);
        /////////////////////////////////////////////
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        return ResultMessage = new DBmessage(System.Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));
    }
    public DBmessage Edit()
    {
        SqlConnection connection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand command = new SqlCommand("UserEdit", connection);
        command.CommandType = CommandType.StoredProcedure;
        //
        SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
        _userid.Value = this.UserID;
        SqlParameter _username = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
        if (this.Username == "" || this.Username == null)
            _username.Value = DBNull.Value;
        else
            _username.Value = this.Username;
        SqlParameter _name = new SqlParameter("@Fname", SqlDbType.NVarChar, 50);
        if (this.Fname == "" || this.Fname == null)
            _name.Value = DBNull.Value;
        else
            _name.Value = this.Fname;
        SqlParameter _family = new SqlParameter("@Lname", SqlDbType.NVarChar, 50);
        if (this.Lname == "" || this.Lname == null)
            _family.Value = DBNull.Value;
        else
            _family.Value = this.Lname;
        SqlParameter _fathername = new SqlParameter("@FatherName", SqlDbType.NVarChar, 50);
        if (this.FatherName == "" || this.FatherName == null)
            _fathername.Value = DBNull.Value;
        else
            _fathername.Value = this.FatherName;
        if (this.FatherName == null)
            _fathername.Value = DBNull.Value;
        SqlParameter _nationalnumber = new SqlParameter("@MelliNumber", SqlDbType.VarChar, 10);
        if (this.Melli == "" || this.Melli == null)
            _nationalnumber.Value = DBNull.Value;
        else
            _nationalnumber.Value = this.Melli;

        SqlParameter _shno = new SqlParameter("@ShenasnameNumber", SqlDbType.VarChar, 10);
        if (this.Shenasname == "" || this.Shenasname == null)
            _shno.Value = DBNull.Value;
        else
            _shno.Value = this.Shenasname;

        SqlParameter _fax = new SqlParameter("@Fax", SqlDbType.NVarChar, 100);
        if (this.Fax == "" || this.Fax == null)
            _fax.Value = DBNull.Value;
        else
            _fax.Value = this.Fax;
        SqlParameter _affelitions = new SqlParameter("@Affelitions", SqlDbType.NVarChar, 100);
        if (this.Affiliations == "" || this.Affiliations == null)
            _affelitions.Value = DBNull.Value;
        else
            _affelitions.Value = this.Affiliations;
        SqlParameter _fields = new SqlParameter("@Fields", SqlDbType.NVarChar, 100);
        if (this.Fields == "" || this.Fields == null)
            _fields.Value = DBNull.Value;
        else
            _fields.Value = this.Fields;

        SqlParameter _dateofbirth = new SqlParameter("@BirtdayDate", SqlDbType.Date);
        if (this.Birthdate == null)
            _dateofbirth.Value = DBNull.Value;
        else
            _dateofbirth.Value = this.Birthdate.Datetime.Date;

        SqlParameter _birthplace = new SqlParameter("@BirthPlace", SqlDbType.NVarChar, 50);
        if (this.Birthplace == "" || this.Birthplace == null)
            _birthplace.Value = DBNull.Value;
        else
            _birthplace.Value = this.Birthplace;
        if (this.Birthplace == null)
            _birthplace.Value = DBNull.Value;
        SqlParameter _education = new SqlParameter("@Education", SqlDbType.NVarChar, 50);
        if (this.Education == "" || this.Education == null)
            _education.Value = DBNull.Value;
        else
            _education.Value = this.Education;
        SqlParameter _image = new SqlParameter("@UserImage", SqlDbType.Image);
        if (this.Image == null)
            _image.Value = DBNull.Value;
        else
            _image.Value = this.Image;
        SqlParameter _phone = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
        if (this.Phone == "" || this.Phone == null)
            _phone.Value = DBNull.Value;
        else
            _phone.Value = this.Phone;
        SqlParameter _email = new SqlParameter("@Email", SqlDbType.VarChar, 100);
        if (this.Email == "" || this.Email == null)
            _email.Value = DBNull.Value;
        else
            _email.Value = this.Email;
        SqlParameter _sex = new SqlParameter("@Sex", SqlDbType.Int);
        if (this.Sex == null)
            _sex.Value = DBNull.Value;
        else
            _sex.Value = this.Sex.ID;
        SqlParameter _issuedfrom = new SqlParameter("@IssuedFrom", SqlDbType.NVarChar, 50);
        if (this.IssuedFrom == "" || this.IssuedFrom == null)
            _issuedfrom.Value = DBNull.Value;
        else
            _issuedfrom.Value = this.IssuedFrom;
        SqlParameter _marriage = new SqlParameter("@Marriage", SqlDbType.NVarChar, 50);
        if (this.Marriage == "" || this.Marriage == null)
            _marriage.Value = DBNull.Value;
        else
            _marriage.Value = this.Marriage;
        SqlParameter _hash = new SqlParameter("@Hash", SqlDbType.NVarChar, 100);
        _hash = SetParameterValue(_hash, this.Hash);
        SqlParameter _exphash = new SqlParameter("@ExpHash", SqlDbType.SmallDateTime);
        if (this.ExpHash != null)
            _exphash.Value = this.ExpHash.Datetime;
        else
            _exphash.Value = DBNull.Value;
        //////////////////////////
        command.Parameters.Add(_userid);
        command.Parameters.Add(_username);
        command.Parameters.Add(_name);
        command.Parameters.Add(_family);
        command.Parameters.Add(_fathername);
        command.Parameters.Add(_nationalnumber);
        command.Parameters.Add(_shno);
        command.Parameters.Add(_fax);
        command.Parameters.Add(_affelitions);
        command.Parameters.Add(_fields);
        command.Parameters.Add(_dateofbirth);
        command.Parameters.Add(_birthplace);
        command.Parameters.Add(_education);
        command.Parameters.Add(_phone);
        command.Parameters.Add(_email);
        command.Parameters.Add(_sex);
        command.Parameters.Add(_issuedfrom);
        command.Parameters.Add(_marriage);
        command.Parameters.Add(_hash);
        command.Parameters.Add(_exphash);
        command.Parameters.Add(RetunParam);
        //////////////////////////////
        command.Connection.Open();
        command.ExecuteNonQuery();
        command.Connection.Close();
        //
        return ResultMessage = new DBmessage(System.Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));
    }
    public DBmessage ChangePassword()
    {
        SqlConnection connection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand command = new SqlCommand("UserPasswordEdit", connection);
        command.CommandType = CommandType.StoredProcedure;
        //
        SqlParameter _userid = new SqlParameter("@id", SqlDbType.Int);
        _userid.Value = this.UserID;
        SqlParameter _password = new SqlParameter("@password", SqlDbType.NVarChar, 50);
        if (this.Password == "" || this.Password == null)
            _password.Value = DBNull.Value;
        else
            _password.Value = this.Password;
        //
        command.Parameters.Add(_userid);
        command.Parameters.Add(_password);
        command.Parameters.Add(RetunParam);
        //////////////////////////////
        command.Connection.Open();
        command.ExecuteNonQuery();
        command.Connection.Close();
        //
        return ResultMessage = new DBmessage(System.Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));
    }
    public DBmessage ChangePassword(string newpassword)
    {
        SqlConnection connection = new SqlConnection(SysProperty.Jurnaldb);
        SqlCommand command = new SqlCommand("UserPasswordChange", connection);
        command.CommandType = CommandType.StoredProcedure;
        //
        SqlParameter _userid = new SqlParameter("@UsrID", SqlDbType.Int);
        _userid.Value = this.UserID;
        SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
        if (this.Password == "" || this.Password == null)
            _password.Value = DBNull.Value;
        else
            _password.Value = this.Password;
        SqlParameter _newpassword = new SqlParameter("@NewPassword", SqlDbType.NVarChar, 50);
        if (newpassword == "" || newpassword == null)
            _newpassword.Value = DBNull.Value;
        else
            _newpassword.Value = newpassword;
        //
        command.Parameters.Add(_userid);
        command.Parameters.Add(_password);
        command.Parameters.Add(_newpassword);
        command.Parameters.Add(RetunParam);
        //////////////////////////////
        command.Connection.Open();
        command.ExecuteNonQuery();
        command.Connection.Close();
        //
        return ResultMessage = new DBmessage(System.Convert.ToInt32(command.Parameters[RetunParam.ParameterName].Value));

    }
    #region static member
    public static List<User_cls> Convert(List<PaperWriter> source)
    {
        List<User_cls> result = new List<User_cls>();
        foreach (PaperWriter item in source)
        {
            result.Add(item);
        }
        return result;
    }

    public static User_cls ConvertDTToUser(DataRow dr)
    {
        User_cls user = new User_cls();
        if (dr != null)
        {
            if (!DBNull.Value.Equals(dr["UserID"]))
                user.UserID = System.Convert.ToInt32(dr["UserID"]);
            else
                user.UserID = 0;
            //
            if (!DBNull.Value.Equals(dr["Affiliations"]))
                user.Affiliations = dr["Affiliations"].ToString();
            //
            if (!DBNull.Value.Equals(dr["UserImage"]))
                user.Image = (byte[])dr["UserImage"];
            //
            if (!DBNull.Value.Equals(dr["Fax"]))
                user.Fax = dr["Fax"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Fields"]))
                user.Fields = dr["Fields"].ToString();
            //
            if (!DBNull.Value.Equals(dr["UsrUsername"]))
                user.Username = dr["UsrUsername"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Fname"]))
                user.Fname = dr["Fname"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Lname"]))
                user.Lname = dr["Lname"].ToString();
            //
            user.FullName = user.Fname + " " + user.Lname;
            //
            if (!DBNull.Value.Equals(dr["FatherName"]))
                user.FatherName = dr["FatherName"].ToString();
            //
            if (!DBNull.Value.Equals(dr["MelliNumber"]))
                user.Melli = dr["MelliNumber"].ToString();
            //
            if (!DBNull.Value.Equals(dr["ShenasnameNumber"]))
                user.Shenasname = dr["ShenasnameNumber"].ToString();
            //
            if (!DBNull.Value.Equals(dr["BirthdayDate"]))
                user.Birthdate = new PersianDateTime(System.Convert.ToDateTime(dr["BirthdayDate"].ToString()));
            //
            if (!DBNull.Value.Equals(dr["BirthPlace"]))
                user.Birthplace = dr["BirthPlace"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Education"]))
                user.Education = dr["Education"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Phone"]))
                user.Phone = dr["Phone"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Email"]))
                user.Email = dr["Email"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Sex"]))
            {
                Gender gender = new Gender(System.Convert.ToInt32(dr["Sex"]));
                user.Sex = gender;
            }
            //
            if (!DBNull.Value.Equals(dr["IssuedFrom"]))
                user.IssuedFrom = dr["IssuedFrom"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Marriage"]))
                user.Marriage = dr["Marriage"].ToString();
            //
            if (!DBNull.Value.Equals(dr["Active"]))
                user.Active = bool.Parse(dr["Active"].ToString());
            //
            if (dr.Table.Columns.Contains("Role") && !DBNull.Value.Equals(dr["Role"]))
            {
                user.Roles = Role.Convert(dr["Role"].ToString());DataTable dt; 
            }
            if (!DBNull.Value.Equals(dr["Hash"]))
                user.Hash = dr["Hash"].ToString();
        }

        return user;
    }
    public static List<User_cls> ConvertDTToUserList(DataTable dt)
    {
        List<User_cls> userList = new List<User_cls>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            userList.Add(ConvertDTToUser(dt.Rows[i]));
        }
        return userList;
    }
    #endregion








}
public class Gender
{
    int _id;
    string _title;


    public string Title
    {
        get { return _title; }
        set
        {
            _id = Gender.Convert(value);
            _title = value;
        }
    }
    public int ID
    {
        get { return _id; }
        set
        {
            _title = Gender.Convert(value);
            _id = value;
        }
    }
    public Gender(int id)
    {
        this.ID = id;
    }
    public static int Convert(string name)
    {
        if (SystemMessage_User.Male == name)
            return 1;
        else if (SystemMessage_User.Female == name)
            return 2;
        else
            throw new Exception("invalid gender name");
    }
    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return SystemMessage_User.Male;
            case 2:
                return SystemMessage_User.Female;

            default: throw new Exception("invalid gender id");
        }
    }
    public static int Male { get { return 1; } }
    public static int Female { get { return 2; } }
}
class SystemMessage_User : SystemMessage
{
    public static string Male
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Male";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "مرد";
            return "";
        }
    }
    public static string Female
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Female";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "زن";
            return "";
        }
    }
}
public class UserTable : DataTable
{
    public UserTable()
    {
        this.Columns.Add("UserID");
        this.Columns.Add("Affiliations");
        this.Columns.Add("Fax");
        this.Columns.Add("Fields");
        this.Columns.Add("UsrUsername");
        this.Columns.Add("UsrPassword");
        this.Columns.Add("UsrStatus");
        this.Columns.Add("Fname");
        this.Columns.Add("Lname");
        this.Columns.Add("FatherName");
        this.Columns.Add("MelliNumber");
        this.Columns.Add("ShenasnameNumber");
        this.Columns.Add("BirthdayDate");
        this.Columns.Add("BirthPlace");
        this.Columns.Add("Major");
        this.Columns.Add("Education");
        this.Columns.Add("Active");
        this.Columns.Add("Phone");
        this.Columns.Add("Email");
        this.Columns.Add("Sex");
        this.Columns.Add("IssuedFrom");
        this.Columns.Add("Marriage");
        this.Columns.Add("Date");
        this.Columns.Add("SubSystem");
        this.Columns.Add("Mobile");
        this.Columns.Add("Address");
        this.Columns.Add("PostNo");
    }
    public void Add(string affiliations, string fax, string fields, string userName, string password, string firstName
        , string lastName, string fatherName, string melliNumber, string shenasnameNumber, PersianDateTime birthDate, string birthPlace, string education,
         string phone, string email, int sex, string issuedFrom, string marriage, string subSystem, string mobile, string address, string postNO)
    {
        object obj = null;
        if (birthDate != null)
            obj = birthDate.Datetime;
        object obj_sex = null;
        if (sex != 0)
            obj = sex;

        this.Rows.Add(null,
            affiliations == string.Empty ? null : affiliations,
            fax == string.Empty ? null : fax,
            fields == string.Empty ? null : fields,
            userName == string.Empty ? null : userName,
            password == string.Empty ? null : password,
            null,
            firstName == string.Empty ? null : firstName,
            lastName == string.Empty ? null : lastName,
            fatherName == string.Empty ? null : fatherName,
            melliNumber == string.Empty ? null : melliNumber,
            shenasnameNumber == string.Empty ? null : shenasnameNumber,
            obj,
            birthPlace == string.Empty ? null : birthPlace,
            null,
            education == string.Empty ? null : education,

            true,
            phone == string.Empty ? null : phone,
            email == string.Empty ? null : email,
            obj_sex,
            issuedFrom == string.Empty ? null : issuedFrom,
            marriage == string.Empty ? null : marriage,
            null,
            subSystem,
            mobile == string.Empty ? null : mobile,
            address == string.Empty ? null : address,
            postNO == string.Empty ? null : postNO);
    }
    public static UserTable Convert(List<User_cls> users)
    {
        UserTable usrTable = new UserTable();
        for (int i = 0; i < users.Count; i++)
        {
            usrTable.Add(users[i].Affiliations, users[i].Fax, users[i].Fields, users[i].Username, users[i].Password, users[i].Fname, users[i].Lname,
                users[i].FatherName, users[i].Melli, users[i].Shenasname, users[i].Birthdate, users[i].Birthplace, users[i].Education, users[i].Phone
                , users[i].Email, users[i].Sex == null ? 0 : users[i].Sex.ID, users[i].IssuedFrom, users[i].Marriage, "", "", "", "");
        }
        return usrTable;
    }
}
public class FullUser
{
    private Author _author;
    private Referee _referee;
    private User_cls _user;
    private Editor _editor;
    public Author Author
    {
        get { return _author; }
        set { _author = value; }
    }
    public Editor Editor
    {
        get { return _editor; }
        set { _editor = value; }
    }
    public Referee Referee
    {
        get { return _referee; }
        set { _referee = value; }
    }
    public User_cls User
    {
        get { return _user; }
        set { _user = value; }
    }
}

