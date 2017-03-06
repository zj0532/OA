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
    /// WorkOvertimeListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkOvertimeListHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int Page = int.Parse(context.Request["page"]); //session["level"] 获取一个用户等级session 判断显示审核人的权利
            DataTable dt = new DataTable();
            string strWhere = "postcause='加班' and stauts<10 ";
            int JobID = Convert.ToInt32(context.Session["JobID"]);
            int BusID = Convert.ToInt32(context.Session["BusID"]);
            int WordGroupID = Convert.ToInt32(context.Session["WordGroupID"]);

            if (JobID > 3 && BusID != 5)
            {
                strWhere += " and 1=2";
            }
            if (JobID > 3 && BusID == 5)
            {
                strWhere += " and stauts = 0";
            }
            if (JobID == 3 && BusID != 5)
            {
               strWhere += " and UsID in (select Usid from tbUserInfo where businessid='"+BusID+"') and (stauts='1' or stauts='0') ";
            }
            if (JobID == 3 && BusID==5)
            {
                strWhere += " and UsID in (select Usid from tbUserInfo where businessid='" + BusID + "') and (stauts='1') ";
            }
            if (JobID == 2)
            {
               strWhere += " and UsID in (select Usid from tbUserInfo where WrodGroupID='" + WordGroupID + "') and stauts='3' ";
            }
            if (JobID == 1)
            {
                strWhere += " and stauts='5' ";
            }


            dt = new BLL.AttendanceBLL().GetList(15, Page, "postdate desc", strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"holidayclass\":\"" + dt.Rows[i]["holidaycalss"].ToString() + "\",\"Holiday\":\"" + dt.Rows[i]["Holiday"].ToString() + "小时\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"ShowInfo\":\" <a onclick='show(" + dt.Rows[i]["atid"].ToString() + ")'>详细</a>\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"begindate\":\"" + Convert.ToDateTime(dt.Rows[i]["begindate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"Audit\":\"<a onclick='Audit(" + dt.Rows[i]["atid"] + ",1)'>通过</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a onclick='Audit(" + dt.Rows[i]["atid"] + ",0)'>不通过</a> \",\"enddate\":\"" + Convert.ToDateTime(dt.Rows[i]["enddate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\"} ");

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