using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx.WorkOvertime
{
    /// <summary>
    /// WorkOvertimeAuditedHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkOvertimeAuditedHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            
            int JobID = Convert.ToInt32(context.Session ["JobID"]);
            int BusID = Convert.ToInt32(context.Session["BusID"]);
            string AtID = context.Request["AtID"].ToString();
            string Stauts = context.Request["Stauts"].ToString();
            MDL.AttendanceMOD AtMod = new BLL.AttendanceBLL().GetModel(int.Parse(AtID));

            if (Stauts == "1")
            {
                if (Convert.ToDouble(AtMod.Holiday) <= Convert.ToDouble(new BLL.AttendanceAuditBLL().GetList("Jobid='" + JobID + "'").Tables[0].Rows[0]["hours"]))
                {
                    AtMod.Stauts = new BLL.AttendanceAuditBLL().GetList("jobid='" + JobID + "' and auditname='同意' ").Tables[0].Rows[0]["auditid"].ToString();
                }
                else
                {
                    AtMod.Stauts = new BLL.AttendanceAuditBLL().GetList("jobid='" + JobID + "' and auditname='审核中' ").Tables[0].Rows[0]["auditid"].ToString();
                
                }
            }
            else
            {
                AtMod.Stauts = new BLL.AttendanceAuditBLL().GetList("jobid='" + JobID + "' and auditname='未通过' ").Tables[0].Rows[0]["auditid"].ToString();
            }

            if (int.Parse(AtMod.Stauts) >10)
            {
                double TimeCount = 0;
                if (AtMod.HolidayCalss == "加班")
                {
                    int Usid = new BLL.AttendanceBLL().GetModel(int.Parse( AtID)).UsID;
                    TimeCount = Convert.ToDouble(new BLL.UserInfoBLL().GetCountList("UsID=" + Usid).Tables[0].Rows[0]["TiaoXiu"]) + Convert.ToDouble(AtMod.Holiday);

                    new BLL.UserInfoBLL().UpdateHolidaySetting(Usid.ToString (), new BLL.UserInfoBLL().GetCountList("UsID=" + Usid).Tables[0].Rows[0]["NianJia"].ToString(), TimeCount.ToString());

                }
                
            }
            
            bool result = new BLL.AttendanceBLL().Update(AtMod);




            if (result)
            {
                str.Append("[{\"result\":\"1\"}]");
            }
            else
            {
                str.Append("[{\"result\":\"0\"}]");
            }


            context.Response.Write(str.ToString());
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