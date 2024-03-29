﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_PaperListSyntaxEditor : FormBase
{

    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/PaperListSyntaxEditor.aspx"; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SyntaxEditorVerification();
        FillGridView();
    }

    public void FillGridView()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperReport paperReport = paperInfoMan.GetPaperListForSyntaxEditor(txtbTitle.Text);
        gvPapers.DataSource = paperReport.Papers;
        gvPapers.DataBind();
    }

    protected void lnkbShow_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandArgument);
        Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + id);
    }

    public string PaperStatusInString(int statusID)
    {
        return PaperStatus.Convert(statusID);
    }
    public string DateTimeInString(DateTime dt)
    {
        return dt.ToString("yyyy.MM.dd");
    }
}