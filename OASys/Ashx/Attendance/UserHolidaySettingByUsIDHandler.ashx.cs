using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using System.Runtime.Serialization;

using System.Web.Services;
using System.Data;

namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// UserHolidaySettingByUsIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserHolidaySettingByUsIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string UsID = context.Request["UserID"];
            string Sign = context.Request["Sigh"];
            string NianJia = context.Request["NianJia"];
            string TiaoXiu = context.Request["TiaoXiu"];
            DataTable dt = new DataTable();
            if (Sign == "Get")
            {
                dt = new BLL.UserInfoBLL().GetCountList("UsID="+UsID).Tables[0];

                sb.Append(" [{\"usid\":\"" + dt.Rows[0]["usid"].ToString() + "\",\"TiaoXiu\":\"" + dt.Rows[0]["tiaoxiu"].ToString() + "\",\"NianJia\":\"" + dt.Rows[0]["nianjia"].ToString() + "\",\"UsName\":\"" + dt.Rows[0]["usname"].ToString() + "\"}] ");
              
            }
            else
            {
                bool result = new BLL.UserInfoBLL().UpdateHolidaySetting(UsID, NianJia, TiaoXiu);
                if (result)
                {
                    sb.Append("[{\"result\":\"1\"}]");
                }
                else
                {
                    sb.Append("[{\"result\":\"0\"}]");
                }


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