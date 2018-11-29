using AxMapWinGIS;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapWinGis_Demo_zhw
{
    class App
    {

        public static AxMap Map
        {
            get { return MainForm.Instance.Map; }
        }

        public static Legend Legend
        {
            get { return MainForm.Instance.Legend; }
        }


        public static void RefreshUI()
        {
            MainForm.Instance.RefreshUI();
        }

        public static void LoadMapState(string filename)
        {
            MainForm.Instance.LoadMapState(filename);
        }
    }
}
