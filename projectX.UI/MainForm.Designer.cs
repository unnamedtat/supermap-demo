
namespace ProjectX.UI
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerUD = new System.Windows.Forms.SplitContainer();
            this.splitContainerLR = new System.Windows.Forms.SplitContainer();
            this.splitContainerdata = new System.Windows.Forms.SplitContainer();
            this.splitContainerB = new System.Windows.Forms.SplitContainer();
            this.tabpageleft = new System.Windows.Forms.TabControl();
            this.tabPagedata = new System.Windows.Forms.TabPage();
            this.tabPageHawkeye = new System.Windows.Forms.TabPage();
            this.splitContainerHawkeye = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUD)).BeginInit();
            this.splitContainerUD.Panel2.SuspendLayout();
            this.splitContainerUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLR)).BeginInit();
            this.splitContainerLR.Panel1.SuspendLayout();
            this.splitContainerLR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerdata)).BeginInit();
            this.splitContainerdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerB)).BeginInit();
            this.splitContainerB.Panel1.SuspendLayout();
            this.splitContainerB.SuspendLayout();
            this.tabpageleft.SuspendLayout();
            this.tabPagedata.SuspendLayout();
            this.tabPageHawkeye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHawkeye)).BeginInit();
            this.splitContainerHawkeye.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerUD
            // 
            this.splitContainerUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUD.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUD.Name = "splitContainerUD";
            this.splitContainerUD.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerUD.Panel2
            // 
            this.splitContainerUD.Panel2.Controls.Add(this.splitContainerLR);
            this.splitContainerUD.Size = new System.Drawing.Size(1477, 745);
            this.splitContainerUD.SplitterDistance = 194;
            this.splitContainerUD.TabIndex = 0;
            // 
            // splitContainerLR
            // 
            this.splitContainerLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLR.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLR.Name = "splitContainerLR";
            // 
            // splitContainerLR.Panel1
            // 
            this.splitContainerLR.Panel1.Controls.Add(this.tabpageleft);
            this.splitContainerLR.Size = new System.Drawing.Size(1477, 547);
            this.splitContainerLR.SplitterDistance = 160;
            this.splitContainerLR.TabIndex = 0;
            // 
            // splitContainerdata
            // 
            this.splitContainerdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerdata.Location = new System.Drawing.Point(3, 3);
            this.splitContainerdata.Name = "splitContainerdata";
            this.splitContainerdata.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerdata.Size = new System.Drawing.Size(146, 509);
            this.splitContainerdata.SplitterDistance = 93;
            this.splitContainerdata.TabIndex = 0;
            // 
            // splitContainerB
            // 
            this.splitContainerB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerB.Location = new System.Drawing.Point(0, 0);
            this.splitContainerB.Name = "splitContainerB";
            this.splitContainerB.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerB.Panel1
            // 
            this.splitContainerB.Panel1.Controls.Add(this.splitContainerUD);
            this.splitContainerB.Size = new System.Drawing.Size(1477, 803);
            this.splitContainerB.SplitterDistance = 745;
            this.splitContainerB.TabIndex = 0;
            // 
            // tabpageleft
            // 
            this.tabpageleft.Controls.Add(this.tabPagedata);
            this.tabpageleft.Controls.Add(this.tabPageHawkeye);
            this.tabpageleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabpageleft.Location = new System.Drawing.Point(0, 0);
            this.tabpageleft.Name = "tabpageleft";
            this.tabpageleft.SelectedIndex = 0;
            this.tabpageleft.Size = new System.Drawing.Size(160, 547);
            this.tabpageleft.TabIndex = 0;
            // 
            // tabPagedata
            // 
            this.tabPagedata.Controls.Add(this.splitContainerdata);
            this.tabPagedata.Location = new System.Drawing.Point(4, 28);
            this.tabPagedata.Name = "tabPagedata";
            this.tabPagedata.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagedata.Size = new System.Drawing.Size(152, 515);
            this.tabPagedata.TabIndex = 0;
            this.tabPagedata.Text = "数据管理";
            this.tabPagedata.UseVisualStyleBackColor = true;
            // 
            // tabPageHawkeye
            // 
            this.tabPageHawkeye.Controls.Add(this.splitContainerHawkeye);
            this.tabPageHawkeye.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tabPageHawkeye.Location = new System.Drawing.Point(4, 28);
            this.tabPageHawkeye.Name = "tabPageHawkeye";
            this.tabPageHawkeye.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHawkeye.Size = new System.Drawing.Size(152, 515);
            this.tabPageHawkeye.TabIndex = 1;
            this.tabPageHawkeye.Text = "鹰眼视图";
            this.tabPageHawkeye.UseVisualStyleBackColor = true;
            // 
            // splitContainerHawkeye
            // 
            this.splitContainerHawkeye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerHawkeye.Location = new System.Drawing.Point(3, 3);
            this.splitContainerHawkeye.Name = "splitContainerHawkeye";
            this.splitContainerHawkeye.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerHawkeye.Size = new System.Drawing.Size(146, 509);
            this.splitContainerHawkeye.SplitterDistance = 93;
            this.splitContainerHawkeye.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 803);
            this.Controls.Add(this.splitContainerB);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Load);
            this.splitContainerUD.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUD)).EndInit();
            this.splitContainerUD.ResumeLayout(false);
            this.splitContainerLR.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLR)).EndInit();
            this.splitContainerLR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerdata)).EndInit();
            this.splitContainerdata.ResumeLayout(false);
            this.splitContainerB.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerB)).EndInit();
            this.splitContainerB.ResumeLayout(false);
            this.tabpageleft.ResumeLayout(false);
            this.tabPagedata.ResumeLayout(false);
            this.tabPageHawkeye.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerHawkeye)).EndInit();
            this.splitContainerHawkeye.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerUD;
        private System.Windows.Forms.SplitContainer splitContainerLR;
        private System.Windows.Forms.SplitContainer splitContainerdata;
        private System.Windows.Forms.SplitContainer splitContainerB;
        private System.Windows.Forms.TabControl tabpageleft;
        private System.Windows.Forms.TabPage tabPagedata;
        private System.Windows.Forms.TabPage tabPageHawkeye;
        private System.Windows.Forms.SplitContainer splitContainerHawkeye;
    }
}

