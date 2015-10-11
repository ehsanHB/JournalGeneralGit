using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SubmitOnline_Step3 : FormBase
{
    public static string PageAddress
    {
        get { return ServerDirectory.Paper + "/SubmitOnline_Step3.aspx"; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorVerification();
        if (Request[RequestMSG.SubmitOnline] == null || Request[RequestMSG.SubmitOnline] == string.Empty)
            Response.Redirect(ServerDirectory.Paper + "/SubmitOnline.aspx");
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
        int paperID = System.Convert.ToInt32(FormBase.UrlDecode(Request[RequestMSG.SubmitOnline]));
        DBmessage dbm = paperInfoMan.RegisterPaper_Step3(pofPDF, pofDOC, pofFigure, TableOfContent, Comment, paperID);
        if (dbm.Type == DBMessageType.Sucsess)
        {
            FormBase.SendRequest(ServerDirectory.Paper + "/SubmitOnline_Step4.aspx", new string[] { RequestMSG.SubmitOnline }, new string[] { paperID.ToString() });
        }
        else
            ShowNotify(dbm);
        //string FileName = System.IO.Path.GetFileName(soPostedFile.FileName);
        //if (soPostedFile == null)
        //{
        //    return;
        //}
        //string strFileName = System.IO.Path.GetFileName(soPostedFile.FileName);
        //string strFileExtension = System.IO.Path.GetExtension(strFileName).ToUpper();
        //if ((strFileExtension != ".DOCX") && (strFileExtension != ".DOC"))
        //{
        //    //  DisplayErrorMessage("You Can Upload Just Doc  & Docx");
        //    return;
        //}

        //string strRootRelativePath = "~/Uploaded";
        //string strPath = Server.MapPath(strRootRelativePath);
        //string strPathName = string.Format("{0}\\{1}{2}", strPath, strFileName, strFileExtension);
        //soPostedFile.SaveAs(strPathName);



    }

}