using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GrammerEditors
/// </summary>
public class LanguageEditors
{
    private List<LanguageEditor> _languageEditor;
    public LanguageEditors()
    {
        _languageEditor = new List<LanguageEditor>();
    }
    public LanguageEditor this[int index]
    {
        get
        {
            return _languageEditor[index];
        }
        set
        {
            _languageEditor[index] = value;
        }
    }
    public int Count
    {
        get
        {
            return _languageEditor.Count;
        }
    }
    public LanguageEditor SelectedLanguageEditors
    {
        get
        {
            if (_languageEditor != null)
                return this._languageEditor.Find(delegate (LanguageEditor l)
                {
                    if (l.Status.ID == PaperStatus.SelectLanguegEditor || l.Status.ID == PaperStatus.VerifyLanguageEditor ||
                      l.Status.ID == PaperStatus.ConfrimationLanguageEditting || l.Status.ID == PaperStatus.DeliveryOfTheEditedFile)
                        return true; return false;
                });
            return null;
        }
    }
    public void Add(LanguageEditor languageEditor)
    {
        _languageEditor.Add(languageEditor);
    }
    public LanguageEditor Find(Predicate<LanguageEditor> match)
    {
        return this._languageEditor.Find(match);
    }
}