using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.Notice
{
    public partial class AddNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
            if (!new BLL.PageSettingBLL().ExistsAuthority(Convert.ToInt32(Session["UsID"]), "添加通知"))
            {
                Page.RegisterStartupScript("Message", "<script> document.getElementById('DivButton').style.display='none'</script>");
            }

            if (!IsPostBack)
            {
                this.GetDate();
            }
            
        }

        private void GetDate()
        {
            ddpWordGroup.DataSource = new BLL.WordGroupBLL().GetList("").Tables[0];
            ddpWordGroup.DataTextField = "WordGroupName";
            ddpWordGroup.DataValueField = "WordGroupID";
            ddpWordGroup.DataBind();
            ddpWordGroup.Items.Insert(0, new ListItem("请选择区域", "0"));


            ddpBus.DataSource = new BLL.BusinessBLL().GetList(" businessid<>3 ").Tables[0];
            ddpBus.DataTextField = "BusinessName";
            ddpBus.DataValueField = "BusinessID";
            ddpBus.DataBind();
            ddpBus.Items.Insert(0, new ListItem("请选择业务组", "0"));
        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            if (txtTitle.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','标题不能为空！','error');</script>");
                return;
            }

            if (BeginDate.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','有效期开始时间不能为空！','error');</script>");
                return;
            }

            if (EndDate.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','有效期开始时间不能为空！','error');</script>");
                return;
            }

            MDL.NoticeMOD NtMod = new MDL.NoticeMOD();
            NtMod.Title = txtTitle.Value;
            NtMod.NoContent = Editor1.Text;
            NtMod.Date = DateTime.Now;
            try
            {
                NtMod.EffectDateBefore = Convert.ToDateTime(BeginDate.Value);
                NtMod.EffectDateEnd = Convert.ToDateTime(EndDate.Value);
            }
            catch
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','有效期开始时间、有效期结束时间日期类型不正确，请重新选择！','error');</script>");
                return;
            }

            NtMod.UsID = Convert.ToInt32(Session["UsID"]);
            if (Rb1.Checked == true)
            {
                NtMod.NoticeClass = 0;
                NtMod.ClassValue = "0";
            }
            if (Rb2.Checked == true)
            {
                NtMod.NoticeClass = 1;
                NtMod.ClassValue = ddpWordGroup.SelectedValue.ToString();
            }
            if (Rb3.Checked == true)
            {
                NtMod.NoticeClass = 2;
                NtMod.ClassValue = ddpBus.SelectedValue.ToString();
            }

            if (FileUpload1.FileName.Trim() != "")
            {
                string FilePath = FileUpload1.FileName;
                Stream objFs;
                objFs = FileUpload1.PostedFile.InputStream;
                BinaryReader objBr = new BinaryReader(objFs);
                byte[] content = objBr.ReadBytes((int)objFs.Length);

                NtMod.FileName = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1); ;
                NtMod.FileContent = content;

            }


            int result = new BLL.NoticeBLL().Add(NtMod);
            if (result > 0)
            {
                txtTitle.Value = "";
                BeginDate.Value = "";
                EndDate.Value = "";
                Editor1.Text = "";
                FileUpload1.Dispose();
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('成功','添加作业计划成功！','info');</script>");

            }
            else
            {

                Page.RegisterStartupScript("Message", "<script>$.messager.alert('失败','添加作业计划失败,请重新添加！','error');</script>");

            }

        }



    }
}