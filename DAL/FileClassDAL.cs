using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class FileClassDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FCID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFileClass");
            strSql.Append(" where FCID=@FCID");
            SqlParameter[] parameters = {
					new SqlParameter("@FCID", SqlDbType.Int,4)
			};
            parameters[0].Value = FCID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.FileClassMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbFileClass(");
            strSql.Append("FCName,Remark)");
            strSql.Append(" values (");
            strSql.Append("@FCName,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FCName", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.FCName;
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
        public bool Update(MDL.FileClassMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbFileClass set ");
            strSql.Append("FCName=@FCName,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where FCID=@FCID");
            SqlParameter[] parameters = {
					new SqlParameter("@FCName", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@FCID", SqlDbType.Int,4)};
            parameters[0].Value = model.FCName;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.FCID;

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
        public bool Delete(int FCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFileClass ");
            strSql.Append(" where FCID=@FCID");
            SqlParameter[] parameters = {
					new SqlParameter("@FCID", SqlDbType.Int,4)
			};
            parameters[0].Value = FCID;

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
        public bool DeleteList(string FCIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFileClass ");
            strSql.Append(" where FCID in (" + FCIDlist + ")  ");
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
        public MDL.FileClassMOD GetModel(int FCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FCID,FCName,Remark from tbFileClass ");
            strSql.Append(" where FCID=@FCID");
            SqlParameter[] parameters = {
					new SqlParameter("@FCID", SqlDbType.Int,4)
			};
            parameters[0].Value = FCID;

            MDL.FileClassMOD model = new MDL.FileClassMOD();
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
        public MDL.FileClassMOD DataRowToModel(DataRow row)
        {
            MDL.FileClassMOD model = new MDL.FileClassMOD();
            if (row != null)
            {
                if (row["FCID"] != null && row["FCID"].ToString() != "")
                {
                    model.FCID = int.Parse(row["FCID"].ToString());
                }
                if (row["FCName"] != null)
                {
                    model.FCName = row["FCName"].ToString();
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
            strSql.Append("select FCID,FCName,Remark ");
            strSql.Append(" FROM tbFileClass ");
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
            strSql.Append(" FCID,FCName,Remark ");
            strSql.Append(" FROM tbFileClass ");
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
            strSql.Append("select count(1) FROM tbFileClass ");
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
                strSql.Append("order by T.FCID desc");
            }
            strSql.Append(")AS Row, T.*  from tbFileClass T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string Order ,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbFileClass";
            parameters[1].Value = "FCID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod

    }
}
