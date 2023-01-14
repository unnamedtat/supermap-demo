using ProjectX.UI.Controls;
using ProjectX.BLL;
using SuperMap.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectX.UI.Forms
{
    public partial class OpenMap : Form
    {
        /// <summary>
        /// 打开map的事件
        /// </summary>
        public event EventHandler<string> OpenMapEvent;
        /// <summary>
        /// 创建map的事件
        /// </summary>
        public event EventHandler<string> CreateMapEvent;
        public OpenMap(IWorkspaceManage workspaceManage)
        {
            InitializeComponent();
            initiOpenMapFrom(workspaceManage);
        }

        private void initiOpenMapFrom(IWorkspaceManage workspaceManage)
        {
            buttonOpen.Click += ButtonOpen_Click;
            buttonCreat.Click += ButtonCreate_Click;
            foreach (string map in workspaceManage.workspace.Maps)
            {
                comboBox.Items.Add(map);
            }
        }
        /// <summary>
        /// 新建地图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != null)
            {
                CreateMapEvent(e, this.textBox.Text);
                this.Close();
            }
        }

        /// <summary>
                /// 打开地图
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                /// <exception cref="NotImplementedException"></exception>
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (this.comboBox.Text != null)
            {
                OpenMapEvent(e, this.comboBox.Text);
                this.Close();
            }
        }
    }
}
