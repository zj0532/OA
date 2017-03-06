using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class WorkPlanInfoDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WPIID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbWorkPlanInfo");
            strSql.Append(" where WPIID=@WPIID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPIID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPIID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.WorkPlanInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbWorkPlanInfo(");
            strSql.Append("WPID,WPIPlanInfo,ShouldDate,WPIContent,TruthDate,FileName,FileContent,Times,Remark)");
            strSql.Append(" values (");
            strSql.Append("@WPID,@WPIPlanInfo,@ShouldDate,@WPIContent,@TruthDate,@FileName,@FileContent,@Times,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WPID", SqlDbType.Int,4),
					new SqlParameter("@WPIPlanInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ShouldDate", SqlDbType.DateTime),
					new SqlParameter("@WPIContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@TruthDate", SqlDbType.DateTime),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Times", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.WPID;
            parameters[1].Value = model.WPIPlanInfo;
            parameters[2].Value = model.ShouldDate;
            parameters[3].Value = model.WPIContent;
            parameters[4].Value = model.TruthDate;
            parameters[5].Value = model.FileName;
            parameters[6].Value = model.FileContent;
            parameters[7].Value = model.Times;
            parameters[8].Value = model.Remark;

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
        public bool Update(MDL.WorkPlanInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbWorkPlanInfo set ");
            strSql.Append("WPID=@WPID,");
            strSql.Append("WPIPlanInfo=@WPIPlanInfo,");
            strSql.Append("ShouldDate=@ShouldDate,");
            strSql.Append("WPIContent=@WPIContent,");
            strSql.Append("TruthDate=@TruthDate,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Times=@Times,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where WPIID=@WPIID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPID", SqlDbType.Int,4),
					new SqlParameter("@WPIPlanInfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@ShouldDate", SqlDbType.DateTime),
					new SqlParameter("@WPIContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@TruthDate", SqlDbType.DateTime),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Times", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@WPIID", SqlDbType.Int,4)};
            parameters[0].Value = model.WPID;
            parameters[1].Value = model.WPIPlanInfo;
            parameters[2].Value = model.ShouldDate;
            parameters[3].Value = model.WPIContent;
            parameters[4].Value = model.TruthDate;
            parameters[5].Value = model.FileName;
            parameters[6].Value = model.FileContent;
            parameters[7].Value = model.Times;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.WPIID;

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
        public bool Delete(int WPIID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbWorkPlanInfo ");
            strSql.Append(" where WPIID=@WPIID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPIID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPIID;

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
        public bool DeleteList(string WPIIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbWorkPlanInfo ");
            strSql.Append(" where WPIID in (" + WPIIDlist + ")  ");
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
        public MDL.WorkPlanInfoMOD GetModel(int WPIID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WPIID,WPID,WPIPlanInfo,ShouldDate,WPIContent,TruthDate,FileName,FileContent,Times,Remark from tbWorkPlanInfo ");
            strSql.Append(" where WPIID=@WPIID");
            SqlParameter[] parameters = {
					new SqlParameter("@WPIID", SqlDbType.Int,4)
			};
            parameters[0].Value = WPIID;

            MDL.WorkPlanInfoMOD model = new MDL.WorkPlanInfoMOD();
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
        public MDL.WorkPlanInfoMOD DataRowToModel(DataRow row)
        {
            MDL.WorkPlanInfoMOD model = new MDL.WorkPlanInfoMOD();
            if (row != null)
            {
                if (row["WPIID"] != null && row["WPIID"].ToString() != "")
                {
                    model.WPIID = int.Parse(row["WPIID"].ToString());
                }
                if (row["WPID"] != null && row["WPID"].ToString() != "")
                {
                    model.WPID = int.Parse(row["WPID"].ToString());
                }
                if (row["WPIPlanInfo"] != null)
                {
                    model.WPIPlanInfo = row["WPIPlanInfo"].ToString();
                }
                if (row["ShouldDate"] != null && row["ShouldDate"].ToString() != "")
                {
                    model.ShouldDate = DateTime.Parse(row["ShouldDate"].ToString());
                }
                if (row["WPIContent"] != null)
                {
                    model.WPIContent = row["WPIContent"].ToString();
                }
                if (row["TruthDate"] != null && row["TruthDate"].ToString() != "")
                {
                    model.TruthDate = DateTime.Parse(row["TruthDate"].ToString());
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["FileContent"] != null && row["FileContent"].ToString() != "")
                {
                    model.FileContent = (byte[])row["FileContent"];
                }
                if (row["Times"] != null && row["Times"].ToString() != "")
                {
                    model.Times = int.Parse(row["Times"].ToString());
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
            strSql.Append("select WPIID,WPID,WPIPlanInfo,ShouldDate,WPIContent,TruthDate,FileName,FileContent,Times,Remark ");
            strSql.Append(" FROM tbWorkPlanInfo ");
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
            strSql.Append(" WPIID,WPID,WPIPlanInfo,ShouldDate,WPIContent,TruthDate,FileName,FileContent,Times,Remark ");
            strSql.Append(" FROM tbWorkPlanInfo ");
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
            strSql.Append("select count(1) FROM tbWorkPlanInfo ");
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
                strSql.Append("order by T.WPIID desc");
            }
            strSql.Append(")AS Row, T.*  from tbWorkPlanInfo T ");
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
            parameters[0].Value = "tbWorkPlanInfo";
            parameters[1].Value = "WPIID";
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
