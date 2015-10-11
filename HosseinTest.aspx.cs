using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HosseinTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SysProperty.Client.UserID ==0)
        {
            UserAuthorizeMan_Business u = new UserAuthorizeMan_Business();
            u.Login("yapmayashar@gmail.com", "123456", ServerDirectory.Host + "/HosseinTest.aspx");
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PaperInfoMan_Business bus = new PaperInfoMan_Business();
        List<User_cls> refereee = new List<User_cls>();
        refereee.Add(new User_cls() { Fname = "hossein", Lname = "eshaghi", Email = "hossein_eshaghi@live.com" });
        refereee.Add(new User_cls() { Fname = "hossein2", Lname = "eshaghi2", Email = "hossein_eshaghi@live.com" });
        refereee.Add(new User_cls() { Fname = "ehsan", Lname = "haghani", Email = "e.haghani@outlook.com" });

        bus.RegisterPaper_Step4(refereee, 1010);
    }
}