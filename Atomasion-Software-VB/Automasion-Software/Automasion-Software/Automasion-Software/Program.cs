using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Automasion_Software
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread spThread = new Thread(() => new frmLetterInfo().ShowDialog());

            //شروع کار ترد
            spThread.Start();
            //فرم شروع یا فرم خوش آمد گویی به مدت 3 ثانیه اجرا شده
            Thread.Sleep(4000);
            //و بعد از 3 ثانیه از بین میرود
            spThread.Abort();
            Thread.Sleep(100);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");

            Application.Run(new LogIn());
            //Application.Run(new frmMain());
        }
    }

}
