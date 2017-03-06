using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using System.Runtime.Serialization;

using System.Web.Services;
using System.Data;

namespace OASys.Ashx.User
{
    /// <summary>
    /// GetUserByAuthortyHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class GetUserByAuthortyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            sb.Append("[{ \"id\":\"1\",");
            sb.Append(" \"text\":\"刘亚辉\"}");
            sb.Append("]");
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