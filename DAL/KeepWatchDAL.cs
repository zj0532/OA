using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class KeepWatchDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KWID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbKeepWatch");
            strSql.Append(" where KWID=@KWID");
            SqlParameter[] parameters = {
					new SqlParameter("@KWID", SqlDbType.Int,4)
			};
            parameters[0].Value = KWID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.KeepWatchMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbKeepWatch(");
            strSql.Append("KWTitle,DepartmentID,UsID,Date,BeginDate,EndDate,FileName,FileContent,Remark)");
            strSql.Append(" values (");
            strSql.Append("@KWTitle,@DepartmentID,@UsID,@Date,@BeginDate,@EndDate,@FileName,@FileContent,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@KWTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KWTitle;
            parameters[1].Value = model.DepartmentID;
            parameters[2].Value = model.UsID;
            parameters[3].Value = model.Date;
            parameters[4].Value = model.BeginDate;
            parameters[5].Value = model.EndDate;
            parameters[6].Value = model.FileName;
            parameters[7].Value = model.FileContent;
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
        public bool Update(MDL.KeepWatchMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbKeepWatch set ");
            strSql.Append("KWTitle=@KWTitle,");
            strSql.Append("DepartmentID=@DepartmentID,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("Date=@Date,");
            strSql.Append("BeginDate=@BeginDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where KWID=@KWID");
            SqlParameter[] parameters = {
					new SqlParameter("@KWTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@KWID", SqlDbType.Int,4)};
            parameters[0].Value = model.KWTitle;
            parameters[1].Value = model.DepartmentID;
            parameters[2].Value = model.UsID;
            parameters[3].Value = model.Date;
            parameters[4].Value = model.BeginDate;
            parameters[5].Value = model.EndDate;
            parameters[6].Value = model.FileName;
            parameters[7].Value = model.FileContent;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.KWID;

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
        public bool Delete(int KWID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbKeepWatch ");
            strSql.Append(" where KWID=@KWID");
            SqlParameter[] parameters = {
					new SqlParameter("@KWID", SqlDbType.Int,4)
			};
            parameters[0].Value = KWID;

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
        public bool DeleteList(string KWIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbKeepWatch ");
            strSql.Append(" where KWID in (" + KWIDlist + ")  ");
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
        public MDL.KeepWatchMOD GetModel(int KWID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KWID,KWTitle,DepartmentID,UsID,Date,BeginDate,EndDate,FileName,FileContent,Remark from tbKeepWatch ");
            strSql.Append(" where KWID=@KWID");
            SqlParameter[] parameters = {
					new SqlParameter("@KWID", SqlDbType.Int,4)
			};
            parameters[0].Value = KWID;

            MDL.KeepWatchMOD model = new MDL.KeepWatchMOD();
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
        public MDL.KeepWatchMOD DataRowToModel(DataRow row)
        {
            MDL.KeepWatchMOD model = new MDL.KeepWatchMOD();
            if (row != null)
            {
                if (row["KWID"] != null && row["KWID"].ToString() != "")
                {
                    model.KWID = int.Parse(row["KWID"].ToString());
                }
                if (row["KWTitle"] != null)
                {
                    model.KWTitle = row["KWTitle"].ToString();
                }
                if (row["DepartmentID"] != null && row["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(row["DepartmentID"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["BeginDate"] != null && row["BeginDate"].ToString() != "")
                {
                    model.BeginDate = DateTime.Parse(row["BeginDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
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
            strSql.Append("select KWID,KWTitle,DepartmentID,UsID,Date,BeginDate,EndDate,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbKeepWatch ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListTotal(string strWhere,string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select KWID,KWTitle,DepartmentID,UsID,Date,BeginDate,EndDate,FileName,FileContent,Remark ");
            strSql.Append(",(select count(*) from tbKeepWatch ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) as total");
            strSql.Append(" FROM tbKeepWatch ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append( order );
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
            strSql.Append(" KWID,KWTitle,DepartmentID,UsID,Date,BeginDate,EndDate,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbKeepWatch ");
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
            strSql.Append("select count(1) FROM tbKeepWatch ");
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
                strSql.Append("order by T.KWID desc");
            }
            strSql.Append(")AS Row, T.*  from tbKeepWatch T ");
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
            parameters[0].Value = "tbKeepWatch";
            parameters[1].Value = "KWID";
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
