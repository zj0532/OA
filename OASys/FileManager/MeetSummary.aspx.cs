using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.FileManager
{
    public partial class MeetSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            if (!new BLL.PageSettingBLL().ExistsAuthority(Convert.ToInt32(Session["UsID"]), "会议纪要"))
            {
                Page.RegisterStartupScript("Message", "<script> document.getElementById('DivButton').style.display='none'</script>");
            }
        }
    }
}