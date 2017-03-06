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
    /// AttendanceCheckHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AttendanceCheckHandler : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int Page = int.Parse(context.Request["page"]);
            DataTable dt = new DataTable();

            dt = new BLL.AttendanceBLL().GetList(15, Page, "postdate desc", " postcause !='请假' and postcause!='加班' ").Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"postCause\":\"" + dt.Rows[i]["postcause"].ToString() + "\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"postip\":\"" + dt.Rows[i]["postip"].ToString() + "\",\"Remark\":\"" + dt.Rows[i]["remark"].ToString() + "\"} ");

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