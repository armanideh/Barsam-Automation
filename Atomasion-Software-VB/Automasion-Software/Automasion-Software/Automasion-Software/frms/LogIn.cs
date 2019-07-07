using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Automasion_Software
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        UserHandller UH = new UserHandller();        
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            DialogResult dialog = FarsiMessage.Show("آیا مطمئن هستید؟", "خروج", FarsiMessageBoxButtons.YesNo, FarsiMessageBoxIcons.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void خروجازسیستمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("آیا مطمئن هستید؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        DataBase DB = new DataBase();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" && txtPass.Text != "")
                {

                    Boolean b = UH.LogIn(txtUserName.Text, txtPass.Text, cmbRule.Text);
                    if (b)
                    {
                        Other.userInfo.Rule = cmbRule.Text;
                        Other.userInfo.UserName = txtUserName.Text;
                        Other.userInfo.Pass = txtPass.Text;

                        DataTable dt = DB.ExecuteSelectSQL("select * from Users where URole=N'" + cmbRule.Text + "' and UPass=N'" + txtPass.Text + "' and UUserName=N'" + txtUserName.Text + "'");
                        Other.objUserInfo.Family = dt.Rows[0]["UFamily"].ToString();
                        Other.objUserInfo.Name = dt.Rows[0]["UName"].ToString();
                        Other.objUserInfo.GroupIndex = int.Parse(dt.Rows[0]["UGroup_Index"].ToString());
                        Other.objUserInfo.GroupName = dt.Rows[0]["UGroup_Name"].ToString();
                        Other.objUserInfo.Rule = dt.Rows[0]["URole"].ToString();
                        Other.objUserInfo.Id = int.Parse(dt.Rows[0]["UID"].ToString());

                        frmMain fm = new frmMain();
                        this.Hide();
                        fm.Show();
                    }

                    else
                    {
                        FarsiMessage.Show("رمز عبور اشتباه است . ارتباط با بانک بررسی گردد .", "اخطار", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
                    }
                }
                else
                {
                    FarsiMessage.Show("متاسفانه برای شما امکان ورود به سیستم وجود ندارد", "توجه", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Information);
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show("رمز عبور اشتباه است . ارتباط با بانک بررسی گردد .", "اخطار", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            cmbRule.SelectedIndex = 0;
            try
            {
                this.Focus();
                StreamReader sr = new StreamReader("cnn.txt");
                textBox1.Text= sr.ReadLine();
                sr.Close();
            }
            catch (Exception ex)
            {
                //FarsiMessage.Show("خطای سیستم" + ex.Message, "خطای سیستم", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }            
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender,e);
            }
        }               

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmChangePass p = new frmChangePass(txtUserName.Text);
            //p.ShowDialog();
            this.Size = new System.Drawing.Size(392, 250);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("cnn.txt");
                sw.Write(textBox1.Text);
                sw.Close();
                FarsiMessage.Show("تغییرات اعمال شدند .برنامه مجدد بارگزاری میگردد");
                Application.Exit();
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
