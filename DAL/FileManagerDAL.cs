using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class FileManagerDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FlID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbFileManager");
            strSql.Append(" where FlID=@FlID");
            SqlParameter[] parameters = {
					new SqlParameter("@FlID", SqlDbType.Int,4)
			};
            parameters[0].Value = FlID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.FileManagerMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbFileManager(");
            strSql.Append("FileName,FileContent,FileCode,FileDate,UsID,FCEID,FCID)");
            strSql.Append(" values (");
            strSql.Append("@FileName,@FileContent,@FileCode,@FileDate,@UsID,@FCEID,@FCID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileCode", SqlDbType.Image),
					new SqlParameter("@FileDate", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@FCEID", SqlDbType.Int,4),
					new SqlParameter("@FCID", SqlDbType.Int,4)};
            parameters[0].Value = model.FileName;
            parameters[1].Value = model.FileContent;
            parameters[2].Value = model.FileCode;
            parameters[3].Value = model.FileDate;
            parameters[4].Value = model.UsID;
            parameters[5].Value = model.FCEID;
            parameters[6].Value = model.FCID;

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
        public bool Update(MDL.FileManagerMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbFileManager set ");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FileContent=@FileContent,");
            strSql.Append("FileCode=@FileCode,");
            strSql.Append("FileDate=@FileDate,");
            strSql.Append("UsID=@UsID,");
            strSql.Append("FCEID=@FCEID,");
            strSql.Append("FCID=@FCID");
            strSql.Append(" where FlID=@FlID");
            SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@FileCode", SqlDbType.Image),
					new SqlParameter("@FileDate", SqlDbType.DateTime),
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@FCEID", SqlDbType.Int,4),
					new SqlParameter("@FCID", SqlDbType.Int,4),
					new SqlParameter("@FlID", SqlDbType.Int,4)};
            parameters[0].Value = model.FileName;
            parameters[1].Value = model.FileContent;
            parameters[2].Value = model.FileCode;
            parameters[3].Value = model.FileDate;
            parameters[4].Value = model.UsID;
            parameters[5].Value = model.FCEID;
            parameters[6].Value = model.FCID;
            parameters[7].Value = model.FlID;

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
        public bool Delete(int FlID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFileManager ");
            strSql.Append(" where FlID=@FlID");
            SqlParameter[] parameters = {
					new SqlParameter("@FlID", SqlDbType.Int,4)
			};
            parameters[0].Value = FlID;

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
        public bool DeleteList(string FlIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbFileManager ");
            strSql.Append(" where FlID in (" + FlIDlist + ")  ");
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
        public MDL.FileManagerMOD GetModel(int FlID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FlID,FileName,FileContent,FileCode,FileDate,UsID,FCEID,FCID from tbFileManager ");
            strSql.Append(" where FlID=@FlID");
            SqlParameter[] parameters = {
					new SqlParameter("@FlID", SqlDbType.Int,4)
			};
            parameters[0].Value = FlID;

            MDL.FileManagerMOD model = new MDL.FileManagerMOD();
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
        public MDL.FileManagerMOD DataRowToModel(DataRow row)
        {
            MDL.FileManagerMOD model = new MDL.FileManagerMOD();
            if (row != null)
            {
                if (row["FlID"] != null && row["FlID"].ToString() != "")
                {
                    model.FlID = int.Parse(row["FlID"].ToString());
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["FileContent"] != null)
                {
                    model.FileContent = row["FileContent"].ToString();
                }
                if (row["FileCode"] != null && row["FileCode"].ToString() != "")
                {
                    model.FileCode = (byte[])row["FileCode"];
                }
                if (row["FileDate"] != null && row["FileDate"].ToString() != "")
                {
                    model.FileDate = DateTime.Parse(row["FileDate"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["FCEID"] != null && row["FCEID"].ToString() != "")
                {
                    model.FCEID = int.Parse(row["FCEID"].ToString());
                }
                if (row["FCID"] != null && row["FCID"].ToString() != "")
                {
                    model.FCID = int.Parse(row["FCID"].ToString());
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
            strSql.Append("select FlID,FileName,FileContent,FileCode,FileDate,UsID,FCEID,FCID ");
            strSql.Append(" FROM tbFileManager ");
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
            strSql.Append(" FlID,FileName,FileContent,FileCode,FileDate,UsID,FCEID,FCID ");
            strSql.Append(" FROM tbFileManager ");
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
            strSql.Append("select count(1) FROM tbFileManager ");
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
                strSql.Append("order by T.FlID desc");
            }
            strSql.Append(")AS Row, T.*  from tbFileManager T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string Order ,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.NVarChar,100),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbFileManager";
            parameters[1].Value = "FlID";
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
