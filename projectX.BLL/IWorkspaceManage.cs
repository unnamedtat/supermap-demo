using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjectX.BLL
{
    public enum TabType
    {
        [Description("地图")]
        Map=0,
        [Description("场景")]
        Scene = 1,
        [Description("布局")]
        Layout=2,
    }
    public class SaveArgs
    {
        public String Name;
        public String XML;
        public TabType tabType;
        public SaveArgs(String Name, String XML, TabType tabType)
        {
            this.Name = Name;
            this.XML = XML;
            this.tabType = tabType;
        }
    }
    public interface IWorkspaceManage:INotifyPropertyChanged
    {
        Workspace workspace { get; }
        void SetWorkspace(WorkspaceConnectionInfo WorkspaceInfo);//程序更换工作空间
        void OpenWorkspace();//用户打开工作空间
        bool CreateWorkspace(String WorkspaceInfo, string workspaceType);//创建新工作空间
        bool Save();//保存工作空间
        bool SaveAs(WorkspaceConnectionInfo connectionInfo);//另存为工作空间
        void CreatMap(string name);
        void CreatLayout(string name);
    }
}
