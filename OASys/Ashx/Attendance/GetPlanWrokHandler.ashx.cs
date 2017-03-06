using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// GetPlanWrokHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanWrokHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string PWID = context.Request["PWID"];
            MDL.PlanWrokMOD pwMod= new BLL.PlanWrokBLL().GetModel(Convert .ToInt32( PWID));
            sb.Append("[{\"Title\":\"" + pwMod.PWTitle + "\"}]");
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