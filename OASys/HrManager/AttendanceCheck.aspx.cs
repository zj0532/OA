using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.Serialization;
using System.Web.Services;
using System.Text;

namespace OASys.HrManager
{
    public partial class AttendanceCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("../index.aspx");
            }

        }


    }
}