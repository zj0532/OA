using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.FileManager
{
    public partial class AddAndMeet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
        }

        protected void bthAddFile_Click(object sender, EventArgs e)
        {
            MDL.MeetingSummaryMOD MtMod = new MDL.MeetingSummaryMOD();
            if (txtTitle.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议标题不能为空！','error');</script>");
                return;
            }
            if (txtDate.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间不能为空！','error');</script>");
                return;
            }
            if (txtAddress.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议地点不能为空！','error');</script>");
                return;
            }
            if (txtCompere.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议主持不能为空！','error');</script>");
                return;
            }
            if (txtJoiner.Value.Trim() == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','参会人员不能为空！','error');</script>");
                return;
            }
            if (FileUpLoad1.FileName == "")
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议纪要文档路径错误，请重新选择！','error');</script>");
                return;
            }

            MtMod.MSTitle = txtTitle.Value;
            try
            {
                MtMod.MSDate = Convert.ToDateTime(txtDate.Value);
            }
            catch
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间格式错误，请重新选择！','error');</script>");
                return;
            }

            string FilePath = FileUpLoad1.FileName;

            Stream objFs;
            objFs = FileUpLoad1.PostedFile.InputStream;
            BinaryReader objBr = new BinaryReader(objFs);
            byte[] content = objBr.ReadBytes((int)objFs.Length);

            MtMod.MSAddress = txtAddress.Value;
            MtMod.UsID = Convert.ToInt32(Session["UsID"]);
            MtMod.Compere = txtCompere.Value;
            MtMod.Joiner = txtJoiner.Value;
            MtMod.FileName = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1, FilePath.Length - FilePath.LastIndexOf(@"\") - 1);
            MtMod.Remark = DateTime.Now.ToString();
            MtMod.FileContent = content;


            int result = new BLL.MeetingSummaryBLL().Add(MtMod);
            if (result > 0)
            {
                Page.RegisterStartupScript("Message", "<script>window.location.href='MeetSummary.aspx';</script>");
            }
            else
            {
                Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','添加会议记录发生失败，请重新添加，如果继续失败请于管理员联系！','error');</script>");

            }


        }

      //  protected void bthAddFile_Click(object sender, EventArgs e)
        //{
        //    if (PageStaute == "添加")
        //    {
        //        MDL.MeetingSummaryMOD MtMod = new MDL.MeetingSummaryMOD();
        //        if (txtTitle.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议标题不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtDate.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtAddress.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议地点不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtCompere.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议主持不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtJoiner.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','参会人员不能为空！','error');</script>");
        //            return;
        //        }
        //        if (Editor1.Text.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议内容不能为空！','error');</script>");
        //            return;
        //        }

        //        MtMod.MSTitle = txtTitle.Value;
        //        try
        //        {
        //            MtMod.MSDate = Convert.ToDateTime(txtDate.Value);
        //        }
        //        catch
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间格式错误，请重新选择！','error');</script>");
        //            return;
        //        }
        //        MtMod.MSAddress = txtAddress.Value;
        //        MtMod.UsID = Convert.ToInt32(Session["UsID"]);
        //        MtMod.Compere = txtCompere.Value;
        //        MtMod.Joiner = txtJoiner.Value;
        //        MtMod.MSContent = Editor1.Text;
        //        MtMod.Remark = DateTime.Now.ToString();

        //        int result = new BLL.MeetingSummaryBLL().Add(MtMod);
        //        if (result > 0)
        //        {
        //            Page.RegisterStartupScript("Message", "<script>window.location.href='MeetSummary.aspx';</script>");
        //        }
        //        else
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','添加会议记录发生失败，请重新添加，如果继续失败请于管理员联系！','error');</script>");

        //        }

        //    }
        //    else
        //    {
        //        MDL.MeetingSummaryMOD UpdMtMod = new MDL.MeetingSummaryMOD();
        //        if (txtTitle.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议标题不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtDate.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtAddress.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议地点不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtCompere.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议主持不能为空！','error');</script>");
        //            return;
        //        }
        //        if (txtJoiner.Value.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','参会人员不能为空！','error');</script>");
        //            return;
        //        }
        //        if (Editor1.Text.Trim() == "")
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议内容不能为空！','error');</script>");
        //            return;
        //        }

        //        UpdMtMod.MSTitle = txtTitle.Value;
        //        try
        //        {
        //            UpdMtMod.MSDate = Convert.ToDateTime(txtDate.Value);
        //        }
        //        catch
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','会议时间格式错误，请重新选择！','error');</script>");
        //            return;
        //        }
        //        UpdMtMod.MSAddress = txtAddress.Value;
        //        UpdMtMod.UsID = Convert.ToInt32(Session["UsID"]);
        //        UpdMtMod.Compere = txtCompere.Value;
        //        UpdMtMod.Joiner = txtJoiner.Value;
        //        UpdMtMod.MSContent = Editor1.Text;
        //        UpdMtMod.Remark = DateTime.Now.ToString();
        //        UpdMtMod.MSID = Convert.ToInt32(Request.QueryString["MsID"]);
        //        bool result = new BLL.MeetingSummaryBLL().Update(UpdMtMod);
        //        if (result)
        //        {
        //            Page.RegisterStartupScript("Message", "<script>window.location.href='MeetSummary.aspx';</script>");
        //        }
        //        else
        //        {
        //            Page.RegisterStartupScript("Message", "<script>$.messager.alert('修改失败','修改会议记录发生失败，请重新添加，如果继续失败请于管理员联系！','error');</script>");

        //        }



        //    }
        //}
    }
}