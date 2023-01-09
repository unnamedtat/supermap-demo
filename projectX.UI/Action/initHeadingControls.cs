using ProjectX.BLL;
using ProjectX.UI.Controls;
using System;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        public event Action<string> mapModeChange;
        Delegate[] buttonDelegate;
        /// <summary>
        /// 设置按钮
        /// </summary>
        public void initbtn()
        {
            int buttonNum = 5;
            //初始化tabpage1的compositebutton
            CompositeButton[] compositeButtons = new CompositeButton[buttonNum];
            string[] cpbtnTEXT = { "打开工作空间", "打开数据库型工作空间", "打开数据源", "新建地图", "数据导入" };
            //依次绑定事件点击方法,只绑定了一个
            Action<object, System.EventArgs> action = OpenFilebtnOnclick;
            buttonDelegate = action.GetInvocationList();
            for (int i = 0; i < buttonNum; i++)
            {
                compositeButtons[i] = new CompositeButton();
                compositeButtons[i].ButtonText = cpbtnTEXT[i];
                compositeButtons[i].Tag = i + 1;
                compositeButtons[i].Click += ButtonOnclick;
                this.headingLayoutPanel1.Controls.Add(compositeButtons[i]);
            }
        }
        /// <summary>
        /// 按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOnclick(object sender, System.EventArgs e)
        {
            CompositeButton button = (CompositeButton)sender;
            /*根据button.Tag中序号选择委托列表数组中相应方法*/
            Action<object, System.EventArgs> method = (Action<object, System.EventArgs>)buttonDelegate[Convert.ToInt16(button.Tag) - 1];

            /*执行*/
            method(sender, e);
        }

        /// <summary>
        /// 点击打开工作空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFilebtnOnclick(object sender, System.EventArgs e)
        {
            this.workspaceManage.OpenWorkspace();
        }

        private void toolStripBtn_Click(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            mapModeChange?.Invoke(button.Tag.ToString());
        }
    }

}
