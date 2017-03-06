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
    /// AddApplyHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddApplyHandler : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string Shopid = context.Request["ShopID"];
            string Number = context.Request["Number"];
            string ReturnDate = context.Request["ReturnDate"];
            string ShopClassid = context.Request["ShopClassID"];
            string Remark = context.Request["Remark"];
            int UserID = Convert.ToInt32(context.Session["UsID"]);

            MDL.ApplyArticleMOD AAMod = new MDL.ApplyArticleMOD();
            AAMod.ShID = Convert.ToInt32(Shopid);
            AAMod.Number = Convert.ToInt32(Number);
            AAMod.AADate = DateTime.Now;
            AAMod.ReturnDate = Convert.ToDateTime(ReturnDate);
            AAMod.UsID = UserID;
            AAMod.AsID = 1;
            AAMod.Remark = Remark;

            int result = new BLL.ApplyArticleBLL().Add(AAMod);
            string ErrorMessage = "";
            if (result > 0)
            {
                
            }
            else
            {
                ErrorMessage = "申请失败，请与管理员联系！";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[{\"Result\":\"" + ErrorMessage + "\"}]");
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