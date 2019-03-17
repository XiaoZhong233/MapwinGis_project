using AxMapWinGIS;
using MapWinGis_Demo_zhw.Forms;
using MWLite.Symbology.Forms;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace MapWinGis_Demo_zhw
{
    public class App
    {

        public static void getIdentifyResultForm(DockContent dc,DockState ds,string name)
        {
            IdentifyResultForm.getInstance().addForm(dc, ds);
            //IdentifyResultForm.getInstance.
            dc.Text = name;
            IdentifyResultForm.getInstance().Show();

        }

        /// <summary>
        /// 有可能抛出异常 最好别用这个
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="ds"></param>
        public static void getIdentifyResultForm(InformationForm dc, DockState ds)
        {
            getIdentifyResultForm(dc, ds, "Shape " + dc.E.shapeIndex);
        }


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
