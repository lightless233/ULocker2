using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ULocker2
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void buttonRegistry_Click(object sender, EventArgs e)
		{
			RegistryForm registryform = new RegistryForm();
			registryform.ShowDialog();
		}


		public string ReturnValue1 { get; set; }

		private void buttonLogin_Click(object sender, EventArgs e)
		{

			// 检查用户名密码是否填写完整
			if (this.textBoxUsername.Text.Length == 0)
			{
				MessageBox.Show("请填写用户名!");
				return;
			}
			if (this.textBoxPasswd.Text.Length == 0)
			{
				MessageBox.Show("请填写密码!");
				return;
			}

			// 检查用户名密码中是否含有特殊字符
			System.Text.RegularExpressions.Regex regexCommon =
				new System.Text.RegularExpressions.Regex(@"^[0-9a-zA-Z]{3,}$");
			if (!regexCommon.IsMatch(this.textBoxUsername.Text))
			{
				MessageBox.Show("用户名非法!");
				return;
			}
			if (!regexCommon.IsMatch(this.textBoxPasswd.Text))
			{
				MessageBox.Show("密码非法！");
				return;
			}

			this.DialogResult = DialogResult.OK;

			// 向远程服务器发送登陆请求
			// 为了debug，先认为返回的是登录成功
			this.ReturnValue1 = "Success.";
			this.Close();
		}
	}
}
