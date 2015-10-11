using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Directory
/// </summary>
static public class ServerDirectory
{
    static string _host;
    public static string Host
    {
        set { _host = value; }
        get
        {
            return _host;
            //return "http://localhost:60694";//mahmud laptop 
        }
    }
    static string _physicalPath;

    public static string PhysicalPath
    {
        get { return ServerDirectory._physicalPath; }
        set { ServerDirectory._physicalPath = value; }
    }
    public static string LoginPage
    {
        get
        {
            return Host + @"\Login.aspx";
        }
    }
    public static string Admin
    {
        get
        {
            return Host + "/Admin";
        }
    }
    public static string Paper
    {
        get
        {
            return Host + "/Paper";
        }
    }
    
    public static string User
    {
        get
        {
            return Host + "/User";
        }
    }
    
    public static string AppDataVirtual
    {
        get { return Host + "/App_Data"; }
    }
    public static string AppDataPhysical
    {
        get { return PhysicalPath + "\\App_Data"; }
    }
    public static string PaperFilesPhysical
    {
        get { return AppDataPhysical + "\\PaperFiles"; }
    }
    
    public static string TempVirtual
    {
        get { return AppDataVirtual + "/Temp"; }
    }
    
    public static string TempPhysical
    {
        get { return AppDataPhysical + "\\Temp"; }
    }

    public static string UserImagePathPhysical
    {
        get { return TempPhysical + "\\UserImage"; }
    }
    public static string UserImageVirtual
    {
        get { return TempVirtual + "/UserImage"; }
    }

    public static string UploadVirtual
    {
        get { return Host + "/Uploaded"; }
    }

    public static string UploadPhysical
    {
        get { return PhysicalPath + "\\Uploaded"; }
    }

}
