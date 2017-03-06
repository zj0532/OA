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
    /// GetFileListByFcIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetFileListByFcIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string FcID = context.Request["FcID"];
            int page = Convert.ToInt32(context.Request["page"]);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.FileManagerBLL().GetList(15, page, "filedate desc", "FcID='" + FcID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"FileName\":\"<a href='ImportantShow.aspx?Fid="+dt.Rows[i]["flid"]+"' class='a1' >" + dt.Rows[i]["FileName"] + "</a>\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["UsID"].ToString())).UsName + "\",\"FileDate\":\"" + Convert.ToDateTime(dt.Rows[i]["FileDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"FileClass\":\"" + new BLL.FileClassExplicitBLL().GetModel(int.Parse(dt.Rows[i]["FCEID"].ToString())).FCEName + "\",\"DownLoad\":\"下载\",\"FileID\":\""+dt.Rows[i]["FlID"]+"\"} ");

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