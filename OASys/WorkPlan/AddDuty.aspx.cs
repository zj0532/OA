using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.WorkPlan
{
    public partial class AddDuty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           

            txtBusiness.Value = new BLL.BusinessBLL().GetModel(Convert.ToInt32(Session["BusID"])).BusinessName;
        }

        protected void bthCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DutyTable.aspx");
        }

        protected void bthOK_Click(object sender, EventArgs e)
        {
            if (txtTitle.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','标题不能为空！','error');</script>");
                return;
            }
            if (BeginDate.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','开始时间不能为空！','error');</script>");
                return;
            }
            if (FileUpload1.FileName.Trim () == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','上传文档不能为空！','error');</script>");
                return;
            }

            MDL.KeepWatchMOD kwMod = new MDL.KeepWatchMOD();
            kwMod.KWTitle = txtTitle.Value;
            kwMod.DepartmentID = Convert.ToInt32(Session["BusID"]);
            kwMod.UsID = Convert.ToInt32(Session["UsID"]);
            kwMod.Date = DateTime.Now;
            try
            {
                kwMod.BeginDate = Convert.ToDateTime(BeginDate.Value);
                kwMod.EndDate = Convert.ToDateTime(EndDate.Value);

            }
            catch
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','开始时间或结束时间格式错误，请重新选择！','error');</script>");
                return;
            }

            string FilePath = FileUpload1.FileName;
            Stream objFs;
            objFs = FileUpload1.PostedFile.InputStream;
            BinaryReader objBr = new BinaryReader(objFs);
            byte[] content = objBr.ReadBytes((int)objFs.Length);

            kwMod.FileName = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1); ;
            kwMod.FileContent= content;

          

            int result = new BLL.KeepWatchBLL().Add(kwMod);
            if (result > 0)
            {
                txtTitle.Value = "";
                
                BeginDate.Value = "";
                EndDate.Value = "";
                FileUpload1.Dispose();
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('成功','上传值班表成功！','info');</script>");

            }
            else
            {

                Page.RegisterStartupScript("Message", "<script>$.messager.alert('失败','上传值班表失败,请重新上传！','error');</script>");

            }



        }

       
    }
}