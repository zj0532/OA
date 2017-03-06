using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx.StoreHouse
{
    /// <summary>
    /// KeepStoreHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class KeepStoreHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Aaid = context.Request["AAKeepid"];
            string KeepDate = context.Request["KeepOnDate"];
            string KeepRemark = context.Request["KeepOnRemark"];

            MDL.ApplyArticleMOD AAMod = new BLL.ApplyArticleBLL().GetModel(Convert.ToInt32(Aaid));

            AAMod.AsID = 6;
            AAMod.ReturnDate = Convert.ToDateTime(KeepDate);
            AAMod.ReturnRemark += KeepRemark;
            bool result = new BLL.ApplyArticleBLL().Update(AAMod);
            

            StringBuilder sb = new StringBuilder();
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