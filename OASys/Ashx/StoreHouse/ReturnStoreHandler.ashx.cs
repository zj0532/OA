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
    /// ReturnStoreHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ReturnStoreHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Aaid = context.Request["AAid"];
           
            
            MDL.ApplyArticleMOD AAMod = new BLL.ApplyArticleBLL().GetModel(Convert.ToInt32(Aaid));
            


            AAMod.AsID = 7;
            bool result = new BLL.ApplyArticleBLL().Update(AAMod);
            MDL.StoreHouseMOD ShMod = new MDL.StoreHouseMOD();
            if (result)
            {
                ShMod = new BLL.StoreHouseBLL().GetModel(AAMod.ShID);
                ShMod.ShopAmount = ShMod.ShopAmount + AAMod.Number;
                
                new BLL.StoreHouseBLL().Update(ShMod);

            }

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