using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
   public class UserInfoBLL
    {
       private readonly DAL.UserInfoDAL dal = new DAL.UserInfoDAL();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UsID)
        {
            return dal.Exists(UsID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>MDL.UserInfoMOD
        public int Add(MDL.UserInfoMOD model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.UserInfoMOD model)
        {
            return dal.Update(model);
        }

        public bool UpdatePwd(string UserPwd, int UserID)
        {

            return dal.UpdatePwd(UserPwd, UserID);
        }


        public bool UpdateHolidaySetting(string Usid, string NianJia, string TiaoXiu)
        {

            return dal.UpdateHolidaySetting(Usid, NianJia, TiaoXiu);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UsID)
        {

            return dal.Delete(UsID);
        }

       /// <summary>
       /// 导出信息
       /// </summary>
       /// <returns></returns>
        public DataTable GetUserListByExport()
        {
           return  dal.GetUserListByExport();
        
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.UserInfoMOD GetModel(int UsID)
        {

            return dal.GetModel(UsID);
        }

        public MDL.UserInfoMOD GetModel(string UsName)
        {

            return dal.GetModel(UsName);
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
        public List<MDL.UserInfoMOD> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MDL.UserInfoMOD> DataTableToList(DataTable dt)
        {
            List<MDL.UserInfoMOD> modelList = new List<MDL.UserInfoMOD>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MDL.UserInfoMOD model;
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
        public DataSet GetList(int PageSize, int PageIndex,string strOrder, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strOrder, strWhere);
        }

        public bool insert()
        {
            return dal.insert();
        }

        public DataSet GetCountList(string strWhere)
        {
            return dal.GetCountList(strWhere);
        }

        #endregion  BasicMethod


    }
}
