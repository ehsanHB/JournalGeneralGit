using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;


public class FileOperations
{
    public static string SetId()
    {

        string _id = "";
        Random r = new Random();
        _id = DateTime.Now.Year.ToString();
        _id += DateTime.Now.Month.ToString();
        _id += DateTime.Now.Day.ToString();
        _id += DateTime.Now.Hour.ToString();
        _id += DateTime.Now.Minute.ToString();
        _id += DateTime.Now.Second.ToString();
        _id += DateTime.Now.Millisecond.ToString();
        _id += r.Next(10001, 99999).ToString();
        _id = clsSecurity.ComputeMD5(_id);
        return _id;
    }
    /// <summary>
    /// zakhire kardan yek httppostedfile dar masiri moshakhas, va dar sorat movafaght bodan retun mishavad
    /// </summary>
    /// <param name="file"></param>
    /// <param name="PhysicalPath">adrese fiziki poshe ee ke bayad unja zakhire shavad</param>
    /// <param name="filenameforsave">esmei ke baraye file jahat zakhire estefade mishavad, bedone type bashad</param>
    /// <param name="validFileType">list format haee ke valid ast bedone .</param>
    /// <returns>dar khane 0 parametre DBmessage esme kamele file be hamrahe typash mojud ast</returns>
    public static DBmessage SaveAs(HttpPostedFile file, string PhysicalPath, string filenameforsave, List<string> validFileType)
    {
        if (file == null || file.ContentLength == 0)
            return new DBmessage(DBMessageType.Info, "no file exist to upload");
        string ext = System.IO.Path.GetExtension(file.FileName); // masir ra midahad 
        if (validFileType != null && validFileType.Count != 0)
            if (validFileType.Find(delegate (string s) { if (ext.ToLower() == s.ToLower()) return true; return false; }) == null)
                return new DBmessage(DBMessageType.Error, "Invalid File Type");

        filenameforsave = filenameforsave + ext;
        int i = 1;
        while (System.IO.File.Exists(PhysicalPath + "\\" + filenameforsave))
        {
            filenameforsave = SetId() + i.ToString() + ext;
            i++;
        }
        file.SaveAs(PhysicalPath + "\\" + filenameforsave);
        DBmessage result = new DBmessage(DBMessageType.Sucsess, "upload compelete");
        result.Parameter["FileName"] = filenameforsave;

        return result;


    }

