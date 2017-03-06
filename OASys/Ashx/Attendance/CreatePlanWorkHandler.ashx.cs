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
    /// CreatePlanWorkHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CreatePlanWorkHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            MDL.PlanWrokMOD PWMod = new MDL.PlanWrokMOD();
            PWMod.UsID=Convert.ToInt32(context.Session["UsID"]);
            PWMod.PWTitle=context.Request["Title"];
            PWMod.Date = DateTime.Now;
            PWMod.BusID =Convert .ToInt32(context.Session["BusID"]);
            PWMod.Stauts = 0;

            int result = new BLL.PlanWrokBLL().Add(PWMod);
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