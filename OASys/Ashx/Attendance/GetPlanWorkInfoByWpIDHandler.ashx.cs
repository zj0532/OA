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
    /// GetPlanWorkInfoByWpIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanWorkInfoByWpIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int Pwid = Convert.ToInt32(context.Request["PWID"]);
            DataTable dt = new BLL.PlanWrokInfoBLL().GetList("pwid='"+Pwid+"' order by pwlid").Tables[0];
            StringBuilder sb = new StringBuilder();
            
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows.Count+ ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"UsName\":\"" + dt.Rows[i]["UsName"] + "\",\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["beginDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"Count\":\"" + dt.Rows[i]["Hours"].ToString() + "\",\"DelContent\":\"<a href='#' class='a1' title='点击删除' onclick='DelPlan(" + dt.Rows[i]["PWLID"] + ")'>删除</a>\",\"PWLID\":\"" + dt.Rows[i]["PWLID"].ToString() + "\"} ");

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