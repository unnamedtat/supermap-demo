using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX.BLL
{
    public interface IWorkspaceManage
    {
        Workspace workspace { get; }
        void SetWorkspace(String WorkspaceInfo);//程序更换工作空间
        void OpenWorkspace();//用户打开工作空间
    }
}
