using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class FileClassExplicitMOD
    {

        #region Model
        private int _fceid;
        private string _fcename;
        private int _fcid;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int FCEID
        {
            set { _fceid = value; }
            get { return _fceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FCEName
        {
            set { _fcename = value; }
            get { return _fcename; }
        }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
