namespace project.controls.newPanelControls
{
    partial class OpenFileControl
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
            this.axisButton1 = new project.controls.newPanelControls.AxisButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.axisButton2 = new project.controls.newPanelControls.AxisButton();
            this.axisButton3 = new project.controls.newPanelControls.AxisButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axisButton1
            // 
            this.axisButton1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.axisButton1.ButtonText = "打开文件型工作空间";
            this.axisButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisButton1.Location = new System.Drawing.Point(3, 3);
            this.axisButton1.Name = "axisButton1";
            this.axisButton1.Size = new System.Drawing.Size(316, 57);
            this.axisButton1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.axisButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.axisButton2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.axisButton3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(322, 189);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // axisButton2
            // 
            this.axisButton2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.axisButton2.ButtonText = "label1";
            this.axisButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisButton2.Location = new System.Drawing.Point(3, 66);
            this.axisButton2.Name = "axisButton2";
            this.axisButton2.Size = new System.Drawing.Size(316, 57);
            this.axisButton2.TabIndex = 1;
            // 
            // axisButton3
            // 
            this.axisButton3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.axisButton3.ButtonText = "label1";
            this.axisButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisButton3.Location = new System.Drawing.Point(3, 129);
            this.axisButton3.Name = "axisButton3";
            this.axisButton3.Size = new System.Drawing.Size(316, 57);
            this.axisButton3.TabIndex = 2;
            this.axisButton3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.axisButton3_MouseClick);
            // 
            // OpenFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OpenFileControl";
            this.Size = new System.Drawing.Size(322, 189);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxisButton axisButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxisButton axisButton2;
        private AxisButton axisButton3;
    }
}
