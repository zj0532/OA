﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class BusinessDAL
    {


        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BusinessID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbBusiness");
            strSql.Append(" where BusinessID=@BusinessID");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessID", SqlDbType.Int,4)
			};
            parameters[0].Value = BusinessID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.BusinessMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbBusiness(");
            strSql.Append("BusinessName,Remark)");
            strSql.Append(" values (");
            strSql.Append("@BusinessName,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.BusinessName;
            parameters[1].Value = model.Remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.BusinessMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbBusiness set ");
            strSql.Append("BusinessName=@BusinessName,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where BusinessID=@BusinessID");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessID", SqlDbType.Int,4)};
            parameters[0].Value = model.BusinessName;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.BusinessID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int BusinessID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBusiness ");
            strSql.Append(" where BusinessID=@BusinessID");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessID", SqlDbType.Int,4)
			};
            parameters[0].Value = BusinessID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string BusinessIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbBusiness ");
            strSql.Append(" where BusinessID in (" + BusinessIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.BusinessMOD GetModel(int BusinessID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BusinessID,BusinessName,Remark from tbBusiness ");
            strSql.Append(" where BusinessID=@BusinessID");
            SqlParameter[] parameters = {
					new SqlParameter("@BusinessID", SqlDbType.Int,4)
			};
            parameters[0].Value = BusinessID;

            MDL.BusinessMOD model = new MDL.BusinessMOD();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MDL.BusinessMOD DataRowToModel(DataRow row)
        {
            MDL.BusinessMOD model = new MDL.BusinessMOD();
            if (row != null)
            {
                if (row["BusinessID"] != null && row["BusinessID"].ToString() != "")
                {
                    model.BusinessID = int.Parse(row["BusinessID"].ToString());
                }
                if (row["BusinessName"] != null)
                {
                    model.BusinessName = row["BusinessName"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BusinessID,BusinessName,Remark ");
            strSql.Append(" FROM tbBusiness ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" BusinessID,BusinessName,Remark ");
            strSql.Append(" FROM tbBusiness ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tbBusiness ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.BusinessID desc");
            }
            strSql.Append(")AS Row, T.*  from tbBusiness T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

      
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strOrder,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.VarChar,255),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbBusiness";
            parameters[1].Value = "BusinessID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = strOrder;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod

    }
}
