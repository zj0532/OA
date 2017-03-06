using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;


namespace OASys.Ashx
{
    /// <summary>
    /// UserAttendanceHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserAttendanceHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            //int Page = int.Parse(context.Request["UserID"]); Session["UserID"]
            int Page=int.Parse(context.Request["page"]);
            DataTable dt = new DataTable();
            string strWhere = "(convert(nvarchar,year(postdate))+convert(nvarchar,month(postdate))=convert(nvarchar,year(getdate()))+convert(nvarchar,month(getdate()))";
            strWhere+=" or convert(nvarchar,year(postdate))+convert(nvarchar,month(postdate))=convert(nvarchar,year(DATEADD(\"MM\",-1,getdate())))+convert(nvarchar,month(DATEADD(\"MM\",-1,getdate())))  )";
            strWhere += " and usid='" + context.Session["UsID"] + "'";
            string stauts = "";
            dt = new BLL.AttendanceBLL().GetList(15, Page, "postdate desc", strWhere).Tables[0];

            if(dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stauts = dt.Rows[i]["stauts"].ToString() == "" ? "101" : dt.Rows[i]["stauts"].ToString();

                    var attendanceAudit = new BLL.AttendanceAuditBLL().GetModel(stauts);

                    sb.Append(" { \"AttendanceAuditRemark\": \"" + attendanceAudit.Remark + "\", \"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"postCause\":\"" + dt.Rows[i]["postcause"].ToString() + "\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"postip\":\"" + dt.Rows[i]["postip"].ToString() + "\",\"stauts\":\"<a href='#' class='a1' title='" + attendanceAudit.Remark + "'>" + attendanceAudit.AuditName + "</a>\",\"Remark\":\"" + dt.Rows[i]["remark"].ToString() + "\"} ");

                    if(i != dt.Rows.Count - 1)
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