using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Data;

namespace ProjectX.BLL.Layout
{
    /// <summary>
    /// 布局自定义元素类型，这里仅实现了excel图表，在实现多种对象时需要多个枚举常量。
    /// 该常量必须是byte大小，以便能够方便地存储到工作空间中。
    /// </summary>
    public enum CustomElementType : byte
    {
        excel=0
    }
    /// <summary>
    /// 布局自定义元素的基类，其提供与SuperMap内部能够识别的GeoUserDefined对象之间的相互转化。
    /// </summary>
    public abstract class  LayoutCustomElemnt
    {        
        /// <summary>
        /// 自定义布局元素在布局中的范围，单位与布局的坐标单位相同，单位为0.1毫米
        /// </summary>
        public Rectangle2D Bounds
        {
            get;
            set;
        }

        /// <summary>
        /// 返回自定义元素需要保存到工作空间中所需要存储的数据内容。此为抽象方法，子类比较实现该方法
        /// </summary>        
        protected abstract Byte[] GetCustomData();
        
        /// <summary>
        /// 抽象方法，读取存储的字节数据获取自定义绘制的对象，输出为png图片
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <param name="chartName"></param>
        /// <returns></returns>
        public abstract bool FromBytes(Byte[] bytes, int startIndex, int length);

        //

        /// <summary>
        /// 返回用于识别不同子类的枚举值，此为抽象方法，子类需要实现
        /// <returns></returns>
        /// </summary>
        public abstract CustomElementType Type
        {
            get;
        }

        /// <summary>
        /// 将自定义元素转为SuperMap能够识别的自定义几何对象对象
        /// </summary>
        /// <returns>返回对应的自定义几何对象</returns>
        public GeoUserDefined ToGeoUser()
        {
            GeoUserDefined geo = new GeoUserDefined();
            Byte[] data = GetCustomData();
            Byte[] bytes = new Byte[data.Length + 1];
            bytes[0] = (Byte)this.Type;
            Array.Copy(data, 0, bytes, 1, data.Length);
            geo.SetGeoData(Bounds, bytes);

            return geo;
        }

        /// <summary>
        /// 将保存在工作空间文档中的自定义几何对象转为用户自定义布局元素
        /// </summary>
        /// <param name="geoUser">保存在工作空间文档中的自定义几何对象</param>
        /// <returns>返回布局自定义元素</returns>
        public static LayoutCustomElemnt FromGeoUser(GeoUserDefined geoUser)
        {
            Byte[] bytes = geoUser.GetGeoData();
            CustomElementType type = (CustomElementType)bytes[0];
            LayoutCustomElemnt elemnt = LayoutElemntFactory.CreateElement(type);
            elemnt.FromBytes(bytes, 1, bytes.Length - 1);
            elemnt.Bounds = geoUser.Bounds;
            return elemnt;
        }
    }
}
