using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class StoreStatusMOD
    {
        #region Model
        private int _stid;
        private string _stname;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int StID
        {
            set { _stid = value; }
            get { return _stid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StName
        {
            set { _stname = value; }
            get { return _stname; }
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
