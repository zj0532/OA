using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class ApplyStatusMOD
    {
        #region Model
        private int _asid;
        private string _asname;
        private string _remark;
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
        public string AsName
        {
            set { _asname = value; }
            get { return _asname; }
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
