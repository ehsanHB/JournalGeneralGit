using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_PaperList : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/PaperListChefEditor.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        ChefEditorVerification();
        FillInfo();
        FillGridView();
    }

    public void FillGridView()
    {
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        PaperReport paperReport = paperInfoMan.GetPaperListForChefEditor(int.Parse(ddlChefEditor.SelectedValue), txtbTitle.Text, txtbKeyWord.Text);
        gvPapers.DataSource = paperReport.Papers;
        gvPapers.DataBind();
    }

    public void FillInfo()
    {
        UserInfoMan_Business userInfoMan = new UserInfoMan_Business();
        List<User_cls> users = userInfoMan.GetUsersFullInfo(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0);
        ddlChefEditor.Items.Add(new ListItem("FullName...", "0"));
        for (int i = 0; i < users.Count; i++)
        {
            ddlChefEditor.Items.Add(new ListItem(users[i].FullName, users[i].UserID.ToString()));
        }
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

    public string DateTimeInString(DateTime dt)
    {
        return dt.ToString("yyyy.MM.dd");
    }
}