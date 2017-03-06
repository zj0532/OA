using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OASys.FileManager
{
    public partial class AddImportant : System.Web.UI.Page
    {
        public string PageStaute;
        int FileID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            PageStaute = Request.QueryString["FileID"].ToString() == "0" ? "添加" : "修改";
            FileID = Convert.ToInt32(Request.QueryString["FileID"]);
            if (!IsPostBack)
            {
                if (PageStaute == "修改")
                {
                  this.getDateBind();
                }
                else
                { this.setting(); }
               
                
            }
        }

        private void getDateBind()
        {
            MDL.FileManagerMOD dbFmMod = new BLL.FileManagerBLL().GetModel(FileID);
            txtTitle.Value = dbFmMod.FileName;
            txtDate.Value = dbFmMod.FileDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtUsName.Value = new BLL.UserInfoBLL().GetModel(dbFmMod.UsID).UsName;
            Editor1.Text = dbFmMod.FileContent;

        }

        private void setting()
        {
            txtDate.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtUsName.Value = Session["UsName"].ToString();

        }

        protected void bthCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Important.aspx");
        }

        protected void bthSumbit_Click(object sender, EventArgs e)
        {
           
            MDL.FileManagerMOD FmMod = new MDL.FileManagerMOD();
            if (PageStaute == "添加")
            {
                if (txtTitle.Value.Trim() == "")
                {
                    Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','核心资料标题不能为空！','error');</script>");
                    return;
                }
                FmMod.FileName = txtTitle.Value;
                FmMod.FileDate = Convert.ToDateTime(txtDate.Value);
                FmMod.FileContent = Editor1.Text;
                FmMod.UsID = Convert.ToInt32(Session["UsID"]);
                FmMod.FCEID = int.Parse(new BLL.FileClassExplicitBLL().GetList("FCEName='核心资料'").Tables[0].Rows[0]["FCEID"].ToString());
                FmMod.FCID = int.Parse(new BLL.FileClassExplicitBLL().GetList("FCEName='核心资料'").Tables[0].Rows[0]["FCID"].ToString());

                int result = new BLL.FileManagerBLL().Add(FmMod);
                if (result > 0)
                {
                    Response.Redirect("Important.aspx");
                }
                else
                {
                    Page.RegisterStartupScript("Message", "<script>$.messager.alert('添加失败','添加失败，请重新添加，如果继续失败请于管理员联系！','error');</script>");
                   
                }


            }
            else
            {
                if (txtTitle.Value.Trim() == "")
                {
                    Page.RegisterStartupScript("Message", "<script>$.messager.alert('格式错误','核心资料标题不能为空！','error');</script>");
                    return;
                }
                FmMod.FileName = txtTitle.Value;
                FmMod.FileDate = Convert.ToDateTime(txtDate.Value);
                FmMod.FileContent = Editor1.Text;
                FmMod.UsID = Convert.ToInt32(Session["UsID"]);
                FmMod.FCEID = int.Parse(new BLL.FileClassExplicitBLL().GetList("FCEName='核心资料'").Tables[0].Rows[0]["FCEID"].ToString());
                FmMod.FCID = int.Parse(new BLL.FileClassExplicitBLL().GetList("FCEName='核心资料'").Tables[0].Rows[0]["FCID"].ToString());
                FmMod.FlID = FileID;
                bool result = new BLL.FileManagerBLL().Update(FmMod);
                if (result)
                {
                    Response.Redirect("Important.aspx");
                }
                else
                {
                    Page.RegisterStartupScript("Message", "<script>$.messager.alert('修改失败','修改失败，请重新修改，如果继续失败请于管理员联系！','error');</script>");

                }


            }


        }
    }
}