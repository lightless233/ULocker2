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

/************************************************************************/
/* 
 *	Powered By Lightless. 
 *	
 *	2014.06.30
 *
 *	lightless@foxmail.com
 *
/************************************************************************/



namespace ULocker2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// 设置新线程，负责进行初始化
			Thread threadInitApp = new Thread(InitApp);
			threadInitApp.Start();
		}

		/************************************************************************/
		/* 全局变量                                                             */
		/************************************************************************/
		// U盘的数量
		uint gRemoveableDeviceCount = 0;

		// 打开文件按钮
		//
		// 状态：完成
		// 完成时间：2014年6月30日 19:18:04
		// 最后修改日期：2014年6月30日 19:18:15
		// 编写者：lightless
		private void buttonSelectFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDialog = new OpenFileDialog();
			openDialog.Title = "请选择需要操作的文件";
			DialogResult x;
			try
			{
				x = openDialog.ShowDialog();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("OpenFileDialog Failed!\r\n" + ex.Message);
				return;
			}
			if (x == DialogResult.OK || x == DialogResult.Yes)
			{
				string strFilePath = openDialog.FileName;
				this.textFilePath.Text = strFilePath;
			}
		}

		// 初始化线程函数
		//
		// 状态：编写中
		// 完成时间：null
		// 最后修改日期：2014年6月30日 19:24:38
		// 编写者：lightless
		private void InitApp()
		{
			// 设置“加解密算法”combox默认为第一项
			this.comboBoxEncryptionAlgorithm.SelectedIndex = 0;

			// 初始化时设置共享方式为private
			this.comboBoxShareMode.Items.Add("private - 私人文件，仅有个人可以解密");
			this.comboBoxShareMode.SelectedIndex = 0;

			// 初始化app的时候获取一次驱动器信息
			gRemoveableDeviceCount = getDriverType();
		}

		// 获取驱动器信息
		// 返回值：U盘的数量
		//
		// 状态：已完成
		// 完成时间：2014年6月30日 19:36:52
		// 最后修改日期：2014年6月30日 19:37:02
		// 编写者：lightless
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

		// 在GetRemoveableDeviceSerialNumber中对searcher的值进行过滤
		// 状态：完成
		// 完成日期：2014.4.22
		// 最后修改日期：2014.4.22
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
			serial = serialArray[0];

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

		// 重写窗体的WndProc方法，截取消息
		// 状态：完成
		// 完成日期：2014.4.21
		// 最后修改日期：2014.4.21
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

			if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
			{
				DialogResult x = MessageBox.Show("你想要关闭程序么？点击确定关闭程序",
						"ULocker2", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
				if (x == DialogResult.OK)
				{
					Environment.Exit(0);
				}
				else return;
			}

			base.WndProc(ref m);
		}

		// 检测所有的位置是否填充完整
		// 返回值：true - 已填写完整
		//		   false - 未填写完整
		//
		// 状态：完成
		// 完成时间：2014年6月30日 22:58:52
		// 最后修改日期：2014年7月1日 00:08:58
		// 编写者：lightless
		public bool CheckBlank()
		{
			// 请插入U盘
			if (gRemoveableDeviceCount == 0)
			{
				MessageBox.Show("U盘选择有误！");
				return false;
			}

			// 检查是否选择U盘
			string strSelectDevice;
			try
			{
				strSelectDevice = comboBoxUDevice.SelectedItem.ToString();
				if (strSelectDevice == "没有发现U盘设备！")
				{
					MessageBox.Show("请选择U盘!");
					return false;
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("请选择U盘!");
				return false;
			}

			// 检查是否选择了文件以及文件是否存在
			if (textFilePath.Text.Length == 0)
			{
				MessageBox.Show("请选择需要操作的文件!");
				return false;
			}
			if (!File.Exists(textFilePath.Text))
			//if (File.Exists(@"D:\ULocker-test\GroupTest.txt"))
			{
				//MessageBox.Show(textFilePath.Text);
				MessageBox.Show("文件不存在！请重新选择！");
				return false;
			}

			// 检测是否填写用户名
			if (textBoxUsername.Text.Length == 0)
			{
				MessageBox.Show("请填写用户名!");
				return false;
			}

			// 检测是否填写密钥
			if (textBoxUserSalt.Text.Length == 0)
			{
				MessageBox.Show("请填写自定义密钥!");
				return false;
			}

			// 检查是否选择共享方式
			string strShareMode;
			try
			{
				strShareMode = comboBoxShareMode.SelectedItem.ToString();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("请选择共享方式");
				return false;
			}

			// 检测是否选择操作方式 加密/解密
			if (!(radioButtonDecrypto.Checked || radioButtonEncrypto.Checked))
			{
				MessageBox.Show("请选择加密/解密!");
				return false;
			}


			return true;
		}


		// 关闭按钮
		//
		// 状态：完成
		// 完成时间：2014年6月30日 22:58:52
		// 最后修改日期：2014年7月1日 00:09:37
		// 编写者：lightless
		private void buttonExit_Click(object sender, EventArgs e)
		{
			DialogResult x = MessageBox.Show("你想要关闭程序么？点击确定关闭程序",
				"ULocker2", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
			if (x == DialogResult.OK)
			{
				Environment.Exit(0);
			}
		}


		// 加密按钮
		//
		// 状态：编写中
		// 完成时间：null
		// 最后修改日期：2014年7月1日 00:10:27
		// 编写者：lightless
		private void buttonDo_Click(object sender, EventArgs e)
		{
			// 先检查是否填写完整
			if (CheckBlank() == false)
			{
				return;
			}





		}

		/************************************************************************/
		/* 加解密所需函数                                                        */
		/************************************************************************/
		/************************************************************************/
		/* DES                                                                  */
		/************************************************************************/
		#region DES
		
		// DES 加密函数
		// 需改进，应该自定义IV
		public static string DES_EncryptString(string plainText, string strKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);

			des.Key = UTF8Encoding.UTF8.GetBytes(strKey);
			des.IV = UTF8Encoding.UTF8.GetBytes(strKey);

			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			StringBuilder strRet = new StringBuilder();
			foreach (byte b in ms.ToArray())
			{
				strRet.AppendFormat("{0:X2}", b);
			}
			/*strRet.ToString();*/
			return strRet.ToString();
		}

		public static string DES_DecryptString(string cipherText, string strKey)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();

			byte[] inputByteArray = new byte[cipherText.Length / 2];

			for (int x = 0; x < cipherText.Length / 2; x++)
			{
				int i = (Convert.ToInt32(cipherText.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}

			des.Key = UTF8Encoding.UTF8.GetBytes(strKey);
			des.IV = UTF8Encoding.UTF8.GetBytes(strKey);

			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			StringBuilder strRet = new StringBuilder();
			return Encoding.UTF8.GetString(ms.ToArray());
		}


#endregion

	}
}
