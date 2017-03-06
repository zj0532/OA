using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx.Plan
{
    /// <summary>
    /// ReplyPlanInfoHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class ReplyPlanInfoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string wpid = context.Request["Wid"];
            string times = context.Request["ReplyCycle"];
            string Content = context.Request["Content"].Replace("\r\n","<br/>");

            MDL.WorkPlanInfoMOD WpiMod = new MDL.WorkPlanInfoMOD();
            WpiMod.WPID = Convert.ToInt32(wpid);
            WpiMod.Date = DateTime.Now;
            WpiMod.WPIContent = Content;
            WpiMod.Times = times;

            int result = new BLL.WorkPlanInfoBLL().Add(WpiMod);
            StringBuilder sb = new StringBuilder();

            if (result > 0)
            {
                sb.Append("[{\"result\":\"1\"}]");
            }
            else
            {
                sb.Append("[{\"result\":\"0\"}]");
            }

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