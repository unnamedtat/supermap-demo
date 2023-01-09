using ProjectX.BLL;
using ProjectX.UI.Controls;
using SuperMap.UI;
using System;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private MapControl mapControl;//地图控件
        private HeadingControl headingControl;//标题栏控件
        private WorkspaceControl workspaceControl;//工作空间树控件
        private LayersControl layersControl;//图层管理器控件

        private string defaultWorkSpaceInfo = @"e:\program files (x86)\supermap-iobjectsdotnet-10.1.2-19530-86195-all\sampledata\world\world.smwu";
        private WorkspaceManage workspaceManage;//工作空间管理类
        /// <summary>
        /// 初始化地图控件
        /// </summary>
        /// <param name="headingPanel"></param>
        /// <param name="mapPanel"></param>
        /// <param name="workspacepanel"></param>
        /// <param name="layerpanel"></param>
        public void InitAllControls(Panel headingPanel, Panel mapPanel, Panel workspacepanel, Panel layerpanel)
        {
            try
            {
                workspaceManage = new WorkspaceManage();
                InitHeadingControls(headingPanel);
                InitMapControl(mapPanel);
                InitNavigation(workspacepanel, layerpanel);
                workspaceManage.SetWorkspace(defaultWorkSpaceInfo);//设定默认工作空间
                RefreshControls();//刷新工作空间关联
                workspaceManage.PropertyChanged += this.WorkspaceChanged;
                headingControl.mapModeChange += HeadingControl_mapModeChange;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HeadingControl_mapModeChange(string Tag)
        {
            switch (Tag)
            {
                case "1": mapControl.Action = SuperMap.UI.Action.ZoomIn;break;
                case "2": mapControl.Action = SuperMap.UI.Action.ZoomOut;break;
                case "3": mapControl.Action = SuperMap.UI.Action.ZoomFree; break;
                case "4": mapControl.Map.ViewEntire();break;
                case "5": mapControl.Action = SuperMap.UI.Action.Pan;break;     
                default:break;
            }
        }

        /// <summary>
        /// 添加标题栏
        /// </summary>
        /// <param name="headingPanel"></param>
        private void InitHeadingControls(Panel headingPanel)
        {
            //添加标题栏
            this.headingControl = new HeadingControl(this.workspaceManage);
            this.headingControl.Dock = DockStyle.Fill;
            headingPanel.Controls.Add(this.headingControl);
        }
        /// <summary>
        /// 添加地图漫游框
        /// </summary>
        /// <param name="mapPanel"></param>
        private void InitMapControl(Panel mapPanel)
        {
            //为用户界面添加地图控件
            this.mapControl = new MapControl();
            this.mapControl.Dock = DockStyle.Fill;
            mapPanel.Controls.Add(this.mapControl);
        }
        /// <summary>
        /// 添加工作空间树及图层管理器
        /// </summary>
        /// <param name="workspacepanel"></param>
        /// <param name="layerpanel"></param>
        private void InitNavigation(Panel workspacepanel, Panel layerpanel)
        {
            //添加工作空间控件
            this.workspaceControl = new WorkspaceControl();
            this.workspaceControl.Dock = DockStyle.Fill;
            workspacepanel.Controls.Add(workspaceControl);
            //添加图层管理器控件
            this.layersControl = new LayersControl();
            this.layersControl.Dock = DockStyle.Fill;
            layerpanel.Controls.Add(this.layersControl);
        }
    }
}
