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
    /// GetSearchEnterHouseRecodHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetSearchEnterHouseRecodHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string ShName = context.Request["ShopName"];
            string ShopClass = context.Request["ShopClass"];
            string BeginDate = context.Request["BeginDate"];
            string EndDate = context.Request["EndDate"];
            string sqlWhere = "1=1";

            if (ShName.Trim() != "")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopName like '%"+ShName+"%' ) ";
            }

            if (ShopClass != "0")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopClassID='"+ShopClass+"'  ) ";
            }

            if (BeginDate.Trim() != "")
            {
                sqlWhere += " and pidate >='"+BeginDate+"' ";
            }

            if (EndDate.Trim() != "")
            {
                sqlWhere += " and pidate <='" + EndDate + "' ";
            }

            sqlWhere += " order by pidate desc ";

            DataTable dt = new BLL.PutInStoreBLL().GetList(sqlWhere).Tables[0];

            string ShopName = "";
            string Unit = "";
            string UsName = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows.Count + ",\"rows\":[ ");
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