﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public class NewEmplyeeKnowBLL
    {
       private readonly DAL.NewEmployeeKnowDAL dal = new DAL.NewEmployeeKnowDAL();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int NeID)
       {
           return dal.Exists(NeID);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(MDL.NewEmplyeeKnowMOD model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(MDL.NewEmplyeeKnowMOD model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(int NeID)
       {

           return dal.Delete(NeID);
       }
       

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public MDL.NewEmplyeeKnowMOD GetModel(int NeID)
       {

           return dal.GetModel(NeID);
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
       public List<MDL.NewEmplyeeKnowMOD> GetModelList(string strWhere)
       {
           DataSet ds = dal.GetList(strWhere);
           return DataTableToList(ds.Tables[0]);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<MDL.NewEmplyeeKnowMOD> DataTableToList(DataTable dt)
       {
           List<MDL.NewEmplyeeKnowMOD> modelList = new List<MDL.NewEmplyeeKnowMOD>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               MDL.NewEmplyeeKnowMOD model;
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
       public DataSet GetList(int PageSize, int PageIndex, string strOrder,string strWhere)
       {
           return dal.GetList(PageSize, PageIndex, strOrder, strWhere);
       }

       #endregion  BasicMethod

    }
}
