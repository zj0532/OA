using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class UserInfoDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tbUserInfo");
            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4)
			};
            parameters[0].Value = UsID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MDL.UserInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbUserInfo(");
            strSql.Append("UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP)");
            strSql.Append(" values (");
            strSql.Append("@UsName,@UsPwd,@Phone,@Email,@JobID,@BusinessID,@Stauts,@ServerStyleID,@BeComany,@Office,@EntryDate,@EntryCause,@DimissionDate,@Remark,@EmptyOne,@EmptyTwo,@WrodGroupID,@MorTime,@NightTime,@SaturdayMorTime,@SaturdayNightTime,@IsLockIP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UsName", SqlDbType.NVarChar,50),
					new SqlParameter("@UsPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@JobID", SqlDbType.Int,4),
					new SqlParameter("@BusinessID", SqlDbType.Int,4),
					new SqlParameter("@Stauts", SqlDbType.NVarChar,50),
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4),
					new SqlParameter("@BeComany", SqlDbType.NVarChar,60),
					new SqlParameter("@Office", SqlDbType.NVarChar,100),
					new SqlParameter("@EntryDate", SqlDbType.NVarChar,50),
					new SqlParameter("@EntryCause", SqlDbType.NVarChar,100),
					new SqlParameter("@DimissionDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@EmptyOne", SqlDbType.NVarChar,500),
					new SqlParameter("@EmptyTwo", SqlDbType.NVarChar,500),
					new SqlParameter("@WrodGroupID", SqlDbType.Int,4),
					new SqlParameter("@MorTime", SqlDbType.NVarChar,50),
					new SqlParameter("@NightTime", SqlDbType.NVarChar,50),
					new SqlParameter("@SaturdayMorTime", SqlDbType.NVarChar,50),
					new SqlParameter("@SaturdayNightTime", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLockIP", SqlDbType.Int,4)};
            parameters[0].Value = model.UsName;
            parameters[1].Value = model.UsPwd;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.JobID;
            parameters[5].Value = model.BusinessID;
            parameters[6].Value = model.Stauts;
            parameters[7].Value = model.ServerStyleID;
            parameters[8].Value = model.BeComany;
            parameters[9].Value = model.Office;
            parameters[10].Value = model.EntryDate;
            parameters[11].Value = model.EntryCause;
            parameters[12].Value = model.DimissionDate;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.EmptyOne;
            parameters[15].Value = model.EmptyTwo;
            parameters[16].Value = model.WrodGroupID;
            parameters[17].Value = model.MorTime;
            parameters[18].Value = model.NightTime;
            parameters[19].Value = model.SaturdayMorTime;
            parameters[20].Value = model.SaturdayNightTime;
            parameters[21].Value = model.IsLockIP;

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
       /// 导出信息
       /// </summary>
       /// <returns></returns>
        public DataTable GetUserListByExport()
        {
            StringBuilder str = new StringBuilder();
            str.Append(" SELECT  ");
            str.Append("  [UsName] as '姓名' ");
            str.Append(" ,[Phone] as '电话' ");
            str.Append(" ,[Email] as '邮箱' ");
            str.Append(" ,(select jobname from tbjob where jobid=[tbUserInfo].[JobID]) as '职务' ");
            str.Append(" ,(select BusinessName from tbBusiness where [BusinessID]=[tbUserInfo].[BusinessID]) as '业务' ");
            str.Append(" ,[Stauts] as '状态' ");
            str.Append(" ,(select ServerStyleName  from tbServerStyle where [ServerStyleID] =[tbUserInfo].[ServerStyleID] ) as '服务形式' ");
            str.Append(" ,[BeComany] as '所属公司' ");
            str.Append(" ,[Office] as '办公地点' ");
            str.Append(" ,[EntryDate] as '入职时间' ");
            str.Append(" ,[EntryCause] as '入职原因' ");
            str.Append(" ,[DimissionDate] as '离职时间' ");
            str.Append(" ,[Remark] as '备注' ");
            str.Append(" FROM [tbUserInfo]  ");
            str.Append(" order by businessid,jobid,usid ");

            DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
            return dt;
        
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MDL.UserInfoMOD model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUserInfo set ");
            strSql.Append("UsName=@UsName,");
            strSql.Append("UsPwd=@UsPwd,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("JobID=@JobID,");
            strSql.Append("BusinessID=@BusinessID,");
            strSql.Append("Stauts=@Stauts,");
            strSql.Append("ServerStyleID=@ServerStyleID,");
            strSql.Append("BeComany=@BeComany,");
            strSql.Append("Office=@Office,");
            strSql.Append("EntryDate=@EntryDate,");
            strSql.Append("EntryCause=@EntryCause,");
            strSql.Append("DimissionDate=@DimissionDate,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("EmptyOne=@EmptyOne,");
            strSql.Append("EmptyTwo=@EmptyTwo,");
            strSql.Append("WrodGroupID=@WrodGroupID,");
            strSql.Append("MorTime=@MorTime,");
            strSql.Append("NightTime=@NightTime,");
            strSql.Append("SaturdayMorTime=@SaturdayMorTime,");
            strSql.Append("SaturdayNightTime=@SaturdayNightTime,");
            strSql.Append("IsLockIP=@IsLockIP");
            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsName", SqlDbType.NVarChar,50),
					new SqlParameter("@UsPwd", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@JobID", SqlDbType.Int,4),
					new SqlParameter("@BusinessID", SqlDbType.Int,4),
					new SqlParameter("@Stauts", SqlDbType.NVarChar,50),
					new SqlParameter("@ServerStyleID", SqlDbType.Int,4),
					new SqlParameter("@BeComany", SqlDbType.NVarChar,60),
					new SqlParameter("@Office", SqlDbType.NVarChar,100),
					new SqlParameter("@EntryDate", SqlDbType.NVarChar,50),
					new SqlParameter("@EntryCause", SqlDbType.NVarChar,100),
					new SqlParameter("@DimissionDate", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,100),
					new SqlParameter("@EmptyOne", SqlDbType.NVarChar,500),
					new SqlParameter("@EmptyTwo", SqlDbType.NVarChar,500),
					new SqlParameter("@WrodGroupID", SqlDbType.Int,4),
					new SqlParameter("@MorTime", SqlDbType.NVarChar,50),
					new SqlParameter("@NightTime", SqlDbType.NVarChar,50),
					new SqlParameter("@SaturdayMorTime", SqlDbType.NVarChar,50),
					new SqlParameter("@SaturdayNightTime", SqlDbType.NVarChar,50),
					new SqlParameter("@IsLockIP", SqlDbType.Int,4),
					new SqlParameter("@UsID", SqlDbType.Int,4)};
            parameters[0].Value = model.UsName;
            parameters[1].Value = model.UsPwd;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.JobID;
            parameters[5].Value = model.BusinessID;
            parameters[6].Value = model.Stauts;
            parameters[7].Value = model.ServerStyleID;
            parameters[8].Value = model.BeComany;
            parameters[9].Value = model.Office;
            parameters[10].Value = model.EntryDate;
            parameters[11].Value = model.EntryCause;
            parameters[12].Value = model.DimissionDate;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.EmptyOne;
            parameters[15].Value = model.EmptyTwo;
            parameters[16].Value = model.WrodGroupID;
            parameters[17].Value = model.MorTime;
            parameters[18].Value = model.NightTime;
            parameters[19].Value = model.SaturdayMorTime;
            parameters[20].Value = model.SaturdayNightTime;
            parameters[21].Value = model.IsLockIP;
            parameters[22].Value = model.UsID;

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
        /// 更新一条用户密码
        /// </summary>
        public bool UpdatePwd(string UserPwd,int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUserInfo set ");
            
            strSql.Append("UsPwd=@UsPwd ");
            
            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					
					new SqlParameter("@UsPwd", SqlDbType.NVarChar,50),
					
					new SqlParameter("@UsID", SqlDbType.Int,4)};
            parameters[0].Value = UserPwd;
            parameters[1].Value = UserID;
            

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
       /// 更新用户假期时间
       /// </summary>
       /// <returns></returns>
        public bool UpdateHolidaySetting(string Usid,string NianJia,string TiaoXiu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbUserInfo set ");

            strSql.Append("NianJia=@NianJia,TiaoXiu=@TiaoXiu");

            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					
					new SqlParameter("@NianJia", SqlDbType.NVarChar,20),
					new SqlParameter("@TiaoXiu", SqlDbType.NVarChar,20),
					new SqlParameter("@UsID", SqlDbType.Int,4)};
            parameters[0].Value = NianJia;
            parameters[1].Value = TiaoXiu;
            parameters[2].Value = Usid;

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
        public bool Delete(int UsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUserInfo ");
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
        public bool DeleteList(string UsIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbUserInfo ");
            strSql.Append(" where UsID in (" + UsIDlist + ")  ");
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
        public MDL.UserInfoMOD GetModel(int UsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UsID,UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP from tbUserInfo ");
            strSql.Append(" where UsID=@UsID");
            SqlParameter[] parameters = {
					new SqlParameter("@UsID", SqlDbType.Int,4)
			};
            parameters[0].Value = UsID;

            MDL.UserInfoMOD model = new MDL.UserInfoMOD();
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


        public MDL.UserInfoMOD GetModel(string UsName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UsID,UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP from tbUserInfo ");
            strSql.Append(" where UsName=@UsName");
            SqlParameter[] parameters = {
					new SqlParameter("@UsName", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = UsName;

            MDL.UserInfoMOD model = new MDL.UserInfoMOD();
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
        public MDL.UserInfoMOD DataRowToModel(DataRow row)
        {
            MDL.UserInfoMOD model = new MDL.UserInfoMOD();
            if (row != null)
            {
                if (row["UsID"] != null && row["UsID"].ToString() != "")
                {
                    model.UsID = int.Parse(row["UsID"].ToString());
                }
                if (row["UsName"] != null)
                {
                    model.UsName = row["UsName"].ToString();
                }
                if (row["UsPwd"] != null)
                {
                    model.UsPwd = row["UsPwd"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["JobID"] != null && row["JobID"].ToString() != "")
                {
                    model.JobID = int.Parse(row["JobID"].ToString());
                }
                if (row["BusinessID"] != null && row["BusinessID"].ToString() != "")
                {
                    model.BusinessID = int.Parse(row["BusinessID"].ToString());
                }
                if (row["Stauts"] != null)
                {
                    model.Stauts = row["Stauts"].ToString();
                }
                if (row["ServerStyleID"] != null && row["ServerStyleID"].ToString() != "")
                {
                    model.ServerStyleID = int.Parse(row["ServerStyleID"].ToString());
                }
                if (row["BeComany"] != null)
                {
                    model.BeComany = row["BeComany"].ToString();
                }
                if (row["Office"] != null)
                {
                    model.Office = row["Office"].ToString();
                }
                if (row["EntryDate"] != null)
                {
                    model.EntryDate = row["EntryDate"].ToString();
                }
                if (row["EntryCause"] != null)
                {
                    model.EntryCause = row["EntryCause"].ToString();
                }
                if (row["DimissionDate"] != null)
                {
                    model.DimissionDate = row["DimissionDate"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["EmptyOne"] != null)
                {
                    model.EmptyOne = row["EmptyOne"].ToString();
                }
                if (row["EmptyTwo"] != null)
                {
                    model.EmptyTwo = row["EmptyTwo"].ToString();
                }
                if (row["WrodGroupID"] != null && row["WrodGroupID"].ToString() != "")
                {
                    model.WrodGroupID = int.Parse(row["WrodGroupID"].ToString());
                }
                if (row["MorTime"] != null)
                {
                    model.MorTime = row["MorTime"].ToString();
                }
                if (row["NightTime"] != null)
                {
                    model.NightTime = row["NightTime"].ToString();
                }
                if (row["SaturdayMorTime"] != null)
                {
                    model.SaturdayMorTime = row["SaturdayMorTime"].ToString();
                }
                if (row["SaturdayNightTime"] != null)
                {
                    model.SaturdayNightTime = row["SaturdayNightTime"].ToString();
                }
                if (row["IsLockIP"] != null && row["IsLockIP"].ToString() != "")
                {
                    model.IsLockIP = int.Parse(row["IsLockIP"].ToString());
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
            strSql.Append("select UsID,UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP ");
            strSql.Append(" FROM tbUserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCountList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ");
            strSql.Append("UsID,UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP,NianJia,TiaoXiu  ");
            strSql.Append(",(select count (*) from tbUserInfo   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" ) as total ");
            strSql.Append(" FROM tbUserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Businessid,jobid,usid ");
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
            strSql.Append(" UsID,UsName,UsPwd,Phone,Email,JobID,BusinessID,Stauts,ServerStyleID,BeComany,Office,EntryDate,EntryCause,DimissionDate,Remark,EmptyOne,EmptyTwo,WrodGroupID,MorTime,NightTime,SaturdayMorTime,SaturdayNightTime,IsLockIP  ");
            strSql.Append(" FROM tbUserInfo ");
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
            strSql.Append("select count(1) FROM tbUserInfo ");
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
                strSql.Append("order by T.UsID desc");
            }
            strSql.Append(")AS Row, T.*  from tbUserInfo T ");
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
            parameters[0].Value = "tbUserInfo";
            parameters[1].Value = "UsID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = strOrder;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        public bool insert()
        {
            DataTable dt = new UserInfoDAL().GetList("  jobid=3 and stauts='在职' ").Tables[0];
            MDL.AuthorityMOD auth=new MDL.AuthorityMOD ();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 14;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 6;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 6;
                auth.AuthorityParamID = 2;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 32;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 17;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 18;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 18;
                auth.AuthorityParamID = 2;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 7;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);

                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 30;
                auth.AuthorityParamID = 1;
                new AuthorityDAL().Add(auth);
                auth.UsID = int.Parse(dt.Rows[i]["UsID"].ToString());
                auth.PsID = 30;
                auth.AuthorityParamID = 2;
                new AuthorityDAL().Add(auth);

            }
            return true;
        
        
        }
        

        #endregion  BasicMethod


    }
}
