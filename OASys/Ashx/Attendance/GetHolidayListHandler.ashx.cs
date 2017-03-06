﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using System.Runtime.Serialization;

using System.Web.Services;
using System.Data;

namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// GetHolidayListHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetHolidayListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            DataTable dt = null; //0查询    >0:分页
            int Page = int.Parse(context.Request["page"]);
            if (Page > 0)
            {
                dt = new BLL.UserInfoBLL().GetList(15, Page, "businessid,jobid,usid", "stauts='在职'").Tables[0];

            }
            else
            {
                
                string SearchKey = context.Request["KeyStr"];
                dt = new BLL.UserInfoBLL().GetCountList("( Usname like '%" + SearchKey + "%' or Phone like '%" + SearchKey + "%' or email like '%" + SearchKey + "%') and stauts='在职' ").Tables[0];


            }
            if (dt.Rows.Count > 0)
            {
                sb.Append(" {\"total\":" + dt.Rows[0]["total"].ToString() + ",\"rows\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append(" {\"productid\":\"" + new BLL.JobBLL().GetModel(int.Parse(dt.Rows[i]["jobid"].ToString())).JobName + "\",\"usid\":\"" + dt.Rows[i]["usid"].ToString() + "\",\"office\":\"" + dt.Rows[i]["Office"].ToString() + "\",\"tiaoxiu\":\"" + dt.Rows[i]["tiaoxiu"].ToString() + "\",\"modify\":\"<a class='a1' onclick='ModifyHoliday(" + dt.Rows[i]["UsID"].ToString() + ")'>修改</a>\",\"listprice\":\"" + new BLL.BusinessBLL().GetModel(int.Parse(dt.Rows[i]["businessid"].ToString())).BusinessName + "\",\"nianjia\":\"" + dt.Rows[i]["nianjia"].ToString() + "\",\"itemid\":\"" + dt.Rows[i]["usname"].ToString() + "\"} ");

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