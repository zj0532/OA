using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class MeetingSummaryMOD
    {

        #region Model
        private int _msid;
        private string _mstitle;
        private DateTime _msdate;
        private string _msaddress;
        private int _usid;
        private string _compere;
        private string _joiner;
        private string _mscontent;
        private string _filename;
        private byte[] _filecontent;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int MSID
        {
            set { _msid = value; }
            get { return _msid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSTitle
        {
            set { _mstitle = value; }
            get { return _mstitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime MSDate
        {
            set { _msdate = value; }
            get { return _msdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSAddress
        {
            set { _msaddress = value; }
            get { return _msaddress; }
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
        public string Compere
        {
            set { _compere = value; }
            get { return _compere; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Joiner
        {
            set { _joiner = value; }
            get { return _joiner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSContent
        {
            set { _mscontent = value; }
            get { return _mscontent; }
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
