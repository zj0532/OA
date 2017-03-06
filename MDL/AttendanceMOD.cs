using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class AttendanceMOD
    {

        #region Model
        private int _atid;
        private int _usid;
        private string _postcause;
        private DateTime _postdate;
        private string _postip;
        private string _holiday;
        private string _onelevelaudit = "NULL";
        private string _twolevelaudit;
        private string _begindate;
        private string _enddate;
        private string _holidaycalss;
        private string _workcontent;
        private string _workpeson;
        private string _stauts;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int AtID
        {
            set { _atid = value; }
            get { return _atid; }
        }
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
        public string PostCause
        {
            set { _postcause = value; }
            get { return _postcause; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostIP
        {
            set { _postip = value; }
            get { return _postip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Holiday
        {
            set { _holiday = value; }
            get { return _holiday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OneLevelAudit
        {
            set { _onelevelaudit = value; }
            get { return _onelevelaudit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TwoLevelAudit
        {
            set { _twolevelaudit = value; }
            get { return _twolevelaudit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BeginDate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HolidayCalss
        {
            set { _holidaycalss = value; }
            get { return _holidaycalss; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkContent
        {
            set { _workcontent = value; }
            get { return _workcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkPeson
        {
            set { _workpeson = value; }
            get { return _workpeson; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model


    }
}
