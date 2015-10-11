using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_RefereesOpinion : FormBase
{
    public List<EvaluationForm> evaluations;

    protected void Page_Load(object sender, EventArgs e)
    {
        ChefEditorVerification();
        if (!IsPostBack)
        {
            FillInfo();
        }
    }
    private void FillInfo()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        if (Request[RequestMSG.PaperID] != null)
        {
            int paperID = Convert.ToInt32(Request[RequestMSG.PaperID]);
            evaluations = paperInfoMan.GetEvaluate(paperID);
        }
        else
            Response.Redirect(ServerDirectory.Host + "Dashboard.aspx");
    }
}