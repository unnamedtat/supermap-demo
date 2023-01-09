using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace ProjectX.UI.Controls
{
    /// <summary>
    /// 自定义heading面板
    /// </summary>
    class HeadingLayoutPanel : Panel
    {
        UserLayoutEditor editor = new UserLayoutEditor();
        public override LayoutEngine LayoutEngine
        {
            get { return editor; }
        }
    }
    /// <summary>
    /// 布局器
    /// </summary>
    class UserLayoutEditor : LayoutEngine
    {
        public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
        {
            HeadingLayoutPanel usercontainer = (HeadingLayoutPanel)container;
            int width = usercontainer.Width;
            int height = usercontainer.Height;
            int left = usercontainer.Padding.Left;
            int right = usercontainer.Padding.Right;
            int top = usercontainer.Padding.Top;
            int button = usercontainer.Padding.Bottom;
            width -= (left + right);
            height -= (top + button);
            int gap = 2;
            foreach (Control control in usercontainer.Controls)
            {
                control.Location = new Point(left, top);
                control.Size = new Size(100, control.PreferredSize.Height);
                left += 120;
                left += gap;
            }
            return base.Layout(container, layoutEventArgs);
        }
    }
}
