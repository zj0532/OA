using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;


namespace OASys.Ashx.Authority
{
    /// <summary>
    /// GetAuthorityByUsIDHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetAuthorityByUsIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            int UsID = Convert.ToInt32(context.Request["UsID"]);
            DataTable dt = new BLL.AuthorityBLL().GetListByUsID(UsID).Tables [0];

            if (dt.Rows.Count > 0)
            {
                str.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                        str.Append("{\"Name\":\"" + dt.Rows[i]["Name"] + "\"}");


                        if (i < dt.Rows.Count - 1)
                        {
                            str.Append(",");
                        }
                    
                }
                str.Append("]");

            }
            else
            {
                str.Append("[{\"Name\":\"新员工须知读\"}]");
            
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