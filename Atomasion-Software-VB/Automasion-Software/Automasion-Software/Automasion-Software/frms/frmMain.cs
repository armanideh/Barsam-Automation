using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; // Namespace for Thread class
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Diagnostics;
//Barsam Novin



namespace Automasion_Software
{
    public partial class frmMain : Form
    {        
        public frmMain()
        {
            InitializeComponent();
        }

        Boolean updateLetter = false;
        DataBase DB = new DataBase();
        UserHandller UHH = new UserHandller();
        LetterHandller LH = new LetterHandller();
        public void ShowAllUsers()
        {
            if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل")
            {
                dgUsers.DataSource = UHH.ShowAllwithAdmin();
            }
            else
            {
             
            }
            SettingDataGridUser();
        }

        public void SettingDataGridUser()
        {
            dgUsers.Columns[0].Width = 50;
            dgUsers.Columns[1].Width = 250;
            dgUsers.Columns[2].Width = 150;
            dgUsers.Columns[3].Width = 150;
            dgUsers.Columns[4].Width = 150;
            Other.colorize(dgUsers);
            for (int i = 0; i < dgUsers.Rows.Count; i++)
            {
                dgUsers.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Yellow;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                //cmbBuyColor.DataSource = CH.ShowAllWithoutAs();
                //cmbBuyColor.DisplayMember = "CColor";
                //cmbBuyColor.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show("خطای سیستم : " + ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl2.SelectedTab = tabControl2.TabPages[3];
            }
            catch (Exception ex)
            {
                FarsiMessage.Show("خطای سیستم : " + ex.Message);
            }
        }


        private void pictureBox11_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[1];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[6];
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[2];
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[5];
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                btnLAechive.Visible = true;
                btnLShow.Enabled = false;
                cmbYear1.Items.Clear();
                cmbYear2.Items.Clear();
                cmbYear1.Items.Add("0");
                cmbYear2.Items.Add("0");
                for (int i = 1392; i < 1450; i++)
                {
                    cmbYear1.Items.Add(i.ToString());
                    cmbYear2.Items.Add(i.ToString());
                }
                cmbDay1.SelectedIndex = 0;
                cmbDay2.SelectedIndex = 0;
                cmbMonth1.SelectedIndex = 0;
                cmbMonth2.SelectedIndex = 0;
                cmbYear1.SelectedIndex = 0;
                cmbYear2.SelectedIndex = 0;

                //cmbSortLetters.SelectedIndex = 0;

                lblDate.Text = MilladiToShamc.ToSahmcDate() + " - " + MilladiToShamc.ShowTimeLimited();

                this.Text += "  " + "[" + Other.objUserInfo.Name + " " + Other.objUserInfo.Family + "]";
                txtSender.Text = Other.objUserInfo.Name + " " + Other.objUserInfo.Family;
                lblSenderID.Text = Other.objUserInfo.Id.ToString();

                if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    //نایش نامه ها
                    dgLettersMe.DataSource = LH.ShowAll();

                    //نمایش کاربران
                    ShowAllUsers();
                }            
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    pnlLettersAll.Visible = false;
                    pnlUsers.Visible = false;
                    tabControl2.TabPages.Remove(tbpUsers);
                    //btnLUpdate.Visible = false;
                    btnLDel.Visible = false;
                    btnLAechive.Visible = true;
                    btnEmzaErsal.Visible = true;
                    btnSendEnd.Visible = true;
                    //btnLShow.Enabled = true;

