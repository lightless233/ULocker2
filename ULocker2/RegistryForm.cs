using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Threading;
using System.Security.Cryptography;
using System.Net;

namespace ULocker2
{
	public partial class RegistryForm : Form
	{
		uint gRemoveableDeviceCount = 0;

		public RegistryForm()
		{
			InitializeComponent();
			//gRemoveableDeviceCount = form1.getDriverType();
			gRemoveableDeviceCount = getDriverType();
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
				strUDisk = comboBoxUDevice.SelectedItem.ToString();
				if (strUDisk == "没有发现U盘设备！")
				{
					MessageBox.Show("请选择U盘!");
					return;
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("请选择U盘");
				return;
			}
			if (textBoxPhoneNumber.Text.Length != 0)
			{
				if (textBoxPhoneNumber.Text.Length != 11)
				{
					MessageBox.Show("手机无效！");
					textBoxPhoneNumber.Focus();
					textBoxPhoneNumber.BackColor = Color.Red;
					return;
				}
				foreach (char i in textBoxPhoneNumber.Text)
				{
					if (!(i <= '9' && i >= '0'))
					{
						MessageBox.Show("手机无效！");
						textBoxPhoneNumber.Focus();
						textBoxPhoneNumber.BackColor = Color.Red;
						return;
					}
				}


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

		protected override void WndProc(ref Message m)
		{
			const int WM_DEVICECHANGE = 0x219;		//硬件设备状态改变
			const int DBT_DEVICEARRIVAL = 0x8000;	//U盘插入
			//const int DBT_CONFIGCHANGECANCELED = 0x0019;	//要求更改当前的配置已被取消
			const int DBT_DEVICEREMOVECOMPLETE = 0x8004;	//U盘拔出

			// 截取关闭消息
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_CLOSE = 0xF060;

			if (m.Msg == WM_DEVICECHANGE)
			{
				switch (m.WParam.ToInt32())
				{
					case WM_DEVICECHANGE:
						break;
					case DBT_DEVICEARRIVAL:
						//检测到U盘插入
						gRemoveableDeviceCount = getDriverType();
						break;
					case DBT_DEVICEREMOVECOMPLETE:
						//检测到U盘拔出
						gRemoveableDeviceCount = getDriverType();
						break;
					default:
						break;
				}
			}
			base.WndProc(ref m);
		}

		public uint getDriverType()
		{
			uint RemoveableDeviceCount = 0;
			// 清空combox
			this.comboBoxUDevice.Items.Clear();
			// 获取所有驱动器信息
			DriveInfo[] allDrivers = DriveInfo.GetDrives();
			foreach (DriveInfo d in allDrivers)
			{
				//MessageBox.Show(d.DriveType.ToString() + d.Name.ToString());
				// 判断是否为移动设备
				if (d.DriveType.ToString() == "Removable")
				{
					RemoveableDeviceCount += 1;
					//MessageBox.Show(d.VolumeLabel.ToString());
					comboBoxUDevice.Items.Add(d.Name.ToString() +
						" " + d.VolumeLabel.ToString() +
						" " + d.DriveFormat.ToString() +
						" " + d.TotalSize.ToString());
					/*
					comboBoxUDevice.Items.Add(d.Name.ToString() +
						" " + d.VolumeLabel.ToString() +
						" " + d.DriveFormat.ToString() +
						" " + d.TotalSize.ToString());*/
				}
			}

			if (RemoveableDeviceCount == 0)
			{
				comboBoxUDevice.Items.Clear();
				comboBoxUDevice.Items.Add("没有发现U盘设备！");
				this.comboBoxUDevice.SelectedIndex = 0;
			}
			else comboBoxUDevice.SelectedIndex = 0;

			return RemoveableDeviceCount;
		}

		private void textBoxPhoneNumber_MouseDown(object sender, MouseEventArgs e)
		{
			textBoxPhoneNumber.BackColor = Color.White;
		}

		private void textBoxPhoneNumber_Leave(object sender, EventArgs e)
		{
			if (textBoxPhoneNumber.Text.Length == 11)
			{
				foreach (char i in textBoxPhoneNumber.Text)
				{
					if (i >= '0' && i <= '9')
					{
						textBoxPhoneNumber.BackColor = Color.Green;
					}
					else
					{
						textBoxPhoneNumber.BackColor = Color.Red;
						return;
					}
				}
			}
			else
			{
				textBoxPhoneNumber.BackColor = Color.Red;
			}
				

		}

	}
}
