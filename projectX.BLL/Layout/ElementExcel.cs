using System;
using System.Drawing;
using SuperMap.Data;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace ProjectX.BLL.Layout
{
    public class LayoutElemntFactory
    {
        public static LayoutCustomElemnt CreateElement(CustomElementType type)
        {
            LayoutCustomElemnt result = null;

            switch (type)
            {
                case CustomElementType.excel:
                    {
                        result = new ElementExcel();
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
    }

    /// <summary>
    /// 自行扩展的Excel图表对象，演示如何在布局中添加自定义扩展对象。
    /// </summary>
    public class ElementExcel : LayoutCustomElemnt
    {        
        private Image m_chart;
        private byte[] m_geoData;

        public String ChartName
        {
            get;
            set;
        }

        public ElementExcel(String excelFile, Rectangle2D bounds, String chartName)
        {
            Bounds = bounds;
            ChartName = chartName;

            if (!File.Exists(excelFile))
            {
                throw new FileNotFoundException("file not found", excelFile);
            }

            m_geoData = this.Encode(excelFile,ChartName);
        }

        /// <summary>
        /// 将excel文件，以及图表名称进行编码，转成可以用于保存到工作空间文档中的byte数组
        /// The excel file, and the chart name are encoded, into a byte array that can be used to save to the workspace document
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="chartName"></param>
        /// <returns></returns>
        private byte[] Encode(String excelFile,String chartName)
        {
            // m_geoData由chartName 和 文件的数据组成.
            // 数据由[4个字节存储chartName对应的utf8编码的字符串长度][chartName在utf8编码后的内容][excel文档数据]
            // m_geoData consists of chartName and the data of the file.
            // data is [4 bytes stored chartName corresponding to the utf8 encoded string length][Content of chartName after utf8 coding][excel document data]
            byte[] fileData = File.ReadAllBytes(excelFile);
            byte[] nameData = Encoding.UTF8.GetBytes(chartName);
            
            int nameLenght = nameData.Length;
            byte[] lenghtData = BitConverter.GetBytes(nameLenght);

            byte[] result = new byte[fileData.Length + nameData.Length + lenghtData.Length];
            // 写入字符串长度信息
            // Write string length information
            Array.Copy(lenghtData, result, lenghtData.Length);

            // 写入chartName在utf8编码后的数据
            // Write utf8 encoded chartName data
            Array.Copy(nameData, 0, result, lenghtData.Length, nameData.Length);

            // 写入文件数据
            // Write the file data
            Array.Copy(fileData, 0, result, lenghtData.Length + nameData.Length, fileData.Length);

            return result;


        }
        
        /// <summary>
        /// 将保存在工作空间中的byte数组进行解码，转为可以让扩展的Excel图表对象能够识别的内容
        /// Decodes the byte array saved in the workspace to the content that the extended Excel chart object can recognize.
        /// </summary>
        /// <param name="bytes">byte数据数组</param>
        /// <param name="startIndex">标示Excel图表对象起始的索引</param>
        /// <param name="allDataLength">标示Excel图表对象数据的长度</param>
        /// <param name="fileDataIndex">返回Excel文档在bytes中的起始索引</param>
        /// <param name="fileDataLeght">返回Excel文档在bytes中的数据长度</param>
        /// <param name="chartname">返回当前excel对象所使用的图表名称</param>
        /// /// <param name="bytes">byte data array</param>
        /// <param name="startIndex">Specifies the index of the beginning of the Excel chart object</param>
        /// <param name="allDataLength">Specifies the length of the Excel chart object data</param>
        /// <param name="fileDataIndex">Returns the starting index of the Excel document in bytes</param>
        /// <param name="fileDataLeght">Returns the length of the Excel document in bytes</param>
        /// <param name="chartname">Returns the name of the chart used by the current excel object</param>
        private void Decode(byte[] bytes, int startIndex, int allDataLength,out int fileDataIndex, out int fileDataLeght, out String chartname)
        {
            // 数据由[4个字节存储chartName对应的utf8编码的字符串长度][chartName在utf8编码后的内容][excel文档数据]
            // data is [4 bytes stored chartName corresponding to the utf8 encoded string length][Content of chartName after utf8 coding][excel document data]
            int lenght = BitConverter.ToInt32(bytes, startIndex);
            chartname = Encoding.UTF8.GetString(bytes, startIndex+4, lenght);

            fileDataIndex = 4 + lenght + startIndex;
            fileDataLeght = allDataLength - 4 - lenght;
        }

        public ElementExcel() { }

        /// <summary>
        /// 用于返回在布局存储时所需要存储的数据内容。
        /// Used to return the data content that needs to be stored in the layout store.
        /// </summary>
        /// <returns>返回自定义对象需要存储到布局中的字节数据</returns>
        /// <returns>Returns the byte data that the custom object needs to store in the layout</returns>
        protected override byte[] GetCustomData()
        {
            return m_geoData;
        }

        /// <summary>
        /// 自定义对象类型
        /// Customize object type
        /// </summary>
        public override CustomElementType Type
        {
            get { return CustomElementType.excel; }
        }      

        /// <summary>
        /// 读取存储的字节数据获取自定义绘制的对象，输出为png图片
        /// Read the stored byte data to get the custom drawing object and output it as a png image
        /// </summary>
        /// <param name="bytes">存储的自定义对象字节数据</param>
        /// <param name="startIndex">开始读取字节内容的索引</param>
        /// <param name="length">存储的字节长度</param>
        /// <returns>返回True</returns>        
        /// /// <param name="bytes">Stored the custom object byte data</param>
        /// <param name="startIndex">Start reading the index of byte content</param>
        /// <param name="length">The length of the stored bytes</param>
        /// <returns>Return True</returns>        
        public override bool FromBytes(byte[] bytes, int startIndex, int length)
        {
            Microsoft.Office.Interop.Excel.Application x = null;
            Workbook workbook = null;
            Worksheet workSheet = null;
            ChartObject chartobj = null;
            String tempFileName = null;
            String chartImageFile = "";

            try
            {
                
                int fileDataStartIndex = -1;
                int fileDataLength = -1;
                String chartName = null;

                this.Decode(bytes, startIndex, length, out fileDataStartIndex, out fileDataLength, out chartName);

                this.ChartName = chartName;

                tempFileName = Path.GetTempFileName();
                FileStream writer = new FileStream(tempFileName, FileMode.Truncate);
                writer.Write(bytes, fileDataStartIndex, fileDataLength);
                writer.Close();

                x = new Microsoft.Office.Interop.Excel.Application();

                workbook = x.Workbooks.Open(tempFileName, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(ChartName);

                chartobj = (ChartObject)workSheet.ChartObjects(1);

                chartImageFile = Path.GetFullPath(String.Format("../../test{0}.png", DateTime.Now.Ticks));                

                chartobj.Chart.Export(chartImageFile);
                m_chart = new Bitmap(chartImageFile); 
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                workbook.Close(null, null, null);
                x.Workbooks.Close();
                x.Quit();
                File.Delete(tempFileName);
            }

            return true;
        }

        /// <summary>
        /// 根据给定的位置和大小绘制自定义对象
        /// Draws a custom object based on the given position and size
        /// </summary>
        /// <param name="g">绘制自定义对象</param>
        /// <param name="location">自定义对象绘制的位置</param>
        /// <param name="size">自定义对象绘制的大小</param>
        /// /// <param name="g">Draws a custom object</param>
        /// <param name="location">Customize the position of the object drawing</param>
        /// <param name="size">Customize the size of the object drawing</param>
        public void DrawGraph(Graphics g, System.Drawing.PointF location, SizeF size)
        {
            if (m_chart != null)
            {
                g.DrawImage(m_chart, location.X, location.Y, size.Width, size.Height);
            }
         }
    }
}
