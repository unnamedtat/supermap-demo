using SuperMap.Data;
using SuperMap.UI;
using System.ComponentModel;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        public void WorkspaceChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshControls();
        }
        public void RefreshControls()
        {
            //避免连续打开地图导致程序异常     
            this.mapControl.Map.Close();
            this.mapControl.Map.Workspace = workspaceManage.workspace;
            this.workspaceControl.WorkspaceTree.Workspace = workspaceManage.workspace;
            if (workspaceManage.workspace.Maps.Count!=0)
            {
                this.mapControl.Map.Open(workspaceManage.workspace.Maps[0]);
            } 
            // 将地图关联到图层管理器，使其管理其中的地图图层
            this.layersControl.Map = this.mapControl.Map;
            this.mapControl.Map.Refresh();

            //调整mapcontrol的状态
            this.mapControl.Action = SuperMap.UI.Action.Pan;
            this.mapControl.Map.ViewEntire();

        }
    }
}
