using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Layout;
using System.IO;
using ProjectX.BLL;

namespace SuperMap.SampleCode.Layout
{
    public class LayoutManage
    {
        private Workspace m_workspace;
        private MapLayoutControl m_mapLayoutControl;
        private Int32 m_mapID = 0;
        private Dictionary<Int32, ElementExcel> m_dicElementExcel;

        /// <summary>
        /// 根据workspace和map构造 SampleRun对象
        /// Constructs a SampleRun object based on the workspace and map
        /// </summary>
        public LayoutManage(Workspace workspace, MapLayoutControl mapLayoutControl)
        {
            try
            {
                m_workspace = workspace;
                m_mapLayoutControl = mapLayoutControl;
                m_dicElementExcel = new Dictionary<Int32, ElementExcel>();

                Initialize();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 打开需要的工作空间文件及事件注册
        /// Open the required workspace files and event registration
        /// </summary>
        private void Initialize()
        {
            try
            {
                // 打开工作空间及地图
                // Open the workspace and map
                String filePath = Path.GetFullPath("../../SampleData/China/China400.smwu");
                WorkspaceConnectionInfo conInfo = new WorkspaceConnectionInfo(filePath);                
                m_workspace.Open(conInfo);

                if (SuperMap.Data.Environment.CurrentCulture == "zh-CN")
                {
                    m_mapLayoutControl.MapLayout.Open(m_workspace.Layouts[0]);
                }
                else
                {
                    m_mapLayoutControl.MapLayout.Open(m_workspace.Layouts[1]);
                }
                
                m_mapLayoutControl.ElementDeleted += m_mapLayoutControl_ElementDeleted;
                m_mapLayoutControl.MapLayout.GeoUserDefinedDrawing += MapLayout_GeoUserDefinedDrawing;
                SetLayoutAction(SuperMap.UI.Action.Pan);

                InitializeLayout();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 初始化布局，添加一个默认的图表
        /// Initialize the layout, add a default chart
        /// </summary>
        private void InitializeLayout()
        {
            try
            {
                Rectangle2D bounds = m_mapLayoutControl.MapLayout.Bounds;
                Point leftTop = m_mapLayoutControl.MapLayout.LayoutToPixel(new Point2D(bounds.Left, bounds.Top));

                AddExcelHistogramToLayout(new Point(leftTop.X + 77, leftTop.Y + 80), "统计图表1");          
                
                m_mapLayoutControl.MapLayout.Refresh();
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 布局自定义绘制事件，通过该事件处理函数，将Excel图表绘制到布局中
        /// Layout custom drawing event, through which the Excel chart is drawn into the layout.
        /// </summary>        
        private void MapLayout_GeoUserDefinedDrawing(object sender, MapLayoutGeoUserDefinedDrawingEventArgs e)
        {
            try
            {
                e.Cancel = true;

                ElementExcel excel = null;
                if (m_dicElementExcel.ContainsKey(e.Geometry.ID))
                {
                    excel = m_dicElementExcel[e.Geometry.ID];
                }
                else
                {
                    excel = LayoutCustomElemnt.FromGeoUser(e.Geometry) as ElementExcel;
                    m_dicElementExcel.Add(e.Geometry.ID, excel);
                }

                Rectangle2D bounds = e.Geometry.Bounds;
                PointF leftTop = new PointF();
                PointF rightBottom = new PointF();

                // 在打印的时候Graphics的单位与控件显示的坐标系不同，需要根据绘制参数进行不同的处理坐标转换处理
                // At the time of printing, the units of Graphics are different from the coordinate systems displayed by the controls, and they need to be processed differently according to the drawing parameters.
                if (e.IsPrinting)
                {
                    leftTop = e.LayoutToPrinter(new Point2D(bounds.Left, bounds.Top));
                    rightBottom = e.LayoutToPrinter(new Point2D(bounds.Right, bounds.Bottom));                  
                }
                else
                {
                    leftTop = e.MapLayout.LayoutToPixel(new Point2D(bounds.Left, bounds.Top));
                    rightBottom = e.MapLayout.LayoutToPixel(new Point2D(bounds.Right, bounds.Bottom));
                }

                excel.DrawGraph(e.Graphics, leftTop, new SizeF(Math.Abs(rightBottom.X - leftTop.X), Math.Abs(rightBottom.Y - leftTop.Y)));
            }
            catch (System.Exception ex)
            {
                e.Cancel = false;
                Trace.WriteLine(ex.Message);
            }  
        }

        /// <summary>
        /// 在布局上面单击后添加自定义图表到布局
        /// Add a custom chart to the layout after clicking on the layout
        /// </summary>        
        public void AddHistogramClick(object sender, MouseEventArgs e)
        {            
            try
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    Cursor preCursor = m_mapLayoutControl.Cursor;
                    m_mapLayoutControl.Cursor = MapLayoutControl.Cursors.Busy;
                    AddExcelHistogramToLayout(e.Location, "统计图表2");
                    m_mapLayoutControl.MapLayout.Refresh();
                    m_mapLayoutControl.Cursor = preCursor;
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// 添加自定义图表到布局
        /// Add a custom chart to the layout
        /// </summary>
        /// <param name="location">自定义图表将要绘制的位置</param>
        /// <param name="location">The location where the customize chart will be drawn</param>
        public void AddExcelHistogramToLayout(Point location, String chartname)
        {
            try
            {
                LayoutElements elements = m_mapLayoutControl.MapLayout.Elements;

                String excelFile = Path.GetFullPath("../../SampleData/China/Province_R.xlsx");
                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                {
                    excelFile = Path.GetFullPath("../../SampleData/China/Province_R_en.xlsx");
                }

                Point2D locationLayout = m_mapLayoutControl.MapLayout.PixelToLayout(location);
                Rectangle2D bounds = new Rectangle2D(locationLayout.X, locationLayout.Y - 650, locationLayout.X + 1700, locationLayout.Y);
                ElementExcel excel = new ElementExcel(excelFile, bounds, chartname);

                GeoUserDefined geo = excel.ToGeoUser();
               
                if (geo==null)
                {
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        MessageBox.Show("Icon to get empty, please confirm whether the icon exists or whether to install office excel locally!");
                    }
                    else
                    {
                        MessageBox.Show("图标获取为空，请确认图标是否存在或本地是否装有office excel！");
                    }
                }
                elements.AddNew(geo);

                //Debug.Assert(elements.AddNew(geo));
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 改变LayoutMapControl的LayoutMapAction，这里设置为null时重定义为添加excel图表
        /// Change LayoutMapAction of LayoutMapControl, When this is set to null, it is redefined to add the excel chart.
        /// </summary>        
        public void SetLayoutAction(SuperMap.UI.Action action)
        {
            try
            {
                m_mapLayoutControl.LayoutAction = action;
                if (action == SuperMap.UI.Action.Null)
                {
                    // null 用于添加excel元素，需要设置自定义光标
                    // Null To add an excel element, you need to set a custom cursor
                    m_mapLayoutControl.ActionCursorChanging += ActionCursorChanging;
                    m_mapLayoutControl.Cursor = Cursors.Cross;
                    m_mapLayoutControl.MouseClick += AddHistogramClick;
                } 
                else
                {
                    // 非添加excel图表使用预定义光标
                    // Non-add excel chart using predefined cursors
                    m_mapLayoutControl.ActionCursorChanging -= ActionCursorChanging;
                    m_mapLayoutControl.MouseClick -= AddHistogramClick;

                }
                
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 侦听光标变化事件，以实现在添加布局元素时使用需要的光标
        /// Monitor to the cursor change event to implement the desired cursor when adding the layout element
        /// </summary>
        void ActionCursorChanging(object sender, ActionCursorChangingEventArgs e)
        {
            if (e.FollowingCursor != MapLayoutControl.Cursors.Busy)
            {
                e.FollowingCursor = Cursors.Cross;
            }
        }



        /// <summary>
        /// 打印布局
        /// Print layout
        /// </summary>
        public void PrintLayout(String printerName)
        {
            try
            {
                m_mapLayoutControl.MapLayout.Printer.PrinterName = printerName;
                m_mapLayoutControl.MapLayout.Printer.Print();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 另存工作空间，用于演示如何将自定义的元素保存到工作空间中。
        /// 不过针对保存了的数据，如果想显示跟SampleCode的一样，也需要在目标程序中添加对应的处理，否则会以默认的方式显示自定义对象
        /// Save the workspace to show how to save custom elements to the workspace.
        /// But for the preservation of the data, if you want to show the same with the SampleCode, also need to add the corresponding process in the target process, otherwise it will be the default way to display custom objects
        /// </summary>
        public void SaveAsLayout()
        {
            // 保存布局对象
            //  Save the layout object
            String xml = m_mapLayoutControl.MapLayout.ToXML();
            m_workspace.Layouts.SetLayoutXML(0, xml);
                        
            String file_saveAs = Path.GetFullPath("../../SampleData/China/China400_SaveAs.smwu");
            WorkspaceConnectionInfo workspaceConnectionInfo_saveAs = new WorkspaceConnectionInfo(file_saveAs);
            m_workspace.SaveAs(workspaceConnectionInfo_saveAs);
        }

       

        /// <summary>
        /// 侦听对象删除事件，并在对象删除后从内存中的移除，以便释放所占用的内容。
        /// Monitor to the object delete event and remove it from the memory after the object is deleted in order to free the occupied content.
        /// </summary>
        void m_mapLayoutControl_ElementDeleted(object sender, ElementEventArgs e)
        {
            try
            {
                if (m_dicElementExcel.ContainsKey(e.ID))
                {
                    m_dicElementExcel.Remove(e.ID);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}


