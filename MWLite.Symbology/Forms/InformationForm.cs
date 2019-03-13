using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWLite.Symbology.Forms
{

    
    public partial class InformationForm : Form
    {
        public static bool flag = false;

        AxMap _axMap;
        private _DMapEvents_ShapeHighlightedEvent _e;//点击位置

        public InformationForm(AxMap axMap, _DMapEvents_ShapeHighlightedEvent e)
        {
            _axMap = axMap;
            _e = e;
            flag = true;

            InitializeComponent();
        }

        public InformationForm(AxMap axMap, _DMapEvents_ShapeIdentifiedEvent e)
        {
            _DMapEvents_ShapeHighlightedEvent ee = new _DMapEvents_ShapeHighlightedEvent(e.layerHandle, e.shapeIndex);
            _axMap = axMap;
            _e = ee;
            flag = true;

            InitializeComponent();
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            Shapefile shapefile = _axMap.get_Shapefile(_e.layerHandle);
            if (shapefile != null)
            {   
                
                informationDGV.Columns.Add("column1", "Field");
                informationDGV.Columns.Add("column2", "Value");
                
                for (int i = 0; i < shapefile.NumFields; i++)
                {
                    informationDGV.Rows.Add();
                    informationDGV.Rows[i].Cells[0].Value = shapefile.Field[i].Name;
                    informationDGV.Rows[i].Cells[1].Value = shapefile.CellValue[i, _e.shapeIndex];
                    
                }
            }
        }

        private void InformationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            flag = false;
        }
    }
}
