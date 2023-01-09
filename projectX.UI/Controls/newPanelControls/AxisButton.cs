using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.controls.newPanelControls
{
    public partial class AxisButton : UserControl
    {
        /// <summary>
        /// 设置文字
        /// </summary>
        public string ButtonText
        {
            set { this.label1.Text = value; }
            get { return this.label1.Text; }
        }
        public AxisButton()
        {
            InitializeComponent();
        }
    }
}
