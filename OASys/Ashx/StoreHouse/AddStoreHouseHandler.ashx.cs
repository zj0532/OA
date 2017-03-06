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
    /// AddStoreHouseHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddStoreHouseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int UserID = Convert.ToInt32(context.Session["UsID"]);
            string name = context.Request["ShName"];
            string unit = context.Request["ShUnit"];
            string shclass = context.Request["ShClass"];
            string bus = context.Request["ShBus"];
            string remark = context.Request["Remark"];
            string shorestauts="";
            if(shclass=="1")
            {
             shorestauts="1";
            }
            else
            {
             shorestauts="2";
            }

            MDL.StoreHouseMOD ShMod = new MDL.StoreHouseMOD();
            ShMod.ShopName = name;
            ShMod.ShopClassID = Convert.ToInt32(shclass);
            ShMod.Supplier = bus;
            ShMod.Unit = unit;
            ShMod.Describe = remark;
            ShMod.StID = Convert.ToInt32(shorestauts);
            ShMod.ShopAmount = 0;
            StringBuilder sb = new StringBuilder();
            int result = new BLL.StoreHouseBLL().Add(ShMod);
            string ErrorMessage = "";
            if (result > 0)
            {
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "添加物品发生失败，请于管理员联系";
            }

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