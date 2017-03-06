using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDL
{
   public  class AuthorityMOD
    {
      
		#region Model
		private int _auid;
		private int _usid;
		private int _psid;
		private int _authorityparamid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int AuID
		{
			set{ _auid=value;}
			get{return _auid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UsID
		{
			set{ _usid=value;}
			get{return _usid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PsID
		{
			set{ _psid=value;}
			get{return _psid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AuthorityParamID
		{
			set{ _authorityparamid=value;}
			get{return _authorityparamid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model


    }
}
