using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;

namespace 屏幕锁定程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //对当前的Thread增加键盘钩子
            DllInclude.SetHook(AppDomain.GetCurrentThreadId());
            //获取现在的进程
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                //如果出现任务管理器，杀任务管理器进程
                if (item.ProcessName == "Taskmgr")
                {
                    item.Kill();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //MyFs = new FileStream(Environment.ExpandEnvironmentVariables("%windir%\\system32\\taskmgr.exe"), FileMode.Open);
            //byte[] Mybyte = new byte[(int)MyFs.Length];
            //MyFs.Write(Mybyte, 0, (int)MyFs.Length);
            //MyFs.Close(); //用文件流打开任务管理器应用程序而不关闭文件流就会阻止打开任务管理器   
            //这个方法不能使用，因为没有权限打开


            this.KeyPreview = true;
            progressBar1.Hide();
            label2.Text = "你的屏幕被锁定了！！！";
            timer1.Start();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //如果输入正确密码，那么可以退出这个窗口了
                if (textBox1.Text == "888")
                {
                    DllInclude.DeleteHook();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("对不起，您输入的密码错误，请查证后再试，谢谢合作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                }
            }
        }
  
    }   
}
