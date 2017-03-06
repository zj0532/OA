using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public class ServerStyleMOD
    {

        #region Model
        private int _serverstyleid;
        private string _serverstylename;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int ServerStyleID
        {
            set { _serverstyleid = value; }
            get { return _serverstyleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServerStyleName
        {
            set { _serverstylename = value; }
            get { return _serverstylename; }
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
