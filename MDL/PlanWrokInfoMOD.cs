using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class PlanWrokInfoMOD
    {
        #region Model
        private int _pwlid;
        private int _pwid;
        private string _usname;
        private DateTime _begindate;
        private DateTime _enddate;
        private string _hours;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int PWLID
        {
            set { _pwlid = value; }
            get { return _pwlid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PWID
        {
            set { _pwid = value; }
            get { return _pwid; }
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
        public DateTime BeginDate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hours
        {
            set { _hours = value; }
            get { return _hours; }
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
