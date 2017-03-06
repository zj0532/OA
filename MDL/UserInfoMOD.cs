using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public class UserInfoMOD
    {
        #region Model
        private int _usid;
        private string _usname;
        private string _uspwd;
        private string _phone;
        private string _email;
        private int _jobid;
        private int _businessid;
        private string _stauts;
        private int _serverstyleid;
        private string _becomany;
        private string _office;
        private string _entrydate;
        private string _entrycause;
        private string _dimissiondate;
        private string _remark;
        private string _emptyone;
        private string _emptytwo;
        private int _wrodgroupid;
        private string _mortime;
        private string _nighttime;
        private string _saturdaymortime;
        private string _saturdaynighttime;
        private int _islockip = 0;
        /// <summary>
        /// 
        /// </summary>
        public int UsID
        {
            set { _usid = value; }
            get { return _usid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsName
        {
            set { _usname = value; }
            get { return _usname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsPwd
        {
            set { _uspwd = value; }
            get { return _uspwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int JobID
        {
            set { _jobid = value; }
            get { return _jobid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BusinessID
        {
            set { _businessid = value; }
            get { return _businessid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Stauts
        {
            set { _stauts = value; }
            get { return _stauts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ServerStyleID
        {
            set { _serverstyleid = value; }
            get { return _serverstyleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BeComany
        {
            set { _becomany = value; }
            get { return _becomany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Office
        {
            set { _office = value; }
            get { return _office; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EntryDate
        {
            set { _entrydate = value; }
            get { return _entrydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EntryCause
        {
            set { _entrycause = value; }
            get { return _entrycause; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DimissionDate
        {
            set { _dimissiondate = value; }
            get { return _dimissiondate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmptyOne
        {
            set { _emptyone = value; }
            get { return _emptyone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmptyTwo
        {
            set { _emptytwo = value; }
            get { return _emptytwo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WrodGroupID
        {
            set { _wrodgroupid = value; }
            get { return _wrodgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MorTime
        {
            set { _mortime = value; }
            get { return _mortime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NightTime
        {
            set { _nighttime = value; }
            get { return _nighttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SaturdayMorTime
        {
            set { _saturdaymortime = value; }
            get { return _saturdaymortime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SaturdayNightTime
        {
            set { _saturdaynighttime = value; }
            get { return _saturdaynighttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsLockIP
        {
            set { _islockip = value; }
            get { return _islockip; }
        }
        #endregion Model

    }
}
