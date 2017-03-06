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
    /// GetPlanOneByWpidHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanOneByWpidHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Wid = context.Request["Wid"];
            MDL.WorkPlanMOD WpMod = new BLL.WorkPlanBLL().GetModel(int.Parse(Wid));    
            StringBuilder sb = new StringBuilder();

            sb.Append("[{\"BeginDate\":\"" + WpMod.BeginDate.ToString("yyyy-MM-dd") +  "\"");
            sb.Append(",\"EndDate\":\"" + WpMod.EndDate.ToString("yyyy-MM-dd") + "\"  ");
            sb.Append(",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(WpMod.UsID).UsName + "\"  ");
            sb.Append(",\"CreateDate\":\"" + WpMod.CreateDate.ToString("yyyy-MM-dd") + "\"  ");
            sb.Append(",\"Cycle\":\"" + WpMod.Cycle + "\"  ");
            sb.Append(",\"WPTitle\":\"" + WpMod.WPTitle + "\"  ");
            
            sb.Append(" }]");

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