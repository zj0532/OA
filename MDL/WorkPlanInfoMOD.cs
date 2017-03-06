using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class WorkPlanInfoMOD
    {

        #region Model
        private int _wpiid;
        private int _wpid;
        private string _wpiplaninfo;
        private DateTime _shoulddate;
        private string _wpicontent;
        private DateTime _truthdate;
        private string _filename;
        private byte[] _filecontent;
        private int _times;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int WPIID
        {
            set { _wpiid = value; }
            get { return _wpiid; }
        }
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
        public string WPIPlanInfo
        {
            set { _wpiplaninfo = value; }
            get { return _wpiplaninfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ShouldDate
        {
            set { _shoulddate = value; }
            get { return _shoulddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WPIContent
        {
            set { _wpicontent = value; }
            get { return _wpicontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TruthDate
        {
            set { _truthdate = value; }
            get { return _truthdate; }
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
        public int Times
        {
            set { _times = value; }
            get { return _times; }
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
