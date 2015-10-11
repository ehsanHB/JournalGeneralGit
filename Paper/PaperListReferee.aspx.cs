using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_PaperListReferee : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        RefereeVerification();
        FillGridView();

    }


    public void FillGridView()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperReport paperReport = paperInfoMan.GetPaperListForReferee();
        gvPapers.DataSource = paperReport.Papers;
        gvPapers.DataBind();
    }

    public string DateTimeInString(DateTime dt)
    {
        return dt.ToString("yyyy.MM.dd");
    }

    public string PaperStatusInString(int statusID)
    {
        return PaperStatus.Convert(statusID);
    }

    protected void lnkbShow_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandArgument);
        Response.Redirect(ServerDirectory.Paper + "/PaperInformation.aspx?" + RequestMSG.ID + "=" + id);
    }
}