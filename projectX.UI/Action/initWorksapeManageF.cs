using projectX.UI.Forms;
using ProjectX.BLL;
using ProjectX.UI.Forms;
using SuperMap.Data;
using SuperMap.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm 
    {
        private void initWorkspaceManageForm()
        {
            this.ButtonSave.Click += ButtonSave_Click;
            this.ButtonCreatWorkspace.Click += ButtonCreatWorkspace_Click;
            this.ButtonSaveAs.Click += ButtonSaveAs_Click;
            this.ButtonAddDataSource.Click += ButtonAddDataSource_Click;
        }

        private void ButtonAddDataSource_Click(object sender, EventArgs e)
        {
            AddDataSource addDataSource = new AddDataSource(this.workspaceManage.workspace);
            //this.workspaceManage.workspace.Datasources.Opened += Datasources_Opened;
            //addDataSource.FormClosed += new FormClosedEventHandler((addsender, adde) => this.workspaceManage.workspace.Datasources.Opened -= Datasources_Opened);
            addDataSource.Show();
        }
        #region 工作空间
        /// <summary>
        /// 若存在打开的标签页，进行选择，若不存在，直接保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (utpMap.TabPages.Count != 0)
            {
                SelectSaveElements selectSaveElements = new SelectSaveElements(utpMap);
                selectSaveElements.Show();
                selectSaveElements.SaveElement += SelectSaveElements_SaveElement;
                selectSaveElements.SaveWorkspace += SelectSaveElements_SaveWorkspace;
            }
            else SaveWorkspace();
        }
        /// <summary>
        /// 保存工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSaveElements_SaveWorkspace(object sender, EventArgs e)
        {
            SaveWorkspace();
        }
        /// <summary>
        /// 保存工作空间中元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSaveElements_SaveElement(object sender, BLL.SaveArgs e)
        {
            WorkspaceManage.SaveElements(e,workspaceManage.workspace);
        }
        /// <summary>
        /// 保存工作空间的操作
        /// </summary>
        private void SaveWorkspace()
        {
            Boolean isSucceed = false;
            isSucceed = this.workspaceManage.Save();
            if (isSucceed == false) MessageBox.Show("保存失败！");
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace createNewWorkspace = new CreateNewWorkspace(this.workspaceManage,1);
            createNewWorkspace.SaveElementsEventHandler += SaveElements;
            createNewWorkspace.Show();
        }

        private void SaveElements(object sender, WorkspaceConnectionInfo connectionInfo)
        {
            Workspace workspace = new Workspace();
            workspace.Open(connectionInfo);
            foreach (TabPage tabPage in utpMap.TabPages)
            {
                Control control = tabPage.Controls[0];
                if (control is MapControl)
                {
                    MapControl mapControl = (MapControl)control;
                    SaveArgs saveArgs = new SaveArgs(mapControl.Map.Name, mapControl.Map.ToXML(), TabType.Map);
                    WorkspaceManage.SaveElements(saveArgs,workspace);
                }
                else if (control is MapLayoutControl)
                {
                    MapLayoutControl mapLayoutControl = (MapLayoutControl)control;
                    SaveArgs saveArgs = new SaveArgs(mapLayoutControl.MapLayout.Name, mapLayoutControl.MapLayout.ToXML(), TabType.Layout);
                    WorkspaceManage.SaveElements(saveArgs,workspace);
                }
            }
            workspace.Save();
            workspaceManage.SetWorkspace(connectionInfo);
        }

        /// <summary>
        /// 新建工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreatWorkspace_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace createNewWorkspace = new CreateNewWorkspace(this.workspaceManage,0);
            createNewWorkspace.Show();
        }
        #endregion

    }
}
