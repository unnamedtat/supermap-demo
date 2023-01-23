namespace ProjectX.UI.Forms
{
    partial class AddDataSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDataSource));
            this.operationTabCtrl = new System.Windows.Forms.TabControl();
            this.openPage = new System.Windows.Forms.TabPage();
            this.openFilePanel = new System.Windows.Forms.Panel();
            this.openKeyTable = new System.Windows.Forms.TextBox();
            this.openKeyText = new System.Windows.Forms.Label();
            this.openFileSource = new System.Windows.Forms.Button();
            this.openPathLabel = new System.Windows.Forms.Label();
            this.openFolderBrowser = new System.Windows.Forms.Button();
            this.openPathText = new System.Windows.Forms.TextBox();
            this.openDatabasePanel = new System.Windows.Forms.Panel();
            this.openDatabaseSource = new System.Windows.Forms.Button();
            this.openPasswordText = new System.Windows.Forms.TextBox();
            this.openUserNameText = new System.Windows.Forms.TextBox();
            this.openDatabaseText = new System.Windows.Forms.TextBox();
            this.openServerText = new System.Windows.Forms.TextBox();
            this.openPasswordLabel = new System.Windows.Forms.Label();
            this.openUserNameLabel = new System.Windows.Forms.Label();
            this.openDatabaseLabel = new System.Windows.Forms.Label();
            this.openServerLabel = new System.Windows.Forms.Label();
            this.openEngineTypeCombox = new System.Windows.Forms.ComboBox();
            this.openEngineTypeLabel = new System.Windows.Forms.Label();
            this.createPage = new System.Windows.Forms.TabPage();
            this.createFileSourcePanel = new System.Windows.Forms.Panel();
            this.createSourceNameLabel = new System.Windows.Forms.Label();
            this.createSourceText = new System.Windows.Forms.TextBox();
            this.createFileSource = new System.Windows.Forms.Button();
            this.createFilePathLabel = new System.Windows.Forms.Label();
            this.createFileFolderBrowser = new System.Windows.Forms.Button();
            this.createFilePathText = new System.Windows.Forms.TextBox();
            this.createEngineTypeCombox = new System.Windows.Forms.ComboBox();
            this.createTypeLable = new System.Windows.Forms.Label();
            this.createDatabasePanel = new System.Windows.Forms.Panel();
            this.createDatabaseSource = new System.Windows.Forms.Button();
            this.createPasswordText = new System.Windows.Forms.TextBox();
            this.createUserText = new System.Windows.Forms.TextBox();
            this.createDatabaseText = new System.Windows.Forms.TextBox();
            this.createServerText = new System.Windows.Forms.TextBox();
            this.createPasswordLabel = new System.Windows.Forms.Label();
            this.createUserLabel = new System.Windows.Forms.Label();
            this.createDatabaseLabel = new System.Windows.Forms.Label();
            this.createServerLabel = new System.Windows.Forms.Label();
            this.datasourceGroup = new System.Windows.Forms.GroupBox();
            this.datasourceText = new System.Windows.Forms.RichTextBox();
            this.operationTabCtrl.SuspendLayout();
            this.openPage.SuspendLayout();
            this.openFilePanel.SuspendLayout();
            this.openDatabasePanel.SuspendLayout();
            this.createPage.SuspendLayout();
            this.createFileSourcePanel.SuspendLayout();
            this.createDatabasePanel.SuspendLayout();
            this.datasourceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationTabCtrl
            // 
            this.operationTabCtrl.Controls.Add(this.openPage);
            this.operationTabCtrl.Controls.Add(this.createPage);
            this.operationTabCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.operationTabCtrl.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.operationTabCtrl.Name = "operationTabCtrl";
            this.operationTabCtrl.SelectedIndex = 0;
            this.operationTabCtrl.Size = new System.Drawing.Size(572, 1152);
            this.operationTabCtrl.TabIndex = 0;
            // 
            // openPage
            // 
            this.openPage.Controls.Add(this.openFilePanel);
            this.openPage.Controls.Add(this.openDatabasePanel);
            this.openPage.Controls.Add(this.openEngineTypeCombox);
            this.openPage.Controls.Add(this.openEngineTypeLabel);
            this.openPage.Location = new System.Drawing.Point(4, 33);
            this.openPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openPage.Name = "openPage";
            this.openPage.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openPage.Size = new System.Drawing.Size(564, 1115);
            this.openPage.TabIndex = 1;
            this.openPage.Text = "打开";
            this.openPage.UseVisualStyleBackColor = true;
            // 
            // openFilePanel
            // 
            this.openFilePanel.Controls.Add(this.openKeyTable);
            this.openFilePanel.Controls.Add(this.openKeyText);
            this.openFilePanel.Controls.Add(this.openFileSource);
            this.openFilePanel.Controls.Add(this.openPathLabel);
            this.openFilePanel.Controls.Add(this.openFolderBrowser);
            this.openFilePanel.Controls.Add(this.openPathText);
            this.openFilePanel.Location = new System.Drawing.Point(0, 167);
            this.openFilePanel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openFilePanel.Name = "openFilePanel";
            this.openFilePanel.Size = new System.Drawing.Size(546, 264);
            this.openFilePanel.TabIndex = 0;
            // 
            // openKeyTable
            // 
            this.openKeyTable.Location = new System.Drawing.Point(144, 97);
            this.openKeyTable.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openKeyTable.Name = "openKeyTable";
            this.openKeyTable.Size = new System.Drawing.Size(253, 31);
            this.openKeyTable.TabIndex = 35;
            // 
            // openKeyText
            // 
            this.openKeyText.Location = new System.Drawing.Point(40, 99);
            this.openKeyText.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openKeyText.Name = "openKeyText";
            this.openKeyText.Size = new System.Drawing.Size(109, 24);
            this.openKeyText.TabIndex = 34;
            this.openKeyText.Text = "密    钥:";
            // 
            // openFileSource
            // 
            this.openFileSource.Location = new System.Drawing.Point(422, 89);
            this.openFileSource.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openFileSource.Name = "openFileSource";
            this.openFileSource.Size = new System.Drawing.Size(100, 45);
            this.openFileSource.TabIndex = 33;
            this.openFileSource.Text = "打开";
            this.openFileSource.UseVisualStyleBackColor = true;
            // 
            // openPathLabel
            // 
            this.openPathLabel.AutoSize = true;
            this.openPathLabel.Location = new System.Drawing.Point(40, 25);
            this.openPathLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openPathLabel.Name = "openPathLabel";
            this.openPathLabel.Size = new System.Drawing.Size(70, 24);
            this.openPathLabel.TabIndex = 30;
            this.openPathLabel.Text = "路    径:";
            // 
            // openFolderBrowser
            // 
            this.openFolderBrowser.Location = new System.Drawing.Point(422, 19);
            this.openFolderBrowser.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openFolderBrowser.Name = "openFolderBrowser";
            this.openFolderBrowser.Size = new System.Drawing.Size(100, 45);
            this.openFolderBrowser.TabIndex = 32;
            this.openFolderBrowser.Text = "浏览";
            this.openFolderBrowser.UseVisualStyleBackColor = true;
            // 
            // openPathText
            // 
            this.openPathText.Location = new System.Drawing.Point(149, 19);
            this.openPathText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openPathText.Name = "openPathText";
            this.openPathText.Size = new System.Drawing.Size(253, 31);
            this.openPathText.TabIndex = 31;
            // 
            // openDatabasePanel
            // 
            this.openDatabasePanel.Controls.Add(this.openDatabaseSource);
            this.openDatabasePanel.Controls.Add(this.openPasswordText);
            this.openDatabasePanel.Controls.Add(this.openUserNameText);
            this.openDatabasePanel.Controls.Add(this.openDatabaseText);
            this.openDatabasePanel.Controls.Add(this.openServerText);
            this.openDatabasePanel.Controls.Add(this.openPasswordLabel);
            this.openDatabasePanel.Controls.Add(this.openUserNameLabel);
            this.openDatabasePanel.Controls.Add(this.openDatabaseLabel);
            this.openDatabasePanel.Controls.Add(this.openServerLabel);
            this.openDatabasePanel.Location = new System.Drawing.Point(0, 600);
            this.openDatabasePanel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openDatabasePanel.Name = "openDatabasePanel";
            this.openDatabasePanel.Size = new System.Drawing.Size(546, 439);
            this.openDatabasePanel.TabIndex = 20;
            this.openDatabasePanel.Visible = false;
            // 
            // openDatabaseSource
            // 
            this.openDatabaseSource.Location = new System.Drawing.Point(422, 271);
            this.openDatabaseSource.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openDatabaseSource.Name = "openDatabaseSource";
            this.openDatabaseSource.Size = new System.Drawing.Size(100, 45);
            this.openDatabaseSource.TabIndex = 25;
            this.openDatabaseSource.Text = "打开";
            this.openDatabaseSource.UseVisualStyleBackColor = true;
            // 
            // openPasswordText
            // 
            this.openPasswordText.Location = new System.Drawing.Point(154, 200);
            this.openPasswordText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openPasswordText.Name = "openPasswordText";
            this.openPasswordText.Size = new System.Drawing.Size(366, 31);
            this.openPasswordText.TabIndex = 24;
            // 
            // openUserNameText
            // 
            this.openUserNameText.Location = new System.Drawing.Point(154, 141);
            this.openUserNameText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openUserNameText.Name = "openUserNameText";
            this.openUserNameText.Size = new System.Drawing.Size(366, 31);
            this.openUserNameText.TabIndex = 23;
            // 
            // openDatabaseText
            // 
            this.openDatabaseText.Location = new System.Drawing.Point(155, 80);
            this.openDatabaseText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openDatabaseText.Name = "openDatabaseText";
            this.openDatabaseText.Size = new System.Drawing.Size(363, 31);
            this.openDatabaseText.TabIndex = 22;
            // 
            // openServerText
            // 
            this.openServerText.Location = new System.Drawing.Point(154, 19);
            this.openServerText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openServerText.Name = "openServerText";
            this.openServerText.Size = new System.Drawing.Size(366, 31);
            this.openServerText.TabIndex = 21;
            // 
            // openPasswordLabel
            // 
            this.openPasswordLabel.AutoSize = true;
            this.openPasswordLabel.Location = new System.Drawing.Point(40, 207);
            this.openPasswordLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openPasswordLabel.Name = "openPasswordLabel";
            this.openPasswordLabel.Size = new System.Drawing.Size(70, 24);
            this.openPasswordLabel.TabIndex = 0;
            this.openPasswordLabel.Text = "密    码:";
            // 
            // openUserNameLabel
            // 
            this.openUserNameLabel.AutoSize = true;
            this.openUserNameLabel.Location = new System.Drawing.Point(40, 145);
            this.openUserNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openUserNameLabel.Name = "openUserNameLabel";
            this.openUserNameLabel.Size = new System.Drawing.Size(78, 24);
            this.openUserNameLabel.TabIndex = 0;
            this.openUserNameLabel.Text = "用 户 名:";
            // 
            // openDatabaseLabel
            // 
            this.openDatabaseLabel.AutoSize = true;
            this.openDatabaseLabel.Location = new System.Drawing.Point(40, 87);
            this.openDatabaseLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openDatabaseLabel.Name = "openDatabaseLabel";
            this.openDatabaseLabel.Size = new System.Drawing.Size(86, 24);
            this.openDatabaseLabel.TabIndex = 0;
            this.openDatabaseLabel.Text = "数据库名:";
            // 
            // openServerLabel
            // 
            this.openServerLabel.AutoSize = true;
            this.openServerLabel.Location = new System.Drawing.Point(40, 25);
            this.openServerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openServerLabel.Name = "openServerLabel";
            this.openServerLabel.Size = new System.Drawing.Size(86, 24);
            this.openServerLabel.TabIndex = 0;
            this.openServerLabel.Text = "服务器名:";
            // 
            // openEngineTypeCombox
            // 
            this.openEngineTypeCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.openEngineTypeCombox.FormattingEnabled = true;
            this.openEngineTypeCombox.Location = new System.Drawing.Point(153, 49);
            this.openEngineTypeCombox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.openEngineTypeCombox.Name = "openEngineTypeCombox";
            this.openEngineTypeCombox.Size = new System.Drawing.Size(367, 32);
            this.openEngineTypeCombox.TabIndex = 10;
            // 
            // openEngineTypeLabel
            // 
            this.openEngineTypeLabel.AutoSize = true;
            this.openEngineTypeLabel.Location = new System.Drawing.Point(40, 51);
            this.openEngineTypeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.openEngineTypeLabel.Name = "openEngineTypeLabel";
            this.openEngineTypeLabel.Size = new System.Drawing.Size(86, 24);
            this.openEngineTypeLabel.TabIndex = 5;
            this.openEngineTypeLabel.Text = "引擎类型:";
            // 
            // createPage
            // 
            this.createPage.Controls.Add(this.createFileSourcePanel);
            this.createPage.Controls.Add(this.createEngineTypeCombox);
            this.createPage.Controls.Add(this.createTypeLable);
            this.createPage.Controls.Add(this.createDatabasePanel);
            this.createPage.Location = new System.Drawing.Point(4, 33);
            this.createPage.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createPage.Name = "createPage";
            this.createPage.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createPage.Size = new System.Drawing.Size(564, 1115);
            this.createPage.TabIndex = 2;
            this.createPage.Text = "新建";
            this.createPage.UseVisualStyleBackColor = true;
            // 
            // createFileSourcePanel
            // 
            this.createFileSourcePanel.Controls.Add(this.createSourceNameLabel);
            this.createFileSourcePanel.Controls.Add(this.createSourceText);
            this.createFileSourcePanel.Controls.Add(this.createFileSource);
            this.createFileSourcePanel.Controls.Add(this.createFilePathLabel);
            this.createFileSourcePanel.Controls.Add(this.createFileFolderBrowser);
            this.createFileSourcePanel.Controls.Add(this.createFilePathText);
            this.createFileSourcePanel.Location = new System.Drawing.Point(7, 224);
            this.createFileSourcePanel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createFileSourcePanel.Name = "createFileSourcePanel";
            this.createFileSourcePanel.Size = new System.Drawing.Size(557, 239);
            this.createFileSourcePanel.TabIndex = 0;
            // 
            // createSourceNameLabel
            // 
            this.createSourceNameLabel.AutoSize = true;
            this.createSourceNameLabel.Location = new System.Drawing.Point(40, 93);
            this.createSourceNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createSourceNameLabel.Name = "createSourceNameLabel";
            this.createSourceNameLabel.Size = new System.Drawing.Size(86, 24);
            this.createSourceNameLabel.TabIndex = 0;
            this.createSourceNameLabel.Text = "数据源名:";
            // 
            // createSourceText
            // 
            this.createSourceText.Location = new System.Drawing.Point(149, 87);
            this.createSourceText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createSourceText.Name = "createSourceText";
            this.createSourceText.Size = new System.Drawing.Size(253, 31);
            this.createSourceText.TabIndex = 46;
            // 
            // createFileSource
            // 
            this.createFileSource.Location = new System.Drawing.Point(423, 88);
            this.createFileSource.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createFileSource.Name = "createFileSource";
            this.createFileSource.Size = new System.Drawing.Size(100, 45);
            this.createFileSource.TabIndex = 51;
            this.createFileSource.Text = "创建";
            this.createFileSource.UseVisualStyleBackColor = true;
            // 
            // createFilePathLabel
            // 
            this.createFilePathLabel.AutoSize = true;
            this.createFilePathLabel.Location = new System.Drawing.Point(40, 25);
            this.createFilePathLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createFilePathLabel.Name = "createFilePathLabel";
            this.createFilePathLabel.Size = new System.Drawing.Size(70, 24);
            this.createFilePathLabel.TabIndex = 0;
            this.createFilePathLabel.Text = "路    径:";
            // 
            // createFileFolderBrowser
            // 
            this.createFileFolderBrowser.Location = new System.Drawing.Point(422, 19);
            this.createFileFolderBrowser.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createFileFolderBrowser.Name = "createFileFolderBrowser";
            this.createFileFolderBrowser.Size = new System.Drawing.Size(100, 45);
            this.createFileFolderBrowser.TabIndex = 51;
            this.createFileFolderBrowser.Text = "浏览";
            this.createFileFolderBrowser.UseVisualStyleBackColor = true;
            // 
            // createFilePathText
            // 
            this.createFilePathText.Location = new System.Drawing.Point(149, 19);
            this.createFilePathText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createFilePathText.Name = "createFilePathText";
            this.createFilePathText.Size = new System.Drawing.Size(253, 31);
            this.createFilePathText.TabIndex = 45;
            // 
            // createEngineTypeCombox
            // 
            this.createEngineTypeCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createEngineTypeCombox.FormattingEnabled = true;
            this.createEngineTypeCombox.Location = new System.Drawing.Point(150, 49);
            this.createEngineTypeCombox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createEngineTypeCombox.Name = "createEngineTypeCombox";
            this.createEngineTypeCombox.Size = new System.Drawing.Size(367, 32);
            this.createEngineTypeCombox.TabIndex = 10;
            // 
            // createTypeLable
            // 
            this.createTypeLable.AutoSize = true;
            this.createTypeLable.Location = new System.Drawing.Point(40, 51);
            this.createTypeLable.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createTypeLable.Name = "createTypeLable";
            this.createTypeLable.Size = new System.Drawing.Size(86, 24);
            this.createTypeLable.TabIndex = 0;
            this.createTypeLable.Text = "引擎类型:";
            // 
            // createDatabasePanel
            // 
            this.createDatabasePanel.Controls.Add(this.createDatabaseSource);
            this.createDatabasePanel.Controls.Add(this.createPasswordText);
            this.createDatabasePanel.Controls.Add(this.createUserText);
            this.createDatabasePanel.Controls.Add(this.createDatabaseText);
            this.createDatabasePanel.Controls.Add(this.createServerText);
            this.createDatabasePanel.Controls.Add(this.createPasswordLabel);
            this.createDatabasePanel.Controls.Add(this.createUserLabel);
            this.createDatabasePanel.Controls.Add(this.createDatabaseLabel);
            this.createDatabasePanel.Controls.Add(this.createServerLabel);
            this.createDatabasePanel.Location = new System.Drawing.Point(0, 600);
            this.createDatabasePanel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createDatabasePanel.Name = "createDatabasePanel";
            this.createDatabasePanel.Size = new System.Drawing.Size(546, 439);
            this.createDatabasePanel.TabIndex = 0;
            this.createDatabasePanel.Visible = false;
            // 
            // createDatabaseSource
            // 
            this.createDatabaseSource.Location = new System.Drawing.Point(422, 271);
            this.createDatabaseSource.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createDatabaseSource.Name = "createDatabaseSource";
            this.createDatabaseSource.Size = new System.Drawing.Size(100, 45);
            this.createDatabaseSource.TabIndex = 40;
            this.createDatabaseSource.Text = "创建";
            this.createDatabaseSource.UseVisualStyleBackColor = true;
            // 
            // createPasswordText
            // 
            this.createPasswordText.Location = new System.Drawing.Point(154, 200);
            this.createPasswordText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createPasswordText.Name = "createPasswordText";
            this.createPasswordText.Size = new System.Drawing.Size(363, 31);
            this.createPasswordText.TabIndex = 55;
            // 
            // createUserText
            // 
            this.createUserText.Location = new System.Drawing.Point(154, 141);
            this.createUserText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createUserText.Name = "createUserText";
            this.createUserText.Size = new System.Drawing.Size(363, 31);
            this.createUserText.TabIndex = 54;
            // 
            // createDatabaseText
            // 
            this.createDatabaseText.Location = new System.Drawing.Point(155, 80);
            this.createDatabaseText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createDatabaseText.Name = "createDatabaseText";
            this.createDatabaseText.Size = new System.Drawing.Size(361, 31);
            this.createDatabaseText.TabIndex = 53;
            // 
            // createServerText
            // 
            this.createServerText.Location = new System.Drawing.Point(154, 19);
            this.createServerText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.createServerText.Name = "createServerText";
            this.createServerText.Size = new System.Drawing.Size(363, 31);
            this.createServerText.TabIndex = 52;
            // 
            // createPasswordLabel
            // 
            this.createPasswordLabel.AutoSize = true;
            this.createPasswordLabel.Location = new System.Drawing.Point(40, 207);
            this.createPasswordLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createPasswordLabel.Name = "createPasswordLabel";
            this.createPasswordLabel.Size = new System.Drawing.Size(70, 24);
            this.createPasswordLabel.TabIndex = 0;
            this.createPasswordLabel.Text = "密    码:";
            // 
            // createUserLabel
            // 
            this.createUserLabel.AutoSize = true;
            this.createUserLabel.Location = new System.Drawing.Point(40, 145);
            this.createUserLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createUserLabel.Name = "createUserLabel";
            this.createUserLabel.Size = new System.Drawing.Size(78, 24);
            this.createUserLabel.TabIndex = 0;
            this.createUserLabel.Text = "用 户 名:";
            // 
            // createDatabaseLabel
            // 
            this.createDatabaseLabel.AutoSize = true;
            this.createDatabaseLabel.Location = new System.Drawing.Point(40, 87);
            this.createDatabaseLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createDatabaseLabel.Name = "createDatabaseLabel";
            this.createDatabaseLabel.Size = new System.Drawing.Size(86, 24);
            this.createDatabaseLabel.TabIndex = 0;
            this.createDatabaseLabel.Text = "数据库名:";
            // 
            // createServerLabel
            // 
            this.createServerLabel.AutoSize = true;
            this.createServerLabel.Location = new System.Drawing.Point(40, 25);
            this.createServerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createServerLabel.Name = "createServerLabel";
            this.createServerLabel.Size = new System.Drawing.Size(86, 24);
            this.createServerLabel.TabIndex = 0;
            this.createServerLabel.Text = "服务器名:";
            // 
            // datasourceGroup
            // 
            this.datasourceGroup.Controls.Add(this.datasourceText);
            this.datasourceGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.datasourceGroup.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datasourceGroup.Location = new System.Drawing.Point(583, 0);
            this.datasourceGroup.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.datasourceGroup.Name = "datasourceGroup";
            this.datasourceGroup.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.datasourceGroup.Size = new System.Drawing.Size(815, 1152);
            this.datasourceGroup.TabIndex = 3;
            this.datasourceGroup.TabStop = false;
            this.datasourceGroup.Text = "数据源信息";
            // 
            // datasourceText
            // 
            this.datasourceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datasourceText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datasourceText.Location = new System.Drawing.Point(5, 28);
            this.datasourceText.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.datasourceText.Name = "datasourceText";
            this.datasourceText.Size = new System.Drawing.Size(805, 1117);
            this.datasourceText.TabIndex = 4;
            this.datasourceText.Text = "";
            // 
            // AddDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 1152);
            this.Controls.Add(this.datasourceGroup);
            this.Controls.Add(this.operationTabCtrl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "AddDataSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据源管理";
            this.operationTabCtrl.ResumeLayout(false);
            this.openPage.ResumeLayout(false);
            this.openPage.PerformLayout();
            this.openFilePanel.ResumeLayout(false);
            this.openFilePanel.PerformLayout();
            this.openDatabasePanel.ResumeLayout(false);
            this.openDatabasePanel.PerformLayout();
            this.createPage.ResumeLayout(false);
            this.createPage.PerformLayout();
            this.createFileSourcePanel.ResumeLayout(false);
            this.createFileSourcePanel.PerformLayout();
            this.createDatabasePanel.ResumeLayout(false);
            this.createDatabasePanel.PerformLayout();
            this.datasourceGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl operationTabCtrl;
        private System.Windows.Forms.TabPage openPage;
        private System.Windows.Forms.TabPage createPage;
        private System.Windows.Forms.GroupBox datasourceGroup;
        private System.Windows.Forms.RichTextBox datasourceText;
        private System.Windows.Forms.Panel openDatabasePanel;
        private System.Windows.Forms.ComboBox openEngineTypeCombox;
        private System.Windows.Forms.Label openEngineTypeLabel;
        private System.Windows.Forms.Button openFileSource;
        private System.Windows.Forms.Button openFolderBrowser;
        private System.Windows.Forms.TextBox openPathText;
        private System.Windows.Forms.Label openPathLabel;
        private System.Windows.Forms.Label openServerLabel;
        private System.Windows.Forms.Button openDatabaseSource;
        private System.Windows.Forms.TextBox openPasswordText;
        private System.Windows.Forms.TextBox openUserNameText;
        private System.Windows.Forms.TextBox openDatabaseText;
        private System.Windows.Forms.TextBox openServerText;
        private System.Windows.Forms.Label openPasswordLabel;
        private System.Windows.Forms.Label openUserNameLabel;
        private System.Windows.Forms.Label openDatabaseLabel;
        private System.Windows.Forms.Panel openFilePanel;
        private System.Windows.Forms.ComboBox createEngineTypeCombox;
        private System.Windows.Forms.Label createTypeLable;
        private System.Windows.Forms.Panel createDatabasePanel;
        private System.Windows.Forms.Button createDatabaseSource;
        private System.Windows.Forms.TextBox createPasswordText;
        private System.Windows.Forms.TextBox createUserText;
        private System.Windows.Forms.TextBox createDatabaseText;
        private System.Windows.Forms.TextBox createServerText;
        private System.Windows.Forms.Label createPasswordLabel;
        private System.Windows.Forms.Label createUserLabel;
        private System.Windows.Forms.Label createDatabaseLabel;
        private System.Windows.Forms.Label createServerLabel;
        private System.Windows.Forms.Panel createFileSourcePanel;
        private System.Windows.Forms.Button createFileSource;
        private System.Windows.Forms.Label createFilePathLabel;
        private System.Windows.Forms.Button createFileFolderBrowser;
        private System.Windows.Forms.TextBox createFilePathText;
        private System.Windows.Forms.Label createSourceNameLabel;
        private System.Windows.Forms.TextBox createSourceText;
        private System.Windows.Forms.TextBox openKeyTable;
        private System.Windows.Forms.Label openKeyText;


    }
}



