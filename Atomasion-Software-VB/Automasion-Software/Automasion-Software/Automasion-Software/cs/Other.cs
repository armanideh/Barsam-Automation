using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Automasion_Software
{
    public static class Other
    {
        public static User objUserInfo = new User();

        public static string userType = "";
        public static User userInfo = new User();
        public static int IOSelectedRow = 0;

        //این فیلد مشخص میکند که گیرنده انتخاب شده است یا فرستنده
        public static int selectTypeUser = 2;
        public static int UserID = 0;



        public static string reportType = "";
        public static void colorize(DataGridView dg)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dg.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
                else
                    dg.Rows[i].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            }
        }
    }
}
