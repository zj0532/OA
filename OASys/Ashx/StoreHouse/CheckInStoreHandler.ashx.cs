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
    /// CheckInStoreHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CheckInStoreHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int UserID = Convert.ToInt32(context.Session["UsID"]);
            string shid = context.Request["ShID"];
            string number = context.Request["Number"];
            string ErrorMessage = "";
            //入库表单
            MDL.PutInStoreMOD PisMod = new MDL.PutInStoreMOD();
            PisMod.ShID = Convert.ToInt32(shid);
            PisMod.PiAmount = Convert.ToInt32(number);
            PisMod.PiDate = DateTime.Now;
            PisMod.PiUsID = UserID;

            int result = new BLL.PutInStoreBLL().Add(PisMod);
            MDL.StoreHouseMOD ShMod = new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(shid));
            bool res = false;
            if (result > 0)
            {
                ShMod.ShopAmount = ShMod.ShopAmount + PisMod.PiAmount;
                res = new BLL.StoreHouseBLL().Update(ShMod);
                if (!res)
                {
                    new BLL.PutInStoreBLL().Delete(result);
                    ErrorMessage = "物品入库失败，请检查网络！";
                }
            }
            else
            {
                ErrorMessage = "物品入库失败，请检查网络！";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[{ \"Message\":\"" + ErrorMessage + "\"}]");
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