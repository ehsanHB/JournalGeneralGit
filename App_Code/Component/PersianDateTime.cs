using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// tarikh shamsi
/// Create by Hossein Es'hahi
/// </summary>
public class PersianDateTime
{
    
    /// <summary>
    /// 
    /// </summary>
    public static PersianDateTime MinValue
    {
        get { return new PersianDateTime(new DateTime(1901, 1, 1)); }
    }
    /// <summary>
    /// 
    /// </summary>
    public static PersianDateTime MaxValue
    {
        get { return new PersianDateTime(new DateTime(2078, 12, 29)); }
    }
    private int dayofyear;
    public int Dayofyear
    {
        get { return Persiancalender.GetDayOfYear(Datetime); }

    }
    private DateTime datetime;
    /// <summary>
    /// tarikh miladi dar in moteghayer mojod ast
    /// </summary>
    public DateTime Datetime
    {
        get { return Persiancalender.ToDateTime(Year, Month, Day, Hour, Minute, Secend, 0); }
    }

    private int year;
    PersianCalendar persiancalender;

    public PersianCalendar Persiancalender
    {
        get { return persiancalender; }
        set { persiancalender = value; }
    }
    /// <summary>
    /// set ya get sal
    /// </summary>
    public int Year
    {
        get { return year; }
        set
        {
            if (value >= 1132 && value < 2001)
                year = value;
            else if (value >= 20 && value < 99)
                year = 1300 + value;
            else
            {
                MyException ex = new MyException("سال اشتباه وارد شده", 104, "PersianDateTime.Year");
                throw ex;
            }
        }
    }


    private int month;

    /// <summary>
    /// set ya get shomare mah
    /// </summary>
    public int Month
    {
        get { return month; }
        set
        {
            if (value > 0 && value < 13)
                month = value;
            else
            {
                MyException ex = new MyException("ماه اشتباه وارد شده", 104, "PersianDateTime.Month");
                throw ex;
            }
        }
    }

    private int day;
    /// <summary>
    /// set ya get shomare roze mah
    /// </summary>
    public int Day
    {
        get { return day; }
        set
        {
            if (value > 0 && value < 32)

                day = value;
            else
            {
                MyException ex = new MyException("روز اشتباه وارد شده", 104, "PersianDateTime.Day");
                throw ex;
            }
        }
    }
    private int hour;

    /// <summary>
    /// set ya get sat. 24 base
    /// </summary>
    public int Hour
    {
        get { return hour; }
        set
        {
            if (value >= 0 && value < 24)
                hour = value;
            else
            {
                MyException ex = new MyException("ساعت اشتباه وارد شده", 104, "PersianDateTime.Hour");
                throw ex;
            }
        }
    }

    private int minute;
    /// <summary>
    /// set ya get daghighe
    /// </summary>
    public int Minute
    {
        get { return minute; }
        set
        {
            if (value >= 0 && value < 60)
                minute = value;
            else
            {
                MyException ex = new MyException("دقیقه اشتباه وارد شده", 104, "PersianDateTime.Minute");
                throw ex;
            }
        }
    }
    private int secend;
    /// <summary>
    /// set ya get saniye
    /// </summary>
    public int Secend
    {
        get { return secend; }
        set
        {
            if (value >= 0 && value < 60)
                secend = value;
            else
            {
                MyException ex = new MyException("ثانیه اشتباه وارد شده", 104, "PersianDateTime.Secend");
                throw ex;
            }
        }
    }
    private string dayofweek;
    /// <summary>
    /// get name roze hafte
    /// </summary>
    public string Dayofweek
    {
        get
        {
            string name = Datetime.DayOfWeek.ToString();
            switch (name)
            {
                case "Saturday":
                    return "شنبه";
                case "Sunday":
                    return "یکشنبه";
                case "Monday":
                    return "دوشنبه";
                case "Tuesday":
                    return "سه شنبه";
                case "Wednesday":
                    return "چهارشنبه";
                case "Thursday":
                    return "پنجشنبه";
                case "Friday":
                    return "جمعه";
            }
            MyException ex = new MyException("invalid name of day", 104, "Dayofweek");
            throw ex;
        }

    }

