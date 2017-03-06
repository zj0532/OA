using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.FileManager
{
    public partial class AddStandard : System.Web.UI.Page
    {

        public string PageStaute;
        private int FileID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            FileID = int.Parse(Request.QueryString["Fid"].ToString());
            PageStaute = FileID == 0 ? "添加" : "修改";
            if (!IsPostBack)
            {
                this.getDatabind();
                if (FileID != 0)
                {
                    this.UpdSetData();
                }
                else
                {
                    this.AddSetData();
                }
            }
        }

        private void AddSetData()
        {
            txtDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtUsName.Value = new BLL.UserInfoBLL().GetModel(Convert .ToInt32(Session["UsID"])).UsName;
        }
        private void UpdSetData()
        {
            MDL.FileManagerMOD FmMod=new BLL.FileManagerBLL().GetModel(FileID);
            txtTitle.Value = FmMod.FileName;
            txtDate.Value = FmMod.FileDate.ToString("yyyy-MM-dd HH:mm:ss");
            dplBusiness.SelectedValue = FmMod.FCEID.ToString();
            txtUsName.Value = new BLL.UserInfoBLL().GetModel(FmMod.UsID).UsName;
            Editor1.Text = FmMod.FileContent;
        }

        private void getDatabind()
        {
            dplBusiness.DataSource = new BLL.FileClassExplicitBLL().GetList(" FCID=5 order by FCEID ").Tables[0];
            dplBusiness.DataTextField = "FCEName";
            dplBusiness.DataValueField = "FCEID";
            dplBusiness.DataBind();

        }

        protected void bthSumbit_Click(object sender, EventArgs e)
        {
            if (txtTitle.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','制度规范标题不能为空！','error');</script>");
                return;
            }
            MDL.FileManagerMOD FmMOD = new MDL.FileManagerMOD();
            FmMOD.FileName = txtTitle.Value;
            FmMOD.FileDate = Convert.ToDateTime(txtDate.Value);
            FmMOD.UsID = Convert.ToInt32(Session["UsID"]);
            FmMOD.FCEID = Convert.ToInt32(dplBusiness.SelectedValue);
            FmMOD.FCID = 5;
            FmMOD.FileContent = Editor1.Text;
            
            int result = 0;
            if (FileID == 0)
            {
                
                result = new BLL.FileManagerBLL().Add(FmMOD);
            }
            else
            {
                FmMOD.FlID = FileID;
                result = new BLL.FileManagerBLL().Update(FmMOD)==true?1:0;
            }

            if (result > 0)
            {
                Response.Redirect("Standard.aspx");
               
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('任务失败','任务失败，请重新操作，如果继续失败请于管理员联系！','error');</script>");
            }

        }

        protected void bthCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Standard.aspx");
        }
    }
}