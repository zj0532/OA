using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.FileManager
{
    public partial class AddTechnical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            if (!IsPostBack)
            {
                dplFileClass.DataSource = new BLL.FileClassExplicitBLL().GetList("FCID='2'").Tables[0];
                dplFileClass.DataTextField = "FCEName";
                dplFileClass.DataValueField = "FCEID";
                dplFileClass.DataBind();

                txtUsName.Value = Session["UsName"].ToString();
                txtDate.Value = DateTime.Now.ToString();
                txtBusiness.Value = new BLL.BusinessBLL().GetModel(int.Parse(Session["BusID"].ToString())).BusinessName;
            }
        }


        protected void bthAddFile_Click1(object sender, EventArgs e)
        {
            MDL.FileManagerMOD FmMod = new MDL.FileManagerMOD();

            if (txtTitle.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','文件标题不能为空!','error');</script>");
                return;
            }

            string FilePath = FileUpLoad1.FileName;

            if (FilePath.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','文件路径错误请重新选择！','error');</script>");
                return;
            }

            FmMod.FileName = txtTitle.Value;
            FmMod.FCEID = int.Parse(dplFileClass.SelectedValue);
            FmMod.FCID = 2;

            Stream objFs;
            objFs = FileUpLoad1.PostedFile.InputStream;
            BinaryReader objBr = new BinaryReader(objFs);
            byte[] content = objBr.ReadBytes((int)objFs.Length);

            FmMod.FileCode = content;
            FmMod.FileDate = Convert.ToDateTime(txtDate.Value);
            FmMod.UsID = Convert.ToInt32(Session["UsID"]);
            FmMod.FileContent = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1);

            int result = new BLL.FileManagerBLL().Add(FmMod);

            if (result > 0)
            {
                txtTitle.Value = "";

                Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加文件','添加成功！');</script>");
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','请重新添加!','error');</script>");
            }


        }

    }
}