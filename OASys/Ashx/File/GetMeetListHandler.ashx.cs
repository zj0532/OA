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
    /// GetMeetListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetMeetListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int page = Convert.ToInt32(context.Request["page"]);
            DataTable dt = new BLL.MeetingSummaryBLL().GetList(15, page, "MSDate desc", "").Tables[0];
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"Title\":\"" + dt.Rows[i]["MSTitle"] + "\",\"MSDate\":\"" + Convert.ToDateTime(dt.Rows[i]["MSDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"MSAddress\":\"" + dt.Rows[i]["MSAddress"] + "\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["UsID"].ToString())).UsName + "\",\"Remark\":\"" + Convert.ToDateTime(dt.Rows[i]["remark"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"MsID\":\"" + dt.Rows[i]["MsID"] + "\",\"DownLoad\":\"<a href='#' title='下载会议纪要' class='a1' onclick='Download(" + dt.Rows[i]["MsID"] + ")'> 下载 </a>\"} ");

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