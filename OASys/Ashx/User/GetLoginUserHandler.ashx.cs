using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;
using System.Text;


namespace OASys.Ashx.User
{
    /// <summary>
    /// GetLoginUserHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetLoginUserHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            int UsID = Convert.ToInt32(context.Session["UsID"]);
            MDL.UserInfoMOD UserMod = new BLL.UserInfoBLL().GetModel(UsID);
            str.Append("[{");
            str.Append(" \"usid\":\"" + UserMod.UsID + "\" ,");
            str.Append(" \"usname\":\"" + UserMod.UsName + "\" ,");
            str.Append(" \"phone\":\"" + UserMod.Phone + "\" ,");
            str.Append(" \"email\":\"" + UserMod.Email + "\" ,");
            str.Append(" \"job\":\"" +new BLL.JobBLL().GetModel( UserMod.JobID).JobName + "\" ,");
            str.Append(" \"business\":\"" +new BLL.BusinessBLL().GetModel( UserMod.BusinessID).BusinessName + "\" ,");
            str.Append(" \"getDate\":\"" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + "\" ,");
           
            str.Append(" \"emptytwo\":\"" + UserMod.EmptyTwo + "\" ");
            str.Append("}]");

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