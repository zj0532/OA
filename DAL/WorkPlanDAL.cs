using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class WorkPlanDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WPID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbWorkPlan");
            strSql.Append(" where WPID=@WPID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.WorkPlanMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbWorkPlan(");
            strSql.Append("WPTitle,Cycle,BeginDate,EndDate,UsID,CreateDate,WPContent,FileName,FileContent,IsDel,Remark)");
            strSql.Append(" values (");
            strSql.Append("@WPTitle,@Cycle,@BeginDate,@EndDate,@UsID,@CreateDate,@WPContent,@FileName,@FileContent,@IsDel,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WPTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@Cycle", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@WPContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.WPTitle;
            parameters[1].Value = model.Cycle;
            parameters[2].Value = model.BeginDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.UsID;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.WPContent;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.FileContent;
            parameters[9].Value = model.IsDel;
            parameters[10].Value = model.Remark;

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
        public bool Update(MDL.WorkPlanMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbWorkPlan set ");
            strSql.Append("WPTitle=@WPTitle,");
            strSql.Append("Cycle=@Cycle,");
            strSql.Append("BeginDate=@BeginDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("WPContent=@WPContent,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("IsDel=@IsDel,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where WPID=@WPID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@Cycle", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@WPContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@WPID", SqlDbType.Int,4)};
            parameters[0].Value = model.WPTitle;
            parameters[1].Value = model.Cycle;
            parameters[2].Value = model.BeginDate;
            parameters[3].Value = model.EndDate;
            parameters[4].Value = model.UsID;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.WPContent;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.FileContent;
            parameters[9].Value = model.IsDel;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.WPID;

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
        public bool Delete(int WPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbWorkPlan ");
            strSql.Append(" where WPID=@WPID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPID;

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
        public bool DeleteList(string WPIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbWorkPlan ");
            strSql.Append(" where WPID in (" + WPIDlist + ")  ");
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
        public MDL.WorkPlanMOD GetModel(int WPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WPID,WPTitle,Cycle,BeginDate,EndDate,UsID,CreateDate,WPContent,FileName,FileContent,IsDel,Remark from tbWorkPlan ");
            strSql.Append(" where WPID=@WPID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPID;

            MDL.WorkPlanMOD model = new MDL.WorkPlanMOD();
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
        public MDL.WorkPlanMOD DataRowToModel(DataRow row)
        {
            MDL.WorkPlanMOD model = new MDL.WorkPlanMOD();
            if (row != null)
            {
                if (row["WPID"] != null && row["WPID"].ToString() != "")
                {
                    model.WPID = int.Parse(row["WPID"].ToString());
                }
                if (row["WPTitle"] != null)
                {
                    model.WPTitle = row["WPTitle"].ToString();
                }
                if (row["Cycle"] != null)
                {
                    model.Cycle = row["Cycle"].ToString();
                }
                if (row["BeginDate"] != null && row["BeginDate"].ToString() != "")
                {
                    model.BeginDate = DateTime.Parse(row["BeginDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["WPContent"] != null)
                {
                    model.WPContent = row["WPContent"].ToString();
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["FileContent"] != null && row["FileContent"].ToString() != "")
                {
                    model.FileContent = (byte[])row["FileContent"];
                }
                if (row["IsDel"] != null && row["IsDel"].ToString() != "")
                {
                    model.IsDel = int.Parse(row["IsDel"].ToString());
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
        public DataSet GetListTotal(string strWhere,string Order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WPID,WPTitle,Cycle,BeginDate,EndDate,UsID,CreateDate,WPContent,FileName,FileContent,IsDel,Remark ");
            strSql.Append(",(select count(*) from tbWorkPlan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) as total ");
            strSql.Append(" FROM tbWorkPlan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(Order);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WPID,WPTitle,Cycle,BeginDate,EndDate,UsID,CreateDate,WPContent,FileName,FileContent,IsDel,Remark ");
           
            strSql.Append(" FROM tbWorkPlan ");
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
            strSql.Append(" WPID,WPTitle,Cycle,BeginDate,EndDate,UsID,CreateDate,WPContent,FileName,FileContent,IsDel,Remark ");
            strSql.Append(" FROM tbWorkPlan ");
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
            strSql.Append("select count(1) FROM tbWorkPlan ");
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
                strSql.Append("order by T.WPID desc");
            }
            strSql.Append(")AS Row, T.*  from tbWorkPlan T ");
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
        public DataSet GetList(int PageSize, int PageIndex, string strOrder, string strWhere)
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
            parameters[0].Value = "tbWorkPlan";
            parameters[1].Value = "WPID";
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
