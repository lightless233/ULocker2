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
	public partial class MainForm : Form
	{

		public MainForm()
		{
			LoginForm loginform = new LoginForm();

			bool issuccess = true;

			while (issuccess)
			{
				loginform.ShowDialog();
				if (loginform.DialogResult == DialogResult.OK)
				{
					if (loginform.ReturnValue1 == "Success.")
					{
						MessageBox.Show("登陆成功");
						issuccess = false;
						//this.textBoxUsername.Text = loginform.ReturnUsername;
						//MessageBox.Show(loginform.ReturnUsername);
						//this.textBoxUsername.ReadOnly = true;

					}
					else if (loginform.ReturnValue1 == "Database error!")
					{
						MessageBox.Show("远程服务器数据库出错，请稍后再试。");
						issuccess = true;
					}
					else if (loginform.ReturnValue1 == "Auth fail.")
					{
						MessageBox.Show("用户名或密码错误");
						issuccess = true;
					}
				}
			}
			InitializeComponent();

			this.textBoxUsername.Text = loginform.ReturnUsername;
			this.textBoxUsername.ReadOnly = true;
			this.登陆ToolStripMenuItem.Enabled = false;

			// 设置新线程，负责进行初始化
			Thread threadInitApp = new Thread(InitApp);
			threadInitApp.Start();



// 			if (loginform.ShowDialog() == DialogResult.OK)
// 			{
// 				string res = loginform.ReturnValue1;
// 				if (res == "Success.")
// 				{
// 					MessageBox.Show("登陆成功");
// 					InitializeComponent();
// 
// 					// 设置新线程，负责进行初始化
// 					Thread threadInitApp = new Thread(InitApp);
// 					threadInitApp.Start();
// 				}
// 				else
// 				{
// 
// 				}
// 			}

			//InitializeComponent();


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

		// 向服务器POST数据并获得回显
		// 状态：完成
		// 完成日期：2014年5月9日 19:37:36
		// 最后修改日期：2014年5月9日 19:37:46
		// 参数：postData，待传递的参数，为a=1&b=2的形式
		// 返回值：post后的回显
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


		// 加解密按钮
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

			string strSelectDevice = comboBoxUDevice.SelectedItem.ToString();

			// 将combox中获取的内容分割，得到U盘盘符
			// TargetDevice[0]就是盘符
			string[] TargetDevice = strSelectDevice.Split(' ');
			// 获取U盘序列号，存在serialNumber中
			string serialNumber = GetRemoveableDeviceSerialNumber(TargetDevice[0]);

			// 1表示用户选择的加密，应该调用加密函数
			// 0表示用户选择的解密，应该调用解密函数
			int isEncryption = 0;

			// 判断用户选择的是加密还是解密
			if (radioButtonEncrypto.Checked)
			{
				// 用户选择的加密
				// MessageBox.Show("Encrypto");
				isEncryption = 1;
			}
			else
			{
				// 用户选择的解密
				// MessageBox.Show("Decrypto");
				isEncryption = 0;
			}

			// 打开文件
			string strLine = null;
			string strFilePath = this.textFilePath.Text;
			using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
			{
				BinaryReader br = new BinaryReader(fs);
				byte[] bytes = br.ReadBytes((int)fs.Length);
				// strLine 是最终读取内容的BASE64
				strLine = Convert.ToBase64String(bytes);
				br.Close();
			}
			

			//获取用户选择的加密方式
			string strUserEnc = null;
			strUserEnc = this.comboBoxEncryptionAlgorithm.SelectedItem.ToString();

			// 如果已经存在密文文件，那么删除掉密文再重新生成
			if (File.Exists(strFilePath + ".enc"))
			{
				File.Delete(strFilePath + ".enc");
			}

			string PKey = null;
			string postData = "username=" + this.textBoxUsername.Text + "&ukey=" + 
				serialNumber;
			PKey = PostAndRecv(postData, "http://127.0.0.1/ulocker/getpkey-master.php");

			// 通过PKey和私盐生成最终的密钥 FinalKey
			string FinalKeyTemp = PKey + this.textBoxUserSalt;
			byte[] buffer = Encoding.UTF8.GetBytes(FinalKeyTemp);

			SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
			byte[] temp = sha512.ComputeHash(buffer);

			string strFinalKey = BitConverter.ToString(temp).Replace("-", string.Empty);

			//MessageBox.Show(strFinalKey);


			switch (strUserEnc)
			{
				case "AES - 高级加密标准 (默认，推荐算法)":
					// MessageBox.Show("aes");


					break;
				case "DES - 数据加密算法 (适合文件保密性不高的文件)":
					MessageBox.Show("des");
					break;
				case "TripleDES - 3层数据加密算法 (比DES安全性较高)":
					MessageBox.Show("3des");
					break;
				case "RC2 - Ron's Code (速度快，适合大文件)":
					MessageBox.Show("rc2");
					break;

				default:
					MessageBox.Show("错误的算法！");
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
		// strKey: 8字符
		// strIV: 8字符
		public static string DES_EncryptString(string plainText, string strKey, string strIV)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);

			des.Key = UTF8Encoding.UTF8.GetBytes(strKey);
			des.IV = UTF8Encoding.UTF8.GetBytes(strIV);

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

		public static string DES_DecryptString(string cipherText, string strKey, string strIV)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();

			byte[] inputByteArray = new byte[cipherText.Length / 2];

			for (int x = 0; x < cipherText.Length / 2; x++)
			{
				int i = (Convert.ToInt32(cipherText.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}

			des.Key = UTF8Encoding.UTF8.GetBytes(strKey);
			des.IV = UTF8Encoding.UTF8.GetBytes(strIV);

			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();

			StringBuilder strRet = new StringBuilder();
			return Encoding.UTF8.GetString(ms.ToArray());
		}
		#endregion
		/************************************************************************/
		/* AES                                                                  */
		/************************************************************************/
		#region AES
		// Iv: 32字符
		// Key: 32字符
		private String AES_Encrypt(String Input, string Iv, string Key)
		{
			var aes = new RijndaelManaged();
			aes.KeySize = 256;
			aes.BlockSize = 256;
			aes.Padding = PaddingMode.PKCS7;
			aes.Key = UTF8Encoding.UTF8.GetBytes(Key);
			aes.IV = UTF8Encoding.UTF8.GetBytes(Iv);

			var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
			byte[] xBuff = null;
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
				{
					byte[] xXml = Encoding.UTF8.GetBytes(Input);
					cs.Write(xXml, 0, xXml.Length);
				}

				xBuff = ms.ToArray();
			}

			String Output = Convert.ToBase64String(xBuff);
			return Output;
		}

		private String AES_Decrypt(String Input, string Iv, string Key)
		{
			RijndaelManaged aes = new RijndaelManaged();
			aes.KeySize = 256;
			aes.BlockSize = 256;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			aes.Key = UTF8Encoding.UTF8.GetBytes(Key);
			aes.IV = UTF8Encoding.UTF8.GetBytes(Iv);

			var decrypt = aes.CreateDecryptor();
			byte[] xBuff = null;
			using (var ms = new MemoryStream())
			{
				using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
				{
					byte[] xXml = Convert.FromBase64String(Input);
					cs.Write(xXml, 0, xXml.Length);
				}

				xBuff = ms.ToArray();
			}

			String Output = Encoding.UTF8.GetString(xBuff);
			return Output;
		}
		#endregion
		/************************************************************************/
		/* RC2                                                                  */
		/************************************************************************/

		#region RC2
		// encryptKey 5-16位字符串
		// t为8个字符
		public static string RC2Encrypt(string encryptString, string encryptKey, string t)
		{
			string returnValue;
			try
			{
				byte[] temp = UTF8Encoding.UTF8.GetBytes(t);
				//byte[] temp = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xFF };
				RC2CryptoServiceProvider rC2 = new RC2CryptoServiceProvider();
				byte[] byteEncryptString = Encoding.Default.GetBytes(encryptString);
				MemoryStream memorystream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memorystream, rC2.CreateEncryptor(Encoding.Default.GetBytes(encryptKey), temp), CryptoStreamMode.Write);
				cryptoStream.Write(byteEncryptString, 0, byteEncryptString.Length);
				cryptoStream.FlushFinalBlock();
				returnValue = Convert.ToBase64String(memorystream.ToArray());
			}
			catch
			{
				returnValue = null;
			}
			return returnValue;
		}

		public static string RC2Decrypt(string decryptString, string decryptKey, string t)
		{
			string returnValue;
			try
			{
				byte[] temp = UTF8Encoding.UTF8.GetBytes(t);
				//byte[] temp = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xFF };
				RC2CryptoServiceProvider rC2 = new RC2CryptoServiceProvider();
				byte[] byteDecrytString = Convert.FromBase64String(decryptString);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, rC2.CreateDecryptor(Encoding.Default.GetBytes(decryptKey), temp), CryptoStreamMode.Write);
				cryptoStream.Write(byteDecrytString, 0, byteDecrytString.Length);
				cryptoStream.FlushFinalBlock();
				returnValue = Encoding.Default.GetString(memoryStream.ToArray());
			}
			catch
			{
				returnValue = null;
			}
			return returnValue;
		}

		#endregion

		/************************************************************************/
		/* TripleDES                                                            */
		/************************************************************************/
		#region TripleDES
		public static string DES3Encrypt(string encryptString, string encryptKey1, string encryptKey2, string encryptKey3,
			string encryptIV1, string encryptIV2, string encryptIV3)
		{
			string returnValue;
			try
			{
				returnValue = DES_EncryptString(encryptString, encryptKey3, encryptIV3);
				returnValue = DES_EncryptString(returnValue, encryptKey2, encryptIV2);
				returnValue = DES_EncryptString(returnValue, encryptKey1, encryptIV1);
			}
			catch (Exception ex)
			{
				returnValue = null;
			}
			return returnValue;
		}

		public static string DES3Decrypt(string decryptString, string decryptKey1, string decryptKey2, string decryptKey3,
			string decryptIV1, string decryptIV2, string decryptIV3)
		{

			string returnValue;
			try
			{
				returnValue = DES_DecryptString(decryptString, decryptKey1, decryptIV1);
				returnValue = DES_DecryptString(returnValue, decryptKey2, decryptIV2);
				returnValue = DES_DecryptString(returnValue, decryptKey3, decryptIV3);

			}
			catch (Exception ex)
			{
				returnValue = null;
			}
			return returnValue;
		}
		#endregion

		private void buttonGetMyUserGroup_Click(object sender, EventArgs e)
		{
			this.comboBoxShareMode.Items.Clear();
			this.comboBoxShareMode.Items.Add("private - 私人文件，仅有个人可以解密");
			this.comboBoxShareMode.SelectedIndex = 0;

			if (this.textBoxUsername.Text.Length == 0)
			{
				MessageBox.Show("请先填写用户名!");
				return;
			}

			string postData = "username=";
			string recv = null;

			postData += this.textBoxUsername.Text;

			recv = PostAndRecv(postData, "http://127.0.0.1/ULocker/getgroup.php");

			if (recv == "0")
			{
				MessageBox.Show("用户不存在，请检查用户名是否填写有误！");
				return;
			}
			if (recv == "Cannot connect to remote host")
			{
				return;
			}

			string[] strGroup = recv.Split('|');
			foreach (string i in strGroup)
			{
				comboBoxShareMode.Items.Add(i);
			}
			comboBoxShareMode.Items.RemoveAt(comboBoxShareMode.Items.Count-1);
			MessageBox.Show("获取成功");
			this.comboBoxShareMode.SelectedIndex = 0;
		}

		private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
		{
// 			Form formRegistry = new Form();
// 			formRegistry.ShowDialog();
			RegistryForm formRegistry = new RegistryForm();
			formRegistry.ShowDialog();
		}

		private void 退出当前用户ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.textBoxUsername.Text = "";
			this.登陆ToolStripMenuItem.Enabled = true;
			this.退出当前用户ToolStripMenuItem.Enabled = false;
		}

		private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoginForm loginform = new LoginForm();

			bool issuccess = true;

			while (issuccess)
			{
				loginform.ShowDialog();
				if (loginform.DialogResult == DialogResult.OK)
				{
					if (loginform.ReturnValue1 == "Success.")
					{
						MessageBox.Show("登陆成功");
						issuccess = false;
						//this.textBoxUsername.Text = loginform.ReturnUsername;
						//MessageBox.Show(loginform.ReturnUsername);
						//this.textBoxUsername.ReadOnly = true;

					}
					else if (loginform.ReturnValue1 == "Database error!")
					{
						MessageBox.Show("远程服务器数据库出错，请稍后再试。");
						issuccess = true;
					}
					else if (loginform.ReturnValue1 == "Auth fail.")
					{
						MessageBox.Show("用户名或密码错误");
						issuccess = true;
					}
				}
			}
			this.textBoxUsername.Text = loginform.ReturnUsername;

			this.登陆ToolStripMenuItem.Enabled = false;
			this.退出当前用户ToolStripMenuItem.Enabled = true;
		}





	}
}
