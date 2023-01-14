using ProjectX.UI.Forms;
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

        //private void Datasources_Opened(object sender, SuperMap.Data.DatasourceOpenedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Boolean isSucceed = false;
            isSucceed=this.workspaceManage.Save();
            if (isSucceed == false) MessageBox.Show("保存失败！");
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace createNewWorkspace = new CreateNewWorkspace(this.workspaceManage,1);
            createNewWorkspace.Show();
        }

        private void ButtonCreatWorkspace_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace createNewWorkspace = new CreateNewWorkspace(this.workspaceManage,0);
            createNewWorkspace.Show();
        }
    }
}
