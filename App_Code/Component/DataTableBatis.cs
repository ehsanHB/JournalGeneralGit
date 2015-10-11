using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataTableBatis
/// </summary>
public class IntTable : DataTable
{
    public IntTable()
    {
        this.Columns.Add("ID");
    }
    public void Add(int id)
    {
        this.Rows.Add(id);
    }
    #region static methods
    /// <summary>
    /// userid source darune IntTable rikhte mishavad
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IntTable Convert(List<PaperWriter> source)
    {
        IntTable intTable = new IntTable();
        for (int i = 0; i < source.Count; i++)
        {
            intTable.Add(source[i].UserID);
        }
        return intTable;
    }
    #endregion
}
public class DoubleIntTable : DataTable
{
    public DoubleIntTable()
    {
        this.Columns.Add("ID1");
        this.Columns.Add("ID2");
    }
    public void Add(int id_1 , int id_2)
    {
        this.Rows.Add(id_1, id_2);
    }
    public static DoubleIntTable Convert(List<PaperWriter> source)
    {
        DoubleIntTable doubleIntTable = new DoubleIntTable();
        for (int i = 0; i < source.Count; i++)
        {
            doubleIntTable.Add(source[i].UserID,source[i].Responsibility.ID); // momkene responsibility null bashe ; badan check beshe
        }
        return doubleIntTable;
    }
}