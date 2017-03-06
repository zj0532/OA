using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public  class AttendanceDAL
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AtID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbAttendance");
            strSql.Append(" where AtID=@AtID");
            SqlParameter[] parameters = {
					new SqlParameter("@AtID", SqlDbType.Int,4)
			};
            parameters[0].Value = AtID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.AttendanceMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbAttendance(");
            strSql.Append("UsID,PostCause,PostDate,PostIP,Holiday,OneLevelAudit,TwoLevelAudit,BeginDate,EndDate,HolidayCalss,WorkContent,WorkPeson,Stauts,Remark)");
            strSql.Append(" values (");
            strSql.Append("@UsID,@PostCause,@PostDate,@PostIP,@Holiday,@OneLevelAudit,@TwoLevelAudit,@BeginDate,@EndDate,@HolidayCalss,@WorkContent,@WorkPeson,@Stauts,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PostCause", SqlDbType.NVarChar,60),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,60),
					new SqlParameter("@Holiday", SqlDbType.NVarChar,50),
					new SqlParameter("@OneLevelAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@TwoLevelAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.NVarChar,50),
					new SqlParameter("@EndDate", SqlDbType.NVarChar,50),
					new SqlParameter("@HolidayCalss", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkContent", SqlDbType.NVarChar,200),
					new SqlParameter("@WorkPeson", SqlDbType.NVarChar,200),
					new SqlParameter("@Stauts", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PostCause;
            parameters[2].Value = model.PostDate;
            parameters[3].Value = model.PostIP;
            parameters[4].Value = model.Holiday;
            parameters[5].Value = model.OneLevelAudit;
            parameters[6].Value = model.TwoLevelAudit;
            parameters[7].Value = model.BeginDate;
            parameters[8].Value = model.EndDate;
            parameters[9].Value = model.HolidayCalss;
            parameters[10].Value = model.WorkContent;
            parameters[11].Value = model.WorkPeson;
            parameters[12].Value = model.Stauts;
            parameters[13].Value = model.Remark;

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
        public bool Update(MDL.AttendanceMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbAttendance set ");
            strSql.Append("UsID=@UsID,");
            strSql.Append("PostCause=@PostCause,");
            strSql.Append("PostDate=@PostDate,");
            strSql.Append("PostIP=@PostIP,");
            strSql.Append("Holiday=@Holiday,");
            strSql.Append("OneLevelAudit=@OneLevelAudit,");
            strSql.Append("TwoLevelAudit=@TwoLevelAudit,");
            strSql.Append("BeginDate=@BeginDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("HolidayCalss=@HolidayCalss,");
            strSql.Append("WorkContent=@WorkContent,");
            strSql.Append("WorkPeson=@WorkPeson,");
            strSql.Append("Stauts=@Stauts,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where AtID=@AtID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4),
					new SqlParameter("@PostCause", SqlDbType.NVarChar,60),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,60),
					new SqlParameter("@Holiday", SqlDbType.NVarChar,50),
					new SqlParameter("@OneLevelAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@TwoLevelAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginDate", SqlDbType.NVarChar,50),
					new SqlParameter("@EndDate", SqlDbType.NVarChar,50),
					new SqlParameter("@HolidayCalss", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkContent", SqlDbType.NVarChar,200),
					new SqlParameter("@WorkPeson", SqlDbType.NVarChar,200),
					new SqlParameter("@Stauts", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@AtID", SqlDbType.Int,4)};
            parameters[0].Value = model.UsID;
            parameters[1].Value = model.PostCause;
            parameters[2].Value = model.PostDate;
            parameters[3].Value = model.PostIP;
            parameters[4].Value = model.Holiday;
            parameters[5].Value = model.OneLevelAudit;
            parameters[6].Value = model.TwoLevelAudit;
            parameters[7].Value = model.BeginDate;
            parameters[8].Value = model.EndDate;
            parameters[9].Value = model.HolidayCalss;
            parameters[10].Value = model.WorkContent;
            parameters[11].Value = model.WorkPeson;
            parameters[12].Value = model.Stauts;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.AtID;

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
        public bool Delete(int AtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAttendance ");
            strSql.Append(" where AtID=@AtID");
            SqlParameter[] parameters = {
					new SqlParameter("@AtID", SqlDbType.Int,4)
			};
            parameters[0].Value = AtID;

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
        public bool DeleteList(string AtIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbAttendance ");
            strSql.Append(" where AtID in (" + AtIDlist + ")  ");
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
        public MDL.AttendanceMOD GetModel(int AtID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AtID,UsID,PostCause,PostDate,PostIP,Holiday,OneLevelAudit,TwoLevelAudit,BeginDate,EndDate,HolidayCalss,WorkContent,WorkPeson,Stauts,Remark from tbAttendance ");
            strSql.Append(" where AtID=@AtID");
            SqlParameter[] parameters = {
					new SqlParameter("@AtID", SqlDbType.Int,4)
			};
            parameters[0].Value = AtID;

            MDL.AttendanceMOD model = new MDL.AttendanceMOD();
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
        public MDL.AttendanceMOD DataRowToModel(DataRow row)
        {
            MDL.AttendanceMOD model = new MDL.AttendanceMOD();
            if (row != null)
            {
                if (row["AtID"] != null && row["AtID"].ToString() != "")
                {
                    model.AtID = int.Parse(row["AtID"].ToString());
                }
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["PostCause"] != null)
                {
                    model.PostCause = row["PostCause"].ToString();
                }
                if (row["PostDate"] != null && row["PostDate"].ToString() != "")
                {
                    model.PostDate = DateTime.Parse(row["PostDate"].ToString());
                }
                if (row["PostIP"] != null)
                {
                    model.PostIP = row["PostIP"].ToString();
                }
                if (row["Holiday"] != null && row["Holiday"].ToString() != "")
                {
                    model.Holiday = row["Holiday"].ToString();
                }
                if (row["OneLevelAudit"] != null)
                {
                    model.OneLevelAudit = row["OneLevelAudit"].ToString();
                }
                if (row["TwoLevelAudit"] != null)
                {
                    model.TwoLevelAudit = row["TwoLevelAudit"].ToString();
                }
                if (row["BeginDate"] != null)
                {
                    model.BeginDate = row["BeginDate"].ToString();
                }
                if (row["EndDate"] != null)
                {
                    model.EndDate = row["EndDate"].ToString();
                }
                if (row["HolidayCalss"] != null)
                {
                    model.HolidayCalss = row["HolidayCalss"].ToString();
                }
                if (row["WorkContent"] != null)
                {
                    model.WorkContent = row["WorkContent"].ToString();
                }
                if (row["WorkPeson"] != null)
                {
                    model.WorkPeson = row["WorkPeson"].ToString();
                }
                if (row["Stauts"] != null && row["Stauts"].ToString() != "")
                {
                    model.Stauts = row["Stauts"].ToString();
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
            strSql.Append("select AtID,UsID,PostCause,PostDate,PostIP,Holiday,OneLevelAudit,TwoLevelAudit,BeginDate,EndDate,HolidayCalss,WorkContent,WorkPeson,Stauts,Remark,@@ROWCOUNT as total ");
            strSql.Append(" FROM tbAttendance ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

       /// <summary>
       /// 获取导出列表
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
        public DataSet GetListByChineseName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select usname from tbuserinfo where usid=ta.usid) as '员工姓名' ");
            strSql.Append(" ,CONVERT(varchar(100),PostDate, 20) as '提交请假申请时间',PostIP as '登陆IP',Holiday as '请假时长 （单位：天）' ");
            strSql.Append(" ,CONVERT(varchar(100),convert(datetime,BeginDate), 20) as '假期开始时间',CONVERT(varchar(100), convert(datetime, EndDate), 20) as '假期结束时间' ,HolidayCalss as '假期类别' ");
            strSql.Append(" ,WorkContent as '请假事由',WorkPeson as '工作交接', (select remark from tbAttendanceAudit where  Auditid =ta.Stauts) as '状态' ");

            strSql.Append(" FROM tbAttendance as ta ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetListByJBChineseName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (select usname from tbuserinfo where usid=ta.usid) as '员工姓名' ");
            strSql.Append(" ,CONVERT(varchar(100),PostDate, 20) as '提交加班申请时间',PostIP as '登陆IP',Holiday as '加班时长 （单位：小时）' ");
            strSql.Append(" ,CONVERT(varchar(100),convert(datetime,BeginDate), 20) as '加班开始时间',CONVERT(varchar(100),convert(datetime,EndDate), 20) as '加班结束时间' ,HolidayCalss as '申请类别' ");
            strSql.Append(" ,WorkContent as '加班事由',WorkPeson as '加班见证人', (select remark from tbAttendanceAudit where  Auditid =ta.Stauts) as '状态' ");

            strSql.Append(" FROM tbAttendance as ta ");
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
            strSql.Append(" AtID,UsID,PostCause,PostDate,PostIP,Holiday,OneLevelAudit,TwoLevelAudit,BeginDate,EndDate,HolidayCalss,WorkContent,WorkPeson,Stauts,Remark ");
            strSql.Append(" FROM tbAttendance ");
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
            strSql.Append("select count(1) FROM tbAttendance ");
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
                strSql.Append("order by T.AtID desc");
            }
            strSql.Append(")AS Row, T.*  from tbAttendance T ");
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
        public DataSet GetList(int PageSize,int PageIndex,string strOrder,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.VarChar,255),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tbAttendance";
            parameters[1].Value = "AtID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = strOrder;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        public DataSet RunProcedure(string storedProcName,DateTime day)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Day", SqlDbType.DateTime),
                    };
            parameters[0].Value = day;
            return DbHelperSQL.RunProcedure(storedProcName,parameters,"ds");
        }
        
        }

        #endregion  BasicMethod

}
