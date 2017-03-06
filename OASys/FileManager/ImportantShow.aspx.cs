using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OASys.FileManager
{
    public partial class ImportantShow : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }


            if (!IsPostBack)
            {
                this.GetDateBind();
            }
        }

        private void GetDateBind()
        {
            int FileID = int.Parse(Request.QueryString["Fid"].ToString());
            MDL.FileManagerMOD FmMod = new BLL.FileManagerBLL().GetModel(FileID);
            spTitle.InnerText = FmMod.FileName;
            labUsName.Text = new BLL.UserInfoBLL().GetModel(FmMod.UsID).UsName;
            labDate.Text = FmMod.FileDate.ToString("yyyy-MM-dd HH:mm:ss");
            labContent.Text = FmMod.FileContent;

        }

    }
}