using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class KeepWatchMOD
    {

        #region Model
        private int _kwid;
        private string _kwtitle;
        private int _departmentid;
        private int _usid;
        private DateTime _date;
        private DateTime _begindate;
        private DateTime _enddate;
        private string _filename;
        private byte[] _filecontent;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int KWID
        {
            set { _kwid = value; }
            get { return _kwid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KWTitle
        {
            set { _kwtitle = value; }
            get { return _kwtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
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
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
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
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FileContent
        {
            set { _filecontent = value; }
            get { return _filecontent; }
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
