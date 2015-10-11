using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_DDL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<person> persons = new List<person>();
        persons.Add(new person() { name = "ali1", family = "amiry1" });
        persons.Add(new person() { name = "ali2", family = "amiry2" });
        persons.Add(new person() { name = "ali3", family = "amiry3" });
        persons.Add(new person() { name = "ali4", family = "amiry4" });
        persons.Add(new person() { name = "ali5", family = "amiry5" });
        persons.Add(new person() { name = "ali6", family = "amiry6" });

        List<person> persons2 = new List<person>();
        persons2.Add(new person() { name = "yashar1", family = "erfani1" });
        persons2.Add(new person() { name = "yashar2", family = "erfani2" });
        persons2.Add(new person() { name = "yashar3", family = "erfani3" });
        persons2.Add(new person() { name = "yashar4", family = "erfani4" });
        persons2.Add(new person() { name = "yashar5", family = "erfani5" });
        persons2.Add(new person() { name = "yashar6", family = "erfani6" });
        persons2.Add(new person() { name = "yashar7", family = "erfani7" });
        persons2.Add(new person() { name = "yashar8", family = "erfani8" });

        if (!IsPostBack)
        {
            //ddltest.DataSource = persons;
            //ddltest.DataTextField = "Name";
            //ddltest.DataValueField = "Last";
            //ddltest.DataBind();

            //ddltest2.DataSource = persons2;
            //ddltest2.DataTextField = "Name";
            //ddltest2.DataValueField = "Last";
            //ddltest2.DataBind();

        }
    }
}



public class person
{
    public string name;
    public string family;
    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Last
    {
        get
        {
            return family;
        }
    }
    public override string ToString()
    {
        return name + " " + family;
    }
}