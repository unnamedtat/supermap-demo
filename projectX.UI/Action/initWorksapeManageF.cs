using projectX.UI.Forms;
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
            this.ButtonCreatWorkspace.Click += ButtonCreatWorkspace_Click;
        }

        private void ButtonCreatWorkspace_Click(object sender, EventArgs e)
        {
            CreateNewWorkspace createNewWorkspace = new CreateNewWorkspace(this.workspaceManage);
            createNewWorkspace.Show();
        }
    }
}
