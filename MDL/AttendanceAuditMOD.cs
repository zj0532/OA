using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class AttendanceAuditMOD
    {

        #region Model
        private string _auditid;
        private int _jobid;
        private string _auditname;
        private string _remark;
        private int _days;
        private int _hours;
        /// <summary>
        /// 
        /// </summary>
        public string AuditID
        {
            set { _auditid = value; }
            get { return _auditid; }
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
        public string AuditName
        {
            set { _auditname = value; }
            get { return _auditname; }
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
        public int Days
        {
            set { _days = value; }
            get { return _days; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hours
        {
            set { _hours = value; }
            get { return _hours; }
        }
        #endregion Model

    }
}
