using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OASys.FileManager
{
    public partial class WeeklyReportList : System.Web.UI.Page
    {
        public string BusinessIDName;
        public string BusID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            BusID = Request.QueryString["BusID"].ToString();
            BusinessIDName = new BLL.BusinessBLL().GetModel(int.Parse(BusID)).BusinessName;

        }



    }
}