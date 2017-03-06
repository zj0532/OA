using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public class WorkPlanMOD
    {
        #region Model
        private int _wpid;
        private string _wptitle;
        private string _cycle;
        private DateTime _begindate;
        private DateTime _enddate;
        private int _usid;
        private DateTime _createdate;
        private string _wpcontent;
        private string _filename;
        private byte[] _filecontent;
        private int _isdel;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int WPID
        {
            set { _wpid = value; }
            get { return _wpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WPTitle
        {
            set { _wptitle = value; }
            get { return _wptitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cycle
        {
            set { _cycle = value; }
            get { return _cycle; }
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
        public int UsID
        {
            set { _usid = value; }
            get { return _usid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WPContent
        {
            set { _wpcontent = value; }
            get { return _wpcontent; }
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
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
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
