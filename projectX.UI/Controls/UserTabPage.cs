using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectX.UI.Controls
{
    public partial class UserTabPage : TabControl
    {
        public UserTabPage()
        {
            InitializeComponent();
            initUserTabPage();
        }


        private void initUserTabPage()
        {
            //切换绘制模式为由父窗口绘制
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;
            this.MouseDown += UserTabPage_MouseDown;
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 关闭Tabpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserTabPage_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle r = this.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 20, r.Top + 7, 15, 15);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("是否关闭该页面", "关闭确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 绘制tabpage
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            Color recColor = e.State == DrawItemState.Selected ? Color.Red : Color.FromArgb(255, 125, 125);
            //画一个矩形框
            Rectangle closeButton = new Rectangle(e.Bounds.Right - 20, e.Bounds.Top + 7, 15, 15);
            using (Pen penDrawRec=new Pen(recColor))
            {
                e.Graphics.DrawRectangle(penDrawRec, closeButton);
            }
            //填充矩形框
            using (Brush b=new SolidBrush(recColor))
            {
                e.Graphics.FillRectangle(b, closeButton);
            }
            //画关闭符号
            using (Pen penDrawLine=new Pen(Color.White))
            {
                Point p1 = new Point(closeButton.X + 3, closeButton.Y + 3);
                Point p2 = new Point(closeButton.X + closeButton.Width - 3, closeButton.Y + closeButton.Height - 3) ;
                e.Graphics.DrawLine(penDrawLine, p1, p2);
                Point p3 = new Point(closeButton.X + 3, closeButton.Y + closeButton.Height - 3);
                Point p4 = new Point(closeButton.X + closeButton.Width - 3, closeButton.Y + 3);
                e.Graphics.DrawLine(penDrawLine, p3, p4);
            }
            e.Graphics.DrawString(this.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }
    }
}
