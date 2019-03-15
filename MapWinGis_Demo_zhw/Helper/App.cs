using AxMapWinGIS;
using MapWinGis_Demo_zhw.Forms;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw
{
    public class App
    {



        public static AxMap Map
        {
            get { return Main.Instance.Map; }
        }

        public static AxMap PreviewMap
        {
            get { return Main.Instance.PreviewMap; }
        }

        public static SnapShotForm SnapshotForm
        {
            get { return Main.Instance.SnapShotForm; }
        }

        public static Legend Legend
        {
            get { return Main.Instance.Legend; }
        }
        
        public static void RefreshUI()
        {
            Main.Instance.RefreshUI();
        }

        public static void LoadMapState(string filename)
        {
            Main.Instance.mapDockForm.LoadMapState(filename);
        }
    }
}
