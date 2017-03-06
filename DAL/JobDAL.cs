using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class JobDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int JobID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbJob");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.JobMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbJob(");
            strSql.Append("JobName,Remark)");
            strSql.Append(" values (");
            strSql.Append("@JobName,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@JobName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.JobName;
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
        public bool Update(MDL.JobMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbJob set ");
            strSql.Append("JobName=@JobName,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@JobID", SqlDbType.Int,4)};
            parameters[0].Value = model.JobName;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.JobID;

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
        public bool Delete(int JobID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbJob ");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobID;

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
        public bool DeleteList(string JobIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbJob ");
            strSql.Append(" where JobID in (" + JobIDlist + ")  ");
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
        public MDL.JobMOD GetModel(int JobID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JobID,JobName,Remark from tbJob ");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.Int,4)
			};
            parameters[0].Value = JobID;

            MDL.JobMOD model = new MDL.JobMOD();
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
        public MDL.JobMOD DataRowToModel(DataRow row)
        {
            MDL.JobMOD model = new MDL.JobMOD();
            if (row != null)
            {
                if (row["JobID"] != null && row["JobID"].ToString() != "")
                {
                    model.JobID = int.Parse(row["JobID"].ToString());
                }
                if (row["JobName"] != null)
                {
                    model.JobName = row["JobName"].ToString();
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
            strSql.Append("select JobID,JobName,Remark ");
            strSql.Append(" FROM tbJob ");
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
            strSql.Append(" JobID,JobName,Remark ");
            strSql.Append(" FROM tbJob ");
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
            strSql.Append("select count(1) FROM tbJob ");
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
                strSql.Append("order by T.JobID desc");
            }
            strSql.Append(")AS Row, T.*  from tbJob T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string srtOrder,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.VarChar, 255),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbJob";
            parameters[1].Value = "JobID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = srtOrder;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod

    }
}
