using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.FileManager
{
    public partial class StandardList : System.Web.UI.Page
    {
        public string FceID;
        public string PageStaute;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
            FceID = Request.QueryString["BusID"];
            PageStaute =new BLL.FileClassExplicitBLL().GetModel(int.Parse(Request.QueryString["BusID"].ToString())).FCEName;
            if (!new BLL.PageSettingBLL().ExistsAuthority(Convert.ToInt32(Session["UsID"]), "制度规范"))
            {
                Page.RegisterStartupScript("Message", "<script> document.getElementById('DivButton').style.display='none'</script>");
            }         
        }
    }
}