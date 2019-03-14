using MapWinGIS;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MapWinGis_Demo_zhw.Forms
{
    public partial class LegendDockForm : DockContent
    {
        private LegendDispatcher _dispatcher = null;

        public LegendDockForm()
        {
            InitializeComponent();
            _dispatcher = new LegendDispatcher(legend1);
            _dispatcher.InitMenu(contextMenuStrip1.Items);
            legend1.LayerMouseUp += legend1_LayerMouseUp;
            legend1.LayerDoubleClick += legend1_LayerDoubleClick;
        }

        public Legend Legend
        {
            get { return legend1; }
        }

        private void legend1_LayerDoubleClick(int Handle)
        {
            LayerHelper.ShowLayerProperties(Handle);
        }

        private void legend1_LayerMouseUp(int Handle, MouseButtons button)
        {
            if (button == MouseButtons.Right && Handle != -1)
            {
                legend1.SelectedLayer = Handle;
                var layer = legend1.Layers.ItemByHandle(Handle);
                if (layer != null)
                {
                    _dispatcher.LayerHandle = Handle;
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var layer = legend1.Layers.ItemByHandle(_dispatcher.LayerHandle);
            if (!(layer.GetObject() is Shapefile))
            {
                ctxPostGis.Enabled = false;
                ctxLabels.Enabled = false;
                ctxCalculateArea.Enabled = false;
            }
        }
    }
}
