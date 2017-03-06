using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class PutInStoreMOD
    {

        #region Model
        private int _piid;
        private int _shid;
        private int _piamount;
        private DateTime _pidate;
        private int _piusid;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int PiID
        {
            set { _piid = value; }
            get { return _piid; }
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
        public int PiAmount
        {
            set { _piamount = value; }
            get { return _piamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PiDate
        {
            set { _pidate = value; }
            get { return _pidate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PiUsID
        {
            set { _piusid = value; }
            get { return _piusid; }
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
