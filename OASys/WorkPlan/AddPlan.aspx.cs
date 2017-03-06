using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace OASys.WorkPlan
{
    
    public partial class AddPlan : System.Web.UI.Page
    {
        
        public string PageSetName;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            PageSetName = "添加作业计划";
        }

    }
}