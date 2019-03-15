using AxMapWinGIS;
using MapWinGIS;
using MapWinGis_Demo_zhw.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MapWinGis_Demo_zhw.Enums;

namespace MapWinGis_Demo_zhw.Model
{
    /// <summary>
    /// 地图扩展方法
    /// </summary>
    public static class MapExt
    {
        /// <summary>
        /// 设置默认范围
        /// </summary>
        /// <param name="map"></param>
        public static void SetDefaultExtents(this AxMap map)
        {
            map.Projection = tkMapProjection.PROJECTION_NONE;
            var ext = new Extents();
            ext.SetBounds(0.0, 0.0, 0.0, 100.0, 100.0, 0.0);
            map.Extents = ext;
        }

        /// <summary>
        /// 获取图层属性
        /// </summary>
        /// <param name="map"></param>
        /// <param name="layerHandle"></param>
        /// <param name="shapeIndex"></param>
        /// <returns></returns>
        public static string GetAttributes(this AxMap map, int layerHandle, int shapeIndex)
        {
            string s = "";
            var sf = map.get_Shapefile(layerHandle);
            if (sf == null)
                return s;

            string name = map.get_LayerName(layerHandle);
            s += "图层: " + name + "\n";
            s += "Shape ID: " + shapeIndex + "\n\n";


            var shp = sf.Shape[shapeIndex];
            if (shp != null && map.ShapeEditor.IsUsingEllipsoid)
            {
                var type = shp.ShapeType2D;
                if (type == ShpfileType.SHP_POLYLINE)
                {
                    s += "长度, m: " + map.GeodesicLength(shp).ToString("0.0") + "\n\n";
                }
                if (type == ShpfileType.SHP_POLYGON)
                {
                    s += "周长, m: " + map.GeodesicLength(shp).ToString("0.0") + "\n";
                    s += "面积, ha: " + (map.GeodesicArea(shp) / 10000).ToString("0.0") + "\n\n";
                }
            }

            s += "属性:\n";
            //只选前十个
            for (int i = 0; i < Math.Min(sf.NumFields, 10); i++)
            {
                s += sf.Field[i].Name + " = " + sf.CellValue[i, shapeIndex] + Environment.NewLine;
            }
            if (sf.NumFields > 10)
            {
                s += "查看更多左键点击...";
            }
            return s;
        }

        /// <summary>
        ///像素转换为坐标
        /// </summary>
        /// <param name="map"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static double PixelToProj(this AxMap map, int pixel)
        {
            double h1, w1, h2, w2;
            h1 = h2 = w1 = w2 = 0.0;
            map.PixelToProj(0, 0, ref w1, ref h1);
            map.PixelToProj(0, -pixel, ref w2, ref h2);
            return Math.Abs(h1 - h2);
        }

        /// <summary>
        /// symbol的垂直偏移量
        /// </summary>
        /// <param name="map"></param>
        /// <param name="opt"></param>
        /// <param name="shpType"></param>
        /// <returns></returns>
        public static int VerticalIconOffset(this AxMap map, ShapeDrawingOptions opt, ShpfileType shpType)
        {
            if (shpType == ShpfileType.SHP_POINT && opt.Picture != null &&
                opt.PointType == tkPointSymbolType.ptSymbolPicture)
            {
                return (int)(((double)opt.Picture.Height * opt.PictureScaleY) / 2.0 + 0.5);
            }
            return 0;
        }

        /// <summary>
        /// 点的捕捉容差
        /// </summary>
        /// <param name="map"></param>
        /// <param name="opt"></param>
        /// <param name="shpType"></param>
        /// <returns></returns>
        public static double PointTolerance(this AxMap map, ShapeDrawingOptions opt, ShpfileType shpType)
        {
            switch (shpType)
            {
                case ShpfileType.SHP_POINT:
                    double w = 0.0, h = 0.0, w1 = 0.0, h1 = 0.0;
                    var img = opt.Picture;
                    map.PixelToProj(0, 0, ref w, ref h);
                    map.PixelToProj(img != null ? img.Width : opt.PointSize, img != null ? img.Height : opt.PointSize,
                                    ref w1, ref h1);
                    return (Math.Abs(w1 - w) + Math.Abs(h1 - h)) / 2.0;
                default:
                    return 0.0;
            }
        }


        /// <summary>
        /// 获取文件选择器（用来打开某个类型的图层）
        /// </summary>
        /// <param name="map"></param>
        /// <param name="layerType"></param>
        /// <returns></returns>
        public static string GetLayerFilter(this AxMap map, LayerType layerType)
        {
            switch (layerType)
            {
                case LayerType.All:
                    return map.FileManager.CdlgFilter;
                case LayerType.Raster:
                    return map.FileManager.CdlgRasterFilter;
                case LayerType.Vector:
                    return map.FileManager.CdlgVectorFilter;
            }
            return "All files|*.*";
        }

        /// <summary>
        /// 获取地图快照
        /// </summary>
        /// <param name="map"></param>
        /// <param name="parentForm"></param>
        public static void MakeScreenshot(this AxMap map, Form parentForm)
        {
            var ext = map.Extents as MapWinGIS.Extents;

            var img = map.SnapShot3(ext.xMin, ext.xMax, ext.yMax, ext.yMin, map.Width);
            if (img != null)
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "*.jpg|*.jpg";
                    if (dlg.ShowDialog(parentForm) == DialogResult.OK)
                    {
                        if (!img.Save(dlg.FileName, false, ImageType.JPEG_FILE))
                        {
                            MessageHelper.Warn("Failed to save image: " + img.get_ErrorMsg(img.LastErrorCode));
                        }
                        else
                        {
                            MessageHelper.Warn("Image is saved: " + dlg.FileName);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 返回最大可见范围
        /// 所有可见的关联的层的范围
        /// </summary>
        public static Extents MaxVisibleExtents(this AxMap map)
        {

            MapWinGIS.Extents tExts = new MapWinGIS.Extents();
            bool bFoundVisibleLayer = false;
            double maxX = 0, maxY = 0, minX = 0, minY = 0;
            int i;
            double dx, dy;

            int numLyr = map.NumLayers;
            for (i = 0; i < numLyr; i++)
            {
                int lyrHandle = map.get_LayerHandle(i);
                if (map.get_LayerVisible(lyrHandle))
                {
                    tExts = map.get_layerExtents(lyrHandle);
                    if (bFoundVisibleLayer == false)
                    {
                        maxX = tExts.xMax;
                        minX = tExts.xMin;
                        maxY = tExts.yMax;
                        minY = tExts.yMin;
                        bFoundVisibleLayer = true;
                    }
                    else
                    {
                        if (tExts.xMax > maxX)
                        {
                            maxX = tExts.xMax;
                        }
                        if (tExts.yMax > maxY)
                        {
                            maxY = tExts.yMax;
                        }
                        if (tExts.xMin < minX)
                        {
                            minX = tExts.xMin;
                        }
                        if (tExts.yMin < minY)
                        {
                            minY = tExts.yMin;
                        }
                    }
                }
            }

            dx = maxX - minX;
            dx = dx * map.ExtentPad;
            maxX = maxX + dx;
            minX = minX - dx;

            dy = maxY - minY;
            dy = dy * map.ExtentPad;
            maxY = maxY + dy;
            minY = minY - dy;

            tExts = new MapWinGIS.Extents();
            tExts.SetBounds(minX, minY, 0, maxX, maxY, 0);
            return tExts;
        }


  




    }
}
