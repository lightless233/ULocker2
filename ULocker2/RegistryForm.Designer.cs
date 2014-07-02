namespace ULocker2
{
	partial class RegistryForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPasswordConfirm = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxUDevice = new System.Windows.Forms.ComboBox();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonSubmit = new System.Windows.Forms.Button();
			this.buttonCancelRegistry = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "*用户名：";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(70, 6);
			this.textBoxUsername.MaxLength = 16;
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(152, 21);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
			this.textBoxUsername.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxUsername_MouseDown);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(70, 33);
			this.textBoxPassword.MaxLength = 32;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '#';
			this.textBoxPassword.Size = new System.Drawing.Size(152, 21);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "*密码：";
			// 
			// textBoxPasswordConfirm
			// 
			this.textBoxPasswordConfirm.Location = new System.Drawing.Point(70, 60);
			this.textBoxPasswordConfirm.MaxLength = 32;
			this.textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
			this.textBoxPasswordConfirm.PasswordChar = '#';
			this.textBoxPasswordConfirm.Size = new System.Drawing.Size(152, 21);
			this.textBoxPasswordConfirm.TabIndex = 5;
			this.textBoxPasswordConfirm.Leave += new System.EventHandler(this.textBoxPasswordConfirm_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "*确认密码：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "请选择需要绑定的U盘";
			// 
			// comboBoxUDevice
			// 
			this.comboBoxUDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxUDevice.FormattingEnabled = true;
			this.comboBoxUDevice.Location = new System.Drawing.Point(23, 163);
			this.comboBoxUDevice.Name = "comboBoxUDevice";
			this.comboBoxUDevice.Size = new System.Drawing.Size(345, 20);
			this.comboBoxUDevice.TabIndex = 7;
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(70, 87);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(152, 21);
			this.textBoxEmail.TabIndex = 9;
			this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
			this.textBoxEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxEmail_MouseDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 90);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 12);
			this.label5.TabIndex = 8;
			this.label5.Text = "*邮箱：";
			// 
			// textBoxPhoneNumber
			// 
			this.textBoxPhoneNumber.Location = new System.Drawing.Point(70, 114);
			this.textBoxPhoneNumber.MaxLength = 11;
			this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
			this.textBoxPhoneNumber.Size = new System.Drawing.Size(152, 21);
			this.textBoxPhoneNumber.TabIndex = 11;
			this.textBoxPhoneNumber.Leave += new System.EventHandler(this.textBoxPhoneNumber_Leave);
			this.textBoxPhoneNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxPhoneNumber_MouseDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(33, 117);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "手机：";
			// 
			// buttonSubmit
			// 
			this.buttonSubmit.Location = new System.Drawing.Point(89, 212);
			this.buttonSubmit.Name = "buttonSubmit";
			this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
			this.buttonSubmit.TabIndex = 12;
			this.buttonSubmit.Text = "注册";
			this.buttonSubmit.UseVisualStyleBackColor = true;
			this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
			// 
			// buttonCancelRegistry
			// 
			this.buttonCancelRegistry.Location = new System.Drawing.Point(213, 212);
			this.buttonCancelRegistry.Name = "buttonCancelRegistry";
			this.buttonCancelRegistry.Size = new System.Drawing.Size(75, 23);
			this.buttonCancelRegistry.TabIndex = 13;
			this.buttonCancelRegistry.Text = "取消";
			this.buttonCancelRegistry.UseVisualStyleBackColor = true;
			this.buttonCancelRegistry.Click += new System.EventHandler(this.buttonCancelRegistry_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(22, 192);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 12);
			this.label7.TabIndex = 14;
			this.label7.Text = "其中带*为必填项";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(231, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(137, 12);
			this.label8.TabIndex = 15;
			this.label8.Text = "3~16个字符，数字和字母";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(231, 36);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(137, 12);
			this.label9.TabIndex = 15;
			this.label9.Text = "6~32个字符，数字和字母";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(231, 63);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 12);
			this.label10.TabIndex = 15;
			this.label10.Text = "请重复密码";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(231, 90);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(149, 12);
			this.label11.TabIndex = 15;
			this.label11.Text = "有效的邮箱地址，找回密码";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(231, 117);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 12);
			this.label12.TabIndex = 15;
			this.label12.Text = "可不填";
			// 
			// RegistryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 245);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.buttonCancelRegistry);
			this.Controls.Add(this.buttonSubmit);
			this.Controls.Add(this.textBoxPhoneNumber);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.comboBoxUDevice);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxPasswordConfirm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxUsername);
			this.Controls.Add(this.label1);
			this.Name = "RegistryForm";
			this.Text = "注册";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPasswordConfirm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxUDevice;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxPhoneNumber;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonSubmit;
		private System.Windows.Forms.Button buttonCancelRegistry;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
	}
}