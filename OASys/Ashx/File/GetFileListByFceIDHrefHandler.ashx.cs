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
    /// GetFileListByFceIDHerfHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetFileListByFceIDHerfHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string FceID = context.Request["FceID"];
            int page = Convert.ToInt32(context.Request["page"]);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.FileManagerBLL().GetList(15, page, "filedate desc", "FceID='" + FceID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"FileName\":\"<a href='StandardShow.aspx?Fid="+dt.Rows[i]["Flid"]+"' class='a1' title='点击链接进入标题'>" + dt.Rows[i]["FileName"] + "</a>\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["UsID"].ToString())).UsName + "\",\"FileDate\":\"" + Convert.ToDateTime(dt.Rows[i]["FileDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"FileClass\":\"" + new BLL.FileClassExplicitBLL().GetModel(int.Parse(dt.Rows[i]["FCEID"].ToString())).FCEName + "\",\"DownLoad\":\"<a href='#' title='下载文档' class='a1' onclick='Download(" + dt.Rows[i]["flid"] + ")'> 下载 </a>\",\"FileID\":\""+dt.Rows[i]["flid"]+"\"} ");

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