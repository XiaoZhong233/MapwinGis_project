using System;
using System.Windows.Forms;
using MWLite.Symbology.Classes;
using MWLite.Symbology.Forms;
using MWLite.Symbology.Forms.Labels;
using MapWinGIS;

namespace MWLite.Symbology.LegendControl
{
    /// <summary>
    /// 图层树事件
    /// </summary>
    public class LegendEventHandler
    {
        private Legend m_legend = null;
        

        public LegendEventHandler(Legend legend)
        {
            if (legend == null)
                throw new NullReferenceException("Reference to the legend wasn't passed");
            
            m_legend = legend;
            m_legend.LayerColorboxClicked += m_legend_LayerColorboxClicked;
            m_legend.LayerLabelsClicked += m_legend_LayerLabelsClicked;
            m_legend.LayerCategoryClicked += m_legend_LayerCategoryClicked;
        }

        /// <summary>
        /// colorbox点击处理
        /// Handles the clicking on the layer color box
        /// </summary>
        /// <param name="Handle"></param>
        public void m_legend_LayerColorboxClicked(int Handle)
        {
            
            if (m_legend == null || m_legend.m_Map == null)
                return;

            MapWinGIS.Shapefile sf = m_legend.m_Map.get_Shapefile(Handle);
            if (sf != null)
            {
                Form form = FormHelper.GetSymbologyForm(m_legend, Handle, sf.ShapefileType, sf.DefaultDrawingOptions, false);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // do something
                }
                form.Dispose();
            }
        }

        /// <summary>
        /// lables点击事件处理
        /// </summary>
        /// <param name="Handle"></param>
        public void m_legend_LayerLabelsClicked(int Handle)
        {
            if (m_legend == null || m_legend.m_Map == null)
                return;

            MapWinGIS.Shapefile sf = m_legend.m_Map.get_Shapefile(Handle);
            if (sf != null)
            {
                using (Form form = new LabelStyleForm(m_legend, sf, Handle))
                { 
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        m_legend.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// 图例表点击事件处理
        /// Handling the clicking on the category preview
        /// </summary>
        public void m_legend_LayerCategoryClicked(int Handle, int Category)
        {
            
            if (m_legend == null || m_legend.m_Map == null)
                    return;

            MapWinGIS.Shapefile sf = m_legend.m_Map.get_Shapefile(Handle);
            if (sf != null)
            {
                MapWinGIS.ShapefileCategory cat = sf.Categories.get_Item(Category);
                if (cat != null)
                {
                    
                    Form form = FormHelper.GetSymbologyForm(m_legend, Handle, sf.ShapefileType, cat.DrawingOptions, false);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // do something
                    }
                    form.Dispose();
                    
                }
            }

        }
    }
}
