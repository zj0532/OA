using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace OASys.UserManager
{
    public partial class ModifyPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtNpwd.Text != txtTNpwd.Text)
            {
                Page.RegisterStartupScript("Message", "<script>alert('新密码与确认新密码输入不符')</script>");
                return;
            }
            Regex RegexPassword = new Regex("^(?![a-zA-Z0-9]+$)(?![^a-zA-Z/D]+$)(?![^0-9/D]+$).{6,12}$");
            MDL.UserInfoMOD UserMod = new BLL.UserInfoBLL().GetModel(int.Parse(Session["UsID"].ToString()));

            if (BLL.StringHelper.Encrypt(txtYpwd.Text) == UserMod.UsPwd && RegexPassword.IsMatch(txtNpwd.Text))
            {
                bool result = new BLL.UserInfoBLL().UpdatePwd(BLL.StringHelper.Encrypt(txtNpwd.Text), int.Parse(Session["UsID"].ToString()));
                if (result)
                {
                    Page.RegisterStartupScript("Message", "<script>alert('修改完成,请点击确定后重新登录');window.parent.parent.location.href='../../login.aspx'</script>");
                   
                }
                else
                {
                    Page.RegisterStartupScript("Message", "<script>alert('修改失败')</script>");
                }
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>alert('原密码输入错误')</script>");
            }



        }
    }
}