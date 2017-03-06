using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class ApplyArticleMOD
    {
        #region Model
        private int _aaid;
        private int _shid;
        private int _number;
        private DateTime _aadate;
        private DateTime _returndate;
        private int _usid;
        private int _asid;
        private string _returnremark;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int AAID
        {
            set { _aaid = value; }
            get { return _aaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShID
        {
            set { _shid = value; }
            get { return _shid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AADate
        {
            set { _aadate = value; }
            get { return _aadate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReturnDate
        {
            set { _returndate = value; }
            get { return _returndate; }
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
        public int AsID
        {
            set { _asid = value; }
            get { return _asid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnRemark
        {
            set { _returnremark = value; }
            get { return _returnremark; }
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
