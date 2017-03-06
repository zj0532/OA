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
    /// WorkOvertimeSearchHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkOvertimeSearchHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string UsName = context.Request["UsName"];
            DateTime MinDate = Convert.ToDateTime(context.Request["BeginDate"].Trim() == "" ? "2000-01-01" : context.Request["BeginDate"]);
            DateTime MaxDate = Convert.ToDateTime(context.Request["EndDate"].Trim() == "" ? DateTime.Now.ToShortDateString() : context.Request["EndDate"]);
            string HolidayClass = context.Request["WorkClass"];
            DataTable dt = new DataTable();
            string strWhere = "postCause='加班' and stauts>10 ";
            string UidWhere = "";
            if (UsName != "")
            {
                dt = new BLL.UserInfoBLL().GetList("UsName='" + UsName + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        strWhere += " and usid='" + dt.Rows[0]["usid"] + "' ";
                    }
                    else
                    {
                        UidWhere += "and (";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UidWhere += " usid='" + dt.Rows[i]["usid"] + "' or";
                            if (i == dt.Rows.Count - 1)
                            {
                                UidWhere += "1=2 )";
                            }

                        }
                    }
                }
                else
                {
                    strWhere += " and 1=2 ";
                }
            }
            if (UidWhere != "")
            {
                strWhere = strWhere + UidWhere;
            }

            strWhere += " and begindate>=convert(datetime,'" + MinDate + "') and endDate<=convert(datetime,'" + MaxDate + "')";

            if (HolidayClass != "")
            {
                strWhere += "and HolidayCalss='" + HolidayClass + "' ";
            }

            strWhere += " order by  postdate desc ";
            dt = new BLL.AttendanceBLL().GetList(strWhere).Tables[0];
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