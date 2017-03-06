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
    /// ModifyAuthorityHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ModifyAuthorityHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            string UsID = context.Request["UsID"].ToString();
            string AuthListStr = context.Request["AuthList"].ToString();
            //30-1,29-1,28-1,27-1,26-1,4-1,3-1,2-1,
            new BLL.AuthorityBLL().DeleteByUsID(int.Parse(UsID));
            MDL.AuthorityMOD AhMod;
            string[] list = AuthListStr.Split(',');
            string[] ls;
            if(AuthListStr.Trim()!="")
            { 
                for (int i = 0; i < list.Length-1; i++)
                {
                    AhMod = new MDL.AuthorityMOD();
                    ls = list[i].Split('-');
                    AhMod.PsID =Convert .ToInt32(ls[0]);
                    AhMod.UsID =Convert .ToInt32(UsID);
                    AhMod.AuthorityParamID = Convert.ToInt32(ls[1]);
                    new BLL.AuthorityBLL().Add(AhMod);
                }
            }
            str.Append("[{\"result\":\"1\"}]");

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