using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectX.UI.Forms
{
    public partial class WelcomeForm : Form
    {
        private const string flash = "森林火险监测系统启动中……\n";
        private int stopCount = flash.Length+55;//停止时间
        private int count = 0;
        private bool finish = false;
        public WelcomeForm()
        {
            InitializeComponent();
            this.timer_Display.Tick += timer_Display_Tick;
            timer_Display.Start();//启动显示定时器
            label.Text = "";
        }

        /// <summary>
        /// 窗口定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Display_Tick(object sender, EventArgs e)
        {
            if (finish == false)
            {
                label.Text += flash.Substring(count, 1); //逐个显示文字 
            }
            //累加计数
            count++;
            if (count == flash.Length)
            {
                CheckProgramProcess();
                finish = true;//文字显示完成
            }
            else if (count >= stopCount)
            {
                timer_Display.Stop();
                this.Close();//关闭窗口
            }
        }

        private bool CheckProgramProcess()
        {
            Process[] myProcesses = Process.GetProcessesByName(Application.ProductName);
            if (myProcesses.Length > 1) //如果可以获取到本进程名大于1个，则说明在此之前已经启动过
            {
                timer_Display.Stop();
                MessageBox.Show("检测到程序已经运行，请先关闭多余的程序或进程！\n");
                Application.Exit();//关闭
            }
            return true;
        }
    }
}
