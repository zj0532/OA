using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class PageSettingDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbPageSetting");
            strSql.Append(" where PsID=@PsID");
            SqlParameter[] parameters = {
					new SqlParameter("@PsID", SqlDbType.Int,4)
			};
            parameters[0].Value = PsID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 用户该页是否具备写权限
        /// </summary>
        /// <param name="UsID"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool ExistsAuthority(int UsID, string FileName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM [tbAuthority]");
            strSql.Append(" WHERE PSID=(SELECT PSID FROM tbPageSetting WHERE PSNAME='" + FileName + "') AND USID='"+UsID+"' AND  AUTHORITYPARAMID='2' ");

            return DbHelperSQL.Exists(strSql.ToString());
        
        }
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.PageSettingMOD model)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbPageSetting(");
            strSql.Append("PsAddress,PsName,FatherPsID,Remark)");
            strSql.Append(" values (");
            strSql.Append("@PsAddress,@PsName,@FatherPsID,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PsAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@PsName", SqlDbType.NVarChar,100),
					new SqlParameter("@FatherPsID", SqlDbType.NChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PsAddress;
            parameters[1].Value = model.PsName;
            parameters[2].Value = model.FatherPsID;
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
        public bool Update(MDL.PageSettingMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbPageSetting set ");
            strSql.Append("PsAddress=@PsAddress,");
            strSql.Append("PsName=@PsName,");
            strSql.Append("FatherPsID=@FatherPsID,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where PsID=@PsID");
            SqlParameter[] parameters = {
					new SqlParameter("@PsAddress", SqlDbType.NVarChar,300),
					new SqlParameter("@PsName", SqlDbType.NVarChar,100),
					new SqlParameter("@FatherPsID", SqlDbType.NChar,10),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@PsID", SqlDbType.Int,4)};
            parameters[0].Value = model.PsAddress;
            parameters[1].Value = model.PsName;
            parameters[2].Value = model.FatherPsID;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.PsID;

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
        public bool Delete(int PsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPageSetting ");
            strSql.Append(" where PsID=@PsID");
            SqlParameter[] parameters = {
					new SqlParameter("@PsID", SqlDbType.Int,4)
			};
            parameters[0].Value = PsID;

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
        public bool DeleteList(string PsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbPageSetting ");
            strSql.Append(" where PsID in (" + PsIDlist + ")  ");
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
        public MDL.PageSettingMOD GetModel(int PsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PsID,PsAddress,PsName,FatherPsID,Remark from tbPageSetting ");
            strSql.Append(" where PsID=@PsID");
            SqlParameter[] parameters = {
					new SqlParameter("@PsID", SqlDbType.Int,4)
			};
            parameters[0].Value = PsID;

            MDL.PageSettingMOD model = new MDL.PageSettingMOD();
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
        public MDL.PageSettingMOD DataRowToModel(DataRow row)
        {
            MDL.PageSettingMOD model = new MDL.PageSettingMOD();
            if (row != null)
            {
                if (row["PsID"] != null && row["PsID"].ToString() != "")
                {
                    model.PsID = int.Parse(row["PsID"].ToString());
                }
                if (row["PsAddress"] != null)
                {
                    model.PsAddress = row["PsAddress"].ToString();
                }
                if (row["PsName"] != null)
                {
                    model.PsName = row["PsName"].ToString();
                }
                if (row["FatherPsID"] != null)
                {
                    model.FatherPsID = row["FatherPsID"].ToString();
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
            strSql.Append("select PsID,PsAddress,PsName,FatherPsID,Remark ");
            strSql.Append(" FROM tbPageSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

       /// <summary>
       /// 获取
       /// </summary>
       /// <returns></returns>
        public DataSet GetListFather(int UsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PsID,PsAddress,PsName,FatherPsID,Remark ");
            strSql.Append(" FROM tbPageSetting ");
            strSql.Append(" where psid in ( SELECT [FatherPsID] ");
            strSql.Append(" FROM [tbPageSetting] where psid in ( ");
            strSql.Append(" SELECT [PsID] FROM [tbAuthority] where authorityparamid='1' and usid='"+UsID+"')) ");
            strSql.Append(" order by remark ");
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
            strSql.Append(" PsID,PsAddress,PsName,FatherPsID,Remark ");
            strSql.Append(" FROM tbPageSetting ");
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
            strSql.Append("select count(1) FROM tbPageSetting ");
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
                strSql.Append("order by T.PsID desc");
            }
            strSql.Append(")AS Row, T.*  from tbPageSetting T ");
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
            parameters[0].Value = "tbPageSetting";
            parameters[1].Value = "PsID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod



    }
}
