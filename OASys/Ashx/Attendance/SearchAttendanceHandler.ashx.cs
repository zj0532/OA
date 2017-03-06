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
    /// SearchAttendanceHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SearchAttendanceHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            string strWhere="postcause!='请假' and postcause!='加班' ";
            string Usname = context.Request["UsName"].ToString();
            string BeginDate = context.Request["BeginDate"].ToString();
            string EndDate = context.Request["EndDate"].ToString();
            string PostIP = context.Request["PostIp"].ToString();

            if (Usname != "")
            {
                strWhere += " and UsID='" + new BLL.UserInfoBLL().GetModel(Usname).UsID + "'";
            }

            if (BeginDate != "")
            {
                strWhere += " and postdate>='" + BeginDate + "' ";
            }
            if (EndDate != "")
            {
                strWhere += " and postdate<='" + EndDate + "' ";
            }
            if (PostIP != "")
            {
                strWhere += " and PostIP='" + PostIP + "'";
            }
            strWhere += " order by postdate desc ";
            DataTable dt=new BLL.AttendanceBLL().GetList(strWhere).Tables [0];

            if (dt.Rows.Count > 0)
            {
                str.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str.Append(" {\"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"postCause\":\"" + dt.Rows[i]["postcause"].ToString() + "\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"postip\":\"" + dt.Rows[i]["postip"].ToString() + "\",\"Remark\":\"" + dt.Rows[i]["remark"].ToString() + "\"} ");

                    if (i != dt.Rows.Count - 1)
                    {
                        str.Append(" , ");
                    }


                }
                str.Append(" ]} ");

            }
            else
            {
                str.Append(" {\"total\":0,\"rows\":[ ");
                str.Append(" ]} ");

            }

            context.Response.Write(str.ToString());
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