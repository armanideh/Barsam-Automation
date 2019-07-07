using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automasion_Software
{
   public class Letter
    {
        string code;
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        string body;
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        int senderID;
        public int SenderID
        {
            get { return senderID; }
            set { senderID = value; }
        }

        int recieverID;
        public int RecieverID
        {
            get { return recieverID; }
            set { recieverID = value; }
        }

           string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        string paraf;
        public string Paraf
        {
            get { return paraf; }
            set { paraf = value; }
        }

        int delFlag;
        public int DelFlag
        {
            get { return delFlag; }
            set { delFlag = value; }
        }

        int pishnevisFlag;
        public int PishnevisFlag
        {
            get { return pishnevisFlag; }
            set { pishnevisFlag = value; }
        }

        int sendFlag;
        public int SendFlag
        {
            get { return sendFlag; }
            set { sendFlag = value; }
        }

        int revieveFlag;
        public int RevieveFlag
        {
            get { return revieveFlag; }
            set { revieveFlag = value; }
        }

        string emza;
        public string Emza
        {
            get { return emza; }
            set { emza = value; }
        }


      public Letter()
      {
          code = "-";
          date = MilladiToShamc.ShowDateFarsi();
          subject = "";
          body = "";
          senderID = 0;
          recieverID = 0;
          state = "";
          paraf = "-";
          delFlag = 0;
          pishnevisFlag = 0;
          emza = "";
      }

      public Letter(string date1,string subject1,string body1,int senderID1,int recieverID1,string state1,string paraf1,int sendflag,int reciveflag,int pishnevisflag)
      {
          //code = code1;
          date = date1;
          subject = subject1;
          body = body1;
          senderID = senderID1;
          recieverID = recieverID1;
          state = state1;
          paraf = paraf1;
          delFlag = 0;
          pishnevisFlag =pishnevisflag ;
          this.sendFlag = sendflag;
          this.revieveFlag = reciveflag;
          this.Emza = "";
      }
    }
}
