using projectX.UI.Controls;
using ProjectX.BLL;
using ProjectX.UI.Controls;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace projectX.UI.Action
{
    internal class ControlManager
    {
        private UserTabPage utpMap;//地图控件tabpage页
        private WorkspaceControl workspaceControl;//工作空间树控件
        private LayersControl layersControl;//图层管理器控件
        private MapControl mapControlEagleEye;//鹰眼图控件
        private MapControl mapControlMagnifier;//放大镜控件
        private MapControl activeMapControl;//正在使用的地图控件
        private string defaultWorkSpaceInfo = @"e:\program files (x86)\supermap-iobjectsdotnet-10.1.2-19530-86195-all\sampledata\World\WorldUdbx.smwu";
        private IWorkspaceManage workspaceManage;//工作空间管理类
        private Rectangle2D engleRectangle;//鹰眼图上指示范围
        private Point pointBefore;//指示中心
        private Boolean isMoveEngleRect;//是否移动指示范围
        private int m_viewIndex;//指示当前活跃地图控件类型
        public event Action<string> mapModeChange;
        Delegate[] buttonDelegate;
        private Int32 ScaleIndex;//放大尺度，默认为3，最大为10
        private Panel headingLayoutPanel;
        private StatusStrip eaglerstatusBar;
        private StatusStrip coordinatetatusBar;


        /// <summary>
        /// 初始化地图控件
        /// </summary>
        /// <param name="mapPanel"></param>
        /// <param name="workspacepanel"></param>
        /// <param name="layerPanel"></param>
        /// <param name="Hawkeyepanel"></param>
        /// <param name="Hboostepanel"></param>
        /// <param name="headingLayoutPanel"></param>
        public void InitAllControls(Panel mapPanel, Panel workspacepanel, Panel layerPanel, Panel Hawkeyepanel, Panel Hboostepanel, Panel headingLayoutPanel)
        {
            try
            {
                workspaceManage = new WorkspaceManage();
                workspaceManage.SetWorkspace(defaultWorkSpaceInfo);//设定默认工作空间
                utpMap = new UserTabPage();
                mapPanel.Controls.Add(utpMap);
                InitWorkspaceControl(workspacepanel);//初始化工作空间树
                InitLayerControl(layerPanel);//初始化图层管理器
                InitMainMapControl(mapPanel);//初始化一个tabpage、mapcontrol
                InitEagZoomMapControl(Hawkeyepanel, Hboostepanel);//初始化鹰眼图放大镜控件
                initEagleZoomEvent();//鹰眼图放大镜事件初始化
                RefreshMainMapControl();
                RefreshEagZoomControls();
                workspaceManage.PropertyChanged += this.WorkspaceChanged;
                this.headingLayoutPanel = headingLayoutPanel;
                initbtn();
                this.mapModeChange += HeadingControl_mapModeChange;
                workspaceControl.WorkspaceTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(WorkspaceTree_NodeMouseDoubleClick);
                workspaceControl.WorkspaceTree.AllowDefaultAction = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InitStatusBar(StatusStrip eaglerstatusBar, StatusStrip coordinatetatusBar)
        {
            this.eaglerstatusBar = eaglerstatusBar;
            this.coordinatetatusBar = coordinatetatusBar;
        }
        /// <summary>
        /// 绑定顶部按钮点击事件
        /// </summary>
        /// <param name="Tag"></param>
        private void HeadingControl_mapModeChange(string Tag)
        {
            switch (Tag)
            {
                case "5": this.activeMapControl.Action = SuperMap.UI.Action.ZoomIn; break;
                case "6": this.activeMapControl.Action = SuperMap.UI.Action.ZoomOut; break;
                case "7": this.activeMapControl.Action = SuperMap.UI.Action.ZoomFree; break;
                case "8": this.activeMapControl.Map.ViewEntire(); break;
                case "9": this.activeMapControl.Action = SuperMap.UI.Action.Pan; break;
                default: break;
            }
        }
        /// <summary>
        /// 绑定鹰眼图事件
        /// </summary>
        public void initEagleZoomEvent()
        {
            mapControlEagleEye.MouseMove += new MouseEventHandler(EagleEyeMapMouseMoveHandler);
            mapControlEagleEye.MouseDown += new MouseEventHandler(EagleEyeMapMouseDownHandler);
            mapControlEagleEye.MouseUp += new MouseEventHandler(EagleEyeMapMouseUpHandler);
            mapControlEagleEye.ActionCursorChanging += new ActionCursorChangingEventHandler(EagleEyeMapCursorChangedHandler);

            activeMapControl.Map.Drawn += new MapDrawnEventHandler(MainMapDrawnHandler);
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
        private void InitMainMapControl(Panel mapPanel)
        {
            m_viewIndex = 0;
            this.utpMap.TabPages.Clear();//清除所有tabpage
            AddMapAndTab();
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
        /// <summary>
        /// 地图绘制完成后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMapDrawnHandler(object sender, MapDrawnEventArgs e)
        {
            if (!isMoveEngleRect)
            {
                DisplayRect(activeMapControl.Map.ViewBounds);
            }
            ZoomForView();
        }
        /// <summary>
        /// 定义鹰眼图中鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseMoveHandler(object sender, MouseEventArgs e)
        {
            mapControlEagleEye.Cursor = Cursors.Arrow;

            try
            {
                MapControl eagleEyeMapControl = sender as MapControl;
                Map eagleEyeMap = eagleEyeMapControl.Map;
                // 当鼠标是在rect框内时，改变鼠标形态，对改变鼠标形态进行控制
                // Change the mouse shape when the mouse cursor move into the rect 
                if (engleRectangle.Contains(eagleEyeMap.PixelToMap(e.Location)))
                {
                    mapControlEagleEye.Cursor = Cursors.Cross;

                    if (e.Button == MouseButtons.Left)
                    {
                        isMoveEngleRect = true;
                    }
                }

                if (isMoveEngleRect)
                {
                    // 将pointBefore点和当前鼠标点的像素坐标转换为地图坐标
                    // Change the pixel coordinates of pointBefore and current point into the map coordinates
                    // 计算两点的坐标差对rect进行重新绘制
                    // Calculate the distance of the two point and redraw the rect
                    Point2D point2DBeforeMove = mapControlEagleEye.Map.PixelToMap(pointBefore);
                    Point2D point2DAfterMove = mapControlEagleEye.Map.PixelToMap(e.Location);

                    Double dx = point2DAfterMove.X - point2DBeforeMove.X;
                    Double dy = point2DAfterMove.Y - point2DBeforeMove.Y;

                    engleRectangle = new Rectangle2D(OffsetPoint(new Point2D(engleRectangle.Left, engleRectangle.Bottom), dx, dy), OffsetPoint(new Point2D(engleRectangle.Right, engleRectangle.Top), dx, dy));

                    DisplayRect(engleRectangle);
                    activeMapControl.Map.ViewBounds = engleRectangle;
                    activeMapControl.Map.Refresh();
                    // 将鼠标的当前点坐标存入pointBefore，以进行循环计算
                    // Save the current point coordinates into pointBefore
                    pointBefore = e.Location;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 定义鹰眼窗口鼠标按下事件，并将鼠标按下时的坐标保存到pointBefore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pointBefore = e.Location;
            }
        }
        /// <summary>
        /// 定义鼠标释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseUpHandler(object sender, MouseEventArgs e)
        {
            try
            {
                // 左键释放，定义isMoveEngleRect为false
                // The isMoveEngleRect property is set to false
                if (e.Button == MouseButtons.Left)
                {
                    if (!isMoveEngleRect)
                    {
                        Point2D pntCenter = mapControlEagleEye.Map.PixelToMap(e.Location);
                        activeMapControl.Map.Center = pntCenter;
                        activeMapControl.Map.Refresh();
                    }

                    isMoveEngleRect = false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 定义更新光标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapCursorChangedHandler(object sender, ActionCursorChangingEventArgs e)
        {
            e.FollowingCursor = Cursors.Cross;
        }
        /// <summary>
        /// 放大镜按比例显示
        /// </summary>
        public void ZoomForView()
        {
            try
            {
                Point2D pntCenter = activeMapControl.Map.Center;
                mapControlMagnifier.Map.Center = pntCenter;

                //  选择地图放大倍数，放大镜窗口放大显示
                mapControlMagnifier.Map.Scale = activeMapControl.Map.Scale * ScaleIndex;
                mapControlMagnifier.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 按照指定风格显示指示范围矩形
        /// </summary>
        /// <param name="rectangleDisplay"></param>
        private void DisplayRect(Rectangle2D rectangleDisplay)
        {
            try
            {
                engleRectangle = rectangleDisplay;
                mapControlEagleEye.Cursor = Cursors.Cross;

                Double rectangleWidth = rectangleDisplay.Width;
                Double rectangleHeight = rectangleDisplay.Height;
                Double pntLeftTopX = rectangleDisplay.Left;
                Double pntLeftTopY = rectangleDisplay.Top;
                // 设置图框四点坐标
                // Set the four point of the rectangle
                Point2Ds points = new Point2Ds();

                Point2D pntLeftTop = new Point2D(pntLeftTopX, pntLeftTopY);
                points.Add(pntLeftTop);
                Point2D pntLeftBottom = new Point2D(pntLeftTopX, pntLeftTopY - rectangleHeight);
                points.Add(pntLeftBottom);
                Point2D pntRightBottom = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY - rectangleHeight);
                points.Add(pntRightBottom);
                Point2D pntRightTop = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY);
                points.Add(pntRightTop);
                points.Add(pntLeftTop);
                // 将点连成线，并设置样式
                // Connect the points to line and set its style

                GeoLine rectangleBoundary = new GeoLine();
                rectangleBoundary.AddPart(points);

                GeoStyle rectangleStyle = new GeoStyle();
                rectangleStyle.LineColor = Color.FromArgb(255, 0, 0);
                rectangleStyle.LineWidth = 0.5;

                rectangleBoundary.Style = rectangleStyle;
                // 添加到跟踪层
                // Add the rectangle into the trackinglayer
                mapControlEagleEye.Map.TrackingLayer.Clear();
                mapControlEagleEye.Map.TrackingLayer.Add((Geometry)rectangleBoundary, "");
                mapControlEagleEye.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 构建offset点对象
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        private Point2D OffsetPoint(Point2D point, Double dx, Double dy)
        {
            Point2D temp = point;
            temp.Offset(dx, dy);

            return temp;
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
            RefreshMainMapControl();
            RefreshEagZoomControls();
        }
        /// <summary>
        /// 刷新鹰眼图和放大镜
        /// </summary>
        public void RefreshEagZoomControls()
        {
            // 将地图关联到图层管理器，使其管理其中的地图图层
            this.layersControl.Map = this.activeMapControl.Map;
            MapControl[] EMmapControls = new MapControl[2] { this.mapControlEagleEye, this.mapControlMagnifier };
            foreach (MapControl control in EMmapControls)
            {
                RefreshMapControl(control);
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
            if (this.mapControlEagleEye.Map != null) this.mapControlEagleEye.Map.ViewEntire();

            this.mapControlMagnifier.MarginPanEnabled = false;
            this.mapControlMagnifier.IsWaitCursorEnabled = false;
            this.mapControlMagnifier.Action = SuperMap.UI.Action.Null;
            this.mapControlMagnifier.InteractionMode = InteractionMode.CustomAll;
            this.ScaleIndex = 3;

            if (this.mapControlMagnifier.Map != null && this.activeMapControl.Map.Scale != 0)
                this.mapControlMagnifier.Map.Scale = this.activeMapControl.Map.Scale * this.ScaleIndex;
        }
        /// <summary>
        /// 刷新本主地图控件
        /// </summary>
        private void RefreshMainMapControl()
        {
            RefreshMapControl(this.activeMapControl);
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
        private void RefreshMapControl(MapControl control)
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
                if (workspaceManage.workspace.Maps.Count != 0)
                {
                    control.Map.Open(workspaceManage.workspace.Maps[0]);
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
            TabPage tabPage = new TabPage();
            MapControl mapControl = new MapControl();
            mapControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(mapControl);
            utpMap.TabPages.Add(tabPage);
            activeMapControl = mapControl;
        }
        private void WorkspaceTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            AddData();
        }
        /// <summary>
        /// 添加数据集到地图或场景
        /// Add the dataset to the map or the scene
        /// </summary>
        private void AddData()
        {
            try
            {
                WorkspaceTreeNodeBase node = workspaceControl.WorkspaceTree.SelectedNode as WorkspaceTreeNodeBase;
                WorkspaceTreeNodeDataType type = node.NodeType;
                if ((type & WorkspaceTreeNodeDataType.Dataset) != WorkspaceTreeNodeDataType.Unknown)
                {
                    type = WorkspaceTreeNodeDataType.Dataset;
                }
                switch (type)
                {
                    case WorkspaceTreeNodeDataType.Dataset:
                        {
                            Dataset dataset = node.GetData() as Dataset;
                            if (m_viewIndex == 0)
                            {
                                layersControl.Map.Layers.Add(dataset, true);
                                layersControl.Map.Refresh();
                            }
                            //else if (m_viewIndex == 1)
                            //{
                            //    if (dataset.Type == DatasetType.Grid)
                            //    {
                            //        layersControl.Scene.Layers.Add(dataset, m_layer3DSettingGrid, true);
                            //    }
                            //    else if (dataset.Type == DatasetType.Image)
                            //    {
                            //        layersControl.Scene.Layers.Add(dataset, m_layer3DSettingImage, true);
                            //    }
                            //    else
                            //    {
                            //        layersControl.Scene.Layers.Add(dataset, m_layer3DSettingVector, true);
                            //    }
                            //    sceneControl.Scene.Refresh();
                            //}
                        }
                        break;
                    case WorkspaceTreeNodeDataType.MapName:
                        {
                            String mapName = node.GetData() as String;

                            if (layersControl.Map != null)
                            {
                                activeMapControl.Map.Open(mapName);
                                activeMapControl.Map.Refresh();
                            }
                            //else if (m_layersControl.Scene != null && !m_layersControl.Scene.Layers.Contains(mapName))
                            //{
                            //    m_layersControl.Scene.Layers.Add(mapName, Layer3DType.Map, true, mapName);
                            //    m_sceneControl.Scene.Refresh();
                            //}
                        }
                        break;
                    //case WorkspaceTreeNodeDataType.SceneName:
                    //    {
                    //        String sceneName = node.GetData() as String;
                    //        if (m_layersControl.Scene != null)
                    //        {
                    //            m_layersControl.Scene.Open(sceneName);
                    //            m_sceneControl.Scene.Refresh();
                    //        }
                    //    }
                    //break;
                    case WorkspaceTreeNodeDataType.SymbolMarker:
                        {
                            SymbolLibraryDialog.ShowDialog(workspaceManage.workspace.Resources, SymbolType.Marker);
                        }
                        break;
                    case WorkspaceTreeNodeDataType.SymbolLine:
                        {
                            SymbolLibraryDialog.ShowDialog(workspaceManage.workspace.Resources, SymbolType.Line);
                        }
                        break;
                    case WorkspaceTreeNodeDataType.SymbolFill:
                        {
                            SymbolLibraryDialog.ShowDialog(workspaceManage.workspace.Resources, SymbolType.Fill);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 设置按钮
        /// </summary>
        public void initbtn()
        {
            int buttonNum = 5;
            //初始化tabpage1的compositebutton
            CompositeButton[] compositeButtons = new CompositeButton[buttonNum];
            string[] cpbtnTEXT = { "打开工作空间", "打开数据库型工作空间", "打开数据源", "新建地图", "数据导入" };
            //依次绑定事件点击方法,只绑定了一个
            Action<object, System.EventArgs> action = OpenFilebtnOnclick;
            buttonDelegate = action.GetInvocationList();
            for (int i = 0; i < buttonNum; i++)
            {
                compositeButtons[i] = new CompositeButton();
                compositeButtons[i].ButtonText = cpbtnTEXT[i];
                compositeButtons[i].Tag = i + 1;
                compositeButtons[i].Click += ButtonOnclick;
                this.headingLayoutPanel.Controls.Add(compositeButtons[i]);
            }
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
        private void toolStripBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            mapModeChange?.Invoke(button.Tag.ToString());
        }
        /// <summary>
        /// 改变尺度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDownButton_Click(object sender, EventArgs e)
        {
            ToolStripDropDownButton button = (ToolStripDropDownButton)sender;
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
            foreach (Control control in this.eaglerstatusBar.Controls)
            {
                if (control.Name == "tssLabelScale") control.Text = "放大倍数:" + this.ScaleIndex + "x";
            }

            ZoomForView();
        }
    }
}