    /// <summary>
    /// gereftane name mah
    /// </summary>
    public string Nameofmonth
    {
        get
        {
            if (Month == 1)
                return "فروردین";
            else if (month == 2)
                return "اردیبهشت";
            else if (month == 3)
                return "خرداد";
            else if (month == 4)
                return "تیر";
            else if (month == 5)
                return "مرداد";
            else if (month == 6)
                return "شهریور";
            else if (month == 7)
                return "مهر";
            else if (month == 8)
                return "آبان";
            else if (month == 9)
                return "آذر";
            else if (month == 10)
                return "دی";
            else if (month == 11)
                return "بهمن";
            else if (month == 12)
                return "اسفند";
            MyException ex = new MyException("invalid month index", 10000, "Nameofmonth");
            throw ex;
        }

    }
    /// <summary>
    /// daryaft tarikh miladi va convert va zakhire an be shamsi
    /// </summary>
    /// <param name="datetime">tarikh miladi</param>
    public PersianDateTime(DateTime datetime)
    {
        Set(datetime);
    }
    /// <summary>
    /// meghdar object ra ba tarikhe miladie dade shode tanzim mikonad
    /// </summary>
    /// <param name="datetime"></param>
    public PersianDateTime Set(DateTime datetime)
    {
        this.Persiancalender = new PersianCalendar();
        this.Year = Persiancalender.GetYear(datetime);
        this.Month = Persiancalender.GetMonth(datetime);
        this.Day = Persiancalender.GetDayOfMonth(datetime);
        this.Hour = datetime.Hour;
        this.Minute = datetime.Minute;
        this.Secend = datetime.Second;
        return this;
    }

    /// <summary>
    /// </summary>
    /// <param name="datetime">tarikh shamsi be format:YYYY/MM/DD HH:mm:ss</param>
    public PersianDateTime(string datetime)
    {
        FillAtribute(datetime, PersianDateType.YYYYMMDDHHMMSS, '/', ' ', ':');

    }
    public PersianDateTime(int year, int month, int day)
    {

        FillAtribute(year.ToString() + '/' + SetStandard(month) + '/' + SetStandard(day), PersianDateType.YYYYMMDD, '/', '/', ' ');
    }
    private string SetStandard(int value)
    {
        string result = "";
        if (value % 10 == value)
        {
            result = "0";
        }
        return result + value.ToString();
    }
    /// <summary>
    /// zakhire kardan tarikh shamsi
    /// </summary>
    /// <param name="datetime">tarikh shamsi</param>
    /// <param name="format">noe format tarikhi mojod dar datetime</param>
    /// <param name="dateseparater">characteri ke beye tarikh vojod darad dar datetime</param>
    /// <param name="dateandtimeseparater">characteri ke beyne tarikh va zaman vojod darad dar datetime</param>
    /// <param name="timesparater">characteri ke beyne zaman vojod darad dar datetime</param>
    public PersianDateTime(string datetime, PersianDateType format, char dateseparater, char dateandtimeseparater, char timesparater)
    {
        Persiancalender = new PersianCalendar();
        FillAtribute(datetime, format, dateseparater, dateandtimeseparater, timesparater);
    }

