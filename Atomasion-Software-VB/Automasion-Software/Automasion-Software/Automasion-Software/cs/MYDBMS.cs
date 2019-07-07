using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;


namespace Automasion_Software
{

    public class DataBase
    {
        public SqlConnection ObjCnn;
        private SqlCommand ObjCmm = new SqlCommand();
        private String CnnStr;
//        string str = @"Server=(local); Database=ParkingDB; Integrated Security=TRUE";         
        string str ="";

        public DataBase()
        {
            StreamReader sr2 = new StreamReader("cnn.txt");
            string s = sr2.ReadLine();
            sr2.Close();
            str = @"Data Source = 192.168.1.22,1433; Network Library = DBMSSOCN; Initial Catalog = AutoMasiunDB; User ID = sa; Password = ali774411;";
            ///Data Source = 192.168.2.99,1433; Network Library = DBMSSOCN; Initial Catalog = AutoMasiunDB; User ID = sa; Password = ali774411 
            //str = @"data source=.\SQLEXPRESS; Database=ParkingDB; Integrated Security=TRUE";
            //str = @"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|ParkingDB.mdf;Database=ParkingDB;Trusted_Connection=Yes;";
            CnnStr = str;
            ObjCnn = new SqlConnection();
            ObjCnn.ConnectionString = CnnStr;
            ObjCmm = new SqlCommand();
            ObjCmm.Connection = ObjCnn;
        }
        /// <summary>
        /// از این متد برای برقراری ارتباط با پایگاه داده ها استفاده میگردد
        /// </summary>
        public void Connect()
        {
            try
            {
                ObjCnn.Open();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "ارتباط با پایگاه داده برقرار نشد.");
            }
        }

        /// <summary>
        ///از این متد برای قطع ارتباط با بانک استفاده می گردد 
        /// </summary>
        public void Disconnect()
        {
            try
            {
                ObjCnn.Close();
            }
            catch (Exception e)
            {
                ObjCnn.Dispose();//Releases all resources used by the Component. 
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// از این متد برای اجرای دستورات 
        /// insert , delete , update
        /// استفاده میگردد
        /// </summary>
        /// <param name="StrSQL">دریافت دستور اس کیو ال</param>
        public void ExecuteSQL(string StrSQL)
        {
            Connect();
            ObjCmm.CommandText = StrSQL;
            try
            {
                ObjCmm.ExecuteNonQuery();
            }
            catch (Exception n)
            {
                throw new Exception("عملیات درج ثبت نشد.");

            }
            finally
            {
                Disconnect();
            }
        }


        /// <summary>
        /// ولی این متد تنها برای اجرای دستورات 
        ///SELECT
        ///استفاده میگردد
        /// </summary>
        /// <param name="StrSQL">دریافت دستور اس کیو ال</param>
        /// <returns>برگرداندن جدول حاصله</returns>
        public DataTable ExecuteSelectSQL(string StrSQL)
        {
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = ObjCmm;
            DA.SelectCommand.CommandText = StrSQL;
            try
            {
                Connect();
                DA.SelectCommand.Connection = ObjCnn;
                DA.Fill(DT);
                return DT;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Disconnect();
            }
        }

    }
}