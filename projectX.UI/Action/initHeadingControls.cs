using ProjectX.UI.Forms;
using ProjectX.BLL;
using ProjectX.UI.Controls;
using System;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        public event Action<string> mapModeChange;
        Delegate[] buttonDelegate;
        /// <summary>
        /// 设置按钮
        /// </summary>
        public void initbtn()
        {
            foreach (ToolStripButton button in this.toolStripTop.Items)
            {
                switch (button.Tag.ToString())
                {
                    case "1": button.Click += ButtonSave_Click;break;
                    case "2": button.Click += ButtonCreatWorkspace_Click; break;
                    case "10":
                    case "11":
                    case "12":
                        button.Click += TittleButton_Click;
                        break;
                    default: button.Click += toolStripBtn_Click;break;
                }

            }
            this.ButtonOpenWorkspace.Click += OpenFilebtnOnclick;
            this.ButtonAddMap.Click += ButtonAddMap_Click;
            this.ButtonAddData.Click += ButtonAddData_Click;
            initWorkspaceManageForm();
            //int buttonNum = 5;
            ////初始化tabpage1的compositebutton
            //CompositeButton[] compositeButtons = new CompositeButton[buttonNum];
            //string[] cpbtnTEXT = { "打开工作空间", "打开数据库型工作空间", "打开数据源", "新建地图", "数据导入" };
            ////依次绑定事件点击方法,只绑定了一个
            //Action<object, System.EventArgs> action = OpenFilebtnOnclick;
            //buttonDelegate = action.GetInvocationList();
            //for (int i = 0; i < buttonNum; i++)
            //{
            //    compositeButtons[i] = new CompositeButton();
            //    compositeButtons[i].ButtonText = cpbtnTEXT[i];
            //    compositeButtons[i].Tag = i + 1;
            //    compositeButtons[i].Click += ButtonOnclick;
            //    this.headingLayoutPanel1.Controls.Add(compositeButtons[i]);
            //}
        }

        private void TittleButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            switch (button.Tag)
            {
                case "10":this.WindowState = FormWindowState.Minimized; break;
                case "11":
                    if(this.WindowState==FormWindowState.Maximized) {
                        this.WindowState = FormWindowState.Normal;
                    }
                    else { this.WindowState = FormWindowState.Maximized; }
                    break;
                case "12":this.Close();break;
            }
        }

        private void ButtonAddData_Click(object sender, EventArgs e)
        {
            AddDataset addDataset = new AddDataset(workspaceManage.workspace);
            addDataset.Show();
        }

        private void ButtonAddMap_Click(object sender, EventArgs e)
        {
            OpenMap openMap = new OpenMap(workspaceManage);
            openMap.Show();
            openMap.OpenMapEvent += OpenMap_OpenMapEvent;
            openMap.CreateMapEvent += OpenMap_CreateMapEvent;
        }

        private void OpenMap_CreateMapEvent(object sender, string e)
        {
            workspaceManage.CreatMap(e);
        }

        private void OpenMap_OpenMapEvent(object sender, string e)
        {
            OpenMap(e,utpMap);
        }


        /// <summary>
        /// 按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOnclick(object sender, System.EventArgs e)
        {
            CompositeButton button = (CompositeButton)sender;
            /*根据button.Tag中序号选择委托列表数组中相应方法*/
            Action<object, System.EventArgs> method = (Action<object, System.EventArgs>)buttonDelegate[Convert.ToInt16(button.Tag) - 1];

            /*执行*/
            method(sender, e);
        }
        /// <summary>
        /// 点击打开工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFilebtnOnclick(object sender, System.EventArgs e)
        {
            this.workspaceManage.OpenWorkspace();
        }
        /// <summary>
        /// 顶部按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            mapModeChange?.Invoke(button.Tag.ToString());
        }

    }

}
