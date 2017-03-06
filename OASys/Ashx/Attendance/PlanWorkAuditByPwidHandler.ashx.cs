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

namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// PlanWorkAuditByPwidHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PlanWorkAuditByPwidHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            
            int Usid = Convert.ToInt32(context.Session["UsID"]);
            int JobID = Convert.ToInt32(context.Session["JobID"]);
            string PwID = context.Request["PWID"];
            string Result = context.Request["Result"];
            string Remark = context.Request["Remark"];

            MDL.PlanWrokMOD PLMod = new BLL.PlanWrokBLL().GetModel(Convert.ToInt32(PwID));

            if (Result == "0")
            {
                PLMod.Stauts = -1;
                PLMod.Remark = Remark;

            }
            else
            { 

                string Provisional=JobID==1?"同意":"审核中";
                PLMod.Stauts = Convert.ToInt32(new BLL.AttendanceAuditBLL().GetList("jobid='" + JobID + "' and auditname='" + Provisional + "'").Tables[0].Rows[0]["auditid"]);
           
            }

            bool ret = new BLL.PlanWrokBLL().Update(PLMod);

            string Message = "";
            if (ret)
            {
                Message = "审核成功！";
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