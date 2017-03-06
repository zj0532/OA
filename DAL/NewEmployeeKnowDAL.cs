﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class NewEmployeeKnowDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbNewKmployeeKnow");
            strSql.Append(" where NeID=@NeID");
            SqlParameter[] parameters = {
					new SqlParameter("@NeID", SqlDbType.Int,4)
			};
            parameters[0].Value = NeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.NewEmplyeeKnowMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbNewKmployeeKnow(");
            strSql.Append("Title,NeContent,Date,UsID,BusinessID,FileName,FileContent,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Title,@NeContent,@Date,@UsID,@BusinessID,@FileName,@FileContent,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NeContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@BusinessID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.NeContent;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.UsID;
            parameters[4].Value = model.BusinessID;
            parameters[5].Value = model.FileName;
            parameters[6].Value = model.FileContent;
            parameters[7].Value = model.Remark;

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
        public bool Update(MDL.NewEmplyeeKnowMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbNewKmployeeKnow set ");
            strSql.Append("Title=@Title,");
            strSql.Append("NeContent=@NeContent,");
            strSql.Append("Date=@Date,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("BusinessID=@BusinessID,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where NeID=@NeID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NeContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@BusinessID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@NeID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.NeContent;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.UsID;
            parameters[4].Value = model.BusinessID;
            parameters[5].Value = model.FileName;
            parameters[6].Value = model.FileContent;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.NeID;

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
        public bool Delete(int NeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbNewKmployeeKnow ");
            strSql.Append(" where NeID=@NeID");
            SqlParameter[] parameters = {
					new SqlParameter("@NeID", SqlDbType.Int,4)
			};
            parameters[0].Value = NeID;

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
        public bool DeleteList(string NeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbNewKmployeeKnow ");
            strSql.Append(" where NeID in (" + NeIDlist + ")  ");
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
        public MDL.NewEmplyeeKnowMOD GetModel(int NeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NeID,Title,NeContent,Date,UsID,BusinessID,FileName,FileContent,Remark from tbNewKmployeeKnow ");
            strSql.Append(" where NeID=@NeID");
            SqlParameter[] parameters = {
					new SqlParameter("@NeID", SqlDbType.Int,4)
			};
            parameters[0].Value = NeID;

            MDL.NewEmplyeeKnowMOD model = new MDL.NewEmplyeeKnowMOD();
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
        public MDL.NewEmplyeeKnowMOD DataRowToModel(DataRow row)
        {
            MDL.NewEmplyeeKnowMOD model = new MDL.NewEmplyeeKnowMOD();
            if (row != null)
            {
                if (row["NeID"] != null && row["NeID"].ToString() != "")
                {
                    model.NeID = int.Parse(row["NeID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["NeContent"] != null)
                {
                    model.NeContent = row["NeContent"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["BusinessID"] != null && row["BusinessID"].ToString() != "")
                {
                    model.BusinessID = int.Parse(row["BusinessID"].ToString());
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["FileContent"] != null && row["FileContent"].ToString() != "")
                {
                    model.FileContent = (byte[])row["FileContent"];
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
            strSql.Append("select NeID,Title,NeContent,Date,UsID,BusinessID,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbNewKmployeeKnow ");
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
            strSql.Append(" NeID,Title,NeContent,Date,UsID,BusinessID,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbNewKmployeeKnow ");
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
            strSql.Append("select count(1) FROM tbNewKmployeeKnow ");
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
                strSql.Append("order by T.NeID desc");
            }
            strSql.Append(")AS Row, T.*  from tbNewKmployeeKnow T ");
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
            parameters[0].Value = "tbNewKmployeeKnow";
            parameters[1].Value = "NeID";
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
