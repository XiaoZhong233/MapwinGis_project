using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;

namespace MapWinGis_Demo_zhw.Controls
{
    public partial class IdentifierContextMenu : UserControl
    {

        private static bool ShowTooltip = true;

        public IdentifierContextMenu()
        {
            InitializeComponent();
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
        }

        public ContextMenuStrip Menu
        {
            get { return contextMenuStrip1; }
        }

        void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxHotTracking.Checked = App.Map.Identifier.HotTracking;
            ctxAllLayers.Checked = App.Map.Identifier.IdentifierMode == tkIdentifierMode.imAllLayers;
            ctxCurrentLayer.Checked = App.Map.Identifier.IdentifierMode == tkIdentifierMode.imSingleLayer;
            ctxShowTooltip.Checked = ShowTooltip;
            ctxShowTooltip.Enabled = ctxHotTracking.Checked;
        }


        private void ctxAllLayers_Click(object sender, EventArgs e)
        {
            App.Map.Identifier.IdentifierMode = tkIdentifierMode.imAllLayers;
        }

        private void ctxCurrentLayer_Click(object sender, EventArgs e)
        {
            App.Map.Identifier.IdentifierMode = tkIdentifierMode.imSingleLayer;
        }

        private void ctxHotTracking_Click(object sender, EventArgs e)
        {
            App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
        }

        private void ctxShowTooltip_Click(object sender, EventArgs e)
        {
            ShowTooltip = !ShowTooltip;
        }



    }
}
