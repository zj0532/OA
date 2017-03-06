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
    /// GetAttendanceTimeHandler 的摘要说明
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetAttendanceTimeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            DateTime begin = Convert.ToDateTime(context.Request["BeginDate"]);
            DateTime end = Convert.ToDateTime(context.Request["EndDate"]);
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("考勤表");
            IRow headerRow=sheet.CreateRow(0);
            DataTable dt = new BLL.AttendanceBLL().RunProcedure("UP_GetAttendanceDayByDay", DateTime.Parse(begin.ToString("yyyy-MM-dd"))).Tables[0]; 

            ICell cell=headerRow.CreateCell(0);
            cell.SetCellValue("姓名");
            DateTime objDate = begin;
            IRow Row;

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                
                Row = sheet.CreateRow(j);
                cell=Row.CreateCell(0);
                cell.SetCellValue(dt.Rows[j-1]["姓名"].ToString ());
            
            
            }
           for (int i = 1; ; i++)
           {
                if (objDate > end)
                 {
                    break;
                 }

                 cell = headerRow.CreateCell(i);
                 cell.SetCellValue(objDate.ToString("yyyy-MM-dd"));
                 dt = new BLL.AttendanceBLL().RunProcedure("UP_GetAttendanceDayByDay", DateTime.Parse(objDate.ToString("yyyy-MM-dd"))).Tables[0];
                 for (int b = 1; b < dt.Rows.Count; b++)
                 {
                     Row = sheet.GetRow(b);
                     cell = Row.CreateCell(i);
                     cell.SetCellValue(dt.Rows[b-1]["上班"].ToString() + "|" + dt.Rows[b-1]["下班"].ToString());
                 
                 }
                 objDate = objDate.AddDays(1);
                 



           }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            try
            {
                string fileName = begin.ToString("yyyy-MM-dd") + "日到" + end.ToString("yyyy-MM-dd") + "日考勤表.XLS";
                
                SaveToFile(ms, AppDomain.CurrentDomain.BaseDirectory + "\\ExportEecel\\" + fileName);
                sb.Append("[{\"result\":\"" + fileName + "\"}]");
            }
            catch
            {
                sb.Append("[{\"result\":\"1\"}]");
            }

            context.Response.Write(sb.ToString());
            context.Response.End();

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



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}