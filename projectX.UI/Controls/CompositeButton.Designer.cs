namespace ProjectX.UI.Controls
{
    partial class CompositeButton
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(57, 47);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_label_Click);
            this.pictureBox.MouseEnter += new System.EventHandler(this.CompositeButton_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.CompositeButton_MouseLeave);
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label.Location = new System.Drawing.Point(0, 44);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 53);
            this.label.TabIndex = 1;
            this.label.Text = "label1";
            this.label.Click += new System.EventHandler(this.pictureBox_label_Click);
            this.label.MouseEnter += new System.EventHandler(this.CompositeButton_MouseEnter);
            this.label.MouseLeave += new System.EventHandler(this.CompositeButton_MouseLeave);
            // 
            // CompositeButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label);
            this.Name = "CompositeButton";
            this.Size = new System.Drawing.Size(57, 97);
            this.MouseEnter += new System.EventHandler(this.CompositeButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CompositeButton_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
    }
}
