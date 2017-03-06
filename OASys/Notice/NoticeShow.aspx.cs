using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.Notice
{
    public partial class NoticeShow : System.Web.UI.Page
    {
        int NoID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                NoID = Convert.ToInt32(Request.QueryString["Ntid"]);
                SetDate();
            }
            
        }

        private void SetDate()
        {
            MDL.NoticeMOD NtMod = new BLL.NoticeBLL().GetModel(NoID);
            spTitle.InnerText = NtMod.Title;
            spUsName.InnerText = new BLL.UserInfoBLL().GetModel(Convert .ToInt32(NtMod.UsID)).UsName;
            spDate.InnerText = NtMod.Date.ToString("yyyy-MM-dd HH:mm:ss");
            spBeginDate.InnerText = NtMod.EffectDateBefore.ToString("yyyy-MM-dd HH:mm:ss");
            spEndDate.InnerText = NtMod.EffectDateEnd.ToString("yyyy-MM-dd HH:mm:ss");
            spContent.InnerHtml = NtMod.NoContent.ToString();
            if (NtMod.FileName.Trim() != "")
            {
                spFile.InnerHtml = "<a href='#' class='a1' title='点击下载' onclick=GetFile('" + NtMod.NoID + "') >附件下载</a>";
            }
            else
            {
            spFile.InnerText="无附件";
            }

        }
    }
}