namespace ProjectX.UI.Forms
{
    partial class AddDataset
    {
        /// <summary>
        /// 必需的设计器变量。
		/// Required designer variables
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
		/// Dispose all resources
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。True, if managed resources are disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows  


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDataset));
            this.datasetView = new System.Windows.Forms.TreeView();
            this.groupModify = new System.Windows.Forms.GroupBox();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.changeName = new System.Windows.Forms.Button();
            this.deleteCurrent = new System.Windows.Forms.Button();
            this.groupCreateNew = new System.Windows.Forms.GroupBox();
            this.createDatasetName = new System.Windows.Forms.TextBox();
            this.dataName = new System.Windows.Forms.Label();
            this.datasetTypeLabel = new System.Windows.Forms.Label();
            this.datasetTypeCombox = new System.Windows.Forms.ComboBox();
            this.createDataset = new System.Windows.Forms.Button();
            this.groupDatasets = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxShowDataSource = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupModify.SuspendLayout();
            this.groupCreateNew.SuspendLayout();
            this.groupDatasets.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datasetView
            // 
            this.datasetView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datasetView.FullRowSelect = true;
            this.datasetView.Location = new System.Drawing.Point(11, 40);
            this.datasetView.Margin = new System.Windows.Forms.Padding(5);
            this.datasetView.Name = "datasetView";
            this.datasetView.Size = new System.Drawing.Size(515, 613);
            this.datasetView.TabIndex = 0;
            // 
            // groupModify
            // 
            this.groupModify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupModify.Controls.Add(this.newNameTextBox);
            this.groupModify.Controls.Add(this.newNameLabel);
            this.groupModify.Controls.Add(this.changeName);
            this.groupModify.Location = new System.Drawing.Point(575, 260);
            this.groupModify.Margin = new System.Windows.Forms.Padding(5);
            this.groupModify.Name = "groupModify";
            this.groupModify.Padding = new System.Windows.Forms.Padding(5);
            this.groupModify.Size = new System.Drawing.Size(516, 264);
            this.groupModify.TabIndex = 1;
            this.groupModify.TabStop = false;
            this.groupModify.Text = "修改选中数据集";
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newNameTextBox.Location = new System.Drawing.Point(149, 91);
            this.newNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(300, 31);
            this.newNameTextBox.TabIndex = 3;
            // 
            // newNameLabel
            // 
            this.newNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(37, 99);
            this.newNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(68, 24);
            this.newNameLabel.TabIndex = 2;
            this.newNameLabel.Text = "新名称:";
            // 
            // changeName
            // 
            this.changeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changeName.Location = new System.Drawing.Point(268, 164);
            this.changeName.Margin = new System.Windows.Forms.Padding(5);
            this.changeName.Name = "changeName";
            this.changeName.Size = new System.Drawing.Size(183, 60);
            this.changeName.TabIndex = 1;
            this.changeName.Text = "重命名";
            this.changeName.UseVisualStyleBackColor = true;
            // 
            // deleteCurrent
            // 
            this.deleteCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteCurrent.Location = new System.Drawing.Point(40, 84);
            this.deleteCurrent.Margin = new System.Windows.Forms.Padding(5);
            this.deleteCurrent.Name = "deleteCurrent";
            this.deleteCurrent.Size = new System.Drawing.Size(259, 60);
            this.deleteCurrent.TabIndex = 0;
            this.deleteCurrent.Text = "删除选中";
            this.deleteCurrent.UseVisualStyleBackColor = true;
            // 
            // groupCreateNew
            // 
            this.groupCreateNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupCreateNew.Controls.Add(this.createDatasetName);
            this.groupCreateNew.Controls.Add(this.dataName);
            this.groupCreateNew.Controls.Add(this.datasetTypeLabel);
            this.groupCreateNew.Controls.Add(this.datasetTypeCombox);
            this.groupCreateNew.Controls.Add(this.createDataset);
            this.groupCreateNew.Location = new System.Drawing.Point(568, 564);
            this.groupCreateNew.Margin = new System.Windows.Forms.Padding(5);
            this.groupCreateNew.Name = "groupCreateNew";
            this.groupCreateNew.Padding = new System.Windows.Forms.Padding(5);
            this.groupCreateNew.Size = new System.Drawing.Size(516, 316);
            this.groupCreateNew.TabIndex = 2;
            this.groupCreateNew.TabStop = false;
            this.groupCreateNew.Text = "新建数据集";
            // 
            // createDatasetName
            // 
            this.createDatasetName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createDatasetName.Location = new System.Drawing.Point(172, 157);
            this.createDatasetName.Margin = new System.Windows.Forms.Padding(5);
            this.createDatasetName.Name = "createDatasetName";
            this.createDatasetName.Size = new System.Drawing.Size(300, 31);
            this.createDatasetName.TabIndex = 4;
            // 
            // dataName
            // 
            this.dataName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataName.AutoSize = true;
            this.dataName.Location = new System.Drawing.Point(32, 165);
            this.dataName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataName.Name = "dataName";
            this.dataName.Size = new System.Drawing.Size(104, 24);
            this.dataName.TabIndex = 3;
            this.dataName.Text = "数据集名称:";
            // 
            // datasetTypeLabel
            // 
            this.datasetTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datasetTypeLabel.AutoSize = true;
            this.datasetTypeLabel.Location = new System.Drawing.Point(29, 83);
            this.datasetTypeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.datasetTypeLabel.Name = "datasetTypeLabel";
            this.datasetTypeLabel.Size = new System.Drawing.Size(104, 24);
            this.datasetTypeLabel.TabIndex = 2;
            this.datasetTypeLabel.Text = "数据集类型:";
            // 
            // datasetTypeCombox
            // 
            this.datasetTypeCombox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datasetTypeCombox.FormattingEnabled = true;
            this.datasetTypeCombox.Location = new System.Drawing.Point(176, 76);
            this.datasetTypeCombox.Margin = new System.Windows.Forms.Padding(5);
            this.datasetTypeCombox.Name = "datasetTypeCombox";
            this.datasetTypeCombox.Size = new System.Drawing.Size(297, 32);
            this.datasetTypeCombox.TabIndex = 1;
            // 
            // createDataset
            // 
            this.createDataset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createDataset.Location = new System.Drawing.Point(341, 237);
            this.createDataset.Margin = new System.Windows.Forms.Padding(5);
            this.createDataset.Name = "createDataset";
            this.createDataset.Size = new System.Drawing.Size(136, 45);
            this.createDataset.TabIndex = 0;
            this.createDataset.Text = "创建";
            this.createDataset.UseVisualStyleBackColor = true;
            // 
            // groupDatasets
            // 
            this.groupDatasets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupDatasets.Controls.Add(this.datasetView);
            this.groupDatasets.Location = new System.Drawing.Point(16, 225);
            this.groupDatasets.Margin = new System.Windows.Forms.Padding(5);
            this.groupDatasets.Name = "groupDatasets";
            this.groupDatasets.Padding = new System.Windows.Forms.Padding(5);
            this.groupDatasets.Size = new System.Drawing.Size(540, 655);
            this.groupDatasets.TabIndex = 3;
            this.groupDatasets.TabStop = false;
            this.groupDatasets.Text = "数据集列表";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.deleteCurrent);
            this.groupBox1.Location = new System.Drawing.Point(575, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(516, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "删除选中数据集";
            // 
            // comboBoxShowDataSource
            // 
            this.comboBoxShowDataSource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxShowDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowDataSource.FormattingEnabled = true;
            this.comboBoxShowDataSource.Location = new System.Drawing.Point(61, 111);
            this.comboBoxShowDataSource.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxShowDataSource.Name = "comboBoxShowDataSource";
            this.comboBoxShowDataSource.Size = new System.Drawing.Size(459, 32);
            this.comboBoxShowDataSource.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Location = new System.Drawing.Point(27, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(516, 189);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择数据源";
            // 
            // AddDataset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 905);
            this.Controls.Add(this.comboBoxShowDataSource);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupDatasets);
            this.Controls.Add(this.groupCreateNew);
            this.Controls.Add(this.groupModify);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddDataset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据集管理";
            this.Load += new System.EventHandler(this.thisForm_Load);
            this.groupModify.ResumeLayout(false);
            this.groupModify.PerformLayout();
            this.groupCreateNew.ResumeLayout(false);
            this.groupCreateNew.PerformLayout();
            this.groupDatasets.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView datasetView;
        private System.Windows.Forms.GroupBox groupModify;
        private System.Windows.Forms.Button deleteCurrent;
        private System.Windows.Forms.GroupBox groupCreateNew;
        private System.Windows.Forms.GroupBox groupDatasets;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Label newNameLabel;
        private System.Windows.Forms.Button changeName;
        private System.Windows.Forms.TextBox createDatasetName;
        private System.Windows.Forms.Label dataName;
        private System.Windows.Forms.Label datasetTypeLabel;
        private System.Windows.Forms.ComboBox datasetTypeCombox;
        private System.Windows.Forms.Button createDataset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxShowDataSource;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}