    private static byte[] readFile(string strPath)
    {
        byte[] Data = null;

        //  (FileInfo)گرفتن سایز عکس بوسیله فایل اینفو
        FileInfo fInfo = new FileInfo(strPath);
        long numBytes = fInfo.Length;

        //   برای خواندن عکس(FileStream)استفاده از 
        using (FileStream fStream = new FileStream(strPath, FileMode.Open, FileAccess.Read))
        {

            //  برای خواندن عکس از فیل استریم و تبدیل به آرایه ای از بایت(BinaryReader)استفاده از
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            Data = br.ReadBytes((int)numBytes);
            fStream.Close();
            br.Close();
        }
        return Data;
    }
    public static byte[] getFile(HttpPostedFile postesFile, string path, string[] validFileType)
    {
        if (uploadFile(postesFile, ref path, validFileType) == "uploaded")
        {
            byte[] img = readFile(path);
            deleteFile(path);
            return img;
        }
        return null;
    }
    private static bool deleteFile(string path)
    {
        if (File.Exists(path))
        {

            File.Delete(path);
            return true;
        }
        else
            return false;
    }
    /// <summary>
    /// zakhire kardan yek httppostedfile dar masiri moshakhas,name kamel file be sorate randomentekhab mishavad va dar sorat movafaght bodan retun mishavad
    /// </summary>
    /// <param name="file"></param>
    /// <param name="PhysicalPath"></param>
    /// <param name="validFileType"></param>
    /// <returns>dar khane 0 parametre DBmessage esme kamele file be hamrahe typash mojud ast</returns>
    public static DBmessage SaveAs(HttpPostedFile file, string PhysicalPath, List<string> validFileType)
    {
        return SaveAs(file, PhysicalPath, SetId(), validFileType);
    }
    public static string uploadFile(HttpPostedFile file, ref string path, string[] validFileType,int authorizedSize = 100)
    {
        

        if (file == null) return null;
        //1
        //path = Server.MapPath(".") + "\\up\\" + FileUpload1.PostedFile.FileName;
        //path += FileUpload1.PostedFile.FileName;
        //2

        string ext = System.IO.Path.GetExtension(file.FileName); // masir ra midahad 
        if (Array.IndexOf(validFileType, ext.ToLower()) < 0)

            throw new MyException("فرمت فایل انتخاب شده مورد قبول نمی باشد", 105, "FileType");
        //3
        long size = file.ContentLength;
        size = size / 1024;
        if (size > authorizedSize)
        {

            throw new MyException("سایز فایل انتخاب شده باید کمتر از" + authorizedSize + "KB باشد", 105, "FileSize");
        }

        // controle size ax
        System.Drawing.Image myImage = System.Drawing.Image.FromStream(file.InputStream);
        if ((myImage.Width > 200) || (myImage.Height > 200))
        {
            throw new MyException("اندازه عکس انتخاب شده نباید بیشتر از 300*300 پیکسل باشد", 101, "");
        }

        //4
        string filename = file.FileName;
        //5
        while (System.IO.File.Exists(path + "\\" + filename))
        {
            filename = "1" + filename;
        }
        //6
        path += "\\" + filename;
        file.SaveAs(path);
        return "uploaded";

    }
}

//public class SystemMessage_FileOperation
//{
//    public static string InvaliFileType_Error
//    {
//        get { return SystemMessage.GetMessage("")}
//    }
//}






//using Ext.Net;
///<summary>
///Summary description for FileOperations
///</summary>
public class FileOperations_test
{
    private void SetValue()
    {

    }
    public FileOperations_test()
    {

        // TODO: Add constructor logic here

    }
    private string _temppath = ServerDirectory.TempPhysical;
    /// <summary>
    /// adrese poshe zakhire sazi file haye movaghat ke baraye anjam amaliat upload momken ast niaz bashad
    /// </summary>
    public string TempPathe
    {
        set { _temppath = value; }
        get { return _temppath; }
    }