    /// <summary>
    /// hamin tarikhi ke dar in object zakhire shod estefade mikonad
    /// </summary>
    /// <returns></returns>
    public DateTime ConvertToMiladi()
    {
        return Datetime;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="datetime"></param>
    private void FillAtribute(string datetime, PersianDateType format, char dateseparater, char dateandtimeseparater, char timesparater)
    {
        Persiancalender = new PersianCalendar();
        string[] part = datetime.Split(dateseparater, dateandtimeseparater, timesparater);

        if (format == PersianDateType.YYMMDD)
        {
            Year = 1300 + Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = 0;
            Minute = 0;
            Secend = 0;
        }
        else if (format == PersianDateType.YYMMDDHHMM)
        {
            Year = 1300 + Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = Convert.ToInt16(part[3]);
            Minute = Convert.ToInt16(part[4]);
            Secend = 0;
        }
        else if (format == PersianDateType.YYMMDDHHMMSS)
        {
            Year = 1300 + Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = Convert.ToInt16(part[3]);
            Minute = Convert.ToInt16(part[4]);
            Secend = Convert.ToInt16(part[5]);
        }
        else if (format == PersianDateType.YYYYMMDD)
        {
            Year = Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = 0;
            Minute = 0;
            Secend = 0;
        }
        else if (format == PersianDateType.YYYYMMDDHHMM)
        {
            Year = Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = Convert.ToInt16(part[3]);
            Minute = Convert.ToInt16(part[4]);
            Secend = 0;
        }
        else if (format == PersianDateType.YYYYMMDDHHMMSS)
        {
            Year = Convert.ToInt16(part[0]);
            Month = Convert.ToInt16(part[1]);
            Day = Convert.ToInt16(part[2]);
            Hour = Convert.ToInt16(part[3]);
            Minute = Convert.ToInt16(part[4]);
            Secend = Convert.ToInt16(part[5]);
        }
        else
        {
            MyException ex = new MyException("invalid string format", 204, "PersianDateTime");
            throw ex;
        }
    }
    /// <summary>
    /// YYYY/MM/DD HH:mm:ss
    /// </summary>
    /// <returns></returns>
    public string ToString()
    {
        return ToString(PersianDateType.YYMMDDHHMMSS, '/', ' ', ':');
    }
    ///// <summary>
    ///// Y=year
    ///// M=minutes
    ///// D=day of month
    ///// DW=day of week
    ///// DY=day of yeare
    ///// H=hour
    ///// m=minutes
    ///// s=second
    ///// </summary>
    ///// <param name="format">ex:YY/MM or DW or HH:mm</param>
    ///// <returns></returns>
    //public string ToString(string format)
    //{
    //    char[] part = format.ToCharArray();

    //}
    public string ToString(PersianDateType format, char dateseperator, char dateandtimeseperaitor, char timeseperator)
    {

        if (format == PersianDateType.YYMMDD)
        {

            return Convert.ToString(Year % 10 + ((Year / 10) % 10) * 10) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day);
        }
        else if (format == PersianDateType.YYMMDDHHMM)
        {
            return Convert.ToString(Year % 10 + ((Year / 10) % 10) * 10) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day) + dateandtimeseperaitor + SetStandard(Hour) + timeseperator + SetStandard(Minute);
        }
        else if (format == PersianDateType.YYMMDDHHMMSS)
        {
            return Convert.ToString(Year % 10 + ((Year / 10) % 10) * 10) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day) + dateandtimeseperaitor + SetStandard(Hour) + timeseperator + SetStandard(Minute) + timeseperator + SetStandard(Secend);
        }
        else if (format == PersianDateType.YYYYMMDD)
        {
            return Convert.ToString(Year) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day);
        }
        else if (format == PersianDateType.YYYYMMDDHHMM)
        {
            return Convert.ToString(Year) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day) + dateandtimeseperaitor + SetStandard(Hour) + timeseperator + SetStandard(Minute);
        }
        else if (format == PersianDateType.HHMM)
        {
            return SetStandard(Hour) + timeseperator + SetStandard(Minute);

        }
        else
            return Convert.ToString(Year) + dateseperator + SetStandard(Month) + dateseperator + SetStandard(Day) + dateandtimeseperaitor + SetStandard(Hour) + timeseperator + SetStandard(Minute) + timeseperator + SetStandard(Secend);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    public string ToString(PersianDateType format)
    {
        return ToString(format, '/', ' ', ':');
    }
    /// <summary>
    /// ezafe kardane yek roz be tarikhe in object
    /// </summary>
    public void AddDays(double value)
    {
        Set(this.Datetime.AddDays(value));
    }
    public static PersianDateTime ConvertToPersianDateTime(DateTime datetime)
    {
        return new PersianDateTime(datetime);
    }
    /// <summary>
    /// mohasebe tedad roz haye beyne 2 roz, if date1>date2 then retunr negetiv number else posetive number
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns></returns>
    public static int DayIff(PersianDateTime date1, PersianDateTime date2)
    {
        PersianDateTime temp;
        int zarib = 1;
        int miladicompaire = DateTime.Compare(date1.Datetime, date2.Datetime);
        if (miladicompaire == 0)
            return 0;
        if (miladicompaire > 0)
        {
            temp = date1;
            date1 = date2;
            date2 = temp;
            zarib = -1;
        }


        int deffday = 0;
        int deffyear;


        if (date2.Year == date1.Year)// dar yek sal hastand
        {
            return date2.Dayofyear - date1.Dayofyear;
        }

        else // dar yek sal nistand
        {
            deffyear = date1.Year;
            if (IsLeap(date1.Year))
                deffday = 366 - date1.Dayofyear;
            else
                deffday = 365 - date1.Dayofyear;
            deffyear++;
            while (deffyear < date2.Year)
            {
                if (IsLeap(deffyear))
                {
                    deffday = deffday + 366;
                }
                else
                    deffday = deffday + 365;
                deffyear++;
            }
            return (deffday + date2.Dayofyear)* zarib;


        }
    }
    /// <summary>
    /// aya sale kabise ast ya kheyr
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    public static bool IsLeap(int year)
    {
        PersianDateTime x = new PersianDateTime(year, 12, 27);
        int lastdaye = 27;
        while (true)
        {
            x.AddDays(1);
            lastdaye++;
            if (x.Month != 12)
                break;
        }
        if (lastdaye - 1 == 30)
            return true;
        return false;
    }
    public static int MinutesIff(PersianDateTime date1,PersianDateTime date2)
    {

        int defday = DayIff(date1, date2);
        if (defday == 0)// hatman dar yek roz hastand
        {
            TimeSpan start = new TimeSpan(date1.Hour, date1.Minute, date1.Secend);
            TimeSpan end = new TimeSpan(date2.Hour, date2.Minute, date2.Secend);
            return defday * 1440 + Convert.ToInt32((end.TotalMinutes - start.TotalMinutes));
        }
        else if(defday>0)//roze dovom bozorgtar az roze aval ast
        {
            TimeSpan start = new TimeSpan(date1.Hour, date1.Minute, date1.Secend);
            TimeSpan end = new TimeSpan(date2.Hour, date2.Minute, date2.Secend);
            return defday*1440+Convert.ToInt32((end.TotalMinutes-start.TotalMinutes));
        }
        else if(defday<0)// roze aval bozorgtar az roze dovom ast
        {
            TimeSpan end = new TimeSpan(date1.Hour, date1.Minute, date1.Secend);
            TimeSpan start = new TimeSpan(date2.Hour, date2.Minute, date2.Secend);
            return defday * 1440 + Convert.ToInt32((end.TotalMinutes - start.TotalMinutes));
        }
        //defminutes=((date2.Hour-date2.Hour))*60+(date2.Minute)
        return 0;
    }
    /// <summary>
    /// gereftane tarikh akharin roze mah
    /// </summary>
    /// <param name="currentmonthdate">yek roz az un mahi ke akharin rozash ra mikhaheed</param>
    /// <returns>tarikh akharin roz un mah</returns>
    public static  PersianDateTime GetLastDayOfMonth(PersianDateTime currentmonthdate)
    {
        PersianDateTime result = new PersianDateTime(currentmonthdate.Year, currentmonthdate.Month, currentmonthdate.Day);
        int lastday = currentmonthdate.Day;
        int year=currentmonthdate.Year;
        while (true)
        {
            result.AddDays(1);
            if (result.Month != currentmonthdate.Month)
            {
                break;
            }
            lastday++;
        }
        result.AddDays(-1);
        return result;
    }
    /// <summary>
    /// ezafe kardan ye TimeSpanBatis be in PersianDateTime
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PersianDateTime Add(TimeSpanBatis value)
    {
        this.Set(this.Datetime.Add(value.TimeSpan));
        return this;
    }
    /// <summary>
    /// kam kardan ye TimeSpanBatis be in PersianDateTime
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PersianDateTime Subtract(TimeSpanBatis value)
    {
        this.Set(this.Datetime.Subtract(value.TimeSpan));
        return this;
    }
    /// <summary>
    /// ezafe kardan ye TimeSpanBatis be in date
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static PersianDateTime Add(PersianDateTime date,TimeSpanBatis value)
    {
        return new PersianDateTime(date.Datetime.Add(value.TimeSpan));
    }
    /// <summary>
    /// kam kardan ye TimeSpanBatis be in date
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public PersianDateTime Subtract(PersianDateTime date, TimeSpanBatis value)
    {
        return new PersianDateTime(date.Datetime.Subtract(value.TimeSpan));
        
    }
}
public enum PersianDateType
{
    YYYYMMDDHHMMSS,
    YYMMDDHHMMSS,
    YYYYMMDDHHMM,
    YYMMDDHHMM,
    YYYYMMDD,
    YYMMDD,
    HHMM
}