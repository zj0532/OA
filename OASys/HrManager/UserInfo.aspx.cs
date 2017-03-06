using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASys.HrManager
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsID"] == null)
            {
                Response.Redirect("login.aspx");

            }

            string UsID = Request.QueryString["UsID"].ToString();
            MDL.UserInfoMOD uiMod = new BLL.UserInfoBLL().GetModel(int.Parse(UsID));
            labBusiness.Text = new BLL.BusinessBLL().GetModel(uiMod.BusinessID).BusinessName;
            labCompany.Text = uiMod.BeComany;
            labEmail.Text = uiMod.Email;
            labEmptyCause.Text = uiMod.EntryCause;
            labEmptyInDate.Text = uiMod.EntryDate;
            labEmptyOutDate.Text = uiMod.DimissionDate;
            labJob.Text = new BLL.JobBLL().GetModel(uiMod.JobID).JobName;
            labOffice.Text = uiMod.Office;
            labPhone.Text = uiMod.Phone;
            labServerStyle.Text = new BLL.ServerStyleBLL().GetModel(uiMod.ServerStyleID).ServerStyleName;
            labStauts.Text = uiMod.Stauts;
            labUsname.Text = uiMod.UsName;
            labCommUp.Text = uiMod.MorTime.Trim();
            labCommDown.Text = uiMod.NightTime.Trim();
            labSatUp.Text = uiMod.SaturdayMorTime.Trim();
            labSatDown.Text = uiMod.SaturdayNightTime.Trim();

            //labWorkContent.Text = uiMod.EmptyOne;
            if (uiMod.EmptyOne.Trim() == "")
            {
                hlkWorkContent.Visible = false;
            }
            else
            {
                hlkWorkContent.NavigateUrl = uiMod.EmptyOne;
            }
            if (uiMod.EmptyTwo.Trim() == "")
            {
                hlkGW.Visible = false;

            }
            else
            {
                hlkGW.NavigateUrl = uiMod.EmptyTwo;  
            }

           

        }


    }
}