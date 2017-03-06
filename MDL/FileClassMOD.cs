using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class FileClassMOD
    {

        #region Model
        private int _fcid;
        private string _fcname;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int FCID
        {
            set { _fcid = value; }
            get { return _fcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FCName
        {
            set { _fcname = value; }
            get { return _fcname; }
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
