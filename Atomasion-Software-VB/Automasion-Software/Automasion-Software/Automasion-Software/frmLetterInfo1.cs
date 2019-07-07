using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Automasion_Software
{
    public partial class frmLetterInfo1 : Form
    {


        public frmLetterInfo1()


        {
            InitializeComponent();
        }
        int letterId = 0;
        public frmLetterInfo1(int letterID)
        {
            letterId = letterID;
            InitializeComponent();
        }

        LetterHandller LH = new LetterHandller();
        UserHandller UHH = new UserHandller();
        private void frmLetterInfo1_Load(object sender, EventArgs e)
        {



            try
            {
                Letter L1 = LH.ShowInfo(letterId);
                txtBody.Text = L1.Body;
                txtSubject.Text = L1.Subject;
                int reciverID = L1.RecieverID;
                DataTable dd = UHH.ShowInfo(reciverID);
                txtReciver.Text = dd.Rows[0]["UName"].ToString() + " " + dd.Rows[0]["UFamily"].ToString();

                int senderID = L1.SenderID;
                DataTable dd2 = UHH.ShowInfo(senderID);
                txtSender.Text = dd2.Rows[0]["UName"].ToString() + " " + dd2.Rows[0]["UFamily"].ToString();

                txtLID.Text = letterId.ToString();
                txtDate.Text = L1.Date;

                lblParaf.Text = L1.Paraf;               

                
                //---------------- font setting -----------------------------------
                DataTable dtFontSetting = new DataTable();
                dtFontSetting = (new DataBase()).ExecuteSelectSQL("select * from tFontLetter where TFLID=" + letterId + "");
                if (dtFontSetting.Rows.Count>0)
                {
                    //TFStyle
                    //TFFontFamily
                                      
                    if (dtFontSetting.Rows[0]["TFLeftToRight"].ToString() == "Yes")
                        txtBody.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    else if (dtFontSetting.Rows[0]["TFLeftToRight"].ToString() == "No")
                        txtBody.RightToLeft = System.Windows.Forms.RightToLeft.No;

                    if (dtFontSetting.Rows[0]["TFAlignment"].ToString() == "Right")
                        txtBody.TextAlign = System.Drawing.ContentAlignment.TopRight;
                    else if (dtFontSetting.Rows[0]["TFAlignment"].ToString() == "Center")
                        txtBody.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                    else if (dtFontSetting.Rows[0]["TFAlignment"].ToString() == "Left")
                        txtBody.TextAlign = System.Drawing.ContentAlignment.TopLeft;

                    if (dtFontSetting.Rows[0]["TFColor"].ToString() != "none")
                    {
                        //System.Drawing.Color myColor = System.Drawing.ColorTranslator.FromHtml(dtFontSetting.Rows[0]["TFColor"].ToString());
                        //txtBody.ForeColor = myColor;
                        txtBody.ForeColor = System.Drawing.Color.FromName(dtFontSetting.Rows[0]["TFColor"].ToString());
                    }

                    if (dtFontSetting.Rows[0]["TFSize"]!=null)
                    {
                        txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        if (dtFontSetting.Rows[0]["TFStyle"].ToString() != "none")
                        {
                            if (dtFontSetting.Rows[0]["TFStyle"].ToString() == "Bold")
                            {
                                txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            }
                            else if (dtFontSetting.Rows[0]["TFStyle"].ToString() == "Italic")
                            {
                                txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            }
                            else if (dtFontSetting.Rows[0]["TFStyle"].ToString() == "Underline")
                            {
                                txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            }
                            else if (dtFontSetting.Rows[0]["TFStyle"].ToString() == "Strikeout")
                            {
                                txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            }
                            else
                            {
                                txtBody.Font = new System.Drawing.Font(dtFontSetting.Rows[0]["TFFontFamily"].ToString(), Single.Parse(dtFontSetting.Rows[0]["TFSize"].ToString()), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            }

                        }
                    }

                    if (dtFontSetting.Rows[0]["TFColor"].ToString() != "none")
                    {
                        //System.Drawing.Color myColor = System.Drawing.ColorTranslator.FromHtml(dtFontSetting.Rows[0]["TFColor"].ToString());
                        //txtBody.ForeColor = myColor;
                        txtBody.ForeColor = System.Drawing.Color.FromName(dtFontSetting.Rows[0]["TFColor"].ToString());
                    }

                }
                pictureBox1.Image = new Bitmap((new DataBase()).ExecuteSelectSQL("select * from Users where UID=" + senderID + "").Rows[0]["UEmza"].ToString());
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            }
            catch (Exception ex)
            {
            }
        }

        
        


            //PrintDialog PP = new PrintDialog();
            //PP.ShowDialog();
            //PP.AllowSelection = true;
            //PP.AllowPrintToFile = true;
            //PP.AllowCurrentPage = true;

            //Graphics g = this.CreateGraphics();
            //bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            //Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialog1.ShowDialog();

            //this.printForm1.Print();
            //this.printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;


        

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        Bitmap bitmap;
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(bmp, 0, 0);
        //}
        //Bitmap bmp;
    }



   
}