                    //نایش نامه ها
                    dgLettersMe.DataSource = LH.ShowAll(Other.objUserInfo.Id);
                }
                // Other.objUserInfo.Rule == "مدیر عامل" Other.objUserInfo.Rule == "نماینده مدیر عامل" Other.objUserInfo.Rule == "رییس هیئت مدیره" Other.objUserInfo.Rule == "مدیر کارخانه" Other.objUserInfo.Rule == "مدیر بازرگانی" Other.objUserInfo.Rule == "مدیر تولید" Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" 
                //Other.objUserInfo.Rule == "سرپرست کنترل کیفی" Other.objUserInfo.Rule == "انباردار" Other.objUserInfo.Rule == "حراست" 

                if (Other.objUserInfo.Rule == "مدیر کارخانه")
                {
                    pnlLettersAll.Visible = false;
                    pnlUsers.Visible = false;
                    tabControl2.TabPages.Remove(tbpUsers);
                    //btnLUpdate.Visible = false;
                    btnLDel.Visible = false;
                    btnErsalTayid.Visible = false;

                    btnLNSend.Text = "ارسال";

                    //نایش نامه ها
                    dgLettersMe.DataSource = LH.ReadyToSendOfManager(Other.objUserInfo.GroupName);

                }
                if (Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی"|| Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست" )
                {
                    pnlLettersAll.Visible = false;
                    pnlUsers.Visible = false;
                    tabControl2.TabPages.Remove(tbpUsers);
                    //btnLUpdate.Visible = false;
                    btnLDel.Visible = false;
                    btnErsalTayid.Visible = false;

                    btnLNSend.Text = "ارسال";

                    //نایش نامه ها
                    dgLettersMe.DataSource = LH.ReadyToSendOfManager(Other.objUserInfo.GroupName);

                }

                Other.colorize(dgLettersMe);
                dgLettersMe.Columns[0].Width = 40;
                dgLettersMe.Columns[1].Width = 300;
                dgLettersMe.Columns[2].Width = 450;
                dgLettersMe.Columns[3].Width = 270;
                dgLettersMe.Columns[4].Width = 120;
            }
            catch (Exception ex)
            {
                //FarsiMessage.Show("خطای سیستم : " + ex.Message);
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            try            
            {
                if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    tabControl2.SelectedTab = tabControl2.TabPages[1];
                }
                else
                    tabControl2.SelectedTab = tabControl2.TabPages[0];

                //tabControl2.SelectedTab = tabControl2.TabPages[1];
                //tabMain.SelectedTab = tabMain.TabPages[0];
            }
            catch (Exception ex)
            {

            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            try
            {
                tabMain.SelectedTab = tabMain.TabPages[0];
                tabControl2.SelectedTab = tabControl2.TabPages[0];
                ShowAllUsers();
            }
            catch (Exception ex)
            {
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
            {
                tabControl2.SelectedTab = tabControl2.TabPages[3];
            }
            else
                tabControl2.SelectedTab = tabControl2.TabPages[2];            

            //نامه های پیش نویس شده
            dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
            Other.colorize(dgAllLetters);
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCarDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (FarsiMessage.Show("آیا مطمئن به حذف آیتم انتخاب شده هستید ؟ ", "توجه", FarsiMessageBoxButtons.YesNo, FarsiMessageBoxIcons.Question) == DialogResult.Yes)
                {
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void btnCarEdit_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void btnCarFillInfo_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabControl2.TabPages[4];
        }

        private void btnBNew_Click(object sender, EventArgs e)
        {

        }


        int bimehID = 0;
        private void dgBimeCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnBSave_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void btnBDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (FarsiMessage.Show("آیا مطمئن به حذف آیتم انتخاب شده هستید ؟ ", "توجه", FarsiMessageBoxButtons.YesNo, FarsiMessageBoxIcons.Question) == DialogResult.Yes)
                {
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }
        int carId2 = 0;
        Boolean showAllBimeFlag = false;
        private void btnBShowAll_Click(object sender, EventArgs e)
        {
        }

        private void btnBUpdate_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void btnCaerReserve_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox27_Click(sender, e);
        }


        private void dgBimeCars_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPerName.Text != "" && txtPerFamily.Text != "" && txtPerGroupCode.Text != "" && txtPerpasss.Text != "" && txtPerUserName.Text != "")
                {
                    User U = new User();
                    U.Family = txtPerFamily.Text;
                    U.GroupIndex = int.Parse(txtPerGroupCode.Text);
                    U.GroupName = cmbGroupName.Text;
                    U.Name = txtPerName.Text;
                    U.Pass = txtPerpasss.Text;
                    U.Rule = cmbRole.Text;
                    U.UserName = txtPerUserName.Text;

                    UserHandller UH = new UserHandller();

                    string pathS = " ";
                    U.EmzaAddress = null;
                    if (userPicFileName != "")
                    {
                        pathS = "userPics/" + userPicFileName;
                        U.EmzaAddress = pathS;
                        picEmza.Image.Save(pathS);
                    }
                    if (UH.InsertUser(U))
                    {
                        ShowAllUsers();
                        FarsiMessage.Show("داده ها با موفقیت ثبت شدند . ","ثبت",FarsiMessageBoxButtons.OK,FarsiMessageBoxIcons.Information);
                    }

                }
                else
                {
                    FarsiMessage.Show("پر کردن تمامی فیلدها الزامیست !", "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }

        }

        int userID = 0;

        private void dgDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnUserDel.Enabled = true;
                btnUserUpdate.Enabled = true;

                userID = int.Parse(dgUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
                DataTable dt =UHH.ShowInfo(userID);
                if (dt.Rows.Count > 0)
                {
                    txtPerFamily.Text = dt.Rows[0]["UFamily"].ToString();
                    txtPerName.Text = dt.Rows[0]["UName"].ToString();
                    txtPerGroupCode.Text = dt.Rows[0]["UGroup_Index"].ToString();
                    txtPerpasss.Text = dt.Rows[0]["UPass"].ToString();
                    txtPerUserName.Text = dt.Rows[0]["UUserName"].ToString();
                    cmbGroupName.Text = dt.Rows[0]["UGroup_Name"].ToString();
                    cmbRole.Text = dt.Rows[0]["URole"].ToString();
                    picEmza.Image = null;
                    if (dt.Rows[0]["UEmza"] != null)
                        picEmza.Image = new Bitmap(dt.Rows[0]["UEmza"].ToString());
                }
            }
            catch (Exception ex)
            {
                //FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtPerpasss.Text = "";
            txtPerFamily.Text = "";
            txtPerGroupCode.Text = "";
            txtPerUserName.Text = "";
            txtPerName.Text = "";
            picEmza.Image = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                User U = new User();
                U.Family = txtPerFamily.Text;
                U.GroupIndex = int.Parse(txtPerGroupCode.Text);
                U.GroupName = cmbGroupName.Text;
                U.Name = txtPerName.Text;
                U.Pass = txtPerpasss.Text;
                U.Rule = cmbRole.Text;
                U.UserName = txtPerUserName.Text;

                string pathS = " ";
                U.EmzaAddress = null;
                if (userPicFileName != "")
                {
                    pathS = "userPics/" + userPicFileName;
                    U.EmzaAddress = pathS;
                    picEmza.Image.Save(pathS);
                }
                UHH.Update(userID, U);
                ShowAllUsers();
                FarsiMessage.Show("داده ها با موفقیت ویرایش شدند . ", "ویرایش", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Information);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (FarsiMessage.Show("آیا مطمئن به حذف آیتم انتخاب شده هستید ؟ ", "توجه", FarsiMessageBoxButtons.YesNo, FarsiMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    UHH.Delete(userID);
                    ShowAllUsers();
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }
        public void ShowMojazNone()
        {
            //dgCarsMojazNone.DataSource = CHMain.ShowAllWithMojaz("غیر مجاز");

            //dgCarsMojazNone.Columns[0].Width = 40;
            //dgCarsMojazNone.Columns[1].Width = 80;
            //dgCarsMojazNone.Columns[2].Width = 100;
            //dgCarsMojazNone.Columns[3].Width = 150;
            //dgCarsMojazNone.Columns[4].Width = 80;
            //dgCarsMojazNone.Columns[5].Width = 70;
            //dgCarsMojazNone.Columns[6].Width = 90;
            //dgCarsMojazNone.Columns[7].Width = 80;

            //Other.colorize(dgCarsMojazNone);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbMojazCarType.SelectedIndex > 0 && cmbMojazColor.SelectedIndex > 0 && txtMojaz2Digit.Text != "" && txtMojaz3Digit.Text != "" && txtMojazIran.Text != "" && txtMojazName.Text != "")
                {
                    //CHMain.Insert(cmbMojazCarType.Text, txtMojazName.Text, "0", int.Parse(txtMojaz2Digit.Text), cmbMojazChar.Text, int.Parse(txtMojaz3Digit.Text), int.Parse(txtMojazIran.Text), "-", "-", cmbMojazColor.Text, "-", "-", "غیر مجاز", "-", "غیر مجاز", 0,txtDescMojaz.Text, int.Parse(MilladiToShamc.ToSahmcDay()), int.Parse(MilladiToShamc.ToSahmcMonth()), int.Parse(MilladiToShamc.ToSahmcYear()));
                    //ShowMojazNone();   
                }
                //else
                //    FarsiMessage.Show("وارد کردن اطلاعات پلاک ، نام خودرو و نوع خودرو الزامیست . ", "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FarsiMessage.Show("آیا مطمئن به حذف آیتم انتخاب شده هستید ؟ ", "توجه", FarsiMessageBoxButtons.YesNo, FarsiMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    //CHMain.Delete(carIdMojaz);
                    //ShowMojazNone();
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }

        private void dgCarsMojazNone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label169_Click(object sender, EventArgs e)
        {
            //pictureBox27_Click(sender, e);
        }

        private void label131_Click(object sender, EventArgs e)
        {
            pictureBox37_Click(sender, e);
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {
            //pictureBox27_Click(sender, e);
        }

        private void label120_Click(object sender, EventArgs e)
        {
            pictureBox33_Click(sender, e);
        }

        private void label47_Click(object sender, EventArgs e)
        {
            //pictureBox27_Click(sender, e);
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void btnIOInput1_Click(object sender, EventArgs e)
        {
        }

        private void btnIOOutput_Click(object sender, EventArgs e)
        {
        }

        private void btnIOInput2_Click(object sender, EventArgs e)
        {
        }

        private void dgInputOutputs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox33_Click(sender, e);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            pictureBox26_Click(sender, e);
        }

        private void btnCarTools_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox66_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }
        //نوع انتخاب تمام وارد شده ها و کل ورود و خروج امروز
        int ioTypeSelected = 0;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btnMojazOrNone_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            //tabMain.SelectedTab = tabMain.TabPages[2];
            if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
            {
                tabControl2.SelectedTab = tabControl2.TabPages[2];
            }
            else
                tabControl2.SelectedTab = tabControl2.TabPages[1];
            //tabControl2.SelectedTab = tabControl2.TabPages[2];
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void cmbMojazColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void cmbMojazCarType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMojazIran_TextChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void txtMojaz3Digit_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbMojazChar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void txtMojaz2Digit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMojazName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            //tabMain.SelectedTab = tabMain.TabPages[1];
            tabControl2.SelectedTab = tabControl2.TabPages[1];
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            frmsUsers u = new frmsUsers();
            u.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUserAdd.Enabled = true;
        }
        string userPicFileName = "";
        string userPicPath = "";
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picEmza.Image = new Bitmap(openFileDialog1.FileName);
                    string[] str = openFileDialog1.FileName.Split('\\');
                    userPicFileName = str[str.Length - 1];
                    userPicPath = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    FarsiMessage.Show("خطا در بارگذاری تصویر " + ex.Message);
                }
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }       

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Other.selectTypeUser = 0;
            timerShowUsers.Enabled = true;
            frmUser uu = new frmUser();
            uu.ShowDialog();
        }

        private void timerShowUsers_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Other.UserID != 0 && Other.selectTypeUser==1)
                {
                    lblReciverId.Text = Other.UserID.ToString();
                    DataTable dt = UHH.ShowInfo(Other.UserID);
                    txtReciver.Text = dt.Rows[0]["UName"].ToString() + " " + dt.Rows[0]["UFamily"].ToString();

                    txtGroupName.Text = dt.Rows[0]["URole"].ToString() + " - " + dt.Rows[0]["UGroup_Name"].ToString();
                    Other.selectTypeUser = 0;
                    timerShowUsers.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
            {
                tabControl2.SelectedTab = tabControl2.TabPages[3];
            }
            else
                tabControl2.SelectedTab = tabControl2.TabPages[2];

            //نامه های پیش نویس شده
            dgAllLetters.DataSource= LH.PreWriteLetters(Other.objUserInfo.Id);
            Other.colorize(dgAllLetters);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnUpdateL1.Visible = false;
            updateLetter = false;
            //txtSender.Text = "";
            txtReciver.Text = "";
            txtSubject.Text = "";
            txtEditor.Text = "";
            txtGroupName.Text = "";
        }

        
        private void btnPishnevis_Click(object sender, EventArgs e)
        {
            try
            {
                if (!replyValidation)
                {
                    if (txtSender.Text != "" && txtReciver.Text != "" && txtSubject.Text != "")
                    {
                        Letter L = new Letter(MilladiToShamc.ToSahmcDate(), txtSubject.Text, txtEditor.Text, Other.objUserInfo.Id, int.Parse(lblReciverId.Text), "پیش نویس", txtParaf.Text, 1, 0, 1);
                        LH.Send(L, Other.objUserInfo.Id);
                        dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                        Other.colorize(dgAllLetters);
                        dgAllLetters.Columns[0].Width = 40;
                        dgAllLetters.Columns[1].Width = 150;
                        dgAllLetters.Columns[2].Width = 250;
                        dgAllLetters.Columns[3].Width = 150;
                        dgAllLetters.Columns[4].Width = 80;
                        MessageBox.Show("نامه با موفقیت ثبت شد !");
                        //button7_Click(sender, e);
                    }
                    else
                    {
                        FarsiMessage.Show("ورود اطلاعات فرستنده ، گیرنده و موضوع نامه الزامیست !");
                    }
                }
                else
                    FarsiMessage.Show("امکان ارسال نامه جهت تایید در این مرحله فراهم نیست ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        int LID = 0;
        private void dgAllLetters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLNSend.Enabled = true;
            btnLNUpdate.Enabled = true;


            LID = int.Parse(dgAllLetters.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (LID != 0)
            {
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    DB.ExecuteSQL("update tLettersAction set SL_PreWrite=0 where SL_LID=" + LID + " and SL_UserID=" + Other.objUserInfo.Id + " and SL_PreWrite=1");
                    DB.ExecuteSQL("update tLetters set LState=N'آماده ارسال' where LID=" + LID + "");
                }
                else
                {
                    DB.ExecuteSQL("update tLettersAction set SL_PreWrite=0 where SL_LID=" + LID + " and SL_UserID=" + Other.objUserInfo.Id + " and SL_PreWrite=1");
                    DB.ExecuteSQL("update tLetters set LState=N'ارسال شده' where LID=" + LID + "");
                }
                dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                Other.colorize(dgAllLetters);
                dgAllLetters.Columns[0].Width = 40;
                dgAllLetters.Columns[1].Width = 150;
                dgAllLetters.Columns[2].Width = 250;
                dgAllLetters.Columns[3].Width = 150;
                dgAllLetters.Columns[4].Width = 80;
            }
            else
                FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ","نوجه ! ",FarsiMessageBoxButtons.OK,FarsiMessageBoxIcons.Error);
        }

        private void btnErsalTayid_Click(object sender, EventArgs e)
        {
            try
            {
                if (!replyValidation)
                {
                    if (txtSender.Text != "" && txtReciver.Text != "" && txtSubject.Text != "")
                    {
                        Letter L = new Letter(MilladiToShamc.ToSahmcDate(), txtSubject.Text, txtEditor.Text, Other.objUserInfo.Id, int.Parse(lblReciverId.Text), "آماده ارسال", txtParaf.Text, 1, 0, 0);
                        LH.Send(L, Other.objUserInfo.Id);
                        MessageBox.Show("نامه با موفقیت ثبت شد ! در پنل نامه های من میتوانید نامه مورد نظر را ملاحظه فرمایید . ");
                    }
                    else
                    {
                        FarsiMessage.Show("ورود اطلاعات فرستنده ، گیرنده و موضوع نامه الزامیست !");
                    }
                }
                else
                    FarsiMessage.Show("امکان ارسال نامه جهت تایید در این مرحله فراهم نیست ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (LID!=0)
                {
                    Letter L1= LH.ShowInfo(LID);
                    txtEditor.Text = L1.Body;
                    //txtGroupName.Text=L1.grou
                    txtSubject.Text = L1.Subject;
                    int reciverID = L1.RecieverID;
                    lblReciverId.Text = reciverID.ToString();
                    DataTable dd= UHH.ShowInfo(reciverID);
                    txtReciver.Text = dd.Rows[0]["UName"].ToString() + " " + dd.Rows[0]["UFamily"].ToString();
                    txtGroupName.Text = dd.Rows[0]["UGroup_Name"].ToString();

                    updateLetter = true;
                    btnUpdateL1.Visible = true;
                    //DataTable dtl = DB.ExecuteSelectSQL("select * from tLetters");
                    
                }
                else
                    FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void btnUpdateL1_Click(object sender, EventArgs e)
        {
            try
            {
                if (replyValidation)
                {
                    if (txtSender.Text != "" && txtReciver.Text != "" && txtSubject.Text != "")
                    {
                        Letter L = new Letter(MilladiToShamc.ToSahmcDate(), txtSubject.Text, txtEditor.Text, Other.objUserInfo.Id, int.Parse(lblReciverId.Text), "پیش نویس", txtParaf.Text, 1, 0, 1);
                        LH.Update(L, LID);
                        dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                        Other.colorize(dgAllLetters);
                        dgAllLetters.Columns[0].Width = 40;
                        dgAllLetters.Columns[1].Width = 150;
                        dgAllLetters.Columns[2].Width = 250;
                        dgAllLetters.Columns[3].Width = 150;
                        dgAllLetters.Columns[4].Width = 80;
                        MessageBox.Show("نامه با موفقیت ویرایش شد !");
                    }
                    else
                        FarsiMessage.Show("ورود اطلاعات فرستنده ، گیرنده و موضوع نامه الزامیست !");
                }
                else
                {
                    FarsiMessage.Show("امکان ویرایش نامه در این مرحله فراهم نیست ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void dgAllLetters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button2_Click(sender, e);
        }

        private void btnEmzaErsal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSender.Text != "" && txtReciver.Text != "" && txtSubject.Text != "")
                {
                    if (endSendValid || replyValidation)
                    {
                        if (l2 != 0)
                        {
                            DB.ExecuteSQL("update tLetters set LBody=N'" + txtEditor.Text + "',LSubject=N'" + txtSubject.Text + "',LParaf=N'" + txtParaf.Text + "',LRecieverID=" + lblReciverId.Text + ",LState=N'ارسال شده',LSenderID="+Other.objUserInfo.Id+" where LID=" + l2 + "");
                            DB.ExecuteSQL("update tLettersAction set SL_PreWrite=0,SL_UserID=" + Other.objUserInfo.Id + " where SL_LID=" + l2 + "");
                        }
                        else
                            MessageBox.Show("نام انتخاب نشده است !");
                    }
                    else
                    {
                        Letter L = new Letter(MilladiToShamc.ToSahmcDate(), txtSubject.Text, txtEditor.Text, Other.objUserInfo.Id, int.Parse(lblReciverId.Text), "ارسال شده", txtParaf.Text, 1, 0, 0);
                        LH.Send(L, Other.objUserInfo.Id);
                    }
                    MessageBox.Show("نامه با موفقیت ثبت شد ! در پنل نامه های من میتوانید نامه مورد نظر را ملاحظه فرمایید . ");
                }
                else
                {
                    FarsiMessage.Show("ورود اطلاعات فرستنده ، گیرنده و موضوع نامه الزامیست !");
                }
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select LID as 'کد',LSubject as 'موضوع',LBody as 'متن_نامه',UName+' ' + UFamily as 'گیرنده_فرستنده',LDate as 'تاریخ',LState as 'وضعیت' from tLetters,Users where tLetters.LRecieverID=UID and LDelFlag=0";
                if (cmbYear1.Text != "0" && cmbYear2.Text != "0" && cmbMonth1.Text != "0" && cmbMonth2.Text != "0" && cmbDay1.Text != "0" && cmbDay2.Text != "0")
                {
                    sql += " and LDay between " + cmbDay1.Text + " and " + cmbDay2.Text + " and LMonth between " + cmbMonth1.Text + " and " + cmbMonth2.Text + " and LYear between " + cmbYear1.Text + " and " + cmbYear2.Text + "";
                }
                if (txtSearchSubject.Text != "")
                {
                    sql += " and LSubject like N'%" + txtSearchSubject.Text + "%'";
                }
                if (txtSearchReciver.Text != "")
                {
                    sql += " and LRecieverID=" + lblSearchReciverId.Text + "";
                }
                dgSearch.DataSource = DB.ExecuteSelectSQL(sql);
                Other.colorize(dgSearch);
                dgSearch.Columns[0].Width = 40;
                dgSearch.Columns[1].Width = 300;
                dgSearch.Columns[2].Width = 450;
                dgSearch.Columns[3].Width = 270;
                dgSearch.Columns[4].Width = 120;

            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void timerReciver_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Other.UserID != 0)
                {
                    lblSearchReciverId.Text = Other.UserID.ToString();
                    DataTable dt = UHH.ShowInfo(Other.UserID);
                    txtSearchReciver.Text = dt.Rows[0]["UName"].ToString() + " " + dt.Rows[0]["UFamily"].ToString();
                    timerReciver.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Other.selectTypeUser = 1;
            timerReciver.Enabled = true;
            frmUser uu = new frmUser();
            uu.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSortLetters.SelectedIndex == 0)
            {
                //همه نامه ها
                if (Other.objUserInfo.Rule == "Admin"  || Other.objUserInfo.Rule == "مدیر عامل"|| Other.objUserInfo.Rule == "نماینده مدیرعامل")
                {
                    dgLettersMe.DataSource = LH.ShowAll();
                }                
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.ShowAll(Other.objUserInfo.Id);
                }
                if (Other.objUserInfo.Rule =="نماینده مدیرعامل" )
                {
                    dgLettersMe.DataSource = LH.ShowAll(Other.objUserInfo.GroupName);
                }
            }
            else if (cmbSortLetters.SelectedIndex == 1)
            {
                //ارسال شده
                if (Other.objUserInfo.Rule == "Admin" ||  Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    dgLettersMe.DataSource = LH.SendCartabl();
                }
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.SendCartabl(Other.objUserInfo.Id);
                }
                if ( Other.objUserInfo.Rule == "مدیر کارخانه"|| Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" || Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست")
                {
                    //dgLettersMe.DataSource = LH.SendCartabl(Other.objUserInfo.GroupName);
                    dgLettersMe.DataSource = LH.SendCartabl(Other.objUserInfo.Id);
                }
            }
            else if (cmbSortLetters.SelectedIndex == 2)
            {
                //دریافت شده
                if (Other.objUserInfo.Rule == "Admin" ||  Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    dgLettersMe.DataSource = LH.RecieveCartabl();
                }
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.RecieveCartabl(Other.objUserInfo.Id);
                }
                if ( Other.objUserInfo.Rule == "مدیر کارخانه"|| Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" || Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست")
                {
                    dgLettersMe.DataSource = LH.RecieveCartabl(Other.objUserInfo.Id);
                    //dgLettersMe.DataSource = LH.RecieveCartabl(Other.objUserInfo.GroupName);
                }
            }
            else if (cmbSortLetters.SelectedIndex == 3)
            {
                // Other.objUserInfo.Rule == "مدیر عامل" Other.objUserInfo.Rule == "نماینده مدیر عامل" Other.objUserInfo.Rule == "رییس هیئت مدیره" Other.objUserInfo.Rule == "مدیر کارخانه" Other.objUserInfo.Rule == "مدیر بازرگانی" Other.objUserInfo.Rule == "مدیر تولید" Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" 
                //Other.objUserInfo.Rule == "سرپرست کنترل کیفی" Other.objUserInfo.Rule == "انباردار" Other.objUserInfo.Rule == "حراست" 
                //آماده ارسال
                if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    dgLettersMe.DataSource = LH.ReadyToSend();
                }
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.ReadyToSend(Other.objUserInfo.Id);
                }
                if ( Other.objUserInfo.Rule == "مدیر کارخانه"|| Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" || Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست")
                {
                    dgLettersMe.DataSource = LH.ReadyToSendOfManager(Other.objUserInfo.GroupName);
                }                
            }
            else if (cmbSortLetters.SelectedIndex == 4)
            {
                //بایگانی
                if (Other.objUserInfo.Rule == "Admin" ||Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    dgLettersMe.DataSource = LH.ArchiveLetters();
                }
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.ArchiveLetters(Other.objUserInfo.Id);
                }   
                if (Other.objUserInfo.Rule == "مدیر کارخانه" || Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" || Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست")             
                    dgLettersMe.DataSource = LH.ArchiveLetters(Other.objUserInfo.GroupName);
            }
            else if (cmbSortLetters.SelectedIndex == 5)
            {
                //پیش نویس
                if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیرکل دفتر" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "مدیر کارخانه")
                {
                    dgLettersMe.DataSource = LH.PreWriteLetters();
                }
                if (Other.objUserInfo.Rule == "کارشناس")
                {
                    dgLettersMe.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                }
                if (Other.objUserInfo.Rule == "مدیر کارخانه" || Other.objUserInfo.Rule == "مدیر بازرگانی" || Other.objUserInfo.Rule == "مدیر تولید" || Other.objUserInfo.Rule == "مدیر مالی و منابع انسانی" || Other.objUserInfo.Rule == "سرپرست کنترل کیفی" || Other.objUserInfo.Rule == "انباردار" || Other.objUserInfo.Rule == "حراست")
                    dgLettersMe.DataSource = LH.PreWriteLetters(Other.objUserInfo.GroupName);
            }
            Other.colorize(dgLettersMe);
            dgLettersMe.Columns[0].Width = 40;
            dgLettersMe.Columns[1].Width = 300;
            dgLettersMe.Columns[2].Width = 450;
            dgLettersMe.Columns[3].Width = 270;
            dgLettersMe.Columns[4].Width = 120;
        }

        int l2 = 0;
        private void dgLettersMe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnLDel.Enabled = true;
                btnLShow.Enabled = true;
                btnLAechive.Enabled = true;
                btnLShow.Enabled = true;
                if (!(Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره"))
                {
                    if (cmbSortLetters.Text == "ارسال شده" || cmbSortLetters.Text == "دریافت شده")
                    {
                        btnLShow.Enabled = true;
                    }
                    else
                        btnLShow.Enabled = false;
                }

                l2 = int.Parse(dgLettersMe.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (cmbSortLetters.Text=="پیش نویس" || cmbSortLetters.Text=="آماده ارسال")
                {
                    btnLUpdate.Enabled = true;
                }
                else
                    btnLUpdate.Enabled = false;

                if (cmbSortLetters.Text == "دریافت شده")
                    btnLReply.Enabled = true;
                else
                    btnLReply.Enabled = false;

            }
            catch (Exception ex)
            {
            }
        }

        private void btnLAechive_Click(object sender, EventArgs e)
        {
            if (l2!=0)
            {
                DB.ExecuteSQL("update tLettersAction set SL_Archive=1,SL_PreWrite=0 where SL_LID=" + l2 + " and SL_UserID=" + Other.objUserInfo.Id + " and SL_Archive=0");
                DB.ExecuteSQL("update tLetters set LState=N'بایگانی شده' where LID=" + l2 + "");
                //DB.ExecuteSQL("insert into tLettersAction(SL_UserID,SL_LID,SL_Archive,SL_Read,SL_Send,SL_Recieve,SL_PreWrite) values(" + Other.objUserInfo.Id + "," + l2 + ",1,1,0,1,0)");
                comboBox2_SelectedIndexChanged(sender, e);
                FarsiMessage.Show("بایگانی شد !");
            }
            else
                FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            
        }

        Boolean endSendValid = false;
        private void btnLUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (l2 != 0)
                {
                    endSendValid = true;
                    if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل")
                    {
                        tabControl2.SelectedTab = tabControl2.TabPages[3];
                    }
                    else
                        tabControl2.SelectedTab = tabControl2.TabPages[2];

                    //نامه های پیش نویس شده
                    dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                    Other.colorize(dgAllLetters);


                    Letter L1 = LH.ShowInfo(l2);
                    txtEditor.Text = L1.Body;
                    txtSubject.Text = L1.Subject;
                    int reciverID = L1.RecieverID;
                    lblReciverId.Text = reciverID.ToString();
                    DataTable dd = UHH.ShowInfo(reciverID);
                    txtReciver.Text = dd.Rows[0]["UName"].ToString() + " " + dd.Rows[0]["UFamily"].ToString();

                    //int senderID = L1.SenderID;
                    //lblReciverId.Text = reciverID.ToString();
                    //DataTable dd = UHH.ShowInfo(reciverID);
                    //txtReciver.Text = dd.Rows[0]["UName"].ToString() + " " + dd.Rows[0]["UFamily"].ToString();

                    txtGroupName.Text = dd.Rows[0]["UGroup_Name"].ToString();

                    updateLetter = true;
                    btnUpdateL1.Visible = true;

                }
                else
                    FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message);
            }
        }

        private void btnLDel_Click(object sender, EventArgs e)
        {
            if (l2!=0)
            {
                if (FarsiMessage.Show("آیا مطمئنید ؟ ","توجه",FarsiMessageBoxButtons.YesNo,FarsiMessageBoxIcons.Stop)==DialogResult.Yes)
                {
                    DB.ExecuteSQL("delete from tLetters where LID="+l2+"");
                    DB.ExecuteSQL("delete from tLettersAction where SL_LID=" + l2 + "");
                    MessageBox.Show("نامه حذف شد !");
                    comboBox2_SelectedIndexChanged(sender, e);
                }
            }
            else
                FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
        }

        bool replyValidation = false;
        private void btnLReply_Click(object sender, EventArgs e)
        {
            try
            {
                lblParaf.Visible = true;
                txtParaf.Visible = true;

                replyValidation = true;
                if (Other.objUserInfo.Rule == "Admin" || Other.objUserInfo.Rule == "مدیر عامل" || Other.objUserInfo.Rule == "نماینده مدیر عامل" || Other.objUserInfo.Rule == "رییس هیئت مدیره")
                {
                    tabControl2.SelectedTab = tabControl2.TabPages[3];
                }
                else
                    tabControl2.SelectedTab = tabControl2.TabPages[2];

                dgAllLetters.DataSource = LH.PreWriteLetters(Other.objUserInfo.Id);
                Other.colorize(dgAllLetters);

                Letter L1 = LH.ShowInfo(l2);
                txtEditor.Text = L1.Body;
                txtSubject.Text = L1.Subject;
                lblReciverId.Text = "0";
                txtReciver.Text = "";// dd.Rows[0]["UName"].ToString() + " " + dd.Rows[0]["UFamily"].ToString();

                

            }
            catch (Exception ex)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                txtEditor.Text = "مدیر عامل محترم شرکت" + System.Environment.NewLine + "جناب آقای سلماسی" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
               
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                txtEditor.Text = "قائم مقام محترم شرکت" + System.Environment.NewLine + "جناب آقای محمدیان" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                txtEditor.Text = "ریاست محترم هیئت مدیره شرکت" + System.Environment.NewLine + "جناب آقای طاهری" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                txtEditor.Text = "مدیر محترم کارخانه" + System.Environment.NewLine + "جناب آقای اسکندری نیا" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                txtEditor.Text = "مدیر محترم بازرگانی شرکت" + System.Environment.NewLine + "جناب آقای طاهری" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                txtEditor.Text = "مدیر محترم تولید " + System.Environment.NewLine + "جناب آقای محمدی" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                txtEditor.Text = "مدیر محترم مالی و منابع انسانی" + System.Environment.NewLine + "سرکار خانم کرمی" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                txtEditor.Text = "سرپرست محترم کنترل کیفی" + System.Environment.NewLine + "جناب آقای مرادی" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                txtEditor.Text = "سرپرست انبار" + System.Environment.NewLine + "جناب آقای بهرامی" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                txtEditor.Text = "حراست مجموعه" + System.Environment.NewLine + "با سلام" + System.Environment.NewLine;
            }
            txtSubject.Text = comboBox1.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (l2 != 0)
            {
                frmLetterInfo1 mm = new frmLetterInfo1(l2);
                mm.Show();
            }
            else
                FarsiMessage.Show("نامه مورد نظر را انتخاب کنید ! ", "نوجه ! ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
        }

        private void dgLettersMe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbSortLetters.Text == "ارسال شده" || cmbSortLetters.Text == "دریافت شده")
            {
                button3_Click_1(sender, e);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            button3_Click_1(sender, e);
        }

        private void dgSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLSearchShow.Enabled = true;
            l2 = int.Parse(dgSearch.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3_Click_1(sender, e);
        }

        private void dgAllLetters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }


        //................................................... text editor..........................................................

        #region انواع شمارشی

        /// <summary>
        /// نوع عملکرد برنامه را در این نوع شمارشی مشخص میکنیم
        /// </summary>
        public enum OperateType
        {
            /// <summary>
            /// سند جدید ایجاد کرده اید
            /// </summary>
            New,
            /// <summary>
            /// سندی را باز کردیم
            /// </summary>
            Open,
            /// <summary>
            /// سند جاری ذخیره شده است
            /// </summary>
            Saved,
            /// <summary>
            /// سند جاری ذخیره نشده است
            /// </summary>
            UnSaved
        }

        #endregion

        #region خصوصیات

        /// <summary>
        /// نام فایل را در این خصوصیت نگه میداریم
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// نوع عملکرد سیستم را مشخص میکند
        /// </summary>
        public OperateType OTypeDocument { get; set; }

        #endregion

        #region فیلدها

        private StringReader myReader;

        #endregion
       

        #region متدها

        /// <summary>
        /// تعداد کاراکترها را بر میگرداند
        /// </summary>
        /// <returns></returns>
        long GetCharacterCount()
        {
            return txtEditor.Text.Length;
        }

        /// <summary>
        /// تعداد کلمات را بر میگرداند
        /// </summary>
        /// <returns></returns>
        long GetWordCount()
        {
            string strText = txtEditor.Text;
            return strText.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// تعداد خطوط را بر میگرداند
        /// </summary>
        /// <returns></returns>
        Int32 GetLineCount()
        {
            return txtEditor.Lines.Count();
        }

        /// <summary>
        /// تعداد حروف و لغت را نمایش میدهد
        /// </summary>
        void GetShowCounter()
        {
            lblCharacter.Text = "تعداد حروف : " + this.GetCharacterCount().ToString();
            lblWordCounter.Text = "تعداد لغت : " + this.GetWordCount().ToString();
            lblLineCount.Text = " تعداد خطوط : " + this.GetLineCount().ToString();
        }

        /// <summary>
        /// رنگ متن را تغییر میدهد
        /// </summary>
        void ChangeColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (txtEditor.SelectionLength <= 0)
            {
                if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtEditor.ForeColor = colorDialog.Color;
                    FontSetting.color = colorDialog.Color.Name.ToString();
                }
                return;
            }
            colorDialog.Color = txtEditor.SelectionColor;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && colorDialog.Color != txtEditor.SelectionColor)
            {
                txtEditor.SelectionColor = colorDialog.Color;
                FontSetting.color = colorDialog.Color.Name.ToString();
            }            
        }

        /// <summary>
        /// نوع قلم انتخابی را تغییر میدهد
        /// </summary>
        void ChangeFont()
        {
            FontDialog fontDialog = new FontDialog();
            if (txtEditor.SelectionLength <= 0)
            {
                if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtEditor.SelectionFont = fontDialog.Font;
                    if (fontDialog.Font.Bold)
                        FontSetting.style = "Bold";
                    else if (fontDialog.Font.Italic)
                        FontSetting.style = "Italic";
                    else if (fontDialog.Font.Underline)
                        FontSetting.style = "Underline";
                    else if (fontDialog.Font.Strikeout)
                        FontSetting.style = "Strikeout";
                    else
                        FontSetting.style = "none";

                    FontSetting.fontFamily = fontDialog.Font.Name;
                    FontSetting.fontSize = int.Parse(fontDialog.Font.Size.ToString());
                }
                return;
            }
            fontDialog.Font = txtEditor.SelectionFont;
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && fontDialog.Font != txtEditor.SelectionFont)
            {
                txtEditor.SelectionFont = fontDialog.Font;
                if (fontDialog.Font.Bold)
                    FontSetting.style = "Bold";
                else if (fontDialog.Font.Italic)
                    FontSetting.style = "Italic";
                else
                    FontSetting.style = "none";
                FontSetting.fontFamily = fontDialog.Font.Name;
                FontSetting.fontSize = fontDialog.Font.Size;
            }
            
            
            
        }

        /// <summary>
        /// متن انتخاب شده را به حروف بزرگ تبدیل میکند
        /// </summary>
        void ConvertToUppaerCaseSelectionText()
        {
            txtEditor.SelectedText = txtEditor.SelectedText.ToUpper();
        }


        /// <summary>
        /// متن انتخاب شده را به حروف کوچک تبدیل میکند
        /// </summary>
        void ConvertToLowerCaseSelectionText()
        {
            txtEditor.SelectedText = txtEditor.SelectedText.ToLower();
        }

        /// <summary>
        /// ذخیره سند جاری
        /// </summary>
        private void SaveChange()
        {
            if (this.OTypeDocument == (OperateType.New | OperateType.UnSaved))
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Document|*.txt|All File|*.*";
                saveDialog.Title = "ذخیره سند";
                saveDialog.ShowDialog();
                if (saveDialog.FileName != "")
                {
                    this.FileName = saveDialog.FileName;
                    StreamWriter sWriter = new StreamWriter(this.FileName);
                    sWriter.Write(txtEditor.Text);
                    sWriter.Flush();
                    sWriter.Dispose();
                    sWriter.Close();
                    MessageBox.Show("ذخیره شد.", "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    this.Text = "Text Editor " + saveDialog.FileName;
                    lblFileName.Text = saveDialog.FileName;
                    this.OTypeDocument = OperateType.Saved;
                }
            }
            else if (this.OTypeDocument == OperateType.Saved || this.OTypeDocument == OperateType.UnSaved || this.OTypeDocument == (OperateType.Open | OperateType.UnSaved))
            {
                StreamWriter sWriter = new StreamWriter(this.FileName);
                sWriter.Write(txtEditor.Text);
                sWriter.Flush();
                sWriter.Dispose();
                sWriter.Close();
            }
        }

        /// <summary>
        /// متن انتخاب شده را به کلیپ بورد کپی میکند
        /// </summary>
        void CopyToClipboard()
        {
            txtEditor.Copy();
        }

        /// <summary>
        /// متن انتخاب شده را به کلیپ بورد برش میدهد
        /// </summary>
        void CutToClipboard()
        {
            txtEditor.Cut();
        }

        /// <summary>
        /// اطلاعات را از حافظه کلیپ بورد میخواند و به متن جای اساره گر موس می چسباند
        /// </summary>
        void PasteToTextBoxFromClipboard()
        {
            txtEditor.Paste();
        }


        /// <summary>
        /// تمام متن ا انتخاب میکند
        /// </summary>
        void SelectAllText()
        {
            txtEditor.SelectAll();
        }

        /// <summary>
        /// بازکردن فایل انتخاب شده و نمایش محتویات آن در برنامه
        /// </summary>
        void OpenFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text Document|*.txt|All File|*.*";
            openDialog.Title = "باز کردن فایل";
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.FileName = openDialog.FileName;
                StreamReader sReader = File.OpenText(this.FileName);
                txtEditor.Text = sReader.ReadToEnd();
                sReader.Dispose();
                sReader.Close();

                this.Text = "Text Editor " + openDialog.FileName;
                lblFileName.Text = openDialog.FileName;
                this.OTypeDocument = OperateType.Open | OperateType.Saved;
            }
        }

        #endregion







        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            this.ChangeFont();
        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            this.GetShowCounter();
            this.OTypeDocument = OperateType.UnSaved;
        }

        private void btnSelectColorText_Click(object sender, EventArgs e)
        {
            this.ChangeColor();
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            txtEditor.SelectionAlignment = HorizontalAlignment.Right;
            FontSetting.alignmen = "Right";
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            txtEditor.SelectionAlignment = HorizontalAlignment.Center;
            FontSetting.alignmen = "Center";
        }

        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            txtEditor.SelectionAlignment = HorizontalAlignment.Left;
            FontSetting.alignmen = "Left";
        }

        private void btnRTLText_Click(object sender, EventArgs e)
        {
            txtEditor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            FontSetting.leftToRight = "Yes";
        }

        private void btnLTRText_Click(object sender, EventArgs e)
        {
            txtEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            FontSetting.leftToRight = "No";
        }

        private void PicEmza_Click(object sender, EventArgs e)
        {

        }
    }

}