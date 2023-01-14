///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------鹰眼图等----------------------------
//
// 此部分用于实现鹰眼图、放大镜和与主地图相关的一些的基本操作功能
//------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////
using ProjectX.BLL;
using ProjectX.UI.Controls;
using SuperMap.Data;
using SuperMap.Mapping;
using SuperMap.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectX.UI
{
    public partial class MainForm
    {
        private Rectangle2D engleRectangle;//鹰眼图上指示范围
        private Point pointBefore;//指示中心
        private Boolean isMoveEngleRect;//是否移动指示范围

        private Int32 ScaleIndex;//放大尺度，默认为3，最大为10

        /// <summary>
        /// 初始化移动显示坐标信息
        /// </summary>
        private void initCoordinateInfo()
        {
            this.activeMapControl.MouseMove += new MouseEventHandler(UpdateCoordinateInfo);
        }

        private void UpdateCoordinateInfo(object sender, MouseEventArgs e)
        {
            Point2D point = this.activeMapControl.Map.PixelToMap(e.Location);//e.Location 现在屏幕坐标，换算成地图坐标
            this.tssLabelCoordinate.Text = "坐标： X= " + point.X + " Y= " + point.Y;
        }

        /// <summary>
        /// 初始化鹰眼图放大镜相关的事件
        /// </summary>
        private void initEagleZoomEvent()
        {
            mapControlEagleEye.MouseMove += new MouseEventHandler(EagleEyeMapMouseMoveHandler);
            mapControlEagleEye.MouseDown += new MouseEventHandler(EagleEyeMapMouseDownHandler);
            mapControlEagleEye.MouseUp += new MouseEventHandler(EagleEyeMapMouseUpHandler);
            mapControlEagleEye.ActionCursorChanging += new ActionCursorChangingEventHandler(EagleEyeMapCursorChangedHandler);

            activeMapControl.Map.Drawn += new MapDrawnEventHandler(MainMapDrawnHandler);
        }

        /// <summary>
        /// 地图绘制完成后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMapDrawnHandler(object sender, MapDrawnEventArgs e)
        {
            if (!isMoveEngleRect)
            {
                DisplayRect(activeMapControl.Map.ViewBounds);
            }
            ZoomForView();
        }
        /// <summary>
        /// 定义鹰眼图中鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseMoveHandler(object sender, MouseEventArgs e)
        {
            mapControlEagleEye.Cursor = Cursors.Arrow;

            try
            {
                MapControl eagleEyeMapControl = sender as MapControl;
                Map eagleEyeMap = eagleEyeMapControl.Map;
                // 当鼠标是在rect框内时，改变鼠标形态，对改变鼠标形态进行控制
                // Change the mouse shape when the mouse cursor move into the rect 
                if (engleRectangle.Contains(eagleEyeMap.PixelToMap(e.Location)))
                {
                    mapControlEagleEye.Cursor = Cursors.Cross;

                    if (e.Button == MouseButtons.Left)
                    {
                        isMoveEngleRect = true;
                    }
                }

                if (isMoveEngleRect)
                {
                    // 将pointBefore点和当前鼠标点的像素坐标转换为地图坐标
                    // Change the pixel coordinates of pointBefore and current point into the map coordinates
                    // 计算两点的坐标差对rect进行重新绘制
                    // Calculate the distance of the two point and redraw the rect
                    Point2D point2DBeforeMove = mapControlEagleEye.Map.PixelToMap(pointBefore);
                    Point2D point2DAfterMove = mapControlEagleEye.Map.PixelToMap(e.Location);

                    Double dx = point2DAfterMove.X - point2DBeforeMove.X;
                    Double dy = point2DAfterMove.Y - point2DBeforeMove.Y;

                    engleRectangle = new Rectangle2D(OffsetPoint(new Point2D(engleRectangle.Left, engleRectangle.Bottom), dx, dy), OffsetPoint(new Point2D(engleRectangle.Right, engleRectangle.Top), dx, dy));

                    DisplayRect(engleRectangle);
                    activeMapControl.Map.ViewBounds = engleRectangle;
                    activeMapControl.Map.Refresh();
                    // 将鼠标的当前点坐标存入pointBefore，以进行循环计算
                    // Save the current point coordinates into pointBefore
                    pointBefore = e.Location;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 定义鹰眼窗口鼠标按下事件，并将鼠标按下时的坐标保存到pointBefore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pointBefore = e.Location;
            }
        }
        /// <summary>
        /// 定义鼠标释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapMouseUpHandler(object sender, MouseEventArgs e)
        {
            try
            {
                // 左键释放，定义isMoveEngleRect为false
                // The isMoveEngleRect property is set to false
                if (e.Button == MouseButtons.Left)
                {
                    if (!isMoveEngleRect)
                    {
                        Point2D pntCenter = mapControlEagleEye.Map.PixelToMap(e.Location);
                        activeMapControl.Map.Center = pntCenter;
                        activeMapControl.Map.Refresh();
                    }

                    isMoveEngleRect = false;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 定义更新光标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EagleEyeMapCursorChangedHandler(object sender, ActionCursorChangingEventArgs e)
        {
            e.FollowingCursor = Cursors.Cross;
        }
        /// <summary>
        /// 放大镜按比例显示
        /// </summary>
        public void ZoomForView()
        {
            try
            {
                Point2D pntCenter = activeMapControl.Map.Center;
                mapControlMagnifier.Map.Center = pntCenter;

                //  选择地图放大倍数，放大镜窗口放大显示
                mapControlMagnifier.Map.Scale= activeMapControl.Map.Scale * ScaleIndex;
                mapControlMagnifier.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 按照指定风格显示指示范围矩形
        /// </summary>
        /// <param name="rectangleDisplay"></param>
        private void DisplayRect(Rectangle2D rectangleDisplay)
        {
            try
            {
                engleRectangle = rectangleDisplay;
                mapControlEagleEye.Cursor = Cursors.Cross;

                Double rectangleWidth = rectangleDisplay.Width;
                Double rectangleHeight = rectangleDisplay.Height;
                Double pntLeftTopX = rectangleDisplay.Left;
                Double pntLeftTopY = rectangleDisplay.Top;
                // 设置图框四点坐标
                // Set the four point of the rectangle
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
                // Connect the points to line and set its style

                GeoLine rectangleBoundary = new GeoLine();
                rectangleBoundary.AddPart(points);

                GeoStyle rectangleStyle = new GeoStyle();
                rectangleStyle.LineColor = Color.FromArgb(255, 0, 0);
                rectangleStyle.LineWidth = 0.5;

                rectangleBoundary.Style = rectangleStyle;
                // 添加到跟踪层
                // Add the rectangle into the trackinglayer
                mapControlEagleEye.Map.TrackingLayer.Clear();
                mapControlEagleEye.Map.TrackingLayer.Add((Geometry)rectangleBoundary, "");
                mapControlEagleEye.Map.Refresh();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 构建offset点对象
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        private Point2D OffsetPoint(Point2D point, Double dx, Double dy)
        {
            Point2D temp = point;
            temp.Offset(dx, dy);

            return temp;
        }
    }
}
