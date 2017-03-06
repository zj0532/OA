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
    /// GetStoreHouseListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetStoreHouseListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int Page = int.Parse(context.Request["page"]);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.StoreHouseBLL().GetList(15, Page," ShID ", "").Tables[0];

            string ShopClass = "";
            string StoreStatus = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShopClass = new BLL.ShopClassBLL().GetModel(Convert .ToInt32(dt.Rows[i]["shopclassid"])).ShopClassName;
                    StoreStatus = new BLL.StoreStatusBLL().GetModel(Convert.ToInt32(dt.Rows[i]["stid"])).StName;
                    sb.Append(" {\"ShopName\":\"" + dt.Rows[i]["shopname"] + "\",\"Number\":\"" + dt.Rows[i]["shopAmount"] + "\",\"Unit\":\"" + dt.Rows[i]["unit"] + "\",\"ShopClass\":\"" + ShopClass + "\",\"ShopStatus\":\"" + StoreStatus + "\",\"ShID\":\"" + dt.Rows[i]["shid"] + "\"} ");

                    if (i != dt.Rows.Count - 1)
                    {
                        sb.Append(" , ");
                    }


                }
                sb.Append(" ]} ");

            }
            else
            {
                sb.Append(" {\"total\":0,\"rows\":[ ");
                sb.Append(" ]} ");

            }

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