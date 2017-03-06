using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class MeetingSupplyDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MSUID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbMeetingSupply");
            strSql.Append(" where MSUID=@MSUID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSUID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSUID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.MeetingSupplyMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbMeetingSupply(");
            strSql.Append("MSID,UsID,Date,SuContent,FileName,FileContent,Remark)");
            strSql.Append(" values (");
            strSql.Append("@MSID,@UsID,@Date,@SuContent,@FileName,@FileContent,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MSID", SqlDbType.Int,4),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@SuContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.MSID;
            parameters[1].Value = model.UsID;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.SuContent;
            parameters[4].Value = model.FileName;
            parameters[5].Value = model.FileContent;
            parameters[6].Value = model.Remark;

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
        public bool Update(MDL.MeetingSupplyMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbMeetingSupply set ");
            strSql.Append("MSID=@MSID,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("Date=@Date,");
            strSql.Append("SuContent=@SuContent,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where MSUID=@MSUID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSID", SqlDbType.Int,4),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@SuContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@MSUID", SqlDbType.Int,4)};
            parameters[0].Value = model.MSID;
            parameters[1].Value = model.UsID;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.SuContent;
            parameters[4].Value = model.FileName;
            parameters[5].Value = model.FileContent;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.MSUID;

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
        public bool Delete(int MSUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMeetingSupply ");
            strSql.Append(" where MSUID=@MSUID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSUID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSUID;

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
        public bool DeleteList(string MSUIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbMeetingSupply ");
            strSql.Append(" where MSUID in (" + MSUIDlist + ")  ");
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
        public MDL.MeetingSupplyMOD GetModel(int MSUID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MSUID,MSID,UsID,Date,SuContent,FileName,FileContent,Remark from tbMeetingSupply ");
            strSql.Append(" where MSUID=@MSUID");
            SqlParameter[] parameters = {
					new SqlParameter("@MSUID", SqlDbType.Int,4)
			};
            parameters[0].Value = MSUID;

            MDL.MeetingSupplyMOD model = new MDL.MeetingSupplyMOD();
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
        public MDL.MeetingSupplyMOD DataRowToModel(DataRow row)
        {
            MDL.MeetingSupplyMOD model = new MDL.MeetingSupplyMOD();
            if (row != null)
            {
                if (row["MSUID"] != null && row["MSUID"].ToString() != "")
                {
                    model.MSUID = int.Parse(row["MSUID"].ToString());
                }
                if (row["MSID"] != null && row["MSID"].ToString() != "")
                {
                    model.MSID = int.Parse(row["MSID"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["SuContent"] != null)
                {
                    model.SuContent = row["SuContent"].ToString();
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
            strSql.Append("select MSUID,MSID,UsID,Date,SuContent,FileName,FileContent,Remark,(select UsName from tbUserInfo where usid=tbMeetingSupply.usid) as UsName ");
            strSql.Append(" FROM tbMeetingSupply ");
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
            strSql.Append(" MSUID,MSID,UsID,Date,SuContent,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbMeetingSupply ");
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
            strSql.Append("select count(1) FROM tbMeetingSupply ");
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
                strSql.Append("order by T.MSUID desc");
            }
            strSql.Append(")AS Row, T.*  from tbMeetingSupply T ");
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
            parameters[0].Value = "tbMeetingSupply";
            parameters[1].Value = "MSUID";
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
