namespace Automasion_Software
{
    partial class frmUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.txtPerName = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPerName
            // 
            this.txtPerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerName.Location = new System.Drawing.Point(12, 31);
            this.txtPerName.Name = "txtPerName";
            this.txtPerName.Size = new System.Drawing.Size(309, 21);
            this.txtPerName.TabIndex = 107;
            this.txtPerName.Text = "-";
            this.txtPerName.TextChanged += new System.EventHandler(this.txtPerName_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(12, 15);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 108;
            this.label32.Text = "نام :";
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToDeleteRows = false;
            this.dgUsers.AllowUserToResizeColumns = false;
            this.dgUsers.AllowUserToResizeRows = false;
            this.dgUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgUsers.Location = new System.Drawing.Point(0, 58);
            this.dgUsers.MultiSelect = false;
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUsers.RowHeadersVisible = false;
            this.dgUsers.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgUsers.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgUsers.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgUsers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgUsers.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsers.Size = new System.Drawing.Size(513, 361);
            this.dgUsers.TabIndex = 109;
            this.dgUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsers_CellClick);
            this.dgUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsers_CellDoubleClick);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(442, 31);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(67, 24);
            this.button8.TabIndex = 110;
            this.button8.Text = "انتخاب";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 419);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dgUsers);
            this.Controls.Add(this.txtPerName);
            this.Controls.Add(this.label32);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب گیرنده / فرستنده";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPerName;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.Button button8;
    }
}