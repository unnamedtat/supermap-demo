using System;
using System.IO;
using System.Windows.Forms;
using ProjectX.BLL;
using SuperMap.Data;

namespace ProjectX.UI.Forms
{
    public partial class CreateNewWorkspace : Form
    {
        int Action;
        private IWorkspaceManage workspaceManage;//工作空间管理类
        public CreateNewWorkspace(IWorkspaceManage workspaceManage,int Action)
        {
            InitializeComponent();
            this.Action = Action;
            if (Action == 1) this.Text = "另存为工作空间";
            this.workspaceManage = workspaceManage;
        }
        /// <summary>
        /// 创建工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                //创建对象
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = "siling-Data",
                    //默认上次打开路径
                    RestoreDirectory = true,
                    //设置文本框标题
                    Title = "选择路径",
                    //对话框的初始目录
                    //InitialDirectory = @"E:\",
                    InitialDirectory = Directory.GetCurrentDirectory(),
                //设置文件类型
                Filter = "所有文件|*.*|SuperMap工作空间文件|*.sxw;*.smw;*.sxwu;*.smwu|SuperMap sxw文件|*.sxw|SuperMap smw文件|*.smw|SuperMap sxwu文件|*.sxwu|SuperMap smwu文件|*.smwu"
                };
                string str = saveFileDialog.FileName;
                //获取选择的路径
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(openFileDialog.FileName);
                    //用户点击打开后，替换
                    try
                    {
                        textBoxFilename.Text = saveFileDialog.FileName;
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
        /// 点击确认尝试创建新工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            bool isSucceed=false;
            if (textBoxFilename.Text!=null&& comboBoxGetTpye.Text!=null)
            {
                if (Action == 0)
                    isSucceed = workspaceManage.CreateWorkspace(textBoxFilename.Text, WorkspaceManage.GetType(comboBoxGetTpye.Text));
                else if(Action == 1)
                    isSucceed = workspaceManage.SaveAs(textBoxFilename.Text, WorkspaceManage.GetType(comboBoxGetTpye.Text));
                if (isSucceed == true)
                {
                    this.Close();
                }
                else { MessageBox.Show("未创建成功！请检查您的输入是否有误！"); }
            }
        }
    }
}
