using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitOnline_Step2 : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/SubmitOnline_Step2.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        if (Request[RequestMSG.SubmitOnline] == null || Request[RequestMSG.SubmitOnline] == string.Empty)
            Response.Redirect(ServerDirectory.Paper + "/SubmitOnline.aspx");

    }
    protected void btnStep3_Click(object sender, EventArgs e)
    {
        try
        {
            DBmessage dbm = new DBmessage(DBMessageType.Error, SystemMessage_DBMessage.NotRegisterOnePersonFullInfo);
            PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
            List<PaperWriter> paperWriters = new List<PaperWriter>();
            string[] names = hfFirstName.Value.Split(',');
            string[] lastnames = hflastName.Value.Split(',');
            string[] incharge = hfIncharge.Value.Split(',');
            for (int i = 0; i < names.Length - 1; i++)
            {
                if (names[i] != string.Empty && lastnames[i] != string.Empty)
                    paperWriters.Add(new PaperWriter()
                    {
                        Fname = names[i],
                        Lname = lastnames[i],
                        Responsibility = new PaperWriterResponsibility(Resposibility(incharge[i]))
                    });
            }
            int paperID = System.Convert.ToInt32(FormBase.UrlDecode(Request[RequestMSG.SubmitOnline]));
            if (paperWriters.Count > 0)
                dbm = paperInfoMan.RegisterPaper_Step2(paperWriters, paperID);
            if (dbm.Type == DBMessageType.Sucsess)
            {
                FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step3.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paperID.ToString() });
            }
            else
                ShowNotify(dbm);
        }
        catch (MyException myEx)
        {
            ShowNotify(myEx);
        }
        catch (Exception ex)
        {
            ShowNotify(ex);
        }
    }
    public int Resposibility(string status)
    {
        if (status == "true")
        {
            return PaperWriterResponsibility.Encharge;
        }
        else
        {
            return PaperWriterResponsibility.Normal;
        }
    }
}