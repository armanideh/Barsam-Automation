using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

  public static class MilladiToShamc
    {
       
       //to sham30
        public static string ToSahmcDate()
        {
            PersianCalendar je = new PersianCalendar();
            DateTime thisdate = DateTime.Now;
            string a;
            string shelltime;
            a = je.GetMonth(thisdate).ToString();
            shelltime = je.GetYear(thisdate) + "/" + a;
            a = je.GetDayOfMonth(thisdate).ToString();
            shelltime = shelltime + "/" + a;
            return shelltime;
        }

        /// <summary>
        /// این متد سال شمسی را برمیکرداند
        /// </summary>
        /// <returns></returns>
        public static string ToSahmcYear()
        {
            PersianCalendar je = new PersianCalendar();
            DateTime thisdate = DateTime.Now;
            return je.GetYear(thisdate).ToString();
        }


        /// <summary>
        /// ماه شمسی را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public static string ToSahmcMonth()
        {
            PersianCalendar je = new PersianCalendar();
            DateTime thisdate = DateTime.Now;
            string a;
            a = je.GetMonth(thisdate).ToString();
            //if (a.Length < 2) { a = "0" + a; };
            return a;
        }

        
        /// <summary>
        /// روز شمسی را بر می گرداند
        /// </summary>
        /// <returns></returns>
        public static string ToSahmcDay()
        {
            PersianCalendar je = new PersianCalendar();
            DateTime thisdate = DateTime.Now;
            string a;
            a = je.GetDayOfMonth(thisdate).ToString();
            return a;
        }

        public static string ShowTimeComplete()
        {            
            DateTime date = DateTime.Now;
            string time =date.Hour.ToString() + ":" + date.Minute.ToString() + ":" + date.Second.ToString();
            return time;
        }

        public static string ShowTimeLimited()
        {

            DateTime date = DateTime.Now;
            string m = date.Minute.ToString();
            if (m.Length==1)
            {
                m = "0" + m;
            }
            string time = date.Hour.ToString() + ":" + m;


            return time;

        }

        public static string ShowDateFarsi()
        {
            string Date = "";
            Date += MilladiToShamc.ToSahmcDay() + " ";
            switch (MilladiToShamc.ToSahmcMonth())
            {
                case "1":
                    {
                        Date += "فروردین ";
                        break;
                    }
                case "2":
                    {
                        Date += "اردیبهشت ";
                        break;
                    }
                case "3":
                    {
                        Date += "خرداد ";
                        break;
                    }
                case "4":
                    {
                        Date += "تیر ";
                        break;
                    }
                case "5":
                    {
                        Date += "مرداد ";
                        break;
                    }
                case "6":
                    {
                        Date += "شهریور ";
                        break;
                    }
                case "7":
                    {
                        Date += "مهر ";
                        break;
                    }
                case "8":
                    {
                        Date += "آبان ";
                        break;
                    }
                case "9":
                    {
                        Date += "آذر ";
                        break;
                    }
                case "10":
                    {
                        Date += "دی ";
                        break;
                    }
                case "11":
                    {
                        Date += "بهمن ";
                        break;
                    }
                case "12":
                    {
                        Date += "اسفند ";
                        break;
                    }
                default:
                    break;
            }
            Date += MilladiToShamc.ToSahmcYear();
            return Date;
        }

        public static string ShowMonthName(int month)
        {
            string Date = "";
            switch (month)
            {
                case 1:
                    {
                        Date = "فروردین ";
                        break;
                    }
                case 2:
                    {
                        Date = "اردیبهشت ";
                        break;
                    }
                case 3:
                    {
                        Date = "خرداد ";
                        break;
                    }
                case 4:
                    {
                        Date = "تیر ";
                        break;
                    }
                case 5:
                    {
                        Date = "مرداد ";
                        break;
                    }
                case 6:
                    {
                        Date = "شهریور ";
                        break;
                    }
                case 7:
                    {
                        Date = "مهر ";
                        break;
                    }
                case 8:
                    {
                        Date = "آبان ";
                        break;
                    }
                case 9:
                    {
                        Date = "آذر ";
                        break;
                    }
                case 10:
                    {
                        Date = "دی ";
                        break;
                    }
                case 11:
                    {
                        Date = "بهمن ";
                        break;
                    }
                case 12:
                    {
                        Date = "اسفند ";
                        break;
                    }
                default:
                    break;
            }            
            return Date;
        }



    }
