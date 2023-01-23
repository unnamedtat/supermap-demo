using ProjectX.UI.Forms;
using ProjectX.BLL;
using ProjectX.UI.Controls;
using System;
using System.Windows.Forms;
using SuperMap.Layout;
using SuperMap.UI;
using SuperMap.Mapping;
using ProjectX.BLL.Layout;
using SuperMap.Data;

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
            OpenLayoutEvent(e);
        }
        private void OpenForm_OpenLayoutEvent(object sender, string e)
        {
            OpenLayoutEvent(e);
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
        /// <summary>
        /// 布局按钮
        /// </summary>
        private void InitLayoutButtonClick()
        {
            iButtonLayoutSelect.Click += layoutManage.IButtonLayout_Click;
            iButtonZoomIn.Click += layoutManage.IButtonLayout_Click;
            iButtonZoomOut.Click += layoutManage.IButtonLayout_Click;
            iButtonZoomFree.Click += layoutManage.IButtonLayout_Click;
            iButtonPan.Click += layoutManage.IButtonLayout_Click;
            iButtonViewEntire.Click += layoutManage.IButtonLayout_Click;
            iButtonOpenLayoutSetting.Click += layoutManage.IButtonOpenLayoutSetting_Click;
            MapZoomIn.Click += layoutManage.MapEvent;
            MapLock.Click+= layoutManage.MapEvent;
            MapZoomFree.Click += layoutManage.MapEvent;
            MapZoomOut.Click += layoutManage.MapEvent;
            MapPan.Click += layoutManage.MapEvent;
            MapViewEntire.Click += layoutManage.MapEvent;
            MapRefresh.Click += layoutManage.MapEvent;

            layoutManage.LayoutControl.ElementSelectChanged += LayoutControl_ElementSelectChanged;
  
            ChangeMapButtonEnable(false);
            ChangeBaseMapButtonEnable(false);
            layoutManage.ISActiveMapExist += ChangeBaseButton;

        }
        /// <summary>
        /// 选择状态更新时按钮的更新状况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeBaseButton(object sender, bool e)
        {
            if(e == true) this.MapLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            else this.MapLock.BackColor = System.Drawing.Color.Transparent;
            ChangeBaseMapButtonEnable(e);
        }
        /// <summary>
        /// 布局按钮中对地图进行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutControl_ElementSelectChanged(object sender, ElementSelectChangedEventArgs e)
        {
            LayoutSelection layoutSelection = layoutManage.LayoutControl.MapLayout.Selection;
            if (layoutSelection.Count == 1) 
            {
                LayoutElements layoutElements = layoutManage.LayoutControl.MapLayout.Elements;
                int ID = layoutSelection[0];
                layoutElements.SeekID(ID);
                Geometry geometry = layoutElements.GetGeometry();
                if (geometry.Type == GeometryType.GeoMap)
                {
                    ChangeMapButtonEnable(true);
                }
                else { ChangeMapButtonEnable(false);
                    ChangeBaseMapButtonEnable(false);
                }
            }
            else { ChangeMapButtonEnable(false);
                ChangeBaseMapButtonEnable(false);
            }
        }
        /// <summary>
        /// 更新按钮的可用状态
        /// </summary>
        /// <param name="IsEnable"></param>
        private void ChangeMapButtonEnable(bool IsEnable)
        {
            MapLock.Enabled = IsEnable;
        }
        /// <summary>
        /// 更新布局中地图的按钮可用状态
        /// </summary>
        /// <param name="IsEnable"></param>
        private void ChangeBaseMapButtonEnable(bool IsEnable)
        {
            MapZoomFree.Enabled = IsEnable;
            MapZoomIn.Enabled = IsEnable;
            MapZoomOut.Enabled = IsEnable;
            MapPan.Enabled = IsEnable;
            MapViewEntire.Enabled = IsEnable;
            MapRefresh.Enabled = IsEnable;
        }
    }
}
