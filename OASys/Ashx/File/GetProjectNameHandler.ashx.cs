using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;


namespace OASys.Ashx.File
{
    /// <summary>
    /// GetProjectNameHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetProjectNameHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.BusinessBLL().GetList(15, 1, "businessid", "businessid!=2 and businessid!=3").Tables[0];


            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"businessname\":\"<a href='WeeklyReportList.aspx?BusID=" + dt.Rows[i]["businessid"].ToString() + "' class='a1'>" + dt.Rows[i]["businessName"] + "</a>\",\"style\":\"2014-05-25至2014-05-31_周工作总结\"} ");

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