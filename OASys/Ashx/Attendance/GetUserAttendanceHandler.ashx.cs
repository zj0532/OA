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
    /// GetUserAttendanceHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetUserAttendanceHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            MDL.AttendanceMOD attMod = new MDL.AttendanceMOD();
            attMod.UsID =Convert .ToInt32(context.Session["UsID"]);
            attMod.PostCause=context.Request["Cid"].ToString();

            attMod.BeginDate = context.Request["BeginDate"].ToString();
            attMod.EndDate = context.Request["EndDate"].ToString();
            attMod.Holiday = context.Request["Holiday"];
            attMod.HolidayCalss = context.Request["HolidayClass"].ToString();
            attMod.WorkContent = context.Request["WorkContent"].ToString();
            attMod.WorkPeson = context.Request["WorkPeson"].ToString();
            attMod.PostDate = DateTime.Now;
            attMod.PostIP = GetAddress();
            attMod.Remark = context.Request["remark"].ToString();
            int JobID=new BLL.UserInfoBLL().GetModel(attMod.UsID).JobID;
            DataTable dt;

            if ( JobID< 5&&JobID!=1)
            {
                attMod.Stauts = new BLL.AttendanceAuditBLL().GetList("auditname='审核中' and jobid='"+JobID+"' ").Tables[0].Rows[0]["auditid"].ToString ();
            }
            else
            {
                if (JobID == 7)
                {
                    attMod.Stauts = "3";
                }
                else
                {
                    #region 业务组有组长 审核状态为0 没有组长 审核状态为1
                    int BusID = new BLL.UserInfoBLL().GetModel(attMod.UsID).BusinessID;
                    int res = new BLL.UserInfoBLL().GetList("BusinessID='"+BusID+"' and Jobid=4 ").Tables[0].Rows.Count;
                    if (res > 0)
                    {
                        attMod.Stauts = "0";
                    }
                    else
                    {
                        attMod.Stauts = "1";
                    }
                   

                    #endregion
                }
            
            
            }
            if (attMod.PostCause == "上班" || attMod.PostCause == "下班")
            {
                attMod.Stauts ="";
            }

            string returnStr="";
            if (attMod.PostCause == "上班")
            {
                 dt = new BLL.AttendanceBLL().GetList(" postdate between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' and usid='" + attMod.UsID + "' and postcause='上班' ").Tables[0];
               
                 if (dt.Rows.Count>0)
                {
                    returnStr = "当前用户上班已打过卡,本次操作无效!";
                }
                else
                {
                    dt = new BLL.AttendanceBLL().GetList(" postdate between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' and postip='"+attMod.PostIP+"' and postcause='上班'  ").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (new BLL.UserInfoBLL().GetList(" Usid=" + attMod.UsID).Tables[0].Rows[0]["IsLockIP"].ToString() != "1")
                       {
                           returnStr = "当前IP上班已打过卡，本次操作无效!";
                       }

                    }
                }

            }

            if (attMod.PostCause == "下班")
            {
                dt = new BLL.AttendanceBLL().GetList(" postdate between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' and usid='" + attMod.UsID + "' and postcause='下班' ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    returnStr = "当前用户下班已打过卡,本次操作无效!";
                }
                else
                {
                    dt = new BLL.AttendanceBLL().GetList(" postdate between '" + DateTime.Now.ToString("yyyy-MM-dd") + " 0:00:00' and '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59' and postip='" + attMod.PostIP + "' and postcause='下班' ").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        returnStr = "当前IP下班已打过卡，本次操作无效!";
                    }
                }

            }

            if (returnStr == "")
            {
                int result = new BLL.AttendanceBLL().Add(attMod);
                if (result > 0)
                {
                    str.Append("[{\"result\":\"本次操作成功\"}]");
                }
                else
                {
                    str.Append("[{\"result\":\"本次操作失败\"}]");
                }
            }
            else
            {
                str.Append("[{\"result\":\""+returnStr+"\"}]");
            
            }
            context.Response.Write(str.ToString());
            context.Response.End();
        }

        public string GetAddress()
        {

            string userIP = "未获取用户IP";


            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";


                string CustomerIP = "";


                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }


                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];



                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;


                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];


                }


                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }


            return userIP;

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