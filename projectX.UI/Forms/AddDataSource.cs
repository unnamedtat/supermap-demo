using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using SuperMap.Data;
using System.IO;
using ProjectX.BLL;

namespace ProjectX.UI.Forms
{
    public partial class AddDataSource : Form
    {
        private AddDataSourceManage addDataSourceManage;
        /// <summary>
        /// 新建的数据源
        /// </summary>
        private Workspace workspace;
        private DatasourceConnectionInfo newCreatesourceInfo;
        private String[] engineType;

        public AddDataSource(Workspace workspace)
        {
            try
            {
                InitializeComponent();
				InitializeCultureResources();
                Initialize(workspace);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
		private void InitializeCultureResources()
		{
			if(SuperMap.Data.Environment.CurrentCulture =="zh-CN")
			{
				this.openPage.Size = new System.Drawing.Size(408, 691);
				this.openPage.Text = "打开";
				this.openKeyText.Size = new System.Drawing.Size(79, 15);
				this.openKeyText.Size = new System.Drawing.Size(79, 15);
				this.openFileSource.Size = new System.Drawing.Size(65, 28);
				this.openFileSource.Text = "打开";
				this.openPathLabel.Size = new System.Drawing.Size(77, 15);
				this.openPathLabel.Text = "路    径:";
				this.openFolderBrowser.Size = new System.Drawing.Size(65, 28);
				this.openFolderBrowser.Text = "浏览";
				this.openPasswordLabel.Size = new System.Drawing.Size(77, 15);
				this.openPasswordLabel.Text = "密    码:";
				this.openUserNameLabel.Size = new System.Drawing.Size(76, 15);
				this.openUserNameLabel.Text = "用 户 名:";
				this.openDatabaseLabel.Size = new System.Drawing.Size(75, 15);
				this.openDatabaseLabel.Text = "数据库名:";
				this.openServerLabel.Size = new System.Drawing.Size(75, 15);
				this.openServerLabel.Text = "服务器名:";
				this.openEngineTypeLabel.Size = new System.Drawing.Size(75, 15);
				this.openEngineTypeLabel.Text = "引擎类型:";
				this.createPage.Size = new System.Drawing.Size(408, 691);
				this.createPage.Text = "新建";
				this.createSourceNameLabel.Size = new System.Drawing.Size(75, 15);
				this.createSourceNameLabel.Text = "数据源名:";
				this.createFileSource.Size = new System.Drawing.Size(65, 28);
				this.createFileSource.Text = "创建";
				this.createFilePathLabel.Size = new System.Drawing.Size(77, 15);
				this.createFilePathLabel.Text = "路    径:";
				this.createFileFolderBrowser.Size = new System.Drawing.Size(65, 28);
				this.createFileFolderBrowser.Text = "浏览";
				this.createTypeLable.Size = new System.Drawing.Size(75, 15);
				this.createTypeLable.Text = "引擎类型:";
				this.createDatabaseSource.Size = new System.Drawing.Size(73, 28);
				this.createDatabaseSource.Text = "创建";
				this.createPasswordLabel.Size = new System.Drawing.Size(77, 15);
				this.createPasswordLabel.Text = "密    码:";
				this.createUserLabel.Size = new System.Drawing.Size(76, 15);
				this.createUserLabel.Text = "用 户 名:";
				this.createDatabaseLabel.Size = new System.Drawing.Size(75, 15);
				this.createDatabaseLabel.Text = "数据库名:";
				this.createServerLabel.Size = new System.Drawing.Size(75, 15);
				this.createServerLabel.Text = "服务器名:";
				this.datasourceGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
				this.datasourceGroup.Size = new System.Drawing.Size(593, 720);
				this.datasourceGroup.Text = "数据源信息";
				this.datasourceText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
				this.Text = "数据源管理";
			}
			else
			{
				this.openPage.Size = new System.Drawing.Size(304, 550);
				this.openPage.Text = "Open";
				this.openKeyText.Size = new System.Drawing.Size(59, 12);
				this.openKeyText.Text = "Key:";
				this.openFileSource.Size = new System.Drawing.Size(55, 22);
				this.openFileSource.Text = "Open";
				this.openPathLabel.Size = new System.Drawing.Size(35, 12);
				this.openPathLabel.Text = "Path:";
				this.openFolderBrowser.Size = new System.Drawing.Size(55, 22);
				this.openFolderBrowser.Text = "Browse";
				this.openPasswordLabel.Size = new System.Drawing.Size(59, 12);
				this.openPasswordLabel.Text = "Password:";
				this.openUserNameLabel.Size = new System.Drawing.Size(35, 12);
				this.openUserNameLabel.Text = "User:";
				this.openDatabaseLabel.Size = new System.Drawing.Size(59, 12); 

                this.openDatabaseLabel.Text = "Database:";
				this.openServerLabel.Size = new System.Drawing.Size(47, 12);
				this.openServerLabel.Text = "Server:";
				this.openEngineTypeLabel.Size = new System.Drawing.Size(35, 12);
				this.openEngineTypeLabel.Text = "Type:";
				this.createPage.Size = new System.Drawing.Size(304, 550);
				this.createPage.Text = "New";			
				this.createSourceNameLabel.Size = new System.Drawing.Size(35, 12);
				this.createSourceNameLabel.Text = "Name:";
				this.createFileSource.Size = new System.Drawing.Size(55, 22);
				this.createFileSource.Text = "Create";
				this.createFilePathLabel.Size = new System.Drawing.Size(35, 12);
				this.createFilePathLabel.Text = "Path:";
				this.createFileFolderBrowser.Size = new System.Drawing.Size(55, 22);
				this.createFileFolderBrowser.Text = "Browse";
				this.createTypeLable.Size = new System.Drawing.Size(35, 12);
				this.createTypeLable.Text = "Type:";
				this.createDatabaseSource.Size = new System.Drawing.Size(55, 22);
				this.createDatabaseSource.Text = "Create";
				this.createPasswordLabel.Size = new System.Drawing.Size(59, 12);
				this.createPasswordLabel.Text = "Password:";
				this.createUserLabel.Size = new System.Drawing.Size(35, 12);
				this.createUserLabel.Text = "User:";
				this.createDatabaseLabel.Size = new System.Drawing.Size(59, 12);
				this.createDatabaseLabel.Text = "Database:";
				this.createServerLabel.Size = new System.Drawing.Size(47, 12);
				this.createServerLabel.Text = "Server:";
				this.datasourceGroup.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
				this.datasourceGroup.Size = new System.Drawing.Size(445, 576);
				this.datasourceGroup.Text = "Datasource Information";
				this.datasourceText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
				this.Text = "Manage Datasource";
			}
		}

        private void Initialize(Workspace workspace)
        {
            try
            {
                this.workspace = workspace;
                newCreatesourceInfo = new DatasourceConnectionInfo();
                addDataSourceManage = new AddDataSourceManage(workspace);

                newCreatesourceInfo.EngineType = EngineType.UDB;

                if (addDataSourceManage != null)
                {
                    // 设置panel的位置和是否可见
                    openDatabasePanel.Location = new Point(0, 125);
                    openFilePanel.Location = new Point(0, 125);

                    openFilePanel.Visible = true;
                    openDatabasePanel.Visible = false;
                    engineType = new String[10];
					if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
					{
						engineType[0] = "ImagePlus";
                    	engineType[1] = "UDB";
                    	engineType[2] = "OraclePlus";
                    	engineType[3] = "SQLPlus";
                   		engineType[4] = "PostgreSQL";
                		engineType[5] = "DB2";
                    	engineType[6] = "OGC(WMS)";
                    	engineType[7] = "GoogleMaps";
                    	engineType[8] = "SuperMapCloud";
                    	engineType[9] = "REST";
					}					
                    else{
						engineType[0] = "ImagePlus引擎";                    
                    	engineType[1] = "UDB引擎";
                    	engineType[2] = "OraclePlus引擎";
                    	engineType[3] = "SQLPlus引擎";
                    	engineType[4] = "PostgreSQL引擎";
                    	engineType[5] = "DB2引擎";
                    	engineType[6] = "OGC引擎(WMS)";
                    	engineType[7] = "GoogleMaps引擎";
                    	engineType[8] = "SuperMapCloud引擎";
                    	engineType[9] = "REST引擎";
					}

                    InitializeOpenEngineType();

                    this.Resize += new EventHandler(FormMain_Resize);
                    // 打开界面的相关事件
					// The events of the "Open" panel
                    this.openFileSource.Enabled = false;
                    this.openEngineTypeCombox.SelectedIndexChanged += new EventHandler(openEngineTypeCombox_SelectedIndexChanged);
                    this.openFolderBrowser.Click += new EventHandler(openFolderBrowser_Click);
                    this.openFileSource.Click += new EventHandler(openFileSource_Click);

                    this.openDatabaseSource.Click += new EventHandler(openDatabaseSource_Click);
                    this.openPathText.TextChanged += new EventHandler(openPathText_TextChanged);
                    // 创建界面的相关事件
					// The events of the "New" panel
                    this.operationTabCtrl.SelectedIndexChanged += new EventHandler(operationTabCtrl_SelectedIndexChanged);
                    this.createEngineTypeCombox.SelectedIndexChanged += new EventHandler(createEngineTypeCombox_SelectedIndexChanged);
                    this.createFileFolderBrowser.Click += new EventHandler(createFileFolderBrowser_Click);
                    this.createSourceText.TextChanged += new EventHandler(createSourceText_TextChanged);
                    this.createFileSource.Click += new EventHandler(createFileSource_Click);
                    this.createDatabaseSource.Click += new EventHandler(createDatabaseSource_Click);
                }
                else
                {
                    if(SuperMap.Data.Environment.CurrentCulture != "zh-CN")
					{
						MessageBox.Show("Failed to initialize~!");
					}
                    else{
						MessageBox.Show("初始化失败~！");
					}
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            try
            {
                datasourceGroup.Width = this.Width - operationTabCtrl.Width - 10;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void InitializeOpenEngineType()
        {
            try
            {
                openEngineTypeCombox.Items.AddRange(engineType);
                // 默认打开SDB
				// Default to open SDB type
                openEngineTypeCombox.SelectedIndex = 1;
                openKeyTable.Visible = false;
                openKeyText.Visible = false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 根据typename获取对应的EngineType
        /// </summary>
        private EngineType GetEngineType(Int32 engineIndex)
        {
            EngineType type = EngineType.UDB;

            switch (engineIndex)
            {
                case 0:
                    {
                        type = EngineType.ImagePlugins;
                    }
                    break;
                case 1:
                    {
                        type = EngineType.UDB;
                    }
                    break;
                case 2:
                    {
                        type = EngineType.OraclePlus;
                    }
                    break;
                case 3:
                    {
                        type = EngineType.SQLPlus;
                    }
                    break;
                case 4:
                    {
                        type = EngineType.PostgreSQL;
                    }
                    break;
                case 5:
                    {
                        type = EngineType.DB2;
                    }
                    break;
                case 6:
                    {
                        type = EngineType.OGC;
                    }
                    break;
                case 7:
                    {
                        type = EngineType.GoogleMaps;
                    }
                    break;
                case 8:
                    {
                        type = EngineType.SuperMapCloud;
                    }
                    break;
                default:
                    {
                        type = EngineType.iServerRest;
                    }
                    break;         
            }

            return type;
        }

        // ==============================事件======================================
        /// <summary>
        /// 设置不同引擎下界面上应该显示的东西
        /// </summary>
        private void openEngineTypeCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean isVisible = (openEngineTypeCombox.Text.CompareTo(engineType[2]) == 0
                    || openEngineTypeCombox.Text.CompareTo(engineType[3]) == 0
                    || openEngineTypeCombox.Text.CompareTo(engineType[4]) == 0
                    || openEngineTypeCombox.Text.CompareTo(engineType[5]) == 0);

                openDatabasePanel.Visible = isVisible;
                openFilePanel.Visible = !isVisible;

                if (openFilePanel.Visible)
                {
                    openPathText.Text = "";
                    if (openEngineTypeCombox.Text.CompareTo(engineType[6]) == 0
                        || openEngineTypeCombox.Text.CompareTo(engineType[9]) == 0)
                    {
                        openPathText.Enabled = true;
						if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
						{
							openPathLabel.Text = "Website";
						}
                        else
						{
							openPathLabel.Text = "网    址";
                        }
						openKeyText.Visible = false;
                        openKeyTable.Visible = false;
                        openFolderBrowser.Visible = false;
                    }
                    else if (openEngineTypeCombox.Text.CompareTo(engineType[7]) == 0)
                    {
						if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
						{
							openPathLabel.Text = "URL";
						}
                        else
						{
							openPathLabel.Text = "服务地址";
                        }

                        openPathText.Text = "http://maps.google.com";
                        openPathText.Enabled = false;
                        openKeyText.Visible = true;
                        openKeyTable.Visible = true;
                        openFolderBrowser.Visible = false;
                    }
                    else if (openEngineTypeCombox.Text.CompareTo(engineType[8]) == 0)
                    {
                        if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
						{
							openPathLabel.Text = "URL";
						}
                        else
						{
							openPathLabel.Text = "服务地址";
                        }

                        openPathText.Enabled = false;
                        openKeyText.Visible = false;
                        openKeyTable.Visible = false;
                        openFolderBrowser.Visible = false;                      
                        openPathText.Text = "http://beijing.supermapcloud.com";                
                    }
                    else
                    {
						if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
						{
							openPathLabel.Text = "Path";
						}
                        else
						{
							openPathLabel.Text = "路    径";
                        }
                        openPathText.Enabled = true;
                        openKeyText.Visible = false;
                        openKeyTable.Visible = false;
                        openFolderBrowser.Visible = true;
                    }
                }
                else
                {
                    openServerText.Text = "";
                    openDatabaseText.Text = "";
                    openUserNameText.Text = "";
                    openPasswordText.Text = "";
                    if (openEngineTypeCombox.Text.CompareTo(engineType[5]) == 0)
                    {
                        openServerText.Enabled = false;
                    }
                    else
                    {
                        openServerText.Enabled = true;
                    }
                }

                // 根据所选type设置连接信息的EngineType
                newCreatesourceInfo = new DatasourceConnectionInfo();
                newCreatesourceInfo.EngineType = GetEngineType(openEngineTypeCombox.SelectedIndex);

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// 浏览文件
        /// </summary>
        private void openFolderBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDlg = new OpenFileDialog();

                EngineType type = GetEngineType(openEngineTypeCombox.SelectedIndex);
				if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					switch (type)
               		{
                    	case EngineType.ImagePlugins:
                        	fileDlg.Filter = "Support Image File(*.tif,*.sit,*.bmp,*.png,*.sct,*.tga,*.raw)|*.tif;*.sit;*.bmp;*.png;*.sct;*.tga;*.raw";
                        	break;
                    	case EngineType.UDB:
                        	fileDlg.Filter = "UDB File(*.udb)|*.udb";
                        	break;
                    	default:
                        	fileDlg.Filter = "All File|*.*";
                        	break;
                	}
				}
                else
				{
					switch (type)
                	{
                    	case EngineType.ImagePlugins:
                        	fileDlg.Filter = "支持的影像文件(*.tif,*.sit,*.bmp,*.png,*.sct,*.tga,*.raw)|*.tif;*.sit;*.bmp;*.png;*.sct;*.tga;*.raw";
                        	break;
                    	case EngineType.UDB:
                        	fileDlg.Filter = "UDB数据文件(*.udb)|*.udb";
                        	break;
                    	default:
                        	fileDlg.Filter = "所有文件|*.*";
                        	break;
                	}
				}
                // 该按钮只在文件型数据源时有效
				// This button is usable only for the file type datasource
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    openPathText.Text = fileDlg.FileName;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 打开文件型数据源
		/// Open the file type datasource
        /// </summary>
        private void openFileSource_Click(object sender, EventArgs e)
        {
            try
            {
                openFileSource.Enabled = false;
				if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					datasourceText.Text = "Datasource is opening....\n";
				}
                else
				{
					datasourceText.Text = "数据源打开中....\n";
                }
				datasourceText.Update();

                if (newCreatesourceInfo.EngineType == EngineType.OGC)
                {
                    // 这里只允许设置WMS和WFS两种类型,具体看发布的网络数据源类型
					// Only the WMS and WFS type database can be set.
                    newCreatesourceInfo.Database = "WMS";
                }
                newCreatesourceInfo.Server = openPathText.Text;
                string filename = System.IO.Path.GetFileNameWithoutExtension(newCreatesourceInfo.Server);
                newCreatesourceInfo.Alias = filename;
                datasourceText.Text = addDataSourceManage.OpenDatasource(newCreatesourceInfo);
                openFileSource.Enabled = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            //workspace.Datasources.CloseAll();
        }
        /// <summary>
        /// 打开数据库型数据源
		/// Open the database datasource 
        /// </summary>
        private void openDatabaseSource_Click(object sender, EventArgs e)
        {
            try
            {
                openDatabaseSource.Enabled = false;
                if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					datasourceText.Text = "Datasource is opening....\n";
				}
                else
				{
					datasourceText.Text = "数据源打开中....\n";
                }
                datasourceText.Update();
                newCreatesourceInfo.Server = openServerText.Text;
                newCreatesourceInfo.Database = openDatabaseText.Text;
                newCreatesourceInfo.User = openUserNameText.Text;
                newCreatesourceInfo.Password = openPasswordText.Text;
                if (newCreatesourceInfo.EngineType == EngineType.SQLPlus)
                {
                    newCreatesourceInfo.Driver = "SQL Server";
                }

                datasourceText.Text = addDataSourceManage.OpenDatasource(newCreatesourceInfo);
                openDatabaseSource.Enabled = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            //workspace.Datasources.CloseAll();
        }
        /// <summary>
        /// 设置打开按钮是否可用
		/// Control that whether the "Open" button is valid or not
        /// </summary>
        private void openPathText_TextChanged(object sender, EventArgs e)
        {
            if (openPathText.Text.Length != 0)
            {
                openFileSource.Enabled = true;
            }
            else
            {
                openFileSource.Enabled = false;
            }
        }
        /// <summary>
        /// 当切换到创建页的时候，才初始化该界面上的元素
		/// Initialize the elements of the "New" panel when switch to
        /// </summary>
        private void operationTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (operationTabCtrl.SelectedIndex == 1 && createEngineTypeCombox.Items.Count == 0)
                {
                    createEngineTypeCombox.Items.Add(engineType[1]);
                    createEngineTypeCombox.Items.Add(engineType[2]);
                    createEngineTypeCombox.Items.Add(engineType[3]);
                    createEngineTypeCombox.Items.Add(engineType[4]);
                    createEngineTypeCombox.Items.Add(engineType[5]);
                    createEngineTypeCombox.SelectedIndex = 0;

                    createFileSourcePanel.Location = new Point(0, 125);
                    createFileSourcePanel.Visible = true;
                    createDatabasePanel.Location = new Point(0, 125);
                    createDatabasePanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        private void createEngineTypeCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean isVisible = (createEngineTypeCombox.Text.CompareTo(engineType[2]) == 0
                    || createEngineTypeCombox.Text.CompareTo(engineType[3]) == 0
                    || createEngineTypeCombox.Text.CompareTo(engineType[4]) == 0
                    || createEngineTypeCombox.Text.CompareTo(engineType[5]) == 0);

                createDatabasePanel.Visible = isVisible;
                createFileSourcePanel.Visible = !isVisible;

                if (createDatabasePanel.Visible)
                {
                    createServerText.Text = "";
                    createDatabaseText.Text = "";
                    createUserText.Text = "";
                    createPasswordText.Text = "";

                    if (createEngineTypeCombox.Text.CompareTo(engineType[5]) == 0)
                    {
                        createServerText.Enabled = false;
                    }
                    else
                    {
                        createServerText.Enabled = true;
                    }
                }
                else
                {
                    createFilePathText.Text = "";
                    createSourceText.Text = "";
                }

                // 根据所选type设置连接信息的EngineType
				// Set the connected information EngineType accroding to the selected type
                newCreatesourceInfo = new DatasourceConnectionInfo();
                newCreatesourceInfo.EngineType = GetEngineType(createEngineTypeCombox.SelectedIndex + 1);
                createFileSource.Enabled = false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 设置创建数据源的路径
		/// Sets the path of the created datasource
        /// </summary>
        private void createFileFolderBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();

                if (folderDlg.ShowDialog() == DialogResult.OK)
                {
                    createFilePathText.Text = folderDlg.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 控制创建按钮是否可用
		/// Control that whether the "Create" button is valid or not
        /// </summary>
        private void createSourceText_TextChanged(object sender, EventArgs e)
        {
            if (createSourceText.Text.Length != 0)
            {
                createFileSource.Enabled = true;
            }
            else
            {
                createFileSource.Enabled = false;
            }
        }
        /// <summary>
        /// 创建数据库数据源
		/// Create the database datasource
        /// </summary>
        private void createDatabaseSource_Click(object sender, EventArgs e)
        {
            try
            {
                createDatabaseSource.Enabled = false;
				if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					datasourceText.Text = "Datasource is creating....\n";
				}
                else
				{
					datasourceText.Text = "数据源创建中....\n";
                }
                datasourceText.Update();

                newCreatesourceInfo.Server = createServerText.Text;
                newCreatesourceInfo.Database = createDatabaseText.Text;
                newCreatesourceInfo.User = createUserText.Text;
                newCreatesourceInfo.Password = createPasswordText.Text;
                if (newCreatesourceInfo.EngineType == EngineType.SQLPlus)
                {
                    newCreatesourceInfo.Driver = "SQL Server";
                }

                datasourceText.Text = addDataSourceManage.CreateDatasource(newCreatesourceInfo);
                createDatabaseSource.Enabled = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 创建文件型数据源
		/// Create the file datasource
        /// </summary>
        private void createFileSource_Click(object sender, EventArgs e)
        {
            try
            {
                createFileSource.Enabled = false;
                if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					datasourceText.Text = "Datasource is creating....\n";
				}
                else
				{
					datasourceText.Text = "数据源创建中....\n";
                }
                datasourceText.Update();
                newCreatesourceInfo.Server = createFilePathText.Text + "\\" + createSourceText.Text;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(newCreatesourceInfo.Server);
                newCreatesourceInfo.Alias = fileName;
                datasourceText.Text = addDataSourceManage.CreateDatasource(newCreatesourceInfo);
                createFileSource.Enabled = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
    /// <summary>
    /// 执行数据源管理的逻辑类
    /// </summary>
    public class AddDataSourceManage
    {
        private Workspace m_workspace;

        private String m_opensu = "";
        private String m_openfa = "";
        private String m_openfawithexc = "";
        private String m_dsinfo = "";
        private String m_insname = "";
        private String m_engtype = "";
        private String m_datasetinfo = "";
        private String m_datasetname = "";
        private String m_nodataset = "";
        private String m_createsu = "";
        private String m_createfa = "";
        private String m_createfawithexc = "";
        /// <summary>
        /// 根据workspace构造 SampleRun对象
        ///Initialize the SampleRun object with the specified workspace
        /// </summary>
        public AddDataSourceManage(Workspace workspace)
        {
            InitializeCultureResources();
            m_workspace = workspace;
        }

        private void InitializeCultureResources()
        {
            m_opensu = "打开数据源成功！\n";
            m_openfa = "打开数据源失败！\n";
            m_openfawithexc = "打开数据源失败！异常信息：";
            m_dsinfo = "数据源基本信息：";
            m_insname = "实例名称：";
            m_engtype = "引擎类型：";
            m_datasetinfo = "数据源中数据集信息：";
            m_datasetname = "数据集名称：{0}\t{1}\n";
            m_nodataset = "数据源中没有数据集！";
            m_createsu = "创建数据源成功！\n";
            m_createfa = "创建数据源失败！\n";
            m_createfawithexc = "创建数据源失败！异常信息：";
        }

        /// <summary>
        /// 根据数据源连接信息打开数据源，返回相应的描述信息
        /// </summary>
        public String OpenDatasource(DatasourceConnectionInfo datasourceInfo)
        {
            //m_workspace.Datasources.CloseAll();
            String discription = "";

            if (m_workspace != null)
            {
                try
                {
                    Datasource datasource = m_workspace.Datasources.Open(datasourceInfo);

                    if (datasource != null)
                    {
                        discription = m_opensu;
                        discription += GetDatasourceString(datasource);
                    }
                    else
                    {
                        discription = m_openfa;
                    }
                }
                catch (Exception e)
                {
                    discription = m_openfawithexc + e.Message+"\n可能数据源已存在于该工程中！";
                }
            }
            return discription;
        }

        /// <summary>
        /// 获取数据源的描述字符串
		/// Get the description string of the datasource
        /// </summary>
        private String GetDatasourceString(Datasource datasource)
        {
            StringBuilder dsString = new StringBuilder();
            try
            {
                dsString.AppendLine(m_dsinfo);
                dsString.AppendLine(m_insname + datasource.ConnectionInfo.Server);
                dsString.AppendLine(m_engtype + datasource.EngineType.ToString());
                dsString.AppendLine("*******************************************");
                if (datasource.Datasets.Count != 0)
                {
                    dsString.AppendLine(m_datasetinfo);
                    foreach (Dataset dataset in datasource.Datasets)
                    {
                        dsString.AppendFormat(m_datasetname, dataset.Name, dataset.Type.ToString());
                    }
                }
                else
                {
                    dsString.AppendLine(m_nodataset);

                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return dsString.ToString();
        }

        /// <summary>
        /// 根据数据源连接信息创建数据源，返回相应的描述信息
		/// Create the datasource based on datsource connection information, and return the description information
        /// </summary>
        public String CreateDatasource(DatasourceConnectionInfo datasourceInfo)
        {
            String discription = "";
            try
            {
                //m_workspace.Datasources.CloseAll();
                Datasource datasource = m_workspace.Datasources.Create(datasourceInfo);

                if (datasource != null)
                {
                    discription = m_createsu;
                    discription += GetDatasourceString(datasource);
                }
                else
                {
                    discription = m_createfa;
                }
            }
            catch (Exception e)
            {
                discription = m_createfawithexc + e.Message;
            }
            return discription;
        }
    }

}

