using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.FileManager
{
    public partial class AddReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            if(!IsPostBack)
            {
              dplFileClass.DataSource = new BLL.FileClassExplicitBLL().GetList("FCID='1'").Tables[0];
              dplFileClass.DataTextField="FCEName";
              dplFileClass.DataValueField="FCEID";
              dplFileClass.DataBind ();

              txtUsName.Value=Session["UsName"].ToString ();
              txtDate.Value=DateTime.Now.ToString ();
              txtBusiness.Value=new BLL.BusinessBLL().GetModel(int.Parse( Session["BusID"].ToString ())).BusinessName;


            }
        }

      

        protected void bthAddFile_Click(object sender, EventArgs e)
        {
            DateTime BeginDate=new DateTime();
            DateTime EndDate = new DateTime();
            string FilePath;
            try
            {
                BeginDate = Convert.ToDateTime(beginDate.Value.Trim());
                EndDate = Convert.ToDateTime(endDate.Value.Trim());
            }
            catch
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','开始日期或结束日期错误，请重新选择!','error');</script>");
                beginDate.Value = "";
                endDate.Value = "";
            }

            if (FileUpLoad1.FileName == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议纪要文档路径错误，请重新选择！','error');</script>");
                return;
            }


            FilePath = FileUpLoad1.FileName;
           
            Stream objFs;
            objFs = FileUpLoad1.PostedFile.InputStream;
            BinaryReader objBr = new BinaryReader(objFs);
            byte[] content = objBr.ReadBytes((int)objFs.Length);

            MDL.FileManagerMOD FmMod = new MDL.FileManagerMOD();
            FmMod.FileName = BeginDate.ToString("yyyy-MM-dd") + "至" + EndDate.ToString("yyyy-MM-dd") + "_" +  dplFileClass.SelectedItem.Text;
            FmMod.FileCode = content;
            FmMod.FileDate = Convert.ToDateTime(txtDate.Value);
            FmMod.UsID = Convert .ToInt32 (Session["UsID"]);
            FmMod.FCEID = Convert.ToInt32(dplFileClass.SelectedValue);
            FmMod.FileContent = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1);
            FmMod.FCID = 1;

            int result = new BLL.FileManagerBLL().Add(FmMod);

            if (result > 0)
            {
                Page.RegisterStartupScript("Message", "<script>window.location='WeeklyReportList.aspx?BusID=" + Session["BusID"].ToString() + "'</script>");
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','请重新添加!','error');</script>");
            }

        }


    }
}