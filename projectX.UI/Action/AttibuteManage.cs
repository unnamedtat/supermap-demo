using SuperMap.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using ProjectX.UI.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMap.UI;
using System.Windows.Forms;
using SuperMap.Mapping;
using System.Diagnostics;
using System.Data;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private bool IsQuerying;//是否在进行查询
        private Point m_pointFirst;//拉框起点
        private Rectangle2D m_QueryRectangle;//拉框矩形
        private AttributeTable attributeTableForm;//属性表

        /// <summary>
        /// 初始化属性表相关
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitiAttributeMange()
        {
            this.IsQuerying = false;
            this.activeMapControl.GeometrySelected += new SuperMap.UI.GeometrySelectedEventHandler(m_mapControl_GeometrySelected);

            this.activeMapControl.MouseDown += new MouseEventHandler(MapMouseDownHandler);
            this.activeMapControl.MouseMove += new MouseEventHandler(MapMouseMoveHandler);
            this.activeMapControl.MouseUp += new MouseEventHandler(MapMouseUpHandler);
            this.ButtonSpatialQuery.Click += ButtonSpatialQuery_click;
            this.ButtonAttributeTable.Click += ButtonAttributeTable_Click;
        }

        private void ButtonAttributeTable_Click(object sender, EventArgs e)
        {
            this.attributeTableForm = new AttributeTable();
            if (layersControl.LayersTree.SelectedNode != null)
            {
                attributeTableForm.Text = "属性表:" + layersControl.LayersTree.SelectedNode.Name;
                attributeTableForm.Show();
                foreach (Datasource datasource in this.workspaceManage.workspace.Datasources)
                {
                    foreach (Dataset dataset in datasource.Datasets)
                    {
                        if (dataset.Name == layersControl.LayersTree.SelectedNode.Name)
                        {
                            DatasetVector datasetVector = dataset as DatasetVector;
                            Recordset recordset = datasetVector.GetRecordset(false, CursorType.Dynamic); ;
                            OutPutToTable(recordset);
                            return;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("请在图层管理器中选择查看的图层！");
            }
        }

        /// <summary>
        /// 关闭窗体时，不再查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void AttributeTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.IsQuerying = false;
            this.activeMapControl.GeometrySelected -= new SuperMap.UI.GeometrySelectedEventHandler(m_mapControl_GeometrySelected);
            this.activeMapControl.Action = SuperMap.UI.Action.Pan;
        }

        /// <summary>
        /// 处理GeometrySelected事件
        /// Manage the GeometrySelected event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mapControl_GeometrySelected(object sender, SuperMap.UI.GeometrySelectedEventArgs e)
        {
            ShowInfo();
        }
        /// <summary>
        /// 展示属性信息
        /// </summary>
        private void ShowInfo()
        {
            attributeTableForm.Text = "属性表:" + layersControl.LayersTree.SelectedNode.Name;
            //获取选择集
            Selection[] selection = this.activeMapControl.Map.FindSelection(true); //Selection[] 对应图层组

            //判断选择集是否为空
            if (selection == null || selection.Length == 0)
            {
                //MessageBox.Show("请选择要查询属性的空间对象");
                return;
            }
            Recordset recordset = selection[0].ToRecordset();
            OutPutToTable(recordset);
        }

        private void OutPutToTable(Recordset recordset)
        {
            DataGridView dataGridView = (DataGridView)attributeTableForm.Controls["dataGridView"];
            //将选择集转换为记录

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            for (int i = 0; i < recordset.FieldCount; i++)
            {
                //定义并获得字段名称
                String fieldName = recordset.GetFieldInfos()[i].Name;

                //将得到的字段名称添加到dataGridView列中
                dataGridView.Columns.Add(fieldName, fieldName);
            }

            //初始化row
            DataGridViewRow row;

            //根据选中记录的个数，将选中对象的信息添加到dataGridView中显示
            while (!recordset.IsEOF) //游标性质
            {
                row = new DataGridViewRow();
                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    //定义并获得字段值
                    Object fieldValue = recordset.GetFieldValue(i);
                    //将字段值添加到dataGridView中对应的位置
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (fieldValue != null)
                    {
                        cell.ValueType = fieldValue.GetType();
                        cell.Value = fieldValue;
                    }
                    row.Cells.Add(cell);
                }
                dataGridView.Rows.Add(row);
                recordset.MoveNext();
            }
            dataGridView.Update();
            recordset.Dispose();
        }

        private void MapMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (IsQuerying == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    m_pointFirst = e.Location;//m_pointFirst 记录的是屏幕坐标
                }
            }
        }
        private void MapMouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (IsQuerying == true)
            {
                //当处于左键按下状态时
                if (e.Button == MouseButtons.Left)
                {
                    //将起始点和当前鼠标点的像素坐标转换为地图坐标
                    Point2D point2DFirst = this.activeMapControl.Map.PixelToMap(m_pointFirst);
                    Point2D point2DAfterMove = this.activeMapControl.Map.PixelToMap(e.Location);//e.Location 现在屏幕坐标，换算成地图坐标

                    m_QueryRectangle = new Rectangle2D(new Point2D(point2DFirst.X, point2DAfterMove.Y), new Point2D(point2DAfterMove.X, point2DFirst.Y));

                    DisplayQueryRectangle(m_QueryRectangle);//标记显示出你拉框的范围
                }
            }
        }
        private void MapMouseUpHandler(object sender, MouseEventArgs e)
        {
            if (IsQuerying == true)
            {
                this.activeMapControl.Map.TrackingLayer.Clear();//先清除跟踪层拉框范围标记
                SpatialQuery();//基于拉框矩形（几何体）做空间查询
            }
        }
        /// <summary>
        /// 空间查询过滤动作
        /// </summary>
        public void SpatialQuery()
        {
            try
            {
                //注意：这里仅是展示了一种构建空间查询过滤条件的途径而已。

                // 设置查询参数
                QueryParameter parameter = new QueryParameter();
                parameter.SpatialQueryObject = m_QueryRectangle;//VIP1:设法构建空间查询过滤条件，动态构建SpatialQueryObject几何体。
                parameter.SpatialQueryMode = SpatialQueryMode.Intersect;//使用包含模式进行查询

                // 对指定查询的图层进行查询
                LayersTreeNodeBase node = layersControl.LayersTree.SelectedNode as LayersTreeNodeBase;
                Layer layer = this.GetLayerByCaption(node.Name);
                DatasetVector dataset = layer.Dataset as DatasetVector;

                //VPI2：查询，结果加入图层选中集合，还可结合前章例子，针对Recordset结果，展开各种功能。
                Recordset recordset2 = dataset.Query(parameter);
                layer.Selection.FromRecordset(recordset2);

                //layer.Selection.Style.LineColor = Color.Red;
                //layer.Selection.Style.LineWidth = 0.6;
                //layer.Selection.SetStyleOptions(StyleOptions.FillSymbolID, true);
                //layer.Selection.Style.FillSymbolID = 1;
                //layer.Selection.IsDefaultStyleEnabled = false;

                recordset2.Dispose();

                // 刷新地图
                activeMapControl.Map.Refresh();

                ShowInfo();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private Layer GetLayerByCaption(String layerCaption)
        {
            Layers layers = this.activeMapControl.Map.Layers;
            Layer result = null;

            foreach (Layer layer in layers)
            {
                if (String.Compare(layer.Caption, layerCaption, true) == 0)
                {
                    result = layer;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 标记拉框矩形
        /// </summary>
        /// <param name="rectangleDisplay"></param>
        private void DisplayQueryRectangle(Rectangle2D rectangleDisplay)
        {
            try
            {
                Double rectangleWidth = rectangleDisplay.Width;
                Double rectangleHeight = rectangleDisplay.Height;
                Double pntLeftTopX = rectangleDisplay.Left;
                Double pntLeftTopY = rectangleDisplay.Top;

                // 设置图框四点坐标
                Point2Ds points = new Point2Ds();
                Point2D pntLeftTop = new Point2D(pntLeftTopX, pntLeftTopY);
                points.Add(pntLeftTop);
                Point2D pntLeftBottom = new Point2D(pntLeftTopX, pntLeftTopY - rectangleHeight);
                points.Add(pntLeftBottom);
                Point2D pntRightBottom = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY - rectangleHeight);
                points.Add(pntRightBottom);
                Point2D pntRightTop = new Point2D(pntLeftTopX + rectangleWidth, pntLeftTopY);
                points.Add(pntRightTop);
                points.Add(pntLeftTop);

                // 将点连成线，并设置样式
                GeoLine rectangleBoundary = new GeoLine();
                rectangleBoundary.AddPart(points);

                GeoStyle rectangleStyle = new GeoStyle();
                rectangleStyle.LineColor = Color.FromArgb(255, 0, 0);
                rectangleStyle.LineWidth = 0.5;

                rectangleBoundary.Style = rectangleStyle;

                // 添加到跟踪层
                this.activeMapControl.Map.TrackingLayer.Clear();//先清除

                this.activeMapControl.Map.TrackingLayer.Add((Geometry)rectangleBoundary, "");
                this.activeMapControl.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 空间查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSpatialQuery_click(object sender, EventArgs e)
        {
            if (IsQuerying == false)
            {
                this.attributeTableForm = new AttributeTable();
                this.attributeTableForm.FormClosed += AttributeTableForm_FormClosed;
                if (layersControl.LayersTree.SelectedNode != null)
                {
                    IsQuerying = true;
                    this.activeMapControl.Action = SuperMap.UI.Action.Select;
                    attributeTableForm.Text = "属性表:" + layersControl.LayersTree.SelectedNode.Name;
                    attributeTableForm.Show();
                }
                else
                {
                    MessageBox.Show("请在图层管理器中选择需要查询的图层！");
                }
            }
        }
    }
}
