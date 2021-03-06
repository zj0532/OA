﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public  class PutInStoreBLL
    {
        private readonly DAL.PutInStoreDAL dal = new DAL.PutInStoreDAL();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PiID)
        {
            return dal.Exists(PiID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.PutInStoreMOD model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.PutInStoreMOD model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PiID)
        {

            return dal.Delete(PiID);
        }
     

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.PutInStoreMOD GetModel(int PiID)
        {

            return dal.GetModel(PiID);
        }

       

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDownLoadList(string strWhere)
        {
            return dal.GetDownLoadList(strWhere);
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
        public List<MDL.PutInStoreMOD> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MDL.PutInStoreMOD> DataTableToList(DataTable dt)
        {
            List<MDL.PutInStoreMOD> modelList = new List<MDL.PutInStoreMOD>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MDL.PutInStoreMOD model;
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
        public DataSet GetList(int PageSize, int PageIndex, string Order,string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, Order,strWhere);
        }

        #endregion  BasicMethod

    }
}
