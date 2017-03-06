using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;

using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;



namespace OASys.HrManager
{
    public partial class AddressList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            this.GetDropDownValue();
            if (!new BLL.PageSettingBLL().ExistsAuthority(Convert.ToInt32(Session["UsID"]), "通讯录"))
            {
                Page.RegisterStartupScript("Message", "<script> document.getElementById('DivButton').style.display='none'</script>");
            }

        }

        public void GetDropDownValue()
        {
            dplJob.DataSource = new BLL.JobBLL().GetList("").Tables[0];
            dplJob.DataTextField = "JobName";
            dplJob.DataValueField = "JobID";
            dplJob.DataBind();

            dplBusiness.DataSource = new BLL.BusinessBLL().GetList("").Tables[0];
            dplBusiness.DataTextField = "BusinessName";
            dplBusiness.DataValueField = "BusinessID";
            dplBusiness.DataBind();

            dplServerStyle.DataSource = new BLL.ServerStyleBLL().GetList("").Tables[0];
            dplServerStyle.DataTextField = "ServerStyleName";
            dplServerStyle.DataValueField = "ServerStyleID";
            dplServerStyle.DataBind();


            dplJobUpd.DataSource = new BLL.JobBLL().GetList("").Tables[0];
            dplJobUpd.DataTextField = "JobName";
            dplJobUpd.DataValueField = "JobID";
            dplJobUpd.DataBind();

            dplBusinessUpd.DataSource = new BLL.BusinessBLL().GetList("").Tables[0];
            dplBusinessUpd.DataTextField = "BusinessName";
            dplBusinessUpd.DataValueField = "BusinessID";
            dplBusinessUpd.DataBind();

            dplServerStyleUpd.DataSource = new BLL.ServerStyleBLL().GetList("").Tables[0];
            dplServerStyleUpd.DataTextField = "ServerStyleName";
            dplServerStyleUpd.DataValueField = "ServerStyleID";
            dplServerStyleUpd.DataBind();

            dplQY.DataSource = new BLL.WordGroupBLL().GetList("").Tables[0];
            dplQY.DataTextField = "WordGroupName";
            dplQY.DataValueField = "WordGroupID";
            dplQY.DataBind();


            dplQYUpd.DataSource = new BLL.WordGroupBLL().GetList("").Tables[0];
            dplQYUpd.DataTextField = "WordGroupName";
            dplQYUpd.DataValueField = "WordGroupID";
            dplQYUpd.DataBind();


        }

        public void getUserSelect(string jobid,string businessid,string serverstyleid )
        {
            dplBusinessUpd.SelectedValue = businessid;
            dplJobUpd.SelectedValue = jobid;
            dplServerStyleUpd.SelectedValue = serverstyleid;

        }


        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public static void ExportByWeb(DataTable dtSource, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(RenderToExcel(dtSource).GetBuffer());
            //curContext.Response.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            curContext.ApplicationInstance.CompleteRequest();
        }

        public static MemoryStream RenderToExcel(DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            using (table)
            {
                IWorkbook workbook = new HSSFWorkbook();

                ISheet sheet = workbook.CreateSheet();

                IRow headerRow = sheet.CreateRow(0);

                // handling header.
                foreach (DataColumn column in table.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

                // handling value.
                int rowIndex = 1;

                foreach (DataRow row in table.Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in table.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }

                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

            }
            return ms;
        }

        protected void ExportExl_Click(object sender, EventArgs e)
        {
            DataTable dt = new BLL.UserInfoBLL().GetUserListByExport();
            ExportByWeb(dt, "通讯录.xls");
                
        }


    }
}