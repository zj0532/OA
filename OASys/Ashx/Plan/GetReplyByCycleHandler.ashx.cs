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
    /// GetReplyByCycleHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    public class GetReplyByCycleHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string wpid = context.Request["Wid"];
            string cycle = context.Request["ReplyCycle"];

            DataTable dt = new BLL.WorkPlanInfoBLL().GetList("wpid='" + wpid + "' and times='" + cycle + "'").Tables[0];
            StringBuilder sb = new StringBuilder();
            sb.Append("[{\"Date\":\"" +Convert .ToDateTime( dt.Rows[0]["date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\"");
            string content = dt.Rows[0]["WPIContent"].ToString();

            sb.Append(",\"content\":\"" + content + "\"  ");
            sb.Append(" }] ");

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