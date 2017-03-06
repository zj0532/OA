using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace OASys
{
    public partial class Index : System.Web.UI.Page
    {
        public string Menu;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Menu = new BLL.PageSettingBLL().GetMenu(Convert.ToInt32(Session["UsID"].ToString()));
                this.GetDesktopData();
            
            }
            //测试将ID=45的员工赋予Session
            //Session["UsID"] = 39;
            //Session["JobID"] = 5;
            //Session["BusID"] = 7;
            //Session["UsName"] = "Test01";
            //Session["WordGroupID"] = 1;
           
        }

        private void GetDesktopData()
        {
            RepAttendance.DataSource = new BLL.AttendanceBLL().GetList("Usid='" + Session["UsID"] + "'and  atid in (select top 8 atid from tbattendance where usid='" + Session["UsID"] + "' order by convert(datetime, postdate) desc) order by convert(datetime, postdate) desc  ").Tables[0];
            RepAttendance.DataBind();

            WorkPlanRep.DataSource = new BLL.WorkPlanBLL().GetList(" wpid in ( select top 8 wpid from tbWorkPlan where Usid='" + Session["UsID"] + "' and begindate<='" + DateTime.Now + "' and enddate>='" + DateTime.Now + "' order by begindate ) order by  begindate").Tables[0];
            WorkPlanRep.DataBind();

            RepDutyTable.DataSource = new BLL.KeepWatchBLL().GetList(" begindate <=getdate() and enddate>=getdate() order by convert(datetime,date) desc ").Tables[0];
            RepDutyTable.DataBind();

            RepNoticeList.DataSource = GetNoticeByUsID();
            RepNoticeList.DataBind();


        }

        private DataTable  GetNoticeByUsID()
        {
            int UsID = Convert.ToInt32(Session["UsID"]);
            int JobID = Convert.ToInt32(Session["JobID"]);
            int BusID = Convert.ToInt32(Session["BusID"]);

            string sqlWhere = "1=1";
            if (JobID == 2)
            {
                sqlWhere += " and (noticeclass='0' or (noticeclass='1' and classValue='" + new BLL.UserInfoBLL().GetModel(UsID).WrodGroupID + "') or noticeclass='2') ";
            }
            if (JobID >= 3)
            {
                sqlWhere += " and (noticeclass='0' or (noticeclass='1' and classValue='" + new BLL.UserInfoBLL().GetModel(UsID).WrodGroupID + "') or (noticeclass='2' and classValue='" + new BLL.UserInfoBLL().GetModel(UsID).BusinessID + "')) ";
            }

            sqlWhere += " and EffectDateBefore<='" + DateTime.Now + "' and EffectDateEnd>='"+DateTime.Now+"' ";

            DataTable dt = new BLL.NoticeBLL().GetList(8, 1, " convert(datetime,date) desc ", sqlWhere).Tables[0];
            return dt;
 
        }

    }
}