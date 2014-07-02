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
	public partial class RegistryForm : Form
	{
		public RegistryForm()
		{
			InitializeComponent();
		}

		private void buttonCancelRegistry_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonSubmit_Click(object sender, EventArgs e)
		{
			// 判断所有带*的是否填写完整
			if (textBoxUsername.Text.Length == 0)
			{
				textBoxUsername.BackColor = Color.Red;
				MessageBox.Show("请填写用户名");
				return;
			}
			if (textBoxPassword.Text.Length == 0)
			{
				textBoxPassword.BackColor = Color.Red;
				MessageBox.Show("请填写密码");
				return;
			}
			if (textBoxPasswordConfirm.Text.Length == 0)
			{
				textBoxPasswordConfirm.BackColor = Color.Red;
				MessageBox.Show("请填写确认密码");
				return;
			}
			if (textBoxEmail.Text.Length == 0)
			{
				textBoxEmail.BackColor = Color.Red;
				MessageBox.Show("请填写邮箱");
				return;
			}
			string strUDisk;
			try
			{
				strUDisk = comboBoxUDisk.SelectedItem.ToString();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("请选择U盘");
				return;
			}



		}

		private void textBoxUsername_MouseDown(object sender, MouseEventArgs e)
		{
			textBoxUsername.BackColor = Color.White;
		}

		private void textBoxUsername_Leave(object sender, EventArgs e)
		{
			if (textBoxUsername.Text.Length >= 3 && textBoxUsername.Text.Length <= 16)
			{
				textBoxUsername.BackColor = Color.Green;
			}
			else
			{
				textBoxUsername.BackColor = Color.Red;
			}

		}
	}
}
