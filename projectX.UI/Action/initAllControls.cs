using ProjectX.UI.Controls;
using ProjectX.BLL;
using SuperMap.UI;
using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using SuperMap.Data;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private UserTabPage utpMap;//地图控件tabpage页
        private WorkspaceControl workspaceControl;//工作空间树控件
        private LayersControl layersControl;//图层管理器控件
        private MapControl mapControlEagleEye;//鹰眼图控件
        private MapControl mapControlMagnifier;//放大镜控件
        private MapControl activeMapControl;//正在使用的地图控件
        private MapLayoutControl activeMapLayoutControl;//正在使用的布局控件
        private string defaultWorkSpaceInfo = @"e:\program files (x86)\supermap-iobjectsdotnet-10.1.2-19530-86195-all\sampledata\World\WorldUdbx.smwu";
        private IWorkspaceManage workspaceManage;//工作空间管理类
        /// <summary>
        /// 初始化地图控件
        /// </summary>
        /// <param name="headingPanel"></param>
        /// <param name="mapPanel"></param>
        /// <param name="workspacepanel"></param>
        /// <param name="layerpanel"></param>
        /// <param name="Hawkeyepanel"></param>
        /// <param name="Hboostepanel"></param>
        public void InitAllControls(Panel mapPanel, Panel workspacepanel, Panel layerPanel, Panel Hawkeyepanel, Panel Hboostepanel)
        {
            try
            {
                WorkspaceConnectionInfo defaultconnectionInfo = new WorkspaceConnectionInfo(defaultWorkSpaceInfo);
                workspaceManage = new WorkspaceManage();
                workspaceManage.SetWorkspace(defaultconnectionInfo);//设定默认工作空间
                utpMap = new UserTabPage();
                utpMap.SelectedIndexChanged += UtpMap_SelectedIndexChanged;//添加选中map更改事件
                mapPanel.Controls.Add(utpMap);
                InitWorkspaceControl(workspacepanel);//初始化工作空间树
                InitLayerControl(layerPanel);//初始化图层管理器
                TabPage InitTabpage = InitMainMapControl();//初始化一个tabpage、mapcontrol
                InitEagZoomMapControl(Hawkeyepanel, Hboostepanel);//初始化鹰眼图放大镜控件
                initEagleZoomEvent();//鹰眼图放大镜事件初始化
                InitOpenFristMap(InitTabpage);
                workspaceManage.PropertyChanged += this.WorkspaceChanged;
                initbtn();
                this.mapModeChange += HeadingControl_mapModeChange;//绑定顶部按钮点击事件
                this.tssLabelCoordinate.Alignment = ToolStripItemAlignment.Right;//状态栏
                InitWorkAndLayercontrols();

                this.statusStrip1.Items[1].Click += new System.EventHandler(this.UpDownButton_Click);
                this.statusStrip1.Items[2].Click += new System.EventHandler(this.UpDownButton_Click);
                InitiAttributeMange();
                initCoordinateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitOpenFristMap(TabPage InitTabpage)
        {
            if (workspaceManage.workspace.Maps.Count == 0)
            {
                workspaceManage.CreatMap("未命名地图");
            }
            //默认打开第一张地图，若无则创建一张(方便第一次打开)
            RefreshMainMapControl(workspaceManage.workspace.Maps[0]);
            RefreshEagZoomLayerControls(workspaceManage.workspace.Maps[0]);
            InitTabpage.Text = workspaceManage.workspace.Maps[0];
            ShowMapControls();
        }

        /// <summary>
        /// 绑定顶部按钮点击事件
        /// </summary>
        /// <param name="Tag"></param>
        private void HeadingControl_mapModeChange(string Tag)
        {
            switch (Tag)
            {
                case "3": this.activeMapControl.Action = SuperMap.UI.Action.Select;
                    activeMapControl.SelectionMode = SuperMap.UI.SelectionMode.Intersect; break;
                case "4": this.activeMapControl.Action = SuperMap.UI.Action.ZoomIn; break;
                case "5": this.activeMapControl.Action = SuperMap.UI.Action.ZoomOut; break;
                case "8": this.activeMapControl.Map.Refresh(); break;
                case "7": this.activeMapControl.Map.ViewEntire(); break;
                case "6": this.activeMapControl.Action = SuperMap.UI.Action.Pan; break;
                case "9": this.activeMapControl.Action = SuperMap.UI.Action.ZoomFree; break;
                default: break;
            }
        }
        /// <summary>
        /// 添加地图漫游框
        /// </summary>
        /// <param name="mapPanel"></param>
        private void InitEagZoomMapControl(Panel Hawkeyepanel, Panel Boostepanel)
        {
            //为用户界面添加鹰眼图控件
            mapControlEagleEye = new MapControl();
            mapControlEagleEye.Dock = DockStyle.Fill;
            Hawkeyepanel.Controls.Add(mapControlEagleEye);
            //为用户界面添加放大镜控件
            mapControlMagnifier = new MapControl();
            mapControlMagnifier.Dock = DockStyle.Fill;
            Boostepanel.Controls.Add(mapControlMagnifier);
        }
        /// <summary>
        /// 初始化添加地图控件
        /// </summary>
        /// <param name="mapPanel"></param>
        private TabPage InitMainMapControl()
        {
            viewIndex = 0;
            this.utpMap.TabPages.Clear();//清除所有tabpage
            return AddMapAndTab();
        }
        /// <summary>
        /// 改变放大镜中尺度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDownButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            switch (button.Tag)
            {
                case "1": this.ScaleIndex += 1; break;
                case "2": this.ScaleIndex -= 1; break;
                default:
                    break;
            }
            if (this.ScaleIndex < 1)
            {
                this.ScaleIndex = 1; return;
            }
            else if (this.ScaleIndex > 6)
            {
                this.ScaleIndex = 6; return;
            }
            tssLabelScale.Text = "放大倍数:" + this.ScaleIndex + "x";
            ZoomForView();
        }
        /// <summary>
        /// 添加工作空间树
        /// </summary>
        /// <param name="workspacePanel"></param>
        private void InitWorkspaceControl(Panel workspacePanel)
        {
            this.workspaceControl = new WorkspaceControl();
            this.workspaceControl.Dock = DockStyle.Fill;
            workspacePanel.Controls.Add(workspaceControl);
            this.workspaceControl.WorkspaceTree.Workspace = workspaceManage.workspace;// 工作空间树连接到新工作空间
        }
        /// <summary>
        /// 添加图层管理器
        /// </summary>
        /// <param name="layerPanel"></param>
        private void InitLayerControl(Panel layerPanel)
        {
            //添加图层管理器控件
            this.layersControl = new LayersControl();
            this.layersControl.Dock = DockStyle.Fill;
            layerPanel.Controls.Add(this.layersControl);
        }
    }
}
