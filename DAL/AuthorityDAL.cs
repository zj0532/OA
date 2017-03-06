using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public  class AuthorityDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AuID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbAuthority");
            strSql.Append(" where AuID=@AuID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.AuthorityMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbAuthority(");
            strSql.Append("UsID,PsID,AuthorityParamID,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UsID,@PsID,@AuthorityParamID,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PsID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityParamID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PsID;
            parameters[2].Value = model.AuthorityParamID;
            parameters[3].Value = model.Remark;

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
        public bool Update(MDL.AuthorityMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbAuthority set ");
            strSql.Append("UsID=@UsID,");
            strSql.Append("PsID=@PsID,");
            strSql.Append("AuthorityParamID=@AuthorityParamID,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where AuID=@AuID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PsID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityParamID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@AuID", SqlDbType.Int,4)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PsID;
            parameters[2].Value = model.AuthorityParamID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.AuID;

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
        public bool Delete(int AuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAuthority ");
            strSql.Append(" where AuID=@AuID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuID;

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
        /// 删除数据通过Usid
        /// </summary>
        public bool DeleteByUsID(int UsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAuthority ");
            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4)
			};
            parameters[0].Value = UsID;

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
        public bool DeleteList(string AuIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAuthority ");
            strSql.Append(" where AuID in (" + AuIDlist + ")  ");
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
        public MDL.AuthorityMOD GetModel(int AuID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AuID,UsID,PsID,AuthorityParamID,Remark from tbAuthority ");
            strSql.Append(" where AuID=@AuID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuID", SqlDbType.Int,4)
			};
            parameters[0].Value = AuID;

            MDL.AuthorityMOD model = new MDL.AuthorityMOD();
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
        public MDL.AuthorityMOD DataRowToModel(DataRow row)
        {
            MDL.AuthorityMOD model = new MDL.AuthorityMOD();
            if (row != null)
            {
                if (row["AuID"] != null && row["AuID"].ToString() != "")
                {
                    model.AuID = int.Parse(row["AuID"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["PsID"] != null && row["PsID"].ToString() != "")
                {
                    model.PsID = int.Parse(row["PsID"].ToString());
                }
                if (row["AuthorityParamID"] != null && row["AuthorityParamID"].ToString() != "")
                {
                    model.AuthorityParamID = int.Parse(row["AuthorityParamID"].ToString());
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
            strSql.Append("select AuID,UsID,PsID,AuthorityParamID,Remark ");
            strSql.Append(" FROM tbAuthority ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByUsID(int UsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" (select psname from  tbpagesetting where psid=a.psid) ");
            strSql.Append(" +(select authorityparamname from tbauthorityparam where authorityparamid=a.authorityparamid ) ");
            strSql.Append(" as name ");
            strSql.Append(" from [tbAuthority] as a where UsID='"+UsID+"' ");
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
            strSql.Append(" AuID,UsID,PsID,AuthorityParamID,Remark ");
            strSql.Append(" FROM tbAuthority ");
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
            strSql.Append("select count(1) FROM tbAuthority ");
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
                strSql.Append("order by T.AuID desc");
            }
            strSql.Append(")AS Row, T.*  from tbAuthority T ");
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
            parameters[0].Value = "tbAuthority";
            parameters[1].Value = "AuID";
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
