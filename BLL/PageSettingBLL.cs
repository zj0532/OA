using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public  class PageSettingBLL
    {
       private readonly DAL.PageSettingDAL dal = new DAL.PageSettingDAL();
       
           
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int PsID)
       {
           return dal.Exists(PsID);
       }


       /// <summary>
       /// 该用户是否对该页面具有写权限
       /// </summary>
       /// <param name="UsID"></param>
       /// <param name="FileName"></param>
       /// <returns></returns>
       public bool ExistsAuthority(int UsID, string FileName)
       {

           return dal.ExistsAuthority(UsID,FileName);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(MDL.PageSettingMOD model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(MDL.PageSettingMOD model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(int PsID)
       {

           return dal.Delete(PsID);
       }
       

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public MDL.PageSettingMOD GetModel(int PsID)
       {

           return dal.GetModel(PsID);
       }

      

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           return dal.GetList(strWhere);
       }
       /// <summary>
       /// 获得前几行数据
       /// </summary>
       public DataSet GetList(int Top, string strWhere, string filedOrder)
       {
           return dal.GetList(Top, strWhere, filedOrder);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<MDL.PageSettingMOD> GetModelList(string strWhere)
       {
           DataSet ds = dal.GetList(strWhere);
           return DataTableToList(ds.Tables[0]);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<MDL.PageSettingMOD> DataTableToList(DataTable dt)
       {
           List<MDL.PageSettingMOD> modelList = new List<MDL.PageSettingMOD>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               MDL.PageSettingMOD model;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = dal.DataRowToModel(dt.Rows[n]);
                   if (model != null)
                   {
                       modelList.Add(model);
                   }
               }
           }
           return modelList;
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetAllList()
       {
           return GetList("");
       }

       /// <summary>
       /// 分页获取数据列表
       /// </summary>
       public int GetRecordCount(string strWhere)
       {
           return dal.GetRecordCount(strWhere);
       }
       /// <summary>
       /// 分页获取数据列表
       /// </summary>
       public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
       {
           return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
       }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

       #endregion  BasicMethod

        #region 
       public string  GetMenu(int UsID)
       {
           StringBuilder str = new StringBuilder();
           DataTable dt = dal.GetListFather(UsID).Tables[0];

           DataTable sdt=null;
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               str.Append(" { ");
               str.Append(" 'menuid': '"+dt.Rows[i]["PsID"].ToString ()+"', 'icon': 'icon-sys', 'menuname': '"+dt.Rows[i]["PsName"].ToString ()+"', ");
               str.Append(" 'menus': [ ");

               sdt = dal.GetList(" FatherPsID='" + dt.Rows[i]["PsID"] + "' and  PsID in (select PsID from [tbAuthority] where UsID='"+UsID+"') order by PsID ").Tables[0];
               for (int j = 0; j < sdt.Rows.Count; j++)
               {
                   str.Append(" { 'menuid': '"+sdt.Rows[j]["PsID"].ToString()+"', 'menuname': '"+sdt.Rows[j]["PsName"].ToString ()+"', 'icon': 'icon-nav', 'url': '"+sdt.Rows[j]["PsAddress"].ToString ()+"' } ");
                   if (j != sdt.Rows.Count - 1)
                   {
                       str.Append(",");
                   }
               }
               str.Append(" ] }");
               if (i != dt.Rows.Count - 1)
               {
                   str.Append(" , ");
               }
           }

           return str.ToString();
       
       }

        #endregion

    }
}
