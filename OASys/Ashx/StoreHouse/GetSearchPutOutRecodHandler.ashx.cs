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
    /// GetSearchPutOutRecodHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetSearchPutOutRecodHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string ShName = context.Request["ShopName"];
            string ShClass = context.Request["ShopClass"];
            string Usname = context.Request["UsName"];
            string BeginDate = context.Request["BeginDate"];
            string EndDate = context.Request["EndDate"];
            string sqlWhere = "1=1";

            if (ShName.Trim() != "")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopName like '%" + ShName + "%' ) ";
            }

            if (ShClass != "0")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopClassID='" + ShClass + "'  ) ";
            }

            if (Usname != "")
            {
                sqlWhere += " and usid in ( select UsID from tbUserInfo where usname='"+Usname+"' ) ";
            }

            if (BeginDate.Trim() != "")
            {
                sqlWhere += " and aadate >='" + BeginDate + "' ";
            }

            if (EndDate.Trim() != "")
            {
                sqlWhere += " and aadate <='" + EndDate + "' ";
            }

            sqlWhere += " and AsID>3 order by aadate desc ";

            DataTable dt = new BLL.ApplyArticleBLL().GetList(sqlWhere).Tables[0];

            string UsName = "";
            string ApplyStatus = "";
            string Unit = "";
            string ShopClass = "";
            string ShopName = "";
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows.Count + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UsName = new BLL.UserInfoBLL().GetModel(Convert.ToInt32(dt.Rows[i]["usid"])).UsName;
                    ApplyStatus = new BLL.ApplyStatusBLL().GetModel(Convert.ToInt32(dt.Rows[i]["asid"])).AsName;
                    Unit = new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(dt.Rows[i]["shid"])).Unit;
                    ShopClass = new BLL.ShopClassBLL().GetModel(new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(dt.Rows[i]["shid"])).ShopClassID).ShopClassName;
                    ShopName = new BLL.StoreHouseBLL().GetModel(Convert.ToInt32(dt.Rows[i]["shid"])).ShopName;
                    sb.Append(" {\"ShopName\":\"" + ShopName + "\",\"Number\":\"" + dt.Rows[i]["number"] + "\",\"Unit\":\"" + Unit + "\",\"ShopClass\":\"" + ShopClass + "\",\"ApplyDate\":\"" + Convert.ToDateTime(dt.Rows[i]["AAdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"ReturnDate\":\"" + Convert.ToDateTime(dt.Rows[i]["ReturnDate"]).ToString("yyyy-MM-dd HH:mm:ss") + "\",\"UsName\":\"" + UsName + "\",\"ShopStatus\":\"" + ApplyStatus + "\",\"AAID\":\"" + dt.Rows[i]["aaid"] + "\",\"ShID\":\"" + dt.Rows[i]["shid"] + "\"} ");

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