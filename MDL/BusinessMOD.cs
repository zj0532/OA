using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class BusinessMOD
    {
        #region Model
        private int _businessid;
        private string _businessname;
        private string _remark;
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
        public string BusinessName
        {
            set { _businessname = value; }
            get { return _businessname; }
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
