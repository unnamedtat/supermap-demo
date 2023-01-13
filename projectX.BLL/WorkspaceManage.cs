using SuperMap.Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

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
        public void SetWorkspace(String WorkspaceInfo)
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
                    Filter = "SuperMap工作空间文件|*.sxw;*.smw;*.sxwu;*.smwu|SuperMap sxw文件|*.sxw|SuperMap smw文件|*.smw|SuperMap sxwu文件|*.sxwu|SuperMap smwu文件|*.smwu"
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
                        SetWorkspace(openFileDialog.FileName);
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
        public void CreatMap()
        {


        }
        /// <summary>
        /// 创建新工作空间
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public bool CreateWorkspace(String WorkspaceInfo, WorkspaceType workspaceType)
        {
            Boolean isSucceed=false;
            String result = String.Empty;
            try
            {
                workspace.Close();
                WorkspaceConnectionInfo m_connectionInfo = new WorkspaceConnectionInfo(WorkspaceInfo);

                isSucceed = workspace.Create(m_connectionInfo);
                //若创建成功，设定工作空间
                if (isSucceed == true) SetWorkspace(WorkspaceInfo);


            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return isSucceed;
        }
    }
}