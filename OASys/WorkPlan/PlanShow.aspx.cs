using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace OASys.WorkPlan
{
    
    public partial class PlanShow : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bthOK_Click(object sender, EventArgs e)
        {
            string Wpiid = hfwpiid.Value;
            MDL.WorkPlanInfoMOD WPMod = new BLL.WorkPlanInfoBLL().GetModel(int.Parse(Wpiid));
            if (WPMod.Remark == "1")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('回复失败','本期计划任务已回复过，如需重新回复请与管理员联系！','error');</script>");
                return;
            }

            WPMod.WPIContent = txtContent.Value.Replace("\r\n","<br/>");
            WPMod.TruthDate = DateTime.Now;  
            
            string FilePath = FileUpload1.FileName;
            if(FilePath.Trim ()!="")
            { 
                Stream objFs;
                objFs = FileUpload1.PostedFile.InputStream;
                BinaryReader objBr = new BinaryReader(objFs);
                byte[] content = objBr.ReadBytes((int)objFs.Length);

                WPMod.FileName = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1); ;
                WPMod.FileContent = content;
            }
            WPMod.Remark ="1";

            bool result = new BLL.WorkPlanInfoBLL().Update(WPMod);

            if (result)
            {
                Response.Redirect("PlanShow.aspx?wpid=" + Request.QueryString["wpid"]);
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('回复失败','回复本期作业计划失败，请重新回复！','error');</script>");
                return;
            }

        }
    }
}