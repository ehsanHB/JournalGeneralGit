using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataContainer
/// </summary>
public class DataContainer
{
    private Dictionary<string, object> continer;
    private Dictionary<int, string> keyMapping;

    public DataContainer()
    {
        continer = new Dictionary<string, object>();
        keyMapping = new Dictionary<int, string>();
    }
    public object this[string key]
    {
        set { this.Add(key, value); }
        get
        {
            if (this.continer.ContainsKey(key))
                return this.continer[key];
            return null;
        }
    }
    public object this[int index]
    {
        set { this.Add(index, value); }
        get
        {
            if (!this.keyMapping.ContainsKey(index))
                throw new Exception("index is not contain in this collection");
            return this[this.keyMapping[index]];
        }
    }
    private void Add(string key, object value)
    {
        if (this.continer.ContainsKey(key))
        {
            this.continer[key] = value;
        }
        else
        {
            this.continer.Add(key, value);
            this.keyMapping.Add(this.continer.Count - 1, key);
        }
    }
    private void Add(int index, object value)
    {
        if (!this.keyMapping.ContainsKey(index))
            throw new Exception("index is not contain in this collection");
        this.Add(this.keyMapping[index], value);
    }
    public bool Remove(string key)
    {
        bool result = this.continer.Remove(key);
        if(result)
        {
            bool flag=false;
            for (int i = 0; i < this.keyMapping.Count-1; i++)
            {
                if (this.keyMapping[i] == key )
                {
                    this.keyMapping.Remove(i);
                   flag=true;

                }
                if (flag)
                    this.keyMapping[i] = this.keyMapping[i + 1];
            }
            this.keyMapping.Remove(this.keyMapping.Count-1);

        }
        return result;
    }
    public bool Remove(int index)
    {
        if (!this.keyMapping.ContainsKey(index))
            return false;
        return this.Remove(this.keyMapping[index]);

    }

}