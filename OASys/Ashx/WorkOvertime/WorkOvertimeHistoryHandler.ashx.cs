using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;


namespace OASys.Ashx.WorkOvertime
{
    /// <summary>
    /// WorkOvertimeHistoryHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkOvertimeHistoryHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int Page = int.Parse(context.Request["page"]);
            DataTable dt = new DataTable();

            dt = new BLL.AttendanceBLL().GetList(15, Page, "BeginDate desc", "postCause='加班' and stauts>10 ").Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"holidayclass\":\"" + dt.Rows[i]["holidaycalss"].ToString() + "\",\"Holiday\":\"" + dt.Rows[i]["Holiday"].ToString() + "小时\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"ShowInfo\":\" <a onclick='show(" + dt.Rows[i]["atid"].ToString() + ")'>详细</a>\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"begindate\":\"" + Convert.ToDateTime(dt.Rows[i]["begindate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"Audit\":\"<a href='#' class='a1' title='" + new BLL.AttendanceAuditBLL().GetModel(dt.Rows[i]["stauts"].ToString()).Remark + "'>" + new BLL.AttendanceAuditBLL().GetModel(dt.Rows[i]["stauts"].ToString()).AuditName + "</a>\",\"enddate\":\"" + Convert.ToDateTime(dt.Rows[i]["enddate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\"} ");

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