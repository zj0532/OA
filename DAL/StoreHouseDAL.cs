using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StoreHouseDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ShID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbStoreHouse");
            strSql.Append(" where ShID=@ShID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.StoreHouseMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbStoreHouse(");
            strSql.Append("ShopName,ShopAmount,ShopClassID,Describe,Unit,Supplier,StID,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ShopName,@ShopAmount,@ShopClassID,@Describe,@Unit,@Supplier,@StID,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopName", SqlDbType.NVarChar,100),
					new SqlParameter("@ShopAmount", SqlDbType.Int,4),
					new SqlParameter("@ShopClassID", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,300),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,100),
					new SqlParameter("@StID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ShopName;
            parameters[1].Value = model.ShopAmount;
            parameters[2].Value = model.ShopClassID;
            parameters[3].Value = model.Describe;
            parameters[4].Value = model.Unit;
            parameters[5].Value = model.Supplier;
            parameters[6].Value = model.StID;
            parameters[7].Value = model.Remark;

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
        public bool Update(MDL.StoreHouseMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbStoreHouse set ");
            strSql.Append("ShopName=@ShopName,");
            strSql.Append("ShopAmount=@ShopAmount,");
            strSql.Append("ShopClassID=@ShopClassID,");
            strSql.Append("Describe=@Describe,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("StID=@StID,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ShID=@ShID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShopName", SqlDbType.NVarChar,100),
					new SqlParameter("@ShopAmount", SqlDbType.Int,4),
					new SqlParameter("@ShopClassID", SqlDbType.Int,4),
					new SqlParameter("@Describe", SqlDbType.NVarChar,300),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,100),
					new SqlParameter("@StID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,50),
					new SqlParameter("@ShID", SqlDbType.Int,4)};
            parameters[0].Value = model.ShopName;
            parameters[1].Value = model.ShopAmount;
            parameters[2].Value = model.ShopClassID;
            parameters[3].Value = model.Describe;
            parameters[4].Value = model.Unit;
            parameters[5].Value = model.Supplier;
            parameters[6].Value = model.StID;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.ShID;

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
        public bool Delete(int ShID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStoreHouse ");
            strSql.Append(" where ShID=@ShID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShID;

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
        public bool DeleteList(string ShIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbStoreHouse ");
            strSql.Append(" where ShID in (" + ShIDlist + ")  ");
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
        public MDL.StoreHouseMOD GetModel(int ShID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ShID,ShopName,ShopAmount,ShopClassID,Describe,Unit,Supplier,StID,Remark from tbStoreHouse ");
            strSql.Append(" where ShID=@ShID");
            SqlParameter[] parameters = {
					new SqlParameter("@ShID", SqlDbType.Int,4)
			};
            parameters[0].Value = ShID;

            MDL.StoreHouseMOD model = new MDL.StoreHouseMOD();
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
        public MDL.StoreHouseMOD DataRowToModel(DataRow row)
        {
            MDL.StoreHouseMOD model = new MDL.StoreHouseMOD();
            if (row != null)
            {
                if (row["ShID"] != null && row["ShID"].ToString() != "")
                {
                    model.ShID = int.Parse(row["ShID"].ToString());
                }
                if (row["ShopName"] != null)
                {
                    model.ShopName = row["ShopName"].ToString();
                }
                if (row["ShopAmount"] != null && row["ShopAmount"].ToString() != "")
                {
                    model.ShopAmount = int.Parse(row["ShopAmount"].ToString());
                }
                if (row["ShopClassID"] != null && row["ShopClassID"].ToString() != "")
                {
                    model.ShopClassID = int.Parse(row["ShopClassID"].ToString());
                }
                if (row["Describe"] != null)
                {
                    model.Describe = row["Describe"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
                if (row["StID"] != null && row["StID"].ToString() != "")
                {
                    model.StID = int.Parse(row["StID"].ToString());
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
            strSql.Append("select ShID,ShopName,ShopAmount,ShopClassID,Describe,Unit,Supplier,StID,Remark ");
            strSql.Append(" FROM tbStoreHouse ");
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
            strSql.Append(" ShID,ShopName,ShopAmount,ShopClassID,Describe,Unit,Supplier,StID,Remark ");
            strSql.Append(" FROM tbStoreHouse ");
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
            strSql.Append("select count(1) FROM tbStoreHouse ");
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
                strSql.Append("order by T.ShID desc");
            }
            strSql.Append(")AS Row, T.*  from tbStoreHouse T ");
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
                    new SqlParameter("@OrderType", SqlDbType.NVarChar,200),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbStoreHouse";
            parameters[1].Value = "ShID";
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
