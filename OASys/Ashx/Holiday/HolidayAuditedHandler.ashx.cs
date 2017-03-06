using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;


namespace OASys.Ashx.Holiday
{
    /// <summary>
    /// HolidayAuditedHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class HolidayAuditedHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            int AtID = Convert.ToInt32(context.Request["AtID"]);
            string staut = context.Request["Stauts"];
            MDL.AttendanceMOD AtMod = new BLL.AttendanceBLL().GetModel(AtID);
            MDL.UserInfoMOD UiMod=new BLL.UserInfoBLL().GetModel(AtMod.UsID);
            int JobID = Convert.ToInt32(HttpContext.Current.Session["JobID"].ToString());
            int BusID = Convert.ToInt32(HttpContext.Current.Session["BusID"].ToString());
            DataTable dt = new BLL.AttendanceAuditBLL().GetList("jobid='" + JobID + "' order by convert(int,auditid) ").Tables[0];
            int result = 0;


            if (UiMod.JobID > 4 && UiMod.JobID != 7)
            {
                if (double.Parse(AtMod.Holiday) > Convert.ToInt32(dt.Rows[0]["Days"]))
                {
                    AtMod.Stauts = dt.Rows[0]["auditid"].ToString();
                }
                else
                {
                    AtMod.Stauts = dt.Rows[dt.Rows.Count - 1]["auditid"].ToString();
                   
                }

                if (staut == "0")
                {
                    AtMod.Stauts = new BLL.AttendanceAuditBLL().GetList("Jobid='" + JobID + "' and auditname='未通过'").Tables[0].Rows[0]["auditid"].ToString();
                }
                result = new BLL.AttendanceBLL().Update(AtMod) == true ? 1 : 0;
                if (int.Parse(AtMod.Stauts) > 10)
                {
                    double TimeCount = 0;
                    if (AtMod.HolidayCalss == "年假")
                    {
                        TimeCount = Convert.ToDouble(new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["NianJia"]) - Convert.ToDouble(AtMod.Holiday);

                        new BLL.UserInfoBLL().UpdateHolidaySetting(UiMod.UsID.ToString(), TimeCount.ToString(), new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["TiaoXiu"].ToString());

                    }
                    if (AtMod.HolidayCalss == "调休")
                    {
                        TimeCount = Convert.ToDouble(new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["TiaoXiu"]) - Convert.ToDouble(AtMod.Holiday);
                        new BLL.UserInfoBLL().UpdateHolidaySetting(UiMod.UsID.ToString(), new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["NianJia"].ToString(), TimeCount.ToString());

                    }
                }

            }
            else
            {
                if (JobID!=1)
                {
                    AtMod.Stauts = dt.Rows[0]["auditid"].ToString();
                }
                else
                {
                    AtMod.Stauts = "11";
                }


                if (staut == "0")
                {
                    AtMod.Stauts = new BLL.AttendanceAuditBLL().GetList("Jobid='" + JobID + "' and auditname='未通过'").Tables[0].Rows[0]["auditid"].ToString();
                }
                result = new BLL.AttendanceBLL().Update(AtMod) == true ? 1 : 0;
                if (int.Parse(AtMod.Stauts)==11)
                {
                    double TimeCount = 0;
                    if (AtMod.HolidayCalss == "年假")
                    {
                        TimeCount = Convert.ToDouble(new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["NianJia"]) - Convert.ToDouble(AtMod.Holiday);

                        new BLL.UserInfoBLL().UpdateHolidaySetting(UiMod.UsID.ToString(), TimeCount.ToString(), new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["TiaoXiu"].ToString());

                    }
                    if (AtMod.HolidayCalss == "调休")
                    {
                        TimeCount = Convert.ToDouble(new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["TiaoXiu"]) - Convert.ToDouble(AtMod.Holiday);
                        new BLL.UserInfoBLL().UpdateHolidaySetting(UiMod.UsID.ToString(), new BLL.UserInfoBLL().GetCountList("UsID=" + UiMod.UsID).Tables[0].Rows[0]["NianJia"].ToString(), TimeCount.ToString());

                    }
                }
            }

            StringBuilder str = new StringBuilder();
            if (result > 0)
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