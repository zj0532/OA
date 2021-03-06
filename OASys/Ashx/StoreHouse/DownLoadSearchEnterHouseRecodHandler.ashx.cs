﻿using System;
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

namespace OASys.Ashx.StoreHouse
{
    /// <summary>
    /// DownLoadSearchEnterHouseRecodHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DownLoadSearchEnterHouseRecodHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            StringBuilder sb = new StringBuilder();
            string ShName = context.Request["ShopName"];
            string ShopClass = context.Request["ShopClass"];
            string BeginDate = context.Request["BeginDate"];
            string EndDate = context.Request["EndDate"];
            string sqlWhere = "1=1";

            if (ShName.Trim() != "")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopName like '%" + ShName + "%' ) ";
            }

            if (ShopClass != "0")
            {
                sqlWhere += " and shid in ( select shid from tbStoreHouse where ShopClassID='" + ShopClass + "'  ) ";
            }

            if (BeginDate.Trim() != "")
            {
                sqlWhere += " and pidate >='" + BeginDate + "' ";
            }

            if (EndDate.Trim() != "")
            {
                sqlWhere += " and pidate <='" + EndDate + "' ";
            }

            sqlWhere += " order by pidate desc ";

            try
            {
                DataTable dt = new BLL.PutInStoreBLL().GetDownLoadList(sqlWhere).Tables[0];
                MemoryStream Ms = RenderToExcel(dt);
                string fileName ="入库记录查询导出表.XLS";
                SaveToFile(Ms, AppDomain.CurrentDomain.BaseDirectory + "\\ExportEecel\\" + fileName);
                sb.Append("[{\"result\":\""+fileName+"\"}]");
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