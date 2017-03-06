using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.HrManager
{
    public partial class NewEmployeeKnowAdd : System.Web.UI.Page
    {
        int NeID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
            if(!IsPostBack)
            { 
                NeID =int .Parse(Request.QueryString["NeID"].ToString());
                if (NeID != 0)
                {
                    MDL.NewEmplyeeKnowMOD NeMod = new BLL.NewEmplyeeKnowBLL().GetModel(NeID);
                    txtTitle.Text = NeMod.Title;
                    txtDate.Value = NeMod.Date.ToString();
                    txtUsname.Value = new BLL.UserInfoBLL().GetModel(NeMod.UsID).UsName;
                    txtRemark.Value = NeMod.Remark;
                    if (NeMod.BusinessID == 3)
                    {
                        CheckBox1.Checked = true;
                    }
                    Editor1.Text = NeMod.NeContent;
                }
                else
                {
                    txtUsname.Value = new BLL.UserInfoBLL().GetModel(Convert .ToInt32(Session["Usid"])).UsName;
                    txtDate.Value = DateTime.Now.ToString();
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MDL.NewEmplyeeKnowMOD NeMod = new MDL.NewEmplyeeKnowMOD();
            NeID = int.Parse(Request.QueryString["NeID"].ToString());
            int result = 0;
            NeMod.Title = txtTitle.Text.ToString();
            NeMod.Date = DateTime.Now;
            NeMod.Remark = txtRemark.Value;
            NeMod.NeContent = Editor1.Text;
            NeMod.UsID = Convert.ToInt32(Session["UsID"]);
            if (CheckBox1.Checked==true)
            {
                NeMod.BusinessID = 3;
            }
            else
            {
                NeMod.BusinessID = Convert.ToInt32(Session["BusID"]);
            
            }

            if (NeID != 0)
            {
                NeMod.NeID = NeID;
                result = new BLL.NewEmplyeeKnowBLL().Update(NeMod) == true ? 1 : 0;
            }
            else
            {
                result = new BLL.NewEmplyeeKnowBLL().Add(NeMod);
            }

            if (result > 0)
            {
                RegisterStartupScript("Message", "<script>alert('添加/更新成功，点击确定返回列表');document.location='NewEmployeeKnowGroup.aspx'</script>");
                
            }
            else
            {
                RegisterStartupScript("Message", "<script>alert('添加/更新失败，失败任务编号："+result+"')</script>");
            }

        }
    }
}