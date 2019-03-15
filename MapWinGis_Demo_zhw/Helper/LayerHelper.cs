using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MapWinGis_Demo_zhw.Enums;

namespace MapWinGis_Demo_zhw
{
    internal static class LayerHelper
    {


        public static string GetLayerFilter(AxMap map, LayerType layerType)
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
        /// 显示要素属性卡
        /// </summary>
        /// <param name="layerHandle"></param>
        public static void ShowLayerProperties(int layerHandle)
        {
            //未实现
        }

        /// <summary>
        /// 在最顶层的组加入某个图层，调用此方法AXmap会自动加载图层
        /// </summary>
        /// <param name="layer"></param>
        public static void AddLayer(object layer)
        {
            if (layer == null) return;
            App.Legend.Layers.Add(layer, true);
        }

        /// <summary>
        /// 在某个组中加入图层，在该组的最顶端加入
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="targetGroupHandle"></param>
        public static void AddLayer(object layer,int targetGroupHandle)
        {
            if (layer == null) return;
            App.Legend.Layers.Add(layer, true, targetGroupHandle);
        }

        /// <summary>
        /// 在最顶层的组加入某个图层
        /// </summary>
        /// <param name="layer">图层</param>
        /// <param name="legendVisble">图层在图层树的可见性</param>
        /// <param name="mapVisble">图层在地图中的可见性</param>
        public static void AddLayer(object layer,bool legendVisble,bool mapVisble)
        {
            if (layer == null) return;
            App.Legend.Layers.Add(legendVisble, layer, mapVisble);
        }
        
        /// <summary>
        /// 在特定位置加入图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="targetGroupHandle">组位置</param>
        /// <param name="afterLayerHandle">图层位置</param>
        public static void AddLayer(object layer,int targetGroupHandle,int afterLayerHandle)
        {
            if (layer == null) return;
            App.Legend.Layers.Add(layer, true, targetGroupHandle, afterLayerHandle);
        }


        /// <summary>
        /// 打开一个新图层，指定类型
        /// </summary>
        /// <param name="layerType"></param>
        public static void AddLayer(LayerType layerType)
        {
            var map = App.Map;

            var dlg = new OpenFileDialog { Filter = GetLayerFilter(map,layerType), Multiselect = true };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            var legend = App.Legend;

            legend.Lock();
            map.LockWindow(tkLockMode.lmLock);

            string layerName = "";
            try
            {
                var fm = new FileManager();
                foreach (var name in dlg.FileNames.ToList())
                {
                    layerName = name;
                    var layer = fm.Open(name);
                    if (layer == null)
                    {
                        string msg = string.Format("Failed to open datasource: {0} \n {1}", name, fm.ErrorMsg[fm.LastErrorCode]);
                        MessageBox.Show("警告："+msg);
                    }
                    else if (layer is OgrDatasource)
                    {
                        var ds = layer as OgrDatasource;
                        for (int i = 0; i < ds.LayerCount; i++)
                        {
                            var l = ds.GetLayer(i, false);
                            AddLayer(l);
                        }
                        map.ZoomToMaxExtents();
                    }
                    else
                    {
                        AddLayer(layer);
                    }
                }
            }
            catch
            {
                MessageBox.Show("该图层打开出现错误 " + layerName);
            }
            finally
            {
                legend.Unlock();
                map.LockWindow(tkLockMode.lmUnlock);
            }
        }

        /// <summary>
        /// 移除某个图层
        /// </summary>
        public static void RemoveLayer()
        {
            int layerHandle = App.Legend.SelectedLayer;
            if (layerHandle != -1)
            {
                App.Legend.Layers.Remove(layerHandle);
                App.Legend.Refresh();
            }
        }

        /// <summary>
        /// 缩放至图层
        /// </summary>
        public static void ZoomToLayer()
        {
            int handle = App.Legend.SelectedLayer;
            App.Map.ZoomToLayer(handle);
        }



        /// <summary>
        /// 缩放至图层树所选图层
        /// </summary>
        public static void ZoomToSelected()
        {
            int handle = App.Legend.SelectedLayer;
            App.Map.ZoomToSelected(handle);
        }


        /// <summary>
        /// 清除图层树的选择图层的选择状态
        /// </summary>
        public static void ClearSelection()
        {
            int handle = App.Legend.SelectedLayer;
            var sf = App.Map.get_Shapefile(handle);
            if (sf != null)
            {
                sf.SelectNone();
                MainForm.Instance.RefreshUI();
                App.Map.Redraw();
            }
        }


        /// <summary>
        /// 保存图层的样式
        /// </summary>
        public static void SaveCurrentStyle()
        {
            var legend = App.Legend;
            int layerHandle = legend.SelectedLayer;
            if (layerHandle != -1)
            {
         
                bool result = App.Map.SaveLayerOptions(layerHandle, "", true, "");
                if (result)
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }

            }
        }



        public static void LoadLayerStyle()
        {
            var legend = App.Legend;
            int layerHandle = legend.SelectedLayer;
            if (layerHandle != -1)
            {
                string description = "";
                bool result = App.Map.LoadLayerOptions(layerHandle, "", ref description);
                if (result)
                {
                    App.Map.Redraw();
                    App.Legend.Refresh();
                    MessageBox.Show("图层样式加载成功");
                }
                else
                {
                    string msg = "No options are loaded: " + App.Map.get_ErrorMsg(App.Map.LastErrorCode);
                    var layer = App.Map.get_OgrLayer(layerHandle);
                    if (layer != null)
                    {
                        msg += Environment.NewLine + "Last GDAL error message: " + layer.GdalLastErrorMsg;
                    }
                    MessageBox.Show("失败： " + msg);
                }
            }
            else
            {
                MessageBox.Show("当前未选中图层");
            }
        }


        /// <summary>
        /// 图层树加入新数据组,加在最顶层
        /// </summary>
        /// <param name="name"></param>
        public static void AddGroup(string name)
        {
            App.Legend.Groups.Add(name);
        }

        /// <summary>
        /// 在图层树中特定位置加入新的数据组
        /// </summary>
        /// <param name="name">数据组名称</param>
        /// <param name="position">位置</param>
        public static void AddGroup(string name,int position)
        {
            App.Legend.Groups.Add(name, position);

        }

    }
}
