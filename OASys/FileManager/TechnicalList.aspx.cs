using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.FileManager
{
    public partial class TechnicalList : System.Web.UI.Page
    {
        public string TechnicalName;
        public string TechnicalID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
            TechnicalID = Request.QueryString["fceid"].ToString();
            TechnicalName = new BLL.FileClassExplicitBLL().GetModel(int.Parse(Request.QueryString["fceid"].ToString())).FCEName;

        }
    }
}