using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
    public class PlanWrokMOD
    {
        #region Model
        private int _pwid;
        private int _usid;
        private string _pwtitle;
        private DateTime _date;
        private int _busid;
        private int _stauts;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int PWID
        {
            set { _pwid = value; }
            get { return _pwid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UsID
        {
            set { _usid = value; }
            get { return _usid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PWTitle
        {
            set { _pwtitle = value; }
            get { return _pwtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int BusID
        {
            set { _busid = value; }
            get { return _busid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Stauts
        {
            set { _stauts = value; }
            get { return _stauts; }
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
