using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SuperMap.Data;
using System.Diagnostics;
using System.IO;
using ProjectX.BLL;

namespace ProjectX.UI.Forms
{
    public partial class AddDataset : Form
    {
        private AddDataSetAction m_sampleRun;
        private Workspace m_workspace;

        public AddDataset(Workspace workspace)
        {
            try
            {
                InitializeComponent();
				InitializeCultureResources();
                InitializeDatasetTypeCombox();
                m_workspace = workspace;
                //首先选择数据源，再选择数据集
                foreach (Datasource datasource in workspace.Datasources)
                {
                    comboBoxShowDataSource.Items.Add(datasource.Alias);
                }

                //m_srcDatasourceInfo = new DatasourceConnectionInfo("../../SampleData/World/world.udbx", "world", "");
                //m_srcDatasourceInfo.EngineType = EngineType.UDBX;
                //m_dstDatasourceInfo = new DatasourceConnectionInfo("../../SampleData/World/copyworld.udbx", "copyworld", "");
                //m_dstDatasourceInfo.EngineType = EngineType.UDBX;
                m_sampleRun = null;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

		private void InitializeCultureResources()
		{
			if(SuperMap.Data.Environment.CurrentCulture =="zh-CN")
			{
				this.groupModify.Text = "修改选中数据集";
				this.newNameLabel.Size = new System.Drawing.Size(47, 12);
           		this.newNameLabel.Text = "新名称:";
				this.changeName.Text = "重命名";
				this.deleteCurrent.Name = "deleteCurrent";
				this.groupCreateNew.Text = "新建数据集";
				this.dataName.Size = new System.Drawing.Size(71, 12);
				this.dataName.Text = "数据集名称:";
				this.datasetTypeLabel.Size = new System.Drawing.Size(71, 12);
				this.datasetTypeLabel.Text = "数据集类型:";
				this.createDataset.Text = "创建";
				this.groupDatasets.Text = "数据集列表";
				this.groupBox1.Text = "删除选中数据集";
				
				this.Text = "数据集管理";
				
			}
			else
			{
				this.groupModify.Text = "Modify Selected Dataset";
				this.newNameLabel.Size = new System.Drawing.Size(65, 12);
            	this.newNameLabel.Text = "New Name: ";
				this.changeName.Text = "Rename";
				this.deleteCurrent.Text = "Delete Selected";
				this.groupCreateNew.Text = "New Dataset";
				this.dataName.Size = new System.Drawing.Size(89, 12);
				this.dataName.Text = "Dataset Name: ";
				this.datasetTypeLabel.Size = new System.Drawing.Size(83, 12);
				this.datasetTypeLabel.Text = "Dataset Type:";
				this.createDataset.Text = "Create";
				this.groupDatasets.Text = "Dataset List";
				this.groupBox1.Text = "Delete Selected Dataset";
				
				this.Text = "Manage Dataset";
				
			}
		}
		
        /// <summary>
        /// 窗口加载的时候，绑定一些事件等
		/// Bind events when adding the main form
        /// </summary>
        private void thisForm_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxShowDataSource.TextChanged += new EventHandler(ChooseDataSource);

                this.deleteCurrent.Click += new EventHandler(deleteCurrent_Click);

                this.changeName.Enabled = false;
                this.changeName.Click += new EventHandler(changeName_Click);
                this.newNameTextBox.TextChanged += new EventHandler(newNameTextBox_TextChanged);

                this.createDataset.Enabled = false;
                this.createDataset.Click += new EventHandler(createDataset_Click);
                this.createDatasetName.TextChanged += new EventHandler(createDatasetName_TextChanged);

                this.datasetView.NodeMouseClick += new TreeNodeMouseClickEventHandler(datasetView_NodeMouseClick);
                this.datasetView.LostFocus += new EventHandler(datasetView_LostFocus);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 选择一个数据源后
        /// </summary>
        private void ChooseDataSource(object sender,EventArgs e)
        {
            Datasource datasource = m_workspace.Datasources[comboBoxShowDataSource.Text];
            m_sampleRun = new AddDataSetAction(m_workspace, datasource);

            //m_sampleRun.CopyDatasource(m_dstDatasourceInfo);

            InitializeDatasetView();
        }

        /// <summary>
        /// 初始化Dataset的名称列表
        /// Initialize the name list of dataset
        /// </summary>
        private void InitializeDatasetView()
        {
            try
            {
                if (m_sampleRun != null)
                {
                    String[] datasetNames = m_sampleRun.GetDatasetsNames();
                    foreach (String name in datasetNames)
                    {
                        datasetView.Nodes.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 初始化数据集类型列表
		/// Initialize the type list of dataset
        /// </summary>
        private void InitializeDatasetTypeCombox()
        {
            try
            {
				if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					datasetTypeCombox.Items.Add("Point");
               		datasetTypeCombox.Items.Add("Line");
                	datasetTypeCombox.Items.Add("Region");
                	datasetTypeCombox.Items.Add("Text");
                	datasetTypeCombox.Items.Add("CAD");
                	datasetTypeCombox.Items.Add("Table");

                	datasetTypeCombox.Items.Add("Grid");
                	datasetTypeCombox.Items.Add("Image");
				}
				else
				{
					datasetTypeCombox.Items.Add("点数据集");
                	datasetTypeCombox.Items.Add("线数据集");
                	datasetTypeCombox.Items.Add("面数据集");
                	datasetTypeCombox.Items.Add("文本数据集");
                	datasetTypeCombox.Items.Add("CAD数据集");
                	datasetTypeCombox.Items.Add("数据表数据集");

                	datasetTypeCombox.Items.Add("栅格数据集");
                	datasetTypeCombox.Items.Add("影像数据集");
				}

                datasetTypeCombox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 通过数据集类型字符获取对应的数据类型Type
		/// Get the type of the dataset by the string of the dataset type
        /// </summary>
        private DatasetType GetDatasetType(String typeName)
        {
            DatasetType result = DatasetType.Point;
            try
            {
                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                {
                    switch (typeName)
                    {
                        case "Point":
                            result = DatasetType.Point;
                            break;
                        case "Line":
                            result = DatasetType.Line;
                            break;
                        case "Region":
                            result = DatasetType.Region;
                            break;
                        case "Text":
                            result = DatasetType.Text;
                            break;
                        case "CAD":
                            result = DatasetType.CAD;
                            break;
                        case "Table":
                            result = DatasetType.Tabular;
                            break;
                        case "Grid":
                            result = DatasetType.Grid;
                            break;
                        case "Image":
                            result = DatasetType.Image;
                            break;
                        default:
                            result = DatasetType.Line;
                            break;
                    }
                }
                else
                {
                    switch (typeName)
                    {
                        case "点数据集":
                            result = DatasetType.Point;
                            break;
                        case "线数据集":
                            result = DatasetType.Line;
                            break;
                        case "面数据集":
                            result = DatasetType.Region;
                            break;
                        case "文本数据集":
                            result = DatasetType.Text;
                            break;
                        case "CAD数据集":
                            result = DatasetType.CAD;
                            break;
                        case "数据表数据集":
                            result = DatasetType.Tabular;
                            break;
                        case "栅格数据集":
                            result = DatasetType.Grid;
                            break;
                        case "影像数据集":
                            result = DatasetType.Image;
                            break;
                        default:
                            result = DatasetType.Line;
                            break;
                    }
                }				
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 此函数为了实现节点在失去焦点时依然可以看到选中状态
		/// The selected state is still visible when lose focus by this class
        /// </summary>        
        private void datasetView_LostFocus(object sender, EventArgs e)
        {
            try
            {
                datasetView.SelectedNode.BackColor = Color.DarkBlue;
                datasetView.SelectedNode.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void datasetView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (datasetView.SelectedNode != null)
                {
                    datasetView.SelectedNode.BackColor = Color.White;
                    datasetView.SelectedNode.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 删除选中的数据集
		/// Delete the selected dataset
        /// </summary>
        private void deleteCurrent_Click(object sender, EventArgs e)
        {
            try
            {

				if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
				{
					if (datasetView.SelectedNode == null)
                	{
                   	 	MessageBox.Show("No dataset is selected!");
                    	return;
                	}
                	if (MessageBox.Show("Are you sure to delete the dataset? Beyond retrieve", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                	{
                    	m_sampleRun.DeleteDataset(datasetView.SelectedNode.Text);
                    	datasetView.Nodes.Remove(datasetView.SelectedNode);
                	}
				}
				else
				{
                	if (datasetView.SelectedNode == null)
                	{
                    	MessageBox.Show("没有选中任何数据集！");
                    	return;
                	}
                	if (MessageBox.Show("确定要删除数据集？ 不可恢复", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                	{
                    	m_sampleRun.DeleteDataset(datasetView.SelectedNode.Text);
                    	datasetView.Nodes.Remove(datasetView.SelectedNode);
                	}
				}

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 修改名称响应函数
		/// Modify the name responding function
        /// </summary>
        private void changeName_Click(object sender, EventArgs e)
        {
            try
            {
                if (datasetView.SelectedNode == null)
                {
					if(SuperMap.Data.Environment.CurrentCulture !="zh-CN")
					{
						MessageBox.Show("No dataset is selected!");
					}
                    else{
						MessageBox.Show("没有选中任何数据集！");
					}
                    return;
                }
                if (m_sampleRun.RenameDataset(datasetView.SelectedNode.Text, newNameTextBox.Text))
                {
                    datasetView.SelectedNode.Text = newNameTextBox.Text;
                    newNameTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 当输入新名字时，修改名字按钮才可用
		/// The "Change Name" button is usable when input a new name in the textbox
        /// </summary>
        private void newNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (newNameTextBox.Text.Length != 0)
                {
                    changeName.Enabled = true;
                }
                else
                {
                    changeName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 当输入名字时，新建数据集按钮才可用
		/// The "New" button is usable when input a new name in the textbox
        /// </summary>
        private void createDatasetName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (createDatasetName.Text.Length != 0)
                {
                    createDataset.Enabled = true;
                }
                else
                {
                    createDataset.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 创建数据集
		/// Create the dataset
        /// </summary>
        private void createDataset_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_sampleRun.CreateDataset(GetDatasetType(datasetTypeCombox.Text), createDatasetName.Text))
                {
                    datasetView.Nodes.Add(createDatasetName.Text);
					if(SuperMap.Data.Environment.CurrentCulture !="zh-CN"){
						MessageBox.Show("Add the dataset successfully!");
					}
					else{
                    	MessageBox.Show("添加数据集成功");
                	}
				}
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }


    }
    public class AddDataSetAction
    {
        private Workspace m_workspace;
        // 保存拷贝后的数据源
        // Save the  datasource which has been copied
        private Datasource m_datasource;

        private String m_openfa = "";
        private String m_nameexisted = "";
        /// <summary>
        /// 构造函数，需要传入可用的工作空间和数据源连接信息
		/// Initialize the SampleRun object with the specified Workspace and DatasourceConnectionInfo
        /// </summary>
        public AddDataSetAction(Workspace workspace, Datasource datasource)
        {
            try
            {

                InitializeCultureResources();
                m_workspace = workspace;
                m_datasource = datasource;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void InitializeCultureResources()
        {
            if (SuperMap.Data.Environment.CurrentCulture == "zh-CN")
            {
                m_openfa = "数据打开失败~！";
                m_nameexisted = "该名字已经存在或不合法";
            }
            else
            {
                m_openfa = "Failed to open the datasource~!";
                m_nameexisted = "This name has been exited or invalid";
            }
        }



        /// <summary>
        /// 防止破坏数据，此处拷贝一份新的
		/// Make a new copy for the datasource in order to avoid destroying the data。
        /// </summary>
        public void CopyDatasource(DatasourceConnectionInfo dstInfo)
        {
            try
            {
                if (m_workspace.Datasources.Count == 0)
                {
                    m_datasource = null;
                    return;
                }
                CopyDatasource(m_workspace.Datasources[0].ConnectionInfo, dstInfo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 拷贝数据源
		/// Copy the datasource
        /// </summary>
        private void CopyDatasource(DatasourceConnectionInfo srcInfo, DatasourceConnectionInfo dstInfo)
        {
            try
            {
                String targetPath = dstInfo.Server;

                this.DeleteDatasource(dstInfo);

                m_datasource = m_workspace.Datasources.Create(dstInfo);
                if (m_datasource == null)
                {
                    throw new Exception("Create datasource failed");
                }

                Datasets datasetsToCopy = m_workspace.Datasources[srcInfo.Alias].Datasets;

                // 逐个拷贝数据集
                // Copy the datasets
                foreach (Dataset dataset in datasetsToCopy)
                {
                    m_datasource.CopyDataset(dataset, dataset.Name, dataset.EncodeType);
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 操作结束 删除数据源
		/// Delete the datasource when the operation is over
        /// </summary>
        public void DeleteDatasource(DatasourceConnectionInfo targetInfo)
        {
            try
            {
                this.CloseDatasource(targetInfo);

                String targetPath = targetInfo.Server;
                File.Delete(targetPath);

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 关闭数据源
		/// Close the datasource
        /// </summary>
        private void CloseDatasource(DatasourceConnectionInfo targetInfo)
        {
            try
            {
                if (m_datasource != null)
                {
                    m_workspace.Datasources.Close(targetInfo.Alias);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// 获取数据源中所有数据集的名称
		/// Get the names of all the datasets from the datasource
        /// </summary>
        public String[] GetDatasetsNames()
        {
            try
            {
                if (m_datasource != null)
                {
                    String[] datasetNames = new String[m_datasource.Datasets.Count];
                    Int32 index = 0;
                    foreach (Dataset dataset in m_datasource.Datasets)
                    {
                        datasetNames[index++] = dataset.Name;
                    }
                    return datasetNames;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// 删除数据集
		/// Delete the specified dataset
        /// </summary>
        public Boolean DeleteDataset(String datasetName)
        {
            try
            {
                if (m_datasource != null)
                {
                    return m_datasource.Datasets.Delete(datasetName);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 数据集重命名
		/// Rename the specified dataset
        /// </summary>
        public Boolean RenameDataset(String srcName, String targetName)
        {
            try
            {
                if (m_datasource != null)
                {
                    if (!m_datasource.Datasets.IsAvailableDatasetName(targetName))
                    {
                        MessageBox.Show(m_nameexisted);
                    }
                    else
                    {
                        return m_datasource.Datasets.Rename(srcName, targetName);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 创建数据集
		/// Create the dataset
        /// </summary>
        public Boolean CreateDataset(DatasetType datasetType, String datasetName)
        {
            Boolean result = false;
            if (m_datasource == null)
            {
                return result;
            }

            // 首先要判断输入的名字是否可用
            // Judge that whether the input name is usable or not
            if (!m_datasource.Datasets.IsAvailableDatasetName(datasetName))
            {
                MessageBox.Show(m_nameexisted);
                return result;
            }

            Datasets datasets = m_datasource.Datasets;
            DatasetVectorInfo vectorInfo = new DatasetVectorInfo();
            vectorInfo.Name = datasetName;

            try
            {
                // Point等为Vector类型，类型是一样的，可以统一处理
                // Data such as Point,Line,etc can be operated as the same method as they are all vector type
                switch (datasetType)
                {
                    case DatasetType.Point:
                    case DatasetType.Line:
                    case DatasetType.CAD:
                    case DatasetType.Region:
                    case DatasetType.Text:
                    case DatasetType.Tabular:
                        {
                            vectorInfo.Type = datasetType;
                            if (datasets.Create(vectorInfo) != null)
                                result = true;
                        }
                        break;
                    case DatasetType.Grid:
                        {
                            DatasetGridInfo datasetGridInfo = new DatasetGridInfo();
                            datasetGridInfo.Name = datasetName;
                            datasetGridInfo.Height = 200;
                            datasetGridInfo.Width = 200;
                            datasetGridInfo.NoValue = 1.0;
                            datasetGridInfo.PixelFormat = PixelFormat.Single;
                            datasetGridInfo.EncodeType = EncodeType.LZW;

                            if (datasets.Create(datasetGridInfo) != null)
                                result = true;
                        }
                        break;
                    case DatasetType.Image:
                        {
                            DatasetImageInfo datasetImageInfo = new DatasetImageInfo();
                            datasetImageInfo.Name = datasetName;
                            datasetImageInfo.BlockSizeOption = BlockSizeOption.BS_128;
                            datasetImageInfo.Height = 200;
                            datasetImageInfo.Width = 200;
                            //datasetImageInfo.Palette = Colors.MakeRandom(10);
                            datasetImageInfo.EncodeType = EncodeType.None;

                            if (datasets.Create(datasetImageInfo) != null)
                                result = true;
                        }
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return result;
        }
    }

}

