using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Automasion_Software
{
    public class UserHandller
	{
        DataBase DB;
        public UserHandller()
        {
            DB = new DataBase();
        }

        public Boolean InsertUser(User U)
        {
            Boolean b = false;
            try
            {
                DB.ExecuteSQL("insert into Users(URole,UName,UFamily,UPass,UGroup_Index,UGroup_Name,UUserName,UEmza)" +
                    " values(N'" + U.Rule + "',N'" + U.Name + "',N'" + U.Family + "',N'" + U.Pass + "'," + U.GroupIndex + ",N'" + U.GroupName + "',N'" + U.UserName + "',N'" + U.EmzaAddress+ "')");
                b = true;
            }
            catch (Exception ex) { b = false; }
            return b;
        }

        public Boolean Update(int UIDOld,User NewUser )
        {
            Boolean b = false;
            DB.ExecuteSQL("update Users set URole=N'" + NewUser.Rule + "',UName=N'" + NewUser.Name + "',UFamily=N'" + NewUser.Family + "',UPass=N'" + NewUser.Pass + "',UGroup_Index=" + NewUser.GroupIndex + ",UGroup_Name=N'" + NewUser.GroupName + "',UUserName=N'" + NewUser.UserName + "',UEmza=N'" + NewUser.EmzaAddress + "' where UID=" + UIDOld + "");
            return b;           
        }

        /// <summary>
        /// نمایش اطلاعات کاربری
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable ShowInfo(int userId)
        {
            string Sq = "select * from Users where UID=" + userId + "";
            DataTable dt = new DataTable();
            try
            {
                dt = DB.ExecuteSelectSQL(Sq);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable ShowAllwithAdmin()
        {
            string Sq = "select UID as 'کد',UName + ' ' + UFamily as 'مشخصات_فردی',URole as 'نقش',UPass as 'پسورد',UUserName as 'نام_کاربری',UGroup_Name as 'گروه' from Users";
            DataTable dt = new DataTable();
            try
            {
                dt = DB.ExecuteSelectSQL(Sq);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        public DataTable ShowAll()
        {
            string Sq = "select UID as 'کد',UName + ' ' + UFamily as 'مشخصات_فردی',URole as 'نقش',UGroup_Name as 'گروه' from Users where UId not in(" + Other.objUserInfo.Id + ")";
            DataTable dt = new DataTable();
            try
            {
                dt = DB.ExecuteSelectSQL(Sq);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }     

        /// <summary>
        /// بررسی وجود نام کاربری
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Boolean Exist(string username, string naghsh,string pass)
        {
            Boolean b = false;
            string Sq = "select * from Users where UserName='" + username + "' and URole=N'" + naghsh + "' and UPass=N'"+pass+"'";
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt = DB.ExecuteSelectSQL(Sq);
                if (dt.Rows.Count != 0)
                    b = true;
                else
                    b = false;
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return b;
        }

        /// <summary>
        /// حدف جساب کاربری
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public Boolean Delete(int UID)
        {
            Boolean b = false;
            string SS = "delete from Users where UID="+UID+"";
            try
            {
                DB.ExecuteSQL(SS);
                b = true;
            }
            catch (Exception vv)
            {
                b = false;
            }
            return b;
        }


        public int GetID(string UserName, string Password, string role)
        {
            return int.Parse(DB.ExecuteSelectSQL("select UID from Users where UUserName='" + UserName + "' and UPass='" + Password + "' and URole=N'" + role + "'").Rows[0][0].ToString());
        }
        
        public Boolean LogIn(string UserName, string Password,string rule)
        {
            Boolean b = false;
            try
            {
                if (DB.ExecuteSelectSQL("select * from Users where UUserName='" + UserName + "' and UPass='" + Password + "' and URole=N'" + rule + "'").Rows.Count > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                b = false;
            }
            return b;
        }
	}
}
