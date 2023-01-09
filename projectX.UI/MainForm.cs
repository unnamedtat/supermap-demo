using System;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitAllControls(splitContainerLR.Panel2, splitContainerdata.Panel2, splitContainerdata.Panel1, splitContainerHawkeye.Panel1, splitContainerHawkeye.Panel2);        }
    }
}