    private List<string> _validfiletype;
    /// <summary>
    /// liste format haye mojaz baraye upload shodan dar server
    /// </summary>
    public List<string> ValidFileType
    {
        set { _validfiletype = value; }
        get { return _validfiletype; }
    }
    int _maxsize = 200000;
    /// <summary>
    /// hade aksar hajme file be KB ke mitavanad upload shavad, pishfarz 200000KB
    /// </summary>
    public int MaxSize
    {
        set { _maxsize = value; }
        get { return _maxsize; }
    }
    private string _savepath;
    public string SavePath
    {
        set { _savepath = value; }
        get { return _savepath; }
    }
    ///<summary>
    ///##EHSAN## fili ra gerfte va besorate byte baz migardanad
    ///</summary>
    ///<param name="fu">file uploader havie file morede nazar</param>
    ///<param name="path">address jahate uploade movaghate file</param>
    ///<returns>file daryafty besorate bytes</returns>
    public byte[] getFile(FileUpload fu, string path)
    {

        string filename = SetId();

        if (UploadFile(fu, path, ref filename))
        {
            string filepath = path + "\\" + filename + System.IO.Path.GetExtension(fu.PostedFile.FileName);
            byte[] img = readFile(filepath);
            deleteFile(filepath);
            return img;

        }
        else
            return null;

    }
    public byte[] getFile(string path)
    {
        try
        {
            byte[] img = readFile(path);
            deleteFile(path);
            return img;
        }
        catch (Exception)
        {

            return null;
        }
    }
    public string getFileWithoutDelete(FileUpload fu, string path)
    {
        string str = "";
        if (uploadFile(fu, ref path) == "uploaded")
        {
            return "uploaded";
        }
        return str;
    }
    ///<summary>
    ///##EHSAN## jahate upload file dar yek directory
    ///</summary>
    ///<param name="FileUpload1">file uploader havie file</param>
    ///<param name="path">addresse directory jahate upload file</param>
    ///<returns>darsorate upload movafagh "uploaded" barmigaradnad. darsorate motabar nabodane file string havie error morede nazar ast</returns>
    private string uploadFile(FileUpload FileUpload1, ref string path)
    {
        int authorizedSize = 2000;
        String[] validFileType = { ".jpg", ".gif", ".png", ".rar", ".zip", ".pdf" };
        try
        {
            //1
            //path = Server.MapPath(".") + "\\up\\" + FileUpload1.PostedFile.FileName;
            path += "\\" + FileUpload1.PostedFile.FileName;

            //2
            string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName); // masir ra midahad 
            if (Array.IndexOf(validFileType, ext.ToLower()) < 0)//donbale chi ? koja ?
                return "Invalid file extension";
            //3
            long size = FileUpload1.PostedFile.ContentLength;
            size = size / 1024;
            if (size > authorizedSize)
            {
                return "File size must lower than " + authorizedSize.ToString() + "kb";
            }
            //4
            string filename = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            //5
            while (System.IO.File.Exists(path + "\\" + filename))
            {
                filename = "1" + filename;
            }
            //6
            path += filename;
            FileUpload1.PostedFile.SaveAs(path);
            return "uploaded";
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message.ToString();
        }
    }
    public static string SetId()
    {

        string _id = "";
        Random r = new Random();
        _id = DateTime.Now.Year.ToString();
        _id += DateTime.Now.Month.ToString();
        _id += DateTime.Now.Day.ToString();
        _id += DateTime.Now.Hour.ToString();
        _id += DateTime.Now.Minute.ToString();
        _id += DateTime.Now.Second.ToString();
        _id += DateTime.Now.Millisecond.ToString();
        _id += r.Next(10001, 99999).ToString();
        return _id;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FileUpload"></param>
    /// <param name="path">directory baraye zakhire</param>
    /// <param name="filenametosave">name fail baraye zakhire bedone format file, va bedone format file ham ref mikonad</param>
    /// <returns></returns>
    private bool UploadFile(FileUpload FileUpload, string path, ref string filenametosave)
    {
        if (!FileUpload.HasFile)
            return false;
        string ext = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName); // masir ra midahad 
        if (ValidFileType != null)
            if (Array.IndexOf(ValidFileType.ToArray(), ext.ToLower()) < 0)//donbale chi ? koja ?
                throw new MyException("فرمت فابل قابل قبول نیست", 105, "");
        //3
        long size = FileUpload.PostedFile.ContentLength;
        size = size / 1024;
        if (size > MaxSize)
        {
            throw new MyException("حجم فایل آپلودی باید کمتر از " + MaxSize.ToString() + "KB", 105, "");

        }
        //4
        string extention = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
        //5
        while (System.IO.File.Exists(path + "\\" + filenametosave + extention))
        {
            filenametosave = filenametosave + "1";
        }
        //6

        path += "\\" + filenametosave + extention;
        FileUpload.PostedFile.SaveAs(path);
        return true;

    }
    public string UploadFile(FileUpload FileUpload, string path, string[] fileTypeValid, int MaxValidSize)
    {
        if (FileUpload.FileName == String.Empty)
            return string.Empty;
        string ext = System.IO.Path.GetExtension(FileUpload.PostedFile.FileName);
        if (fileTypeValid != null)
            ValidFileType = fileTypeValid.ToList<string>();
        if (ValidFileType != null)
            if (Array.IndexOf(ValidFileType.ToArray(), ext.ToLower()) < 0)//donbale chi ? koja ?
                throw new MyException("فرمت فابل قابل قبول نیست", 105, "");
        //3
        long size = FileUpload.PostedFile.ContentLength;
        size = size / 1024;
        MaxSize = MaxValidSize;
        if (size > MaxSize)
        {
            throw new MyException("حجم فایل آپلودی باید کمتر از " + MaxSize.ToString() + "KB", 105, "");

        }
        //4
        //5
        string filenametosave = SetId();
        while (System.IO.File.Exists(path + "\\" + filenametosave + ext))
        {
            filenametosave = filenametosave + "1";
        }
        //6

        path += "\\" + filenametosave + ext;
        FileUpload.PostedFile.SaveAs(path);
        return filenametosave + ext;

    }


    ///<summary>
    ///##EHSAN## jahate khandane fili dar directory va tabdile an be bytes
    ///</summary>
    ///<param name="strPath">addresse file dar directorye barname</param>
    ///<returns>file tabdil be byte shode</returns>
    public byte[] readFile(string strPath)
    {
        byte[] Data = null;
        //string strPath = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        // (FileInfo)????? ???? ??? ?????? ???? ?????
        FileInfo fInfo = new FileInfo(strPath);
        //string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        long numBytes = fInfo.Length;

        //???? ?????? ???(FileStream)??????? ?? 
        FileStream fStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

        //???? ?????? ??? ?? ??? ?????? ? ????? ?? ????? ?? ?? ????(BinaryReader)??????? ??
        BinaryReader br = new BinaryReader(fStream);

        //When you use BinaryReader, you need to supply number of bytes to read from file.
        //In this case we want to read entire file. So supplying total number of bytes.
        Data = br.ReadBytes((int)numBytes);
        fStream.Close();
        return Data;
    }
    private byte[] readFileWithoutDelete(string strPath)
    {
        byte[] Data = null;
        //string strPath = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        //(FileInfo)????? ???? ??? ?????? ???? ?????
        FileInfo fInfo = new FileInfo(strPath);
        //string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        long numBytes = fInfo.Length;

        // ???? ?????? ???(FileStream)??????? ?? 
        FileStream fStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

        //  ???? ?????? ??? ?? ??? ?????? ? ????? ?? ????? ?? ?? ????(BinaryReader)??????? ??
        BinaryReader br = new BinaryReader(fStream);

        ///When you use BinaryReader, you need to supply number of bytes to read from file.
        ///In this case we want to read entire file. So supplying total number of bytes.
        Data = br.ReadBytes((int)numBytes);
        fStream.Close();
        return Data;
    }

    ///<summary>
    ///##EHSAN## hazfe file az directory barname
    ///</summary>
    ///<param name="path">addresse kamele file dar directory barname</param>
    ///<returns>true: darsorate movafagh bodane; false: darsorate movafagh nabodan</returns>
    public bool deleteFile(string path)
    {
        if (File.Exists(path))
        {

            File.Delete(path);
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// create directory
    /// </summary>
    /// <param name="path">adrese directory ke mikhahahid sakhte shavad</param>
    /// <returns>adrese directory kle sakhte shod</returns>
    public string CreateDirectory(string path)
    {
        while (Directory.Exists(path))
        {
            path = path + "1";
        }
        Directory.CreateDirectory(path);
        return path;


    }
    /// <summary>
    /// in tabe baraye zakhire kardane file mibashad
    /// </summary>
    /// <param name="fileuploader"></param>
    /// <param name="filename">in file name bayad string directory + filename bedoone formate file bashad</param>
    public static string SaveAs(FileUpload fileuploader, string filename)
    {

        string exp = System.IO.Path.GetExtension(fileuploader.PostedFile.FileName);
        filename = filename + exp;
        fileuploader.SaveAs(filename);
        return filename;
    }




}