using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyException
/// </summary>
public class MyException:Exception
{
    #region//VALUES

    int _id;
    string _field;
    string _overallmessage;

    #endregion

    #region//PROPRTY

    public int Id
    {
        set
        {
            if (value==101)
            {
                _overallmessage = "Too larg!!";
                _id = value; 
            }
            else if (value==201)
            {
                _overallmessage = "You can't assign values!!";
            }
            else if (value==102)
            {
                _overallmessage = "To Small!!";
            }
            else if(value==104)
            {
                _overallmessage = "Not alowed for null";
            }
            else if (value == 105)
            {
                _overallmessage = "Wrong value!!";
            }
            else if (value == 204)
            {
                _overallmessage = "Wrong value!!";
            }
                else if(value==301)
            {
                _overallmessage = "Error in file opration";
            }
            else if (value == 302)
            {
                _overallmessage = "Error in Running client side JavaScript";
            }
            else
            {
                Exception ex = new Exception(string.Format("Exception ID not found!!, ID={0}",value));
                throw ex;
            }
        }

        get { return _id; }
    }
    public string Field
    {
        set { _field = value; }
        get { return _field; }
    }
    public string OverallMessage
    {
        set { }
        get { return _overallmessage; }
    }

    #endregion

    #region//FUNCTION

    public MyException()
        : base()
    { }
    public MyException(string message, int id, string field)
        : base(message)
    {
        Id = id;
        Field = field;
    }

    #endregion

}