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

namespace OASys.Ashx.Plan
{
    /// <summary>
    /// GetWPIContentHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetWPIContentHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string WPIID = context.Request["Wpiid"];
            MDL.WorkPlanInfoMOD WPIMod = new BLL.WorkPlanInfoBLL().GetModel(int .Parse(WPIID));

            sb.Append("[{\"WPIPlanInfo\":\"" + WPIMod.WPIPlanInfo + "\"");
            sb.Append(",\"WPIContent\":\""+WPIMod.WPIContent+"\"");
            sb.Append(",\"FileName\":\"" + WPIMod.FileContent + "\"");
            sb.Append(",\"WPIID\":\"" + WPIMod.WPIID + "\"");
            sb.Append("}]");
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