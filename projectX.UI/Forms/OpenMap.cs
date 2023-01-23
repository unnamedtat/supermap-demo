using ProjectX.BLL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectX.UI.Forms
{
    public partial class OpenMap : Form
    {
        FormType formType;
        /// <summary>
        /// 此form被用作的用途
        /// </summary>
        public enum FormType
        {
            [Description("打开地图")]
            OpenMapForm = 0,
            [Description("打开布局")]
            OpenLayoutForm = 1,
        }
        /// <summary>
        /// 打开map的事件
        /// </summary>
        public event EventHandler<string> OpenEvent;
        /// <summary>
        /// 创建map的事件
        /// </summary>
        public event EventHandler<string> CreateEvent;
        private IWorkspaceManage workspaceManage;
        public OpenMap(IWorkspaceManage workspaceManage, FormType formType)
        {
            this.formType = formType;
            this.workspaceManage = workspaceManage;
            InitializeComponent();
            if (formType == FormType.OpenMapForm) initOpenMapFrom();
            else if (formType == FormType.OpenLayoutForm) initOpenLayoutForm();
        }
        /// <summary>
        /// 初始化打开布局窗口
        /// </summary>
        /// <param name="workspaceManage"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void initOpenLayoutForm()
        {
            this.Text = "打开布局";
            this.label1.Text = "打开已有布局";
            this.label2.Text = "新建布局";
            initButtonEvent();
            foreach (string layout in this.workspaceManage.workspace.Layouts)
            {
                comboBox.Items.Add(layout);
            }
        }

        private void initButtonEvent()
        {
            buttonOpen.Click += ButtonOpen_Click;
            buttonCreat.Click += ButtonCreate_Click;
        }

        /// <summary>
        /// 初始化打开地图窗口
        /// </summary>
        /// <param name="workspaceManage"></param>
        private void initOpenMapFrom()
        {
            initButtonEvent();
            foreach (string map in this.workspaceManage.workspace.Maps)
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
                CreateEvent(e, this.textBox.Text);
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
                OpenEvent(e, this.comboBox.Text);
                this.Close();
            }
        }
    }
}
