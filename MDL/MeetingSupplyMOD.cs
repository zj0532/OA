using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class MeetingSupplyMOD
    {

        #region Model
        private int _msuid;
        private int _msid;
        private int _usid;
        private DateTime _date;
        private string _sucontent;
        private string _filename;
        private byte[] _filecontent;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int MSUID
        {
            set { _msuid = value; }
            get { return _msuid; }
        }
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
        public string SuContent
        {
            set { _sucontent = value; }
            get { return _sucontent; }
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
