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
using System.Diagnostics;

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
			System.Text.RegularExpressions.Regex regexCommon = 
				new System.Text.RegularExpressions.Regex("^[0-9A-Za-z]+$");
			//MessageBox.Show(regexCommon.IsMatch(this.textBoxUsername.Text).ToString());
			if (!regexCommon.IsMatch(this.textBoxUsername.Text) || 
				this.textBoxUsername.Text.Length < 3 || this.textBoxUsername.Text.Length > 16)
			{
				textBoxUsername.BackColor = Color.Red;
				MessageBox.Show("用户名非法");
				return;
			}
			if (textBoxUsername.Text.Length == 0)
			{
				textBoxUsername.BackColor = Color.Red;
				MessageBox.Show("请填写用户名");
				return;
			}
			if (!regexCommon.IsMatch(this.textBoxPassword.Text) ||
				this.textBoxPassword.Text.Length < 6 )
			{
				textBoxPassword.BackColor = Color.Red;
				MessageBox.Show("密码非法");
				return;
			}
			if (!regexCommon.IsMatch(this.textBoxPasswordConfirm.Text) || 
				this.textBoxPasswordConfirm.Text.Length < 6)
			{
				textBoxPasswordConfirm.BackColor = Color.Red;
				MessageBox.Show("重复密码非法");
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
			System.Text.RegularExpressions.Regex regexEmail = 
				new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-.]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-.]+$");
			if (!regexEmail.IsMatch(this.textBoxEmail.Text))
			{
				this.textBoxEmail.BackColor = Color.Red;
				MessageBox.Show("邮箱无效");
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
			// 判断两个密码是否一样
			// MessageBox.Show(textBoxPassword.Text + "\r\n" + textBoxPasswordConfirm.Text);
			if (this.textBoxPasswordConfirm.Text != this.textBoxPassword.Text)
			{
				MessageBox.Show("密码不一致");
				this.textBoxPasswordConfirm.BackColor = Color.Red;
				return;
			}

			// 验证完毕，准备进行 加密 & post数据

			string phonenumber = null;
			if (this.textBoxPhoneNumber.Text.Length != 0)
			{
				phonenumber = this.textBoxPhoneNumber.Text;
			}
			else
			{
				phonenumber = "null";
			}

			// 现在是debug版本，正式发布的时候需要对这里进行改进，增加上相应的
			// 算法
			string strSelectDevice = comboBoxUDevice.SelectedItem.ToString();
			string[] TargetDevice = strSelectDevice.Split(' ');
			string serialNumber = GetRemoveableDeviceSerialNumber(TargetDevice[0]);

			// md5(password)
			byte[] MD5res = Encoding.Default.GetBytes(this.textBoxPassword.Text.Trim());
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] output = md5.ComputeHash(MD5res);
			string pwd = BitConverter.ToString(output).Replace("-","");

			//MessageBox.Show(pwd);

			string recv = null;
			string postData = "username=" + this.textBoxUsername.Text + "&" +
				"passwd=" + pwd.ToLower() + "&" +
				"email=" + this.textBoxEmail.Text + "&" +
				"phonenumber=" + phonenumber + "&" +
				"ukey=" + serialNumber;
			/*
			recv = PostAndRecv(postData, 
				"http://127.0.0.1/ulocker/registry-master.php");
			*/
			//recv = PostAndRecv(postData, "http://107.167.191.113/e7b048d514f5a233ff9afdd97b0394ca.php");
			recv = PostAndRecv(postData, "http://Ulocker.info/e7b048d514f5a233ff9afdd97b0394ca.php");

			Debug.WriteLine("postData = " + postData);
			Debug.WriteLine("recv = " + recv);

			//MessageBox.Show(recv);

			if (recv.Trim() == "1")
			{
				MessageBox.Show("注册成功！请牢记您的用户名密码!");
				this.Close();
				return;
			}
			else if (recv.Trim() == "-1")
			{
				MessageBox.Show("服务器可能正在维护中，请稍后再尝试。");
				return;
			}
			else if (recv.Trim() == "-2")
			{
				MessageBox.Show("远程服务器错误！");
				return;
			}
			else if (recv.Trim() == "-3")
			{
				MessageBox.Show("用户名已经存在!");
				return;
			}
			else
			{
				MessageBox.Show("未知错误!");
				return;
			}
			

		}

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

		private void textBoxUsername_MouseDown(object sender, MouseEventArgs e)
		{
			textBoxUsername.BackColor = Color.White;
		}

		private void textBoxUsername_Leave(object sender, EventArgs e)
		{
			System.Text.RegularExpressions.Regex regexUser = 
				new System.Text.RegularExpressions.Regex("^[0-9A-Za-z]+$");

			if (!regexUser.IsMatch(this.textBoxUsername.Text))
			{
				textBoxUsername.BackColor = Color.Red;
			}
			else textBoxUsername.BackColor = Color.Green;

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

		private void textBoxEmail_Leave(object sender, EventArgs e)
		{
			System.Text.RegularExpressions.Regex regex =
				new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-.]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-.]+$");
			if (!regex.IsMatch(textBoxEmail.Text))
			{
				this.textBoxEmail.BackColor = Color.Red;
				return;
			}
			else
			{
				this.textBoxEmail.BackColor = Color.Green;
			}
		}

		private void textBoxEmail_MouseDown(object sender, MouseEventArgs e)
		{
			this.textBoxEmail.BackColor = Color.White;
		}

		private void textBoxPassword_Leave(object sender, EventArgs e)
		{
			System.Text.RegularExpressions.Regex regexPasswd =
				new System.Text.RegularExpressions.Regex("^[0-9A-Za-z]+$");
			if (!regexPasswd.IsMatch(this.textBoxPassword.Text))
			{
				this.textBoxPassword.BackColor = Color.Red;
				return;
			}
			else
			{
				this.textBoxPassword.BackColor = Color.Green;
				return;
			}
		}

		private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
		{
			System.Text.RegularExpressions.Regex regexPasswd =
	new System.Text.RegularExpressions.Regex("^[0-9A-Za-z]+$");
			if (!regexPasswd.IsMatch(this.textBoxPasswordConfirm.Text))
			{
				this.textBoxPasswordConfirm.BackColor = Color.Red;
			}
			else
			{
				this.textBoxPasswordConfirm.BackColor = Color.Green;
			}
			if (this.textBoxPasswordConfirm.Text != this.textBoxPassword.Text)
			{
				this.textBoxPasswordConfirm.BackColor = Color.Red;
			}

		}


		private string getValueInQuotes(string inValue)
		{
			string parsedValue = "";

			int posFoundStart = 0;
			int posFoundEnd = 0;

			posFoundStart = inValue.IndexOf("\"");
			posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);

			parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);

			return parsedValue;
		}

		// 在GetRemoveableDeviceSerialNumber 中对serialnumber进行过滤
		// 状态：完成
		// 完成日期：2014.4.22
		// 最后修改日期：2014.4.22
		private string parseSerialFromDeviceID(string deviceId)
		{
			string[] splitDeviceId = deviceId.Split('\\');
			string[] serialArray;
			string serial;
			int arrayLen = splitDeviceId.Length - 1;

			serialArray = splitDeviceId[arrayLen].Split('&');
			serial = serialArray[serialArray.Length - 2];

			return serial;
		}

		// 获取指定盘符的序列号
		// 参数DeviceName：指定盘符，例如C:\
		// 返回值为序列号
		// 状态：完成
		// 完成日期：2014-04-22
		// 最后修改日期：2014-04-22
		public string GetRemoveableDeviceSerialNumber(string DeviceName)
		{
			string[] diskArray;
			string driveNumber;
			string driveLetter;

			string serialNumber = null;

			ManagementObjectSearcher searcher =
				new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
			foreach (ManagementObject dm in searcher.Get())
			{
				diskArray = null;
				driveLetter = getValueInQuotes(dm["Dependent"].ToString());
				diskArray = getValueInQuotes(dm["Antecedent"].ToString()).Split(',');
				driveNumber = diskArray[0].Remove(0, 6).Trim();
				string[] t = DeviceName.Split('\\');
				if (driveLetter == t[0])
				{
					/* This is where we get the drive serial */
					ManagementObjectSearcher disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
					foreach (ManagementObject disk in disks.Get())
					{
						if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber) & disk["InterfaceType"].ToString() == "USB")
						{
							//this._serialNumber = parseSerialFromDeviceID(disk["PNPDeviceID"].ToString());
							/*MessageBox.Show(disk["PNPDeviceID"].ToString());*/
							serialNumber = parseSerialFromDeviceID(disk["PNPDeviceID"].ToString());
							/*							MessageBox.Show(serialNumber);*/
						}
					}
				}
			}
			return serialNumber;
		}


	}
}
