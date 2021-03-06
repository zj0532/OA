﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class ShopClassDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ShopClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbShopClass");
            strSql.Append(" where ShopClassID=@ShopClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopClassID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShopClassID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.ShopClassMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbShopClass(");
            strSql.Append("ShopClassName,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ShopClassName,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ShopClassName;
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
        public bool Update(MDL.ShopClassMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbShopClass set ");
            strSql.Append("ShopClassName=@ShopClassName,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ShopClassID=@ShopClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@ShopClassID", SqlDbType.Int,4)};
            parameters[0].Value = model.ShopClassName;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.ShopClassID;

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
        public bool Delete(int ShopClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbShopClass ");
            strSql.Append(" where ShopClassID=@ShopClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopClassID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShopClassID;

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
        public bool DeleteList(string ShopClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbShopClass ");
            strSql.Append(" where ShopClassID in (" + ShopClassIDlist + ")  ");
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
        public MDL.ShopClassMOD GetModel(int ShopClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShopClassID,ShopClassName,Remark from tbShopClass ");
            strSql.Append(" where ShopClassID=@ShopClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopClassID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShopClassID;

            MDL.ShopClassMOD model = new MDL.ShopClassMOD();
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
        public MDL.ShopClassMOD DataRowToModel(DataRow row)
        {
            MDL.ShopClassMOD model = new MDL.ShopClassMOD();
            if (row != null)
            {
                if (row["ShopClassID"] != null && row["ShopClassID"].ToString() != "")
                {
                    model.ShopClassID = int.Parse(row["ShopClassID"].ToString());
                }
                if (row["ShopClassName"] != null)
                {
                    model.ShopClassName = row["ShopClassName"].ToString();
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
            strSql.Append("select ShopClassID,ShopClassName,Remark ");
            strSql.Append(" FROM tbShopClass ");
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
            strSql.Append(" ShopClassID,ShopClassName,Remark ");
            strSql.Append(" FROM tbShopClass ");
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
            strSql.Append("select count(1) FROM tbShopClass ");
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
                strSql.Append("order by T.ShopClassID desc");
            }
            strSql.Append(")AS Row, T.*  from tbShopClass T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string Order,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.NVarChar,200),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbShopClass";
            parameters[1].Value = "ShopClassID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = Order;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod


    }
}
