using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automasion_Software
{
    public partial class frmsUsers : Form
    {
        public frmsUsers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmsUsers_Load(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Enabled = true;
                showUserInfo();
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }
        UserHandller UH = new UserHandller();
        public void showUserInfo()
        {
            int userid = UH.GetID(Other.userInfo.UserName, Other.userInfo.Pass, Other.userInfo.Rule);
            DataTable dtusers = UH.ShowInfo(userid);
            if (dtusers.Rows.Count > 0)
            {
                txtFamily.Text = dtusers.Rows[0]["UFamily"].ToString();
                txtName.Text = dtusers.Rows[0]["UName"].ToString();
                txtPass.Text = dtusers.Rows[0]["UPass"].ToString();
                txtUserName.Text = dtusers.Rows[0]["UUserName"].ToString();
            }
        }

        DataBase DB = new DataBase();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int userid = UH.GetID(Other.userInfo.UserName, Other.userInfo.Pass, Other.userInfo.Rule);
                User UU = new User();
                UU.Family = txtFamily.Text;
                UU.Name = txtName.Text;
                UU.Pass = txtPass.Text;
                UU.UserName = txtUserName.Text;
                DB.ExecuteSQL("update Users set UName=N'" + txtName.Text + "',UFamily=N'" + txtFamily.Text + "',UPass=N'" + txtPass.Text + "',UUserName=N'" + txtUserName.Text + "' where UID=" + userid + "");
                FarsiMessage.Show("اطلاعات شما با موفقیت ویرایش شد .");
                //UH.Update(userid, UU);
            }
            catch (Exception ex)
            {
                FarsiMessage.Show(ex.Message, "توجه ", FarsiMessageBoxButtons.OK, FarsiMessageBoxIcons.Error);
            }
        }
    }
}
