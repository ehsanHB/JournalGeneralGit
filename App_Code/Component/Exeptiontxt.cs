using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Exeptiontxt
/// </summary>
public class Exeptiontxt
{
    public static string NotAuthorRole
    {
        get
        {
            if (SysProperty.SiteLanguage == Languages.English)
            {
                return "you must be an author to do this";
            }
            else
            {
                return "";
            }
        }
    }
	public Exeptiontxt()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}