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
    /// ResetPlanWorkApplyHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ResetPlanWorkApplyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string PwID = context.Request["PWID"];
            MDL.PlanWrokMOD PWMod = new BLL.PlanWrokBLL().GetModel(Convert.ToInt32(PwID));
            PWMod.Stauts = 0;
            PWMod.Remark = "";
            bool ret = new BLL.PlanWrokBLL().Update(PWMod);
            StringBuilder sb = new StringBuilder();
            string Message = "";
            if (ret)
            {
                Message = "提交成功！";
            }
            else
            {
                Message = "审核失败，请与管理员联系！";
            }
            sb.Append("[{\"Result\":\"" + Message + "\"}]");
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