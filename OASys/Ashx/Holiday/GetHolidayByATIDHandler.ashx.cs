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
    /// GetHolidayByATIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetHolidayByATIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            string AtID = context.Request["atid"];
            MDL.AttendanceMOD atMod = new BLL.AttendanceBLL().GetModel(int .Parse( AtID));
            str.Append("[{ ");
            str.Append(" \"holidayclass\":\"" + atMod.HolidayCalss + "\" ,");
            str.Append(" \"begindate\":\"" + atMod.BeginDate + "\" ,");
            str.Append(" \"enddate\":\"" + atMod.EndDate + "\" ,");
            str.Append(" \"holiday\":\"" + atMod.Holiday + "\" ,");
            str.Append(" \"workcontent\":\"" + atMod.WorkContent + "\" ,");
            str.Append(" \"workpeson\":\"" + atMod.WorkPeson + "\" ");
            str.Append(" }] ");
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