using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OASys.Ashx.Time
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DateTime currentTime;
            currentTime = System.DateTime.Now;
            context.Response.ContentType = "text/plain";
            context.Response.Write(currentTime);
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