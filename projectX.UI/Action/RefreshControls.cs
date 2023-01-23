using SuperMap.Mapping;
using SuperMap.UI;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        /// <summary>
        /// tapage选择卡更新方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UtpMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (utpMap.SelectedTab != null)
            {
                if (((ControlAccessibleObject)utpMap.SelectedTab.AccessibilityObject).Name != null)
                {
                    if (utpMap.SelectedTab.Controls[0] is MapControl)
                    {
                        ShowMapControls();
                        MapControl tempmapControl = (MapControl)utpMap.SelectedTab.Controls[0];
                        activeMapControl = tempmapControl;
                        ChangeMap(activeMapControl.Map.Name);
                        ChangeButtonEnable(true);//按钮状态切换为可用
                    }
                    else if (utpMap.SelectedTab.Controls[0] is MapLayoutControl)
                    {
                        CloseTheMap();
                        MapLayoutControl tempmaplayoutControl = (MapLayoutControl)utpMap.SelectedTab.Controls[0];
                        activeMapLayoutControl = tempmaplayoutControl;
                        InitLayoutButtonClick();
                        ChangeToLayout();
                        ChangeButtonEnable(false);
                    }
                }
            }
            else
            {
                //无布局、地图页面，保存无意义
                ButtonSave.Enabled = false;
                toolStripButton3.Enabled = false;
                this.layersControl.Map.Close();
                CloseTheMap();
                ChangeButtonEnable(false);
            }

        }
        /// <summary>
        /// 切换视图时切换按钮可用状态
        /// </summary>
        private void ChangeButtonEnable(bool IsEnable)
        {
            ButtonSpatialQuery.Enabled = IsEnable;
            ButtonAttributeTable.Enabled = IsEnable;
            foreach (ToolStripItem toolStripButton in toolStripTop.Items)
            {
                if (Convert.ToInt32(toolStripButton.Tag.ToString()) > 2&& Convert.ToInt32(toolStripButton.Tag.ToString())<10)
                    toolStripButton.Enabled= IsEnable;
            }
        }
        /// <summary>
        /// 工作空间更换时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorkspaceChanged(object sender, PropertyChangedEventArgs e)
        {
            // 工作空间树连接到新工作空间
            this.workspaceControl.WorkspaceTree.Workspace = workspaceManage.workspace;
            TabPage InitTabpage = InitMainMapControl();
            InitOpenFristMap(InitTabpage);
            ChangeButtonEnable(true);//按钮状态切换为可用
        }
        /// <summary>
        /// 刷新鹰眼图和放大镜、图层管理器
        /// </summary>
        public void RefreshEagZoomLayerControls(string Mapname)
        {
            // 将地图关联到图层管理器，使其管理其中的地图图层
            this.layersControl.Map = this.activeMapControl.Map;
            MapControl[] EMmapControls = new MapControl[2] { this.mapControlEagleEye, this.mapControlMagnifier };
            foreach (MapControl control in EMmapControls)
            {
                RefreshMapControl(control,Mapname);
            }
            if (mapControlEagleEye.Map != null)
            {
                foreach (Layer layer in mapControlEagleEye.Map.Layers)
                {
                    layer.IsSelectable = false;
                }
            }
            mapControlEagleEye.MarginPanEnabled = false;
            mapControlEagleEye.IsWaitCursorEnabled = false;
            mapControlEagleEye.InteractionMode = InteractionMode.CustomAll;
            mapControlEagleEye.Cursor = Cursors.Arrow;
            if (this.activeMapControl.Map.Scale != 0)
                this.mapControlEagleEye.Map.ViewEntire();

            this.mapControlMagnifier.MarginPanEnabled = false;
            this.mapControlMagnifier.IsWaitCursorEnabled = false;
            this.mapControlMagnifier.Action = SuperMap.UI.Action.Null;
            this.mapControlMagnifier.InteractionMode = InteractionMode.CustomAll;
            this.ScaleIndex = 3;

            if (this.activeMapControl.Map.Scale != 0)
                this.mapControlMagnifier.Map.Scale = this.activeMapControl.Map.Scale * this.ScaleIndex;
        }
        /// <summary>
        /// 刷新主地图控件
        /// </summary>
        private void RefreshMainMapControl(string Mapname)
        {
            RefreshMapControl(this.activeMapControl,Mapname);
            //调整mapcontrol的状态
            this.activeMapControl.Action = SuperMap.UI.Action.Pan;
            if (this.activeMapControl.Map != null)
            {
                this.activeMapControl.Map.ViewEntire();
            }
        }
        /// <summary>
        /// 刷新地图控件状态
        /// </summary>
        /// <param name="control"></param>
        private void RefreshMapControl(MapControl control,string Mapname)
        {
            try
            {
                //避免连续打开地图导致程序异常
                if (control.Map != null)
                {
                    control.Map.Close();
                }
                //更换控件工作空间
                control.Map.Workspace = workspaceManage.workspace;
                control.Map.Open(Mapname);
                control.Map.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 添加地图控件和Tabpage页
        /// </summary>
        private TabPage AddMapAndTab()
        {
            TabPage tabPage = new TabPage();
            MapControl mapControl = new MapControl();
            mapControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(mapControl);
            utpMap.TabPages.Add(tabPage); 
            activeMapControl = mapControl;
            return tabPage;
        }
        /// <summary>
        /// 添加布局控件和Tabpage页
        /// </summary>
        private TabPage AddLayoutAndTab(string mapLayoutName)
        {
            TabPage tabPage = new TabPage();
            MapLayoutControl mapLayoutControl = new MapLayoutControl();
            mapLayoutControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(mapLayoutControl);
            utpMap.TabPages.Add(tabPage);
            activeMapLayoutControl = mapLayoutControl;
            activeMapLayoutControl.MapLayout.Workspace = workspaceManage.workspace;
            // 打开布局窗口水平、垂直滚动条
            activeMapLayoutControl.IsHorizontalScrollbarVisible = true;
            activeMapLayoutControl.IsVerticalScrollbarVisible = true;
            tabPage.Text = mapLayoutName;
            return tabPage;
        }
    }
}
