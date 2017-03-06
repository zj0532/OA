using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public class NoticeMOD
    {
        #region Model
        private int _noid;
        private string _title;
        private string _nocontent;
        private DateTime _date;
        private DateTime _effectdatebefore;
        private DateTime _effectdateend;
        private int _usid;
        private int _noticeclass;
        private string _classvalue;
        private string _filename;
        private byte[] _filecontent;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int NoID
        {
            set { _noid = value; }
            get { return _noid; }
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
        public string NoContent
        {
            set { _nocontent = value; }
            get { return _nocontent; }
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
        public DateTime EffectDateBefore
        {
            set { _effectdatebefore = value; }
            get { return _effectdatebefore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EffectDateEnd
        {
            set { _effectdateend = value; }
            get { return _effectdateend; }
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
        public int NoticeClass
        {
            set { _noticeclass = value; }
            get { return _noticeclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassValue
        {
            set { _classvalue = value; }
            get { return _classvalue; }
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
