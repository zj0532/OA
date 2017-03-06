using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class FileManagerMOD
    {
        #region Model
        private int _flid;
        private string _filename;
        private string _filecontent;
        private byte[] _filecode;
        private DateTime _filedate;
        private int _usid;
        private int _fceid;
        private int _fcid;
        /// <summary>
        /// 
        /// </summary>
        public int FlID
        {
            set { _flid = value; }
            get { return _flid; }
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
        public string FileContent
        {
            set { _filecontent = value; }
            get { return _filecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FileCode
        {
            set { _filecode = value; }
            get { return _filecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FileDate
        {
            set { _filedate = value; }
            get { return _filedate; }
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
        public int FCEID
        {
            set { _fceid = value; }
            get { return _fceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FCID
        {
            set { _fcid = value; }
            get { return _fcid; }
        }
        #endregion Model


    }
}
