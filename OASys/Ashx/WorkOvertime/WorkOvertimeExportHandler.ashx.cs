using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;
using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace OASys.Ashx.WorkOvertime
{
    /// <summary>
    /// WorkOvertimeExportHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkOvertimeExportHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string UsName = context.Request["UsName"];
            DateTime MinDate = Convert.ToDateTime(context.Request["BeginDate"].Trim() == "" ? "2000-01-01" : context.Request["BeginDate"]);
            DateTime MaxDate = Convert.ToDateTime(context.Request["EndDate"].Trim() == "" ? DateTime.Now.ToShortDateString() : context.Request["EndDate"]);
            string HolidayClass = context.Request["WorkClass"];
            DataTable dt = new DataTable();
            string strWhere = "postCause='加班' ";
            string UidWhere = "";
            if (UsName != "")
            {
                dt = new BLL.UserInfoBLL().GetList("UsName='" + UsName + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count == 1)
                    {
                        strWhere += " and usid='" + dt.Rows[0]["usid"] + "' ";
                    }
                    else
                    {
                        UidWhere += "and (";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UidWhere += " usid='" + dt.Rows[i]["usid"] + "' or";
                            if (i == dt.Rows.Count - 1)
                            {
                                UidWhere += "1=2 )";
                            }

                        }
                    }
                }
                else
                {
                    strWhere += " and 1=2 ";
                }
            }
            if (UidWhere != "")
            {
                strWhere = strWhere + UidWhere;
            }

            strWhere += " and begindate>=convert(datetime,'" + MinDate + "') and endDate<=convert(datetime,'" + MaxDate + "')";

            if (HolidayClass != "")
            {
                strWhere += "and HolidayCalss='" + HolidayClass + "' ";
            }

            strWhere += " order by  postdate desc ";
            dt = new BLL.AttendanceBLL().GetListByJBChineseName(strWhere).Tables[0];
            MemoryStream Ms = RenderToExcel(dt);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "查询加班历史记录导出表.XLS";
            SaveToFile(Ms, AppDomain.CurrentDomain.BaseDirectory + "\\ExportEecel\\" + fileName);
            sb.Append("[{\"result\":\"" + fileName + "\"}]");

            context.Response.Write(sb.ToString());
            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
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


        static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();

                data = null;
            }
        }





    }
}