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
    /// GetShopNameByClassIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetShopNameByClassIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string ClassID=context.Request["ClassID"];
            DataTable dt = new BLL.StoreHouseBLL().GetList("ShopClassID='" + ClassID + "'").Tables[0];
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sb.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("{ \"Value\":\"" + dt.Rows[i]["shid"] + "\",\"Text\":\""+dt.Rows[i]["shopName"]+"\"}");
                   
                    if (i != dt.Rows.Count - 1)
                    {
                        sb.Append(" , ");
                    }


                }
                sb.Append(" ] ");

            }
            else
            {

                sb.Append("[\"Value\":\"0\",\"Text\":\"无任何物品\"}] ");

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