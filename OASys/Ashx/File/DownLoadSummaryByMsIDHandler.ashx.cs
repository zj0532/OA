using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.Ashx.File
{
    /// <summary>
    /// DownLoadSummaryByMsIDHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DownLoadSummaryByMsIDHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            string MsID = context.Request["MsID"];

            MDL.MeetingSummaryMOD FmMod = new BLL.MeetingSummaryBLL().GetModel(int.Parse(MsID));


            string savePath = System.Web.HttpContext.Current.Server.MapPath("..\\..\\ExportFile\\");

            if (!System.IO.Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string filePath = savePath + FmMod.FileName;

            FileStream fs;
            if (System.IO.File.Exists(filePath))
            {
                fs = new FileStream(filePath, FileMode.Truncate);
            }
            else
            {
                fs = new FileStream(filePath, FileMode.CreateNew);
            }
            BinaryWriter br = new BinaryWriter(fs);
            byte[] data = FmMod.FileContent;

            br.Write(data, 0, data.Length);
            br.Close();
            fs.Close();
            StringBuilder sb = new StringBuilder();

            sb.Append("[{\"result\":\"" + FmMod.FileName + "\"}]");
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
    }
}