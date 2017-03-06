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
    /// GetPlanListByUserIDHandler1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPlanListByUserIDHandler1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
       
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int UsID = Convert.ToInt32(context.Session["UsID"]);
            int page = Convert.ToInt32(context.Request["page"]);
            string sqlWhere = " UsID='" + UsID + "' and isdel='0' ";
            DataTable dt = new BLL.WorkPlanBLL().GetList(15, page, "CreateDate desc", sqlWhere).Tables[0];
            StringBuilder sb = new StringBuilder();
            string SetTitle = "";
            string IsFujian = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SetTitle = dt.Rows[i]["wptitle"].ToString().Length > 18 ? dt.Rows[i]["wptitle"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["wptitle"].ToString();
                    IsFujian = dt.Rows[i]["filename"].ToString().Trim() == "" ? "无" : "有";
                    sb.Append(" {\"title\":\"<a title='点击进入' class='a1' href='PlanShow.aspx?wpid=" + dt.Rows[i]["wpid"] + "'>" + SetTitle + "</a>\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName + "\",\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"]).ToString("yyyy-MM-dd") + "\",\"WPID\":\"" + dt.Rows[i]["wpid"].ToString() + "\",\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\",\"Cycle\":\"" + dt.Rows[i]["Cycle"].ToString() + "\",\"Isfj\":\"" + IsFujian + "\"} ");

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