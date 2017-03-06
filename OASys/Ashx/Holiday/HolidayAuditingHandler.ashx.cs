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
    /// HolidayAuditingHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class HolidayAuditingHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            
            string strWhere = "postcause='请假'";
            int Page = int.Parse(context.Request["page"]); //session["level"] 获取一个用户等级session 判断显示审核人的权利
            
            int UsID = Convert.ToInt32(HttpContext.Current.Session["UsID"]);
            int JobID = Convert.ToInt32(HttpContext.Current.Session["JobID"]);
            int BusinessID = Convert.ToInt32(HttpContext.Current.Session["BusID"]);
            string WordGroupID = HttpContext.Current.Session["WordGroupID"].ToString();

            if (JobID > 4)
            {
                strWhere += " and 1=2";
            }
            
            if (JobID == 4)
            {
                strWhere += " and stauts='0' and usid in (select usid from tbuserinfo where  businessid= (select businessid from tbuserinfo where usid='"+UsID+"') and jobid>4) ";
            }

            if (JobID == 3)
            {
                strWhere += " and ((stauts='1'and usid in (select usid from tbuserinfo where  businessid= (select businessid from tbuserinfo where usid='"+UsID+"') and jobid>3) ) ";
                strWhere += " or( stauts='0' and usid in(select usid from tbuserinfo where jobid='4'))) ";
            }

            if (JobID == 2)
            {
                strWhere += " and ((stauts='3' and usid in (select usid from tbuserinfo where wrodgroupid='" + WordGroupID + "')) ";
                strWhere += " or( stauts='0' and usid in(select usid from tbuserinfo where jobid='3' and wrodgroupid='"+WordGroupID+"'))) ";
            }
            if (JobID == 1)
            {
                strWhere += " and ((stauts='5') ";
                strWhere += " or( stauts='0' and usid in(select usid from tbuserinfo where jobid='2'))) ";
            }


            DataTable dt = new DataTable();
            dt = new BLL.AttendanceBLL().GetList(15, Page, "postdate desc", strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"usname\":\"" + new BLL.UserInfoBLL().GetModel(int.Parse(dt.Rows[i]["usid"].ToString())).UsName + "\",\"holidayclass\":\"" + dt.Rows[i]["holidaycalss"].ToString() + "\",\"Holiday\":\"" + dt.Rows[i]["Holiday"].ToString() + "小时\",\"atid\":\"" + dt.Rows[i]["atid"].ToString() + "\",\"ShowInfo\":\" <a onclick='show(" + dt.Rows[i]["atid"].ToString() + ")'>详细</a>\",\"postdate\":\"" + Convert.ToDateTime(dt.Rows[i]["postdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"begindate\":\"" + Convert.ToDateTime(dt.Rows[i]["begindate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"Audit\":\"<a onclick='Audit(" + dt.Rows[i]["atid"] + ",1)'>通过</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a onclick='Audit(" + dt.Rows[i]["atid"] + ",0)'>不通过</a> \",\"enddate\":\"" + Convert.ToDateTime(dt.Rows[i]["enddate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"NianJia\":\"" + new BLL.UserInfoBLL().GetCountList("UsID=" + dt.Rows[i]["usid"].ToString()).Tables[0].Rows[0]["NianJia"] +"小时"+ "\",\"TiaoXiu\":\"" + new BLL.UserInfoBLL().GetCountList("UsID=" + dt.Rows[i]["usid"].ToString()).Tables[0].Rows[0]["TiaoXiu"] +"小时"+ "\"} ");

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