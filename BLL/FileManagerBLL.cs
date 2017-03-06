using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
     public class FileManagerBLL
    {
         private readonly DAL.FileManagerDAL dal = new DAL.FileManagerDAL();
         #region  BasicMethod
         /// <summary>
         /// 是否存在该记录
         /// </summary>
         public bool Exists(int FlID)
         {
             return dal.Exists(FlID);
         }

         /// <summary>
         /// 增加一条数据
         /// </summary>
         public int Add(MDL.FileManagerMOD model)
         {
             return dal.Add(model);
         }

         /// <summary>
         /// 更新一条数据
         /// </summary>
         public bool Update(MDL.FileManagerMOD model)
         {
             return dal.Update(model);
         }

         /// <summary>
         /// 删除一条数据
         /// </summary>
         public bool Delete(int FlID)
         {

             return dal.Delete(FlID);
         }
      

         /// <summary>
         /// 得到一个对象实体
         /// </summary>
         public MDL.FileManagerMOD GetModel(int FlID)
         {

             return dal.GetModel(FlID);
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
         public List<MDL.FileManagerMOD> GetModelList(string strWhere)
         {
             DataSet ds = dal.GetList(strWhere);
             return DataTableToList(ds.Tables[0]);
         }
         /// <summary>
         /// 获得数据列表
         /// </summary>
         public List<MDL.FileManagerMOD> DataTableToList(DataTable dt)
         {
             List<MDL.FileManagerMOD> modelList = new List<MDL.FileManagerMOD>();
             int rowsCount = dt.Rows.Count;
             if (rowsCount > 0)
             {
                 MDL.FileManagerMOD model;
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
         public DataSet GetList(int PageSize, int PageIndex, string order ,string strWhere)
         {
             return dal.GetList(PageSize, PageIndex, order, strWhere);
         }

         #endregion  BasicMethod

    }
}
