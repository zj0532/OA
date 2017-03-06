using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class StoreHouseMOD
    {

        #region Model
        private int _shid;
        private string _shopname;
        private int _shopamount;
        private int _shopclassid;
        private string _describe;
        private string _unit;
        private string _supplier;
        private int _stid;
        private string _remark;
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
        public string ShopName
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShopAmount
        {
            set { _shopamount = value; }
            get { return _shopamount; }
        }
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
        public string Describe
        {
            set { _describe = value; }
            get { return _describe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model


    }
}
