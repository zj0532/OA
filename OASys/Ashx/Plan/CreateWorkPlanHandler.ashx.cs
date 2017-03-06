using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;
using System.Data.Sql;

namespace OASys.Ashx.Plan
{
    /// <summary>
    /// CreateWorkPlanHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CreateWorkPlanHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int UserID = Convert.ToInt32(context.Session["UsID"]);
            string Title = context.Request["Title"];
            string Cycle = context.Request["Cycle"];
            string BeginDate = context.Request["BDate"];
            string EndDate = context.Request["EDate"];
            StringBuilder sb = new StringBuilder();
            string ErrorMessage = "";
            MDL.WorkPlanMOD WPMod = new MDL.WorkPlanMOD();
            WPMod.WPTitle = Title;
            WPMod.Cycle = Cycle;
            try
            {
                WPMod.BeginDate = Convert.ToDateTime(BeginDate);
                WPMod.EndDate = Convert.ToDateTime(EndDate);
            }
            catch
            {
                ErrorMessage = "日期格式错误";
            }
            WPMod.UsID = UserID;
            WPMod.CreateDate = DateTime.Now;
            WPMod.IsDel = 0;

            DataTable dt = new BLL.WorkPlanBLL().GetList("WPTitle='" + Title + "' and usid='"+UserID+"' ").Tables[0];
            if (dt.Rows.Count > 0)
            {
                ErrorMessage = "历史记录中已有相同标题的作业计划，如果用户确认需要继续创建请修改标题以区分！";
            }

            int result = 0;
            if (ErrorMessage == "")
            {
                result = new BLL.WorkPlanBLL().Add(WPMod);
            }
            sb.Append("[{ \"Message\":\""+ErrorMessage+"\",\"Result\":\""+result+"\"}]");
            context.Response.Write(sb.ToString());
            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}