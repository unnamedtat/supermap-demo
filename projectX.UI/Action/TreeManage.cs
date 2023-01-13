using SuperMap.Data;
using SuperMap.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private int viewIndex;//指示当前活跃地图控件类型
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

                            if (layersControl.Map != null)
                            {
                                TabPage containTapPage = checkMapIsInUtp(mapName);
                                //若已存在，不添加,改变激活map
                                if (containTapPage != null) {
                                    activeMapControl = (MapControl)containTapPage.Controls[0];
                                    utpMap.SelectedTab = containTapPage;
                                }
                                else AddMapAndTab();
                                RefreshMainMapControl(mapName);
                                RefreshEagZoomControls(mapName);
                                ChangeMap();
                                utpMap.Selected += UtpMap_SelectedIndexChanged;//重新挂接
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
        /// 查看地图是否重复加入
        /// </summary>
        /// <param name="mapName"></param>
        /// <returns></returns>
        private TabPage checkMapIsInUtp(string mapName)
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
        /// The click event of the context menu when right click the workspace tree
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
                if (SuperMap.Data.Environment.CurrentCulture == "zh-CN")
                {
                    toolStripMenuItemOpenMap.Text = "打开地图";
                }
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
        }
    }
}
