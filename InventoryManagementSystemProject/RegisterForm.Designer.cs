namespace InventoryManagementSystemProject
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConfirmPassTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PhoneTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FullNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserNameTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LoginLbl = new System.Windows.Forms.Label();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.checkBoxPass = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 77);
            this.panel1.TabIndex = 1;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.Location = new System.Drawing.Point(614, 0);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(21, 26);
            this.CloseBtn.TabIndex = 9;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(162, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Inventory Management System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(266, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Register";
            // 
            // ConfirmPassTxt
            // 
            this.ConfirmPassTxt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConfirmPassTxt.Location = new System.Drawing.Point(179, 348);
            this.ConfirmPassTxt.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPassTxt.Name = "ConfirmPassTxt";
            this.ConfirmPassTxt.Size = new System.Drawing.Size(408, 26);
            this.ConfirmPassTxt.TabIndex = 23;
            this.ConfirmPassTxt.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 352);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Confirm Password :";
            // 
            // PhoneTxt
            // 
            this.PhoneTxt.Location = new System.Drawing.Point(179, 400);
            this.PhoneTxt.Margin = new System.Windows.Forms.Padding(4);
            this.PhoneTxt.Name = "PhoneTxt";
            this.PhoneTxt.Size = new System.Drawing.Size(408, 26);
            this.PhoneTxt.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 404);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Phone no. :";
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Location = new System.Drawing.Point(179, 279);
            this.PasswordTxt.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(408, 26);
            this.PasswordTxt.TabIndex = 19;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 283);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Password :";
            // 
            // FullNameTxt
            // 
            this.FullNameTxt.Location = new System.Drawing.Point(179, 227);
            this.FullNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.FullNameTxt.Name = "FullNameTxt";
            this.FullNameTxt.Size = new System.Drawing.Size(408, 26);
            this.FullNameTxt.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Full Name :";
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.Location = new System.Drawing.Point(179, 174);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.Size = new System.Drawing.Size(408, 26);
            this.UserNameTxt.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 178);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "User Name :";
            // 
            // LoginLbl
            // 
            this.LoginLbl.AutoSize = true;
            this.LoginLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginLbl.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLbl.ForeColor = System.Drawing.Color.Black;
            this.LoginLbl.Location = new System.Drawing.Point(233, 497);
            this.LoginLbl.Name = "LoginLbl";
            this.LoginLbl.Size = new System.Drawing.Size(166, 20);
            this.LoginLbl.TabIndex = 24;
            this.LoginLbl.Text = "Already an user? Login";
            this.LoginLbl.Click += new System.EventHandler(this.LoginLbl_Click);
            this.LoginLbl.MouseLeave += new System.EventHandler(this.LoginLbl_MouseLeave);
            this.LoginLbl.MouseHover += new System.EventHandler(this.LoginLbl_MouseHover);
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.BackColor = System.Drawing.Color.Blue;
            this.RegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.ForeColor = System.Drawing.Color.White;
            this.RegisterBtn.Location = new System.Drawing.Point(179, 539);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(273, 46);
            this.RegisterBtn.TabIndex = 25;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = false;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLabel.ForeColor = System.Drawing.Color.Blue;
            this.ClearLabel.Location = new System.Drawing.Point(537, 451);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(50, 23);
            this.ClearLabel.TabIndex = 26;
            this.ClearLabel.Text = "Clear";
            this.ClearLabel.Click += new System.EventHandler(this.ClearLabel_Click);
            // 
            // checkBoxPass
            // 
            this.checkBoxPass.AutoSize = true;
            this.checkBoxPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPass.Location = new System.Drawing.Point(465, 312);
            this.checkBoxPass.Name = "checkBoxPass";
            this.checkBoxPass.Size = new System.Drawing.Size(122, 20);
            this.checkBoxPass.TabIndex = 27;
            this.checkBoxPass.Text = "Show Password";
            this.checkBoxPass.UseVisualStyleBackColor = true;
            this.checkBoxPass.CheckedChanged += new System.EventHandler(this.checkBoxPass_CheckedChanged);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 627);
            this.Controls.Add(this.checkBoxPass);
            this.Controls.Add(this.ClearLabel);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.LoginLbl);
            this.Controls.Add(this.ConfirmPassTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PhoneTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FullNameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNameTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox CloseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox ConfirmPassTxt;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox PhoneTxt;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox FullNameTxt;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox UserNameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LoginLbl;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.CheckBox checkBoxPass;
    }
}