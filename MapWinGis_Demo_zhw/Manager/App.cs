using AxMapWinGIS;
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
