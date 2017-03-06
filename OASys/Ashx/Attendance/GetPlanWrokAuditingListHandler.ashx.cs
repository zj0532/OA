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

namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// GetPlanWrokAuditingListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanWrokAuditingListHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int page = Convert.ToInt32(context.Request["page"]);
            int Usid = Convert.ToInt32(context.Session["UsID"]);
            int JobID=Convert.ToInt32(context.Session["JobID"]);
            string sqlWhere = "";
            if (JobID == 2)
            {
                sqlWhere = " stauts='0' and usid in (select usid from tbuserinfo where WrodGroupID=(select WrodGroupID from tbuserinfo where usid='"+Usid+"')) ";
            }
            if (JobID == 1)
            {
                sqlWhere = " stauts='5' ";
            }
            if (JobID > 2)
            {
                sqlWhere = "1=2";
            }

            DataTable dt = new BLL.PlanWrokBLL().GetList(15, page, " convert(datetime,date) desc", sqlWhere).Tables[0];

            string stauts = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stauts = new BLL.AttendanceAuditBLL().GetModel( dt.Rows[i]["stauts"].ToString()).AuditName ;

                    sb.Append(" {\"Title\":\"<a href='PlanWorkAudited.aspx?PWID="+dt.Rows[i]["pwid"]+"' class='a1' title='点击标题进入详细信息审核'>" + dt.Rows[i]["PWTitle"] + "\",\"ApplyDate\":\"" + Convert.ToDateTime(dt.Rows[i]["date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName + "\",\"BusName\":\"" + new BLL.BusinessBLL().GetModel(Convert.ToInt32(dt.Rows[i]["busid"])).BusinessName + "\",\"Stauts\":\"<a href='#' class='a1' title='" + dt.Rows[i]["remark"].ToString() + "'>" + stauts + "\",\"PWID\":\"" + dt.Rows[i]["pwid"].ToString() + "\"} ");

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