namespace ULocker2
{
	partial class LoginForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxPasswd = new System.Windows.Forms.TextBox();
			this.buttonLogin = new System.Windows.Forms.Button();
			this.buttonRegistry = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "用户名：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(41, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "密码：";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(84, 23);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(230, 21);
			this.textBoxUsername.TabIndex = 2;
			// 
			// textBoxPasswd
			// 
			this.textBoxPasswd.Location = new System.Drawing.Point(84, 62);
			this.textBoxPasswd.Name = "textBoxPasswd";
			this.textBoxPasswd.PasswordChar = '#';
			this.textBoxPasswd.Size = new System.Drawing.Size(230, 21);
			this.textBoxPasswd.TabIndex = 3;
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point(23, 103);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(75, 23);
			this.buttonLogin.TabIndex = 4;
			this.buttonLogin.Text = "登陆";
			this.buttonLogin.UseVisualStyleBackColor = true;
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// buttonRegistry
			// 
			this.buttonRegistry.Location = new System.Drawing.Point(136, 103);
			this.buttonRegistry.Name = "buttonRegistry";
			this.buttonRegistry.Size = new System.Drawing.Size(75, 23);
			this.buttonRegistry.TabIndex = 5;
			this.buttonRegistry.Text = "注册";
			this.buttonRegistry.UseVisualStyleBackColor = true;
			this.buttonRegistry.Click += new System.EventHandler(this.buttonRegistry_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(249, 103);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "关闭";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(345, 145);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRegistry);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.textBoxPasswd);
			this.Controls.Add(this.textBoxUsername);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "LoginForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "登陆 - 基于U盘文件加密系统 V2.0";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxPasswd;
		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonRegistry;
		private System.Windows.Forms.Button buttonClose;
	}
}