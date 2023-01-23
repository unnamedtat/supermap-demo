using ProjectX.UI.Forms;
using ProjectX.BLL;
using ProjectX.UI.Controls;
using System;
using System.Windows.Forms;
using SuperMap.Layout;
using SuperMap.UI;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        public event Action<string> mapModeChange;
        /// <summary>
        /// 设置按钮
        /// </summary>
        public void initbtn()
        {
            foreach (ToolStripItem button in this.toolStripTop.Items)
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
                    case "13":break;
                    default: button.Click += toolStripBtn_Click;break;
                }

            }
            this.ButtonOpenWorkspace.Click += OpenFilebtnOnclick;
            this.ButtonAddMap.Click += ButtonAddMap_Click;
            this.ButtonAddLayout.Click += ButtonAddMap_Click;
            this.ButtonAddData.Click += ButtonAddData_Click;
            initWorkspaceManageForm();
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
            OpenMap openMap;
            ImageButton imageButton = (ImageButton)sender;
            if(imageButton.Name== "ButtonAddMap")
            {
                openMap = new OpenMap(workspaceManage, ProjectX.UI.Forms.OpenMap.FormType.OpenMapForm);
                openMap.OpenEvent += OpenForm_OpenMapEvent;
                openMap.CreateEvent += OpenForm_CreateMapEvent;
            }
            else
            {
                openMap = new OpenMap(workspaceManage, ProjectX.UI.Forms.OpenMap.FormType.OpenLayoutForm);
                openMap.OpenEvent += OpenForm_OpenLayoutEvent;
                openMap.CreateEvent += OpenForm_CreateLayoutEvent;
            }
            openMap.Show();
        }
        private void OpenForm_CreateLayoutEvent(object sender, string e)
        {
            workspaceManage.CreatLayout(e);
            OpenLayout(e);
        }
        private void OpenForm_OpenLayoutEvent(object sender, string e)
        {
            OpenLayout(e);
        }
        private void OpenForm_CreateMapEvent(object sender, string e)
        {
            workspaceManage.CreatMap(e);
            OpenMap(e);
        }
        private void OpenForm_OpenMapEvent(object sender, string e)
        {
            OpenMap(e);
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
        #region 布局按钮
        private void InitLayoutButtonClick()
        {
            iButtonLayoutSelect.Click += IButtonLayout_Click;
            iButtonZoomIn.Click += IButtonLayout_Click;
            iButtonZoomOut.Click += IButtonLayout_Click;
            iButtonZoomFree.Click += IButtonLayout_Click;
            iButtonPan.Click += IButtonLayout_Click;
            iButtonViewEntire.Click += IButtonLayout_Click;
            iButtonOpenLayoutSetting.Click += IButtonOpenLayoutSetting_Click;
        }

        private void IButtonOpenLayoutSetting_Click(object sender, EventArgs e)
        {
            LayoutSettingDialog.ShowDialog(activeMapLayoutControl.MapLayout, "布局设置："+activeMapLayoutControl.MapLayout.Name);
        }
        /// <summary>
        /// 布局的普通操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IButtonLayout_Click(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            switch (imageButton.Tag)
            {
                case "0":activeMapLayoutControl.LayoutAction = SuperMap.UI.Action.Select2;break;
                case "1": activeMapLayoutControl.LayoutAction = SuperMap.UI.Action.ZoomIn; break;
                case "2": activeMapLayoutControl.LayoutAction = SuperMap.UI.Action.ZoomOut; break;
                case "3": activeMapLayoutControl.LayoutAction = SuperMap.UI.Action.ZoomFree; break;
                case "4": activeMapLayoutControl.LayoutAction = SuperMap.UI.Action.Pan; break;
                case "5": activeMapLayoutControl.MapLayout.ZoomToPaper(); break;
                default:
                    break;
            }
        }
        #endregion
    }
}
