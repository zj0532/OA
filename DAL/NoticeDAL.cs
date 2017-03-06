using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NoticeDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbNotice");
            strSql.Append(" where NoID=@NoID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoID", SqlDbType.Int,4)
			};
            parameters[0].Value = NoID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.NoticeMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbNotice(");
            strSql.Append("Title,NoContent,Date,EffectDateBefore,EffectDateEnd,UsID,NoticeClass,ClassValue,FileName,FileContent,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Title,@NoContent,@Date,@EffectDateBefore,@EffectDateEnd,@UsID,@NoticeClass,@ClassValue,@FileName,@FileContent,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NoContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@EffectDateBefore", SqlDbType.DateTime),
					new SqlParameter("@EffectDateEnd", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@NoticeClass", SqlDbType.Int,4),
					new SqlParameter("@ClassValue", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.NoContent;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.EffectDateBefore;
            parameters[4].Value = model.EffectDateEnd;
            parameters[5].Value = model.UsID;
            parameters[6].Value = model.NoticeClass;
            parameters[7].Value = model.ClassValue;
            parameters[8].Value = model.FileName;
            parameters[9].Value = model.FileContent;
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
        public bool Update(MDL.NoticeMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbNotice set ");
            strSql.Append("Title=@Title,");
            strSql.Append("NoContent=@NoContent,");
            strSql.Append("Date=@Date,");
            strSql.Append("EffectDateBefore=@EffectDateBefore,");
            strSql.Append("EffectDateEnd=@EffectDateEnd,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("NoticeClass=@NoticeClass,");
            strSql.Append("ClassValue=@ClassValue,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where NoID=@NoID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NoContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@EffectDateBefore", SqlDbType.DateTime),
					new SqlParameter("@EffectDateEnd", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@NoticeClass", SqlDbType.Int,4),
					new SqlParameter("@ClassValue", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FileContent", SqlDbType.Image),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@NoID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.NoContent;
            parameters[2].Value = model.Date;
            parameters[3].Value = model.EffectDateBefore;
            parameters[4].Value = model.EffectDateEnd;
            parameters[5].Value = model.UsID;
            parameters[6].Value = model.NoticeClass;
            parameters[7].Value = model.ClassValue;
            parameters[8].Value = model.FileName;
            parameters[9].Value = model.FileContent;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.NoID;

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
        public bool Delete(int NoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbNotice ");
            strSql.Append(" where NoID=@NoID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoID", SqlDbType.Int,4)
			};
            parameters[0].Value = NoID;

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
        public bool DeleteList(string NoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbNotice ");
            strSql.Append(" where NoID in (" + NoIDlist + ")  ");
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
        public MDL.NoticeMOD GetModel(int NoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NoID,Title,NoContent,Date,EffectDateBefore,EffectDateEnd,UsID,NoticeClass,ClassValue,FileName,FileContent,Remark from tbNotice ");
            strSql.Append(" where NoID=@NoID");
            SqlParameter[] parameters = {
					new SqlParameter("@NoID", SqlDbType.Int,4)
			};
            parameters[0].Value = NoID;

            MDL.NoticeMOD model = new MDL.NoticeMOD();
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
        public MDL.NoticeMOD DataRowToModel(DataRow row)
        {
            MDL.NoticeMOD model = new MDL.NoticeMOD();
            if (row != null)
            {
                if (row["NoID"] != null && row["NoID"].ToString() != "")
                {
                    model.NoID = int.Parse(row["NoID"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["NoContent"] != null)
                {
                    model.NoContent = row["NoContent"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["EffectDateBefore"] != null && row["EffectDateBefore"].ToString() != "")
                {
                    model.EffectDateBefore = DateTime.Parse(row["EffectDateBefore"].ToString());
                }
                if (row["EffectDateEnd"] != null && row["EffectDateEnd"].ToString() != "")
                {
                    model.EffectDateEnd = DateTime.Parse(row["EffectDateEnd"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["NoticeClass"] != null && row["NoticeClass"].ToString() != "")
                {
                    model.NoticeClass = int.Parse(row["NoticeClass"].ToString());
                }
                if (row["ClassValue"] != null)
                {
                    model.ClassValue = row["ClassValue"].ToString();
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
            strSql.Append("select NoID,Title,NoContent,Date,EffectDateBefore,EffectDateEnd,UsID,NoticeClass,ClassValue,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbNotice ");
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
            strSql.Append(" NoID,Title,NoContent,Date,EffectDateBefore,EffectDateEnd,UsID,NoticeClass,ClassValue,FileName,FileContent,Remark ");
            strSql.Append(" FROM tbNotice ");
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
            strSql.Append("select count(1) FROM tbNotice ");
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
                strSql.Append("order by T.NoID desc");
            }
            strSql.Append(")AS Row, T.*  from tbNotice T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string order,string strWhere)
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
            parameters[0].Value = "tbNotice";
            parameters[1].Value = "NoID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = order ;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod


    }
}
