using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

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
		public string ReturnUsername { get; set; }

		public string PostAndRecv(string postData, string url)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);

			Uri target = new Uri(url);
			WebRequest request = WebRequest.Create(target);

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = byteArray.Length;

			string content;
			try
			{
				using (var dataStream = request.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
				}
				using (var response = (HttpWebResponse)request.GetResponse())
				{
					StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
					content = reader.ReadToEnd();
				}
				return content;
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				content = "Cannot connect to remote host";
				return content;
			}
		}

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
			//this.ReturnValue1 = "Success.";
			
			string postData = "username=";
			postData += this.textBoxUsername.Text;
			postData += "&";
			postData = postData + "passwd=" + this.textBoxPasswd.Text;

			// released的时候，password需要md5;
			string recv = PostAndRecv(postData, "http://127.0.0.1/ulocker/login.php");
			
			
			if (recv == "1")
			{
				this.ReturnValue1 = "Success.";
				//MessageBox.Show(this.textBoxUsername.Text);
				this.ReturnUsername = this.textBoxUsername.Text;
				this.Close();
			}
			if (recv == "-1")
			{
				this.ReturnValue1 = "Database error!";
				this.ReturnUsername = null;
			}
			if (recv == "-2")
			{
				this.ReturnValue1 = "Auth fail.";
				this.ReturnUsername = null;
			}
			
			
		}

		protected override void WndProc(ref Message m)
		{
			// 截取关闭消息
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_CLOSE = 0xF060;

			if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
			{
				Environment.Exit(0);
			}

			base.WndProc(ref m);
		}




	}
}
