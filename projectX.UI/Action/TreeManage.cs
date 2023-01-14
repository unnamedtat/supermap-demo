using ProjectX.UI.Controls;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private KeyEventHandler layersTreeDoKeyDelete;
        private int viewIndex;//指示当前活跃地图控件类型
        /// <summary>
        /// 初始化绑定工作空间和图层管理器相关事件
        /// </summary>
        private void InitWorkAndLayercontrols()
        {
            //绑定工作空间树的初始化事件
            workspaceControl.WorkspaceTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(WorkspaceTree_NodeMouseDoubleClick);
            workspaceControl.WorkspaceTree.AllowDefaultAction = true;
            workspaceControl.WorkspaceTree.BeforeNodeContextMenuStripShow += new BeforeNodeContextMenuStripShowEventHandler(WorkspaceTree_BeforeNodeContextMenuStripShow);

            // LayersTree保存Delete按键默认操作并自定义操作
            layersTreeDoKeyDelete = layersControl.LayersTree.Interactions[InteractionType.KeyDelete] as KeyEventHandler;
            layersControl.LayersTree.Interactions[InteractionType.KeyDelete] = new KeyEventHandler(LayersTreeDoKeyDelete);
            layersControl.LayersTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(LayersTree_NodeMouseDoubleClick);
            layersControl.LayersTree.BeforeNodeContextMenuStripShow += new BeforeNodeContextMenuStripShowEventHandler(LayersTree_BeforeNodeContextMenuStripShow);
        }
        /// <summary>
        /// 工作空间树双击事件挂接方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            if (viewIndex == 0)
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

                            OpenMap(mapName, this.utpMap);
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
                    case WorkspaceTreeNodeDataType.Maps:
                        break;
                    default:
                        break;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 在指定tabcontrol中打开指定map
        /// </summary>
        /// <param name="mapName"></param>
        /// <param name="utpMap"></param>
        private void OpenMap(string mapName, UserTabPage utpMap)
        {
            if (layersControl.Map != null)
            {
                TabPage containTapPage = checkMapIsInUtp(mapName, utpMap);
                //若已存在，不添加,改变激活map
                if (containTapPage != null)
                {
                    activeMapControl = (MapControl)containTapPage.Controls[0];
                    utpMap.SelectedTab = containTapPage;
                }
                else AddMapAndTab();
                RefreshMainMapControl(mapName);
                RefreshEagZoomLayerControls(mapName);
                ChangeMap();
                //utpMap.Selected += UtpMap_SelectedIndexChanged;//重新挂接
            }
        }
        /// <summary>
        /// 查看地图是否重复加入
        /// </summary>
        /// <param name="mapName"></param>
        /// <returns></returns>
        private TabPage checkMapIsInUtp(string mapName, UserTabPage utpMap)
        {
            foreach (TabPage tabpage in utpMap.TabPages)
            {
                MapControl mapcontrol = (MapControl)tabpage.Controls[0];
                if (mapcontrol.Map.Name == mapName) return tabpage;
            }
            return null;
        }
        /// <summary>
        /// 工作空间树右击选择添加地图或数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAddDataMap_Click(object sender, EventArgs e)
        {
            AddData();
        }
        /// <summary>
        /// 工作空间树右键菜单弹出前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkspaceTree_BeforeNodeContextMenuStripShow(object sender, BeforeNodeContextMenuStripShowEventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripMenuItemAddData = new ToolStripMenuItem();
                toolStripMenuItemAddData.Click += new EventHandler(toolStripMenuItemAddDataMap_Click);
                if (viewIndex == 0)
                {
                    toolStripMenuItemAddData.Text = "添加到当前地图";
                }
                else
                {
                    toolStripMenuItemAddData.Text = "添加到当前场景";

                }
                ToolStripMenuItem toolStripMenuItemOpenMap = new ToolStripMenuItem("Open Map");
                toolStripMenuItemOpenMap.Text = "打开地图";
                toolStripMenuItemOpenMap.Click += new EventHandler(toolStripMenuItemAddDataMap_Click);

                ContextMenuStrip contextMenuStripWorkspaceTree = new ContextMenuStrip();
                WorkspaceTreeNodeBase treeNode = e.Node as WorkspaceTreeNodeBase;
                if ((treeNode.NodeType & WorkspaceTreeNodeDataType.Dataset) != WorkspaceTreeNodeDataType.Unknown)
                {
                    contextMenuStripWorkspaceTree.Items.AddRange(new ToolStripItem[] { toolStripMenuItemAddData });
                }
                else if (treeNode.NodeType == WorkspaceTreeNodeDataType.MapName)
                {
                    contextMenuStripWorkspaceTree.Items.AddRange(new ToolStripItem[] { toolStripMenuItemOpenMap });
                }
                workspaceControl.WorkspaceTree.NodeContextMenuStrips[treeNode.NodeType] = contextMenuStripWorkspaceTree;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 切换地图窗口，更改图层管理器、鹰眼图等关联
        /// </summary>
        private void ChangeMap()
        {
            initEagleZoomEvent();
            InitiAttributeMange();
        }
        /// <summary>
        /// LayersTree自定义Delete按键操作
        /// </summary>
        private void LayersTreeDoKeyDelete(object sender, KeyEventArgs e)
        {
            DeleteLayer();
        }
        /// <summary>
        /// 删除二维图层树中的图层
        /// Delete layers in LayersTree
        /// </summary>
        public void DeleteLayer()
        {
            try
            {
                TreeNode[] selected = layersControl.LayersTree.SelectedNodes;
                if (selected.Length > 0)
                {
                    Object data = (selected[0] as TreeNodeBase).GetData();
                    if (data is ThemeUniqueItem)
                    {
                        // 删除单值专题图子项
                        // Delete the items of the unique values map
                        LayersTreeNodeBase layerNode = selected[0].Parent as LayersTreeNodeBase;
                        Layer layer = layerNode.GetData() as Layer;
                        ThemeUnique themeUnique = layer.Theme as ThemeUnique;
                        foreach (TreeNode node in selected)
                        {
                            if (themeUnique.Remove(node.Index))
                            {
                                node.Remove();
                            }
                        }
                        layersControl.LayersTree.SelectedNodes = new TreeNode[] { layerNode };
                        layersControl.Map.Refresh();
                    }
                    else if (data is ThemeGridUniqueItem)
                    {
                        // 删除栅格单值专题图子项
                        // Delete the items of the grid unique values map
                        LayersTreeNodeBase layerNode = selected[0].Parent as LayersTreeNodeBase;
                        Layer layer = layerNode.GetData() as Layer;
                        ThemeGridUnique themeGridUnique = layer.Theme as ThemeGridUnique;
                        foreach (TreeNode node in selected)
                        {
                            if (themeGridUnique.Remove(node.Index))
                            {
                                node.Remove();
                            }
                        }
                        layersControl.LayersTree.SelectedNodes = new TreeNode[] { layerNode };
                        layersControl.Map.Refresh();
                    }
                    else if (data is ThemeGraphItem)
                    {
                        // 删除统计专题图子项
                        // Deletem the items of the graph map
                        LayersTreeNodeBase layerNode = selected[0].Parent as LayersTreeNodeBase;
                        Layer layer = layerNode.GetData() as Layer;
                        ThemeGraph themeGraph = layer.Theme as ThemeGraph;
                        foreach (TreeNode node in selected)
                        {
                            if (themeGraph.Remove(node.Index))
                            {
                                node.Remove();
                            }
                        }
                        layersControl.LayersTree.SelectedNodes = new TreeNode[] { layerNode };
                        layersControl.Map.Refresh();
                    }
                    else
                    {
                        // 执行Layer3DsTree的默认操作
                        // Perform the default Layers3DsTree operations
                        layersTreeDoKeyDelete(layersControl.LayersTree, new KeyEventArgs(Keys.Delete));
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 双击图层管理器图层节点事件
        /// The event of double clicking a layer in the layer control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayersTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetLayerStyle();
        }
        /// <summary>
        /// 风格设置
        /// Set styles
        /// </summary>
        private void SetLayerStyle()
        {
            try
            {
                LayersTreeNodeBase node = layersControl.LayersTree.SelectedNode as LayersTreeNodeBase;
                Layer layer = node.GetData() as Layer;
                if (layer != null && layer.Theme == null)
                {
                    DatasetType type = layer.Dataset.Type;
                    //根据图层类型显示对应的资源管理器控件
                    // Show the explorer control according to the layer type
                    switch (type)
                    {
                        case DatasetType.Point:
                        case DatasetType.Line:
                        case DatasetType.Region:
                            {
                                LayerSettingVector setting = layer.AdditionalSetting as LayerSettingVector;
                                GeoStyle style = SymbolDialog.ShowDialog(workspaceManage.workspace.Resources, setting.Style, GetSymbolType(type));
                                if (style != null)
                                {
                                    setting.Style = style;

                                    activeMapControl.Map.Refresh();
                                    layersControl.LayersTree.RefreshNode(node);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 根据数据集类型获取符号库的类型
        /// </summary>
        /// <param name="datasetType">数据集类型</param>
        /// <param name="datasetType">Dataset type</param>
        /// <returns>返回符号库类型</returns>
        /// <returns>Return the symbol library type</returns>
        private SymbolType GetSymbolType(DatasetType datasetType)
        {
            SymbolType result = SymbolType.Marker;

            switch (datasetType)
            {
                case DatasetType.Line:
                    {
                        result = SymbolType.Line;
                    }
                    break;
                case DatasetType.Point:
                    {
                        result = SymbolType.Marker;
                    }
                    break;
                case DatasetType.Region:
                    {
                        result = SymbolType.Fill;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// 二维图层树右键菜单弹出前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayersTree_BeforeNodeContextMenuStripShow(object sender, BeforeNodeContextMenuStripShowEventArgs e)
        {
            try
            {
                TreeNodeBase treeNode = e.Node as TreeNodeBase;
                Layer layer = treeNode.GetData() as Layer;
                if (layer != null)
                {
                    ToolStripMenuItem toolStripMenuItemLayersTreeDelete = new ToolStripMenuItem("Remove");
                    toolStripMenuItemLayersTreeDelete.Click += new EventHandler(toolStripMenuItemLayersTreeDelete_Click);
                    ToolStripMenuItem toolStripMenuItemRename = new ToolStripMenuItem("Rename");
                    toolStripMenuItemRename.Click += new EventHandler(toolStripMenuItemLayersRename_Click);
                    ToolStripMenuItem toolStripMenuItemStyle = new ToolStripMenuItem("Set Style");
                    toolStripMenuItemStyle.Click += new EventHandler(toolStripMenuItemStyle_Click);
                    ToolStripMenuItem toolStripMenuItemCanEdit = new ToolStripMenuItem("Editable");
                    toolStripMenuItemCanEdit.Tag = TreeIconTypes.Editable;
                    toolStripMenuItemLayersTreeDelete.Text = "移除";
                    toolStripMenuItemRename.Text = "重命名";
                    toolStripMenuItemStyle.Text = "风格设置";
                    toolStripMenuItemCanEdit.Text = "可编辑";
                    if (layer.IsEditable)
                    {
                        toolStripMenuItemCanEdit.CheckState = CheckState.Checked;
                    }
                    ToolStripMenuItem toolStripMenuItemCanSnap = new ToolStripMenuItem("Snap");
                    toolStripMenuItemCanSnap.Text = "可捕捉";
                    toolStripMenuItemCanSnap.Tag = TreeIconTypes.Snapable;
                    if (layer.IsSnapable)
                    {
                        toolStripMenuItemCanSnap.CheckState = CheckState.Checked;
                    }
                    ToolStripMenuItem toolStripMenuItemCanSee = new ToolStripMenuItem("Visible");
                    toolStripMenuItemCanSee.Text = "可显示";
                    toolStripMenuItemCanSee.Tag = TreeIconTypes.Visible;
                    if (layer.IsVisible)
                    {
                        toolStripMenuItemCanSee.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        toolStripMenuItemCanEdit.Enabled = false;
                        toolStripMenuItemCanSnap.Enabled = false;
                    }

                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    toolStripMenuItemCanSee.Click += new EventHandler(contextMenuStrip_ItemClicked);
                    toolStripMenuItemCanEdit.Click += new EventHandler(contextMenuStrip_ItemClicked);
                    toolStripMenuItemCanSnap.Click += new EventHandler(contextMenuStrip_ItemClicked);
                    //contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
                    if (layer.Theme == null)
                    {
                        switch (layer.Dataset.Type)
                        {
                            case DatasetType.Point:
                            case DatasetType.Line:
                            case DatasetType.Region:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee, toolStripMenuItemCanEdit, toolStripMenuItemCanSnap, toolStripMenuItemStyle, toolStripMenuItemLayersTreeDelete, toolStripMenuItemRename });
                                }
                                break;
                            case DatasetType.Text:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee, toolStripMenuItemCanEdit, toolStripMenuItemLayersTreeDelete, toolStripMenuItemRename });
                                }
                                break;
                            default:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee, toolStripMenuItemLayersTreeDelete, toolStripMenuItemRename });
                                }
                                break;
                        }
                    }
                    else if (layer.Theme != null)
                    {
                        switch (layer.Theme.Type)
                        {
                            case ThemeType.Unique:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee, toolStripMenuItemLayersTreeDelete, toolStripMenuItemRename });
                                }
                                break;
                            case ThemeType.Label:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee, toolStripMenuItemLayersTreeDelete });

                                }
                                break;
                            default:
                                {
                                    contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCanSee });
                                }
                                break;
                        }
                    }
                    layersControl.LayersTree.NodeContextMenuStrips[LayersTreeNodeDataType.Layer] = contextMenuStrip;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 二维图层树移除图层、专题图子项单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemLayersTreeDelete_Click(object sender, EventArgs e)
        {
            DeleteLayer();
        }
        /// <summary>
        /// 二维图层重命名单击事件
        /// Event for renaming layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemLayersRename_Click(object sender, EventArgs e)
        {
            LayersRename();
        }
        /// <summary>
        /// 二维图层树图层重命名
        /// Rename the layer in LayersTree
        /// </summary>
        public void LayersRename()
        {
            try
            {
                TreeNode node = layersControl.LayersTree.SelectedNode;
                layersControl.LayersTree.LabelEdit = true;
                node.BeginEdit();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 风格设置单击事件
        /// Style setting event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemStyle_Click(object sender, EventArgs e)
        {
            SetLayerStyle();
        }
        /// <summary>
        /// 右键菜单子项单击事件
        /// The click event of the context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_ItemClicked(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
                TreeNodeBase treeNode = layersControl.LayersTree.SelectedNode as TreeNodeBase;
                Layer layer = treeNode.GetData() as Layer;
                TreeIconTypes type = (TreeIconTypes)toolStripMenuItem.Tag;
                switch (type)
                {
                    case TreeIconTypes.Editable:
                        {
                            Boolean isItemChecked = ((toolStripMenuItem).CheckState == CheckState.Checked);

                            ((ToolStripMenuItem)toolStripMenuItem).CheckState = isItemChecked ? CheckState.Checked : CheckState.Unchecked;
                            layer.IsEditable = !isItemChecked;
                            activeMapControl.Map.Refresh();
                        }
                        break;
                    case TreeIconTypes.Visible:
                        {
                            Boolean isItemChecked = (toolStripMenuItem.CheckState == CheckState.Checked);

                            (toolStripMenuItem).CheckState = isItemChecked ? CheckState.Checked : CheckState.Unchecked;
                            layer.IsVisible = !isItemChecked;
                            activeMapControl.Map.Refresh();
                        }
                        break;
                    case TreeIconTypes.Snapable:
                        {
                            Boolean isItemChecked = ((toolStripMenuItem).CheckState == CheckState.Checked);

                            (toolStripMenuItem).CheckState = isItemChecked ? CheckState.Checked : CheckState.Unchecked;
                            layer.IsSnapable = !isItemChecked;
                            activeMapControl.Map.Refresh();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

    }
}
