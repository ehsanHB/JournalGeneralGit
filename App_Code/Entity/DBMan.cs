using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;


/// <summary>
/// Summary description for DBMan
/// </summary>
public class DBMan:SysProperty
{
    protected SqlConnection conn;
    protected SqlCommand cmd;
    protected SqlDataAdapter da;
    protected DataTable dt;
    protected DBmessage ResultMessage;
    private SqlParameter _returnvalue;
    private SqlParameter _createby;
    protected SqlParameter RetunParam
    {
        get
        {
            _returnvalue = new SqlParameter
            {
                ParameterName = ReturnValue,
                Direction = ParameterDirection.ReturnValue
            };
            return _returnvalue;
        }
    }
    protected SqlParameter CreateBy
    {
        get
        {
            return new SqlParameter("@CreateBy", SqlDbType.Int) { Value = SysProperty.Client.UserID };
        }
    }
    static private string ReturnValue
    { get { return "ReturnValue"; } }
    protected DBMan()
    {

        //Data Source=.;Initial Catalog=SAHADB;Integrated Security=True
        string strconn = SysProperty.Jurnaldb;
        //string strconn = @"Data Source=red.mysitehosted.com;Database=SAHEBDB;User ID=Developer;pwd=vagdartimjar";
        //string strconn = @"Data Source=.;Initial Catalog=SAHEBDB;Integrated Security=True";
        conn = new SqlConnection(strconn);
    }

    /// <summary>
    /// agar value = 0 ==> param.Value = DBNull.Value;
    /// </summary>
    /// <param name="param"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static SqlParameter SetParameterValue(SqlParameter param, int value)
    {
        if (value == 0)
            param.Value = DBNull.Value;
        else
            param.Value = value;
        return param;
    }
    public static SqlParameter SetParameterValue(SqlParameter param, Int64 value)
    {
        if (value == 0)
            param.Value = DBNull.Value;
        else
            param.Value = value;
        return param;
    }
    public static SqlParameter SetParameterValue(SqlParameter param, string value)
    {
        if (value == null || value.Trim() == ""  || value.Trim() == string.Empty)
            param.Value = DBNull.Value;
        else
            param.Value = value.Trim();
        return param;
    }
    public static SqlParameter SetParameterValue(SqlParameter param, PersianDateTime value)
    {
        if (value == null)
            param.Value = DBNull.Value;
        else
            param.Value = value.Datetime;
        return param;
    }
    public static SqlParameter SetParameterValue(SqlParameter param, bool value)
    {
        param.Value = value;
        return param;
    }
}