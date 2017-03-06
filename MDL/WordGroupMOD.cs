using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public  class WordGroupMOD
    {

        #region Model
        private int _wordgroupid;
        private string _wordgroupname;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int WordGroupID
        {
            set { _wordgroupid = value; }
            get { return _wordgroupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WordGroupName
        {
            set { _wordgroupname = value; }
            get { return _wordgroupname; }
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
