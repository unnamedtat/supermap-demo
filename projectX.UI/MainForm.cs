using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectX.UI.Controls;

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
            InitAllControls(splitContainerUD.Panel1, splitContainerLR.Panel2, splitContainerdata.Panel2, splitContainerdata.Panel1);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
