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

namespace projectX.UI.Controls
{
    public partial class ImageButton : Button
    {
        private Image buttonImage;
        private string buttonText;
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
            InitializeComponent();
            InitialImageButton();
        }

        private void InitialImageButton()
        {
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            //Rectangle buttonBBondingBox = new Rectangle(this.Bounds.Location, this.Size);
            PointF ImageLocation = new PointF((float)(this.Bounds.Size.Width * 0.1), (float)(this.Bounds.Size.Width * 0.1));
            SizeF imageSize = new SizeF((float)(this.Bounds.Size.Width * 0.8), (float)(this.Bounds.Size.Width * 0.8));
            RectangleF imageBondingBox = new RectangleF(ImageLocation, imageSize);
            Graphics g = pevent.Graphics;
            PointF TextLocation = new PointF((float)(this.Bounds.Size.Width * 0.05), (float)(this.Bounds.Size.Width * 0.9));
            if (this.buttonImage!=null)
            g.DrawImage(this.buttonImage,imageBondingBox);
            if (this.buttonText != null)
               g.DrawString(this.buttonText, this.Font, Brushes.Black, TextLocation);
        }
    }
}
