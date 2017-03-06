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
    /// CreateWorkPlanInfoHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CreateWorkPlanInfoHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int UserID = Convert.ToInt32(context.Session["UsID"]);
            string Times = context.Request["Times"];
            string ShouldTime = context.Request["ShouldTime"];
            string Content = context.Request["Content"];
            string WPID=context.Request["Wpid"];

            StringBuilder sb = new StringBuilder();
            string ErrorMessage = "";
            MDL.WorkPlanInfoMOD WPIMod = new MDL.WorkPlanInfoMOD();
            WPIMod.WPID =int.Parse(WPID);
            try
            {
                WPIMod.ShouldDate = Convert.ToDateTime(ShouldTime);
                
            }
            catch
            {
                ErrorMessage = "本期回复时间日期格式错误";
            }
            WPIMod.WPIPlanInfo = Content.Replace("\n","<br/>");
            WPIMod.Times =int.Parse(Times);
            WPIMod.TruthDate = Convert.ToDateTime("2001-01-01");
            DataTable dt = new BLL.WorkPlanInfoBLL().GetList("WPID='" + WPID + "' and Times='" + int.Parse(Times) + "' ").Tables[0];
            if (dt.Rows.Count > 0)
            {
                ErrorMessage = "作业计划中第"+Times+"期任务已添加完成，如需添加请先删除！";
            }

            int result = 0;
            if (ErrorMessage == "")
            {
                result = new BLL.WorkPlanInfoBLL().Add(WPIMod);
            }
            sb.Append("[{ \"Message\":\"" + ErrorMessage + "\",\"Result\":\"" + result + "\"}]");
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