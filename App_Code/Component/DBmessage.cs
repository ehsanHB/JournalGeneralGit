using System;

/// <summary>
/// Summary description for DBmessage
/// </summary>
public class DBmessage
{
    private string _message;
    private int _id;
    private DBMessageType _type;
    private DataContainer _parameter;

    public DataContainer Parameter
    {
        get { return _parameter; }
        set { _parameter = value; }
    }
    public string Message
    {
        set { _message = value; }
        get { return _message; }
    }
    public int ID
    {
        set
        {
            _id = value;
            int num = value % 10;
            if (num == 0)
                _type = DBMessageType.NoShow;
            else if (num == 1)
                _type = DBMessageType.Sucsess;
            else if (num > 1 && num < 8)
                _type = DBMessageType.Error;
            else if (num == 8)
                _type = DBMessageType.Info;
            else if (num == 9)
                _type = DBMessageType.Alert;

        }
        get { return _id; }
    }
    public DBMessageType Type
    {
        get { return _type; }
    }
    public DBmessage(int id)
    {
        this.Parameter = new DataContainer();
        ID = id;
        switch (ID)
        {
            case 6101:
                Message = SystemMessage_DBMessage.SuccessFullRegisteration;
                break;
            case 6102:
                Message = SystemMessage_DBMessage.FaildRegisteration;
                break;
            case 6103:
                Message = SystemMessage_DBMessage.MoreThanOneChefEditorOrAdmin;
                break;
            case 6201:
                Message = SystemMessage_DBMessage.SuccessFullRemove;
                break;
            case 6202:
                Message = SystemMessage_DBMessage.FaildRemove;
                break;
            case 6301:
                Message = SystemMessage_DBMessage.SuccessFullEdition;
                break;
            case 6302:
                Message = SystemMessage_DBMessage.FaildEdition;
                break;
            case 6402:
                Message = SystemMessage_DBMessage.AccessPeremisionForAdmin;
                break;
            case 6403:
                Message = SystemMessage_DBMessage.AvailableUser;
                break;
            case 6105:
                Message = SystemMessage_DBMessage.RepetitiveEmail;
                break;
            case 6106:
                Message = SystemMessage_DBMessage.NameOfEvaluationFormIsRepetetive;
                break;
            /////////////START: code zir system marja felan injast\\\\\\\\\\\\\\\\\
            case 1101:
                Message = SystemMessage_DBMessage.SuccessFullRegisteration;
                break;
            case 1102:
                Message = SystemMessage_DBMessage.FaildRegisteration;
                break;
            case 1105:
                Message = SystemMessage_DBMessage.RepetitiveEmail;
                break;
            case 1106:
                Message = SystemMessage_DBMessage.NationalDuplicateCode;
                break;
            case 1107:
                Message = SystemMessage_DBMessage.WrongPassword;
                break;
            case 1301:
                Message = SystemMessage_DBMessage.SuccessFullEdition;
                break;
            case 1302:
                Message = SystemMessage_DBMessage.FaildEdition;
                break;
            case 1305:
                Message = SystemMessage_DBMessage.RepetitiveEmail;
                break;
            case 1400:
                Message = SystemMessage_DBMessage.SuccessfullSelectionOpr;
                break;
            case 1408:
                Message = SystemMessage_DBMessage.NothingFound;
                break;
            case 6405:
                Message = SystemMessage_DBMessage.DuplicateEmail;
                break;
            case 1201:
                Message = SystemMessage_DBMessage.SuccessFullRemove;
                break;
            case 1202:
                Message = SystemMessage_DBMessage.FaildRemove;
                break;
            ///////////////////////////////
            case 4101:
                Message = SystemMessage_DBMessage.SuccessFullRegisteration;
                break;
            case 4102:
                Message = SystemMessage_DBMessage.FaildRegisteration;
                break;
            case 4201:
                Message = SystemMessage_DBMessage.SuccessFullRemove;
                break;
            default:

                ////////////END :   code zir system marja felan injast\\\\\\\\\\\\\\\\\\\\
                throw new Exception("id from db not found");

        }

    }
    /// <summary>
    /// yek message dorost mikonad ke id va message motabeghe argoman ast va niaz nist az ghabl id sabt shode bashad, faghat standard cod gozari rayat shavad
    /// </summary>
    /// <param name="id"></param>
    /// <param name="message"></param>
    public DBmessage(int id, string message)
    {
        this.Parameter = new DataContainer();
        ID = id;
        _message = message;
    }
    /// <summary>
    /// yek message dorost mikone ba matn va type moshakhas shode
    /// </summary>
    /// <param name="messagetype"></param>
    /// <param name="message"></param>
    public DBmessage(DBMessageType messagetype, string message)
    {
        _message = message;
        _type = messagetype;
        this.Parameter = new DataContainer();
    }

}
public enum DBMessageType
{
    Sucsess,
    Info,
    Alert,
    Error,
    NoShow,
}
public class SystemMessage_DBMessage
{
    #region static Props
    /// <summary>
    /// عملیات ثبت با موفقیت انجام شد
    /// </summary>
    public static string SuccessFullRegisteration
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Registration was successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات ثبت با موفقیت انجام شد";
            return "";
        }
    }
    /// <summary>
    /// نام فرم ارزیابی تکراری است
    /// </summary>
    public static string NameOfEvaluationFormIsRepetetive
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Name of evaluation form is repetetive";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "نام فرم ارزیابی تکراری است";
            return "";
        }
    }
    /// <summary>
    /// این سیستم نمی تواند بیش از یک مدیر و یا بیش از یک سردبیر داشته باشد
    /// </summary>
    public static string MoreThanOneChefEditorOrAdmin
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "It can not be more than one admin or more than one chef editor in this system";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "این سیستم نمی تواند بیش از یک مدیر و یا بیش از یک سردبیر داشته باشد";
            return "";
        }
    }
    /// <summary>
    /// عملیات ثبت با موفقیت انجام نشد
    /// </summary>
    public static string FaildRegisteration
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Registration was not successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات ثبت با موفقیت انجام نشد";
            return "";
        }
    }
    /// <summary>
    /// عملیات ویرایش با موفقیت انجام شد
    /// </summary>
    public static string SuccessFullEdition
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Editing operation was successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات ویرایش با موفقیت انجام شد";
            return "";
        }
    }
    /// <summary>
    /// عملیات ویرایش با موفقیت انجام نشد
    /// </summary>
    public static string FaildEdition
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Editing operations failed";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات ویرایش با موفقیت انجام نشد";
            return "";
        }
    }
    /// <summary>
    /// شما به عنوان مدیر داخلی وارد نشده اید
    /// </summary>
    public static string AccessPeremisionForAdmin
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "You are not logged as Admin";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما به عنوان مدیر داخلی وارد نشده اید";
            return "";
        }
    }
    /// <summary>
    /// کاربر مورد نظر موجود میباشد
    /// </summary>
    public static string AvailableUser
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "The user is available";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "کاربر مورد نظر موجود میباشد";
            return "";
        }
    }
    /// <summary>
    /// نام کاربری  تکراری است
    /// </summary>
    public static string RepetitiveEmail
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Email is repetitive";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "ایمیل  تکراری است";
            return "";
        }
    }
    /// <summary>
    /// کد ملی تکراری است
    /// </summary>
    public static string NationalDuplicateCode
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "National duplicate code";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "کد ملی تکراری است";
            return "";
        }
    }
    /// <summary>
    /// رمز عبور اشتباه می باشد
    /// </summary>
    public static string WrongPassword
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Password is wrong";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "رمز عبور اشتباه می باشد";
            return "";
        }
    }
    /// <summary>
    /// عملیات انتخاب با موفقیت انجام شد
    /// </summary>
    public static string SuccessfullSelectionOpr
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "The operation was successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات انتخاب با موفقیت انجام شد";
            return "";
        }
    }
    /// <summary>
    /// موردی یافت نشد
    /// </summary>
    public static string NothingFound
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Nothing found";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "موردی یافت نشد";
            return "";
        }
    }
    /// <summary>
    /// عملیات حذف با موفقیت انجام شد
    /// </summary>
    public static string SuccessFullRemove
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Removal operation was successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات حذف با موفقیت انجام شد";
            return "";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public static string FaildRemove
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Delete operation was not successful";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات حذف با موفقیت انجام نشد";
            return "";
        }
    }
    /// <summary>
    /// ایمل داده شده قبلا در سیستم ثبت شده بود
    /// </summary>
    public static string DuplicateEmail { get { return SystemMessage.GetMessage("Email is already registered in the system", "ایمل داده شده قبلا در سیستم ثبت شده بود"); } }
    /// <summary>
    /// حداقل باید اطلاعات کامل یک نویسنده ثبت گردد.
    /// </summary>
    public static string NotRegisterOnePersonFullInfo
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "You must register full information of at least one person";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "حداقل باید اطلاعات کامل یک فرد ثبت گردد.";
            return "";
        }
    }
    #endregion

}

