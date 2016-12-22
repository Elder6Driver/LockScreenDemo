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

namespace 屏幕锁定程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        public FileStream MyFs;
        private void timer1_Tick(object sender, EventArgs e)
        {

            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "Taskmgr")
                {
                    item.Kill();
                }
                if (item.ProcessName == "taskmgr")
                {
                    item.Kill();
                }
                if (item.ProcessName == "任务管理器")
                {
                    item.Kill();
                }
            }

            if (this.progressBar1.Value == 50)
            {
                label2.Text += "\n你现在按ALT+F4也没用，不信你试试！！！呵呵";
            }
            if (this.progressBar1.Value == 100)
            {
                label2.ForeColor = Color.Blue; ;
                label2.Text = "不行吧！！！";
            }
            if (this.progressBar1.Value == 150)
            {
                label2.ForeColor = Color.DarkGreen;
                label2.Text = "结束不了了，怎么办？？？";
            }
            if (this.progressBar1.Value == 200)
            {
                label2.Text = "任务管理器怎么样？？？看能不能结束？";
                label2.ForeColor = Color.White;
            }
            if (this.progressBar1.Value == 250)
            {
                label2.ForeColor = Color.DarkRed;
                label2.Text = "我靠，调不出来！！！";
            }
            if (this.progressBar1.Value == 300)
            {
                label2.ForeColor = Color.Yellow;
                label2.Text = "重新启动？ 不会吧！！！";
            }
            if (this.progressBar1.Value == 350)
            {
                label2.ForeColor = Color.YellowGreen;
                label2.Text = "没办法了吧";
            }
            if (this.progressBar1.Value == 400)
            {
                label2.ForeColor = Color.Red;
                label2.Text = "自己慢慢想办法吧，O(∩_∩)O~";
            }
            if (this.progressBar1.Value == 450)
            {
                label2.ForeColor = Color.Green;
                label2.Text = "算了，不整你了";
            }
            if (this.progressBar1.Value == 500)
            {
                label2.ForeColor = Color.DarkGray;
                label2.Text = "在文本框中输入";
            }
            if (this.progressBar1.Value == 550)
            {
                label2.ForeColor = Color.Brown;
                label2.Text = "888";
            }
            if (this.progressBar1.Value == 599)
            {
                label2.ForeColor = Color.Gold;
                label2.Text += "按回车";
            }
            if (i <= 600)
            {
                this.progressBar1.Value = i++;
            }
            else
            {
                this.timer1.Stop();
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //MyFs = new FileStream(Environment.ExpandEnvironmentVariables("%windir%\\system32\\taskmgr.exe"), FileMode.Open);
            //byte[] Mybyte = new byte[(int)MyFs.Length];
            //MyFs.Write(Mybyte, 0, (int)MyFs.Length);
            //MyFs.Close(); //用文件流打开任务管理器应用程序而不关闭文件流就会阻止打开任务管理器   

            this.KeyPreview = true;
            progressBar1.Hide();
            label2.Text = "你的屏幕被锁定了！！！";
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Alt)
            {
                e.Handled = true;
                MessageBox.Show("ALT被禁用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //if (e.KeyCode == Keys.F4)
                //{
                //    e.Handled = true;
                //    MessageBox.Show("ALT+F4被禁用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //if (e.KeyCode == Keys.Tab)
                //{
                //    e.Handled = true;
                //    MessageBox.Show("ALT+Tab被禁用", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox1.Text == "888")
                {
                    //MyFs.Close();
                    
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
