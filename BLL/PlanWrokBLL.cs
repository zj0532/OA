using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public  class PlanWrokBLL
    {
       private readonly DAL.PlanWrokDAL dal = new DAL.PlanWrokDAL();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int PWID)
       {
           return dal.Exists(PWID);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(MDL.PlanWrokMOD model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(MDL.PlanWrokMOD model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(int PWID)
       {

           return dal.Delete(PWID);
       }
      

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public MDL.PlanWrokMOD GetModel(int PWID)
       {
           
           return dal.GetModel(PWID);
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

       public DataSet GetListByPage(int PageSize, int PageIndex, string sqlWhere)
       {
           return dal.GetListByPage(PageSize, PageIndex, sqlWhere);
       }

       /// <summary>
       /// 导出EXCEL表
       /// </summary>
       /// <param name="sqlWhere"></param>
       /// <returns></returns>
       public DataSet ExportListByWhere(string sqlWhere)
       {
           return dal.ExportListByWhere(sqlWhere);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<MDL.PlanWrokMOD> GetModelList(string strWhere)
       {
           DataSet ds = dal.GetList(strWhere);
           return DataTableToList(ds.Tables[0]);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<MDL.PlanWrokMOD> DataTableToList(DataTable dt)
       {
           List<MDL.PlanWrokMOD> modelList = new List<MDL.PlanWrokMOD>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               MDL.PlanWrokMOD model;
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
       public DataSet GetList(int PageSize, int PageIndex,string Order, string strWhere)
       {
           return dal.GetList(PageSize, PageIndex, Order,strWhere);
       }

       #endregion  BasicMethod



    }
}
