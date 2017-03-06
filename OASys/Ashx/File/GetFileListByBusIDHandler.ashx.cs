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
    /// GetFileListByBusIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetFileListByBusIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string BusID = context.Request["BusID"];
            int page = int.Parse(context.Request["page"]);
            
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.FileManagerBLL().GetList(15, page, "filedate desc", " FcID='1' and Usid in (select usid from tbuserinfo where BusinessID='" + BusID + "')").Tables[0];

            if(dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"FileName\":\"" + dt.Rows[i]["FileName"] + "\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["UsID"].ToString())).UsName + "\",\"FileDate\":\"" + Convert.ToDateTime(dt.Rows[i]["FileDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"FileClass\":\"" + new BLL.FileClassExplicitBLL().GetModel(int .Parse( dt.Rows[i]["FCEID"].ToString ())).FCEName + "\",\"DownLoad\":\" <a href='#' title='下载周报' class='a1' onclick='Download("+dt.Rows[i]["flid"]+")'> 下载 </a>\"} ");

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