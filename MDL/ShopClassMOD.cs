using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class ShopClassMOD
    {
        #region Model
        private int _shopclassid;
        private string _shopclassname;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int ShopClassID
        {
            set { _shopclassid = value; }
            get { return _shopclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopClassName
        {
            set { _shopclassname = value; }
            get { return _shopclassname; }
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
