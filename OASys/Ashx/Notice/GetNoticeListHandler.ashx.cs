using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx.Notice
{
    /// <summary>
    /// GetNoticeListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetNoticeListHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int page = Convert.ToInt32(context.Request["page"]);
            int UsID = Convert.ToInt32(context.Session["UsID"]);
            int JobID = Convert.ToInt32(context.Session["JobID"]);
            int BusID = Convert.ToInt32(context.Session["BusID"]);

            string sqlWhere = "1=1";
            if (JobID == 2)
            {
                sqlWhere += " and (noticeclass='0' or (noticeclass='1' and classValue='"+new BLL.UserInfoBLL().GetModel(UsID).WrodGroupID+"') or noticeclass='2') ";
            }
            if (JobID >= 3)
            {
                sqlWhere += " and (noticeclass='0' or (noticeclass='1' and classValue='" + new BLL.UserInfoBLL().GetModel(UsID).WrodGroupID + "') or (noticeclass='2' and classValue='" + new BLL.UserInfoBLL().GetModel(UsID).BusinessID + "')) ";
            }


            DataTable dt = new BLL.NoticeBLL().GetList(15, page, " convert(datetime,date) desc ", sqlWhere).Tables[0];

            string SetTitle = "";
            string IsFujian = "";
            string NoClass = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SetTitle = dt.Rows[i]["Title"].ToString().Length > 18 ? dt.Rows[i]["Title"].ToString().Substring(0, 18) + "..." : dt.Rows[i]["Title"].ToString();
                    IsFujian =dt.Rows[i]["FileName"].ToString ()==""?"无":"<a href='#' class='a1' title='点击下载' onclick=GetFile('" + dt.Rows[i]["Noid"] + "') >下载</a>";
                    if (dt.Rows[i]["NoticeClass"].ToString ()=="0")
                    {
                        NoClass = "全员显示";
                    }
                    if (dt.Rows[i]["NoticeClass"].ToString() == "1")
                    {
                        NoClass = "区域显示";
                    }
                    if (dt.Rows[i]["NoticeClass"].ToString() == "2")
                    {
                        NoClass = "业务组显示";
                    }

                    sb.Append(" {\"title\":\"<a title='"+dt.Rows[i]["title"]+"' class='a1' href='NoticeShow.aspx?Ntid="+dt.Rows[i]["Noid"]+"'>" + SetTitle + "\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName + "\",\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("yyyy-MM-dd") + "\",\"NoID\":\"" + dt.Rows[i]["NoID"].ToString() + "\",\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EffectDateBefore"]).ToString("yyyy-MM-dd") + "\",\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EffectDateEnd"]).ToString("yyyy-MM-dd") + "\",\"NoClass\":\"" + NoClass + "\",\"Isfj\":\"" + IsFujian + "\"} ");

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