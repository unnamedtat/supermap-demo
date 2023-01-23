using SuperMap.Data;
using SuperMap.Mapping;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using SuperMap.Layout;
using SuperMap.UI;
using ProjectX.BLL.Layout;

namespace ProjectX.BLL
{
    public class WorkspaceManage : IWorkspaceManage
    {

        private Workspace _workspace;

        public event PropertyChangedEventHandler PropertyChanged;

        public Workspace workspace { get { return _workspace; } }

        /// <summary>
        /// 设定工作空间
        /// </summary>
        /// <param name="WorkspaceInfo"></param>
        public void SetWorkspace(WorkspaceConnectionInfo WorkspaceInfo)
        {
            this._workspace = new Workspace();
            WorkspaceConnectionInfo coninfo = new WorkspaceConnectionInfo(WorkspaceInfo);
            this._workspace.Open(coninfo);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(workspace.ConnectionInfo.ToString()));
        }
        /// <summary>
        /// 打开工作空间
        /// </summary>
        public void OpenWorkspace()
        {
            try
            {
                //创建对象
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    //默认上次打开路径
                    RestoreDirectory = true,
                    //设置文本框标题
                    Title = "打开工作空间",
                    //对话框的初始目录
                    InitialDirectory = @"E:\",
                    //设置文件类型
                    Filter = "SuperMap工作空间文件|*.sxw;*.smw;*.sxwu;*.smwu|SuperMap sxw文件|*.sxw|SuperMap smw文件|*.smw|SuperMap sxwu文件|*.sxwu|SuperMap smwu文件|*.smwu",
                };
                string str = openFileDialog.FileName;
                //获取选择的路径
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(openFileDialog.FileName);
                    //用户点击打开后，替换
                    try
                    {
                        workspace.Close();
                        WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(openFileDialog.FileName);
                        SetWorkspace(connectionInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 创建map
        /// </summary>
        public void CreatMap(string name)
        {
            Map map = new Map();
            map.Name = this._workspace.Maps.GetAvailableMapName(name);
            this._workspace.Maps.Add(map.Name, map.ToXML());
        }
        /// <summary>
        /// 对当前工作空间进行保存操作
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            Boolean isSucceed = false;
            isSucceed = this._workspace.Save();
            return isSucceed;
        }
        /// <summary>
        /// 另存为工作空间
        /// </summary>
        /// <param name="WorkspaceInfo"></param>
        /// <param name="workspaceType"></param>
        /// <returns></returns>
        public bool SaveAs(WorkspaceConnectionInfo connectionInfo)
        {
            Boolean isSucceed = false;
            isSucceed = this._workspace.SaveAs(connectionInfo); 
            return isSucceed;
        }
        /// <summary>
        /// 创建新工作空间
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public bool CreateWorkspace(String WorkspaceInfo, string workspaceType)
        {
            Boolean isSucceed = false;
            if ((string)null == WorkspaceInfo)
            {
                return false;
            }
            try
            {
                workspace.Close();
                WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(WorkspaceInfo+"."+ workspaceType);
                isSucceed = workspace.Create(connectionInfo);
                this._workspace.Open(connectionInfo);

                //若创建成功，设定工作空间
                if (isSucceed == true)
                {
                    //！！！默认创建一张地图，避免工作空间为空
                    CreatMap("Untitled");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(workspace.ConnectionInfo.ToString()));
                    this._workspace.Save();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return isSucceed;
        }
        /// <summary>
        /// 获取选择的工作空间类型
        /// Gets the type of selected workspace
        /// </summary>
        /// <param name="index">选中的索引号 Index</param>
        /// <returns>对应的类型 Type</returns>
        public static WorkspaceType GetType(String type)
        {
            WorkspaceType result = WorkspaceType.Default;

            switch (type.ToUpper())
            {
                case "SMW":
                    {
                        result = WorkspaceType.SMW;
                    }
                    break;
                case "SXW":
                    {
                        result = WorkspaceType.SXW;
                    }
                    break;
                case "SMWU":
                    {
                        result = WorkspaceType.SMWU;
                    }
                    break;
                case "SXWU":
                    {
                        result = WorkspaceType.SXWU;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// 创建布局
        /// </summary>
        /// <param name="name"></param>
        public void CreatLayout(string name)
        {
            MapLayout mapLayout = new MapLayout(this.workspace);
            mapLayout.Name = this._workspace.Layouts.GetAvailableLayoutName(name);
            this.workspace.Layouts.Add(mapLayout.Name, mapLayout.ToXML());

        }
        /// <summary>
        /// 保存布局
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool SaveElements(SaveArgs saveArgs,Workspace workspace)
        {
            switch (saveArgs.tabType)
            {
                case TabType.Map:
                    return workspace.Maps.SetMapXML(saveArgs.Name, saveArgs.XML); 
                    break;
                case TabType.Scene:
                    break;
                case TabType.Layout:
                    return workspace.Layouts.SetLayoutXML(saveArgs.Name, saveArgs.XML);
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}