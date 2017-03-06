using System;
using System.Web.UI;
using System.Data;
using System.Text.RegularExpressions;

namespace OASys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }


        protected void UserLogin(object sender, ImageClickEventArgs e)
        {
            //string inputCode = txtCode.Value.Trim().ToUpper();
            //string NoinptCode = OASys.Control.GetViCode1.code.ToUpper();

            //if (inputCode == NoinptCode)
            //{

            string UsName = RemoveHTMLTags(txtName.Value.Trim());
            string UsPwd = txtPwd.Value.Trim();
            string md = BLL.StringHelper.Encrypt(UsPwd);

            // 验证码失效重新加载
            if (Session["VerifyCode"] == null)
            {
                Page.RegisterStartupScript("Message", "<script>alert('验证码过期!')</script>");
                tVerifyCode.Value = "";
                //txtCode.Value = "";
                tVerifyCode.Focus();
                return;
            }

            // 验证用户输入的验证码
            if (UsName == "周杰" || UsName == "许鲁" || UsName == "姜苏" || UsName == "吕伟" || UsName == "郭玉健" ||
                UsName == "王元强" || UsName == "朱方龙" || UsName == "姜述伟" || UsName == "董萌萌" ||
                UsName == "孙燕" || UsName == "于海洋" || UsName == "梁帅")
            {

            }
           else
            {
                if (Session["VerifyCode"].ToString() != tVerifyCode.Value)
                {
                    Page.RegisterStartupScript("Message", "<script>alert('验证码不正确!')</script>");
                    tVerifyCode.Value = "";
                    //txtCode.Value = "";
                    tVerifyCode.Focus();
                    return;
                }
            }
                DataTable dt = new BLL.UserInfoBLL().GetList("UsName='" + UsName + "'and stauts='在职' ").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dt = new BLL.UserInfoBLL().GetList("UsName='" + UsName + "' and UsPwd='" + BLL.StringHelper.Encrypt(UsPwd) + "' and stauts='在职'  ").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Session["UsID"] = dt.Rows[0]["UsID"].ToString ();
                        Session["JobID"] = dt.Rows[0]["JobID"].ToString();
                        Session["BusID"] = dt.Rows[0]["BusinessID"].ToString();
                        Session["UsName"] = dt.Rows[0]["UsName"].ToString();
                        Session["WordGroupID"] = dt.Rows[0]["WrodGroupID"].ToString();
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Page.RegisterStartupScript("Message", "<script>alert('密码错误,请重新输入!')</script>");
                        txtPwd.Value = "";
                        //txtCode.Value = "";
                        txtPwd.Focus();
                    }

                }
                else
                {
                    Page.RegisterStartupScript("Message", "<script>alert('用户名错误,请重新输入!')</script>");
                    txtName.Value = "";
                    txtPwd.Value = "";
                    //txtCode.Value = "";
                    txtName.Focus();
                        
                }

            //}
            //else
            //{
            //    txtCode.Value = "";

            //    Page.RegisterStartupScript("Message", "<script>alert('验证码错误，请重新登陆')</script>");

            //}


        }

        /// <summary>
        /// 过滤非法字符
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string RemoveHTMLTags(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"[a-zA-Z]", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"=", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"'", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");

            return Htmlstring;
        }
    } 
}