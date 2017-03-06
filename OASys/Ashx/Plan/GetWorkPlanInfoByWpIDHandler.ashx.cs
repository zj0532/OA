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
    /// GetWorkPlanInfoByWpIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetWorkPlanInfoByWpIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string WPID = context.Request["WpID"];
            DataTable dt = new BLL.WorkPlanInfoBLL().GetList(300, 1, "times", "WPID='" + WPID + "'").Tables[0];
            StringBuilder sb = new StringBuilder();
            string IsReply = "";
            string IsFile = "";
            if (dt.Rows.Count > 0)
            {
                

                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IsReply = dt.Rows[i]["WPIContent"].ToString().Trim() == "" ? "未回复" : "已回复";
                    IsFile = dt.Rows[i]["FileName"].ToString().Trim() == "" ? "无" : "有";
                    sb.Append(" {\"Times\":\"第" + dt.Rows[i]["times"] + "期\",\"WpiPlanInfo\":\"<a href='#' class='a1' title='点击查看详细信息' onclick='LookInfo(" + dt.Rows[i]["wpiid"] + ")'>点击查看</a>\",\"ShouldDate\":\"" + Convert.ToDateTime(dt.Rows[i]["ShouldDate"]).ToString("yyyy-MM-dd") + "\",\"TruthDate\":\"" + Convert.ToDateTime(dt.Rows[i]["TruthDate"]).ToString("yyyy-MM-dd") + "\",\"IsFile\":\"" + IsFile + "\",\"WPIID\":\"" + dt.Rows[i]["wpiid"].ToString() + "\",\"DelContent\":\"<a href='#' class='a1' title='点击删除' onclick='DelPlan(" + dt.Rows[i]["wpiid"] + ")'>删除</a>\",\"IsReply\":\"" + IsReply + "\"} ");
                    
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