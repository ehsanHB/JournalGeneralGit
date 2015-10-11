using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitOnline_Step4 : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/SubmitOnline_Step4.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        if (Request[RequestMSG.SubmitOnline] == null || Request[RequestMSG.SubmitOnline] == string.Empty)
            Response.Redirect(ServerDirectory.Paper + "/SubmitOnline.aspx");

    }

    protected void btnFinish_Click(object sender, EventArgs e)
    {
        string[] names = hfFirstName.Value.Split(',');
        string[] lastnames = hflastName.Value.Split(',');
        string[] mails = hfEmail.Value.Split(',');
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        List<User_cls> referees = new List<User_cls>();
        for (int i = 0; i < names.Length - 1; i++)
        {
            if (names[i] != string.Empty && lastnames[i] != string.Empty && mails[i] != string.Empty)
                referees.Add(new User_cls() { Fname = names[i], Lname = lastnames[i], Email = mails[i] });
        }
        int paperID = System.Convert.ToInt32(FormBase.UrlDecode(Request[RequestMSG.SubmitOnline]));
        DBmessage dbm = paperInfoMan.RegisterPaper_Step4(referees, paperID);
        if (dbm.Type == DBMessageType.Sucsess)
            FormBase.SendRequest(ServerDirectory.Paper + "/PaperListAuthor.aspx", new string[] { RequestMSG.Msg, RequestMSG.Type }, new string[] { dbm.Message, dbm.Type.ToString() });
        else
            ShowNotify(dbm);
    }
}