using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

namespace OASys.Ashx
{
    /// <summary>
    /// AddUserHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddUserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder str = new StringBuilder();
            MDL.UserInfoMOD UserMod = new MDL.UserInfoMOD();
            string PageID = context.Request["PageID"].ToString();  // 0添加  1更新  2读取 3删除

            if (PageID == "0" || PageID == "1")
            {
                UserMod.UsID = int.Parse(context.Request["UserID"].ToString());
                UserMod.UsName = context.Request["UserName"].ToString();
                if (PageID == "0")
                {
                    UserMod.UsPwd = BLL.StringHelper.Encrypt("Uni@com.789");
                }
                else
                {
                    UserMod.UsPwd = new BLL.UserInfoBLL().GetModel(UserMod.UsID).UsPwd;

                }
                UserMod.Phone = context.Request["Phone"].ToString();
                UserMod.Email = context.Request["Email"].ToString();
                UserMod.JobID = int.Parse(context.Request["jobid"].ToString());
                UserMod.BusinessID = int.Parse(context.Request["BusinessID"].ToString());
                UserMod.Stauts = context.Request["stauts"].ToString();
                UserMod.ServerStyleID = int.Parse(context.Request["ServerStyleID"].ToString());
                UserMod.BeComany = context.Request["Comany"].ToString();
                UserMod.Office = context.Request["Office"].ToString();
                UserMod.EntryDate = context.Request["EmptyDate"];
                UserMod.EntryCause = context.Request["EmptyCause"].ToString();
                UserMod.DimissionDate = context.Request["EmptyOutDate"].ToString() ;
                UserMod.EmptyOne = context.Request["WorkContent"].ToString();
                UserMod.WrodGroupID = int.Parse(context.Request["QY"].ToString());
                UserMod.EmptyTwo = context.Request["Duty"].ToString();
                UserMod.MorTime = context.Request["CommUp"].ToString().Trim();
                UserMod.NightTime = context.Request["CommDown"].ToString().Trim();
                UserMod.SaturdayMorTime = context.Request["SatUp"].ToString().Trim();
                UserMod.SaturdayNightTime = context.Request["SatDown"].ToString().Trim();

                int result = 0;

                if (UserMod.UsID > 0)
                {
                    
                    result = new BLL.UserInfoBLL().Update(UserMod)==true?1:0;
                }
                else
                {
                    result = new BLL.UserInfoBLL().Add(UserMod);
                }

                if (result > 0)
                {
                    str.Append("[{\"result\":\"1\"}]");
                }
                else
                {
                    str.Append("[{\"result\":\"0\"}]");
                }
            }
            else
            {

                if (PageID == "2")
                {
                    UserMod.UsID = int.Parse(context.Request["UserID"].ToString());
                    UserMod = new BLL.UserInfoBLL().GetModel(UserMod.UsID);
                    str.Append("[{");
                    str.Append(" \"usid\":\"" + UserMod.UsID + "\" ,");
                    str.Append(" \"usname\":\"" + UserMod.UsName + "\" ,");
                    str.Append(" \"phone\":\"" + UserMod.Phone + "\" ,");
                    str.Append(" \"email\":\"" + UserMod.Email + "\" ,");
                    str.Append(" \"jobid\":\"" + UserMod.JobID + "\" ,");
                    str.Append(" \"businessid\":\"" + UserMod.BusinessID + "\" ,");
                    str.Append(" \"stauts\":\"" + UserMod.Stauts + "\" ,");
                    str.Append(" \"serverstyleid\":\"" + UserMod.ServerStyleID + "\" ,");
                    str.Append(" \"becomany\":\"" + UserMod.BeComany + "\" ,");
                    str.Append(" \"office\":\"" + UserMod.Office + "\" ,");
                    str.Append(" \"entrydate\":\"" + UserMod.EntryDate + "\" ,");
                    str.Append(" \"entrycause\":\"" + UserMod.EntryCause + "\" ,");
                    str.Append(" \"dimissiondate\":\"" + UserMod.DimissionDate + "\" ,");
                    str.Append(" \"emptyone\":\"" + UserMod.EmptyOne + "\" ,");
                    str.Append(" \"emptytwo\":\"" + UserMod.EmptyTwo + "\" ,");
                    str.Append(" \"CommUp\":\"" + UserMod.MorTime + "\" ,");
                    str.Append(" \"CommDown\":\"" + UserMod.NightTime + "\" ,");
                    str.Append(" \"SatUp\":\"" + UserMod.SaturdayMorTime + "\" ,");
                    str.Append(" \"SatDown\":\"" + UserMod.SaturdayNightTime + "\" ");
                    str.Append("}]");
                }
                else
                {
                    bool result = new BLL.UserInfoBLL().Delete(int.Parse(context.Request["UserID"].ToString()));
                    if (result)
                    {
                        str.Append("[{\"result\":\"1\"}]");
                    }
                    else
                    {
                        str.Append("[{\"result\":\"0\"}]");
                    }
                
                }
            }
            context.Response.Write(str.ToString());
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