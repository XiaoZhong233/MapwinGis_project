﻿using MapWinGIS;
using MWLite.Symbology.Forms.Labels;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MapWinGis_Demo_zhw.Enums;

namespace MapWinGis_Demo_zhw
{



    internal class LegendDispatcher : CommandDispatcher<LegendCommand>
    {
        internal int LayerHandle = -1;
        private Legend _legend = null;

        public LegendDispatcher(Legend legend)
        {
            _legend = legend;
        }

        public override void Run(LegendCommand command)
        {
            Shapefile sf = null;
            var layer = _legend.Layers.ItemByHandle(LayerHandle);
            if (layer != null)
            {
                sf = layer.GetObject() as Shapefile;
            }

            switch (command)
            {
                case LegendCommand.CalculateArea:
                    break;
                case LegendCommand.RemoveLayer:
                    LayerHelper.RemoveLayer();
                    break;
                case LegendCommand.LoadLayerStyle:
                    LayerHelper.LoadLayerStyle();
                    break;
                case LegendCommand.SaveLayerStyle:
                    LayerHelper.SaveCurrentStyle();
                    break;
                //case LegendCommand.ImportOgrLayer:
                //    LayerHelper.ImportOgrLayer();
                //    break;
                case LegendCommand.ZoomToLayer:
                    _legend.Map.ZoomToLayer(LayerHandle);
                    break;
                case LegendCommand.Labels:
                    {
                        using (Form form = new LabelStyleForm(_legend, sf, LayerHandle))
                        {
                            form.ShowDialog(MainForm.Instance);
                            _legend.Refresh();
                        }
                    }
                    break;
                case LegendCommand.Properties:
                    LayerHelper.ShowLayerProperties(LayerHandle);
                    break;
            }
        }

        protected override void CommandNotFound(ToolStripItem item) { }
    }
}
