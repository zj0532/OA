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
    /// GetPutInRecodHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPutInRecodHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int Page = int.Parse(context.Request["page"]);
            StringBuilder sb = new StringBuilder();
            DataTable dt = new BLL.PutInStoreBLL().GetList(15, Page, " PiDate desc ", "").Tables[0];

            string ShopName = "";
            string Unit = "";
            string UsName = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShopName = new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(dt.Rows[i]["ShID"])).ShopName;
                    Unit = new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(dt.Rows[i]["ShID"])).Unit;
                    UsName = new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["PiUsID"])).UsName;
                    sb.Append(" {\"ShopName\":\"" + ShopName + "\",\"Number\":\"" + dt.Rows[i]["PiAmount"] + "\",\"Unit\":\"" + Unit + "\",\"PiDate\":\"" + Convert.ToDateTime(dt.Rows[i]["PiDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"UsName\":\"" + UsName + "\",\"ShID\":\"" + dt.Rows[i]["shid"] + "\",\"PiID\":\"" + dt.Rows[i]["PiID"] + "\"} ");

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