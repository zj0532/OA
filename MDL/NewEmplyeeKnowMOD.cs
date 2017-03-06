using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public class NewEmplyeeKnowMOD
    {
        #region Model
        private int _neid;
        private string _title;
        private string _necontent;
        private DateTime  _date;
        private int _usid;
        private int _businessid;
        private string _filename;
        private byte[] _filecontent;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int NeID
        {
            set { _neid = value; }
            get { return _neid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NeContent
        {
            set { _necontent = value; }
            get { return _necontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime  Date
        {
            set { _date = value; }
            get { return _date; }
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
        public int BusinessID
        {
            set { _businessid = value; }
            get { return _businessid; }
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
