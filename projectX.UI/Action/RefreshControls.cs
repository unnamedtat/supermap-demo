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
        /// 工作空间更换时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WorkspaceChanged(object sender, PropertyChangedEventArgs e)
        {
            // 工作空间树连接到新工作空间
            this.workspaceControl.WorkspaceTree.Workspace = workspaceManage.workspace;
            utpMap.Selected -= UtpMap_SelectedIndexChanged;
            this.utpMap.Controls.Clear();
            AddMapAndTab();
            RefreshMainMapControl(null);
            RefreshEagZoomControls(null);
            utpMap.Selected += UtpMap_SelectedIndexChanged;
        }
        /// <summary>
        /// 刷新鹰眼图和放大镜
        /// </summary>
        public void RefreshEagZoomControls(string Mapname)
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
        /// 刷新本主地图控件
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
                //默认打开第一张地图
                if (Mapname == null && workspaceManage.workspace.Maps.Count != 0)
                {
                    string mapname0 = workspaceManage.workspace.Maps[0];
                    control.Map.Open(mapname0);
                    utpMap.SelectedTab.Text = mapname0;
                }
                else if (Mapname != null) { control.Map.Open(Mapname);
                    utpMap.SelectedTab.Text = Mapname;
                    
                }
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
        private void AddMapAndTab()
        {
            utpMap.Selected -= UtpMap_SelectedIndexChanged;//为防止冲突，先取消挂接
            TabPage tabPage = new TabPage();
            MapControl mapControl = new MapControl();
            mapControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(mapControl);
            utpMap.TabPages.Add(tabPage); 
            activeMapControl = mapControl;
            utpMap.SelectedTab = tabPage;
        }
    }
}
