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
    public partial class frmUser : Form
    {
        DataBase DB = new DataBase();
        UserHandller UH = new UserHandller();
        public frmUser()
        {
            InitializeComponent();
        }

        private void txtPerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgUsers.DataSource = DB.ExecuteSelectSQL("select UID as 'کد',UName + ' ' + UFamily as 'مشخصات_فردی',URole as 'نقش',UGroup_Name as 'گروه' from Users where UFamily like N'%" + txtPerName.Text + "%'");
            }
            catch (Exception ex)
            {
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            dgUsers.DataSource = UH.ShowAll();
            Other.colorize(dgUsers);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Other.UserID = userid;
            Other.selectTypeUser = 1;
            this.Close();
        }

        int userid = 0;
        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userid = int.Parse(dgUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(userid.ToString());
            }
            catch (Exception ex)
            { }
        }

        private void dgUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button8_Click(sender, e);
        }
    }
}
