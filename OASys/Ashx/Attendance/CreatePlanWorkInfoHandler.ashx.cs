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
    /// CreatePlanWorkInfoHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CreatePlanWorkInfoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            MDL.PlanWrokInfoMOD PWIMod=new MDL.PlanWrokInfoMOD ();
            PWIMod.PWID=Convert .ToInt32(context.Request["PWID"]);
            PWIMod.UsName=context.Request["Usname"];
            PWIMod.BeginDate=Convert .ToDateTime(context.Request["BeginDate"].ToString ());
            PWIMod.EndDate=Convert.ToDateTime(context.Request["EndDate"]);
            PWIMod.Hours = context.Request["HCount"];

            int result = new BLL.PlanWrokInfoBLL().Add(PWIMod);
            StringBuilder sb = new StringBuilder();

            if (result > 0)
            {
                sb.Append("[{\"result\":\"" + result + "\"}]");
            }
            else
            {
                sb.Append("[{\"result\":\"0\"}]");
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