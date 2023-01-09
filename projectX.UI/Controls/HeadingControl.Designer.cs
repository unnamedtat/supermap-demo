namespace ProjectX.UI.Controls
{
    partial class HeadingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadingControl));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnFree = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnViewEntire = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPan = new System.Windows.Forms.ToolStripButton();
            this.tabControlHeading = new System.Windows.Forms.TabControl();
            this.tabPageBegin = new System.Windows.Forms.TabPage();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.tabPage3D = new System.Windows.Forms.TabPage();
            this.tabPageSpatialAnl = new System.Windows.Forms.TabPage();
            this.tabPageNetworkAnl = new System.Windows.Forms.TabPage();
            this.tabPageAuto = new System.Windows.Forms.TabPage();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.headingLayoutPanel1 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel2 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel3 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel4 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel5 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel6 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.headingLayoutPanel7 = new ProjectX.UI.Controls.HeadingLayoutPanel();
            this.toolStrip2.SuspendLayout();
            this.tabControlHeading.SuspendLayout();
            this.tabPageBegin.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPage3D.SuspendLayout();
            this.tabPageSpatialAnl.SuspendLayout();
            this.tabPageNetworkAnl.SuspendLayout();
            this.tabPageAuto.SuspendLayout();
            this.tabPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnZoomIn,
            this.toolStripBtnZoomOut,
            this.toolStripBtnFree,
            this.toolStripBtnViewEntire,
            this.toolStripBtnPan});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1146, 38);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripBtnZoomIn
            // 
            this.toolStripBtnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnZoomIn.Image")));
            this.toolStripBtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnZoomIn.Name = "toolStripBtnZoomIn";
            this.toolStripBtnZoomIn.Size = new System.Drawing.Size(34, 33);
            this.toolStripBtnZoomIn.Tag = "1";
            this.toolStripBtnZoomIn.Text = "放大";
            this.toolStripBtnZoomIn.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // toolStripBtnZoomOut
            // 
            this.toolStripBtnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnZoomOut.Image")));
            this.toolStripBtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnZoomOut.Name = "toolStripBtnZoomOut";
            this.toolStripBtnZoomOut.Size = new System.Drawing.Size(34, 33);
            this.toolStripBtnZoomOut.Tag = "2";
            this.toolStripBtnZoomOut.Text = "缩小";
            this.toolStripBtnZoomOut.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // toolStripBtnFree
            // 
            this.toolStripBtnFree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnFree.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFree.Image")));
            this.toolStripBtnFree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFree.Name = "toolStripBtnFree";
            this.toolStripBtnFree.Size = new System.Drawing.Size(34, 33);
            this.toolStripBtnFree.Tag = "3";
            this.toolStripBtnFree.Text = "自由缩放";
            this.toolStripBtnFree.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // toolStripBtnViewEntire
            // 
            this.toolStripBtnViewEntire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnViewEntire.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnViewEntire.Image")));
            this.toolStripBtnViewEntire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnViewEntire.Name = "toolStripBtnViewEntire";
            this.toolStripBtnViewEntire.Size = new System.Drawing.Size(34, 33);
            this.toolStripBtnViewEntire.Tag = "4";
            this.toolStripBtnViewEntire.Text = "整幅显示";
            this.toolStripBtnViewEntire.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // toolStripBtnPan
            // 
            this.toolStripBtnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPan.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPan.Image")));
            this.toolStripBtnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPan.Name = "toolStripBtnPan";
            this.toolStripBtnPan.Size = new System.Drawing.Size(34, 33);
            this.toolStripBtnPan.Tag = "5";
            this.toolStripBtnPan.Text = "浏览";
            this.toolStripBtnPan.Click += new System.EventHandler(this.toolStripBtn_Click);
            // 
            // tabControlHeading
            // 
            this.tabControlHeading.AllowDrop = true;
            this.tabControlHeading.Controls.Add(this.tabPageBegin);
            this.tabControlHeading.Controls.Add(this.tabPageData);
            this.tabControlHeading.Controls.Add(this.tabPage3D);
            this.tabControlHeading.Controls.Add(this.tabPageSpatialAnl);
            this.tabControlHeading.Controls.Add(this.tabPageNetworkAnl);
            this.tabControlHeading.Controls.Add(this.tabPageAuto);
            this.tabControlHeading.Controls.Add(this.tabPageView);
            this.tabControlHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHeading.Location = new System.Drawing.Point(0, 0);
            this.tabControlHeading.Name = "tabControlHeading";
            this.tabControlHeading.SelectedIndex = 0;
            this.tabControlHeading.Size = new System.Drawing.Size(1146, 212);
            this.tabControlHeading.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlHeading.TabIndex = 0;
            this.tabControlHeading.Tag = "";
            // 
            // tabPageBegin
            // 
            this.tabPageBegin.Controls.Add(this.headingLayoutPanel1);
            this.tabPageBegin.Location = new System.Drawing.Point(4, 28);
            this.tabPageBegin.Name = "tabPageBegin";
            this.tabPageBegin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBegin.Size = new System.Drawing.Size(1138, 180);
            this.tabPageBegin.TabIndex = 0;
            this.tabPageBegin.Text = "开始";
            this.tabPageBegin.UseVisualStyleBackColor = true;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.headingLayoutPanel2);
            this.tabPageData.Location = new System.Drawing.Point(4, 28);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(1138, 180);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "数据";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // tabPage3D
            // 
            this.tabPage3D.Controls.Add(this.headingLayoutPanel3);
            this.tabPage3D.Location = new System.Drawing.Point(4, 28);
            this.tabPage3D.Name = "tabPage3D";
            this.tabPage3D.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3D.Size = new System.Drawing.Size(1138, 180);
            this.tabPage3D.TabIndex = 2;
            this.tabPage3D.Text = "三维数据";
            this.tabPage3D.UseVisualStyleBackColor = true;
            // 
            // tabPageSpatialAnl
            // 
            this.tabPageSpatialAnl.Controls.Add(this.headingLayoutPanel4);
            this.tabPageSpatialAnl.Location = new System.Drawing.Point(4, 28);
            this.tabPageSpatialAnl.Name = "tabPageSpatialAnl";
            this.tabPageSpatialAnl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpatialAnl.Size = new System.Drawing.Size(1138, 180);
            this.tabPageSpatialAnl.TabIndex = 3;
            this.tabPageSpatialAnl.Text = "空间分析";
            this.tabPageSpatialAnl.UseVisualStyleBackColor = true;
            // 
            // tabPageNetworkAnl
            // 
            this.tabPageNetworkAnl.Controls.Add(this.headingLayoutPanel5);
            this.tabPageNetworkAnl.Location = new System.Drawing.Point(4, 28);
            this.tabPageNetworkAnl.Name = "tabPageNetworkAnl";
            this.tabPageNetworkAnl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNetworkAnl.Size = new System.Drawing.Size(1138, 180);
            this.tabPageNetworkAnl.TabIndex = 4;
            this.tabPageNetworkAnl.Text = "交通分析";
            this.tabPageNetworkAnl.UseVisualStyleBackColor = true;
            // 
            // tabPageAuto
            // 
            this.tabPageAuto.Controls.Add(this.headingLayoutPanel6);
            this.tabPageAuto.Location = new System.Drawing.Point(4, 28);
            this.tabPageAuto.Name = "tabPageAuto";
            this.tabPageAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuto.Size = new System.Drawing.Size(1138, 180);
            this.tabPageAuto.TabIndex = 5;
            this.tabPageAuto.Text = "处理自动化";
            this.tabPageAuto.UseVisualStyleBackColor = true;
            // 
            // tabPageView
            // 
            this.tabPageView.Controls.Add(this.headingLayoutPanel7);
            this.tabPageView.Location = new System.Drawing.Point(4, 28);
            this.tabPageView.Name = "tabPageView";
            this.tabPageView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageView.Size = new System.Drawing.Size(1138, 180);
            this.tabPageView.TabIndex = 6;
            this.tabPageView.Text = "视图";
            this.tabPageView.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlHeading);
            this.splitContainer1.Size = new System.Drawing.Size(1146, 243);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 2;
            // 
            // headingLayoutPanel1
            // 
            this.headingLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel1.Name = "headingLayoutPanel1";
            this.headingLayoutPanel1.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel1.TabIndex = 0;
            // 
            // headingLayoutPanel2
            // 
            this.headingLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel2.Name = "headingLayoutPanel2";
            this.headingLayoutPanel2.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel2.TabIndex = 1;
            // 
            // headingLayoutPanel3
            // 
            this.headingLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel3.Name = "headingLayoutPanel3";
            this.headingLayoutPanel3.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel3.TabIndex = 1;
            // 
            // headingLayoutPanel4
            // 
            this.headingLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel4.Name = "headingLayoutPanel4";
            this.headingLayoutPanel4.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel4.TabIndex = 1;
            // 
            // headingLayoutPanel5
            // 
            this.headingLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel5.Name = "headingLayoutPanel5";
            this.headingLayoutPanel5.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel5.TabIndex = 1;
            // 
            // headingLayoutPanel6
            // 
            this.headingLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel6.Name = "headingLayoutPanel6";
            this.headingLayoutPanel6.Size = new System.Drawing.Size(1132, 174);
            this.headingLayoutPanel6.TabIndex = 1;
            // 
            // headingLayoutPanel7
            // 
            this.headingLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.headingLayoutPanel7.Name = "headingLayoutPanel7";
            this.headingLayoutPanel7.Size = new System.Drawing.Size(1132, 164);
            this.headingLayoutPanel7.TabIndex = 1;
            // 
            // HeadingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "HeadingControl";
            this.Size = new System.Drawing.Size(1146, 243);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControlHeading.ResumeLayout(false);
            this.tabPageBegin.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPage3D.ResumeLayout(false);
            this.tabPageSpatialAnl.ResumeLayout(false);
            this.tabPageNetworkAnl.ResumeLayout(false);
            this.tabPageAuto.ResumeLayout(false);
            this.tabPageView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlHeading;
        private System.Windows.Forms.TabPage tabPageBegin;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel1;
        private System.Windows.Forms.TabPage tabPageData;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage3D;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel3;
        private System.Windows.Forms.TabPage tabPageSpatialAnl;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel4;
        private System.Windows.Forms.TabPage tabPageNetworkAnl;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel5;
        private System.Windows.Forms.TabPage tabPageAuto;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel6;
        private System.Windows.Forms.TabPage tabPageView;
        private ProjectX.UI.Controls.HeadingLayoutPanel headingLayoutPanel7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripBtnZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripBtnZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripBtnFree;
        private System.Windows.Forms.ToolStripButton toolStripBtnViewEntire;
        private System.Windows.Forms.ToolStripButton toolStripBtnPan;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
