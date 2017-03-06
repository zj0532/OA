using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class ServerStyleDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ServerStyleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbServerStyle");
            strSql.Append(" where ServerStyleID=@ServerStyleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServerStyleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.ServerStyleMOD model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbServerStyle(");
            strSql.Append("ServerStyleName,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ServerStyleName,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ServerStyleName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ServerStyleName;
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
        public bool Update(MDL.ServerStyleMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbServerStyle set ");
            strSql.Append("ServerStyleName=@ServerStyleName,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ServerStyleID=@ServerStyleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ServerStyleName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4)};
            parameters[0].Value = model.ServerStyleName;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.ServerStyleID;

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
        public bool Delete(int ServerStyleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbServerStyle ");
            strSql.Append(" where ServerStyleID=@ServerStyleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServerStyleID;

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
        public bool DeleteList(string ServerStyleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbServerStyle ");
            strSql.Append(" where ServerStyleID in (" + ServerStyleIDlist + ")  ");
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
        public MDL.ServerStyleMOD GetModel(int ServerStyleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ServerStyleID,ServerStyleName,Remark from tbServerStyle ");
            strSql.Append(" where ServerStyleID=@ServerStyleID");
            SqlParameter[] parameters = {
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4)
			};
            parameters[0].Value = ServerStyleID;

            MDL.ServerStyleMOD model = new MDL.ServerStyleMOD();
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
        public MDL.ServerStyleMOD DataRowToModel(DataRow row)
        {
            MDL.ServerStyleMOD model = new MDL.ServerStyleMOD();
            if (row != null)
            {
                if (row["ServerStyleID"] != null && row["ServerStyleID"].ToString() != "")
                {
                    model.ServerStyleID = int.Parse(row["ServerStyleID"].ToString());
                }
                if (row["ServerStyleName"] != null)
                {
                    model.ServerStyleName = row["ServerStyleName"].ToString();
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
            strSql.Append("select ServerStyleID,ServerStyleName,Remark ");
            strSql.Append(" FROM tbServerStyle ");
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
            strSql.Append(" ServerStyleID,ServerStyleName,Remark ");
            strSql.Append(" FROM tbServerStyle ");
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
            strSql.Append("select count(1) FROM tbServerStyle ");
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
                strSql.Append("order by T.ServerStyleID desc");
            }
            strSql.Append(")AS Row, T.*  from tbServerStyle T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
            parameters[0].Value = "tbServerStyle";
            parameters[1].Value = "ServerStyleID";
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
