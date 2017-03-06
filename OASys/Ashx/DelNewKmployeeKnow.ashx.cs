using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx
{
    /// <summary>
    /// DelNewKmployeeKnow 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] 
    public class DelNewKmployeeKnow : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            string Neid = context.Request["NeID"];
            bool result = new BLL.NewEmplyeeKnowBLL().Delete(int.Parse(Neid));
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