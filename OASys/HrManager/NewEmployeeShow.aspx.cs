using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.HrManager
{
    public partial class NewEmplyeeShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            string NTID = Request.QueryString["NeID"].ToString();
            MDL.NewEmplyeeKnowMOD NEMod = new BLL.NewEmplyeeKnowBLL().GetModel(int.Parse(NTID));
            labTitle.Text = NEMod.Title;
            labAuthor.Text = new BLL.UserInfoBLL().GetModel(NEMod.UsID).UsName;
            labDate.Text = NEMod.Date.ToString("yyyy-MM-dd HH:mm:ss");
            labContent.Text = NEMod.NeContent;
            labRemark.Text = NEMod.Remark;
        }
    }
}