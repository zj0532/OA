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
    /// GetBusinessListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetBusinessListHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int Page = int.Parse(context.Request["page"]); //session["businessid"]
            DataTable dt = new DataTable();
            string BusID = HttpContext.Current.Session["BusID"].ToString();

            dt = new BLL.NewEmplyeeKnowBLL().GetList(15,1,"date desc"," BusinessID=3 or BusinessID="+BusID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"neid\":\"" + dt.Rows[i]["neid"] + "\",\"title\":\"<a class='a1' href='NewEmployeeShow.aspx?NeID=" + dt.Rows[i]["neid"] + "'>" + (dt.Rows[i]["title"].ToString().Length > 20 ? dt.Rows[i]["title"].ToString().Substring(0, 20) + "..." : dt.Rows[i]["title"].ToString()) + "</a>\",\"date\":\"" + Convert.ToDateTime(dt.Rows[i]["date"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"usname\":\"" + new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName + "\",\"remark\":\"" + (dt.Rows[i]["remark"].ToString().Length > 20 ? dt.Rows[i]["remark"].ToString().Substring(0, 20) + "..." : dt.Rows[i]["remark"].ToString()) + "\"} ");

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