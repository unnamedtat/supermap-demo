///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------窗体无边框实现----------------------------
//
// 此部分用于实现无边框窗体的基本操作功能
//------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private readonly uint HTCAPTION = 2;
        private readonly uint SC_MOVE = 0xF010;
        private readonly uint WM_SYSCOMMAND = 0x112;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        private void Tittle_Load()
        {
            MouseDown += MyMouseMove;
            this.toolStripTop.MouseDown += MyMouseMove;
            this.splitContainerUD.Panel1.MouseDown += MyMouseMove;
        }
        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (DesignMode)
            {
                base.WndProc(ref m);
                return;
            }
            switch (m.Msg)
            {
                case (int)0x0083://WM_NCCALCSIZE:
                    ModifyFormSizeAndLcation();
                    break;
                case (int)0x0047://WM_WINDOWPOSCHANGED:
                    {
                        DefWndProc(ref m);
                        UpdateBounds();
                        var pos = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
                        SetWindowRegion(this, m.HWnd, 0, 0, pos.cx, pos.cy);
                        m.Result = new IntPtr(1);
                        break;
                    }
                case (int)0x0086://WM_NCACTIVATE:
                    {
                        WmNCActivate(ref m);
                        break;
                    }
                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
        }
        /// <summary>
        /// 将窗体的大小去掉原始标题和边框尺寸
        /// 同时当启动位置设置为屏幕中心时，对坐标进行校准
        /// </summary>
        private void ModifyFormSizeAndLcation()
        {
            var diffHeight = this.Height - this.ClientRectangle.Height;
            var diffWidth = this.Width - this.ClientRectangle.Width;
            if (diffHeight != 0 || diffWidth != 0)
            {
                var newWidth = this.Width - diffWidth;
                var newHeight = this.Height - diffHeight;
                if (this.StartPosition == FormStartPosition.CenterScreen)
                {
                    var screenWorkingArea = Screen.GetWorkingArea(this);
                    var centerX = screenWorkingArea.Width / 2 - newWidth / 2;
                    var centerY = screenWorkingArea.Height / 2 - newHeight / 2;
                    this.Location = new Point(centerX, centerY);
                }
                this.Size = new Size(newWidth, newHeight);
            }
        }
        private void WmNCActivate(ref Message msg)
        {
            if ((User32.GetWindowLong(this.Handle, -16) & (int)0x20000000) > 0)
            {
                DefWndProc(ref msg);
            }
            else
            {
                msg.Result = new IntPtr(1);
            }
        }
        static void SetWindowRegion(Form form, IntPtr hwnd, int left, int top, int right, int bottom)
        {
            var rgn = User32.CreateRectRgn(0, 0, 0, 0);
            var hrg = new HandleRef((object)form, rgn);
            User32.GetWindowRgn(hwnd, hrg.Handle);
            RECT box;
            User32.GetRgnBox(hrg.Handle, out box);
            if (box.left != left || box.top != top || box.right != right || box.bottom != bottom)
            {
                var hr = new HandleRef((object)form, User32.CreateRectRgn(left, top, right, bottom));
                User32.SetWindowRgn(hwnd, hr.Handle, User32.IsWindowVisible(hwnd));
            }
            User32.DeleteObject(rgn);
        }
    }
    class User32
    {
        [DllImport("user32.dll")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 Offset);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect,
    int nRightRect, int nBottomRect);
        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        [DllImport("gdi32.dll")]
        public static extern int GetRgnBox(IntPtr hrgn, out RECT lprc);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObj);
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct WINDOWPOS
    {
        internal IntPtr hwnd;
        internal IntPtr hWndInsertAfter;
        internal int x;
        internal int y;
        internal int cx;
        internal int cy;
        internal uint flags;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
