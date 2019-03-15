using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MapWinGis_Demo_zhw.Enums;

namespace MapWinGis_Demo_zhw
{
    public interface IMapApp
    {
        Legend Legend { get; }
        AxMapWinGIS.AxMap Map { get; }
        void RefreshUI();
        void AddMenu(ToolStripMenuItem menu);
        void AddToolbar(ToolStrip toolbar);
        IProject Project { get; }
        void RunCommand(APPCommand.AppCommand command);
    }

    public interface IProject
    {
        bool IsEmpty { get; }
        string GetPath();
        Enums.ProjectState GetState();
        bool Save();
        void SaveAs();
        void Load(string filename);
        bool TryClose();
        event EventHandler<EventArgs> ProjectChanged;
    }

    /// <summary>
    /// 接口，概览地图
    /// 可操纵鸟瞰地图 PreviewMap
    /// </summary>
    public interface PreviewMap
    {
        /// <summary>
        /// 背景颜色
        /// </summary>
        System.Drawing.Color BackColor { get; set; }

        /// <summary>
        /// 显示的图片
        /// </summary>
        System.Drawing.Image Picture { get; set; }

        /// <summary>
        /// LocatorBox的颜色
        /// </summary>
        System.Drawing.Color LocatorBoxColor { get; set; }

        /// <summary>
        /// 按照传过来的地图重新显示地图
        /// </summary>
        void GetPictureFromMap();

        /// <summary>
        /// 让PreviewMap重绘地图，根据主地图中当前范围传过来的数据 (current extents).
        /// </summary>
        void Update();

        /// <summary>
        /// 更新自己的显示的地图.
        /// <param name="updateExtents">从当前范围还是从全图范围更新Preview的视图</param>
        /// </summary>
        void Update(ePreviewUpdateExtents updateExtents);

        /// <summary>
        /// 从指定的目录加载一张图片到PreviewMap中
        /// </summary>
        /// <param name="filename">图片的路径</param>
        /// <returns>true 加载成功，false，失败</returns>
        bool GetPictureFromFile(string filename);

        /// <summary>
        /// 关闭预览地图控件
        /// </summary>
        void Close();

        /// <summary>
        /// 浮动停靠预览地图控件
        /// </summary>
        /// <param name="dockStyle"> The dock style</param>
        void DockTo(DockStyle dockStyle);
    }




}
