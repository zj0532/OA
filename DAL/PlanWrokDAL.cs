using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class PlanWrokDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PWID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPlanWrok");
            strSql.Append(" where PWID=@PWID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.PlanWrokMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPlanWrok(");
            strSql.Append("UsID,PWTitle,Date,BusID,Stauts,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UsID,@PWTitle,@Date,@BusID,@Stauts,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PWTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@BusID", SqlDbType.Int,4),
					new SqlParameter("@Stauts", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PWTitle;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.BusID;
            parameters[4].Value = model.Stauts;
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
        public bool Update(MDL.PlanWrokMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPlanWrok set ");
            strSql.Append("UsID=@UsID,");
            strSql.Append("PWTitle=@PWTitle,");
            strSql.Append("Date=@Date,");
            strSql.Append("BusID=@BusID,");
            strSql.Append("Stauts=@Stauts,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where PWID=@PWID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PWTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@BusID", SqlDbType.Int,4),
					new SqlParameter("@Stauts", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@PWID", SqlDbType.Int,4)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PWTitle;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.BusID;
            parameters[4].Value = model.Stauts;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.PWID;

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
        public bool Delete(int PWID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPlanWrok ");
            strSql.Append(" where PWID=@PWID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWID;

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
        public bool DeleteList(string PWIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPlanWrok ");
            strSql.Append(" where PWID in (" + PWIDlist + ")  ");
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
        public MDL.PlanWrokMOD GetModel(int PWID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PWID,UsID,PWTitle,Date,BusID,Stauts,Remark from tbPlanWrok ");
            strSql.Append(" where PWID=@PWID");
            SqlParameter[] parameters = {
					new SqlParameter("@PWID", SqlDbType.Int,4)
			};
            parameters[0].Value = PWID;

            MDL.PlanWrokMOD model = new MDL.PlanWrokMOD();
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
        public MDL.PlanWrokMOD DataRowToModel(DataRow row)
        {
            MDL.PlanWrokMOD model = new MDL.PlanWrokMOD();
            if (row != null)
            {
                if (row["PWID"] != null && row["PWID"].ToString() != "")
                {
                    model.PWID = int.Parse(row["PWID"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["PWTitle"] != null)
                {
                    model.PWTitle = row["PWTitle"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["BusID"] != null && row["BusID"].ToString() != "")
                {
                    model.BusID = int.Parse(row["BusID"].ToString());
                }
                if (row["Stauts"] != null && row["Stauts"].ToString() != "")
                {
                    model.Stauts = int.Parse(row["Stauts"].ToString());
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
            strSql.Append("select PWID,UsID,PWTitle,Date,BusID,Stauts,Remark ");
            strSql.Append(" FROM tbPlanWrok ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页显示计划性加班历史记录
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public DataSet GetListByPage(int PageSize, int PageIndex,string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top " + PageSize + " *,(select count(date) from VW_GetPlanWorkRecord)as total from ");
            strSql.Append(" VW_GetPlanWorkRecord ");
            strSql.Append(" where pwlid not in ( select top (("+PageIndex+"-1)*"+PageSize+") pwlid from VW_GetPlanWorkRecord  ) ");
            if (sqlWhere != "")
            {
                strSql.Append(" and "+sqlWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet ExportListByWhere(string sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select pwtitle as 加班标题,UsName as 加班人,BeginDate as 加班开始时间,EndDate as 加班结束时间,hours as '总计(单位:小时)'  from ");
            strSql.Append(" VW_GetPlanWorkRecord ");
            strSql.Append(" where 1=1 ");
            if (sqlWhere != "")
            {
                strSql.Append(" and " + sqlWhere);
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
            strSql.Append(" PWID,UsID,PWTitle,Date,BusID,Stauts,Remark ");
            strSql.Append(" FROM tbPlanWrok ");
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
            strSql.Append("select count(1) FROM tbPlanWrok ");
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
                strSql.Append("order by T.PWID desc");
            }
            strSql.Append(")AS Row, T.*  from tbPlanWrok T ");
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
            parameters[0].Value = "tbPlanWrok";
            parameters[1].Value = "PWID";
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
