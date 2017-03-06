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

namespace OASys.Ashx.Table
{
    /// <summary>
    /// SearchDutyListHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SearchDutyListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Title = context.Request["txtTitleValue"].ToString();
            string BeginDate = context.Request["BeginDateValue"].ToString();
            string EndDate = context.Request["EndDateValue"].ToString();
            string Usname = context.Request["UsName"].ToString();
            string sqlWhere = "1=1";
            StringBuilder sb = new StringBuilder();

            if (Title.Trim() != "")
            {
                sqlWhere += " and KWTitle like '%" + Title + "%' ";
            }
            if (Usname.Trim() != "")
            {
                sqlWhere += " and usid in (select usid from tbUserInfo where UsName like '%"+Usname+"%') ";
            }
            if (BeginDate.Trim() != "")
            {
                sqlWhere += " and begindate<='" + BeginDate + "' ";
            }
            if (EndDate.Trim() != "")
            {
                sqlWhere += " and Enddate>='" + EndDate + "' ";
            }

            string order = " order by convert(datetime,begindate) desc ";

            DataTable dt = new BLL.KeepWatchBLL().GetListTotal(sqlWhere,order).Tables[0];

            string SetTitle = "";
            string IsFujian = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SetTitle = dt.Rows[i]["KWTitle"].ToString().Length > 18 ? dt.Rows[i]["KWTitle"].ToString().Substring(0, 10) + "..." : dt.Rows[i]["KWTitle"].ToString();
                    IsFujian = "<a href='#' class='a1' title='点击下载' onclick=GetFile('" + dt.Rows[i]["KWID"] + "') >下载</a>";
                    sb.Append(" {\"title\":\"" + SetTitle + "\",\"UsName\":\"" + new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName + "\",\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("yyyy-MM-dd") + "\",\"KWID\":\"" + dt.Rows[i]["KWID"].ToString() + "\",\"BeginDate\":\"" + Convert.ToDateTime(dt.Rows[i]["BeginDate"]).ToString("yyyy-MM-dd") + "\",\"EndDate\":\"" + Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("yyyy-MM-dd") + "\",\"DepartmenName\":\"" + new BLL.BusinessBLL().GetModel(Convert.ToInt32(dt.Rows[i]["DepartmentID"])).BusinessName + "\",\"Isfj\":\"" + IsFujian + "\"} ");

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