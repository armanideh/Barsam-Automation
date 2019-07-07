using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Automasion_Software
{
   public class LetterHandller
    {
       DataBase DB;
       public LetterHandller()
       {
           DB = new DataBase();
       }

       /// <summary>
       /// ارسال نهایی نامه به رده بالاتر توسط رییس گروهها
       /// </summary>
       /// <param name="L"></param>
       /// <returns>شی نامه</returns>
       public Boolean Send(Letter L, int senderId)
       {
           Boolean b = false;
           DB.ExecuteSQL("insert into tLetters(LDate,LSubject,LBody,LSenderID,LRecieverID,LParaf,LDelFlag,LState,LDay,LMonth,LYear) values(N'" + MilladiToShamc.ToSahmcDate() + "',N'" + L.Subject + "',N'" + L.Body + "'," + L.SenderID + "," + L.RecieverID + ",N'-',0,N'" + L.State + "'," + MilladiToShamc.ToSahmcDay() + "," + MilladiToShamc.ToSahmcMonth() + "," + MilladiToShamc.ToSahmcYear() + ")");
           int letterID = int.Parse(DB.ExecuteSelectSQL("select * from tLetters order by LID desc").Rows[0]["LID"].ToString());
           DB.ExecuteSQL("insert into tLettersAction(SL_UserID,SL_LID,SL_Archive,SL_Read,SL_Send,SL_Recieve,SL_PreWrite) values(" + senderId + "," + letterID + ",0,0,1,0," + L.PishnevisFlag + ")");

           //font setting
           DB.ExecuteSQL("insert into tFontLetter(TFAlignment,TFColor,TFStyle,TFLeftToRight,TFFontFamily,TFLID,TFSize)"
               + " values(N'" + FontSetting.alignmen + "',N'" + FontSetting.color + "',N'" + FontSetting.style + "',N'" + FontSetting.leftToRight + "',N'" + FontSetting.fontFamily + "'," + letterID + "," + FontSetting.fontSize + ")");

           return b;
       }

       public Boolean Update(Letter L, int letterID)
       {
           Boolean b = false;
           DB.ExecuteSQL("update tLetters set LSubject=N'" + L.Subject + "',LBody=N'" + L.Body + "',LRecieverID=" + L.RecieverID + " where LID=" + letterID + "");               
           return b;
       }

       /// <summary>
       /// حذف یک نامه
       /// </summary>
       /// <param name="letterID">کد نامه</param>
       /// <returns></returns>
       public Boolean DeleteLetter(int letterID)
       {
           Boolean b = false;
           DB.ExecuteSQL("update tLetters set LDelFlag=1 where LID=" + letterID + "");
           return b;
       }

       public DataTable ShowAll()
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users,tLettersAction where tLettersAction.SL_UserID=Users.UID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and SL_Archive=0");
           return dt;           
       }

       public DataTable ShowAll(int userId)
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users,tLettersAction where tLettersAction.SL_UserID=Users.UID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and SL_Archive=0 and SL_UserID=" + userId + "");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where (tLetters.LRecieverID=Users.UID or tLetters.LSenderID=Users.UID) and LDelFlag=0 and (LSenderID=" + userId + " or LRecieverID=" + userId + ")");
       return dt;
       }

       public DataTable ShowAll(string groupName)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users,tLettersAction where tLettersAction.SL_UserID=Users.UID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and SL_Archive=0 and Users.UGroup_Name=N'" + groupName + "'");
           return dt;
       }



       /// <summary>
       /// نمایش اطلاعات یک نامه
       /// </summary>
       /// <param name="letterID"></param>
       /// <returns></returns>
       public Letter ShowInfo(int letterID)
       {
           Letter L = new Letter();
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select * from tLetters where LID=" + letterID + "");
           L.Body = dt.Rows[0]["LBody"].ToString();
           L.Code = dt.Rows[0]["LCode"].ToString();
           L.Date = dt.Rows[0]["LDate"].ToString();
           L.Paraf = dt.Rows[0]["LParaf"].ToString();
           L.RecieverID =int.Parse(dt.Rows[0]["LRecieverID"].ToString());
           L.SenderID = int.Parse(dt.Rows[0]["LSenderID"].ToString());
           L.Subject = dt.Rows[0]["LSubject"].ToString();
           //L.Emza = dt.Rows[0]["LEmza"].ToString();
           return L;
       }


       //-------------------------------------------------------------------------------------------

       /// <summary>
       /// کارتابل نامه های صادره
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public DataTable SendCartabl(int userId)
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and SL_UserID=" + userId + " and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_PreWrite=0 and SL_Send=1");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LSenderID=" + userId + " and LDelFlag=0 and LState=N'ارسال شده'");
           return dt;
       }

       /// <summary>
       /// کارتابل نامه های وارده
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public DataTable RecieveCartabl(int userId)
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and SL_UserID="+userId+" and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_Recieve=1");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LRecieverID=" + userId + " and LDelFlag=0 and LState=N'ارسال شده'");
           return dt;

       }

       /// <summary>
       /// آماده ارسال
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public DataTable ReadyToSend(int userId)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LSenderID="+userId+" and LDelFlag=0 and LState=N'آماده ارسال'");
           return dt;
       }


       /// <summary>
       /// نامه های آرشیو شده ی من
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public DataTable ArchiveLetters(int userId)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and SL_UserID=" + userId + " and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=1");
           return dt;
       }

       /// <summary>
       /// نامه های پیش نویس شده
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
       public DataTable PreWriteLetters(int userId)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and SL_UserID=" + userId + " and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_PreWrite=1");
           return dt;
       }



       //.................................. نمایش انواع حالات نامه توسط مدیر سیستم ........................................

       public DataTable SendCartabl()
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_PreWrite=0 and SL_Send=1");           
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LDelFlag=0 and LState=N'ارسال شده'");
           return dt;
       }
       public DataTable RecieveCartabl()
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_Recieve=1");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LRecieverID and LDelFlag=0 and LState=N'ارسال شده'");
           return dt;

       }

       public DataTable ReadyToSend()
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LDelFlag=0 and LState=N'آماده ارسال'");
           return dt;
       }

       public DataTable ArchiveLetters()
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=1");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LRecieverID and LDelFlag=0 and LState=N'بایگانی شده'");
           return dt;
       }

       public DataTable PreWriteLetters()
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_PreWrite=1");
           return dt;
       }



       //-----------------------------------------------نمایش نامه های یک گروه توسط رییس گروه ---------------------------------------
       public DataTable SendCartabl(string groupName)
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_PreWrite=0 and SL_Send=1 and Users.UGroup_Name=N'" + groupName + "'");
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LDelFlag=0 and LState=N'ارسال شده' and tLetters.LSenderID="+Useri+"");           
           return dt;
       }
       public DataTable RecieveCartabl(string groupName)
       {
           DataTable dt = new DataTable();
           //dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=0 and SL_Recieve=1 and Users.UGroup_Name=N'" + groupName + "'");
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LRecieverID and LDelFlag=0 and LState=N'ارسال شده' and Users.UGroup_Name=N'" + groupName + "'");           
           return dt;

       }

       public DataTable ArchiveLetters(string groupName)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_Archive=1  and Users.UGroup_Name=N'" + groupName + "'");
           return dt;
       }

       public DataTable PreWriteLetters(string groupName)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ'"+
               " from tLetters,tLettersAction,Users where Users.UID=tLetters.LRecieverID and tLetters.LID=tLettersAction.SL_LID and LDelFlag=0 and tLettersAction.SL_PreWrite=1 and Users.UGroup_Name=N'" + groupName + "'");
           return dt;
       }

       public DataTable ReadyToSendOfManager(string groupName)
       {
           DataTable dt = new DataTable();
           dt = DB.ExecuteSelectSQL("select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LState as 'وضعیت',LDate as 'تاریخ' from tLetters,Users where Users.UID=tLetters.LSenderID and LDelFlag=0 and LState=N'آماده ارسال' and Users.UGroup_Name=N'" + groupName + "'");
           return dt;
       }

    }
}
