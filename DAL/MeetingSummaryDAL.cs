using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class MeetingSummaryDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbMeetingSummary");
            strSql.Append(" where MSID=@MSID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.MeetingSummaryMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMeetingSummary(");
            strSql.Append("MSTitle,MSDate,MSAddress,UsID,Compere,Joiner,MSContent,FileName,FileContent,Remark)");
            strSql.Append(" values (");
            strSql.Append("@MSTitle,@MSDate,@MSAddress,@UsID,@Compere,@Joiner,@MSContent,@FileName,@FileContent,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MSTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@MSDate", SqlDbType.DateTime),
					new SqlParameter("@MSAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Compere", SqlDbType.NVarChar,50),
					new SqlParameter("@Joiner", SqlDbType.NVarChar,50),
					new SqlParameter("@MSContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.MSTitle;
            parameters[1].Value = model.MSDate;
            parameters[2].Value = model.MSAddress;
            parameters[3].Value = model.UsID;
            parameters[4].Value = model.Compere;
            parameters[5].Value = model.Joiner;
            parameters[6].Value = model.MSContent;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.FileContent;
            parameters[9].Value = model.Remark;

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
        public bool Update(MDL.MeetingSummaryMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMeetingSummary set ");
            strSql.Append("MSTitle=@MSTitle,");
            strSql.Append("MSDate=@MSDate,");
            strSql.Append("MSAddress=@MSAddress,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("Compere=@Compere,");
            strSql.Append("Joiner=@Joiner,");
            strSql.Append("MSContent=@MSContent,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where MSID=@MSID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSTitle", SqlDbType.NVarChar,100),
					new SqlParameter("@MSDate", SqlDbType.DateTime),
					new SqlParameter("@MSAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Compere", SqlDbType.NVarChar,50),
					new SqlParameter("@Joiner", SqlDbType.NVarChar,50),
					new SqlParameter("@MSContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@MSID", SqlDbType.Int,4)};
            parameters[0].Value = model.MSTitle;
            parameters[1].Value = model.MSDate;
            parameters[2].Value = model.MSAddress;
            parameters[3].Value = model.UsID;
            parameters[4].Value = model.Compere;
            parameters[5].Value = model.Joiner;
            parameters[6].Value = model.MSContent;
            parameters[7].Value = model.FileName;
            parameters[8].Value = model.FileContent;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.MSID;

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
        public bool Delete(int MSID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMeetingSummary ");
            strSql.Append(" where MSID=@MSID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSID;

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
        public bool DeleteList(string MSIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMeetingSummary ");
            strSql.Append(" where MSID in (" + MSIDlist + ")  ");
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
        public MDL.MeetingSummaryMOD GetModel(int MSID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MSID,MSTitle,MSDate,MSAddress,UsID,Compere,Joiner,MSContent,FileName,FileContent,Remark from tbMeetingSummary ");
            strSql.Append(" where MSID=@MSID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSID;

            MDL.MeetingSummaryMOD model = new MDL.MeetingSummaryMOD();
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
        public MDL.MeetingSummaryMOD DataRowToModel(DataRow row)
        {
            MDL.MeetingSummaryMOD model = new MDL.MeetingSummaryMOD();
            if (row != null)
            {
                if (row["MSID"] != null && row["MSID"].ToString() != "")
                {
                    model.MSID = int.Parse(row["MSID"].ToString());
                }
                if (row["MSTitle"] != null)
                {
                    model.MSTitle = row["MSTitle"].ToString();
                }
                if (row["MSDate"] != null && row["MSDate"].ToString() != "")
                {
                    model.MSDate = DateTime.Parse(row["MSDate"].ToString());
                }
                if (row["MSAddress"] != null)
                {
                    model.MSAddress = row["MSAddress"].ToString();
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["Compere"] != null)
                {
                    model.Compere = row["Compere"].ToString();
                }
                if (row["Joiner"] != null)
                {
                    model.Joiner = row["Joiner"].ToString();
                }
                if (row["MSContent"] != null)
                {
                    model.MSContent = row["MSContent"].ToString();
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
            strSql.Append("select MSID,MSTitle,MSDate,MSAddress,UsID,Compere,Joiner,MSContent,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbMeetingSummary ");
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
            strSql.Append(" MSID,MSTitle,MSDate,MSAddress,UsID,Compere,Joiner,MSContent,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbMeetingSummary ");
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
            strSql.Append("select count(1) FROM tbMeetingSummary ");
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
                strSql.Append("order by T.MSID desc");
            }
            strSql.Append(")AS Row, T.*  from tbMeetingSummary T ");
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
            parameters[0].Value = "tbMeetingSummary";
            parameters[1].Value = "MSID";
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
