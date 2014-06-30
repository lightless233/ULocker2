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
		}


	}
}
