using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_ReviseByAuthor_Step3 : FormBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        if (Request[RequestMSG.PaperID] == null || Request[RequestMSG.PaperID] == string.Empty)
            Response.Redirect(ServerDirectory.Paper + "/ReviseByAuthor.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        HttpPostedFile pofPDF = fuPDF.PostedFile;
        HttpPostedFile pofDOC = fuDOC.PostedFile;
        HttpPostedFile pofFigure = fuFigures.PostedFile;
        HttpPostedFile TableOfContent = fuTable.PostedFile;
        string Comment = txtbComment.Text;
        //
        PaperInfoMan_Business paperInfoMan = new PaperInfoMan_Business();
        int paperID = System.Convert.ToInt32(FormBase.UrlDecode(Request[RequestMSG.PaperID]));
        DBmessage dbm = paperInfoMan.ReviseByAuthor_Step3(paperID,pofPDF, pofDOC, pofFigure, TableOfContent);
        if (dbm.Type == DBMessageType.Sucsess)
            FormBase.SendRequest(ServerDirectory.Paper + "/PaperListAuthor.aspx", new string[] { RequestMSG.Msg, RequestMSG.Type }, new string[] { dbm.Message, dbm.Type.ToString() });
        else
            ShowNotify(dbm);
    }
}