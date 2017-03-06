﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
     public  class PutInStoreDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PiID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPutInStore");
            strSql.Append(" where PiID=@PiID");
            SqlParameter[] parameters = {
					new SqlParameter("@PiID", SqlDbType.Int,4)
			};
            parameters[0].Value = PiID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.PutInStoreMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPutInStore(");
            strSql.Append("ShID,PiAmount,PiDate,PiUsID,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ShID,@PiAmount,@PiDate,@PiUsID,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShID", SqlDbType.Int,4),
					new SqlParameter("@PiAmount", SqlDbType.Int,4),
					new SqlParameter("@PiDate", SqlDbType.DateTime),
					new SqlParameter("@PiUsID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ShID;
            parameters[1].Value = model.PiAmount;
            parameters[2].Value = model.PiDate;
            parameters[3].Value = model.PiUsID;
            parameters[4].Value = model.Remark;

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
        public bool Update(MDL.PutInStoreMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPutInStore set ");
            strSql.Append("ShID=@ShID,");
            strSql.Append("PiAmount=@PiAmount,");
            strSql.Append("PiDate=@PiDate,");
            strSql.Append("PiUsID=@PiUsID,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where PiID=@PiID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShID", SqlDbType.Int,4),
					new SqlParameter("@PiAmount", SqlDbType.Int,4),
					new SqlParameter("@PiDate", SqlDbType.DateTime),
					new SqlParameter("@PiUsID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@PiID", SqlDbType.Int,4)};
            parameters[0].Value = model.ShID;
            parameters[1].Value = model.PiAmount;
            parameters[2].Value = model.PiDate;
            parameters[3].Value = model.PiUsID;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.PiID;

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
        public bool Delete(int PiID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPutInStore ");
            strSql.Append(" where PiID=@PiID");
            SqlParameter[] parameters = {
					new SqlParameter("@PiID", SqlDbType.Int,4)
			};
            parameters[0].Value = PiID;

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
        public bool DeleteList(string PiIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPutInStore ");
            strSql.Append(" where PiID in (" + PiIDlist + ")  ");
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
        public MDL.PutInStoreMOD GetModel(int PiID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PiID,ShID,PiAmount,PiDate,PiUsID,Remark from tbPutInStore ");
            strSql.Append(" where PiID=@PiID");
            SqlParameter[] parameters = {
					new SqlParameter("@PiID", SqlDbType.Int,4)
			};
            parameters[0].Value = PiID;

            MDL.PutInStoreMOD model = new MDL.PutInStoreMOD();
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
        public MDL.PutInStoreMOD DataRowToModel(DataRow row)
        {
            MDL.PutInStoreMOD model = new MDL.PutInStoreMOD();
            if (row != null)
            {
                if (row["PiID"] != null && row["PiID"].ToString() != "")
                {
                    model.PiID = int.Parse(row["PiID"].ToString());
                }
                if (row["ShID"] != null && row["ShID"].ToString() != "")
                {
                    model.ShID = int.Parse(row["ShID"].ToString());
                }
                if (row["PiAmount"] != null && row["PiAmount"].ToString() != "")
                {
                    model.PiAmount = int.Parse(row["PiAmount"].ToString());
                }
                if (row["PiDate"] != null && row["PiDate"].ToString() != "")
                {
                    model.PiDate = DateTime.Parse(row["PiDate"].ToString());
                }
                if (row["PiUsID"] != null && row["PiUsID"].ToString() != "")
                {
                    model.PiUsID = int.Parse(row["PiUsID"].ToString());
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
            strSql.Append("select PiID,ShID,PiAmount,PiDate,PiUsID,Remark ");
            strSql.Append(" FROM tbPutInStore ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 下载
        /// </summary>
        public DataSet GetDownLoadList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PiID] as 系统编号 ");
            strSql.Append(" ,(select shopname from tbStoreHouse where shid=pi.shid) as 物品名称 ");
            strSql.Append(" ,[PiAmount] as 入库数量 ");

            strSql.Append(" ,(select unit from tbStoreHouse where shid=pi.shid) as 计量单位 ");
            strSql.Append(" ,[PiDate] as 入库时间 ");
            strSql.Append(" ,(select usname from tbUserInfo where usid=pi.PiUsID) as 操作员 ");
            
            strSql.Append(" FROM tbPutInStore as pi ");
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
            strSql.Append(" PiID,ShID,PiAmount,PiDate,PiUsID,Remark ");
            strSql.Append(" FROM tbPutInStore ");
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
            strSql.Append("select count(1) FROM tbPutInStore ");
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
                strSql.Append("order by T.PiID desc");
            }
            strSql.Append(")AS Row, T.*  from tbPutInStore T ");
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
            parameters[0].Value = "tbPutInStore";
            parameters[1].Value = "PiID";
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
