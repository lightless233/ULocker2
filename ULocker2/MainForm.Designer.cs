namespace ULocker2
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.注册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出当前用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonSelectFile = new System.Windows.Forms.Button();
			this.textFilePath = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBoxUDevice = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonGetMyUserGroup = new System.Windows.Forms.Button();
			this.comboBoxShareMode = new System.Windows.Forms.ComboBox();
			this.textBoxUserSalt = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.comboBoxEncryptionAlgorithm = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButtonDecrypto = new System.Windows.Forms.RadioButton();
			this.radioButtonEncrypto = new System.Windows.Forms.RadioButton();
			this.buttonDo = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(560, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登陆ToolStripMenuItem,
            this.注册ToolStripMenuItem,
            this.退出当前用户ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
			this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.文件ToolStripMenuItem.Text = "文件";
			// 
			// 登陆ToolStripMenuItem
			// 
			this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
			this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.登陆ToolStripMenuItem.Text = "登陆";
			this.登陆ToolStripMenuItem.Click += new System.EventHandler(this.登陆ToolStripMenuItem_Click);
			// 
			// 注册ToolStripMenuItem
			// 
			this.注册ToolStripMenuItem.Name = "注册ToolStripMenuItem";
			this.注册ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.注册ToolStripMenuItem.Text = "注册";
			this.注册ToolStripMenuItem.Click += new System.EventHandler(this.注册ToolStripMenuItem_Click);
			// 
			// 退出当前用户ToolStripMenuItem
			// 
			this.退出当前用户ToolStripMenuItem.Name = "退出当前用户ToolStripMenuItem";
			this.退出当前用户ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.退出当前用户ToolStripMenuItem.Text = "退出当前用户";
			this.退出当前用户ToolStripMenuItem.Click += new System.EventHandler(this.退出当前用户ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// 帮助ToolStripMenuItem
			// 
			this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.关于ToolStripMenuItem});
			this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.帮助ToolStripMenuItem.Text = "帮助";
			// 
			// 帮助ToolStripMenuItem1
			// 
			this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
			this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.帮助ToolStripMenuItem1.Text = "帮助";
			this.帮助ToolStripMenuItem1.Click += new System.EventHandler(this.帮助ToolStripMenuItem1_Click);
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.关于ToolStripMenuItem.Text = "关于";
			this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonSelectFile);
			this.groupBox1.Controls.Add(this.textFilePath);
			this.groupBox1.Location = new System.Drawing.Point(12, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(538, 52);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "选择需要操作的文件";
			// 
			// buttonSelectFile
			// 
			this.buttonSelectFile.Location = new System.Drawing.Point(398, 18);
			this.buttonSelectFile.Name = "buttonSelectFile";
			this.buttonSelectFile.Size = new System.Drawing.Size(119, 23);
			this.buttonSelectFile.TabIndex = 1;
			this.buttonSelectFile.Text = "选择文件...";
			this.buttonSelectFile.UseVisualStyleBackColor = true;
			this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
			// 
			// textFilePath
			// 
			this.textFilePath.Location = new System.Drawing.Point(6, 20);
			this.textFilePath.Name = "textFilePath";
			this.textFilePath.Size = new System.Drawing.Size(375, 21);
			this.textFilePath.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBoxUDevice);
			this.groupBox2.Location = new System.Drawing.Point(12, 86);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(538, 53);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "请选择U盘";
			// 
			// comboBoxUDevice
			// 
			this.comboBoxUDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxUDevice.FormattingEnabled = true;
			this.comboBoxUDevice.Location = new System.Drawing.Point(6, 20);
			this.comboBoxUDevice.Name = "comboBoxUDevice";
			this.comboBoxUDevice.Size = new System.Drawing.Size(511, 20);
			this.comboBoxUDevice.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.buttonGetMyUserGroup);
			this.groupBox3.Controls.Add(this.comboBoxShareMode);
			this.groupBox3.Controls.Add(this.textBoxUserSalt);
			this.groupBox3.Controls.Add(this.textBoxUsername);
			this.groupBox3.Controls.Add(this.comboBoxEncryptionAlgorithm);
			this.groupBox3.Location = new System.Drawing.Point(12, 145);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(409, 168);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "加解密设置";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "自定义密钥：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "加解密算法：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "文件共享方式：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "用户名：";
			// 
			// buttonGetMyUserGroup
			// 
			this.buttonGetMyUserGroup.Location = new System.Drawing.Point(283, 18);
			this.buttonGetMyUserGroup.Name = "buttonGetMyUserGroup";
			this.buttonGetMyUserGroup.Size = new System.Drawing.Size(120, 23);
			this.buttonGetMyUserGroup.TabIndex = 5;
			this.buttonGetMyUserGroup.Text = "获取我的用户组";
			this.buttonGetMyUserGroup.UseVisualStyleBackColor = true;
			this.buttonGetMyUserGroup.Click += new System.EventHandler(this.buttonGetMyUserGroup_Click);
			// 
			// comboBoxShareMode
			// 
			this.comboBoxShareMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxShareMode.FormattingEnabled = true;
			this.comboBoxShareMode.Location = new System.Drawing.Point(99, 55);
			this.comboBoxShareMode.Name = "comboBoxShareMode";
			this.comboBoxShareMode.Size = new System.Drawing.Size(304, 20);
			this.comboBoxShareMode.TabIndex = 0;
			// 
			// textBoxUserSalt
			// 
			this.textBoxUserSalt.Location = new System.Drawing.Point(99, 123);
			this.textBoxUserSalt.Name = "textBoxUserSalt";
			this.textBoxUserSalt.Size = new System.Drawing.Size(304, 21);
			this.textBoxUserSalt.TabIndex = 0;
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(99, 20);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(172, 21);
			this.textBoxUsername.TabIndex = 0;
			// 
			// comboBoxEncryptionAlgorithm
			// 
			this.comboBoxEncryptionAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEncryptionAlgorithm.FormattingEnabled = true;
			this.comboBoxEncryptionAlgorithm.Items.AddRange(new object[] {
            "AES - 高级加密标准 (默认，推荐算法)",
            "DES - 数据加密算法 (适合文件保密性不高的文件)",
            "TripleDES - 3层数据加密算法 (比DES安全性较高)",
            "RC2 - Ron\'s Code (速度快，适合大文件)"});
			this.comboBoxEncryptionAlgorithm.Location = new System.Drawing.Point(99, 89);
			this.comboBoxEncryptionAlgorithm.Name = "comboBoxEncryptionAlgorithm";
			this.comboBoxEncryptionAlgorithm.Size = new System.Drawing.Size(304, 20);
			this.comboBoxEncryptionAlgorithm.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButtonDecrypto);
			this.groupBox4.Controls.Add(this.radioButtonEncrypto);
			this.groupBox4.Location = new System.Drawing.Point(427, 145);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(123, 69);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "功能区";
			// 
			// radioButtonDecrypto
			// 
			this.radioButtonDecrypto.AutoSize = true;
			this.radioButtonDecrypto.Location = new System.Drawing.Point(35, 43);
			this.radioButtonDecrypto.Name = "radioButtonDecrypto";
			this.radioButtonDecrypto.Size = new System.Drawing.Size(47, 16);
			this.radioButtonDecrypto.TabIndex = 0;
			this.radioButtonDecrypto.TabStop = true;
			this.radioButtonDecrypto.Text = "解密";
			this.radioButtonDecrypto.UseVisualStyleBackColor = true;
			// 
			// radioButtonEncrypto
			// 
			this.radioButtonEncrypto.AutoSize = true;
			this.radioButtonEncrypto.Location = new System.Drawing.Point(35, 21);
			this.radioButtonEncrypto.Name = "radioButtonEncrypto";
			this.radioButtonEncrypto.Size = new System.Drawing.Size(47, 16);
			this.radioButtonEncrypto.TabIndex = 0;
			this.radioButtonEncrypto.TabStop = true;
			this.radioButtonEncrypto.Text = "加密";
			this.radioButtonEncrypto.UseVisualStyleBackColor = true;
			// 
			// buttonDo
			// 
			this.buttonDo.Location = new System.Drawing.Point(434, 235);
			this.buttonDo.Name = "buttonDo";
			this.buttonDo.Size = new System.Drawing.Size(114, 23);
			this.buttonDo.TabIndex = 5;
			this.buttonDo.Text = "加/解密";
			this.buttonDo.UseVisualStyleBackColor = true;
			this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
			// 
			// buttonExit
			// 
			this.buttonExit.Location = new System.Drawing.Point(434, 275);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(114, 23);
			this.buttonExit.TabIndex = 5;
			this.buttonExit.Text = "退出程序";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 325);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.buttonDo);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(576, 363);
			this.MinimumSize = new System.Drawing.Size(576, 363);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ULocker - 基于U盘文件加密系统 V2.0";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonSelectFile;
		private System.Windows.Forms.TextBox textFilePath;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxUDevice;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox comboBoxShareMode;
		private System.Windows.Forms.TextBox textBoxUserSalt;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.ComboBox comboBoxEncryptionAlgorithm;
		private System.Windows.Forms.RadioButton radioButtonDecrypto;
		private System.Windows.Forms.RadioButton radioButtonEncrypto;
		private System.Windows.Forms.Button buttonDo;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonGetMyUserGroup;
		private System.Windows.Forms.ToolStripMenuItem 注册ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出当前用户ToolStripMenuItem;
	}
}

