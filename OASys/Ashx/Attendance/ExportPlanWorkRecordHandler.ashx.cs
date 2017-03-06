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


namespace OASys.Ashx.Attendance
{
    /// <summary>
    /// ExportPlanWorkRecordHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ExportPlanWorkRecordHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string UName = context.Request["UsName"];
            string BeginDate = context.Request["BeginDate"];
            string EndDate = context.Request["EndDate"];
            string sqlWhere = "1=1";
            if (UName.Trim() != "")
            {
                sqlWhere += " and usname like '%" + UName + "%'";
            }
            if (BeginDate.Trim() != "")
            {
                sqlWhere += " and begindate>='" + BeginDate + "' ";
            }
            if (EndDate.Trim() != "")
            {
                sqlWhere += " and enddate<='" + EndDate + "'  ";
            }

            DataTable dt = new BLL.PlanWrokBLL().ExportListByWhere(sqlWhere).Tables[0];
            StringBuilder sb = new StringBuilder();
            try
            {
                
                MemoryStream Ms = RenderToExcel(dt);
                string fileName = "计划性加班历史记录.XLS";
                SaveToFile(Ms, AppDomain.CurrentDomain.BaseDirectory + "\\ExportEecel\\" + fileName);
                sb.Append("[{\"result\":\"" + fileName + "\"}]");
            }
            catch
            {
                sb.Append("[{\"result\":\"0\"}]");
            }
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