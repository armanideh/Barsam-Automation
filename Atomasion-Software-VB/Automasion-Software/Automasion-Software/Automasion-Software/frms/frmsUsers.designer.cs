namespace Automasion_Software
{
    partial class frmsUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsUsers));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Controls.Add(this.btnUpdate);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.txtPass);
            this.panel4.Controls.Add(this.txtUserName);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtName);
            this.panel4.Controls.Add(this.label32);
            this.panel4.Controls.Add(this.txtFamily);
            this.panel4.Controls.Add(this.label33);
            this.panel4.Controls.Add(this.label127);
            this.panel4.Controls.Add(this.label129);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 217);
            this.panel4.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(290, 140);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(67, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "ویرایش";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 42);
            this.panel1.TabIndex = 312;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 30);
            this.button2.TabIndex = 12;
            this.button2.Text = "برگشت";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Location = new System.Drawing.Point(37, 114);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(149, 21);
            this.txtPass.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(229, 113);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 21);
            this.txtUserName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 239;
            this.label1.Text = "کلمه عبور :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 238;
            this.label2.Text = "نام کاربری : ";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(229, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 21);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "-";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(333, 47);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 120;
            this.label32.Text = "نام :";
            // 
            // txtFamily
            // 
            this.txtFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFamily.Location = new System.Drawing.Point(37, 64);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(149, 21);
            this.txtFamily.TabIndex = 1;
            this.txtFamily.Text = "-";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(115, 48);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(72, 13);
            this.label33.TabIndex = 119;
            this.label33.Text = "نام خانوادگی :";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.BackColor = System.Drawing.Color.Transparent;
            this.label127.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.ForeColor = System.Drawing.Color.Black;
            this.label127.Location = new System.Drawing.Point(216, 14);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(144, 14);
            this.label127.TabIndex = 115;
            this.label127.Text = "ویرایش اطلاعات شخصی : ";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.BackColor = System.Drawing.Color.Transparent;
            this.label129.ForeColor = System.Drawing.Color.Black;
            this.label129.Location = new System.Drawing.Point(-344, 28);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(757, 13);
            this.label129.TabIndex = 116;
            this.label129.Text = "_________________________________________________________________________________" +
    "____________________________________________";
            // 
            // frmsUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 217);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsUsers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ویرایش حساب کاربری ";
            this.Load += new System.EventHandler(this.frmsUsers_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUpdate;
    }
}