using System;
using System.IO;
using System.Windows.Forms;
using ProjectX.BLL;
using SuperMap.Data;

namespace projectX.UI.Forms
{
    public partial class CreateNewWorkspace : Form
    {
        private IWorkspaceManage workspaceManage;//工作空间管理类
        public CreateNewWorkspace(IWorkspaceManage workspaceManage)
        {
            InitializeComponent();
            this.workspaceManage = workspaceManage;
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                //创建对象
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
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
                string str = openFileDialog.FileName;
                //获取选择的路径
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show(openFileDialog.FileName);
                    //用户点击打开后，替换
                    try
                    {
                        textBoxFilename.Text = openFileDialog.FileName;
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
        /// 获取选择的工作空间类型
        /// Gets the type of selected workspace
        /// </summary>
        /// <param name="index">选中的索引号 Index</param>
        /// <returns>对应的类型 Type</returns>
        private WorkspaceType GetType(String type)
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
        /// 点击确认尝试创建新工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            bool isSucceed;
            if (textBoxFilename.Text!=null&& comboBoxGetTpye.Text!=null)
            {
                isSucceed = workspaceManage.CreateWorkspace(textBoxFilename.Text, GetType(comboBoxGetTpye.Text));
                if (isSucceed == true)
                {
                    this.Close();
                }
                else { MessageBox.Show("未创建成功！请检查您的输入是否有误！"); }
            }
        }
    }
}
