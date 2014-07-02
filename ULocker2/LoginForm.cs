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
			this.DialogResult = DialogResult.OK;

			// 向远程服务器发送登陆请求
			// 为了debug，先认为返回的是登录成功


			this.ReturnValue1 = "Success.";
			this.Close();
		}
	}
}
