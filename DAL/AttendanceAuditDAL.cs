using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class AttendanceAuditDAL
    {

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AuditID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbAttendanceAudit");
            strSql.Append(" where AuditID=@AuditID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuditID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = AuditID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MDL.AttendanceAuditMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbAttendanceAudit(");
            strSql.Append("AuditID,JobID,AuditName,Remark,Days,Hours)");
            strSql.Append(" values (");
            strSql.Append("@AuditID,@JobID,@AuditName,@Remark,@Days,@Hours)");
            SqlParameter[] parameters = {
					new SqlParameter("@AuditID", SqlDbType.NVarChar,50),
					new SqlParameter("@JobID", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@Days", SqlDbType.Int,4),
					new SqlParameter("@Hours", SqlDbType.Int,4)};
            parameters[0].Value = model.AuditID;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.AuditName;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Days;
            parameters[5].Value = model.Hours;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.AttendanceAuditMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbAttendanceAudit set ");
            strSql.Append("AuditID=@AuditID,");
            strSql.Append("JobID=@JobID,");
            strSql.Append("AuditName=@AuditName,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Days=@Days,");
            strSql.Append("Hours=@Hours");
            strSql.Append(" where AuditID=@AuditID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuditID", SqlDbType.NVarChar,50),
					new SqlParameter("@JobID", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@Days", SqlDbType.Int,4),
					new SqlParameter("@Hours", SqlDbType.Int,4)};
            parameters[0].Value = model.AuditID;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.AuditName;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Days;
            parameters[5].Value = model.Hours;

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
        public bool Delete(string AuditID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAttendanceAudit ");
            strSql.Append(" where AuditID=@AuditID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuditID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = AuditID;

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
        public bool DeleteList(string AuditIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAttendanceAudit ");
            strSql.Append(" where AuditID in (" + AuditIDlist + ")  ");
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
        public MDL.AttendanceAuditMOD GetModel(string AuditID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AuditID,JobID,AuditName,Remark,Days,Hours from tbAttendanceAudit ");
            strSql.Append(" where AuditID=@AuditID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuditID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = AuditID;

            MDL.AttendanceAuditMOD model = new MDL.AttendanceAuditMOD();
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
        public MDL.AttendanceAuditMOD DataRowToModel(DataRow row)
        {
            MDL.AttendanceAuditMOD model = new MDL.AttendanceAuditMOD();
            if (row != null)
            {
                if (row["AuditID"] != null)
                {
                    model.AuditID = row["AuditID"].ToString();
                }
                if (row["JobID"] != null && row["JobID"].ToString() != "")
                {
                    model.JobID = int.Parse(row["JobID"].ToString());
                }
                if (row["AuditName"] != null)
                {
                    model.AuditName = row["AuditName"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Days"] != null && row["Days"].ToString() != "")
                {
                    model.Days = int.Parse(row["Days"].ToString());
                }
                if (row["Hours"] != null && row["Hours"].ToString() != "")
                {
                    model.Hours = int.Parse(row["Hours"].ToString());
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
            strSql.Append("select AuditID,JobID,AuditName,Remark,Days,Hours ");
            strSql.Append(" FROM tbAttendanceAudit ");
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
            strSql.Append(" AuditID,JobID,AuditName,Remark,Days,Hours ");
            strSql.Append(" FROM tbAttendanceAudit ");
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
            strSql.Append("select count(1) FROM tbAttendanceAudit ");
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
                strSql.Append("order by T.AuditID desc");
            }
            strSql.Append(")AS Row, T.*  from tbAttendanceAudit T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
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
            parameters[0].Value = "tbAttendanceAudit";
            parameters[1].Value = "AuditID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

    }
}
