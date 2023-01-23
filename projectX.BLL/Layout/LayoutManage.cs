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


namespace ProjectX.BLL.Layout
{
    public class LayoutManage
    {
        public EventHandler<Boolean> ISActiveMapExist;
        public MapLayoutControl LayoutControl { get; set; }
        /// <summary>
        /// 添加布局控件和Tabpage页
        /// </summary>
        public TabPage AddLayoutAndTab(string mapLayoutName,TabControl utpMap,Workspace workspace)
        {
            TabPage tabPage = new TabPage();
            MapLayoutControl mapLayoutControl = new MapLayoutControl();
            mapLayoutControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(mapLayoutControl);
            utpMap.TabPages.Add(tabPage);
            this.LayoutControl = mapLayoutControl;
            this.LayoutControl.MapLayout.Workspace = workspace;
            // 打开布局窗口水平、垂直滚动条
            this.LayoutControl.IsHorizontalScrollbarVisible = true;
            this.LayoutControl.IsVerticalScrollbarVisible = true;
            tabPage.Text = mapLayoutName;
            return tabPage;
        }
        /// <summary>
        /// 布局的普通操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IButtonLayout_Click(object sender, EventArgs e)
        {
            Button imageButton = (Button)sender;
            switch (imageButton.Tag)
            {
                case "0": this.LayoutControl.LayoutAction = SuperMap.UI.Action.Select2; break;
                case "1": this.LayoutControl.LayoutAction = SuperMap.UI.Action.ZoomIn; break;
                case "2": this.LayoutControl.LayoutAction = SuperMap.UI.Action.ZoomOut; break;
                case "3": this.LayoutControl.LayoutAction = SuperMap.UI.Action.ZoomFree; break;
                case "4": this.LayoutControl.LayoutAction = SuperMap.UI.Action.Pan; break;
                case "5": this.LayoutControl.MapLayout.ZoomToPaper(); break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 弹出布局设置对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IButtonOpenLayoutSetting_Click(object sender, EventArgs e)
        {
            LayoutSettingDialog.ShowDialog(LayoutControl.MapLayout, "布局设置：" +LayoutControl.Name);
        }
        /// <summary>
        /// 打开布局
        /// </summary>
        /// <param name="mapLayoutName"></param>
        public void OpenLayout(string mapLayoutName)
        {
            this.LayoutControl.MapLayout.Open(mapLayoutName);
            this.LayoutControl.MapLayout.Refresh();

        }
        /// <summary>
        /// 设置当前活跃布局控件对象
        /// </summary>
        /// <param name="LayoutControl"></param>
        public void SetLayoutControl(MapLayoutControl LayoutControl)
        {
            this.LayoutControl = LayoutControl;
        }
        /// <summary>
        /// 检查布局是否已存在
        /// </summary>
        /// <param name="mapName"></param>
        /// <param name="utpMap"></param>
        /// <returns></returns>
        public TabPage checkLayoutIsInUtp(string mapLayoutName, TabControl utpMap)
        {
            foreach (TabPage tabpage in utpMap.TabPages)
            {
                if (tabpage.Controls[0] is MapLayoutControl)
                {
                    MapLayoutControl mapLayoutControl = (MapLayoutControl)tabpage.Controls[0];
                    if (mapLayoutControl.MapLayout.Name == mapLayoutName) return tabpage;
                }
            }
            return null;
        }
        /// <summary>
        /// 对布局中选中map的操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MapEvent(object sender, EventArgs e)
        {
            LayoutSelection layoutSelection = LayoutControl.MapLayout.Selection;
            LayoutElements layoutElements = LayoutControl.MapLayout.Elements;
            int ID = layoutSelection[0];
            layoutElements.SeekID(ID);
            Geometry geometry = layoutElements.GetGeometry();
            Button button =(Button)sender;
            switch (button.Tag)
            {
                case "锁定":
                    LockMap(ID); break;
                case "放大":
                    LayoutControl.MapAction=SuperMap.UI.Action.ZoomIn;break;
                case "缩小":
                    LayoutControl.MapAction = SuperMap.UI.Action.ZoomOut; break;
                case "漫游":
                    LayoutControl.MapAction = SuperMap.UI.Action.Pan; break;
                case "缩放":
                    LayoutControl.MapAction = SuperMap.UI.Action.ZoomFree; break;
                case "全幅":
                    LayoutControl.ActiveMap.ViewEntire(); break;
                case "刷新":
                    LayoutControl.ActiveMap.Refresh(); break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 是否锁定地图
        /// </summary>
        public void LockMap(int m_mapID)
        {
            try
            {
                if (m_mapID == LayoutControl.ActiveGeoMapID)
                {
                    LayoutControl.ActiveGeoMapID = -1;
                    ISActiveMapExist(null, false);
                }
                else
                {
                    LayoutControl.ActiveGeoMapID = m_mapID;
                    ISActiveMapExist(null, true);
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


