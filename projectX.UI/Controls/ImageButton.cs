using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectX.UI.Controls
{
    public partial class ImageButton : Button
    {
        private Image buttonImage;
        private string buttonText;
        private ButtonType buttontype;
        /// <summary>
        /// 设置按钮类型
        /// </summary>
        public ButtonType SetButtonType
        {
            get
            {
                return buttontype;
            }
            set
            {
                this.buttontype = value;
            }
        }
        public enum ButtonType {
            [Description("正常")]
            normal=0,
            [Description("小")]
            small=1,
        }
        /// <summary>
        /// 设置图片
        /// </summary>
        public Image ButtonImage
        {
            set { this.buttonImage = value; }
            get { return this.buttonImage; }
        }
        /// <summary>
        /// 设置按钮文字
        /// </summary>
        public string ButtonText
        {
            set { this.buttonText = value; }
            get { return this.buttonText; }
        }
        public ImageButton()
        {
            this.SetButtonType = ButtonType.normal;
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            PointF ImageLocation; SizeF imageSize; RectangleF imageBondingBox; PointF TextLocation;
            Graphics g = pevent.Graphics;
            if (buttontype == ButtonType.normal)
            {
                ImageLocation = new PointF((float)(this.Bounds.Size.Width * 0.1), (float)(this.Bounds.Size.Width * 0.1));
                imageSize = new SizeF((float)(this.Bounds.Size.Width * 0.8), (float)(this.Bounds.Size.Width * 0.8));
                TextLocation = new PointF((float)(this.Bounds.Size.Width * 0.05), (float)(this.Bounds.Size.Width * 0.9));
            }
            else
            {
                ImageLocation = new PointF((float)(this.Bounds.Size.Height * 0.1), (float)(this.Bounds.Size.Height * 0.1));
                imageSize = new SizeF((float)(this.Bounds.Size.Height * 0.8), (float)(this.Bounds.Size.Height * 0.8));
                TextLocation = new PointF((float)(this.Bounds.Size.Height * 1), (float)(this.Bounds.Size.Width * 0.1));
            }
            imageBondingBox = new RectangleF(ImageLocation, imageSize);
            if (this.buttonImage != null)
                g.DrawImage(this.buttonImage, imageBondingBox);
            if (this.buttonText != null)
                g.DrawString(this.buttonText, this.Font, Brushes.Black, TextLocation);
        }
    }
}
