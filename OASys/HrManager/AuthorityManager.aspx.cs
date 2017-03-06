using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace OASys.HrManager
{
    public partial class AuthorityManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }
            if (!IsPostBack)
            {
                this.RepBind();
            }
        }

        private void RepBind()
        {
            DataTable dt = new BLL.PageSettingBLL().GetList("fatherpsid='0' order by psid").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep1 = (Repeater)e.Item.FindControl("Repeater2");
                DataRowView dr = (DataRowView)e.Item.DataItem;
                int PsID = int.Parse(dr["PsID"].ToString ());
                rep1.DataSource = new BLL.PageSettingBLL().GetList("FatherPsID='"+PsID+"' order by psid").Tables[0];
                rep1.DataBind();
            }
        }


        //private void TreeUserBing()
        //{
        //    DataTable dt = new BLL.UserInfoBLL().GetList("stauts='在职' and jobid='1' ").Tables[0];
        //    TreeNode tn = new TreeNode();
        //    tn.Text = dt.Rows[0]["UsName"].ToString();
        //    tn.Value = dt.Rows[0]["UsID"].ToString();
        //    treUserInfo.Nodes.Add(tn);
        //    this.SonTreeUserBing(dt.Rows[0]["jobid"].ToString(), dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["wrodgroupid"].ToString(), tn);

        //}


        //private void SonTreeUserBing(string jobid, string busid, string workid, TreeNode tnode)
        //{

        //    DataTable dt;
        //    TreeNode sn;

        //    if (jobid == "1")
        //    {
        //        dt = new BLL.UserInfoBLL().GetList("jobid='2' and stauts='在职'").Tables[0];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            sn = new TreeNode();
        //            sn.Text = dt.Rows[i]["UsName"].ToString();
        //            sn.Value = dt.Rows[i]["UsID"].ToString();
        //            tnode.ChildNodes.Add(sn);
        //            this.SonTreeUserBing(dt.Rows[0]["jobid"].ToString(), dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["wrodgroupid"].ToString(), sn);

        //        }
        //    }
        //    if (jobid == "2")
        //    {
        //        dt = new BLL.UserInfoBLL().GetList("jobid='3' and stauts='在职' and wrodgroupid='" + workid + "'").Tables[0];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            sn = new TreeNode();
        //            sn.Text = dt.Rows[i]["UsName"].ToString();
        //            sn.Value = dt.Rows[i]["UsID"].ToString();
        //            tnode.ChildNodes.Add(sn);
        //            this.SonTreeUserBing(dt.Rows[0]["jobid"].ToString(), dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["wrodgroupid"].ToString(), sn);

        //        }
        //    }
        //    if (jobid == "3")
        //    {
        //        dt = new BLL.UserInfoBLL().GetList(100, "jobid!='3'and jobid!='2'and jobid!='1'and businessid='" + busid + "' and  stauts='在职' and wrodgroupid='" + workid + "'", " jobid").Tables[0];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            sn = new TreeNode();
        //            sn.Text = dt.Rows[i]["UsName"].ToString();
        //            sn.Value = dt.Rows[i]["UsID"].ToString();
        //            tnode.ChildNodes.Add(sn);
        //            //this.SonTreeUserBing(dt.Rows[0]["jobid"].ToString(), dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["wrodgroupid"].ToString(), sn);

        //        }
        //    }


        //}

    }
}