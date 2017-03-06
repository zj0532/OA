using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;
using System.Net;
using System.Net.Sockets;


namespace OASys.Ashx.Plan
{
    /// <summary>
    /// GetPlanListByUserIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanListByUserIDHandler : IHttpHandler
    {
      
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string WPID = context.Request["WPID"];
            DataTable dt = new BLL.WorkPlanBLL().GetList("WPID='"+WPID+"'").Tables[0];
            sb.Append("[{ ");
            sb.Append("\"Title\":\""+dt.Rows[0]["wptitle"]+"\",");
            sb.Append("\"Cycle\":\"" + dt.Rows[0]["Cycle"] + "\",");
            sb.Append("\"BeginDate\":\"" +Convert .ToDateTime(dt.Rows[0]["BeginDate"]).ToString("yyyy-MM-dd") + "\",");
            sb.Append("\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[0]["EndDate"]).ToString("yyyy-MM-dd") + "\"");
            sb.Append("}]");
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