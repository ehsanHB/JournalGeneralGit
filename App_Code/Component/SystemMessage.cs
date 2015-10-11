using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// classi jahat gharar dadane peygham haye koli system ast, jahate elam khata ya info be karbar, pedar tamame class haye digari ke in kar ra anjam midahand
/// </summary>
public  class SystemMessage
{
    /// <summary>
    /// مقاله بدون فایل اصلی با فرمت .docx نمیتواند ثبت شود
    /// </summary>
    public static string RequierDocFile
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "مقاله بدون فایل اصلی با فرمت .docx نمیتواند ثبت شود";
            if (SysProperty.SiteLanguage == Languages.English)
                return "Articles without original file format .docx can not be recorded";
            return "";
        }
    }

    /// <summary>
    /// شما به این قسمت دسترسی ندارید
    /// </summary>
	public static string AccessDeny
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Access deny!";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما به این قسمت دسترسی ندارید";
            return "";
        }
    }
    public static string EmailCannotEmpty
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Email can not empty.";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "ایمیل نمیتواند خالی باشد";
            return "";
        }
    }
    /// <summary>
    /// شما به این قسمت دسترسی ندارید!\n شما باید حق دسترسی نویسنده را داشته باشد
    /// </summary>
    public static string AccessDeny_ForAuthor
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Access deny! \n You must have 'Author' access!";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "شما به این قسمت دسترسی ندارید!\n شما باید حق دسترسی نویسنده را داشته باشد";
            return "";
        }
    }
    /// <summary>
    /// عملیات غیر مجاز
    /// </summary>
    public static string InvalidOperation
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Invaid opration!";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "عملیات غیر مجاز";
            return "";
        }
    }
    /// <summary>
    /// دوباره سعی کنید
    /// </summary>
    public static string TryAgain
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
                return "Try again!";
            if (SysProperty.SiteLanguage == Languages.Persion)
                return "دوباره سعی کنید";
            return "";
        }
    }
    /// <summary>
    /// bazgasht matne payam ba tavajoh be zabane site
    /// </summary>
    /// <param name="message">0 --> English , 1 --> Persian</param>
    /// <returns></returns>
    public static string GetMessage(params string[] message)
    {
        if (SysProperty.SiteLanguage == Languages.English)
            return message[0];
        if (SysProperty.SiteLanguage == Languages.Persion)
            return message[1];
        return "";
    }
}