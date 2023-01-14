using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SuperMap.Data;

namespace ProjectX.UI
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            this.MaximizedBounds = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitAllControls(splitContainerLR.Panel2, splitContainerdata.Panel2, splitContainerdata.Panel1, splitContainerHawkeye.Panel1, splitContainerHawkeye.Panel2);
            Tittle_Load();
        }

    }
}
