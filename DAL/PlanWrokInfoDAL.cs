using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class PlanWrokInfoDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PWLID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPlanWrokInfo");
            strSql.Append(" where PWLID=@PWLID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWLID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWLID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.PlanWrokInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPlanWrokInfo(");
            strSql.Append("PWID,UsName,BeginDate,EndDate,Hours,Remark)");
            strSql.Append(" values (");
            strSql.Append("@PWID,@UsName,@BeginDate,@EndDate,@Hours,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PWID", SqlDbType.Int,4),
					new SqlParameter("@UsName", SqlDbType.NVarChar,20),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Hours", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.PWID;
            parameters[1].Value = model.UsName;
            parameters[2].Value = model.BeginDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.Hours;
            parameters[5].Value = model.Remark;

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
        public bool Update(MDL.PlanWrokInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPlanWrokInfo set ");
            strSql.Append("PWID=@PWID,");
            strSql.Append("UsName=@UsName,");
            strSql.Append("BeginDate=@BeginDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("Hours=@Hours,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where PWLID=@PWLID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWID", SqlDbType.Int,4),
					new SqlParameter("@UsName", SqlDbType.NVarChar,20),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Hours", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@PWLID", SqlDbType.Int,4)};
            parameters[0].Value = model.PWID;
            parameters[1].Value = model.UsName;
            parameters[2].Value = model.BeginDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.Hours;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.PWLID;

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
        public bool Delete(int PWLID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPlanWrokInfo ");
            strSql.Append(" where PWLID=@PWLID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWLID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWLID;

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
        public bool DeleteList(string PWLIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPlanWrokInfo ");
            strSql.Append(" where PWLID in (" + PWLIDlist + ")  ");
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
        public MDL.PlanWrokInfoMOD GetModel(int PWLID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PWLID,PWID,UsName,BeginDate,EndDate,Hours,Remark from tbPlanWrokInfo ");
            strSql.Append(" where PWLID=@PWLID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWLID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWLID;

            MDL.PlanWrokInfoMOD model = new MDL.PlanWrokInfoMOD();
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
        public MDL.PlanWrokInfoMOD DataRowToModel(DataRow row)
        {
            MDL.PlanWrokInfoMOD model = new MDL.PlanWrokInfoMOD();
            if (row != null)
            {
                if (row["PWLID"] != null && row["PWLID"].ToString() != "")
                {
                    model.PWLID = int.Parse(row["PWLID"].ToString());
                }
                if (row["PWID"] != null && row["PWID"].ToString() != "")
                {
                    model.PWID = int.Parse(row["PWID"].ToString());
                }
                if (row["UsName"] != null)
                {
                    model.UsName = row["UsName"].ToString();
                }
                if (row["BeginDate"] != null && row["BeginDate"].ToString() != "")
                {
                    model.BeginDate = DateTime.Parse(row["BeginDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["Hours"] != null)
                {
                    model.Hours = row["Hours"].ToString();
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
            strSql.Append("select PWLID,PWID,UsName,BeginDate,EndDate,Hours,Remark ");
            strSql.Append(" FROM tbPlanWrokInfo ");
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
            strSql.Append(" PWLID,PWID,UsName,BeginDate,EndDate,Hours,Remark ");
            strSql.Append(" FROM tbPlanWrokInfo ");
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
            strSql.Append("select count(1) FROM tbPlanWrokInfo ");
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
                strSql.Append("order by T.PWLID desc");
            }
            strSql.Append(")AS Row, T.*  from tbPlanWrokInfo T ");
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
            parameters[0].Value = "tbPlanWrokInfo";
            parameters[1].Value = "PWLID";
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
