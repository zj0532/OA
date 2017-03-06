using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.FileManager
{
    public partial class MeetShow : System.Web.UI.Page
    {
        int MsID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            MsID = Convert.ToInt32(Request.QueryString["MsID"]);
            if(!IsPostBack)
            {
                this.GetMeetSummary();
                this.getMeetSupply();
            }
            

        }

        private void getMeetSupply()
        {
            repList.DataSource = new BLL.MeetingSupplyBLL().GetList("MsID='"+MsID+"' order by Date ").Tables[0];
            repList.DataBind();

        }


        private void GetMeetSummary()
        {
            MDL.MeetingSummaryMOD MsMod = new BLL.MeetingSummaryBLL().GetModel(MsID);
            labTitle.InnerText = MsMod.MSTitle;
            labDate.Text = MsMod.MSDate.ToString("yyyy-MM-dd HH:mm:ss");
            labAddress.Text = MsMod.MSAddress;
            labCompere.Text = MsMod.Compere;
            labJoiner.Text = MsMod.Joiner;
            labUsName.Text = new BLL.UserInfoBLL().GetModel(MsMod.UsID).UsName;
            labContent.Text = MsMod.MSContent;


        }

        protected void bthCanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeetSummary.aspx");
        }

        protected void bthAdd_Click(object sender, EventArgs e)
        {
            MDL.MeetingSupplyMOD MsuMod = new MDL.MeetingSupplyMOD();
            MsuMod.MSID = MsID;
            MsuMod.UsID =Convert .ToInt32( Session["UsID"]);
            MsuMod.Date = DateTime.Now;
            MsuMod.SuContent = Editor1.Text;

            int result = new BLL.MeetingSupplyBLL().Add(MsuMod);
            if (result > 0)
            {
                Response.Redirect("MeetShow.aspx?MsID="+MsID);
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','任务反馈失败，请重新添加，如果继续失败请与管理员联系！','error');</script>");
            }

        }

    }
}