using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class PageSettingMOD
    {
        #region Model
        private int _psid;
        private string _psaddress;
        private string _psname;
        private string _fatherpsid;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int PsID
        {
            set { _psid = value; }
            get { return _psid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PsAddress
        {
            set { _psaddress = value; }
            get { return _psaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PsName
        {
            set { _psname = value; }
            get { return _psname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FatherPsID
        {
            set { _fatherpsid = value; }
            get { return _fatherpsid; }
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
