namespace ProjectX.UI.Forms
{
    partial class CreateNewWorkspace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewWorkspace));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.comboBoxGetTpye = new System.Windows.Forms.ComboBox();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "工程路径";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "工程类型";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFilename.Location = new System.Drawing.Point(194, 96);
            this.textBoxFilename.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(548, 31);
            this.textBoxFilename.TabIndex = 2;
            // 
            // comboBoxGetTpye
            // 
            this.comboBoxGetTpye.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxGetTpye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGetTpye.FormattingEnabled = true;
            this.comboBoxGetTpye.Items.AddRange(new object[] {
            "smwu",
            "sxwu"});
            this.comboBoxGetTpye.Location = new System.Drawing.Point(194, 273);
            this.comboBoxGetTpye.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxGetTpye.Name = "comboBoxGetTpye";
            this.comboBoxGetTpye.Size = new System.Drawing.Size(548, 32);
            this.comboBoxGetTpye.TabIndex = 3;
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonChooseFile.Location = new System.Drawing.Point(777, 96);
            this.buttonChooseFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(123, 37);
            this.buttonChooseFile.TabIndex = 4;
            this.buttonChooseFile.Text = "浏览";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConfirm.Location = new System.Drawing.Point(390, 407);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(127, 57);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // CreateNewWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(927, 518);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonChooseFile);
            this.Controls.Add(this.comboBoxGetTpye);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateNewWorkspace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建新工作空间";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.ComboBox comboBoxGetTpye;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.Button buttonConfirm;
    }
}