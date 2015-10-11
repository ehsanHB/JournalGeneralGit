using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeSpanBatis
/// </summary>
public class TimeSpanBatis
{
    private TimeSpan timeSpan;
    private int _seconds;
    private int _minutes;
    private int _hours;
    private int _days;

    public int Seconds
    {
        get { return timeSpan.Seconds; }

    }
    public int Minutes
    {
        get { return timeSpan.Minutes; }

    }
    public int Hours
    {
        get { return timeSpan.Hours; }

    }
    public int Days
    {
        get { return timeSpan.Days; }

    }

    public double TotalDays
    {
        get { return Math.Truncate(timeSpan.TotalDays); }
    }
    public double TotalHours
    {
        get
        {
            return Math.Truncate(timeSpan.TotalHours);
        }
    }
    public double TotalMinutes
    {
        get
        {
            return Math.Truncate(timeSpan.TotalMinutes);
        }
    }
    public double TotalSeconds
    {
        get
        {
            return Math.Truncate(timeSpan.TotalSeconds);
        }
    }

    public TimeSpan TimeSpan
    {
        get { return this.timeSpan; }
    }
    public TimeSpanBatis(TimeSpan timeSpan)
    {
        this.timeSpan = timeSpan;
    }
    public TimeSpanBatis(int hours, int minutes, int seconds)
    {
        this.timeSpan = new TimeSpan(hours, minutes, seconds);
    }
    public TimeSpanBatis(int days, int hours, int minutes, int seconds)
    {
        this.timeSpan = new TimeSpan(days, hours, minutes, seconds);
    }
    public string ToString(TimeSpanBatisType type, string sepratorHour)
    {
        return this.ToString(type, "", sepratorHour, "", "");
    }
    public string ToString(TimeSpanBatisType type,string sepratorHour, string sepratorMinutes)
    {
        return this.ToString(type, "", sepratorHour, sepratorMinutes, "");
    }
    public string ToString(TimeSpanBatisType type, string sepratorDay, string sepratorHour, string sepratorMinutes, string sepratorSecond)
    {
        if (type == TimeSpanBatisType.THMM)
        {
            return this.TotalHours + sepratorHour + this.Minutes;
        }
        else if (type == TimeSpanBatisType.DDHHMMSS)
        {
            return this.Days + sepratorDay + this.Hours + sepratorHour + this.Minutes + sepratorMinutes + this.Seconds + sepratorSecond;
        }
        else if(type == TimeSpanBatisType.HHMMSS)
        {
            return this.Hours + sepratorHour + this.Minutes + sepratorMinutes + this.Seconds + sepratorSecond;
        }
        return "";
    }
    public string ToString()
    {
        return this.ToString(TimeSpanBatisType.DDHHMMSS, ".", ":", ":", "");
    }

}
public enum TimeSpanBatisType
{
    THMM,
    DDHHMMSS,
    HHMMSS
}