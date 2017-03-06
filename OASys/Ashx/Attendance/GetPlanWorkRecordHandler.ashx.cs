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
    /// GetPlanWorkRecordHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanWorkRecordHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int Page = Convert.ToInt32(context.Request["page"]);
            DataTable dt = new BLL.PlanWrokBLL().GetListByPage(15, Page, "").Tables[0];
            StringBuilder sb = new StringBuilder();

            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"PwTitle\":\"" + dt.Rows[i]["pwtitle"] + "\",\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["beginDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"Count\":\"" + dt.Rows[i]["Hours"].ToString() + "\",\"UsName\":\"" + dt.Rows[i]["usname"] + "\",\"BusName\":\"" + new BLL.BusinessBLL().GetModel(Convert.ToInt32(dt.Rows[i]["Busid"])).BusinessName + "\"} ");

                    if (i != dt.Rows.Count - 1)
                    {
                        sb.Append(" , ");
                    }

                }

                sb.Append(" ]} ");

            }
            else
            {
                sb.Append(" {\"total\":0,\"rows\":[ ");
                sb.Append(" ]} ");

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