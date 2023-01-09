using System;
using System.Drawing;
using System.Windows.Forms;



namespace ProjectX.UI.Controls
{
    delegate void ButtonClickEvent();
    internal partial class CompositeButton : UserControl
    {
        public event ButtonClickEvent buttonClickEvent;
        private Delegate[] buttonClickEvents;
        /// <summary>
        /// 设置图片
        /// </summary>
        public Image ButtonImage
        {
            set { pictureBox.Image = value; }
            get { return pictureBox.Image; }
        }
        /// <summary>
        /// 设置按钮文字
        /// </summary>
        public string ButtonText
        {
            set { label.Text = value; }
            get { return label.Text; }
        }
        public CompositeButton()
        {
            InitializeComponent();
        }
        //private void InitClickMethod()
        //{
        //    ////按照Tag进行
        //    buttonClickEvent += cBOpenWorkspaceOnClick;
        //    //转换为委托集合
        //    buttonClickEvents = buttonClickEvent.GetInvocationList();
        //}
        /// <summary>
        /// 鼠标移过picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositeButton_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = SystemColors.ActiveBorder;
        }
        /// <summary>
        /// 鼠标离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositeButton_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = SystemColors.ButtonFace;
        }
        /// <summary>
        /// picturebox和label点击事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_label_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }

}
